using Forms.Reporting;
using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class HeaderIssue : BaseClass
    {
        static string path = FolderPath.StoreCaptureImage("ScreenShot of PA-237");

        public string folderPath = FolderPath.Download();

        [Test]
        public void MainPost()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Header Issue snapping to main post");
            string searchTerm = VerifyDataInTheSetupWizardWalkdoor();
            VerifyDataInTheDoorsAndWindows(searchTerm);
            VerifyDataInTheDefaultJob();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Header Issue snapping to main post");
        }

        #region Private Method
        private static void VerifyDataInTheDefaultJob()
        {
            HomePage.ClicksHomeButton();
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Panel", "3378DimIssue");
            string disabledElementText = (string)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].value;", Driver.FindElement(By.Name("WidthStr")));
            Assert.That(disabledElementText, Is.EqualTo("3' 3 7/8\""));
            DefaultJobElement.PlaceOpening(120, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickDoorAndWindow();
            DefaultJobElement.ClickNonStructuralWalkdoorPostFraming();
            DefaultJobElement.SelectJambType("Post and Jamb");
            DefaultJobElement.SelectHeaderBoundaries("Next Column");

            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksShellButton();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(-80, 0);

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();

            string headerLength = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Header']//following::td[@col='6']//div[1])[1]"))).Text;

            if(!headerLength.Equals("7' 8 1/4\"") && !headerLength.Equals("7' 3 3/4\""))
            {
                Assert.Fail("Fail: Header is not match wit actual length");
            }

            Console.WriteLine("Verify that the Next column is applied to the canvas building.");
            ExtentTestManager.TestSteps($"Verify that the Next column is applied to the canvas building.");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", path, "HeaderIssue.png");
        }

        private void VerifyDataInTheDoorsAndWindows(string searchTerm)
        {
            HomePage.NavigateToDoorAndWindowPage();
            DoorsAndWindow.OpenDoorAndWindowMaterialFromDoubleClickOnTheMaterialName("3378DimIssue");
            string widthElementOfDoorsAndWindows = DoorsAndWindow.GetWidthInputValue();
            Assert.That(widthElementOfDoorsAndWindows, Is.EqualTo(searchTerm));
            Console.WriteLine("Verify that the newly create walkdoor Width value match with the DoorWindow(Edit) of width field.");
            ExtentTestManager.TestSteps($"Verify that the newly create walkdoor Width value match with the DoorWindow(Edit) of width field.");
            DoorsAndWindow.ClickBackToList();

            DoorsAndWindow.DownloadExcelFile();
            string excelFileName = "DoorWindows-AUTOTEST_PHTEST.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(excelFilePath, 60);
            string excelSheet = GetExcelSheetData(excelFilePath);

            DoorsAndWindow.UploadExcelAndCSVFile(excelFilePath);
            DoorsAndWindow.ClickBackToList();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='3378dimissue']//following :: td[@col='3']/div)[1]")));
            string widthSize = CommonMethod.element.GetAttribute("title");
            Assert.That(widthSize, Is.EqualTo(excelSheet));
            Console.WriteLine("Verify that the width value in the Doors & Windows table is not change after uploading the Excel sheet");
        }

        private string VerifyDataInTheSetupWizardWalkdoor()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            SetupWizard.DownloadTheExcelFile();

            string excelFileName = "SetupWizard-WalkDoors.xlsx";
            string filePath = Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(filePath, 60);
            bool result = false;
            string columnName = "Width";
            string searchTerm = "3.3229166666666665";
            int lastRow = SetupWizard.GetLastRowOfColumnByColumnName(filePath, columnName, searchTerm);

            if (lastRow != -1)
            {
                Console.WriteLine($"Verify the 3378DimIssue material width value {searchTerm} is correctly shown in the XLSX file of Setup Wizard.");
                ExtentTestManager.TestSteps($"Verify the 3378DimIssue material width value {searchTerm} is correctly shown in the XLSX file Setup Wizard.");
                result = true;
            }
            else
            {
                Assert.Fail($"Verify the 3378DimIssue material width value {searchTerm} is not correctly shown in the XLSX file Setup Wizard.");
            }

            Assert.That(result, Is.True, "Data is not shown in the excel file");
            return searchTerm;
        }

        private string GetExcelSheetData(string excelFilePath)
        {
            string valueInFourthColumn = null;

            using (var package = new ExcelPackage(new System.IO.FileInfo(excelFilePath)))
            {
                // Get the Materials worksheet
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Materials"];

                // Find the SKU column index
                int skuColumnIndex = FindColumnIndex(worksheet, "SKU");

                if (skuColumnIndex != -1)
                {
                    // Find the value in SKU column in the first row
                    string targetSKU = worksheet.Cells[1, skuColumnIndex].Text;

                    int rowIndex = FindRowIndex(worksheet, skuColumnIndex, "3378dimissue");

                    if (rowIndex != -1)
                    {
                        valueInFourthColumn = worksheet.Cells[rowIndex, 5].Text;
                        Console.WriteLine("The width value of 3378dimissue is shown in the excel file of Doors & Windows: " + valueInFourthColumn);
                    }
                    else
                    {
                        Console.WriteLine("3378dimissue not found in the SKU column.");
                    }
                }
                else
                {
                    Console.WriteLine("SKU column not found in the Excel file.");
                }
            }

            return valueInFourthColumn;
        }

        static int FindColumnIndex(ExcelWorksheet worksheet, string columnName)
        {
            // Find Column 
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
            // find row using column position
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
    }
}
#endregion
