using Microsoft.VisualBasic.FileIO;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Text;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using Forms.Reporting;
using SmartBuildProductionAutomation.Helper;
using System.Collections.Generic;
using System;
using System.Linq;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Sprint_1._85
{
    [TestFixture, Category("Sprint_1_.85")]
    public class GroupAddOnsCheck2 : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test, Order(1)]
        public void PickList()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Items missing Pick List with Group add-ons checked");
            FolderPath.CreateFolder(folderPath);
            CommonMethod.DeleteFolderFile(folderPath);
            HomePage.NavigateToTheOutputPage();
            AddDataInTheOutputTableForPDFAndCSVFiles();

            HomePage.ClicksStartFromScratch();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            VerifyThatDoorPlacedOnCanvasBuilding(initialValue, currentValue);
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.ClickWalkdoorOfAddOns();
            AddPlusIconElements();
            DefaultJobElement.ChangeViewBackRight();
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            string updatedValue = DefaultJobElement.GetTheConfiguredPrice();
            VerifyThatDoorPlacedOnCanvasBuilding(updatedValue, currentValue);
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Pick List");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            CompareDataOfCSVFileAndPdfFiles();
            DefaultJobElement.ClickHomeButton();
        }

        [Test, Order(2)]
        public void Delete()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Data");
            HomePage.NavigateToTheOutputPage();

            string[] descriptions = { "Pick add group ons(PDF)", "Pick add group ons(CSV)", "Pick no add group ons(PDF)", "Pick no add group ons(CSV)" };

            foreach (var description in descriptions)
            {
                OutputPageElement.DeleteDataFromOutputTable(description);
            }

            OutputPageElement.ClickMainSaveButtonForPostFrame();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(4)).Perform();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Pick List");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Category field input Script");
        }

        #region Private Methods

        private void AddDataInTheOutputTableForPDFAndCSVFiles()
        {
            string[] noAddGroupOnsDescriptions = { "Pick no add group ons(PDF)", "Pick no add group ons(CSV)" };
            string[] noAddGroupOnsTypes = { "Job Data PDF", "Job Data CSV" };
            string[] addGroupOnsDescriptions = { "Pick add group ons(PDF)", "Pick add group ons(CSV)" };
            string[] addGroupOnsTypes = { "Job Data PDF", "Job Data CSV" };

            GenerateOutput(noAddGroupOnsDescriptions, noAddGroupOnsTypes, true);
            GenerateOutput(addGroupOnsDescriptions, addGroupOnsTypes, false);

            OutputPageElement.ClickMainSaveButtonForPostFrame();
        }

        private void GenerateOutput(string[] descriptions, string[] types, bool includeGroupAddOns)
        {
            for (int i = 0; i < descriptions.Length; i++)
            {
                OutputPageElement.ClickAddButton();
                OutputPageElement.EnterDescription(descriptions[i]);
                OutputPageElement.SelectTypeOption(types[i]);
                OutputPageElement.CheckIgnoreUsageCheckbox();

                if (includeGroupAddOns)
                {
                    OutputPageElement.CheckGroupAddonsCheckbox();
                }

                OutputPageElement.ClickSaveButton();
            }
        }

        private void AddPlusIconElements()
        {
            string[] descriptionNames = { "#8 x 1 1/4 Flathead Phillips", "12 X 3 WOOD SCREW FLAT PHILLIPS", "12-24 X 2 MACHINE SCREW FLAT" };

            for (int i = 0; i < descriptionNames.Length; i++)
            {
                DefaultJobElement.AddDoorFromAddOnsElement(descriptionNames[i]);
            }
        }

        private void CompareDataOfCSVFileAndPdfFiles()
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Pick add group ons(PDF)");
            DefaultJobElement.DownloadFileFromOutputFrame("Pick no add group ons(PDF)");
            string date = DateTime.Now.ToString("MM/dd/yyyy").Replace('/', '-');

            try
            {
                string pdfFileName1 = $"Pick List_{date}.pdf";
                string pdfFilePath1 = System.IO.Path.Combine(folderPath, pdfFileName1);
                FolderPath.WaitForFileDownload(pdfFilePath1, 20);
                string pdfFileName2 = $"Pick List_{date} (1).pdf";
                string pdfFilePath2 = System.IO.Path.Combine(folderPath, pdfFileName2);
                FolderPath.WaitForFileDownload(pdfFilePath2, 20);

                var pdfData1 = ExtractTextFromPDF(pdfFilePath1);
                var pdfData2 = ExtractTextFromPDF(pdfFilePath2);
                bool pdfMatch = CompareArrays(pdfData1, pdfData2);
                Assert.IsTrue(pdfMatch, "Data matches between both PDF files.");
                ExtentTestManager.TestSteps($"Data matches between both PDF files: {pdfMatch}");
            }
            catch (Exception)
            {
                string dateFormat = DateTime.Now.ToString("dd/MM/yyyy").Replace('/', '-');
                string pdfFileName1 = $"Pick List_{dateFormat}.pdf";
                string pdfFilePath1 = System.IO.Path.Combine(folderPath, pdfFileName1);
                FolderPath.WaitForFileDownload(pdfFilePath1, 60);
                string pdfFileName2 = $"Pick List_{dateFormat} (1).pdf";
                string pdfFilePath2 = System.IO.Path.Combine(folderPath, pdfFileName2);
                FolderPath.WaitForFileDownload(pdfFilePath2, 60);

                var pdfData1 = ExtractTextFromPDF(pdfFilePath1);
                var pdfData2 = ExtractTextFromPDF(pdfFilePath2);
                bool pdfMatch = CompareArrays(pdfData1, pdfData2);
                Assert.IsTrue(pdfMatch, "Data matches between both PDF files.");
                ExtentTestManager.TestSteps($"Data matches between both PDF files: {pdfMatch}");
            }

            DefaultJobElement.DownloadFileFromOutputFrame("Pick add group ons(CSV)");
            string csvFileName1 = $"Pick List-Pick add group ons(CSV)_{date}.csv";
            string csvFilePath1 = System.IO.Path.Combine(folderPath, csvFileName1);
            FolderPath.WaitForFileDownload(csvFilePath1, 60);
            DefaultJobElement.DownloadFileFromOutputFrame("Pick no add group ons(CSV)");
            string csvFileName2 = $"Pick List-Pick no add group ons(CSV)_{date}.csv";
            string csvFilePath2 = System.IO.Path.Combine(folderPath, csvFileName2);
            FolderPath.WaitForFileDownload(csvFilePath2, 60);

            var csvData1 = ReadDataFromCSVFile(csvFilePath1);
            var csvData2 = ReadDataFromCSVFile(csvFilePath2);

            bool csvMatch = csvData1.SetEquals(csvData2);
            Assert.IsTrue(csvMatch, "Data matches between both CSV files.");
            ExtentTestManager.TestSteps($"Data matches between both CSV files: {csvMatch}");
        }

        private static HashSet<string> ReadDataFromCSVFile(string filePath)
        {
            string columnToCheck = "Framing";
            var columnValues = new HashSet<string>();

            using (var parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] header = parser.ReadFields();
                int columnIndex = Array.IndexOf(header, columnToCheck);

                if (columnIndex != -1)
                {
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        if (fields[columnIndex] == "Doors & Windows")
                        {
                            for (int i = 0; i < 6 && !parser.EndOfData; i++)
                            {
                                fields = parser.ReadFields();
                                if (!string.IsNullOrEmpty(fields[1]))
                                {
                                    columnValues.Add(fields[1]);
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Doors & Windows:");
            ExtentTestManager.TestSteps("Doors & Windows:");
            foreach (var value in columnValues)
            {
                Console.WriteLine(value);
                ExtentTestManager.TestSteps(value);
            }

            return columnValues;
        }

        private static string[] ExtractTextFromPDF(string filePath)
        {
            using (PdfReader reader = new PdfReader(filePath))
            using (PdfDocument document = new PdfDocument(reader))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= document.GetNumberOfPages(); i++)
                {
                    string pageContent = PdfTextExtractor.GetTextFromPage(document.GetPage(i), new SimpleTextExtractionStrategy());
                    text.Append(pageContent);
                }

                string[] targetPhrases = { "Doors & Windows", "3x7 LIS Solid Steel", "#8 x 1 1/4 Flathead", "Phillips", "12 X 3 WOOD", "SCREW FLAT", "PHILLIPS", "12-24 X 2 MACHINE", "SCREW FLAT" };
                var extractedData = targetPhrases.Where(phrase => text.ToString().Contains(phrase)).ToArray();

                foreach (var phrase in extractedData)
                {
                    Console.WriteLine($"{phrase}: Found");
                }

                return extractedData;
            }
        }

        private static bool CompareArrays(string[] array1, string[] array2)
        {
            return array1.Length == array2.Length && !array1.Where((t, i) => t != array2[i]).Any();
        }

        private void VerifyThatDoorPlacedOnCanvasBuilding(string initialValue, string currentValue)
        {
            if (initialValue.Equals(currentValue))
            {
                string message = "Verify that Door is not placed on the canvas building";
                Console.WriteLine(message);
                ExtentTestManager.TestSteps(message);
                Assert.Fail(message);
            }
            else
            {
                string message = "Verify that Door is placed on the canvas building";
                Console.WriteLine(message);
                ExtentTestManager.TestSteps(message);
            }
        }

        #endregion
    }
}
