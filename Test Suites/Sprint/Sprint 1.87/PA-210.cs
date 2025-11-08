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
    public class SKUBuilder : BaseClass
    {

        [Test]
        public void StopRounding()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Stop Rounding {LF} in SKU builder");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            CheckOldDataDeleted();
            FilledTheDataOfTrimTable();
            HomePage.ClicksStartFromScratch();
            VerifyTheRidgeCapLength();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            DeleteDataFromTrimTable();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Stop Rounding {LF} in SKU builder");
        }

        #region Private Method
        private void DeleteDataFromTrimTable()
        {
            SetupWizard.DeleteSetupWizardData("Ridge Cap Test 56");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void CheckOldDataDeleted()
        {
            SetupWizard.DeleteSetupWizardData("Ridge Cap Test 56");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickTrim();
            }
        }

        private void FilledTheDataOfTrimTable()
        {
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("KDRC");
            SetupWizard.EnterDescriptionInputField("Ridge Cap Test 56");
            SetupWizard.EnterWidthInputField("5");
            SetupWizard.EnterHeightInputField("6");
            SetupWizard.AddUsageElement("Ridge Cap - Roof Trim");
            SetupWizard.EnterPricingDetails("5", "6");
           
            for (int i = 1; i <= 5; i++)
            {
                SetupWizard.ClickAddButtonOfPricingTable();
            }

            string[] createRow = new string[6] { "7", "13", "19", "25", "31", "37" };
            string[] enterData = new string[6] { "11", "11.55", "12", "12.33", "13", "13.99" };

            for (int j = 0; j < createRow.Length; j++)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.partLengthXPath, createRow[j]))));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys(enterData[j]).Perform();
                CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            }

            ExtentTestManager.TestSteps("Enter the cost in the pricings table");

            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void VerifyTheRidgeCapLength()
        {
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofTrim();
            DefaultJobElement.SelectRidgeCap("Ridge Cap Test 56");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();

            VerifySKU("KDRC11", "11");
            VerifySKU("KDRC11", "11.55");
            VerifySKU("KDRC12", "12");
            VerifySKU("KDRC12", "12.33");
            VerifySKU("KDRC13", "13");
            VerifySKU("KDRC13", "13.99");
            ExtentTestManager.TestSteps("Verify that any decimal value you enter in the Ridge Cap Length Overrides field is rounded down instead of up");
            Console.WriteLine("Verify that any decimal value you enter in the Ridge Cap Length Overrides field is rounded down instead of up");
            DefaultJobElement.NavigateToHomePage();
        }

        private void VerifySKU(string valueOfRidgeCap, string decimalValue)
        {
            DefaultJobElement.EnterRidgeCapLengthOverrides(decimalValue);          
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "RidgeCap", valueOfRidgeCap, null, null, null, null, null, null, null, null);
        }
    }
}
#endregion