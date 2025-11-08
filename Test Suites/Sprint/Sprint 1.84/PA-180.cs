using DocumentFormat.OpenXml.Wordprocessing;
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
    public class ReloadedFunctionality : BaseClass
    {
        /// <summary>
        ///  1. Login to AUTOTEST_PHTEST Distributor.
        ///  2. Navigate to Setup Wizard and add data in the system table for all product system.
        ///  3. Navigate to Framing Rules page and Click on the Do edit Question Button and get the order of all product system.
        ///  4. Again Navigate to Setup Wizard and edit the framing data.
        ///  5. Verify that product system data order are changes or not in the framing Rules.
        /// </summary>

        [Test]
        public void FramingFunctionalityCheck()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Re-orders the Product Systems List");
            HomePage.NavigateToFramingRulesPages();
            AddDataInSetupWizard();
            VerifyDataInTheFramingRules();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Re-orders the Product Systems List Script");
        }

        #region Private Method
        /// <summary>
        /// Navigate to the setup wizard, add data in the system table for the Main product system and roof product system,
        /// and save data in the setup wizard.
        /// </summary>
        private void AddDataInSetupWizard()
        {
            try
            {
                // Open a new tab and navigate to the Setup Wizard
                Driver.SwitchTo().NewWindow(WindowType.Tab);
                Driver.Navigate().GoToUrl(TestContext.Parameters.Get("SetupWizardPageURL"));
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                ExtentTestManager.TestSteps("Open new tab and navigate to Setup Wizard");

                // Navigate to the Systems tab and add data
                DeleteDateOfSetupWizard();
                AddMainProductSystemData();
                AddRoofProductSystemData();

                // Save data in the Setup Wizard
                SetupWizard.SaveDataInTheSetupWizard();
                // Switch back to the original window
                Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, report, etc.)
                ExtentTestManager.TestSteps($"An error occurred: {ex.Message}");
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Navigate to the framing rules page, make changes in the setup wizard, and verify that the order of the main 
        /// and roof product systems in the framing rules is not changed.
        /// </summary>
        private void VerifyDataInTheFramingRules()
        {
            ExtentTestManager.TestSteps("Open Framing Rule page tab");
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();

            string mainProductDataBeforeChanges = FramingRules.ClickDoEditButtonOfProductSystemAndGetTheData("Main Product System", "before");
            string roofProductDataBeforeChanges = FramingRules.ClickDoEditButtonOfProductSystemAndGetTheData("Roof Product System", "before");

            SwitchToSecondWindowAndMakeChanges();
            RefreshAndAcceptAlert();

            string mainProductDataAfterChanges = FramingRules.ClickDoEditButtonOfProductSystemAndGetTheData("Main Product System", "after");
            Assert.AreEqual(mainProductDataBeforeChanges, mainProductDataAfterChanges);
            ExtentTestManager.TestSteps("Verify that the main product system list doesn’t reorder in the framing rule after applying any change in the setup wizard.");

            string roofProductDataAfterChanges = FramingRules.ClickDoEditButtonOfProductSystemAndGetTheData("Roof Product System", "after");
            Assert.AreEqual(roofProductDataBeforeChanges, roofProductDataAfterChanges);
            ExtentTestManager.TestSteps("Get the Roof product data after the setup wizard changes");
            ExtentTestManager.TestSteps("Verify that the Roof product system list doesn’t reorder in the framing rule after applying any change in the setup wizard.");

            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("SetupWizardPageURL"));
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Open new tab and navigate to Setup Wizard");
            DeleteDataFromTheSystemTable();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void SwitchToSecondWindowAndMakeChanges()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            ChangesInTheSetupWizard();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        private bool RefreshAndAcceptAlert()
        {
            Driver.Navigate().Refresh();
            try
            {
                Driver.SwitchTo().Alert().Accept();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
                ExtentTestManager.TestSteps("Navigate to Framing Rules");
                CommonMethod.Wait(4);
                return true;
            }
            catch(NoAlertPresentException)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
                ExtentTestManager.TestSteps("Navigate to Framing Rules");
                CommonMethod.Wait(4);
                return false;
            }
        }

        private void DeleteDateOfSetupWizard()
        {
            DeleteDataFromTheSystemTable();

            CommonMethod.element = Driver.FindElement(By.XPath(Locator.SetupWizard.SaveAllButton));
            if (CommonMethod.element.Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSystems();
            }
        }

        private static void DeleteDataFromTheSystemTable()
        {
            // Delete data from the System table
            SetupWizard.ClickSystems();
            string[] delete = new string[6] { "Roof Product System-1", "Roof Product System-2", "Roof Product System-3", "Main Product-1", "Main Product-2", "Main Product-3" };

            for (int i = 0; i < delete.Length; i++)
            {
                SetupWizard.DeleteSetupWizardData(delete[i]);
            }
        }

        /// <summary>
        /// Navigate to the setup wizard and delete and restore data from the system table.
        /// Check in the framing rules page if the product system order is not changed.
        /// </summary>
        private void ChangesInTheSetupWizard()
        {
            try
            {
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSystems();

                // Delete and Restore Material
                DeleteMaterial();
                RestoreMaterial();

                SetupWizard.SaveDataInTheSetupWizard();
            }
            catch (Exception ex)
            {
                ExtentTestManager.TestSteps($"An error occurred during changes in the Setup Wizard: {ex.Message}");
                throw;
            }
        }

        private void DeleteMaterial()
        {
            CommonMethod.GetActions().MoveToElement(SetupWizard.FirstRowElementOfTable()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the first material of table");
            SetupWizard.ClickDeleteButtonAndYesButton();
        }

        private void RestoreMaterial()
        {
            // Restore the selected material
            CommonMethod.GetActions().MoveToElement(SetupWizard.FirstRowElementOfTable()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the first material of table");
            SetupWizard.ClickRestoreButton();
        }

        /// <summary>
        /// Add Data in system table for the Roof Product System.
        /// </summary>
        private void AddRoofProductSystemData()
        {
            string[] descriptionRoof = new string[3] { "Roof Product System-1", "Roof Product System-2", "Roof Product System-3", };
            for (int j = 0; j < descriptionRoof.Length; j++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.RemoveElementFromUsageTable("Main Product System - Product Systems");
                SetupWizard.EnterDescriptionInputField(descriptionRoof[j]);
                SetupWizard.KeysInputField(descriptionRoof[j]);
                SetupWizard.AddUsageElement("Roof Product System - Product Systems");
                SetupWizard.ClickSaveButton();
            }
            ExtentTestManager.TestSteps("Add Data in Roof Product System.");
            CommonMethod.Wait(2);
        }

        /// <summary>
        ///  Add Data in system table for the Main Product System.
        /// </summary>
        private void AddMainProductSystemData()
        {
            string[] descriptionMain = new string[3] { "Main Product-1", " Main Product-2", " Main Product-3", };
            for (int i = 0; i < descriptionMain.Length; i++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterDescriptionInputField(descriptionMain[i]);
                SetupWizard.KeysInputField(descriptionMain[i]);
                SetupWizard.ClickSaveButton();
            }
            ExtentTestManager.TestSteps("Add Data in Main Product System.");
        }
    }
}
#endregion