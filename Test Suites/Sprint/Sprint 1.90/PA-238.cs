using Forms.Reporting;
using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class MinAndMax : BaseClass
    {
        public string folderPath = FolderPath.Download();
        [Test, Order(1)]
        public void Trim()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Min and Max settings for Trim(Post Frame)");
            Console.WriteLine("For Post Frame:\n");
            AddDataInTheTrimTableAndVerifyDataShownInTheExcelSheet();
            VerifyTrimMaterialShownInTheDefaultJob();
            CommonMethod.DeleteFolderData();
        }

        [Test, Order(2)]
        public void RoofingPassport()
        {
            LogInToApplication();

            ExtentTestManager.CreateTest("Min and Max settings for Trim(Roofing Passport)").Info("Log in to AUTOTEST_EAGLEVIEW BASE Distributor");
            Console.WriteLine("For Roofing Passport:\n");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            DeleteDataFromTrim();
            AddTrimElementWithoutPartLength();
            AddTrimElementWithPartLength();
            GetExcelSheetData();
            SetupWizard.SaveDataInTheSetupWizard();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            VerifyMinimumAndMaximumLengthInTheDefaultJob("Cladding");
            DefaultJobElement.NavigateToHomePage();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("Test Trim 1");
            SetupWizard.DeleteSetupWizardData("Min and Max Trim");
            SetupWizard.SaveDataInTheSetupWizard();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Min and Max settings for Trim(Post frame and Roofing Passport)");
        }

        #region Private Method
        private void VerifyTrimMaterialShownInTheDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickFrontRight();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            VerifyMinimumAndMaximumLengthInTheDefaultJob("Sheathing");
            DefaultJobElement.NavigateToHomePage();

            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("Test Trim 1");
            SetupWizard.DeleteSetupWizardData("Min and Max Trim");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void AddDataInTheTrimTableAndVerifyDataShownInTheExcelSheet()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            DeleteDataFromTrim();
            AddTrimElementWithoutPartLength();
            AddTrimElementWithPartLength();
            GetExcelSheetData();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void AddTrimElementWithoutPartLength()
        {
            SetupWizard.ClickAddButton();
            CommonMethod.Wait(1);
            SetupWizard.EnterSKUInputField("Test Trim 1");
            SetupWizard.EnterDescriptionInputField("Test Trim 1");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterHeightInputField("0.25");
            SetupWizard.EnterMinimumCutLengthInputField("36");
            SetupWizard.EnterMaximumLengthInputField("36");
            SetupWizard.SelectAllElementFromSystemTable();
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.ClickPartLength();
            SetupWizard.ClickSaveButton();
        }

        private void AddTrimElementWithPartLength()
        {
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Min and Max Trim");
            SetupWizard.EnterDescriptionInputField("Min and Max Trim");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterHeightInputField("0.25");
            SetupWizard.EnterMinimumCutLengthInputField("24");
            SetupWizard.EnterMaximumLengthInputField("36");
            SetupWizard.SelectAllElementFromSystemTable();
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.EnterPricingDetailsOfTrim("10", "20");
            AddButton();
            PartLengthForSheathing();
            SetupWizard.ClickSaveButton();
        }

        private void LogInToApplication()
        {
            // Log in to the application
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();

        }

        private void PartLengthForSheathing()
        {
            int p = 3;
            string[] partLengths = { "12", "14", "16", "18" };

            for (int l = 0; l < partLengths.Length; l++)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@id='grid_pricingsGrid_records']/table/tbody/tr[{p}]/td[1]")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(partLengths[l]).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Pricings')]"))).Click();
                p++;
            }
            ExtentTestManager.TestSteps("Enter value in the Part Length ");
        }

        private string GetExcelSheetData()
        {
            SetupWizard.DownloadTheExcelFile();
            string excelFileName = "SetupWizard-Trim.xlsx";
            string downloadExcelFile = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(downloadExcelFile, 60);

            string valueInFourthColumn = null;
            string valueInFourthColumn1 = null;

            using (var package = new ExcelPackage(new System.IO.FileInfo(downloadExcelFile)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Materials"];

                int minColumnIndex = FindColumnIndex(worksheet, "MinimumCut Length");
                int maxColumnIndex = FindColumnIndex(worksheet, "MaximumLength");

                if (minColumnIndex != -1 && maxColumnIndex != -1)
                {
                    Console.WriteLine("Verify that the Minimum Cut Length and Maximum Length columns are shown in the Trim material excel sheet");
                }

                string[] minAndMaxLength = { "Test Trim 1", "Min and Max Trim{LF}" };
                string[] minAndMaxLengthForTestTrim = { "36", "24" };
                string[] minAndMaxLengthForTrim = { "36", "36" };

                for (int i = 0; i < minAndMaxLength.Length; i++)
                {
                    int skuColumnIndex = FindColumnIndex(worksheet, "SKU");

                    if (skuColumnIndex != -1)
                    {
                        string targetSKU = worksheet.Cells[1, skuColumnIndex].Text;

                        int rowIndex = FindRowIndex(worksheet, skuColumnIndex, minAndMaxLength[i]);

                        if (rowIndex != -1)
                        {
                            valueInFourthColumn = worksheet.Cells[rowIndex, 6].Text;

                            if (valueInFourthColumn == minAndMaxLengthForTestTrim[i])
                            {
                                valueInFourthColumn1 = worksheet.Cells[rowIndex, 7].Text;

                                if (valueInFourthColumn1 == minAndMaxLengthForTrim[i])
                                {
                                    Console.WriteLine($"Verify that {minAndMaxLength[i]} values {minAndMaxLengthForTestTrim[i]} and {minAndMaxLengthForTrim[i]} are shown in the Minimum and Maximum Length of Trim Excel sheet");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{minAndMaxLength[i]} not found in the SKU column.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("SKU column not found in the Excel file.");
                    }
                }

                DirectoryInfo deleteFiles = new DirectoryInfo($@"{folderPath}");
                foreach (FileInfo file in deleteFiles.GetFiles())
                {
                    file.Delete();
                }
                return valueInFourthColumn;
            }
        }

        static int FindColumnIndex(ExcelWorksheet worksheet, string columnName)
        {
            int columnCount = worksheet.Dimension.Columns;

            for (int col = 1; col <= columnCount; col++)
            {
                if (worksheet.Cells[1, col].Text.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    return col;
                }
            }

            return -1;
        }

        static int FindRowIndex(ExcelWorksheet worksheet, int columnIndex, string targetValue)
        {
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++)
            {
                if (worksheet.Cells[row, columnIndex].Text.Equals(targetValue, StringComparison.OrdinalIgnoreCase))
                {
                    return row;
                }
            }

            return -1;
        }

        private void AddButton()
        {
            for (int i = 1; i <= 3; i++)
            {
                SetupWizard.ClickAddButtonOfPricingTable();
            }
        }

        private void VerifyMinimumAndMaximumLengthInTheDefaultJob(string element)
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ServerDelay();

            if (element.Equals("Cladding"))
            {
                DefaultJobElement.ClickRoofTrimForRoofingPassport();
            }
            else
            {
                DefaultJobElement.ClickRoofTrim();
            }

            DefaultJobElement.SelectEaveEdgeTrim("Test Trim 1");
            DefaultJobElement.SelectHipRidgeCap("Test Trim 1");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();

            if (element.Equals("Cladding"))
            {
                DefaultJobElement.ClickCladdingDrawingROOF_3();
            }
            else
            {
                DefaultJobElement.ClickSheathingDrawingROOF_3();
            }

            VerifyElementWithoutPartLength("EaveEdge", "3'");
            VerifyElementWithoutPartLength("HipCap", "3'");

            DefaultJobElement.SelectEaveEdgeTrim("Min and Max Trim");
            DefaultJobElement.SelectHipRidgeCap("Min and Max Trim");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();

            VerifyElementWithPartLength("EaveEdge", "18'", "12'");
            VerifyElementWithPartLength("HipCap", "12'", "");
        }

        private void VerifyElementWithoutPartLength(string elementType, string expectedLength)
        {
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable(elementType, "Test Trim 1", "Test Trim 1", null, expectedLength);
            Console.WriteLine($"Verify that the {elementType} Minimum Length value is {expectedLength} without part length");
            ExtentTestManager.TestSteps($"Verify that the {elementType} Minimum Length value is {expectedLength} without part length");
        }

        private void VerifyElementWithPartLength(string elementType, string expectedMax, string expectedMin)
        {
            string xpathMax = $"(//div[text()='{elementType}']//following :: td[@col='6'])[1]/div";
            string xpathMin = $"(//div[text()='{elementType}']//following :: td[@col='6'])[2]/div";

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathMax)));
            string actualMax = CommonMethod.element.Text;

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpathMin)));
            string actualMin = CommonMethod.element.Text;

            Assert.That(actualMax, Is.EqualTo(expectedMax));
            Console.WriteLine($"Verify that the {elementType} Maximum Length value is {expectedMax} with part length");
            ExtentTestManager.TestSteps($"Verify that the {elementType} Maximum Length value is {expectedMax} with part length");

            if (!string.IsNullOrEmpty(expectedMin))
            {
                Assert.That(actualMin, Is.EqualTo(expectedMin));
                Console.WriteLine($"Verify that the {elementType} Minimum Length value is {expectedMin} with part length");
                ExtentTestManager.TestSteps($"Verify that the {elementType} Minimum Length value is {expectedMin} with part length");
            }
        }

        private static void DeleteDataFromTrim()
        {
            SetupWizard.DeleteSetupWizardData("Test Trim 1");
            CommonMethod.Wait(1);
            SetupWizard.DeleteSetupWizardData("Min and Max Trim");
            CommonMethod.Wait(1);

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickTrim();
            }
        }
    }
}
#endregion