using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildProductionAutomation.Helper;
using SmartBuildAutomation.Helper;
using Forms.Reporting;
using System;
using SmartBuildAutomation.Pages1;
using Locator = SmartBuildAutomation.Locators.Locator;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{

    [TestFixture, Category("Sprint_1._91")]
    public class LoftIssue : BaseClass
    {
        public static string imagesFolder = FolderPath.ImagesFolder();
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-240");

        [Test]
        public void ResizeCanvasBuilding()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH: Job crashes if building is resized and cause lofts to no longer be in building");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.ClicksStartFromScratch();
            PlaceLoftOnThe2DView();
            VerifyLoftOutsideOfCanvas2DBuilding();
            EnterJobNameAndSaveJob();
            ReopenJobAndVerifyErrorMessageShown();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH: Job crashes if building is resized and cause lofts to no longer be in building");
        }

        #region Private Method
        /// <summary>
        /// This method is use for created new job and navigate to home page
        /// </summary>
        private void EnterJobNameAndSaveJob()
        {
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("PFS-4488");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ClickHomeButton();
        }

        /// <summary>
        /// This method is use for re-open 
        /// </summary>
        private void ReopenJobAndVerifyErrorMessageShown()
        {
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4488");
            CommonMethod.PageLoader();
            FetchErrorMessage("Verify that the error messages are shown after re-open the newly created job", "Verify that the error messages are not shown after re-open the newly created job");
            DefaultJobElement.ChangeViewFrontLeft();
            CaptureScreenShotOfCanvasBuilding("Capture3DViewCanvasBuildingAfterRe-openJob.png");
            HomePage.PerformImageComparison(pathFile, imagesFolder, "Verify that the loft has not changed when the user re-opens the newly created job", "Verify that the loft has changed when the user re-opens the newly created job", "Capture3DViewCanvasBuilding.png", "Capture3DViewCanvasBuildingAfterRe-openJob.png");
            DefaultJobElement.ClickHomeButton();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("PFS-4488");
        }

        private void VerifyLoftOutsideOfCanvas2DBuilding()
        {
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickLoftsFromThe2DView();
            CaptureScreenShotOfCanvasBuilding("Verify_Loft_Outside_Of_Building.png");
            HomePage.PerformImageComparison(pathFile, pathFile, "Verify that the loft is not visible outside the building in the 2D view", "Verify that the loft is visible outside the building in the 2D view", "Verify_Loft_Outside_Of_Building.png", "Apply Loft.png");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.returnButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Return button");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));

        }

        private void PlaceLoftOnThe2DView()
        {
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectBuildingSizeMaterial("30' x 60'");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickLoftsFromThe2DView();
            DefaultJobElement.ClickAddButtonOfLofts();
            DefaultJobElement.PlaceOpening(493, 250);
            DefaultJobElement.ClickCrossIcon();
            CaptureScreenShotOfCanvasBuilding("Apply Loft.png");
            DefaultJobElement.SaveButtonOf2DView();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectBuildingSizeMaterial("20' x 20'");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            FetchErrorMessage("Verify that the error messages are shown after resizing the building size.", "Verify that the error messages are not shown after resizing the building size.");
        }

        private void FetchErrorMessage(string errorMessages, string reportMessage)
        {
            try
            {
                string errorMessagePopUp = Driver.FindElement(By.XPath("//div[@id='w2ui-popup']//div[2]")).Text;
                Assert.Fail(errorMessagePopUp, errorMessages);
            }
            catch (Exception)
            {
                ExtentTestManager.TestSteps(reportMessage);
            }
        }

        private void CaptureScreenShotOfCanvasBuilding(string imageName)
        {
            IWebElement canvasElement = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));

            string desiredWidthStr = canvasElement.GetAttribute("width");
            string desiredHeightStr = canvasElement.GetAttribute("height");

            int desiredWidth = Convert.ToInt32(desiredWidthStr);
            int desiredHeight = Convert.ToInt32(desiredHeightStr);
            CommonMethod.Wait(2);

            IJavaScriptExecutor screenshotOfCanvas = (IJavaScriptExecutor)Driver;
            screenshotOfCanvas.ExecuteScript(
                "arguments[0].style.height = arguments[1] + 'px'; arguments[0].style.width = arguments[2] + 'px';",
                 canvasElement, desiredHeight, desiredWidth);

            Screenshot elementScreenshot = ((ITakesScreenshot)canvasElement).GetScreenshot();
            string imagePath = $@"{pathFile}\{imageName}";
            elementScreenshot.SaveAsFile(imagePath);
        }
    }
}
#endregion