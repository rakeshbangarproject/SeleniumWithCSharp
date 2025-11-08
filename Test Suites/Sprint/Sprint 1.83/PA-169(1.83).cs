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
    public class ProductSystemError : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-169");

        private const int ArraySize = 2;

        [Test, Order(1)]
        public void RoofProductSystem()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Product System Error");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.NavigateToSetupWizardPages();
            DeleteDataFromTable();
            SaveDataAndAgainNavigateToSetupWizardPage();

            CreateRoofProductSystemData();
            CreateColorDataForRoofProductSystems();
            CreateSheathingData();
            VerifySetupWizardMaterialInTheDefaultJob();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Data");
            HomePage.NavigateToSetupWizardPages();
            DeleteDataFromTable();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Set Interior Wall Side as a None Script");
        }

        #region Private Method
        /// <summary>
        /// Creates data for Roof Product Systems in the Setup Wizard.
        /// </summary>
        private void CreateRoofProductSystemData()
        {
            string[] descriptions = new string[ArraySize] { "TestRoof System R-1", "TestRoof System R-2" };

            for (int i = 0; i < ArraySize; i++)
            {
                SetupWizard.ClickAddButton();
                CommonMethod.Wait(2);
                SetupWizard.RemoveElementFromUsageTable("Main Product System - Product Systems");
                SetupWizard.AddUsageElement("Roof Product System - Product Systems");
                SetupWizard.EnterDescriptionInputField(descriptions[i]);
                SetupWizard.KeysInputField(descriptions[i]);
                SetupWizard.ClickSaveButton();
                CommonMethod.Wait(2);
            }
        }

        /// <summary>
        /// Creates color data for Roof Product Systems in the Setup Wizard.
        /// </summary>
        public void CreateColorDataForRoofProductSystems()
        {
            SetupWizard.ClickColors();

            string[] colorMaps = new string[ArraySize] { "Brick Texture", "Lap Siding Texture" };
            string[] bumpMaps = new string[ArraySize] { "Brick", "Lap Siding Panel" };
            string[] searchSystems = new string[ArraySize] { "TestRoof System R-1", "TestRoof System R-2" };
            string[] colorNames = new string[ArraySize] { "TestRoof Color R-1", "TestRoof Color R-2" };

            for (int j = 0; j < ArraySize; j++)
            {
                // Generate a random number
                Random randomGenerator = new Random();
                int randomInt = randomGenerator.Next(1000);

                // Perform some actions using values from arrays
                SetupWizard.ClickAddButton();
                SetupWizard.ColorNameInputField(colorNames[j]);
                SetupWizard.SelectHexCode("FF9838");
                SetupWizard.CodeTransparencyInputField("0");
                SetupWizard.ColorCodeInputField("#" + randomInt);
                SetupWizard.SelectColorMap(colorMaps[j]);
                SetupWizard.SelectBumpMap(bumpMaps[j]);
                SetupWizard.AddSystemTableElement(searchSystems[j]);
                SetupWizard.ClickSaveButton();
            }
        }

        /// <summary>
        /// Creates sheathing data in the Setup Wizard.
        /// </summary>
        public void CreateSheathingData()
        {
            SetupWizard.ClickSheathing();

            string[] colorMaps = new string[ArraySize] { "Brick Texture", "Lap Siding Texture" };
            string[] bumpMaps = new string[ArraySize] { "Brick", "Lap Siding Panel" };
            string[] searchSystems = new string[ArraySize] { "TestRoof System R-1", "TestRoof System R-2" };
            string[] usages = new string[ArraySize] { "Roof Material", "Roof Material" };
            string[] skuNames = new string[ArraySize] { "TestRoof Sheathing R-1", "TestRoof Sheathing R-2" };

            for (int p = 0; p < ArraySize; p++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterSKUInputField(skuNames[p]);
                SetupWizard.EnterDescriptionInputField(skuNames[p]);
                SetupWizard.EnterCoverageWidthInputField("36");
                SetupWizard.EnterFullWidthInputField("37");
                SetupWizard.EnterThicknessInputField("0.25");
                SetupWizard.SelectColorMap(colorMaps[p]);
                SetupWizard.SelectBumpMap(bumpMaps[p]);
                SetupWizard.AddSystemTableElement(searchSystems[p]);
                SetupWizard.AddUsageElement(usages[p]);
                SetupWizard.EnterPricingDetails("3", "4");
                SetupWizard.ClickSaveButton();
            }
            SetupWizard.SaveDataInTheSetupWizard();
        }

        public void VerifySetupWizardMaterialInTheDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            VerifyRoofProductSystem();
        }

        private void DeleteDataFromTable()
        {
            DeleteSheathingData();
            DeleteColorData();
            DeleteSystemData();
        }

        private static void SaveDataAndAgainNavigateToSetupWizardPage()
        {
            CommonMethod.element = Driver.FindElement(By.XPath(Locator.SetupWizard.SaveAllButton));
            if (CommonMethod.element.Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                ExtentTestManager.TestSteps("Delete old data from setup wizard");
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSystems();
            }
        }

        private void VerifyRoofProductSystem()
        {
            DefaultJobElement.ClickProductSystem();
            DefaultJobElement.ServerDelay();
            Console.WriteLine("Verify the Roof Product System");
            DefaultJobElement.SelectRoofProductSystem("TestRoof System R-1");
            DefaultJobElement.ClickColors();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string roofColor = DefaultJobElement.GetRoofColorValue();

            if (roofColor == "TestRoof Color R-1")
            {
                Console.WriteLine("Verify that the selected Color Material for the Roof Color R-1 is applied to the roof Color of Main Building");
                ExtentTestManager.TestSteps("Verify that the selected Color Material for the Roof Color R-1 is applied to the roof Color of Main Building");
            }
            else
            {
                Console.WriteLine("Verify that the selected Color Material Roof Color R-1 is not applied to the roof Color of Main Building");
                ExtentTestManager.TestSteps("Verify that the selected Color Material is not applied to the roof Color of Main Building");
                Assert.Fail("Verify that the selected Color Material is not applied to the roof Color of Main Building");
            }

            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofSheathing();

            string firstElementOfDropdown = DefaultJobElement.GeTheFirstElementFromDropdown(DefaultJobElement.RoofMaterial,"div");
            string roofMaterial = DefaultJobElement.GetTheRoofMaterialValue();

            if (roofMaterial == firstElementOfDropdown)
            {
                Console.WriteLine("Verify that The first element is selecting automatically when the roof product system is apply to the canvas building");
                ExtentTestManager.TestSteps("Verify that The first element is selecting automatically when the roof product system is apply to the canvas building");
            }
            else
            {
                Console.WriteLine("Verify that The first element is not selecting automatically when the roof product system is apply to the canvas building");
                ExtentTestManager.TestSteps("Verify that The first element is not selecting automatically when the roof product system is apply to the canvas building");
                Assert.Fail("Verify that The first element is not selecting automatically when the roof product system is apply to the canvas building");
            }

            DefaultJobElement.SelectRoofMaterial("TestRoof Sheathing R-1");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickROOF_2();
            DefaultJobElement.ClickProductSystem();
            DefaultJobElement.ClickRoofSystem();
            DefaultJobElement.SelectMaterialFromDropdownTagNameOfTDElement("TestRoof System R-2");
            ExtentTestManager.TestSteps("Select TestRoof System R-2 from roofing product system");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            ExtentTestManager.TestSteps("Select the Roof System R-2 from the Roof Product Dropdown of Advanced Edits");
            DefaultJobElement.ClickColors();

            string roofColorAdv = DefaultJobElement.GetRoofColorValue();

            if (roofColorAdv == "TestRoof Color R-2")
            {
                Console.WriteLine("Verify that the selected Color Material for the Roof Color R-2 is applied to the roof Color of the Advanced Edits");
                ExtentTestManager.TestSteps("Verify that the selected Color Material is applied to the roof Color of the Advanced Edits");
            }
            else
            {
                Console.WriteLine("Verify that the selected Color Material Roof Color R-1 is not applied to the roof Color of the Advanced Edits");
                ExtentTestManager.TestSteps("Verify that the selected Color Material is not applied to the roof Color of the Advanced Edits");
                Assert.Fail("Verify that the selected Color Material is not applied to the roof Color of the Advanced Edits");
            }

            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofSheathing();

            string firstElementOfAdvancedEditDropdown = DefaultJobElement.GeTheFirstElementFromDropdown(DefaultJobElement.RoofMaterial, "td");
            string roofMaterialAdv = DefaultJobElement.GetTheRoofMaterialValue();

            if (roofMaterialAdv == firstElementOfAdvancedEditDropdown)
            {
                Console.WriteLine("Verify that the selected Sheathing Material is applied to the roof Material of the Advanced Edit");
                ExtentTestManager.TestSteps("Verify that the selected Sheathing Material is applied to the roof Material of the Advanced Edit");
            }
            else
            {
                Console.WriteLine("Verify that the selected Sheathing  Material is not applied to the roof Material of the Advanced Edit");
                ExtentTestManager.TestSteps("Verify that the selected Sheathing Material is not applied to the roof Material of the Advanced Edit");
                Assert.Fail("Verify that the selected Sheathing Material is not applied to the roof Material of the Advanced Edit");
            }

            DefaultJobElement.ClickRoofMaterial();
            DefaultJobElement.SelectMaterialFromDropdownTagNameOfTDElement("TestRoof Sheathing R-2");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();

            // Get the Roof Material Data 
            string roofDataAdv = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id(Locator.DefaultJob.getTheSheathingDrawingElement))).Text;

            if (roofDataAdv == "TestRoof Sheathing R-1")
            {
                Console.WriteLine("Verify that the updated Sheathing Material is not applied to the roof sheathing after changing the Roof product System of Advanced Edit");
                ExtentTestManager.TestSteps("Verify that the updated Sheathing Material is not applied to the roof sheathing after changing the Roof product System of Advanced Edit");
                Assert.Fail("Verify that the updated Sheathing Material is not applied to the roof sheathing after changing the Roof product System of Advanced Edit");
            }
            else
            {
                Console.WriteLine("Verify that the updated Sheathing Material is applied to the roof sheathing after changing the Roof product System of Advanced Edit");
                ExtentTestManager.TestSteps("Verify that the updated Sheathing Material is applied to the roof sheathing after changing the Roof product System of Advanced Edit");
            }

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.CaptureScreenShot($@"{pathFile}", "Roof Product System.png");
        }

        private void DeleteSheathingData()
        {
            SetupWizard.ClickSheathing();
            DeleteDataFromTable("TestRoof Sheathing R-1", "TestRoof Sheathing R-2");
        }

        private void DeleteColorData()
        {
            SetupWizard.ClickColors();
            DeleteDataFromTable("TestRoof Color R-1", "TestRoof Color R-2");
        }

        private void DeleteSystemData()
        {
            SetupWizard.ClickSystems();
            try
            {
                CommonMethod.Wait(2);
                Driver.FindElement(By.XPath(Locator.SetupWizard.YesButton)).Click();
                DeleteDataFromTable("TestRoof System R-1", "TestRoof System R-2");
            }
            catch (Exception)
            {
                DeleteDataFromTable("TestRoof System R-1", "TestRoof System R-2");
            }
        }

        private void DeleteDataFromTable(string materialOne, string materialTwo)
        {
            string[] elementName = new string[2] { materialOne, materialTwo };
            for (int index = 0; index < elementName.Length; index++)
            {
                SetupWizard.DeleteSetupWizardData(elementName[index]);
            }
        }
    }
}
#endregion