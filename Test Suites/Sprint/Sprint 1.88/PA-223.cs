using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation.Sprint_1._88
{
    [TestFixture, Category("Sprint_1._88")]
    public class TrackOpenings : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test, Order(1)]
        public void ServerChanges()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Dev: Change how we track openings (server changes)");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.ChangeView();
            DefaultJobElement.ChangeViewFrontRight();
            PlaceDoorOnTheCanvasBuilding(150, 200);
            EnterJobNameAndSave("Dev: Track Opening");

            ClickOnTheOutputButtonAndDownloadEZMFile();
            UploadEZMFile();
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string currentDate = date.Replace('/', '-');
            JobPage.OpenJob($"Dev_ Track Opening_{currentDate}");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.Click3DEdit();
            CommonMethod.Wait(2);
            DefaultJobElement.ClickChangeView();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.BackLeft)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            DefaultJobElement.OpenPlaceOpening(150, 80);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@name='DistanceStr'])[2]")));
            VerifyDistanceIsNotChange();
            CommonMethod.DeleteFolderData();
            JobPage.DeleteJobFromJobPages("Dev: Track Opening");
            JobPage.DeleteJobFromJobPages($"Dev_ Track Opening_{currentDate}");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Dev: Change how we track openings (server changes)");
        }

        #region Private Method      
        private static void VerifyDistanceIsNotChange()
        {
            string distance = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            string location = DefaultJobElement.GetLocationOpeningOfOpeningValue();
            DefaultJobElement.ClickCrossIcon();
            Assert.That("0'", Is.EqualTo(distance),"The distance value is change");
            Assert.That("From Center", Is.EqualTo(location), "The location value is change");
            Console.WriteLine("Verify that the walkdoor location and distance of the .ezm file job have not been changed.");
            DefaultJobElement.ClickHomeButton();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.noButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        private void PlaceDoorOnTheCanvasBuilding(int x, int y)
        {
            // Place and edit canvas building
            DefaultJobElement.PlaceOpening(x, y);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ClickChangeView();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.BackLeft)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            DefaultJobElement.OpenPlaceOpening(160,200);
            ApplyLocationSelection();
        }

        private void ApplyLocationSelection()
        {
            // Apply location selection
            DefaultJobElement.SelectLocationOpening("From Center");
            DefaultJobElement.EnterDistance("0'");
            DefaultJobElement.ClickUpdateButtonFrom3DView();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void ClickOnTheOutputButtonAndDownloadEZMFile()
        {
            // Click on the output button and download EZM file
            DefaultJobElement.DownloadFileFromOutputFrame("EZM File");
            DefaultJobElement.ClickHomeButton();
            HomePage.ClicksJobTab();
        }

        private void EnterJobNameAndSave(string jobName)
        {
            // Enter job name and save
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField(jobName);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
        }

        private void UploadEZMFile()
        {
            // Upload EZM file
            JobPage.ClickOnTheUploadButtonInTheJobPage();
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string currentDate = date.Replace('/', '-');
            string excelFileName = Path.Combine(folderPath, $"Dev_ Track Opening_{currentDate}.ezm");
            JobPage.UploadFileInTheJobPage(excelFileName);
        }
    }
}
#endregion