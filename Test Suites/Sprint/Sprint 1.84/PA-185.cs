using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._84
{
    [TestFixture, Category("Sprint_1_.84")]
    public class ProductSystemNoneElement : BaseClass
    {
        [Test, Order(1)]
        public void SwitchingProductSystem()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("switching Product Systems");
            AddDataToSystemTable();
            AddDataToTrimTable();
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickProductSystem();
            VerifyDropdownElement();
        }

        [Test, Order(2)]
        public void DeleteOldDataFromSetupWizard()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete data");
            DeleteSetupWizardData();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        [OneTimeTearDown]
        public void CloseExtentReport()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of switching Product Systems Script");
        }

        #region Private Methods

        private void AddDataToSystemTable()
        {
            DeleteTrimData();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterDescriptionInputField("RoofTest1");
            SetupWizard.KeysInputField("RoofTest1");
            SetupWizard.RemoveElementFromUsageTable("Main Product System - Product Systems");
            SetupWizard.AddUsageElement("Roof Product System - Product Systems");
            SetupWizard.ClickSaveButton();
        }

        private void AddDataToTrimTable()
        {
            SetupWizard.ClickTrim();

            string[] skuNames = { "TrimRidgeCap1", "TrimRidgeCap2", "TrimRidgeCap3" };
            foreach (var skuName in skuNames)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterDescriptionInputField(skuName);
                SetupWizard.EnterWidthInputField("1");
                SetupWizard.EnterHeightInputField("1");
                SetupWizard.AddSystemTableElement("RoofTest1");
                SetupWizard.AddUsageElement("Ridge Cap");
                SetupWizard.ClickSaveButton();
            }

            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void DeleteTrimData()
        {
            DeleteSetupWizardData();

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSystems();
            }

            ExtentTestManager.TestSteps("Delete data from setup wizard");
        }

        private static void DeleteSetupWizardData()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("TrimRidgeCap1");
            SetupWizard.DeleteSetupWizardData("TrimRidgeCap2");
            SetupWizard.DeleteSetupWizardData("TrimRidgeCap3");
            SetupWizard.ClickSystems();
            SetupWizard.DeleteSetupWizardData("RoofTest1");
        }

        private void VerifyDropdownElement()
        {
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectRoofProductSystem("RoofTest1");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofTrim();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string ridgeCapElement = DefaultJobElement.GetTheRidgeCapValue();
            DefaultJobElement.ClickRidgeCap();
            string ridgeCapFirstDropdownElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.getTheElementFromDropdown, 0)))).Text;

            Assert.That(ridgeCapElement, Is.EqualTo(ridgeCapFirstDropdownElement));
            ExtentTestManager.TestSteps("Verify that the Ridge cap is selected as the first available option.");
            Console.WriteLine("Verify that the Ridge cap is selected as the first available option.");
        }

        #endregion
    }
}