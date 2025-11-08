using Forms.Reporting;
using Microsoft.VisualBasic.FileIO;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SmartBuildAutomation.Sprint_1._85
{
    [TestFixture, Category("Sprint_1_.85")]

    public class MinimumCutLength : BaseClass
    {
        #region XPath
        string sheathingTableData = "(//div[@id='w2ui-overlay']//following :: td)[{0}]";
        private double number123;
        #endregion
        public string folderPath = FolderPath.Download();

        [Test]
        public void MinimumPanelLength()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Apply a min length for Panels");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickSheathing();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Minimum Cut Length");
            SetupWizard.EnterDescriptionInputField("Test Minimum Cut Length");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("37.5");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterMinimumCutLengthInputField("36");
            SetupWizard.ClickSaveButton();
            SetupWizard.DownloadTheExcelFile();

            string excelFileName = "SetupWizard-Sheathing.xlsx";
            string filePath = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(filePath, 60);
            string columnName = "MinimumCut Length";
            string searchTerm = "36";

            int lastRow = GetLastRowOfColumnByColumnName(filePath, columnName, searchTerm);

            if (lastRow != -1)
            {
                Console.WriteLine($"Verify that that the '{columnName}' column in the XLSX file is showing and the Minimum Cut Length data matches a value of '36'.");
                ExtentTestManager.TestSteps($"Verify that that the '{columnName}' column in the XLSX file is showing and the Minimum Cut Length matches a value of '36'.");
            }
            else
            {
                Assert.Fail($"Verify that the '{columnName}' column is not shown in the XLSX file.");
            }

            SetupWizard.DownloadTheCSVFile();
            string excelFileName1 = "SetupWizard-Sheathing.csv";
            string filePathCSV = Path.Combine(folderPath, excelFileName1);
            FolderPath.WaitForFileDownload(filePathCSV, 60);
            string specificDataToFind = "MinimumCut Length";

            CommonMethod.Wait(3);
            string[] firstRow = GetFirstRow(filePathCSV);

            if (firstRow != null)
            {
                int specificDataIndex = Array.IndexOf(firstRow, specificDataToFind);

                if (specificDataIndex != -1)
                {
                    string[] columnData = GetColumnData(filePathCSV, specificDataIndex);

                    if (columnData != null && columnData.Length > 0)
                    {
                        string lastValue = columnData[columnData.Length - 1];
                        Console.WriteLine($"Verify that the 'Minimum Cut Length' column is shown in the CSV file and the cut length data is matched with '{lastValue}'.");
                        ExtentTestManager.TestSteps($"Verify that the 'Minimum Cut Length' column is shown in the CSV file and the cut length data is matched with '{lastValue}'.");
                    }
                    else
                    {
                        Assert.Fail($"No data found in the matching column.");
                    }
                }
                else
                {
                    Assert.Fail($"Specific data '{specificDataToFind}' not found in the first row.");
                }
            }
            else
            {
                Assert.Fail($"Specific data '{specificDataToFind}' not found in the first row.");
            }

            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksStartFromScratch();
            AttachedPorchOnTheCanvas();
            VerifyMinimumCutLength();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Category field input Script");
        }

        #region private method
        private void AttachedPorchOnTheCanvas()
        {
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickFrontLeft();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
        }

        private void VerifyMinimumCutLength()
        {
            DefaultJobElement.ClickSheathingDrawingROOF_3();
             DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("ExteriorRoof", null, null, null, "3'");     
            ExtentTestManager.TestSteps("Verify that the S13 is shorter than the minimum cut length input of 3'");

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReviewAndDoubleClickOnTheMaterial("Sheathing", "ExteriorRoof", null, null, null, null, null, null, "3'", null, null);

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(sheathingTableData, "4"))));
            string pickListFirstRow = CommonMethod.element.Text;
            pickListFirstRow = pickListFirstRow.Replace("'", "").Trim();
            double pickVal = (double)double.Parse(pickListFirstRow);

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(sheathingTableData, "12"))));
            string pickListSecondRow = CommonMethod.element.Text;
            pickListSecondRow = pickListSecondRow.Replace("'", "").Trim();
            double pickVal1 = (double)double.Parse(pickListSecondRow);

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(sheathingTableData, "7"))));
            string cutLengthFirstRow = CommonMethod.element.Text;
            ConvertNumberIntoFeet(cutLengthFirstRow);
            double cutLength = number123;

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(sheathingTableData, "15"))));
            string cutLengthSecondRow = CommonMethod.element.Text;
            ConvertNumberIntoFeet(cutLengthSecondRow);
            double cutLength2 = number123;

            if (pickVal > cutLength && pickVal1 > cutLength2)
            {
                Console.WriteLine($"Verify that the Pick length '{pickVal}' is greater than the Cut Length '{cutLength2}'");
                ExtentTestManager.TestSteps($"Verify that the Pick length '{pickVal}' is greater than the Cut Length '{cutLength2}'");
            }
        }

        public void ConvertNumberIntoFeet(string input)
        {
            // Define the regular expression pattern for extracting values
            string pattern = @"^(\d+)'\s?(\d+)\s?(\d+/\d+)?""$";

            // Match the input string against the pattern
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                // Extract the feet, inches, and fraction parts
                int feet = int.Parse(match.Groups[1].Value);
                int inches = int.Parse(match.Groups[2].Value);
                string fractionPart = match.Groups[3].Value;

                // Parse the fraction values if available
                int numerator = 0;
                int denominator = 1;

                if (!string.IsNullOrEmpty(fractionPart))
                {
                    string[] fractionParts = fractionPart.Split('/');
                    numerator = int.Parse(fractionParts[0]);
                    denominator = int.Parse(fractionParts[1]);
                }

                // Calculate the total length in feet
                double totalFeet = feet + (inches + (double)numerator / denominator) / 12;
                number123 = totalFeet;
            }
            else
            {
                Console.WriteLine("Invalid input format");
            }
        }

        #endregion
        #region Read data from excel file
        static int GetLastRowOfColumnByColumnName(string filePath, string columnName, string searchTerm)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                    var sheet = workbook.GetSheetAt(0); // Assuming the data is on the first sheet

                    int columnCount = sheet.GetRow(0).LastCellNum;
                    int columnIndex = -1;

                    // Find the column index by matching the column name
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (sheet.GetRow(0).GetCell(i).StringCellValue.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if (columnIndex != -1)
                    {
                        int rowCount = sheet.LastRowNum + 1;

                        // Search for the specified name in the column
                        for (int row = 1; row < rowCount; row++) // Start from row 1 to skip the header
                        {
                            var cellValue = sheet.GetRow(row).GetCell(columnIndex).StringCellValue;
                            if (cellValue.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                            {
                                return row;
                            }
                        }

                        return -1; // The search term was not found in the column
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
        #endregion
        #region Read the from CSV file 
        static string[] GetFirstRow(string filePath)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    if (!parser.EndOfData)
                    {
                        return parser.ReadFields();
                    }
                    else
                    {
                        Console.WriteLine("CSV file is empty.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
                return null;
            }
        }

        static string[] GetColumnData(string filePath, int columnIndex)
        {
            try
            {
                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    string[] columnData = new string[0];

                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        if (fields.Length > columnIndex)
                        {
                            Array.Resize(ref columnData, columnData.Length + 1);
                            columnData[columnData.Length - 1] = fields[columnIndex];
                        }
                    }

                    return columnData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the CSV file: {ex.Message}");
                return null;
            }
        }
    }
}
#endregion