using System;
using System.Collections.Generic;
using System.IO;
using Forms.Reporting;
using Microsoft.VisualBasic.FileIO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class OpeningTag : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void CheckOpeningTagInExcelAndCSV()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Check opening tags");
            string walkdoorMaterialName, overheadMaterialName, windowsMaterialName, sliderMaterialName;
            OpenDefaultJobAndVerifyCustomTagsInJobReviewSection(out walkdoorMaterialName, out overheadMaterialName, out windowsMaterialName, out sliderMaterialName);
            EnterJobNameAndSaveJob();
            string[] materialList;
            string currentDate;
            DownloadJobBidPdfFileAndExcelFileAndCheckTags(walkdoorMaterialName, overheadMaterialName, windowsMaterialName, sliderMaterialName, out materialList, out currentDate);
            DownloadCSVFileAndCheckTags(materialList, currentDate);
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("PA-275");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Check opening tags");
        }

        #region Private Method
        private void DownloadCSVFileAndCheckTags(string[] materialList, string currentDate)
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Job Data CSV");
            string csvFileName = $"PA-275-Job Data_{currentDate}.csv";
            string filePathCSV = Path.Combine(folderPath, csvFileName);
            FolderPath.WaitForFileDownload(filePathCSV, 60);

            for (int i = 0; i < materialList.Length; i++)
            {
                SearchMaterialAndProcessRow(filePathCSV, materialList[i]);
            }

            Console.WriteLine("Verify the opening text displayed after the custom door and window materials in the csv file");
            ExtentTestManager.TestSteps("Verify the opening text displayed after the custom door and window materials in the csv file");
        }

        private void DownloadJobBidPdfFileAndExcelFileAndCheckTags(string walkdoorMaterialName, string overheadMaterialName, string windowsMaterialName, string sliderMaterialName, out string[] materialList, out string currentDate)
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Job Bid");
            materialList = new string[] { walkdoorMaterialName, overheadMaterialName, windowsMaterialName, sliderMaterialName };
            VerifyPDFContent(materialList);
            DefaultJobElement.DownloadFileFromOutputFrame("Excel Workbook");
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            currentDate = date.Replace('/', '-');
            string excelFileName = $"PA-275-MaterialList_{currentDate}.XLSX";
            string filePath = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(filePath, 60);
            string columnName = "Material";
            string sheetName = "Doors & Windows";

            for (int i = 0; i < materialList.Length; i++)
            {
                GetLastRowOfColumnBySheetNameAndColumnName(filePath, sheetName, columnName, materialList[i]);
            }

            Console.WriteLine("Verify the opening text displayed after the custom door and window materials in the excel workbook.");
            ExtentTestManager.TestSteps("Verify the opening text displayed after the custom door and window materials in the excel workbook.");
        }

        private static void EnterJobNameAndSaveJob()
        {
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("PA-275");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
        }

        private void OpenDefaultJobAndVerifyCustomTagsInJobReviewSection(out string walkdoorMaterialName, out string overheadMaterialName, out string windowsMaterialName, out string sliderMaterialName)
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            walkdoorMaterialName = PlaceOpeningOnCanvasBuilding("WalkDoor", 100, 100);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            overheadMaterialName = PlaceOpeningOnCanvasBuilding("Overhead", 150, 150);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            DefaultJobElement.ChangeViewBackRight();
            windowsMaterialName = PlaceOpeningOnCanvasBuilding("Windows", 100, 100);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            sliderMaterialName = PlaceSliderCustom("Slider", 150, 150);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickDoorAndWindowOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Door and Window", "WalkDoor", null, walkdoorMaterialName, null, null, null, null, null, null, null);
            DefaultJobElement.CheckMaterialsDataFromJobReview("Door and Window", "Overhead", null, overheadMaterialName, null, null, null, null, null, null, null);
            DefaultJobElement.CheckMaterialsDataFromJobReview("Door and Window", "Slider", null, sliderMaterialName, null, null, null, null, null, null, null);
            DefaultJobElement.CheckMaterialsDataFromJobReview("Door and Window", "Window", null, windowsMaterialName, null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps("Verify the opening text displayed after the custom door and window materials in the job review section.");
            Console.WriteLine("Verify the opening text displayed after the custom door and window materials in the job review section.");
        }

        public void VerifyPDFContent(string[] openingDoorList)
        {
            try
            {
                string pdfFileName = CommonMethod.GetThePdfFileName("PA-275");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                CommonMethod.Wait(5);
                ComparePdfFileData(pdfFilePath, openingDoorList);
            }
            catch (Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("PA-275");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                CommonMethod.Wait(5);
                ComparePdfFileData(pdfFilePath, openingDoorList);
            }
        }

        static int GetLastRowOfColumnBySheetNameAndColumnName(string filePath, string sheetName, string columnName, string searchTerms)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    bool result = false;
                    XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                    ISheet sheet = null;

                    // Find the sheet by its name
                    for (int i = 0; i < workbook.NumberOfSheets; i++)
                    {
                        if (workbook.GetSheetName(i).Equals(sheetName, StringComparison.OrdinalIgnoreCase))
                        {
                            sheet = workbook.GetSheetAt(i);
                            break;
                        }
                    }

                    if (sheet == null)
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                        return -1;
                    }

                    int columnCount = sheet.GetRow(0).LastCellNum;
                    int columnIndex = -1;

                    // Find the column index by matching the column name
                    for (int i = 0; i < columnCount; i++)
                    {
                        var cell = sheet.GetRow(0).GetCell(i).ToString();
                        if (cell.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if (columnIndex != -1)
                    {
                        int rowCount = sheet.LastRowNum;

                        // Search for any of the specified search terms in the column
                        for (int row = 1; row <= rowCount; row++) // Start from row 1 to skip the header
                        {
                            var cell = sheet.GetRow(row)?.GetCell(columnIndex);
                            if (cell != null)
                            {
                                string cellValue = cell.ToString();

                                if (cellValue.Equals(searchTerms, StringComparison.OrdinalIgnoreCase))
                                {
                                    result = true;
                                }
                            }
                        }

                        Assert.That(result, Is.True, $"{searchTerms} is not shown in the excel sheet");
                        return -1; // No match found
                    }
                    else
                    {
                        Console.WriteLine($"Column '{columnName}' not found in the Excel file.");
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the Excel file: {ex.Message}");
                return -1;
            }
        }

        private void SearchMaterialAndProcessRow(string filePathCSV, string materialToFind)
        {
            // Get all rows from CSV
            List<string[]> rows = GetAllRows(filePathCSV);

            if (rows != null && rows.Count > 0)
            {
                bool materialFound = false;
                foreach (var row in rows)
                {
                    // Check if the first column contains the material
                    if (row.Length > 0 && row[1].Contains(materialToFind, StringComparison.OrdinalIgnoreCase))
                    {
                        materialFound = true;
                        break;
                    }
                }

                if (!materialFound)
                {
                    Assert.Fail($"Material '{materialToFind}' not found in the first column.");
                }
            }
            else
            {
                Assert.Fail("No rows found in the CSV file.");
            }
        }

        // Get all rows from CSV
        static List<string[]> GetAllRows(string filePath)
        {
            try
            {
                List<string[]> rows = new List<string[]>();
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        rows.Add(fields);
                    }
                }

                return rows;
            }
            catch (Exception ex)
            {
                Assert.Fail($"An error occurred while reading the CSV file: {ex.Message}");
                return null;
            }
        }

        public static void ComparePdfFileData(string pdfFilePath, string[] openingDoorList)
        {
            int count = 0;
            string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            ExtentTestManager.TestSteps("Verify PDF File is downloaded");

            for (int i = 0; i < openingDoorList.Length; i++)
            {
                if (openingDoorList[i] != null && readDataFromPdfFile.Contains(openingDoorList[i]))
                {
                    count++;
                }
            }

            Assert.That(count, Is.EqualTo(openingDoorList.Length));
        }

        private string SelectCustom()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DefaultJobElement.SelectStyleFromDoors("Custom")).Perform();
            ExtentTestManager.TestSteps($"Click on the Custom");
            string width = DefaultJobElement.GetWidthOfOpening();
            string height = DefaultJobElement.GetHeightOfOpening();
            string getMaterial = $"{width} x {height} Opening";
            return getMaterial;
        }

        private string PlaceOpeningOnCanvasBuilding(string openingName, int x_axis, int y_axis)
        {
            DefaultJobElement.OpeningDoorsSelection(openingName);
            CommonMethod.Wait(3);
            string materialName = SelectCustom();
            DefaultJobElement.PlaceOpening(x_axis, y_axis);
            return materialName;
        }

        private string PlaceSliderCustom(string openingName, int x_axis, int y_axis)
        {
            DefaultJobElement.OpeningDoorsSelection(openingName);
            CommonMethod.Wait(3);
            DefaultJobElement.SelectStandardStyle();
            string width = DefaultJobElement.GetWidthOfOpening();
            string height = DefaultJobElement.GetHeightOfOpening();
            string side = DefaultJobElement.GetSideOfOpening();
            string getMaterial = $"{width} x {height} Opening-{side}";
            DefaultJobElement.PlaceOpening(x_axis, y_axis);
            ExtentTestManager.TestSteps($"Place the custom {openingName} on the canvas building");
            return getMaterial;
        }
    }
}
#endregion