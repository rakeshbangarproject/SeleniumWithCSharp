using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class FramingMaterial : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-204");

        [Test]
        public void CreateMaterial()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Framing materials are not creating from Setting > materials");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.NavigateToTheMaterialsPage();
            CreateNewDoors();
            VerifyFramingProfile();
            SaveButtonOnMaterialPage();
            SetupWizardPage();
            VerifyNewMaterialShownInTheDefaultJob();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Framing materials are not creating from Setting > materials Script");
        }

        #region Private Method

        private void VerifyNewMaterialShownInTheDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierMaterial("TestingMaterialPage");
            ExtentTestManager.TestSteps("Verify that newly create Framing material shown in the Truss Carrier Material");
            Console.WriteLine("Verify that newly create Framing material shown in the Truss Carrier Material");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("TestingMaterialPage");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void SetupWizardPage()
        {
            SetupWizard.ClickFraming();
            SetupWizard.ClickHomeIconButton();
            CommonMethod.GetActions().MoveToElement(SetupWizard.SearchElementInTheTable()).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys("TestFramingField" + Keys.Enter).Perform();
            CommonMethod.Wait(2);
            SetupWizard.ClickShownAndHideButton();
            SetupWizard.CheckTheCheckBoxFromHideAndShownFrame("TrussCarrierMaterial");
            CommonMethod.GetActions().MoveToElement(SetupWizard.SaveAllButton()).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.checkFirstColumnOfCheckbox))).Click();
            ExtentTestManager.TestSteps("Click on the the Truss Carrier checkbox");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void CreateNewDoors()
        {
            Materials.DeleteMaterialFromTable("TestingMaterialPage");
            Materials.ClickAddButton();
            Materials.EnterSKU("TestFramingField");
            Materials.EnterSupplierId("4");
            Materials.EnterSupplierSKU("5");
            Materials.EnterDescription("TestingMaterialPage");
            Materials.EnterDimension1("2");
            Materials.EnterDimension2("24");
        }

        private void VerifyFramingProfile()
        {
            Materials.SelectFramingColor("RedIron");
            FramingProfile("Cee", "Cee Framingprofile");
            FramingProfile("DimensionLumber", "DimensionLumber Framingprofile");
            FramingProfile("Zee", "Zee Framingprofile");
            FramingProfile("ZeeRotated", "ZeeRotated Framingprofile");
            FramingProfile("IBeam", "IBeam Framingprofile");
            FramingProfile("BackToBackCee", "BackToBackCee Framingprofile");
            FramingProfile("AngleBracket", "AngleBracket Framingprofile");
            FramingProfile("AngleBracketRotated", "AngleBracketRotated Framingprofile");
            FramingProfile("ReceiverChannel", "ReceiverChannel Framingprofile");
            FramingProfile("BarJoist", "BarJoist Framingprofile");
        }

        private void SaveButtonOnMaterialPage()
        {
            Materials.ClickSaveButton();
            bool materialList = Materials.ClickElementFromMaterialTable("TestingMaterialPage");

            if (materialList)
            {
                Console.WriteLine("Newly create framing material is shown in the Material Page table");
                ExtentTestManager.TestSteps("Newly create framing material is shown in the Material Page table");
            }
            else
            {
                Assert.Fail("Newly create framing material is not shown in the Material Page table");
            }

            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("SetupWizardPageURL"));
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Navigate to Setup Wizard Page");
        }

        private void FramingProfile(string value, string imageName)
        {
            Materials.SelectFramingProfile(value);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
            CommonMethod.GetActions().ClickAndHold(CommonMethod.element).MoveByOffset(0, 100).Release().Perform();
            DefaultJobElement.CaptureScreenShot($"{pathFile}", $"{imageName}.png");
        }
    }
}
#endregion