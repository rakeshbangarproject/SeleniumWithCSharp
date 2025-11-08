using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    public class DefaultMaterial : BaseClass
    {
        [Test]
        public void LoftMaterialTest()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Case 1: Check for the Loft");
            string joistMaterial, floorSheathing;
            SetDefaultValueAndPlaceLoft(out joistMaterial, out floorSheathing);
            VerifyMaterial(joistMaterial, floorSheathing);

            UpdateAndVerifyMaterial("4Ply2x8", "Brick_Tex_48");
            UpdateAndVerifyMaterial(joistMaterial, floorSheathing);

            ExtentTestManager.CreateTest("Case 2: Check for the Interior Wall");
            RefreshJobPage();

            DefaultJobElement.ClickDetails();
            string interiorStudFraming = GetFloorMaterial("Interior Stud Framing", "Interior Stud Material");
            ExtentTestManager.TestSteps("Get the interior stud material from 3D view");

            SetDefaultValueInTheInteriorStudFramingSubFields();
            RefreshJob();
            NavigateTo2DViewAndClicksInteriorWallTab();
            ClicksOnElement("(//td[text()='Add Room'])[1]");
            string interiorStudFramingOf2DView = GetInteriorStudMaterialFrom2DView();
            Assert.That(interiorStudFraming.Equals(interiorStudFramingOf2DView), "Interior Stud Framing default material is not shown in the interior wall pop");
            ExtentTestManager.TestSteps("Verify that the Interior Stud Framing default material is shown in the interior wall pop");

            AttachedInteriorWall();
            PlaceInteriorWall();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SaveButtonOf2DView();
            CheckInteriorMaterialInJobReview(interiorStudFramingOf2DView);
            ExtentTestManager.TestSteps("Verify that Stud, Top plat, Bottom plate, and Very Bottom Plate material are update in the framing.");
            UpdateInteriorWallMaterialAndVerifyInTheFraming("1.5x3.5Cee Shape");
            UpdateInteriorWallMaterialAndVerifyInTheFraming(interiorStudFraming);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Check for the Loft");
        }

        private static bool RefreshJobPage()
        {
            Driver.Navigate().Refresh();

            try
            {
                Driver.SwitchTo().Alert().Accept();
                CommonMethod.PageLoader();
                return true;
            }
            catch(NoAlertPresentException)
            {
                CommonMethod.PageLoader();
                return false;
            }

        }

        private void UpdateInteriorWallMaterialAndVerifyInTheFraming(string materialName)
        {
            NavigateTo2DViewAndUpdateInteriorStudMaterial(materialName);
            CheckInteriorMaterialInJobReview(materialName);
        }

        private void CheckInteriorMaterialInJobReview(string interiorStudFramingOf2DView)
        {

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();

            string[] usages = new string[4] { "Stud", "TopPlate", "BottomPlate", "VeryBottomPlate" };

            for (int i = 0; i < usages.Length; i++)
            {
                CheckMaterialInTheJobReview(usages[i], interiorStudFramingOf2DView, "INT-1", $"{usages[i]} after set default value in the interior stud material");
            }
        }

        private void NavigateTo2DViewAndUpdateInteriorStudMaterial(string materialName)
        {
            NavigateTo2DViewAndClicksInteriorWallTab();
            ExistingInteriorWall();
            SelectInteriorStudMaterial(materialName);
            Driver.FindElement(By.XPath("//div[@id='w2ui-popup']//following::label[text()='Interior Stud Material']")).Click();
            DefaultJobElement.ClickUpdateButtonOfWall();
            DefaultJobElement.SaveButtonOf2DView();
        }

        private void NavigateTo2DViewAndClicksInteriorWallTab()
        {
            DefaultJobElement.ClickEdit2DView();
            InteriorWall();
        }

        private void SetDefaultValueAndPlaceLoft(out string joistMaterial, out string floorSheathing)
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();

            string defaultJoistMaterial = GetFloorMaterial("Floor Framing", "Joist Material");
            string defaultWallSheathingMaterial = GetFloorMaterial("Floor Sheathing", "Floor Sheathing");
            ExtentTestManager.TestSteps("Get the default value of joist material and floor sheathing");

            NavigateTo2DViewAndClicksLoft();
            DefaultJobElement.ClickAddButtonOfLofts();
            CommonMethod.Wait(2);
            joistMaterial = GetJoistMaterialFrom2DView();
            floorSheathing = GetFloorSheathingFrom2DView();

            Assert.That(joistMaterial.Equals(defaultJoistMaterial) && floorSheathing.Equals(defaultWallSheathingMaterial), "Joist material and floor sheathing default values are not shown in the loft");
            ExtentTestManager.TestSteps("Verify that the Joist Material and Floor Sheathing Material are set to their default values.");

            PlaceMaterialIn2DViewAndSave();
        }

        private void RefreshJob()
        {
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
        }

        private void ExistingLoft()
        {
            IWebElement loft = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_loftList2d_rec_') and descendant::div[text()='Loft-1']]")));
            CommonMethod.GetActions().MoveToElement(loft).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(" //div[text()='Create Loft']")));
            ExtentTestManager.TestSteps("Double click on the attached loft");
        }

        private void ExistingInteriorWall()
        {
            IWebElement loft = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_wallList2d_rec_') and descendant::div[text()='INT-1']]")));
            CommonMethod.GetActions().MoveToElement(loft).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(" //div[text()='Edit Wall']")));
            ExtentTestManager.TestSteps("Double click on the attached interior wall");
        }

        private void VerifyMaterial(string joistMaterial, string floorSheathing)
        {
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            CheckMaterialInTheJobReview("FloorJoist", joistMaterial, "LOFT-1", "framing table after the joist material in 2D view");
            ExtentTestManager.TestSteps("Verify that Joist material is update in the framing.");
            DefaultJobElement.ClickSheathingOfJobReview();
            CheckMaterialInTheJobReview("FloorTop", floorSheathing, "LOFT-1", "sheathing table after the floor sheathing material in 2D view");
            ExtentTestManager.TestSteps("Verify that floor sheathing material is update in the sheathing.");
        }

        private void UpdateAndVerifyMaterial(string joistMaterial, string floorSheathing)
        {
            UpdateTheJoistAndFloorSheathingMaterial(joistMaterial, floorSheathing);
            VerifyMaterial(joistMaterial, floorSheathing);
        }

        private void UpdateTheJoistAndFloorSheathingMaterial(string joist, string sheathing)
        {
            NavigateTo2DViewAndClicksLoft();
            ExistingLoft();
            SelectJoistMaterial(joist);
            SelectFloorSheathingMaterial(sheathing);
            DefaultJobElement.ClickUpdateButtonOfLoft();
            DefaultJobElement.SaveButtonOf2DView();
        }

        private void SelectJoistMaterial(string name)
        {
            string materialNameOfJoist = "//div[@id='w2ui-overlay']//div[text()='{0}']";
            ClicksOnElement("//div[@id='w2ui-popup']//following::label[text()='Joist Material']//following::div[5]");
            ClicksOnElement(string.Format(materialNameOfJoist, name));
            ExtentTestManager.TestSteps($"Set {name} material to the joist material dropdown");
        }

        private void SelectFloorSheathingMaterial(string name)
        {
            string materialNameOfJoist = "//div[@id='w2ui-overlay']//div[text()='{0}']";
            ClicksOnElement("(//label[text()='Floor Sheathing'])[3]//following::div[5]");
            ClicksOnElement(string.Format(materialNameOfJoist, name));
            ExtentTestManager.TestSteps($"Set {name} material to the floor sheathing material dropdown");
        }

        private void SelectInteriorStudMaterial(string name)
        {
            string materialNameOfJoist = "//div[@id='w2ui-overlay']//td[text()='{0}']";
            CommonMethod.Wait(2);
            ClicksOnElement("//div[@id='w2ui-popup']//following::label[text()='Interior Stud Material']//following::div[2]");
            ClicksOnElement(string.Format(materialNameOfJoist, name));
            ExtentTestManager.TestSteps($"Set {name} material to the Interior Stud Material dropdown");
        }

        private void SetDefaultValueInTheInteriorStudFramingSubFields()
        {
            string materialNameOfJoist = "(//label[text()='{0}'])[1]//following::div[5]";
            string[] dropdownLists = new string[4] { "Interior Top Plate", "Interior Very Top Plate", "Interior Bottom Plate", "Interior Very Bottom Plate" };
            for (int i = 0; i < dropdownLists.Length; i++)
            {
                ClicksOnElement(string.Format(materialNameOfJoist, dropdownLists[i]));
                ClicksOnElement("//div[@id='w2ui-overlay']//div[text()='(interior stud)']");
            }

            ExtentTestManager.TestSteps($"Set (interior stud) to the Interior Top Plate, Interior Very Top Plate, Interior Very Bottom Plate, and  Interior Bottom Plate dropdowns");
        }

        private void InteriorWall()
        {
            ClicksOnElement("(//div[normalize-space()='InteriorWalls'])[1]");
            ExtentTestManager.TestSteps("Click on the interior walls tab");
        }

        private void AttachedInteriorWall()
        {
            DimensionFields(30, "//input[@name='lenstr']");
            DimensionFields(30, "//input[@name='widstr']");
        }

        private void DimensionFields(int value, string XPath)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(XPath)));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
        }

        private static void PlaceMaterialIn2DViewAndSave()
        {
            DefaultJobElement.PlaceOpening(250, 250);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SaveButtonOf2DView();
        }

        private void PlaceInteriorWall()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("drawingArea")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).MoveByOffset(250, -250).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Place interior wall on the 2D canvas building");
        }

        private string GetJoistMaterialFrom2DView()
        {
            return GetMaterial("Joist Material", 3);
        }

        private string GetInteriorStudMaterialFrom2DView()
        {
            return GetMaterial("Interior Stud Material", 3);
        }

        private string GetFloorSheathingFrom2DView()
        {
            return GetMaterial("Floor Sheathing", 3);
        }

        private static void NavigateTo2DViewAndClicksLoft()
        {
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickLoftsFromThe2DView();
        }

        private string GetMaterial(string materialLabel, int num)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//label[text()='{materialLabel}'])[{num}]//following::div[2]"))).GetAttribute("title");
        }

        private string GetFloorMaterial(string tabName, string dropdownName)
        {
            ClickOnTab(tabName);
            ExtentTestManager.TestSteps($"Click on the {tabName} tab");
            return GetMaterial(dropdownName, 1);
        }

        private void ClickOnTab(string tabName)
        {
            IWebElement tabElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"(//div[text()='{tabName}'])[1]")));
            CommonMethod.GetActions().MoveToElement(tabElement).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        private void ClicksOnElement(string xpath)
        {
            CommonMethod.Wait(1);
            IWebElement element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            CommonMethod.GetActions().MoveToElement(element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        private void CheckMaterialInTheJobReview(string usageName, string material, string panelName, string message)
        {
            IReadOnlyList<IWebElement> getRow = Driver.FindElements(By.XPath($"//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='{usageName}']]"));

            foreach (IWebElement row in getRow)
            {
                IReadOnlyList<IWebElement> column = row.FindElements(By.XPath(".//td[@col='3']"));

                for (int i = 0; i < column.Count; i++)
                {
                    string jobReviewMaterial = column[i].Text;
                    Assert.That(jobReviewMaterial, Is.EqualTo(material), $"{material} is not shown in the {message}");

                    CommonMethod.GetActions().DoubleClick(column[i]).Perform();
                    CommonMethod.Wait(2);

                    IWebElement table = Driver.FindElement(By.XPath("//div[@id='w2ui-overlay']//table[@id='mlpopup']"));
                    IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

                    foreach (IWebElement row1 in rows.Skip(1))
                    {
                        IList<IWebElement> columns1 = row1.FindElements(By.TagName("td"));

                        if (columns1[0].Text.Equals(usageName))
                        {
                            string data = columns1[1].Text;
                            string panel = columns1[4].Text;

                            Assert.That(data, Is.EqualTo(material), $"Material of {panelName} is not same in the framing ");
                            Assert.That(panel, Is.EqualTo(panelName), "panel is not match with 2D view");
                        }
                    }
                }
            }
        }
    }
}
