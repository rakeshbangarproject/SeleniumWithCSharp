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

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class InvalidHEXCode : BaseClass
    {
        /// <summary>
        /// 1. Navigate to the SetUp Wizard and click on the Color tab
        /// 2. Create new color material for the job.
        /// 3. Click on the download button and also download the XLSX file 
        /// 4. Click on Upload Button and Upload the edited excel file with invalid HEX code
        /// 5. Click on Upload Button and Upload the edited excel file with valid HEX code
        /// 6. Verified that the XLSX file is successfully uploaded.
        /// 7. Click on the download button and also download the CSV file 
        /// 8. Click on Upload Button and Upload the edited CSV file with invalid HEX code
        /// 9. Click on Upload Button and Upload the edited CSV file with valid HEX code
        /// 10.Verified that the CSV file is successfully uploaded. 
        /// </summary>

        public string folderPath = FolderPath.Download();

        [Test]
        public void HEXColorCode()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Invalid HEX Code");
            CommonMethod.DeleteFolderData();
            AddNewDataInTheColorsTable();
            VerifyNewColorsDataShownInTheTable();
            VerifyExcelAndCSVData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Invalid HEX Code Script");
        }

        #region private Methods
        private void VerifyExcelAndCSVData()
        {
            ExcelData();
            CSVData();
        }

        /// <summary>
        /// Adds new data in the Colors table.
        /// </summary>
        private static void AddNewDataInTheColorsTable()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();

            SetupWizard.DeleteSetupWizardData("Colors1");
            CommonMethod.Wait(1);

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickColors();
            }

            SetupWizard.ClickAddButton();
            SetupWizard.ColorNameInputField("Colors1");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ColorCodeInputField("E06666");
            SetupWizard.SelectHexCode("E06666");  
            SetupWizard.ClickSaveButton();
        }

        #region Edit the Excel data 
        /// <summary>
        /// Downloads an Excel file from the setup wizard, modifies the last row of the second column with invalid data, saves the Excel file,
        /// uploads the modified file in the Colors table, handles error messages for invalid HEX codes, corrects the data with a valid HEX code,
        /// saves the Excel file again, uploads it successfully, and verifies the updated data in the Colors table.
        /// </summary>
        public void ExcelData()
        {
            SetupWizard.DownloadTheExcelFile();

            string excelFileName = "SetupWizard-Colors.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(excelFilePath, 60);
            SetupWizard.UpdateTheDataOfExcelSheetLastRow(excelFilePath, "Test12", 2,"TestColors");

            // Upload the modified Excel file with invalid HEX code
            SetupWizard.UploadFile(excelFilePath);
            Console.WriteLine("Click on Upload Button and Upload the edited excel file with invalid HEX code");
            ExtentTestManager.TestSteps("Click on Upload Button and Upload the edited excel file with invalid HEX code ");
            PopUpMessage();

            SetupWizard.UpdateTheDataOfExcelSheetLastRow(excelFilePath, "#456456", 2, "TestColors2");

            // Upload the corrected Excel file with a valid HEX code
            SetupWizard.UploadFile(excelFilePath);
            Console.WriteLine("Click on Upload Button and Upload the edited excel file with valid HEX code");
            ExtentTestManager.TestSteps("Click on Upload Button and Upload the edited excel file with valid HEX code");
            FileUploadSuccessfully("Excel");

            // Verify the updated data in the Colors table
            CommonMethod.GetActions().MoveToElement(SetupWizard.SearchElementInTheTable()).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys("TestColors2" + Keys.Enter).Perform();
            CommonMethod.Wait(2);
            string getEditedData = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.FirstRowElementOfTable))).Text; 

            if (getEditedData.Contains("#456456"))
            {
                ExtentTestManager.TestSteps("Verify the updated excel file data is shown in the Colors table");
                Console.WriteLine("Verify the updated excel file data is shown in the Colors table");
            }
            else
            {
                ExtentTestManager.TestSteps(" Verify the updated excel file data is not shown in the Colors table");
                Console.WriteLine("Verify the updated excel file data is not shown in the Colors table");
                Assert.Fail("Verify the updated excel file data is not shown in the Colors table");
            }
        }
        #endregion

        #region Edit the CSV File data
        /// <summary>
        /// Downloads a CSV file from the setup wizard, modifies the last row of the second column with invalid data, saves the CSV file,
        /// uploads the modified file in the Colors table, handles error messages for invalid HEX codes, corrects the data with a valid HEX code,
        /// saves the CSV file again, uploads it successfully, and verifies the updated data in the Colors table.
        /// </summary>
        public void CSVData()
        {
            // Download the CSV file from the setup wizard
            SetupWizard.DownloadTheCSVFile();
            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");
            string excelFileName = "SetupWizard-Colors.csv";
            string downloadCSVFile = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(downloadCSVFile, 60);

            // Navigate to the directory where the CSV file is located
            GetCSVFileData(downloadCSVFile);
            SetupWizard.ModifyTheLastRowOfCSVFile(downloadCSVFile, "Test125468", 2);

            // Upload the modified CSV file with invalid HEX code data
            SetupWizard.UploadFile(downloadCSVFile);
            Console.WriteLine("Click on Upload Button and Upload the edited CSV file with invalid HEX code data");
            ExtentTestManager.TestSteps("Click on Upload Button and Upload the edited CSV file with invalid HEX code data");
            CommonMethod.Wait(3);
            // Verify the Error Message
            PopUpMessage();

            // Navigate to the directory where the CSV file is located
            GetCSVFileData(downloadCSVFile);
            CommonMethod.Wait(6);
            SetupWizard.ModifyTheLastRowOfCSVFile(downloadCSVFile, "#999999", 2);
            CommonMethod.Wait(4);

            // Upload the corrected CSV file with valid HEX code
            SetupWizard.UploadFile(downloadCSVFile);
            CommonMethod.Wait(2);
            Console.WriteLine("Click on Upload Button and Upload the edited CSV file with valid HEX code");
            ExtentTestManager.TestSteps("Click on Upload Button and Upload the edited CSV file with valid HEX code");
            CommonMethod.Wait(2);
            FileUploadSuccessfully("CSV");
            CommonMethod.Wait(2);
            VerifyTheUpdatedCsvFile();
            CommonMethod.DeleteFolderData();
        }
        #endregion

        /// <summary>
        /// Verify that edited file upload successfully
        /// </summary>
        private void FileUploadSuccessfully(string fileName)
        {
            CommonMethod.Wait(3);
            SetupWizard.CheckAfterUploadFileInTheSetupWizardMessage("successfully updated",
             $"Verify that the edited {fileName} file is successfully update",
             $"Verify that the edited {fileName} file is not update");
        }

        private void PopUpMessage()
        {
            SetupWizard.CheckAfterUploadFileInTheSetupWizardMessage("Errors Found",
                "Verify that the following error message is shown to the user",
                "Verify that the following error message is not shown to the user");
        }

        /// <summary>
        /// This method is use for get the last element of name and verify this element data shown corrects.
        /// </summary>
        private void VerifyDataShownInTheTable(string expectedValue, string successMessage, string failureMessage)
        {
            SetupWizard.CheckNewEntries(expectedValue, successMessage, failureMessage);
        }

        private void VerifyNewColorsDataShownInTheTable()
        {
            VerifyDataShownInTheTable("Colors1", "Verify the new color is added to the Colors list", "Verify the new color is not added to the Colors list");
        }

        private void VerifyTheUpdatedCsvFile()
        {
            VerifyDataShownInTheTable("TestColors2", "Verify the updated CSV file data is shown in the Color table", "Verify the updated CSV file data is not shown in the Color table");
        }

        private bool GetCSVFileData(string downloadCSVFile)
        {
            Driver.Navigate().GoToUrl(downloadCSVFile);

            try
            {
                Driver.SwitchTo().Alert().Dismiss();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
    
        }
    }
}
#endregion

