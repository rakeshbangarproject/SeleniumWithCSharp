using NUnit.Framework;
using System;
using Forms.Reporting;
using SmartBuildProductionAutomation.Helper;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Sprint_1._89
{
    [TestFixture, Category("Sprint_1._89")]
    public class SummarySheetData : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void CeilingHeight()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Ceiling height shows different on the summary sheet than in the system");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.WidthInputField("30' 6\"");
            DefaultJobElement.LengthInputField("50' 6\"");
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            DefaultJobElement.ExteriorMetalHeightInputField("16' 6\"");
            DefaultJobElement.SelectRoofStyleMaterial("Gambrel");
            DefaultJobElement.SelectOverhangMaterial("1'");
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("PFS-4303");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.DownloadFileFromOutputFrame("Summary Sheet");
            VerifyDataShownInThePDFFile();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomePageURL"));
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("PFS-4303");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Ceiling height shows different on the summary sheet than in the system");
        }

        #region Private Method
        private void VerifyDataShownInThePDFFile()
        {
            string readDataFromPdfFile = GetPdfFileData();
            // Verify data on each page
            VerifyPDFFileData(readDataFromPdfFile, "Name", "PFS-4303\n");
            VerifyPDFFileData(readDataFromPdfFile, "Width", "30' 6\"");
            VerifyPDFFileData(readDataFromPdfFile, "Length", "50' 6\"");
            VerifyPDFFileData(readDataFromPdfFile, "Exterior Metal\nHeight", "16' 6\"");
            VerifyPDFFileData(readDataFromPdfFile, "Roof Low Pitch ", "16/12\n");
            VerifyPDFFileData(readDataFromPdfFile, "Roof High Pitch", "4/12\n");
            VerifyPDFFileData(readDataFromPdfFile, "Overhangs", "1'");
            Console.WriteLine("Verify that the Width, Length, Exterior Metal Height, and overhangs data are not changed in the summary sheet of the PDF file.");
            ExtentTestManager.TestSteps($"Verify that the Width, Length, Exterior Metal Height, and overhangs data are not changed in the summary sheet of the PDF file.");
        }

        private string GetPdfFileData()
        {
            try
            {
                string pdfFileName = CommonMethod.GetThePdfFileName("PFS-4303");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
                ExtentTestManager.TestSteps("Verify PDF File is download");
                return readDataFromPdfFile;
            }
            catch (Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("PFS-4303");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
                ExtentTestManager.TestSteps("Verify PDF File is download");
                return readDataFromPdfFile;
            }
        }

        private void VerifyPDFFileData(string pdfText, string fieldName, string number)
        {
            string expectedData = fieldName;
            if (pdfText.Contains(expectedData))
            {
                if (pdfText.Contains(number))
                {
                    Console.WriteLine($"In the summary sheet PDF file shows the correct data of {expectedData} :{number}");
                    ExtentTestManager.TestSteps($"In the summary sheet PDF file shows the correct data of {expectedData} :{number}");
                }
                else
                {
                    Assert.Fail($"In the summary sheet PDF file, the data is incorrect of {expectedData} :{number}");
                }
            }
            else
            {
                Assert.Fail("In the Summary sheet pdf file data are not match with default job");
            }
        }
    }
}
#endregion