using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using Locator = SmartBuildAutomation.Locators.Locator;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    [TestFixture, Category("Smoke_test")]
    public class ExteriorWallLength : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-253");

        [Test]
        public void TopOfWallMaterial()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Maintain Exterior Wall Height when using sloped overhang soffit panels");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickWainscot();
            DefaultJobElement.UncheckHasWainscotCheckbox();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            DefaultJobElement.ExteriorMetalHeightInputField("12'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            AssemblyOfEXTOne();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("ExteriorWall", null, null, null, "12'");
            ExtentTestManager.TestSteps("Verify that the length of the exterior walls is 12 feet.");
            SetSoffitMaterial("Panels");
            RefreshJob();
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            RefreshJob();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("ExteriorWall", null, null, null, "12'");
            ExtentTestManager.TestSteps("Verify that the exterior wall lengths remain constant after adding overhangs to the canvas building.");
            DefaultJobElement.ClickCanvas3DViewButton();
            CaptureScreenshotOfBuilding("AfterOverhangApplyWithPanelStyle");
            SetSoffitMaterial("Sloped Panels");
            RefreshJob();
            CaptureScreenshotOfBuilding("ApplyWithSlopedPanelsStyle");
            AssemblyOfEXTOne();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("ExteriorWall", null, null, null, "12'");
            ExtentTestManager.TestSteps("Verify that the exterior wall lengths remain constant after applying Sloped Panels to the canvas building.");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Maintain Exterior Wall Height when using sloped overhang soffit panels");
        }

        #region Private Method
        private void AssemblyOfEXTOne()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
        }

        private void CaptureScreenshotOfBuilding(string imageName)
        {
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, -120);
            CaptureScreenshot(imageName);
        }

        private void SetSoffitMaterial(string material)
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickFasciaAndSoffit();
            DefaultJobElement.SelectSoffitStyle(material);
        }

        private void RefreshJob()
        {
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
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
#endregion