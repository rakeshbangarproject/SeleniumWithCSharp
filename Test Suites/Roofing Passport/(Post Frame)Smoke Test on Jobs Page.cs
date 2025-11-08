using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Roofing_Passport")]
    public class JobsPageStatus : BaseClass
    {
        string JobButton = ("{0}");
        By WaitForJobPageLoad = By.XPath("//div[@class='w2ui-lock-msg']");
        public string folderPath = FolderPath.Download();

        [Test]
        public void JobStatus()
        {
            LoginApplicationAndChangesDistributor("Smoke Test On Jobs Page");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterQuotedInputField("Quote Field Testing");
            DefaultJobElement.EnterJobNameInputField("Quote Field Testing");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
            JobStatus("New");
            DefaultJobElement.ChangeStatusOfJob("Make Quote");
            JobStatus("Quoted");
            DefaultJobElement.ChangeStatusOfJob("Make Contract");
            JobStatus("Contracted");
            DefaultJobElement.ChangeStatusOfJob("Prep for Order");
            JobStatus("OrderPrep");
            DefaultJobElement.ChangeStatusOfJob("Make Order");
            JobStatus("Ordered");
            EmailVerification();
            VerifyDataInCSVFile();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Jobs Page");
        }

        #region Private Method
        // <summary>
        /// Login to the application and set distributor as AutoTest_PHTest
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");
        }

        private void JobStatus(string status)
        {
            NavigateToJobsPage();
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='grid_grid_records']/table/tbody"));
            IList<IWebElement> r_table = table.FindElements(By.TagName("tr"));
            string a_xpath = "//div[@id='grid_grid_records']/table/tbody/tr[";
            string b_xpath = "]/td[2]";
            string c_xpath = "]/td[3]/div";
            string d_xpath = "]/td[5]/div";
            string e_xpath = "]/td[1]/div/button[1]";
            var rowCount = r_table.Count();

            for (int r = 3; r <= rowCount; r++)
            {
                string n = Driver.FindElement(By.XPath(a_xpath + r + b_xpath)).Text;

                if (n.Contains("Quote Field Testing"))
                {
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a_xpath + r + c_xpath)));
                    string distributorName = CommonMethod.element.Text;
                    Assert.True(distributorName.Equals("Kritika Dhillon"));
                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a_xpath + r + d_xpath)));
                    string JobStatusChanges = CommonMethod.element.Text;
                    Assert.True(JobStatusChanges.Equals(status));
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a_xpath + r + e_xpath))).Click();
                    CommonMethod.PageLoader();
                    break;
                }
            }
            Console.WriteLine($"Verify that the newly created job status is { status}");
            ExtentTestManager.TestSteps($"Verify that the newly created job status is { status}");
            Console.WriteLine("Verify that the newly created job is open successfully.");
            ExtentTestManager.TestSteps("Verify that the newly created job is open successfully.");
        }

        private void EmailVerification()
        {
            Driver.SwitchTo().NewWindow(WindowType.Tab);
            Driver.Navigate().GoToUrl("https://mail.google.com/mail/");
            ExtentTestManager.TestSteps("Navigate to Gmail account");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[contains(@type,'email')]"))).SendKeys("kdhillon@keymark.com");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[text()='Next']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@type,'password')]"))).SendKeys("Sss4321!");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(text(),'Next')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='nH ar4 z']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@act,'19')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[2]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@act,'19')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[3]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@act,'19')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[4]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@act,'19')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("The user login to Gmail account successfully");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        private void NavigateToJobsPage()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText(string.Format(JobButton, "Jobs")))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(WaitForJobPageLoad));
            ExtentTestManager.TestSteps("Navigate To Jobs Page");
        }

        #region Verify the CSV file data
        public void VerifyDataInCSVFile()
        {
            var dateFormat = DateTime.Now.ToString("00yyyy-MM-dd");
            var date = DateTime.Now.ToString("MM-dd-yyyy");
            DefaultJobElement.ClickHomeButton();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Jobs"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='downloadJobListReport']"))).Click();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='startDate']")));
            CommonMethod.element.SendKeys(dateFormat);
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='endDate']")));
            CommonMethod.element.SendKeys(dateFormat);
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn']"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.Wait(5);
            string excelFileName = $"JobList-AUTOTEST_PHTEST_{date}_{date}.csv";
            FolderPath.WaitForFileDownload(excelFileName, 60);
            string FilePath = Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");

            // Find the table and retrieve the row data
            JobPage.SearchElementInTheTable("Quote Field Testing");
            CommonMethod.Wait(2);
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='grid_grid_records']/table/tbody"));
            string[] tableRowData = GetTableRowData(table, 3, 2, 13);
            IList<IWebElement> r_table = table.FindElements(By.TagName("tr"));
            string a_xpath = "//div[@id='grid_grid_records']/table/tbody/tr[";
            string b_xpath = "]/td[2]";
            var rowCount = r_table.Count();

            for (int r = 3; r <= rowCount; r++)
            {
                string jobName = Driver.FindElement(By.XPath(a_xpath + r + b_xpath)).Text;

                if (jobName == "Quote Field Testing")
                {
                    // Read the CSV file and get data from row 3
                    CommonMethod.Wait(2);
                    string[] csvRowData = GetCsvRowData(FilePath, 3);
                    CommonMethod.Wait(2);
                    string[] headerName = GetCsvRowData(FilePath, 2);

                    // Compare the data from CSV and table
                    for (int i = 0; i < csvRowData.Length; i++)
                    {
                        if (csvRowData[i] == tableRowData[i])
                        {
                            Console.WriteLine($"Column {i + 1}: Values match " + headerName[i] + ":- " + (csvRowData[i] + " " + tableRowData[i]));
                        }
                        else
                        {
                            Console.WriteLine($"Column {i + 1}: Values do not match " + headerName[i] + ":- " + (csvRowData[i] + " " + tableRowData[i]));
                        }
                    }
                break;
                }
            }
        }
        #endregion

        static string[] GetCsvRowData(string filePath, int rowNumber)
        {
            CommonMethod.Wait(5);
            string[] csvRows = File.ReadAllLines(filePath);
            CommonMethod.Wait(5);
            string[] csvRowData = csvRows[rowNumber - 2].Split(',');
            return csvRowData.Take(11).ToArray();
        }

        static string[] GetTableRowData(IWebElement table, int rowNumber, int startColumn, int endColumn)
        {
            // Get the Row data from table with help of 'tr' 
            IWebElement row = table.FindElements(By.TagName("tr"))[rowNumber - 1];
            List<IWebElement> cells = row.FindElements(By.TagName("td")).ToList();
            string[] rowData = cells
                .Skip(startColumn - 1)
                .Take(endColumn - startColumn + 1)
                .Select(cell => cell.Text)
                .ToArray();
            return rowData;
        }
    }
}
#endregion