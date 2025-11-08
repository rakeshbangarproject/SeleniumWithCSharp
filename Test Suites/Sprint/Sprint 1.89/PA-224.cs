using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;
using SmartBuildAutomation.pageObjectModel;

namespace SmartBuildAutomation.Sprint_1._89
{
    [TestFixture, Category("Sprint_1._89")]
    public class CreateDistributor : BaseClass
    {
        string xpath = "(//div[text()='{0}'])[1]";
        public string screenshotOfIcon = FolderPath.StoreCaptureImage("ScreenShot of PA-224");
        public string folderPath = FolderPath.Download();

        [Test, Order(1)]
        public void OpeningStyles()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Opening Styles are not being copied with Create distributor");
            FolderPath.CreateFolder(screenshotOfIcon);
            CommonMethod.DeleteFolderFile(screenshotOfIcon);
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            RemainingDeleteElement();
            CreateWalkdoorMaterial();
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            SetupWizard.DownloadTheExcelFile();
            string excelFileName = "SetupWizard-WalkDoors.xlsx";
            string downloadXLSXFileOfAUTOTESTPHTEST = Path.Combine(folderPath, excelFileName);
            HomePage.NavigateToDistributor();
            CreateNewDistributor();
            VerifyDataInTheSetupWizard();
            string excelFileName1 = "SetupWizard-WalkDoors.xlsx";
            string downloadXLSXFileOfCopyDistributor = Path.Combine(folderPath, excelFileName1);
            string sheetName1 = "Materials";
            string sheetName2 = "Materials";

            bool result = HomePage.CompareExcelSheets(downloadXLSXFileOfCopyDistributor, sheetName1, downloadXLSXFileOfAUTOTESTPHTEST, sheetName2);

            if (result)
            {
                Console.WriteLine("Verify that the AUTOTEST_PHTEST Distributor and Copy KD Distributor excel sheet data are the same");
                ExtentTestManager.TestSteps("Verify that the AUTOTEST_PHTEST Distributor and Copy KD Distributor excel sheet data are the same");
            }
            else
            {
                Assert.Fail("Verify that the AUTOTEST_PHTEST Distributor and Copy KD Distributor excel sheet data are not the same");
            }

            VerifyDataInTheDefaultJob();
            CommonMethod.DeleteFolderData();
        }

        [Test, Order(2)]
        public void DeleteDistributor()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete newly create distributor");
            HomePage.NavigateToDistributor();
            Distributor.DeleteDistributor("Copy KD Distributor");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            DeleteWalkdoorData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Opening Styles are not being copied with Create distributor");
        }

        #region Private Method
        private void RemainingDeleteElement()
        {
            DeleDataFromWalkDoorTable();

            CommonMethod.element = Driver.FindElement(By.XPath("//button[contains(@onclick,'clickFinish()')]"));
            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickWalkDoors();
            }
        }

        private static void DeleDataFromWalkDoorTable()
        {
            string[] styleDropdownElement = new string[5] { "SolidDoor", "PanelDoor", "CommercialDoor", "PatioDoor", "OtherDoor" };

            for (int i = 0; i < styleDropdownElement.Length; i++)
            {
                SetupWizard.DeleteSetupWizardData(styleDropdownElement[i]);
            }
        }

        private void DeleteWalkdoorData()
        {
            DeleDataFromWalkDoorTable();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void CaptureScreenshotOfWalkdoorIconsAutotest()
        {
            DefaultJobElement.OpeningDoorsSelection("WalkDoor");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Solid", screenshotOfIcon, "SolidAutotest.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Panel", screenshotOfIcon, "PanelAutotest.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Commercial", screenshotOfIcon, "CommercialAutotest.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Patio", screenshotOfIcon, "PatioAutotest.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Other", screenshotOfIcon, "OtherAutotest.png");
            DefaultJobElement.NavigateToHomePage();
        }

        private void CaptureScreenshotOfWalkdoorIconsCopy()
        {
            DefaultJobElement.OpeningDoorsSelection("WalkDoor");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Solid", screenshotOfIcon, "SolidCopy.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Panel", screenshotOfIcon, "PanelCopy.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Commercial", screenshotOfIcon, "CommercialCopy.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Patio", screenshotOfIcon, "PatioCopy.png");
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("div", "style-image-Other", screenshotOfIcon, "OtherCopy.png");
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomePageURL"));
        }

        private void CreateWalkdoorMaterial()
        {
            string[] descriptionName = new string[5] { "Solid", "Panel", "Commercial", "Patio", "Other" };

            for (int i = 0; i < descriptionName.Length; i++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterSKUInputField($"{descriptionName[i]}Door");
                SetupWizard.EnterDescriptionInputField($"{descriptionName[i]}Door");
                SetupWizard.EnterWidthInputField("5");
                SetupWizard.EnterHeightInputField("6");
                CommonMethod.Wait(1);
                SetupWizard.SelectStyleElement(descriptionName[i]);
                CommonMethod.Wait(1);
                SetupWizard.ClickSaveButton();
                CommonMethod.Wait(1);
            }
        }

        private void CreateNewDistributor()
        {
            Distributor.ClickAddDistributorButton();
            Distributor.ClickPostFrameButton();
            Distributor.EnterDistributorName("Copy KD Distributor");
            Distributor.SelectSourceDistributor("AUTOTEST_PHTEST");
            Distributor.ClickCreateButton();
            HomePage.ClicksHomeButton();
            HomePage.ClicksStartFromScratch();
            CaptureScreenshotOfWalkdoorIconsAutotest();
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("Copy KD Distributor");
            string verifyDistributor = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='w2ui-marker']"))).Text;
            Assert.That(verifyDistributor, Is.EqualTo("Copy KD Distributor"));
            ExtentTestManager.TestSteps("Verify that the copy distributor is created");
            Console.WriteLine("Verify that the copy distributor is created");
            CommonMethod.ChangeDistributor("Copy KD Distributor");
        }

        private void VerifyDataInTheSetupWizard()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            VerifyStyleInSetupWizard("SolidDoor", "Solid");
            VerifyStyleInSetupWizard("PanelDoor", "Panel");
            VerifyStyleInSetupWizard("CommercialDoor", "Commercial");
            VerifyStyleInSetupWizard("PatioDoor", "Patio");
            VerifyStyleInSetupWizard("OtherDoor", "Other");
            Console.WriteLine("Verify that the AUTOTEST_PHTEST Distributor and Copy KD Distributor styles are the same");
            ExtentTestManager.TestSteps("Verify that the AUTOTEST_PHTEST Distributor and Copy KD Distributor styles are the same");
            SetupWizard.DownloadTheExcelFile();
        }

        private void VerifyDataInTheDefaultJob()
        {
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomePageURL"));
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.OpeningDoorsSelection("WalkDoor");
            CaptureScreenshotOfWalkdoorIconsCopy();
            HomePage.PerformImageComparison(screenshotOfIcon, screenshotOfIcon, "Verify that the Solid icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "Verify that the Solid icon are not same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "SolidAutotest.png", "SolidCopy.png");
            HomePage.PerformImageComparison(screenshotOfIcon, screenshotOfIcon, "Verify that the Panel icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "Verify that the Panel icon are not same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "PanelAutotest.png", "PanelCopy.png");
            HomePage.PerformImageComparison(screenshotOfIcon, screenshotOfIcon, "Verify that the Commercial icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "Verify that the Commercial icon are not same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "CommercialAutotest.png", "CommercialCopy.png");
            HomePage.PerformImageComparison(screenshotOfIcon, screenshotOfIcon, "Verify that the Patio icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "Verify that the Patio icon are not same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "PatioAutotest.png", "PatioCopy.png");
            HomePage.PerformImageComparison(screenshotOfIcon, screenshotOfIcon, "Verify that the Other icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "Verify that the Other icon are not same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor", "OtherAutotest.png", "OtherCopy.png");
            Console.WriteLine("Verify that the Walkdoor style icon are same on the AUTOTEST_PHTEST Distributor and Copy KD Distributor");
        }

        private void VerifyStyleInSetupWizard(string nameOfElement, string checkStyle)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(xpath, nameOfElement))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            string styleName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[text()='Style:'])[1]//following :: div[@id='undefined'][1]"))).Text;
            Assert.That(styleName, Is.EqualTo(checkStyle));
        }
    }
}
#endregion