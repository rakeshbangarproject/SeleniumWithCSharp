using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class HeaderHighBarJoist : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-178");

        [Test, Order(1)]
        public void HeaderHighCheckbox()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Trachte - Header High Bar Joist");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            AddDataToFramingTableAndVerify();
            VerifyHeaderHighFunctionality();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Data");
            DeleteFramingTableData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Trachte - Header High Bar Joist Script");
        }

        #region Private Method
        private void AddDataToFramingTableAndVerify()
        {
            HomePage.NavigateToSetupWizardPages();
            DeleteOldEntriesIfNeeded();
            SetupWizard.ClickAddButton();

            // Entering data for framing table
            SetupWizard.EnterSKUInputField("Wood ` Trading` 0 ` 2X0-4 Test");
            SetupWizard.EnterDescriptionInputField("Wood ` material ` Trading` 0 ` 2X0-4 Test");
            SetupWizard.EnterWidthInputField("2");
            SetupWizard.EnterDepthInputField("6");
            SetupWizard.AddUsageElement("Header High Material - Overhead Door Post Framing");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void VerifyHeaderHighFunctionality()
        {
            // Open default job and placing elements on canvas
            HomePage.ClicksStartFromScratch();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(150, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();

            // Verifying the placement of overhead door on canvas
            VerifyThatOverheadDoorPlaceOnTheCanvasBuilding(initialValue, currentValue);

            // Performing actions related to Header High Material
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("drawingArea")));
            CommonMethod.GetActions().ClickAndHold(CommonMethod.element).MoveByOffset(-150, 0).Release().Perform();
            DefaultJobElement.ClickAndHold(150);
            DefaultJobElement.ClicksShellButton();
            CaptureScreenshot("BeforeApplyHeaderHighMaterial.png");

            // Applying Header High Material and verifying in dropdown
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDoorAndWindow();
            DefaultJobElement.ClickOverheadDoorPostFraming();

            DefaultJobElement.CheckHeaderHighCheckbox();
            DefaultJobElement.SelectHeaderHighMaterial("Wood ` material ` Trading` 0 ` 2X0-4 Test");
            Console.WriteLine("Verify that the Newly created Framing Material is shown in the Header High Material Dropdown");

            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CaptureScreenshot("AfterApplyHeaderHighMaterial.png");

            // Applying Top Girt Material and verifying in dropdown
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            DefaultJobElement.SelectTopGirtMaterial("4x12 I-Beam");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            Console.WriteLine("Apply Top Girt Material to the Canvas building");
            CaptureScreenshot("ApplyTrussCarrierMaterial.png");

            // Verifying the added materials in the drawing table
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TopGirt", "4x12 I-Beam", null, null, null);
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TrussBearer", "Wood ` Trading` 0 ` 2X0-4 Test", null, null, null);
            Console.WriteLine("Verify that the Top girt materials are added");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            ExtentTestManager.TestSteps("Verify that the Top girt materials are added");
            CaptureScreenshot("MaterialList.png");
        }

        private void DeleteOldEntriesIfNeeded()
        {
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("Wood ` material ` Trading` 0 ` 2X0-4 Test");
            CommonMethod.Wait(2);
            CommonMethod.element = Driver.FindElement(By.XPath(Locator.SetupWizard.SaveAllButton));

            if (CommonMethod.element.Enabled)
            {
                // Save data, set up wizard again, and navigate to the framing tab if required
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickFraming();
            }
        }

        private void DeleteFramingTableData()
        {
            // Set up wizard, navigate to the framing tab, and delete specific table data
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("Wood ` material ` Trading` 0 ` 2X0-4 Test");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void CaptureScreenshot(string imageName)
        {
            DefaultJobElement.CaptureScreenShot($@"{pathFile}", $"{imageName}");
        }

        private void VerifyThatOverheadDoorPlaceOnTheCanvasBuilding(string initialValue, string currentValue)
        {
            // Verify if the overhead door is placed on the canvas building
            if (initialValue.Equals(currentValue))
            {
                Console.WriteLine("Error: The Overhead Door is not placed on the canvas building");
                ExtentTestManager.TestSteps("Error: The Overhead Door is not placed on the canvas building");
                Assert.Fail("Error: The Overhead Door is not placed on the canvas building");
            }
            else
            {
                Console.WriteLine("Verify that the Overhead Door is placed on the canvas building");
                ExtentTestManager.TestSteps("Verify that the Overhead Door is placed on the canvas building");
            }
        }
    }
}
#endregion