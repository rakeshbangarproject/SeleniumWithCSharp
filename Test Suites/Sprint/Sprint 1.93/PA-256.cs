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
    [TestFixture, Category("Smoke_test")]
    public class InteriorGirt : BaseClass
    {
        [Test]
        public void LengthOverrides()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Interior Girt override length doesn't work");
            OpenDefaultJobAndPlaceInteriorWall();
            ClickWallLinerAndCheckInteriorHasLinerCheckBox();
            EnterLengthInInteriorGirtAndSelectMaterialFromInteriorWallDropdown();
            ApplyInteriorWallMaterialToINTWallFromAdvancedEdit();
            CheckLengthOverrides();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Interior Girt override length doesn't work");
        }

        #region Private Method
        private void CheckLengthOverrides()
        {
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            CheckLengthOverridesApplyOnTheWall("2x4", "12'", "EXT-1");
            CheckLengthOverridesApplyOnTheWall("Zee Rotated", "20'", "INT-1");
            ExtentTestManager.TestSteps("Verify the interior girt length of the main building and Advanced Edit shown in the job review.");
            Console.WriteLine("Verify the interior girt length of the main building and Advanced Edit shown in the job review.");
            ExtentTestManager.TestSteps("Verify interior girt overrides is apply on the canvas building");
            Console.WriteLine("Verify interior girt overrides is apply on the canvas building");
        }

        private void ApplyInteriorWallMaterialToINTWallFromAdvancedEdit()
        {
            DefaultJobElement.ClickAdvancedEdit();
            ClicksOnElement("(//div[text()='INT-1'])[1]");
            WaitForElementVisible("(//div[@id='form_myForm_tabs'])[1]");
            DefaultJobElement.ClickDetails();
            ClicksOnElement("(//div[text()='Interior Girt Framing'])[1]");
            InteriorGirtPartLengths(12);
            SelectInteriorGirtMaterial("td", "2x4");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
        }

        private void EnterLengthInInteriorGirtAndSelectMaterialFromInteriorWallDropdown()
        {
            DefaultJobElement.ClickDetails();
            ClicksOnElement("(//div[text()='Interior Girt Framing'])[1]");
            ExtentTestManager.TestSteps("Click on the Interior Girt Framing tab");
            InteriorGirtPartLengths(20);
            SelectInteriorGirtMaterial("div", "Zee Rotated");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            CheckLengthOverridesApplyOnTheWall("Zee Rotated", "20'", " ");
            ExtentTestManager.TestSteps("Verify that the Interior girt length is shown as the main building length of the interior girt");
            Console.WriteLine("Verify that the Interior girt length is shown as the main building length of the interior girt");
        }

        private void ClickWallLinerAndCheckInteriorHasLinerCheckBox()
        {
            DefaultJobElement.ClickWallLiner();
            ClicksOnElement("(//input[@name='InternalHasLiner'])[1]");
            ExtentTestManager.TestSteps("Check interior has liner checkbox");
        }

        private void OpenDefaultJobAndPlaceInteriorWall()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            NavigateTo2DViewAndClicksInteriorWallTab();
            PlaceInteriorWall();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SaveButtonOf2DView();
        }

        private void CheckLengthOverridesApplyOnTheWall(string materialName, string pickLengthOfMaterial, string panelElement)
        {
            IReadOnlyList<IWebElement> getRow = Driver.FindElements(By.XPath($"//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='InteriorGirt']]"));
            bool result = false;

            foreach (IWebElement row in getRow)
            {
                IReadOnlyList<IWebElement> material = row.FindElements(By.XPath(".//td[@col='3']"));

                for (int i = 0; i < material.Count; i++)
                {
                    string jobReviewMaterial = material[i].Text;

                    if (jobReviewMaterial.Equals(materialName))
                    {
                        CommonMethod.GetActions().DoubleClick(material[i]).Perform();
                        CommonMethod.Wait(2);

                        IWebElement table = Driver.FindElement(By.XPath("//div[@id='w2ui-overlay']//table[@id='mlpopup']"));
                        IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

                        foreach (IWebElement row1 in rows.Skip(1))
                        {
                            IList<IWebElement> columns1 = row1.FindElements(By.TagName("td"));

                            if (columns1[1].Text.Equals(materialName))
                            {
                                result = true;
                                string materialOfCultLength = columns1[1].Text;
                                string pickLength = columns1[3].Text;
                                string panel = columns1[4].Text;
                                Assert.That(materialOfCultLength.Equals(materialName) && pickLength.Equals(pickLengthOfMaterial) && !panel.Equals(panelElement), "Interior girt length overrides is not working");
                            }
                        }
                    }
                }
            }

            Assert.That(result, Is.True, "Interior girt length overrides is not working");
        }

        private void WaitForElementVisible(string xPath)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        private void NavigateTo2DViewAndClicksInteriorWallTab()
        {
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickInteriorWallsFromThe2DView();
            DefaultJobElement.ClickAddRoom();
            AttachedInteriorWall();
        }

        private void PlaceInteriorWall()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("drawingArea")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).MoveByOffset(250, -250).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Place interior wall on the 2D canvas building");
        }

        private void AttachedInteriorWall()
        {
            DimensionFields(30, "//input[@name='lenstr']");
            DimensionFields(30, "//input[@name='widstr']");
        }

        private void ClicksOnElement(string xpath)
        {
            IWebElement element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            CommonMethod.GetActions().MoveToElement(element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        private void SelectInteriorGirtMaterial(string tagName, string nameOfElement)
        {
            string materialOfInteriorWall = "//div[@id='w2ui-overlay']//{0}[text()='{1}']";
            ClicksOnElement("(//label[text()='Interior Girt Material'])[1]//following::div[5]");
            ClicksOnElement(string.Format(materialOfInteriorWall, tagName, nameOfElement));
            ExtentTestManager.TestSteps($"Select {nameOfElement} from the interior girt material dropdown");
        }

        private void DimensionFields(int value, string xPath)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPath)));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
        }

        private void InteriorGirtPartLengths(int value)
        {
            DimensionFields(value, "(//input[@name='InteriorGirtPartLengths'])[1]");
        }
    }
}
#endregion