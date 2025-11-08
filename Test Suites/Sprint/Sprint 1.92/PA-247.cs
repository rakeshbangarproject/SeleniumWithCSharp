using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace Test_Suites.Sprint.Sprint_1._92
{
    public class OverhangsBroke : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-247");

        [Test]
        public void CombinedRoof()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Test - Combined Roofs with Overhangs is Broke");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            GableBuilding();
            Gambrel();
            Western();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Test - Combined Roofs with Overhangs is Broke");
        }

        #region Private Method
        private void OpenThePlaceDoor(int x, int y)
        {
            IWebElement canvas2 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            CommonMethod.Wait(1);
            CommonMethod.GetActions().MoveToElement(canvas2).MoveByOffset(x, y);
            CommonMethod.Wait(1);
            CommonMethod.GetActions().DoubleClick(canvas2).Perform();
            ExtentTestManager.TestSteps($"Edit the opening");
        }

        private void Western()
        {
            ExtentTestManager.CreateTest("Case 3:  Incorrect overhangs for Western Roofs");
            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            DefaultJobElement.SelectStyleOfRoofStyleAdvanced("Western");
            DefaultJobElement.UpperSlopeOfAdvancedRoofStyleInputField("6");
            DefaultJobElement.LowerSlopeOfAdvancedRoofStyleInputField("3");
            DefaultJobElement.ClickAdvancedFrameApplyButton();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, 120);
            CaptureScreenshot("Overhang_With_Western_Style");
            ExtentTestManager.TestSteps("Verify that the overhang part is not missing when the roof style is the western");
        }

        private void Gambrel()
        {
            ExtentTestManager.CreateTest("Case 1:  Incorrect Overhangs for Gambrel Roofs");
            DefaultJobElement.RoofPitchInputField("3");
            DefaultJobElement.SelectRoofStyleMaterial("Gambrel");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, 120);
            CaptureScreenshot("Overhang_With_Gambrel_Style_WithRafter");

            EditButtonAndPlaceCanvasBuilding(120,-150);

            if (!CommonMethod.IsElementPresent(By.XPath("//span[@id='dialogTitle']")))
            {
                for (int i = 0; i < 20; i++)
                {
                    EditButtonAndPlaceCanvasBuilding(100,120);

                    if (CommonMethod.IsElementPresent(By.XPath("//span[@id='dialogTitle']")))
                    {
                        break;
                    }
                }
            }

            RoofFraming("Trusses");
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, 120);
            CaptureScreenshot("Overhang_With_Gambrel_Style_WithTruss");
            ExtentTestManager.TestSteps("Verify that the overhang part is not missing when the roof style is the gambrel");
        }

        private void EditButtonAndPlaceCanvasBuilding(int x, int y)
        {
            DefaultJobElement.ChangeViewBackLeft();
            DefaultJobElement.Click3DEdit();
            OpenThePlaceDoor(x, y);
        }

        private void GableBuilding()
        {
            ExtentTestManager.CreateTest("Case 1: Verify with Gable style");
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.SelectOverhangDropdownOfOpeningOption("2'");
            DefaultJobElement.RoofPitchInputFieldOption("3");
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, 120);
            CaptureScreenshot("OverhangWithGableWall_WithTruss");
            EditButtonAndPlaceCanvasBuilding(100, 100);

            if (!CommonMethod.IsElementPresent(By.XPath("//span[@id='dialogTitle']")))
            {
                for (int i = 0; i < 10; i++)
                {
                    EditButtonAndPlaceCanvasBuilding(100, 100);
                    if (CommonMethod.IsElementPresent(By.XPath("//span[@id='dialogTitle']")))
                    {
                        break;
                    }
                }
            }

            RoofFraming("Rafters");
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, 120);
            CaptureScreenshot("OverhangWithGableWall_WithRafter");
            ExtentTestManager.TestSteps("Verify that the overhang part is not missing when the roof style is the gable");
        }

        public static void RoofFraming(string elementName)
        {
            DefaultJobElement.SelectRoofFramingDropdownOpeningOption(elementName);
        }

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
#endregion