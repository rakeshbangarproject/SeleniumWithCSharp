using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Pages_Application
{
    public class JobPage : BaseClass
    {
        static string NavigateButtonInput = "//td[normalize-space()='{0}']";

        private static WebDriverWait WaitForElement => new WebDriverWait(Driver, TimeSpan.FromSeconds(3));

        public static string OpenJob(string jobName)
        {
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(3);
            SearchElementInTheTable(jobName);
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.GetTableData)));
            string jobStatus = null;

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (lineNumber.Equals("bottom"))
                {
                    Assert.Fail($"{jobName} is not shown in the jobs table");
                }

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    int lineNumberInt = int.Parse(lineNumber);
                    string num = (lineNumberInt + 1).ToString();
                    string name = row.FindElement(By.XPath(string.Format(Locator.JobPage.GetFirstElementOfText, lineNumber, 2))).GetAttribute("title");
                    try
                    {
                        if (name.Equals(jobName))
                        {
                            CommonMethod.Wait(1);
                            jobStatus = row.FindElement(By.XPath(string.Format(Locator.JobPage.GetFirstElementOfText, lineNumber, 6))).Text;
                            WaitForElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.JobPage.GetTheJobName, lineNumber, jobName)))).Click();
                            ExtentTestManager.TestSteps($"open {jobName} job");
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Assert.Fail($"{jobName} is not shown in the jobs table");
                    }
                }
            }

            return jobStatus;
        }

        public static void SearchElementInTheTable(string jobName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.SearchField)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys(jobName + Keys.Enter).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(2);
        }

        public static void ClickOnTheUploadButtonInTheJobPage()
        {
            // Navigate to the job page
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("JobPageURL"));
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Navigate To Job Page");

            // Click on the 'Upload Model' button
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Upload Model']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Upload Model of Job page");
        }

        public static void ClickRefreshButton()
        {
            IWebElement filterIcon = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_w2ui-reload']")));
            CommonMethod.GetActions().Click(filterIcon).Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void ClickShowActiveButton()
        {
            IWebElement showActive = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_showArchive']")));
            CommonMethod.GetActions().Click(showActive).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click On the Show Active button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void ClickFilterIcon()
        {
            IWebElement filterIcon = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.filterIcon)));
            CommonMethod.GetActions().Click(filterIcon).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the filter icon");
        }

        public static void SelectUser(string userName)
        {
            IWebElement selectUser = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.selectUser)));
            CommonMethod.SelectElement(selectUser).SelectByValue(userName);
            ExtentTestManager.TestSteps($"Select {userName} from user list");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static int GetTheStatusColumnNumber()
        {
            IList<IWebElement> headerElements = Driver.FindElements(By.XPath("//div[@id='grid_grid_columns']//td[@class='w2ui-head ']//div[2]"));
            int columnNumber = 1;

            foreach (IWebElement element in headerElements)
            {
                columnNumber++;

                if (element.Text.Contains("Status"))
                {
                    return columnNumber;
                }
            }
            return -1;
        }

        public static string GetTheJobStatusAfterSearch(string jobName)
        {
            int status = GetTheStatusColumnNumber();

            string getTheJobNameDataXPath = "//div[@id='grid_grid_records']//td[@col='2']//div";
            IList<IWebElement> getTheJobNameData = Driver.FindElements(By.XPath(getTheJobNameDataXPath));
            int indexNumber = 0;

            foreach (IWebElement element in getTheJobNameData)
            {
                string captureTheJobName = element.GetAttribute("title");

                if (jobName.Equals(captureTheJobName))
                {
                    indexNumber++;
                    break;
                }

                indexNumber++;
            }

            string xPathOfStatusCode = $"(//tr[contains(@id,'grid_grid_rec_') and @line='{indexNumber}']//span[text()='{jobName}'])[1]//following::td[@col='{status}']";
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPathOfStatusCode))).Text;
        }

        public static string GetTheJobStatusBeforeSearch(string jobName)
        {
            int status = GetTheStatusColumnNumber();

            string getTheJobNameDataXPath = "//div[@id='grid_grid_records']//td[@col='2']//div";
            IList<IWebElement> getTheJobNameData = Driver.FindElements(By.XPath(getTheJobNameDataXPath));
            int indexNumber = 0;

            foreach (IWebElement element in getTheJobNameData)
            {
                string captureTheJobName = element.GetAttribute("title");

                if (jobName.Equals(captureTheJobName))
                {
                    indexNumber++;
                    break;
                }

                indexNumber++;
            }

            string xPathOfStatusCode = $"(//tr[contains(@id,'grid_grid_rec_') and @line='{indexNumber}']//div[text()='{jobName}'])[1]//following::td[@col='{status}']";
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPathOfStatusCode))).Text;
        }

        public static string OpenAnyJobCopyOfEModelerPage(string jobLink)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{jobLink}', '_blank');");
            string firstWindows = CommonMethod.WindowHandle();
            try
            {
                CommonMethod.PageLoader();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='introMain']")));
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='close-button']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ExtentTestManager.TestSteps("Open a new tab with the job link copied from eModeler ");
            return firstWindows;
        }

        public static string GetTheElementTextFromTable(string jobName, string colNumber, string tagName)
        {
            string getTheJobNameDataXPath = "//div[@id='grid_grid_records']//td[@col='2']//div";
            IList<IWebElement> getTheJobNameData = Driver.FindElements(By.XPath(getTheJobNameDataXPath));
            int indexNumber = 0;

            foreach (IWebElement element in getTheJobNameData)
            {
                string captureTheJobName = element.GetAttribute("title");

                if (jobName.Equals(captureTheJobName))
                {
                    indexNumber++;
                    break;
                }
                indexNumber++;
            }

            string xPathOfStatusCode = $"((//tr[contains(@id,'grid_grid_rec_') and @line='{indexNumber}']//{tagName}[text()='{jobName}'])[1]//following::td[@col='{colNumber}']/div)[1]";
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xPathOfStatusCode))).Text;
        }

        public static string GetTheModifiedTimeFromJobTableAfterSearch(string jobName)
        {
            return GetTheElementTextFromTable(jobName, "8", "span");
        }

        public static string GetTheCreateTimeFromJobTableAfterSearch(string jobName)
        {
            return GetTheElementTextFromTable(jobName, "7", "span");
        }

        public static string GetTheModifiedTimeFromJobTableBeforeSearch(string jobName)
        {
            return GetTheElementTextFromTable(jobName, "8", "div");
        }

        public static string GetTheCreateTimeFromJobTableBeforeSearch(string jobName)
        {
            return GetTheElementTextFromTable(jobName, "7", "div");
        }

        public static void ChangesJobStatus(string checkboxName, string statusButtonName)
        {
            IWebElement statusButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.JobPage.getJobStatusButton, checkboxName, statusButtonName))));
            CommonMethod.GetActions().Click(statusButton).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {statusButton} button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.waitForConfirmationPopup)));
            IWebElement yesButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.yesButton)));
            CommonMethod.GetActions().Click(yesButton).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the yes button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(2);
        }

        public static void CreateRequotedJob(string jobName)
        {
            string getTheJobNameDataXPath = "//div[@id='grid_grid_records']//td[@col='2']//div";

            IList<IWebElement> getTheJobNameData = Driver.FindElements(By.XPath(getTheJobNameDataXPath));
            int indexNumber = 0;

            foreach (IWebElement element in getTheJobNameData)
            {
                string captureTheJobName = element.GetAttribute("title");

                if (jobName.Equals(captureTheJobName))
                {
                    indexNumber++;
                    break;
                }

                indexNumber++;
            }

            string buttonXPath = $"//tr[contains(@id,'grid_grid_rec_') and @line='{indexNumber}']//td[@col='1']//button[text()='---']";
            IWebElement underscoreSymbolIcon = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(buttonXPath)));
            CommonMethod.GetActions().Click(underscoreSymbolIcon).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {underscoreSymbolIcon} button");
            IWebElement reQuotedOptionButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.re_QuotedOption)));
            CommonMethod.GetActions().Click(reQuotedOptionButton).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the RE-QUOTED button");
            IWebElement yesButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.yesButton)));
            CommonMethod.GetActions().Click(yesButton).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the yes button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(2);
        }

        public static string GetTheJobNameFromTable()
        {
            return Driver.FindElement(By.XPath(Locator.JobPage.getTheJobName)).Text;
        }

        public static bool CheckJobName(string existingJob)
        {
            string jobName = GetTheJobNameFromTable();

            if (jobName.Contains(existingJob))
            {
                return true;
            }

            return false;
        }


        public static void CheckStatusCheckboxFromFilterList(string checkboxName)
        {
            IList<IWebElement> checkbox = Driver.FindElements(By.XPath(string.Format(Locator.JobPage.checkStatusCheckbox, checkboxName)));
            Assert.AreNotEqual("1", checkbox.Count, "Error: Duplicate materials shown in the filter list");

            foreach (IWebElement element in checkbox)
            {
                if (!element.Selected)
                {
                    element.Click();
                    break;
                }
            }

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"{checkboxName}  is checked from the filter list");
        }

        public static void UncheckStatusCheckboxFromFilterList(string checkboxName)
        {
            IList<IWebElement> checkbox = Driver.FindElements(By.XPath(string.Format(Locator.JobPage.checkStatusCheckbox, checkboxName)));
            Assert.AreNotEqual("1", checkbox.Count, "Error: Duplicate materials shown in the filter list");

            foreach (IWebElement element in checkbox)
            {
                if (element.Selected)
                {
                    element.Click();
                    break;
                }
            }

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"{checkboxName}  is unchecked from the filter list");
        }


        public static void DeleteJobFromJobPages(string jobName)
        {
            var wait = GetWebDriverWait();

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.SearchField)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys(jobName + Keys.Enter).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));

            CommonMethod.Wait(2);
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.GetTableData)));

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (lineNumber.Equals("bottom"))
                {
                    Assert.Fail($"{jobName} is not shown in the jobs table");
                }

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    int lineNumberInt = int.Parse(lineNumber);
                    string num = (lineNumberInt + 1).ToString();
                    string name = row.FindElement(By.XPath(string.Format(Locator.JobPage.GetFirstElementOfText, lineNumber, 2))).GetAttribute("title");
                    try
                    {
                        if (name.Equals(jobName))
                        {
                            CommonMethod.Wait(1);
                            WaitForElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.JobPage.getTheDeleteButton, lineNumber, jobName)))).Click();
                            ExtentTestManager.TestSteps($"open {jobName} job");

                            // Click on the 'Delete' button
                            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.DeleteButton)));
                            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                            ExtentTestManager.TestSteps("Click on the Delete button");

                            // Confirm deletion
                            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.YesButton)));
                            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                            ExtentTestManager.TestSteps("Click on the yes button");
                            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.JobPage.WaitForTheSpinner)));
                            ExtentTestManager.TestSteps("Confirm Deletion ");

                            CommonMethod.Wait(5);
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Assert.Fail($"{jobName} is not shown in the jobs table");
                    }
                }
            }
        }

        public static void CreateCopyOfJob(string jobName)
        {
            // Navigate to the 'Jobs' page
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Jobs"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Navigate to the 'Jobs' page");

            // Locate the table containing job records
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='grid_grid_records']/table/tbody"));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            string jobNameXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[2]";
            string editButtonXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[1]/div/button[4]";

            // Iterate through the rows in the table
            for (int rowIndex = 3; rowIndex <= rows.Count; rowIndex++)
            {
                // Get the job name from the current row
                string currentJobName = Driver.FindElement(By.XPath(string.Format(jobNameXpath, rowIndex))).Text;

                // Check if the current row contains the specified job name
                if (currentJobName.Contains(jobName))
                {
                    // Click on Edit Button
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(editButtonXpath, rowIndex)))).Click();
                    ExtentTestManager.TestSteps("Click on the (---) button");

                    // Click on the 'Copy' button
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NavigateButtonInput, "Copy"))));
                    CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                    ExtentTestManager.TestSteps("Click on the Copy button");

                    // Confirm Copy
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='Yes']")));
                    CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                    ExtentTestManager.TestSteps("Click on the yes button");

                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
                    break;
                }
            }
        }

        public static void DownloadJobList()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.jobListReport)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void UploadFileInTheJobPage(string filePath)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.uploadModel)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the upload model button");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.chooseFile))).SendKeys(filePath);
            ExtentTestManager.TestSteps("upload file");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.uploadButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the upload button");

            // Wait for the upload to complete
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.JobPage.confirmation)));
            CommonMethod.Wait(8);

            // Verify that no error message is shown while uploading the EZM File
            string status = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.status))).Text;
            Assert.IsTrue(status.Equals("Done!"));
            ExtentTestManager.TestSteps("Verify that no error message is shown while uploading the EZM File.");

            // Click on the 'Back to List' button
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.JobPage.backToList)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Back To List button");
        }

    }
}
