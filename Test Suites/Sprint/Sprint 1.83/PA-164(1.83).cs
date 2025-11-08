using Forms.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Resource;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Smoke_test")]
    public class RoofMart : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void Roof()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST(TestData.PA_164.extentReport);
            HomePage.NavigateToSetupWizardPages();
            CreateNewMaterialInFramingTable();
            VerifyNewFramingMaterialInDefaultJob();
            CommonMethod.DeleteFolderData();

            DefaultJobElement.DownloadFileFromOutputFrame("Assembly Drawings");
            DefaultJobElement.ClickHomeButton();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("Wood ` material ` Trading` 0 ` 2X0-4");
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Assembly Drawing Data");
            CommonMethod.Wait(3);
            VerifyPDFContent();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Verify the Assembly Drawing Script");
        }

        #region private Methods 
        /// <summary>
        /// Opens the default job, checks if the newly created framing material is shown in the Wall Girt Framing dropdown.
        /// Fails the script if the material is not shown. Enters a job name and saves the job.
        /// </summary>
        private static void VerifyNewFramingMaterialInDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallGirtFraming();
            CommonMethod.Wait(2);
            DefaultJobElement.SelectGirtMaterial("Wood ` material ` Trading` 0 ` 2X0-4");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Assembly Drawing Data");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
        }

        /// <summary>
        /// Creates a new material in the Framing table of the setup wizard.
        /// Adds data such as SKU, description, width, depth fields, selects all elements from the usage table,
        /// and clicks on the save button of the framing table.
        /// Clicks on the Save All button to save all data in the setup wizard.
        /// </summary>
        private void CreateNewMaterialInFramingTable()
        {
            SetupWizard.ClickFraming();
            CheckIfOldDataIsShownInTheTableThenDeleted();

            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Wood ` Trading` 0 ` 2X0-4");
            SetupWizard.EnterDescriptionInputField("Wood ` material ` Trading` 0 ` 2X0-4");
            SetupWizard.EnterWidthInputField("2");
            SetupWizard.EnterDepthInputField("6");
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        /// <summary>
        /// Delete the data from framing table
        /// </summary>
        private void CheckIfOldDataIsShownInTheTableThenDeleted()
        {
            SetupWizard.DeleteSetupWizardData("Wood ` material ` Trading` 0 ` 2X0-4");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickFraming();
            }
        }

        /// <summary>
        /// Fetches data from a PDF file and verifies that the backtick symbol ( ` ) is replaced with a comma ( , ).
        /// </summary>
        public void VerifyPDFContent()
        {
            try
            {
                CommonMethod.Wait(2);
                string pdfFileName = CommonMethod.GetThePdfFileName("Assembly Drawing Data");
                CommonMethod.Wait(2);
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                CommonMethod.Wait(2);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                CommonMethod.Wait(5);
                ComparePdfFileData(pdfFilePath);
            }
            catch (Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("Assembly Drawing Data");
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                FolderPath.WaitForFileDownload(pdfFilePath, 60);
                CommonMethod.Wait(5);
                ComparePdfFileData(pdfFilePath);
            }
        }

        public static void ComparePdfFileData(string pdfFilePath)
        {
            string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            ExtentTestManager.TestSteps("Verify PDF File is downloaded");

            if (readDataFromPdfFile.Contains("Wood , material , Trading, 0 , 2X0-4"))
            {
                Console.WriteLine($"Verify the function replaces backtick symbols ( ` ) with commas ( , ) in the assembly drawing output. Wood , material , Trading, 0 , 2X0-4");
                ExtentTestManager.TestSteps($"Verify the function replaces backtick symbols ( ` ) with commas ( , ) in the assembly drawing output. Wood , material , Trading, 0 , 2X0-4");
            }
            else
            {
                Assert.That(readDataFromPdfFile, Is.EqualTo("Wood , material , Trading, 0 , 2X0-4"), "Wood , material , Trading, 0 , 2X0-4 material is not shown in the pdf file");
            }
        }
    }
}
#endregion