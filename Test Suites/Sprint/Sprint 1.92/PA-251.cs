using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProjectBeta.Test_Suites.Sprint.Sprint_1._92
{
    //[TestFixture, Category("Smoke_test")]
    public class BaySpan : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-251");

        [Test]
        public void CheckBaySpanOfOpenWallCarrier()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Open Wall Carrier Bay Span not working");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            CaseOneForBaySpan();
            CaseTwoForBaySpan();
            CaseThreeForBaySpan();
            CaseFourForBaySpan();
            CaseFiveForBaySpan();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Open Wall Carrier Bay Span not working");
        }

        // Case 5: Combined wall where both walls are open
        private void CaseFiveForBaySpan()
        {
            ExtentTestManager.CreateTest("Case 5: Combined wall where both walls are open");
            DefaultJobElement.ClickCanvas3DViewButton();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.Click3DEdit();
            CommonMethod.Wait(2);

            EditButtonAndPlaceCanvasBuilding();

            if (!CommonMethod.IsElementPresent(By.XPath("//label[text()='Walls']//following::div[5]")))
            {
                for (int i = 0; i < 20; i++)
                {
                    EditButtonAndPlaceCanvasBuilding();
                    if (CommonMethod.IsElementPresent(By.XPath("//label[text()='Walls']//following::div[5]")))
                    {
                        break;
                    }
                }
            }

            SelectWallsElement("Open");
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            CheckCanvasBuildingModify(initialValue, currentValue, "Left side of the wall is not open");
            CaptureScreenshot("Post Intersection");
            NavigateToDrawingPageAndClickEXT_1();
            string post = CheckThePostValue();
            Assert.That(post, Is.EqualTo("3"), "Verify that the bay span is not used for the open portion, for the enclosed portion");
            ExtentTestManager.TestSteps("Verify that the intersection post place in the left side");
        }

        // Case 4: Combined open/enclosed wall where the ‘main’ wall is open
        private void CaseFourForBaySpan()
        {
            ExtentTestManager.CreateTest("Case 4: Combined open/enclosed wall where the ‘main’ wall is open");
            DefaultJobElement.ClickCanvas3DViewButton();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            CommonMethod.Wait(2);

            EditButtonAndPlaceCanvasBuilding();
            ExtentTestManager.TestSteps($"Click On The Edit 3D tab");

            if (!CommonMethod.IsElementPresent(By.XPath("//label[text()='Walls']//following::div[5]")))
            {
                for (int i = 0; i < 20; i++)
                {
                    EditButtonAndPlaceCanvasBuilding();
                    if (CommonMethod.IsElementPresent(By.XPath("//label[text()='Walls']//following::div[5]")))
                    {
                        break;
                    }
                }
            }

            SelectWallsElement("Enclosed");
            ApplyButtonOfPorch();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewBackLeft();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(90, 160);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            CheckCanvasBuildingModify(initialValue, currentValue, "Left side of the wall is not open");
            NavigateToDrawingPageAndClickEXT_1();
            string post = CheckThePostValue();
            Assert.That(post, Is.EqualTo("3"), "Verify that the bay span is not used for the open portion, for the enclosed portion");
            ExtentTestManager.TestSteps("Verify that the bay span is used for the open portion, but not for the enclosed portion");
        }

        private void EditButtonAndPlaceCanvasBuilding()
        {
            DefaultJobElement.Click3DEdit();
            CommonMethod.Wait(1);
            EditPlaceCanvasBuilding(150, 150);
            CommonMethod.Wait(1);
        }

        // Case 3: Combined open/enclosed wall where the ‘main’ wall is enclosed
        private void CaseThreeForBaySpan()
        {
            ExtentTestManager.CreateTest("Case 3: Combined open/enclosed wall where the ‘main’ wall is enclosed");
            DefaultJobElement.ClickCanvas3DViewButton();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.LengthInputField("23");
            DefaultJobElement.WidthInputField("23");
            DefaultJobElement.ClickAttachedBuilding();
            DefaultJobElement.EnterStartInputFieldOption("0");
            DefaultJobElement.EnterWidthInputFieldOption("23");
            DefaultJobElement.EnterLengthInputFieldOption("23");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            SelectWallsElement("Open");
            DefaultJobElement.PlaceOpening(-100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClickCrossIcon();
            CheckCanvasBuildingModify(initialValue, currentValue, "Attached building is not attached on the front wall");
            NavigateToDrawingPageAndClickEXT_1();
            string post = CheckThePostValue();
            Assert.That(post, Is.EqualTo("3"), "Verify that the bay span is not used for the open portion, for the enclosed portion");
            ExtentTestManager.TestSteps("Verify that the bay span is used for the open portion, but not for the enclosed portion");
        }

        // Case 2: Enclosed wall does not follow Open Wall Carrier Bays Span
        private void CaseTwoForBaySpan()
        {
            ExtentTestManager.CreateTest("Case 2: Enclosed wall does not follow Open Wall Carrier Bays Span");
            DefaultJobElement.ClickCanvas3DViewButton();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            CheckCanvasBuildingModify(initialValue, currentValue, "Left side of the wall is not enclosed");
            NavigateToDrawingPageAndClickEXT_1();
            string post = CheckThePostValue();
            Assert.That(post, Is.EqualTo("4"), "Without open wall bay span is apply on the wall");
            ExtentTestManager.TestSteps("Verify that open wall bay span is not apply");
        }

        // Case 1: Open Wall follows Open Wall Carrier Bays Span
        private void CaseOneForBaySpan()
        {
            ExtentTestManager.CreateTest("Case 1: Open Wall follows Open Wall Carrier Bays Span");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClicksShellButton();
            DefaultJobElement.ClickDetails();
            SelectBayElementAndApplyOpenWallCarrierSpan();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            CheckCanvasBuildingModify(initialValue, currentValue, "Left side of the wall is not open");
            NavigateToDrawingPageAndClickEXT_1();
            string post = CheckThePostValue();
            Assert.That(post, Is.EqualTo("2"), "Bay span is not working");
            ExtentTestManager.TestSteps("Verify that open wall carrier bay span is apply to the wall after wall is open");
        }

        // Click on the apply button of the porch and attached building
        public static void ApplyButtonOfPorch()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='Apply']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the apply button");
        }

        // Navigate to the drawing page and click on the EXT_1
        private static void NavigateToDrawingPageAndClickEXT_1()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1(); 
        }

        private void EditPlaceCanvasBuilding(int x_axis, int y_axis)
        {
            IWebElement canvas2 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(canvas2).MoveByOffset(x_axis, y_axis);
            CommonMethod.GetActions().DoubleClick(canvas2).Perform();
        }

        // Check canvas building modify or not using configured price
        private void CheckCanvasBuildingModify(string initialValue, string currentValue, string reason)
        {
            if (initialValue.Equals(currentValue))
            {
                Assert.Fail(reason);
            }
        }

        /// <summary>
        /// Click on the bays tab from details menu and check the use bays spacing checkbox
        /// Click on the open wall truss carrier and select 2 from the open wall carrier bys span dropdown
        /// </summary>
        private void SelectBayElementAndApplyOpenWallCarrierSpan()
        {
            DefaultJobElement.ClickBays();
            DefaultJobElement.CheckUseBaysSpacingCheckbox();
            DefaultJobElement.ClickOpenWallTrussCarrier();
            DefaultJobElement.SelectOpenWallTrussCarrierBaySpan("2");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        // Click on the elements
        private void ClickOnElement(string pathOfField, string testStep)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(pathOfField)));
            ExtentTestManager.TestSteps(testStep);
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
        }

        // select 2 from the open wall carrier bys span dropdown
        private void SelectOpenWallCarrierBaySpan(string span)
        {
            ClickOnElement("(//label[text()='Open Wall Carrier Bay Span'])[1]//following::div[2]", "Select the open wall carrier bay span");
            ClickOnElement($"//div[@id='w2ui-overlay']//div[text()='{span}']", $"Select the span value {span}");
        }

        // select 2 from the open wall carrier bys span dropdown
        private void SelectWallsElement(string walls)
        {
            DefaultJobElement.SelectWallsDropdownOfOpeningOption(walls);
        }

        // Get the post quantity 
        private string CheckThePostValue()
        {
            string postValue = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@id,'grid_dwgMaterialsGrid_rec_')]//div[text()='Post']//following::td[@col='5'])[1]"))).Text;
            return postValue;
        }

        // Capture screenshot of canvas building
        private void CaptureScreenshot(string imageName)
        {
            IWebElement canvasBuilding = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            Screenshot elementScreenshot = ((ITakesScreenshot)canvasBuilding).GetScreenshot();

            // Save the screenshot to a file
            string imagePath = $@"{pathFile}\{imageName}.png";
            elementScreenshot.SaveAsFile(imagePath);
        }
    }
}
