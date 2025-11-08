using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    public class ClearPencil : BaseClass
    {
        [Test]
        public void AdvancedEditPencilIcon()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Clear out \"Pencils\" on Re-Quoted Jobs Advanced Edit");
            CreateNewQuotedJob();
            HomePage.ClicksJobTab();
            CreateReQuotedJob();
            string requotedJob = CheckPencilIconInTheReQuotedJob();
            string copyJob = CheckPencilIconInTheCopyJob();
          
            DeleteNewlyCreateJObs(requotedJob, copyJob);
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Clear out \"Pencils\" on Re-Quoted Jobs Advanced Edit");
        }

        #region Private Method
        // This method is for navigate to job page and deleted the newly created job.
        private static void DeleteNewlyCreateJObs(string requotedJob, string copyJob)
        {
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages(copyJob);
            JobPage.DeleteJobFromJobPages(requotedJob);
        }

        // This method is for the check pencil icon in the copy job.
        private string CheckPencilIconInTheCopyJob()
        {
            CreateCopyJob();
            string copyJob = OpenJob();
            DefaultJobElement.ClickAdvancedEdit();
            CheckPencilIcon();
            ExtentTestManager.TestSteps("Verify that the pencil icon shown only the EXT-1 wall for the copy job.");
            return copyJob;
        }

        // This method is for the create copy job.
        private static void CreateCopyJob()
        {
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
            JobPage.CreateCopyOfJob("ClearPencil");
        }

        // This method is for the check pencil icon in for the re-quoted job.
        private string CheckPencilIconInTheReQuotedJob()
        {
            string requotedJob = OpenJob();
            DefaultJobElement.ClickAdvancedEdit();
            CheckPencilIcon();
            ExtentTestManager.TestSteps("Verify that the pencil icon shown only the EXT-1 wall for the re-quoted job.");
            return requotedJob;
        }

        // This method is use for the changes in the EXT-1 wall and save job.
        private static void CreateNewQuotedJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickEXT_1();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectPostMaterialDropdownForAdvancedEdit("2x4RL");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.ClickCanvas3DViewButton();
            CommonMethod.Wait(1);
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("ClearPencil");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ChangeStatusOfJob("Make Quote");
        }

        // This method is for the create re-quoted job.
        private void CreateReQuotedJob()
        {
            // Locate the table containing job records
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='grid_grid_records']/table/tbody"));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            string deleteButtonXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[1]/div[1]/button[4]";
            string jobNameXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[2]";

            // Iterate through the rows in the table
            for (int rowIndex = 3; rowIndex <= rows.Count; rowIndex++)
            {
                // Get the job name from the current row
                string currentJobName = Driver.FindElement(By.XPath(string.Format(jobNameXpath, rowIndex))).Text;

                // Check if the current row contains the specified job name
                if (currentJobName == "ClearPencil")
                {
                    // Click on (---) Button
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(deleteButtonXpath, rowIndex)))).Click();
                    ExtentTestManager.TestSteps($"Click on the ClearPencil Job");

                    // Click on the 'Re-quoted' button
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Re-Quote']")));
                    CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                    ExtentTestManager.TestSteps("Click on the re-quoted button");

                    // click on the yes button pop
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='Yes']")));
                    CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                    ExtentTestManager.TestSteps("Click on the yes button");

                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
                    break;
                }
            }
        }

        // This method is for the get the jobname and open new job
        private string OpenJob()
        {
            string getTheJobName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_grid_rec_') and @line='1']//td[@col='2']/div"))).Text;   
            JobPage.OpenJob(getTheJobName);
            CommonMethod.PageLoader();
            return getTheJobName;
        }

        // This method is use for the check pencil icon show is correct position of walls.
        private void CheckPencilIcon()
        {
            IList<IWebElement> pencilElements = Driver.FindElements(By.XPath("//div[contains(@class,'w2ui-icon-pencil')]//following::div[1]"));
            bool pencilForOtherMaterials = false;

            foreach (IWebElement element in pencilElements)
            {
                string material = element.Text.Trim();

                if (material != "EXT-1")
                {
                    pencilForOtherMaterials = true;
                    break;
                }
            }

            if (pencilForOtherMaterials)
            {
                Assert.Fail("Pencil icon is shown on all panel if the user changes in the EXT-1 wall");
            }
        }
    }
}
#endregion