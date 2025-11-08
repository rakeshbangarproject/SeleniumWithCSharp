using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class PartLength : BaseClass
    {
        public int partLengthColumnNumber = 1;

        [Test]
        public void Assemblies()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Assemblies do not save Part Lengths");
            HomePage.NavigateToSetupWizardPages();
            CheckOldDataAreDeleted();
            AddDataInTheSheathingTable();
            AddDataInTheTrimTable();
            AddDataInTheSheathingAssembliesTable();
            AddDataInTheTrimAssembliesTable();
            VerifyPartLengthDataShownInTheDefaultJob();
            DeleteEntries();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Assemblies do not save Part Lengths Script");
        }

        #region Private Method
        #region Verify that Sheathing and Trim data are updated or not
        public void VerifyPartLengthDataShownInTheDefaultJob()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofSheathing();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectRoofMaterial("Test Sheathing Material+");
            DefaultJobElement.ClickWallSheathing();
            DefaultJobElement.SelectWallMaterialElement("Test Sheathing Material+");
            DefaultJobElement.SelectWainscotElement("Test Sheathing Material+");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();

            DefaultJobElement.VerifyDataShownInTheJobReview(new string[] { "32'", "34'", "36'", "38'" }, "ExteriorWall", "Part Length of Sheathing", "7");
            DefaultJobElement.VerifyDataShownInTheJobReview(new string[] { "32'", "34'", "36'", "38'" }, "Wainscot", "Part Length of Sheathing", "7");
            ExtentTestManager.TestSteps("Verify that the Sheathing Material data is update");

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofTrim();
            DefaultJobElement.SelectRidgeCap("KDTest Material+");
            DefaultJobElement.ClickWallTrim();
            DefaultJobElement.SelectBaseTrimElement("KDTest Material+");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();
            DefaultJobElement.VerifyDataShownInTheJobReview(new string[] { "42'", "44'", "46'", "48'" }, "Base", "Part Length of Trim", "8");
            DefaultJobElement.VerifyDataShownInTheJobReview(new string[] { "42'", "44'", "46'", "48'" }, "RidgeCap", "Part Length of Trim", "8");
            ExtentTestManager.TestSteps("Verify that the Trim Material data is update");
            DefaultJobElement.NavigateToHomePage();
        }
        #endregion

        private string AddLengthInTheAssemblies(string catalogCategory, string materialName, string length, string type, string category)
        {
            SetupWizard.ClickAddNewButtonOfAssemblies();
            SelectTypeAndCategoryElement(type, category);
            SetupWizard.SelectMaterialFromSheathingAssemblies(catalogCategory, materialName);
            SetupWizard.SelectLengthOfAssemblies(length);
            string getTheLengthValue = SetupWizard.GetTheLengthValue();
            SetupWizard.ClickSaveButton();
            return getTheLengthValue;
        }

        private string CheckLengthValueOfTypeEntries(string typeName)
        {
            SetupWizard.OpenNewlyCreatedEntriesOfAssembliesTable(typeName);
            string lengthValue = SetupWizard.GetTheLengthValue();
            SetupWizard.ClickCancelButton();
            return lengthValue;
        }

        private void SelectTypeAndCategoryElement(string type, string category)
        {
            SetupWizard.SelectOutputCategoryOfAssemblies(category);
            SetupWizard.SelectTypeOfAssemblies(type);
        }

        #region Create a new Sheathing Material
        private void AddDataInTheSheathingTable()
        {
            SetupWizard.ClickSheathing();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Sheathing Part Length Test");
            SetupWizard.EnterDescriptionInputField("Part Length of Sheathing");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("37.5");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickPartLength();

            // Click on the Add Button 
            for (int i = 1; i < 4; i++)
            {
                SetupWizard.ClickAddButtonOfPricingTable();
            }

            AddDataInThePartLengthColumn(new string[4] { "32", "34", "36", "38" });

            SetupWizard.ClickColorButtonOfPricingTable();
            SetupWizard.ClickSaveButton();
        }
        #endregion

        private void CheckOldDataAreDeleted()
        {
            DeleteDataFromTable();

            if (SetupWizard.SaveAllButton().Enabled)
            {
                ExtentTestManager.TestSteps("Delete old data from setup wizard");
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSheathing();
            }
            else
            {
                ExtentTestManager.TestSteps("Check old data are deleted");
                SetupWizard.ClickSheathing();
            }
        }

        #region Trim 
        private void AddDataInTheTrimTable()
        {
            SetupWizard.ClickTrim();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Trim Part Length Test");
            SetupWizard.EnterDescriptionInputField("Part Length of Trim");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterHeightInputField("1");
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.EnterPricingDetailsOfTrim("3", "4");

            // Click on the Add Button 
            for (int i = 1; i <= 4; i++)
            {
                SetupWizard.ClickAddButtonOfPricingTable();
            }
            ExtentTestManager.TestSteps("Click on the Add Button");

            AddDataInThePartLengthColumn(new string[4] { "42", "44", "46", "48" });

            SetupWizard.ClickColorButtonOfPricingTable();
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }
        #endregion

        #region Part Length For Trim and Sheathing
        private void AddDataInThePartLengthColumn(string[] partLength)
        {
            // Enter value in the Part Length 
            for (int l = 0; l < partLength.Length; l++)
            {
                CommonMethod.GetActions().MoveToElement(SetupWizard.PartLengthColumns(partLengthColumnNumber)).DoubleClick().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(partLength[l]).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.pricingText))).Click();
                partLengthColumnNumber++;
            }

            partLengthColumnNumber = 1;
            ExtentTestManager.TestSteps("Enter value in the Part Length");
        }
        #endregion

        /// <summary>
        /// Delete the new data from the Sheathing Assemblies table
        /// </summary>
        private void DeleteEntries()
        {
            HomePage.NavigateToSetupWizardPages();
            DeleteDataFromTable();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private static void DeleteDataFromTable()
        {
            SetupWizard.ClickTrimAssemblies();
            SetupWizard.DeleteSetupWizardData("KDTest Material");
            SetupWizard.ClickSheathingAssemblies();
            SetupWizard.DeleteSetupWizardData("Test Sheathing Material");
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("Part Length of Trim");
            SetupWizard.ClickSheathing();
            SetupWizard.DeleteSetupWizardData("Part Length of Sheathing");
        }

        #region Trim Assemblies 
        public void AddDataInTheTrimAssembliesTable()
        {
            SetupWizard.ClickTrimAssemblies();
            SetupWizard.ClickAddButton();
            SetupWizard.NameInputField("KDTest Material");
            SetupWizard.SelectPrimaryMaterial("Part Length of Trim");

            string firstElement = AddLengthInTheAssemblies("Trim", "Part Length of Trim", "42'", "Closure", "Framing");
            string secondElement = AddLengthInTheAssemblies("Trim", "Part Length of Trim", "44'", "Fastener", "Sheathing");
            string thirdElement = AddLengthInTheAssemblies("Trim", "Part Length of Trim", "46'", "Sealant", "Trim");
            string fourthElement = AddLengthInTheAssemblies("Trim", "Part Length of Trim", "48'", "Other", "Doors & Windows");
            CommonMethod.Wait(2);
            SetupWizard.ClickSaveButton();

            SetupWizard.SearchElementAndClickOnTheEdit("KDTest Material");
            string clipValue = CheckLengthValueOfTypeEntries("Closure");
            Assert.That(clipValue, Is.EqualTo(firstElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the Closure type does not change after opening the Closure entry in the assemblies.");
            string fastenerValue = CheckLengthValueOfTypeEntries("Fastener");
            Assert.That(fastenerValue, Is.EqualTo(secondElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the fastener type does not change after opening the fastener entry in the assemblies.");
            string sealantValue = CheckLengthValueOfTypeEntries("Sealant");
            Assert.That(sealantValue, Is.EqualTo(thirdElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the sealant type does not change after opening the sealant entry in the assemblies.");
            string underlaymentValue = CheckLengthValueOfTypeEntries("Other");
            Assert.That(underlaymentValue, Is.EqualTo(fourthElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the Other type does not change after opening the Other entry in the assemblies.");
            SetupWizard.ClickCancelButton();
            ExtentTestManager.TestSteps("Verify that the selected lengths save successfully for Trim Assemblies.");
            SetupWizard.SaveDataInTheSetupWizard();
        }
        #endregion

        #region Sheathing Assemblies
        public void AddDataInTheSheathingAssembliesTable()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickSheathingAssemblies();
            SetupWizard.ClickAddButton();
            SetupWizard.NameInputField("Test Sheathing Material");
            SetupWizard.SelectPrimaryMaterial("Part Length of Sheathing");

            string firstElement = AddLengthInTheAssemblies("Sheathing", "Part Length of Sheathing", "32'", "Clip", "Framing");
            string secondElement = AddLengthInTheAssemblies("Sheathing", "Part Length of Sheathing", "34'", "Fastener", "Sheathing");
            string thirdElement = AddLengthInTheAssemblies("Sheathing", "Part Length of Sheathing", "36'", "Sealant", "Trim");
            string fourthElement = AddLengthInTheAssemblies("Sheathing", "Part Length of Sheathing", "38'", "Underlayment", "Doors & Windows");
            CommonMethod.Wait(2);
            SetupWizard.ClickSaveButton();

            SetupWizard.SearchElementAndClickOnTheEdit("Test Sheathing Material");
            string clipValue = CheckLengthValueOfTypeEntries("Clip");
            Assert.That(clipValue, Is.EqualTo(firstElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the Clip type does not change after opening the clip entry in the assemblies.");
            string fastenerValue = CheckLengthValueOfTypeEntries("Fastener");
            Assert.That(fastenerValue, Is.EqualTo(secondElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the fastener type does not change after opening the fastener entry in the assemblies.");
            string sealantValue = CheckLengthValueOfTypeEntries("Sealant");
            Assert.That(sealantValue, Is.EqualTo(thirdElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the sealant type does not change after opening the sealant entry in the assemblies.");
            string underlaymentValue = CheckLengthValueOfTypeEntries("Underlayment");
            Assert.That(underlaymentValue, Is.EqualTo(fourthElement), "Length value is change");
            ExtentTestManager.TestSteps("Verify that the length of the underlayment type does not change after opening the underlayment entry in the assemblies.");
            SetupWizard.ClickCancelButton();
            ExtentTestManager.TestSteps("Verify that the selected lengths save successfully for Sheathing Assemblies.");
        }
        #endregion
    }
}
#endregion