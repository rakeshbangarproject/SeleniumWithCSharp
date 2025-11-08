using Forms.Reporting;
using NUnit.Framework;
using SmartBuildProductionAutomation.Helper;
using System;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class JobBidMissing : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void DoorAndWindows()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH - Job Bid is missing Doors/Windows");
            HomePage.NavigateToTheOutputPage();
            OutputPageElement.OpenExistingElement("Job Bid");
            OutputPageElement.CheckDoorAndWindowCheckbox();
            OutputPageElement.ClickSaveButton();
            OutputPageElement.ClickMainSaveButtonForPostFrame();
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.ClickWalkdoorOfAddOns();
            AddPlusIconElements();
            DefaultJobElement.PlaceOpening(50, 100);
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Job Bid Missing");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.DownloadFileFromOutputFrame("Job Bid");
            ReadJobBidPDFData();
            DefaultJobElement.ClickHomeButton();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Job Bid Missing");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH - Job Bid is missing Doors/Windows");
        }

        #region Verify PDF File data
        public void ReadJobBidPDFData()
        {
            string readDataFromPdfFile = VerifyPDFContent();

            string[] results = new string[6] { "Doors & Windows", "3x7 LIS Solid Steel Door", "3x7 LIS Solid Steel Door", "#8 x 1 1/4 Flathead Phillips", "12 X 3 WOOD SCREW FLAT PHILLIPS", "12-24 X 2 MACHINE SCREW FLAT" };
            Console.WriteLine("Job Bid Pdf File Data:");
            bool data = false;

            for (int i = 0; i < results.Length; i++)
            {
                if (readDataFromPdfFile.Contains(results[i]))
                {
                    Console.WriteLine($"Verify that {results[i]} element shown in the pdf file");
                    ExtentTestManager.TestSteps($"Verify that {results[i]} element shown in the pdf file");
                    data = true;
                }
            }

            Assert.That(data, Is.True, $"Verify that the element is not shown in the pdf file");
        }

        private void AddPlusIconElements()
        {
            string[] descriptionNames = { "#8 x 1 1/4 Flathead Phillips", "12 X 3 WOOD SCREW FLAT PHILLIPS", "12-24 X 2 MACHINE SCREW FLAT" };

            for (int i = 0; i < descriptionNames.Length; i++)
            {
                DefaultJobElement.AddDoorFromAddOnsElement(descriptionNames[i]);
            }
        }

        public string VerifyPDFContent()
        {
            try
            {
                string pdfFileName = CommonMethod.GetThePdfFileName("Job Bid Missing");
                FolderPath.WaitForFileDownload(pdfFileName, 60);
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                CommonMethod.Wait(5);
               return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
            catch (Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("Job Bid Missing");
                FolderPath.WaitForFileDownload(pdfFileName, 60);
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                CommonMethod.Wait(5);
                return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
        }

    }
}
#endregion