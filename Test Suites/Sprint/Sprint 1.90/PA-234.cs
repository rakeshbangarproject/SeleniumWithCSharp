using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildProductionAutomation.Helper;
using System;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class DoorsMoved : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test, Order(1)]
        public void HotPatch()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH - Output Categories double up doors when moved");
            HomePage.NavigateToOutputCategories();
            bool result = DeleteDataFromOutputCategories();

            if (result)
            {
                HomePage.NavigateToOutputCategories();
            }
            string[] nameOfOutputElement = new string[4] { "TestWalkDoor", "TestOverhead", "TestSlider", "TestWindow" };

            for (int i = 0; i < nameOfOutputElement.Length; i++)
            {
                OutputCategories.ClickAddButton();
                OutputCategories.EnterNameOfCategories(nameOfOutputElement[i]);
            }

            OutputCategories.ClickOutputCategoriesMaterial("Doors & Windows");
            OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWWalkDoor", "TestWalkDoor");
            OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWOverhead", "TestOverhead");
            OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWSlider", "TestSlider");
            OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWWindow", "TestWindow");

            OutputCategories.ClickOutputCategoriesMaterial("TestWalkDoor");
            OutputCategories.ClickOnTheUsageElement("DWWalkDoor");
            OutputCategories.ClickOutputCategoriesMaterial("TestOverhead");
            OutputCategories.ClickOnTheUsageElement("DWOverhead");
            OutputCategories.ClickOutputCategoriesMaterial("TestSlider");
            OutputCategories.ClickOnTheUsageElement("DWSlider");
            OutputCategories.ClickOutputCategoriesMaterial("TestWindow");
            OutputCategories.ClickOnTheUsageElement("DWWindow");
            Console.WriteLine("Verify that DWWalkDoor, DWOverhead, DWSlider and DWWindow successfully moves to the TestWalkDoor, TestOverhead, TestSlider and TestWindow of the Usage table.");
            ExtentTestManager.TestSteps("Verify that DWWalkDoor, DWOverhead, DWSlider and DWWindow successfully moves to the TestWalkDoor, TestOverhead, TestSlider and TestWindow of the Usage table.");
            OutputCategories.ClickSaveButton();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(150, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewBackRight();
            DefaultJobElement.OpeningDoorsSelection("Slider");
            CommonMethod.Wait(2);

            string width = DefaultJobElement.GetWidthOfOpening();
            string height = DefaultJobElement.GetHeightOfOpening();

            string widthField = width.Replace("'", "");
            string heightField = height.Replace("'", "");


            DefaultJobElement.PlaceOpening(150, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SelectOpeningDoor("Windows", "Slider", "30x30 Slider");
            DefaultJobElement.PlaceOpening(50, 150);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            Assert.IsNotNull(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='TestWalkDoor'])[1]"))), "TestWalkDoor tab is not shown in the Job Review");
            Assert.IsNotNull(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='TestOverhead'])[1]"))), "TestOverhead tab is not shown in the Job Review");
            Assert.IsNotNull(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='TestSlider'])[1]"))), "TestSlider tab is not shown in the Job Review");
            Assert.IsNotNull(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='TestWindow'])[1]"))), "TestWindow tab is not shown in the Job Review");
            Console.WriteLine("Verify that the TestWalkDoor, TestOverhead, TestSlider and TestWindow are shown in the newly created TestWindow of the Job Review");
            ExtentTestManager.TestSteps("Verify that the TestWalkDoor, TestOverhead, TestSlider and TestWindow are shown in the newly created TestWindow of the Job Review");

            DefaultJobElement.ClickTestWalkDoor();
            DefaultJobElement.CheckMaterialsDataFromJobReview("TestWalkDoor", "WalkDoor", "3x7 LIS Solid Steel Door", "3x7 LIS Solid Steel Door", null, null, null, null, null, null, null);
            DefaultJobElement.ClickTestOverhead();
            DefaultJobElement.CheckMaterialsDataFromJobReview("TestOverhead", "Overhead", "10x10 OHD-no windows", "10x10 OHD-no windows", null, null, null, null, null, null, null);
            DefaultJobElement.ClickTestSlider();
            DefaultJobElement.CheckMaterialsDataFromJobReview("TestSlider", "Slider", $"{widthField}x{heightField} Slider", $"{widthField}x{heightField} Slider", null, null, null, null, null, null, null);
            DefaultJobElement.ClickTestWindow();
            DefaultJobElement.CheckMaterialsDataFromJobReview("TestWindow", "Window", "VS3030LE", "30x30 Slider", null, null, null, null, null, null, null);

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("OutputCategoriesTestJob");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.DownloadFileFromOutputFrame("Job Data PDF");
            ReadJobBidPDFData(widthField, heightField);
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete data");
            DeleteDataFromOutputCategoriesPage();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH - Output Categories double up doors when moved");
        }

        #region Read Data From PDF File
        private static void DeleteDataFromOutputCategoriesPage()
        {
            HomePage.NavigateToOutputCategories();
            DeleteDataFromOutputCategories();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("OutputCategoriesTestJob");
            CommonMethod.DeleteFolderData();
        }

        private static bool DeleteDataFromOutputCategories()
        {
            try
            {
                bool result = OutputCategories.ClickOutputCategoriesElement("TestWalkDoor");
                if (result)
                {
                    OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWWalkDoor", "Doors & Windows");
                    OutputCategories.ClickOutputCategoriesMaterial("TestOverhead");
                    OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWOverhead", "Doors & Windows");
                    OutputCategories.ClickOutputCategoriesMaterial("TestSlider");
                    OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWSlider", "Doors & Windows");
                    OutputCategories.ClickOutputCategoriesMaterial("TestWindow");
                    OutputCategories.MoveElementOneUsageTableToAnotherUsageTable("DWWindow", "Doors & Windows");
                    OutputCategories.ClickOutputCategoriesMaterial("Doors & Windows");
                    OutputCategories.ClickOnTheUsageElement("DWWalkDoor");
                    OutputCategories.ClickOnTheUsageElement("DWOverhead");
                    OutputCategories.ClickOnTheUsageElement("DWOverhead");
                    OutputCategories.ClickOnTheUsageElement("DWSlider");
                    OutputCategories.ClickOnTheUsageElement("DWWindow");
                    OutputCategories.DeleteElementFromOutputCategoriesTable("TestWalkDoor");
                    OutputCategories.DeleteElementFromOutputCategoriesTable("TestOverhead");
                    OutputCategories.DeleteElementFromOutputCategoriesTable("TestSlider");
                    OutputCategories.DeleteElementFromOutputCategoriesTable("TestWindow");
                    OutputCategories.ClickSaveButton();
                }

                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void ReadJobBidPDFData(string sliderWidth, string sliderHeight)
        {
            ExtentTestManager.TestSteps("Verify PDF File is downloaded");
            string readDataFromPdfFile = VerifyPDFContent();

            string[] results = new string[8] { "TestWalkDoor", "Walk Door 3x7 LIS Solid Steel", "TestOverhead", "Overhead 10x10 OHD-no", "TestSlider", $"Slider {sliderWidth}x{sliderHeight} Slider", "TestWindow", "Window 30x30 Slider" };
            Console.WriteLine("Job Data Pdf:");

            for (int i = 0; i < results.Length; i++)
            {
                if (readDataFromPdfFile.Contains(results[i]))
                {
                    Console.WriteLine($"Verify that {results[i]} element shown in the pdf file");
                    ExtentTestManager.TestSteps($"Verify that {results[i]} element shown in the pdf file");
                }
                else
                {
                    Assert.Fail($"Verify that {results[i]} element is not shown in the pdf file");
                }
            }
        }

        public string VerifyPDFContent()
        {
            try
            {
                string pdfFileName = CommonMethod.GetThePdfFileName("OutputCategoriesTestJob");
                FolderPath.WaitForFileDownload(pdfFileName, 60);
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                CommonMethod.Wait(5);
                return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
            catch (Exception)
            {
                string pdfFileName = CommonMethod.GetThePdfFileNameDateStartWithDays("OutputCategoriesTestJob");
                FolderPath.WaitForFileDownload(pdfFileName, 60);
                string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
                CommonMethod.Wait(5);
                return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
        }
    }
}
#endregion