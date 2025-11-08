using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Roofing_Passport")]
    public class HotPatchRoofingPassport : BaseClass
    {
        /// <summary>
        ///  1. Login to AUTOTEST_EAGLEVIEW Distributor.
        ///  2. Navigate to Setup Wizard and add data in the System and Cladding Field.
        ///  3. Open Any job and apply the New system for Roof Cladding
        ///  4. Verify that the Roof Cladding is selected as the first available option.
        /// </summary>

        [Test, Order(1)]
        public void WallSheathingRF()
        {
            ExtentTestManager.CreateTest("HOT PATCH - Wall Sheathing set to None is being reset");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            EnterDataInTheSetupWizardData();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Job3");
            CommonMethod.PageLoader();
            DefaultJobElement.SelectRoofSystemDropdownOfRoofingPassport("RoofCladdingMaterial");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            VerifyCladdingData();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            ExtentTestManager.CreateTest("Delete Setup Wizard Data");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickCladding();
            SetupWizard.DeleteSetupWizardData("CladdingMaterialTestData1");
            SetupWizard.SaveDataInTheSetupWizard();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of RPS Metal Roofing Systems Contractor database");
        }

        #region Private Method
        private void EnterDataInTheSetupWizardData()
        {
            // Add Data System and Cladding table
            HomePage.NavigateToSetupWizardPages();      
            SetupWizard.ClickCladding();
            SetupWizard.DeleteSetupWizardData("CladdingMaterialTestData1");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickCladding();
            }

            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("CladdingMaterialTestData1");
            SetupWizard.EnterDescriptionInputField("CladdingMaterialTestData1");
            SetupWizard.EnterCoverageWidthInputField("1");
            SetupWizard.EnterFullWidthInputField("1");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterMaximumLengthInputField("40");
            SetupWizard.EnterUnderlapLengthInputField("1");
            SetupWizard.AddSystemTableElement("RoofCladdingMaterial");
            SetupWizard.AddUsageElement("Roof Cladding");
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void VerifyCladdingData()
        {
            string firstElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(text(),'Roof Cladding')])[1]//following :: div[2]"))).GetAttribute("title");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@class='arrow-down'])[2]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(2)).Perform();
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", CommonMethod.element);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[contains(@id,'w2ui-overlay')]//following :: tr[1])[1]//div[1]")));
            string roofCladdingData = CommonMethod.element.Text;
            Assert.True(roofCladdingData == firstElement);
            ExtentTestManager.TestSteps("Verify that the Roof Cladding is selected as the first available option.");
        }
    }
}
#endregion