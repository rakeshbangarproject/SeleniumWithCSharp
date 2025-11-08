using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    class AssemblyCrashes : BaseClass
    {
        /// <summary>
        /// This test case performs the following steps:
        /// 1. Navigates to the Setup Wizard, clicks on Sheathing Assemblies, and adds new material data.
        /// 2. Navigates to the Home page and clicks on Start From Scratch.
        /// 3. Clicks on the details tab.
        /// 4. Clicks on the Wall sheathing tab.
        /// 5. Verifies that the newly added Sheathing Assemblies data is present in both the Wall Material and Wainscot dropdowns.
        /// 6. Navigates back to the Setup Wizard and deletes the newly added data from the Sheathing Assemblies table.
        /// </summary>

        [Test]
        public void SheathingAssemblies()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Primary Material for an Assembly crashes the system");
            HomePage.NavigateToSetupWizardPages();
            CreateSingleAndDoubleQuotationMaterials();
            ConfigureWallSheathingAndWainscotMaterials();

            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickSheathingAssemblies();
            DeleteEntries();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Assembly crashes the system Script");
        }

        #region private Methods
        /// <summary>
        /// Open default job and verify that the single and quotation shown in the dropdown.
        /// </summary>
        public void ConfigureWallSheathingAndWainscotMaterials()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallSheathing();
            CheckSingleAndDoubleQuotationMaterial();
        }

        /// <summary>
        /// Search single and double quotation materials in the wall and wainscot sheathing dropdown
        /// </summary>
        private void CheckSingleAndDoubleQuotationMaterial()
        {
            string[] quotationName = new string[] { "TestBrick_bmp 2'x5'+", "2\"x5\"Wood LightTest+" };

            for (int index = 0; index < quotationName.Length; index++)
            {
                DefaultJobElement.SelectWainscotElement(quotationName[index]);
                DefaultJobElement.SelectWallMaterialElement(quotationName[index]);
                DefaultJobElement.ClickSyncButton();
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            }
        }

        private void DeleteEntries()
        {
            string[] primaryMaterialList = { "TestBrick_bmp 2'x5'", "2\"x5\"Wood LightTest" };
            for (int sku = 0; sku < primaryMaterialList.Length; sku++)
            {
                SetupWizard.DeleteSetupWizardData(primaryMaterialList[sku]);
            }
        }

        private void CreateSingleAndDoubleQuotationMaterials()
        {
            // Navigate to the "Sheathing Assemblies" tab in the setup wizard
            SetupWizard.ClickSheathingAssemblies();
            DeleteEntries();

            CommonMethod.element = Driver.FindElement(By.XPath(Locator.SetupWizard.SaveAllButton));
            if (CommonMethod.element.Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSheathingAssemblies();
            }

            // Data to be entered
            string[] report = new string[] { "'", "\"" };
            string[] skuList = { "TestBrick_bmp 2'x5'", "2\"x5\"Wood LightTest" };
            string[] primaryList = { "2'x5'TestDataMaterial", "2\"x5\"TestData" };

            // Iterate through SKUs and Primary Materials
            for (int i = 0; i < skuList.Length; i++)
            {
                try
                {
                    SetupWizard.ClickAddButton();
                    SetupWizard.NameInputField(skuList[i]);
                    SetupWizard.SelectPrimaryMaterial(primaryList[i]);
                    SetupWizard.SelectAllElementFromUsageTable();
                    CommonMethod.Wait(1);
                    SetupWizard.ClickSaveButton();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Verify the system doesn't crash after adding SKU with '{report[i]}'" + ex.Message);
                    string errorMessage = Driver.FindElement(By.XPath(Locator.SetupWizard.getTheErrorMessagePath)).Text;
                    ExtentTestManager.TestSteps(errorMessage);
                    Assert.Fail($"Error: The system is crash after adding SKU with '{report[i]}'" + ex.Message);
                }

                ExtentTestManager.TestSteps($"Verify the system doesn't crash after adding SKU with '{report[i]}'");
            }

            SetupWizard.SaveDataInTheSetupWizard();
        }
    }
}
#endregion