using Forms.Reporting;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using HomePage = SmartBuildAutomation.Pages1.HomePage;
using JobPage = SmartBuildAutomation.Pages_Application.JobPage;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class Status : BaseClass
    {
        [Test]
        public void CheckJobStatus()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Test Statuses of Jobs.");

            // Create a new job
            CreateNewJob("CheckJobStatus");

            // Validate job status transitions
            ValidateJobStatusTransition("CheckJobStatus", "New", "Make Quote", "Quoted");

            // Check if re-quoted job was created
            CreateQuotedJob();

            ValidateJobStatusTransition("CheckJobStatus", "Requoted", "Make Contract", "Contracted");
            ExtentTestManager.TestSteps("Verify that the Contracted job status shown in the job table");
            ValidateJobStatusTransition("CheckJobStatus", "Contracted", "Prep for Order", "OrderPrep");
            ExtentTestManager.TestSteps("Verify that the OrderPrep job status shown in the job table");
            ValidateJobStatusTransition("CheckJobStatus", "OrderPrep", "Make Order", "Ordered");
            ExtentTestManager.TestSteps("Verify that the Ordered job status shown in the job table");
            ValidateJobStatusTransition("CheckJobStatus", "Ordered", "Amend", "Ammended");
            ExtentTestManager.TestSteps("Verify that the Ammended job status shown in the job table");
            string getCreateTime = JobPage.GetTheCreateTimeFromJobTableAfterSearch("CheckJobStatus");
            HomePage.ClicksJobTab();

            // Check if amended replicate job is created
            Assert.True(JobPage.CheckJobName("CheckJobStatus rev."), "Replicate job for Ammended status is not created in the job table");
            JobPage.ClickShowActiveButton();
            string getCreateTimeForCloseJob = JobPage.GetTheCreateTimeFromJobTableBeforeSearch("CheckJobStatus-Quote");
            string getJobStatus = JobPage.GetTheJobStatusBeforeSearch("CheckJobStatus-Quote");

            if (!getCreateTime.Equals(getCreateTimeForCloseJob) && !getJobStatus.Equals("Close"))
            {
                Assert.Fail("Close job is not create in the job table");
            }

            ExtentTestManager.TestSteps("Verify that the Close job status shown in the job table");

            CheckTheTakenJobStatus();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Truss Catalog range of overhangs (minimum and maximum)");
        }

        #region Private Method
        private void CheckTheTakenJobStatus()
        {
            HomePage.NavigateToEModeler();
            string postAcknowledgment = EModelerElement.GetTheAcknowledgment();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@id='startFromScratch']")));
            string jobLink = CommonMethod.element.Text;
            string firstWindows = JobPage.OpenAnyJobCopyOfEModelerPage(jobLink);
            EModelerElement.EnterDetailsOfJobInTheViewJobLinkPage(firstWindows, postAcknowledgment, "EModelerTakenJob");
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            CommonMethod.Wait(5);
            HomePage.ClicksJobTab();
            CommonMethod.Login();
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            JobPage.OpenJob("EModelerTakenJob");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Take Job']"))).Click();
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            string modifiedTime = JobPage.GetTheModifiedTimeFromJobTableBeforeSearch("EModelerTakenJob");
            JobPage.ClickShowActiveButton();
            string getModifiedTimeForTakenJob = JobPage.GetTheModifiedTimeFromJobTableBeforeSearch("EModelerTakenJob");
            string getJobStatus = JobPage.GetTheJobStatusBeforeSearch("EModelerTakenJob");

            if (!modifiedTime.Equals(getModifiedTimeForTakenJob) && !getJobStatus.Equals("Taken"))
            {
                Assert.Fail("Taken job is not create in the job table");
            }

            ExtentTestManager.TestSteps("Verify that the Taken job status shown in the job table");
        }

        private void CreateNewJob(string jobName)
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField(jobName);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
        }

        private void ValidateJobStatusTransition(string jobName, string currentStatus, string actionStatus, string expectedStatus)
        {
            if (expectedStatus != "Contracted" && expectedStatus != "OrderPrep" && expectedStatus != "Ordered" && expectedStatus != "Ammended")
            {
                ChangeTheUser();
                FilterJobStatus(currentStatus);
                JobPage.SearchElementInTheTable(jobName);
            }

            string currentJobStatus = JobPage.GetTheJobStatusAfterSearch(jobName);
            Assert.That(currentJobStatus, Is.EqualTo(currentStatus), $"The job status is not {currentStatus}");

            JobPage.ChangesJobStatus(jobName, actionStatus);

            ChangeTheUser();
            FilterJobStatus(expectedStatus);

            JobPage.SearchElementInTheTable(jobName);
            string updatedJobStatus = JobPage.GetTheJobStatusAfterSearch(jobName);
            Assert.That(updatedJobStatus, Is.EqualTo(expectedStatus), $"The job status is not {expectedStatus}");
        }

        private void ChangeTheUser()
        {
            JobPage.ClickFilterIcon();
            JobPage.SelectUser("Kritika Dhillon");
        }

        private void FilterJobStatus(string status)
        {
            UncheckTheCheckboxFromFilterLists("All");
            CheckTheCheckboxFromFilterList(status);
        }

        private void UncheckTheCheckboxFromFilterLists(string checkboxName)
        {
            JobPage.ClickFilterIcon();
            JobPage.UncheckStatusCheckboxFromFilterList(checkboxName);
        }

        private void CheckTheCheckboxFromFilterList(string checkboxName)
        {
            JobPage.CheckStatusCheckboxFromFilterList(checkboxName);
        }

        private void CreateQuotedJob()
        {
            JobPage.CreateRequotedJob("CheckJobStatus");
            bool isPresent = JobPage.CheckJobName("CheckJobStatus rev. ");
            Assert.True(isPresent, "Re-quoted job is not create in the job table");
            ChangeTheUser();
            FilterJobStatus("Requoted");
            JobPage.SearchElementInTheTable("CheckJobStatus");
            string updatedJobStatus = JobPage.GetTheJobStatusAfterSearch("CheckJobStatus");
            Assert.That(updatedJobStatus, Is.EqualTo("Requoted"), $"The job status is not Requoted");
            ExtentTestManager.TestSteps("Verify that the re-quoted job is create in the job table");
        }
    }
}
#endregion