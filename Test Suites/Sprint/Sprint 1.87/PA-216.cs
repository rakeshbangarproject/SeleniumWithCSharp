using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class DeleteMaterials : BaseClass
    {

        [Test]
        public void SheathingAssemblies()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("If delete material from assembly then warn user");
            HomePage.NavigateToSetupWizardPages();
            DeleOldDataFromSetupWizard();
            EnterDataInTheSheathingTable();
            EnterDataInTheFastenersTable();
            EnterDataInTheSheathingAssembliesTable();
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofSheathing();
            DefaultJobElement.SelectRoofMaterial("Test SheathingAssemblies0673+");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickAccessoriesOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Accessories", "-Fastener", "KDMaterialFastener", null, null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps("Verify That The Sheathing Assemblies Data Is Shown In The Accessories Table Of Job Review");
            Console.WriteLine("Verify That The Sheathing Assemblies Data Is Shown In The Accessories Table Of Job Review");
            NavigateToSetupWizardPage();
            VerifyDataInTheSetupWizardPage();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("If delete material from assembly then warn user");
        }

        #region private Method
        private void EnterDataInTheSheathingTable()
        {
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("KDTest456");
            SetupWizard.EnterDescriptionInputField("TestMaterialKD");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("36");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.SelectColorMap("Brick Texture");
            SetupWizard.SelectBumpMap("Brick");
            SetupWizard.AddUsageElement("Roof Material");
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickColorButtonOfPricingTable();
            SetupWizard.ClickSaveButton();
        }

        private void EnterDataInTheFastenersTable()
        {
            SetupWizard.ClickFasteners();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("KDMaterialFastener");
            SetupWizard.EnterDescriptionInputField("TestKD");
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickColorButtonOfPricingTable();
            SetupWizard.ClickSaveButton();
        }

        private void DeleOldDataFromSetupWizard()
        {
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("TestKD");
            SetupWizard.ClickSheathingAssemblies();
            SetupWizard.DeleteSetupWizardData("Test SheathingAssemblies0673");
            SetupWizard.ClickSheathing();
            SetupWizard.DeleteSetupWizardData("TestMaterialKD");
            SetupWizard.DeleteSetupWizardData("KDTest666{CC}");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSheathing();
                ExtentTestManager.TestSteps("Delete old data from setup wizard");
            }
        }

        private void EnterDataInTheSheathingAssembliesTable()
        {
            SetupWizard.ClickSheathingAssemblies();
            SetupWizard.ClickAddButton();
            SetupWizard.NameInputField("Test SheathingAssemblies0673");
            SetupWizard.SelectPrimaryMaterial("TestMaterialKD");
            SetupWizard.ClickAddNewButtonOfAssemblies();
            SetupWizard.SelectTypeOfAssemblies("Fastener");
            SetupWizard.SelectOutputCategoryOfAssemblies("Accessories");
            SetupWizard.SelectMaterialFromSheathingAssemblies("Fastener", "TestKD");
            SetupWizard.EnterHowManyInputField("2");
            SetupWizard.ClickSaveButton();
            CommonMethod.Wait(2);
            SetupWizard.ClickSaveButton();
        }

        private void NavigateToSetupWizardPage()
        {
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("SetupWizardPageURL"));
            Alert();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForTHeSubMenuVisible)));
            ExtentTestManager.TestSteps("Navigate to the Setup Wizard page");
        }

        private bool Alert()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }


        private void VerifyDataInTheSetupWizardPage()
        {
            SetupWizard.ClickSheathing();
            ExtentTestManager.TestSteps("Click on Sheathing Tab");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='KDTest456{CC}']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(2)).Perform();
            SetupWizard.EnterSKUInputField("KDTest666");
            Console.WriteLine("Changed the SKU name of Sheathing material");
            ExtentTestManager.TestSteps("Changed the SKU name of Sheathing material");
            SetupWizard.ClickSaveButton();
            SetupWizard.ClickSheathingAssemblies();
            string elementIsNonhighlighted = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='Test SheathingAssemblies0673']"))).GetAttribute("style");
            Assert.True(elementIsNonhighlighted.Equals("color: black; font-weight: bold;"));
            Console.WriteLine("Verify That The Existing Material Data Of Sheathing Assemblies Is Not Shown In The Red Color.");
            ExtentTestManager.TestSteps("Verify That The Existing Material Data Of Sheathing Assemblies Is Not Shown In The Red Color.");
            SetupWizard.ClickSheathing();
            SetupWizard.DeleteSetupWizardData("TestMaterialKD");
            Console.WriteLine("Click on the Sheathing tab and Delete the existing material from the Sheathing table");
            SetupWizard.ClickSheathingAssemblies();
            string elementIsHighlighted = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='Test SheathingAssemblies0673']"))).GetAttribute("style");
            Assert.True(elementIsHighlighted.Equals("color: red;"));
            Console.WriteLine("Verify That The Existing Material Data of Sheathing Assemblies Is Highlighted In The Red Color.");
            ExtentTestManager.TestSteps("Verify That The Existing Material Data of Sheathing Assemblies Is Highlighted In The Red Color.");
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("TestKD");
            SetupWizard.ClickSheathingAssemblies();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[normalize-space()='Test SheathingAssemblies0673']"))).Click();
            string entries = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_entriesList_records']//following::tr[@id='grid_entriesList_rec_0'][1]"))).GetAttribute("style");
            Assert.True(entries.Equals("height: 24px; color: red;"));
            SetupWizard.DeleteSetupWizardData("Test SheathingAssemblies0673");
            SetupWizard.SaveDataInTheSetupWizard();
        }
    }
}
#endregion