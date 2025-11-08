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

namespace SmartBuildAutomation.Sprint_1._85
{
    [TestFixture, Category("Roofing_Passport")]
    public class JobReport : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void OpeningPackages()
        {
            ExtentTestManager.CreateTest("Add Category field input");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.ClicksJobTab();
            JobPage.CreateCopyOfJob("Zombie Parts");
            JobPage.OpenJob("Zombie Parts copy 1");
            CommonMethod.Wait(3);
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Create the new copy of job");
            ExtentTestManager.TestSteps("Click on the edit button of the newly created job");
            string ChangesNewStatus = "New";
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Testing Job Report");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButtonAndYesButtonPop();
            DefaultJobElement.ChangeStatusOfJob("Prep for Order");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickJobListButton();
            string ChangesOrderStatus = JobPage.OpenJob("Testing Job Report");
            CommonMethod.PageLoader();
            VerifyData(ChangesNewStatus, ChangesOrderStatus);
            Console.WriteLine(ChangesNewStatus, ChangesOrderStatus);
            ExtentTestManager.TestSteps("Click on the 'Prep' button of the newly created job");
            VerifyOtherElement();
            DefaultJobElement.ClickJobListButton();
            string ChangesCloseStatus = JobPage.OpenJob("Testing Job Report");
            CommonMethod.PageLoader();
            VerifyData(ChangesOrderStatus, ChangesCloseStatus);
            Console.WriteLine(ChangesOrderStatus, ChangesCloseStatus);
            ExtentTestManager.TestSteps("Click on the 'View' button of the newly created job");
            DefaultJobElement.ClickJobListButton();
            VerifyDataInCSVFile();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Category field input Script");
        }

        #region Priavte Method
        private void VerifyOtherElement()
        {
            string disable = DisplayedElement();
            Assert.That(disable, Is.EqualTo("Roof system dropdown is disable"));
            ExtentTestManager.TestSteps("Roof system dropdown are disable because the  job status is 'Order'");
            DefaultJobElement.StatusChangeButtonButton("Unlock");
            CommonMethod.PageLoader();
            string enable = DisplayedElement();
            Assert.That(enable, Is.EqualTo("Roof system dropdown is enabled"));
            ExtentTestManager.TestSteps("Roof system dropdown are not disable because the job status is 'New'");
            DefaultJobElement.StatusChangeButtonButton("Prep for Order");
            CommonMethod.PageLoader();
            DefaultJobElement.StatusChangeButtonButton("Make Order");
            CommonMethod.PageLoader();
        }

        private string DisplayedElement()
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("(//input[@name='ProductSystem'])[1]"));
                if (CommonMethod.element.Enabled)
                {
                    return "Roof system dropdown is enabled";
                }
                else
                {
                    return "Roof system dropdown is disable";
                }
            }
            catch
            {
                return "Roof system dropdown is disable";
            }
        }

        public void VerifyData(string getTheDataFromJonReview, string compareBothData)
        {
            if (getTheDataFromJonReview.Contains(compareBothData))
            {
                Console.WriteLine($"Verified that the job status is not changed from {getTheDataFromJonReview}  to  {compareBothData}");
                ExtentTestManager.TestSteps($"Verified that the job status is not changed from {getTheDataFromJonReview}  to  {compareBothData}");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verified that the job status is changed from {getTheDataFromJonReview}  to  {compareBothData}");
                Console.WriteLine($"Verified that the job status is changed from {getTheDataFromJonReview}  to  {compareBothData}");
            }
        }

        #region Verify the CSV file data
        public void VerifyDataInCSVFile()
        {
            var date = DateTime.Now.ToString("00yyyy/MM/dd");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.PartialLinkText("Jobs"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@id='downloadJobListReport']"))).Click();
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='startDate']")));
            CommonMethod.element.SendKeys(date);
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='endDate']")));
            CommonMethod.element.SendKeys(date);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@class='btn']"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.Wait(5);

            var date1 = DateTime.Now.ToString("MM/dd/yyyy");
            string dateOfFile = date1.Replace('/', '-');
            string FilePath = $"JobList-AUTOTEST_EAGLEVIEW BASE_{dateOfFile}_{dateOfFile}.csv";
            string downloadCSVFile = Path.Combine(folderPath, FilePath);

            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");

            // Find the table and retrieve the row data
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='grid_grid_records']/table/tbody"));
            string[] tableRowData = GetTableRowData(table, 3, 2, 13);
            IList<IWebElement> r_table = table.FindElements(By.TagName("tr"));
            string a_xpath = "//div[@id='grid_grid_records']/table/tbody/tr[";
            string b_xpath = "]/td[2]";
            var rowCount = r_table.Count();

            for (int r = 3; r <= rowCount; r++)
            {
                string n = Driver.FindElement(By.XPath(a_xpath + r + b_xpath)).Text;

                if (n.Contains("Testing Job Report"))
                {
                    // Read the CSV file and get data from row 3
                    CommonMethod.Wait(5);
                    string[] csvRowData = GetCsvRowData(downloadCSVFile, 3);
                    CommonMethod.Wait(5);
                    // Compare the data from CSV and table
                    for (int i = 0; i < csvRowData.Length; i++)
                    {
                        if (csvRowData[i] == tableRowData[i])
                        {
                            Console.WriteLine($"Column {i + 1}: Values match {csvRowData[i]} {tableRowData[i]}");
                            ExtentTestManager.TestSteps($"Column {i + 1}: Values match {csvRowData[i]} {tableRowData[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"Column {i + 1}: Values do not match {csvRowData[i]} {tableRowData[i]}");
                            ExtentTestManager.TestSteps($"Column {i + 1}: Values do not match {csvRowData[i]} {tableRowData[i]}");
                        }
                    }
                    break;
                }
            }
        }

        static string[] GetCsvRowData(string filePath, int rowNumber)
        {
            string[] csvRows = File.ReadAllLines(filePath);
            CommonMethod.Wait(2);
            string[] csvRowData = csvRows[rowNumber - 2].Split(',');
            CommonMethod.Wait(2);
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
        #endregion 
    }
}
#endregion