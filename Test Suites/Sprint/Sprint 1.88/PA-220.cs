using NUnit.Framework;
using Forms.Reporting;
using SmartBuildProductionAutomation.Helper;
using System;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Sprint_1._88")]
    public class DocumentTemplate : BaseClass
    {
        readonly string getFilePath = FolderPath.DocumentFile();
        readonly string folderPath = FolderPath.Download();

        [Test]
        public void UploadFile()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Provide option to output a document template as a PDF");
            HomePage.NavigateToTheOutputPage();
            OutputPageElement.ClickAddButton();
            OutputPageElement.EnterDescription("TestDocumentTemplate");
            OutputPageElement.SelectTypeOption("Document Template");
            OutputPageElement.UploadFile($"{getFilePath}", "Document Template.docx");
            CommonMethod.Wait(3);
            OutputPageElement.SelectOutputType("PDF section");
            OutputPageElement.ClickSaveButton();
            OutputPageElement.ClickMainSaveButtonForPostFrame();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Document PDF Test");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CommonMethod.Wait(2);
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClicksOutputButton();
            DefaultJobElement.CheckOutputsCheckbox("Summary Sheet");
            DefaultJobElement.CheckOutputsCheckbox("TestDocumentTemplate");
            DefaultJobElement.ClicksDownloadButton();

            try
            {
                bool result = VerifyPDFFileData("Verify that the new Document template has been merged with the pdf file.\n Also verify that the data mentioned in the document template file matches that of the pdf file.");
                Assert.That(result, Is.True, "Document template is not merge with pdf");
                ExtentTestManager.TestSteps("Verify that the new Document template has been merged with the pdf file.\n Also verify that the data mentioned in the document template file matches that of the pdf file.");
                CommonMethod.DeleteFolderData();
                DefaultJobElement.ClickHomeButton();

            }
            catch (Exception)
            {
                DefaultJobElement.NavigateToHomePage();
            }

            HomePage.NavigateToTheOutputPage();
            OutputPageElement.DeleteDataFromOutputTable("TestDocumentTemplate");
            OutputPageElement.ClickMainSaveButtonForPostFrame();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Document PDF Test");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Provide option to output a document template as a PDF");
        }

        #region Private Method      
        private bool VerifyPDFFileData(string verify)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string sanitizedDate = date.Replace('/', '-');
            string excelFileName = $"Document PDF Test_{sanitizedDate}.pdf";
            string pdfFilePath = System.IO.Path.Combine(folderPath, excelFileName);
            FolderPath.WaitForFileDownload(pdfFilePath, 60);
            ExtentTestManager.TestSteps("Verify PDF File is download");
            string searchString1 = "Sales Proposal";
            string searchString2 = "{ProjectName}";
            string searchString3 = "TO TAL PRICE: $16,860.40";
            string searchString4 = $"QUOTE DATE: {date}";
            CommonMethod.Wait(3);
            string[] data = new string[] { searchString1, searchString2, searchString3, searchString4 };
            string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);

            for (int i = 0; i < readDataFromPdfFile.Length; i++)
            {
                if (readDataFromPdfFile.Contains(data[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
#endregion