using Forms.Reporting;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    [TestFixture, Category("Smoke_test")]
    public class TrussCatalogRange : BaseClass
    {
        public static string folderPath = FolderPath.Download();

        [Test, Order(1)]
        public void MaximumAndMinimumOverhang()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Truss Catalog range of overhangs (minimum and maximum)");
            FolderPath.CreateFolder(folderPath);
            CommonMethod.DeleteFolderFile(folderPath);
            CheckMinAndMaxOverhangLengthAreSame();
            CheckTrussesTableMaterialShownInTheJobReview();
            AddMaterialsInTheTrussesTable();
            DownloadExcelFileAndUpdateData();
            CheckNewTrussesMaterialsInTheDefaultJob();
        }

        [Test, Order(2)]
        public void DeleteMaterials()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Material");
            HomePage.NavigateToTrusses();
            TrussesElement.DeleteDataFromTrussesTable("TrussMaterial1");
            TrussesElement.DeleteDataFromTrussesTable("TrussMaterial2");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Truss Catalog range of overhangs (minimum and maximum)");
        }

        #region Private Method
        private void CheckNewTrussesMaterialsInTheDefaultJob()
        {
            DefaultJobElement.NavigateToHomePage();
            CheckTrussMaterialInDefaultJob("38");
            CheckTrussMaterial();
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickSyncButton();
            CheckTrussMaterial();
            DefaultJobElement.SelectOverhangMaterial("3'");
            DefaultJobElement.ClickSyncButton();
            CheckTrussMaterial();
            DefaultJobElement.SelectOverhangMaterial("None");
            DefaultJobElement.ClickSyncButton();
            CheckTrussMaterial();
            Console.WriteLine("Verify that the SKU materials have not changed after modifying the overhang values.");
        }

        private void DownloadExcelFileAndUpdateData()
        {
            TrussesElement.DownloadExcelFile();
            CommonMethod.Wait(2);
            CheckAndUpdateExcelSheetData();
            Console.WriteLine("Verify that the MinOH L, MinOH R, MaxOH L, and MaxOH R columns are shown in the Excel sheet.");
            CheckMinAndMaxValueAfterExcelSheetNewDataUpload();
            Console.WriteLine("Verify that the MinOH L, MinOH R, MaxOH L, and MaxOH R values are modified");
        }

        private void AddMaterialsInTheTrussesTable()
        {
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToTrusses();
            AddNewMaterialInTheTrussTable("TrussMaterial1", "C38P4HH12OH3SP4L20-10-10GB");
            AddNewMaterialInTheTrussTable("TrussMaterial2", "C38P4HH12OH3SP4L20-10-10");
        }

        private void CheckTrussesTableMaterialShownInTheJobReview()
        {
            DefaultJobElement.NavigateToHomePage();
            CheckTrussMaterialInDefaultJob("19");
            CheckTheSameTrussMaterialShownInTheTruss();
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CheckTheNewTrussShownInTheJobReview("(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='C19P4HH12OH1SP4L20-10-10GB'])[1]");
            CheckTheNewTrussShownInTheJobReview("(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='C19P4HH12OH1SP4L20-10-10'])[1]");
            Console.WriteLine("Verify that the C19P4HH12OH1SP4L20-10-10 materials are shown in the job review.");
        }

        private void CheckMinAndMaxOverhangLengthAreSame()
        {
            HomePage.NavigateToTrusses();
            TrussesElement.DeleteDataFromTrussesTable("TrussMaterial1");
            TrussesElement.DeleteDataFromTrussesTable("TrussMaterial2");
            TrussesElement.SearchInputField("C19P4HH12OH1SP4L20-10-10");

            try
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='grid_grid_records']//span[text()='C19P4HH12OH1SP4L20-10-10'])[1]")));
            }
            catch(NoSuchElementException) 
            {
                TrussesElement.SearchInputField().Clear();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                CommonMethod.Wait(2);
                TrussesElement.SearchInputField("C19P4HH12OH1SP4L20-10-10");
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='grid_grid_records']//span[text()='C19P4HH12OH1SP4L20-10-10'])[1]")));
            }

            CommonMethod.Wait(5);
            CheckMinAndMaxValuesOfOverhandAreSame();
            Console.WriteLine("Verify that the minimum and maximum values of the C19P4HH12OH1SP4L20-10-10 material are the same.");
        }

        // This method is used to check sku name is changed in the job review of truss table
        private void CheckTrussMaterial()
        {
            bool result = false;
            bool result1 = false;
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            string skuNameForL1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//tr[@id='grid_MaterialsGrid_rec_0']//td[@col='2']//div)[2]"))).Text;
            string materialForL1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_0']//td[@col='3']//div"))).Text;
            string qtyForL1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_0']//td[@col='6']//div"))).Text;
            string costForL1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_0']//td[@col='12']//div"))).Text;
            string skuNameForT1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//tr[@id='grid_MaterialsGrid_rec_1']//td[@col='2']//div)[2]"))).Text;
            string materialForT1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_1']//td[@col='3']//div"))).Text;
            string qtyForT1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_1']//td[@col='6']//div"))).Text;
            string costForT1Usage = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//tr[@id='grid_MaterialsGrid_rec_1']//td[@col='12']//div"))).Text;

            if (skuNameForL1Usage.Equals("TrussMaterial1") && materialForL1Usage.Equals("C38P4HH12OH3SP4L20-10-10GB") && qtyForL1Usage.Equals("2") && costForL1Usage.Equals("$100.00"))
            {
                result = true;
            }

            if (skuNameForT1Usage.Equals("TrussMaterial2") && materialForT1Usage.Equals("C38P4HH12OH3SP4L20-10-10") && qtyForT1Usage.Equals("9") && costForT1Usage.Equals("$100.00"))
            {
                result1 = true;
            }

            Assert.IsTrue(result == result1, "The truss SKU material has changed after modifying the overhang values.");
            ExtentTestManager.TestSteps("Verify that the SKU materials have not changed after modified the overhang values.");
        }

        // This method is used to check if new dimensions of trusses are implemented in the canvas building.
        private void CheckTrussMaterialInDefaultJob(string jobDimension)
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.LengthInputField(jobDimension);
            DefaultJobElement.WidthInputField(jobDimension);
            DefaultJobElement.SelectOverhangMaterial("1'");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofFraming();
            DefaultJobElement.TrussHeelHeightInputField("1");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrussesOfJobReview();
            DefaultJobElement.DoubleClickOnPrice();
        }

        // This method checks if MinOH L, MinOH R, MaxOH L, and MaxOH R materials are shown in the trusses table header.
        private void CheckMinAndMaxValuesOfOverhandAreSame()
        {
            CommonMethod.Wait(3);
            List<string> minLOHValues = TrussesElement.ProcessHeaders("Min OH L", "MinL");
            CommonMethod.Wait(3);
            List<string> maxLOHValues = TrussesElement.ProcessHeaders("Max OH L", "MaxL");
            CommonMethod.Wait(3);
            List<string> minROHValues = TrussesElement.ProcessHeaders("Min OH R", "MinR");
            EventFiringWebDriver eventFiringWebDriver = new(Driver);
            eventFiringWebDriver.ExecuteScript("document.querySelector('#grid_grid_records').scrollBy(80,0)");
            CommonMethod.Wait(3);
            List<string> maxROHValues = TrussesElement.ProcessHeaders("Max OH R", "MaxR");

            if (minLOHValues.SequenceEqual(maxLOHValues) && minROHValues.SequenceEqual(maxROHValues))
            {
                ExtentTestManager.TestSteps("Verify that the minimum and maximum values of the C19P4HH12OH1SP4L20-10-10 material are the same.");
            }
            else
            {
                Assert.Fail("MinR: " + string.Join(", ", minROHValues) + "\nMinL: "
                    + string.Join(", ", minLOHValues) + "\nMaxR: " + string.Join(", ", maxROHValues)
                    + "\n MaxL: " + string.Join(", ", maxLOHValues));
            }
        }

        // This method is used to check material shown in the job review 
        private void CheckTheSameTrussMaterialShownInTheTruss()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='C19P4HH12OH1SP4L20-10-10GB'])[1]")));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='C19P4HH12OH1SP4L20-10-10'])[1]")));
        }

        // This method is used to check truss material
        private void CheckTheNewTrussShownInTheJobReview(string elementXPath)
        {
            if (CommonMethod.IsElementPresent(By.XPath(elementXPath)))
            {
                Assert.Fail("After I change overhang the new truss is not shown truss table");
            }
        }

        // This method is used to check min and max values shown in the trusses table
        private void CheckMinAndMaxValueAfterExcelSheetNewDataUpload()
        {
            CommonMethod.Wait(2);
            TrussesElement.CheckMaterialValueOfMinAndMax("TrussMaterial1", "0'", "3'");
            TrussesElement.CheckMaterialValueOfMinAndMax("TrussMaterial2", "0'", "3'");
        }

        // This method is used to Add new material in the trusses table
        private void AddNewMaterialInTheTrussTable(string skuName, string description)
        {
            TrussesElement.ClickAddButton();
            TrussesElement.EnterSKUInputField(skuName);
            TrussesElement.EnterDescriptionInputField(description);
            TrussesElement.EnterSpanInputField("38'");
            TrussesElement.EnterDim2InputField("19'");
            TrussesElement.EnterPitch1InputField("4");
            TrussesElement.EnterPitch2InputField("4");
            TrussesElement.EnterHeelInputField("1'");
            TrussesElement.EnterMinOHLInputField("2'");
            TrussesElement.EnterMinOHRInputField("2'");
            TrussesElement.EnterMaxOHLInputField("2'");
            TrussesElement.EnterMaxOHRInputField("2'");

            if (skuName == "TrussMaterial1")
            {
                TrussesElement.IsGableCheckbox().Click();
            }

            TrussesElement.EnterMinSpacingInputField("4'");
            TrussesElement.EnterMaxSpacingInputField("4'");
            TrussesElement.EnterLoadingInputField("20-10-10");
            TrussesElement.ClickSaveButton();
            CommonMethod.Wait(2);
        }

        // This method checks data in the Excel sheet and uploads the edited sheet.
        private void CheckAndUpdateExcelSheetData()
        {
            string excelFileName = "TrussList-AUTOTEST_PHTEST.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify that the XLSX file is downloaded");
            FolderPath.WaitForFileDownload(excelFilePath, 60);
            CheckNewListDataAndUpdateExcelSheet(excelFilePath);
            TrussesElement.UploadFileInTheTrussTable(excelFilePath);
            CommonMethod.Wait(2);
        }

        /// <summary>
        /// This method is used to check if MinOH L, MinOH R, MaxOH L, and MaxOH R elements are shown in the header.
        /// It changes the values of MinOH L, MinOH R, MaxOH L, and MaxOH R.
        /// </summary>
        /// <param name="filePath">The path of the Excel sheet.</param>
        private void CheckNewListDataAndUpdateExcelSheet(string filePath)
        {
            List<int> storeColumnNumber = new();
            string[] headerMaterialName = new string[4] { "Min OH L", "Max OH L", "Min OH R", "Max OH R" };
            string[] minAndMaxValue = new string[2] { "TrussMaterial1", "TrussMaterial2" };

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                var sheet = workbook.GetSheetAt(0);

                int columnCount = sheet.GetRow(0).LastCellNum;

                for (int i = 0; i < columnCount; i++)
                {
                    string cellValue = sheet.GetRow(0).GetCell(i).StringCellValue;
                    for (int j = 0; j < headerMaterialName.Length; j++)
                    {
                        if (cellValue.Equals(headerMaterialName[j], StringComparison.OrdinalIgnoreCase))
                        {
                            storeColumnNumber.Add(i);
                            break;
                        }
                    }
                }

                Assert.That(storeColumnNumber.Count, Is.EqualTo(4), "The number of matching headers is not 4");

                int rowCount = sheet.LastRowNum;

                // Iterate through the rows to find matches in the minAndMaxValue array
                for (int row = 0; row < rowCount; row++)
                {
                    var firstCell = sheet.GetRow(row).GetCell(0);
                    if (firstCell == null) continue; // Skip rows with null in the first cell
                    string cellValue2 = firstCell.StringCellValue;

                    for (int j = 0; j < minAndMaxValue.Length; j++)
                    {
                        if (cellValue2.Equals(minAndMaxValue[j], StringComparison.OrdinalIgnoreCase))
                        {
                            if (storeColumnNumber.Count == 4)
                            {
                                var minOHLValue = sheet.GetRow(row).GetCell(storeColumnNumber[0]).StringCellValue;
                                var maxOHLValue = sheet.GetRow(row).GetCell(storeColumnNumber[1]).StringCellValue;
                                var minOHRValue = sheet.GetRow(row).GetCell(storeColumnNumber[2]).StringCellValue;
                                var maxOHRValue = sheet.GetRow(row).GetCell(storeColumnNumber[3]).StringCellValue;
                                CommonMethod.Wait(1);

                                int minOHLInt = int.Parse(minOHLValue.Replace("'", " "));
                                int minOHRInt = int.Parse(minOHRValue.Replace("'", " "));
                                int maxOHLInt = int.Parse(maxOHLValue.Replace("'", " "));
                                int maxOHRInt = int.Parse(maxOHRValue.Replace("'", " "));

                                // Convert integers back to strings to check for substrings
                                string minOHLStr = minOHLInt.ToString();
                                string minOHRStr = minOHRInt.ToString();
                                string maxOHLStr = maxOHLInt.ToString();
                                string maxOHRStr = maxOHRInt.ToString();

                                // Assertions
                                Assert.IsTrue(minOHLStr.Contains("2"), "MinOHL is not shown correct value in the excel sheet");
                                Assert.IsTrue(minOHRStr.Contains("2"), "MinOHR is not shown correct value in the excel sheet");
                                Assert.IsTrue(maxOHLStr.Contains("2"), "MaxOHL is not shown correct value in the excel sheet");
                                Assert.IsTrue(maxOHRStr.Contains("2"), "MaxOHR is not shown correct value in the excel sheet");

                                sheet.GetRow(row).GetCell(storeColumnNumber[0]).SetCellValue("0'");
                                sheet.GetRow(row).GetCell(storeColumnNumber[1]).SetCellValue("3'");
                                sheet.GetRow(row).GetCell(storeColumnNumber[2]).SetCellValue("0'");
                                sheet.GetRow(row).GetCell(storeColumnNumber[3]).SetCellValue("3'");
                            }
                            break;
                        }
                    }
                }

                using (FileStream outFileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(outFileStream);
                }
            }
        }
    }
}
#endregion