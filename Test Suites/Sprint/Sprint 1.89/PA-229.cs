using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Sprint_1._89")]
    public class ViewerJob : BaseClass
    {
        public string CaptureScreenShot = FolderPath.StoreCaptureImage("ScreenShot of PA-229");

        [Test]
        public void AdvancedEdit()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Doors not showing up in Viewer on Test");
            FolderPath.CreateFolder(CaptureScreenShot);
            CommonMethod.DeleteFolderFile(CaptureScreenShot);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 120);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ChangeViewBackLeft();
            DefaultJobElement.SelectOpeningDoor("Windows", "Slider", "30x30 Slider");
            DefaultJobElement.PlaceOpening(100, 120);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("ViewerJob");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
            OpenViewerLink();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("ViewerJob");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Doors not showing up in Viewer on Test");
        }

        #region Private Method
        private string ClickOnTheDetailsButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='ViewerJob']//preceding :: span[text()='Details']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Details button of ViewerJob");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//i[@id='previewLink']")));
            string getTheViewerLink = CommonMethod.element.Text;
            Console.WriteLine(getTheViewerLink);
            ExtentTestManager.TestSteps("get the viewer job link");
            return getTheViewerLink;
        }

        private void OpenViewerLink()
        {
            string jobViewerLink = ClickOnTheDetailsButton();
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");

            // Switch to the new tab or window
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Driver.Navigate().GoToUrl(jobViewerLink);
            CommonMethod.PageLoader();

            string jobName = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath(" //span[@id='jobName']"))).Text;
            Assert.That(jobName, Is.EqualTo("\"ViewerJob\""));
            Console.WriteLine("Verify that the viewer job shows the door and window.");
            ExtentTestManager.TestSteps("Verify that the viewer job shows the door and window.");
            DefaultJobElement.ChangeViewBackLeft();
            ScreenShot("Door and Window.png");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@onclick,'w2popup.close()')]"))).Click();
        }

        private void ScreenShot(string imageName)
        {
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawingArea", CaptureScreenShot, $"{imageName}");
        }
    }
}
#endregion