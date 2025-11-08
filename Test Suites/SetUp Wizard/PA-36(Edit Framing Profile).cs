using Forms.Reporting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Setup_wizard")]
    public class EditFramingProfile : BaseClass
    {
        int p = 3;
        public string folderPath = FolderPath.Download();
        [Test]
        public void FramingProfile()
        {
            DimensionProfile();
            GetExcelSheetData();
            DeleteData();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Framing Profile");
        }

        #region Private Method
        public void DimensionProfile()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Edit Framing Profile");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            DeleteData();

            string[] sku = new string[6] { "DefaultProfileData", "YellowPineProfileData", "SpruceValueProfileData", "TreatedLumberProfileData", "RedIronProfileData", "GrayIronProfileData" };
            string[] colorData = new string[6] { "Dimension Lumber", "Cee", "Zee", "Zee (Rotated)", "I Beam", "Back To Back Cee" };
            for (int i = 0; i < sku.Length; i++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterSKUInputField(sku[i]);
                SetupWizard.EnterDescriptionInputField(sku[i]);
                SetupWizard.EnterWidthInputField("3.5");
                SetupWizard.EnterDepthInputField("13");
                SetupWizard.SelectColor("Spruce");
                SetupWizard.SelectProfile(colorData[i]);
                SetupWizard.SelectAllElementFromUsageTable();
                SetupWizard.EnterPricingDetails("5", "6");
                SetupWizard.ClickAddButtonOfPricingTable();
                PartLengthForSheathing();
                SetupWizard.ClickSaveButton();
            }

            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
        }

        private void PartLengthForSheathing()
        {
            // Enter value in the Part Length 
            string[] partLength = new string[2] { "12", "14" };
            for (int l = 0; l < partLength.Length; l++)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_pricingsGrid_records']/table/tbody/tr[" + p + "]/td[1]")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(partLength[l]).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Pricings')]"))).Click();
                CommonMethod.Wait(1);
                p++;
            }
            p = 3;
            ExtentTestManager.TestSteps("Enter value in the Part Length ");
        }

        private void DeleteData()
        {
            string[] sku = new string[6] { "DefaultProfileData", "YellowPineProfileData", "SpruceValueProfileData", "TreatedLumberProfileData", "RedIronProfileData", "GrayIronProfileData" };
            for (int i = 0; i < sku.Length; i++)
            {
                SetupWizard.DeleteSetupWizardData(sku[i]);
            }

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickFraming();
            }
        }

        private void GetExcelSheetData()
        {
            SetupWizard.DownloadTheExcelFile();
            string excelFileName = "SetupWizard-Framing.xlsx";
            string downloadExcelFile = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(downloadExcelFile, 60);

            string[] sku1 = new string[6] { "DefaultProfileData{LF}", "YellowPineProfileData{LF}", "SpruceValueProfileData{LF}", "TreatedLumberProfileData{LF}", "RedIronProfileData{LF}", "GrayIronProfileData{LF}" };
            string[] colorData = new string[6] { "DimensionLumber", "Cee", "Zee", "ZeeRotated", "IBeam", "BackToBackCee" };

            using (FileStream file = new FileStream(downloadExcelFile, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook Workbook = new XSSFWorkbook(file);
                var sheet = Workbook.GetSheetAt(0);

                if (sheet != null)
                {
                    int LastRowNumber = sheet.LastRowNum;

                    for (int i = 0; i < sku1.Length; i++)
                    {
                        for (int k = 0; k <= LastRowNumber; k++)
                        {
                            IRow currentRow = sheet.GetRow(k);
                            var skuCell = currentRow?.GetCell(0);

                            if (skuCell != null && skuCell.ToString().Contains(sku1[i]))
                            {
                                var colorCell = currentRow.GetCell(12);
                                if (colorCell != null && colorCell.ToString() == colorData[i])
                                {
                                    Console.WriteLine($"SKU: {sku1[i]}, Color: {colorData[i]}");

                                    for (int col = 0; col <= 21; col++)
                                    {
                                        var value = currentRow.GetCell(col);
                                        Console.WriteLine($"Column {col + 1}: {value}");
                                    }

                                    Console.WriteLine();
                                }

                                break;
                            }
                        }

                        ExtentTestManager.TestSteps("Verify that Added Profile are shown are shown in the XLSX file");
                    }
                }
            }
        }
    }
}
#endregion
