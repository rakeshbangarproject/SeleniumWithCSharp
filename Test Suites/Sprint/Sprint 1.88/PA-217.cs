using NUnit.Framework;
using SmartBuildProductionAutomation.Helper;
using Forms.Reporting;
using System;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Sprint_1._88
{
    [TestFixture, Category("Sprint_1._88")]
    public class QuotedJob : BaseClass
    {
        public string folderPath = FolderPath.Download();
        
        [Test]
        public void CrossSection()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Auto on Cross Section when quoted");
            HomePage.ClicksStartFromScratch();
            CommonMethod.Wait(1);
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            CommonMethod.Wait(1);
            DefaultJobElement.ClickTrussCarrier();
            CommonMethod.Wait(1);
            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            DefaultJobElement.SelectTopGirtMaterial("None");
            DefaultJobElement.SelectTrussCarrierStyle("Double");
            DefaultJobElement.SelectTrussCarrierMaterial("(Auto)");
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("PFS-4229");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            OutputButton();
            VerifyPDFFileData("(Auto)", "(Auto)", "The Job Status is New");
            DefaultJobElement.ChangeStatusOfJob("Make Quote");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4229");
            CommonMethod.PageLoader();
            OutputButton();
            VerifyPDFFileData("EXTERIOR CARRIER: 2x8", "INTERIOR CARRIER: 2x8", "The Job Status is Quoted");
            DefaultJobElement.ChangeStatusOfJob("Make Contract");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4229");
            CommonMethod.PageLoader();
            OutputButton();
            VerifyPDFFileData("EXTERIOR CARRIER: 2x8", "INTERIOR CARRIER: 2x8", "The Job Status is Make Contract");
            DefaultJobElement.ChangeStatusOfJob("Prep for Order");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4229");
            CommonMethod.PageLoader();
            OutputButton();
            VerifyPDFFileData("EXTERIOR CARRIER: 2x8", "INTERIOR CARRIER: 2x8", "The Job Status is Prep for Order");
            DefaultJobElement.ChangeStatusOfJob("Make Order");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4229");
            CommonMethod.PageLoader();
            OutputButton();
            VerifyPDFFileData("EXTERIOR CARRIER: 2x8", "INTERIOR CARRIER: 2x8", "The Job Status is Ordered");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Auto on Cross Section when quoted");
        }

        #region Private Method
        private void OutputButton()
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Cross Sections");
            CommonMethod.Wait(5);
            ExtentTestManager.TestSteps("Download the Cross Sections' PDF File");
        }

        private string GetPdfFileData()
        {
            try
            {
                string pdfFileName = CommonMethod.GetThePdfFileName("PFS-4229");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
                ExtentTestManager.TestSteps("Verify PDF File is download");
                return readDataFromPdfFile;
            }
            catch(Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("PFS-4229");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
                ExtentTestManager.TestSteps("Verify PDF File is download");
                return readDataFromPdfFile;
            }
        }

        private string VerifyPDFFileData(string searchString1, string searchString2, string jobStatus)
        {
            string readDataFromPdfFile = GetPdfFileData();
            CommonMethod.Wait(5);

            try
            {
                if (readDataFromPdfFile.Contains(searchString1))
                {
                    if (readDataFromPdfFile.Contains(searchString2))
                    {
                        ExtentTestManager.TestSteps($"{jobStatus} :Verify that the Exterior Carrier and Interior Carrier Material are not changed.");
                        Console.WriteLine($"{jobStatus} :Verify that the Exterior Carrier and Interior Carrier Material are not changed.");
                        return $"Verify that the Exterior Carrier and Interior Carrier Material are not changed.";
                    }
                }
                else
                {
                    ExtentTestManager.TestSteps($"{jobStatus}:Verify that the Exterior Carrier and Interior Carrier Materials are not showing as ‘Auto’");
                    Console.WriteLine($"{jobStatus} :Verify that the Exterior Carrier and Interior Carrier Materials are not showing as ‘Auto’");
                    return $"Verify that the Exterior Carrier and Interior Carrier Materials are not showing as ‘Auto’";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
        }
    }
}
#endregion