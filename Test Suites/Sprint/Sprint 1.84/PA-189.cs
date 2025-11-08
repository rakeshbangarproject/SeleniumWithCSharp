using Forms.Reporting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
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

namespace SmartBuildAutomation.Sprint_1._84
{
    [TestFixture, Category("Sprint_1_.84")]
    public class MaximumLength : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void CheckMaximumLengthPanel()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Maximum Length for Panel");
            HomePage.NavigateToSetupWizardPages();
            DeleteRemainingElements();
            AddDataInTheSheathingTab();
            AddDataForWithPartLength();
            FetchDataFromExcelSheetAndVerifyPartLengthValue();
            SetupWizard.SaveDataInTheSetupWizard();
            VerifyDataInDefaultJob();
            CommonMethod.DeleteFolderData();
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToSetupWizardPages();
            DeleteRemainingElements();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of switching Product Systems Script");
        }

        private static void AddDataInTheSheathingTab()
        {
            string[] skuNames = { "Without Part Length Positive", "Without Part Length Negative" };
            string[] maxLengths = { "50", "-50" };

            for (int i = 0; i < maxLengths.Length; i++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterSKUInputField(skuNames[i]);
                SetupWizard.EnterDescriptionInputField(skuNames[i]);
                SetupWizard.EnterCoverageWidthInputField("36");
                SetupWizard.EnterFullWidthInputField("37.5");
                SetupWizard.EnterThicknessInputField("0.25");
                SetupWizard.EnterUnderlapLengthInputField("5");
                SetupWizard.SelectAllElementFromUsageTable();
                SetupWizard.EnterMaximumLengthInputField(maxLengths[i]);
                SetupWizard.ClickSaveButton();
            }
        }

        #region Private Methods
        private void DeleteRemainingElements()
        {
            SetupWizard.ClickSheathing();

            string[] elementsToDelete = { "Without Part Length Positive", "Without Part Length Negative", "With Part Length Element" };

            foreach (var element in elementsToDelete)
            {
                SetupWizard.DeleteSetupWizardData(element);
            }

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSheathing();
            }
        }

        private void VerifyDataInDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingROOF_1();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofSheathing();

            VerifyRoofMaterial("Without Part Length Positive");
            VerifyRoofMaterial("Without Part Length Negative", "Maximum length is negative");
            VerifyRoofMaterial("With Part Length Element", null, "10'");
        }

        private void VerifyRoofMaterial(string material, string expectedErrorMessage = null, string expectedLength = null)
        {
            DefaultJobElement.SelectRoofMaterial(material);
            Console.WriteLine($"Selected roof material: {material}");
            DefaultJobElement.PageLoaderFor2D();

            if (!string.IsNullOrEmpty(expectedErrorMessage))
            {
                DefaultJobElement.ClickServerErrorMessageButton();
                string warningMessage = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.serverErrorMessagePopup))).Text;
                Assert.That(warningMessage.Contains(expectedErrorMessage), $"Verify that the message '{expectedErrorMessage}' is shown to the user.");
                Console.WriteLine(warningMessage);
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.okayButton))).Click();
            }
            else
            {
                DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorRoof", material, null, null, expectedLength);
                Console.WriteLine($"Verified maximum length for material: {material}");
            }
        }

        private void AddDataForWithPartLength()
        {
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("With Part Length Element");
            SetupWizard.EnterDescriptionInputField("With Part Length Element");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("37.5");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterUnderlapLengthInputField("5");
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.EnterMaximumLengthInputField("50");
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickPartLength();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.partLengthFirstColumn)));
            ExtentTestManager.TestSteps("Enter Data in the Part Length Field");
            CommonMethod.GetActions().DoubleClick(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("10").Perform();
            SetupWizard.ClickSaveButton();
        }

        private void FetchDataFromExcelSheetAndVerifyPartLengthValue()
        {
            SetupWizard.DownloadTheExcelFile();
            string excelFileName = "SetupWizard-Sheathing.xlsx";
            FolderPath.WaitForFileDownload(excelFileName, 60);
            string downloadsFolderPath = Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify that the XLSX file is downloaded");

            using var fileStream = File.Open(downloadsFolderPath, FileMode.Open);
            XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
            var sheet = workbook.GetSheetAt(0);

            if (sheet != null)
            {
                VerifySheetData(sheet);
            }
        }

        private void VerifySheetData(ISheet sheet)
        {
            string[] elementsToVerify = { "Without Part Length Positive", "Without Part Length Negative", "With Part Length Element" };

            foreach (var element in elementsToVerify)
            {
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(0).ToString().Contains(element))
                    {
                        for (int j = 0; j <= 22; j++)
                        {
                            Console.WriteLine(row.GetCell(j).ToString());
                        }
                    }
                }
            }
        }
        #endregion
    }
}