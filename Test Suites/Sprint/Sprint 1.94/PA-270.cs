using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class HiddenMaterial : BaseClass
    {
        [Test, Order(1)]
        public void CheckNewMaterialWithBuilder()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Fix issues with hidden materials");
            CreateNewBuilder();
            CreateNewFramingMaterial();
            CreateNewJobInTheChildBuilder();
            HideMaterialFromPricingTable();
            CheckHideMaterialIsVisibleForParentDistributor();
            CheckHideMaterialInParentDistributor();
            CheckHideMaterialInKritikaBuilderOfParentDistributor();
            CheckHideMaterialInPackagesOfParentDistributor();
            CheckHideMaterialInDefaultJobParentDistributor();
            CheckHideMaterialForChildBuilder();
            CheckHideMaterialInPackageForChildDistributor();
            CheckHideMaterialInDefaultJobForChildDistributor();
            OpenExistingJobAndCheckHideMaterialIsNotShownInTheJob();
        }

        [Test,Order(2)]
        public void DeleteDataFromSetupWizardAndJobPage()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Data From Setup Wizard and job page");
            HomePage.NavigateToTheBuilderPage();
            Builder.DeleteBuilder("TaskKritikaBuilder");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("TestHiddenMaterial");
            SetupWizard.PushUsageChangesToBuilderInSetupWizard();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("CheckHiddenMaterial");

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Fix issues with hidden materials");
        }

        private void CreateNewBuilder()
        {
            HomePage.NavigateToTheBuilderPage();
            Builder.ClickAddButtonAndSelectFieldFromDropdown("Normal");
            Builder.EnterNameInputField("TaskKritikaBuilder");
            Builder.ClickCreateButton();
        }

        private static void OpenExistingJobAndCheckHideMaterialIsNotShownInTheJob()
        {
            HomePage.ClicksJobTab();
            JobPage.OpenJob("CheckHiddenMaterial");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            string trussCarrierMaterial = DefaultJobElement.GetTrussCarrierMaterialValue();
            Assert.That(!trussCarrierMaterial.Contains("TestHiddenMaterial"), "Error: Verify that the hidden material is displayed in the existing child distributor job.");
            ExtentTestManager.TestSteps("Verify that the hidden material is not displayed in the existing child distributor job.");
        }

        private void CheckHideMaterialInDefaultJobForChildDistributor()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.ClickTrussCarrierMaterial();
            bool trussCarrierMaterialList = CheckElementFromDropdown();
            Assert.That(trussCarrierMaterialList, Is.False, "Error: Verify that the hidden material is displayed in the truss carrier material dropdown of child distributor default job.");
            ExtentTestManager.TestSteps("Verify that the hidden material is not displayed in the truss carrier material dropdown of child distributor default job.");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            DefaultJobElement.ClickAddCatalogButton();
            DefaultJobElement.SelectCatalogCategory("Framing");
            DefaultJobElement.ClickCatalogItem();
            bool catalogItemList = CheckElementFromDropdown();
            Assert.That(catalogItemList, Is.False, "Error: Verify that the hidden material is displayed in the category item dropdown of child distributor default job.");
            ExtentTestManager.TestSteps("Verify that the hidden material is not displayed in the category item dropdown of child distributor default job.");
            DefaultJobElement.ClickCancel();
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialInPackageForChildDistributor()
        {
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.ClickAddCatalogButton();
            DefaultJobElement.SelectCatalogCategory("Framing");
            DefaultJobElement.ClickCatalogItem();
            bool catalogItemListOfPackage = CheckElementFromDropdown();
            Assert.That(catalogItemListOfPackage, Is.False, "Error: Verify that the hidden material is not displayed in the category item dropdown of parent distributor's packages");
            ExtentTestManager.TestSteps("Verify that the hidden material is displayed in the category item dropdown of parent distributor's packages");
            DefaultJobElement.ClickCancel();
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialForChildBuilder()
        {
            CommonMethod.LoginToBuilderDistributor("TaskKritikaBuilder");
            HomePage.ClicksHomeButton();
            HomePage.NavigateToFramingRulesPages();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("1700");
            FramingRules.ClickDoEditButton("-- Truss Carrier --", "Truss Carrier Material");
            bool doEditListsForBuilder = CheckElementShownInTheDoEditTable();
            Assert.That(doEditListsForBuilder, Is.False, "Error: Verify that the hidden material is shown in the  'do edit' table of child distributor framing rules");
            ExtentTestManager.TestSteps("Verify that the hidden material is not shown in the  'do edit' table of child distributor framing rules");
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialIsVisibleForParentDistributor()
        {
            ExtentTestManager.CreateTest("Check hide material in the post frame of AUTOTEST_PHTEST framing rules");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("1700");
            FramingRules.ClickDoEditButton("-- Truss Carrier --", "Truss Carrier Material");
            bool doEditLists = CheckElementShownInTheDoEditTable();
            Assert.That(doEditLists, Is.True, "Error: Verify that the hidden material is not shown in the parent distributor of framing rules");
            ExtentTestManager.TestSteps("Verify that the hidden material is shown in the parent distributor of framing rules");
            DefaultJobElement.NavigateToHomePage();
        }

        private static void HideMaterialFromPricingTable()
        {
            HomePage.NavigateToThePricingPage();
            PricingElement.SelectActiveDistributor("TaskKritikaBuilder");
            CommonMethod.Wait(4);
            PricingElement.SearchElement("TestHiddenMaterial");
            CommonMethod.Wait(4);
            PricingElement.CheckHideCheckbox();
        }

        private static void CreateNewJobInTheChildBuilder()
        {
            ExtentTestManager.CreateTest("Create a job in the Kritika builder");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierMaterial("TestHiddenMaterial");
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("CheckHiddenMaterial");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            HomePage.ClicksHomeButton();
        }

        private static void CreateNewFramingMaterial()
        {
            ExtentTestManager.CreateTest("Create a new framing material");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("TestHiddenMaterial");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickFraming();
            }

            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("TestHiddenMaterial");
            SetupWizard.EnterDescriptionInputField("TestHiddenMaterial");
            SetupWizard.EnterWidthInputField("10");
            SetupWizard.EnterDepthInputField("12");
            SetupWizard.AddUsageElement("Truss Carrier Material - Truss Carrier");
            SetupWizard.ClickSaveButton();
            SetupWizard.PushUsageChangesToBuilderInSetupWizard();
            CommonMethod.LoginToBuilderDistributor("TaskKritikaBuilder");
            HomePage.ClicksHomeButton();
        }

        private bool CheckElementFromDropdown()
        {
            return DefaultJobElement.CheckElementShownInTheDropdown("TestHiddenMaterial", Locator.DefaultJob.selectMaterialFromAdvancedEdit);
        }

        private bool CheckElementShownInTheDoEditTable()
        {
            return FramingRules.CheckElementShownInTheDropdown("TestHiddenMaterial", "color: gray;", "i");
        }

        private void CheckHideMaterialInDefaultJobParentDistributor()
        {
            ExtentTestManager.CreateTest("Check hidden material in the default job of parent distributor");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.ClickTrussCarrierMaterial();
            bool trussCarrierMaterialList = CheckElementFromDropdown();
            Assert.That(trussCarrierMaterialList, Is.True, "Error: Verify that hidden material is not shown in the truss carrier material dropdown of parent distributor default job");
            ExtentTestManager.TestSteps("Verify that hidden material is shown in the truss carrier material dropdown of parent distributor default job");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.ClickAddCatalogButton();
            DefaultJobElement.SelectCatalogCategory("Framing");
            DefaultJobElement.ClickCatalogItem();
            bool catalogItemList = CheckElementFromDropdown();
            Assert.That(catalogItemList, Is.True, "Error: Verify that hidden material is not shown in the category item dropdown of parent distributor default job");
            ExtentTestManager.TestSteps("Verify that hidden material is shown in the category item dropdown of parent distributor default job");
            DefaultJobElement.ClickCancel();
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialInPackagesOfParentDistributor()
        {
            ExtentTestManager.CreateTest("Check hidden material in the packages of parent distributor");
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.ClickAddCatalogButton();
            DefaultJobElement.SelectCatalogCategory("Framing");
            DefaultJobElement.ClickCatalogItem();
            bool catalogItemListOfPackage = CheckElementFromDropdown();
            Assert.That(catalogItemListOfPackage, Is.True, "Error: Verify that hidden material is not shown in the category item dropdown of parent distributor packages");
            ExtentTestManager.TestSteps("Verify that hidden material is shown in the category item dropdown of parent distributor packages");
            DefaultJobElement.ClickCancel();
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialInKritikaBuilderOfParentDistributor()
        {
            ExtentTestManager.CreateTest("Check hidden material in the framing rules of child distributor");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.ClickOnEditButtonOfBuilderFromFramingRules("TaskKritikaBuilder");
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("1700");
            FramingRules.ClickDoEditButton("-- Truss Carrier --", "Truss Carrier Material");
            bool doEditListsForBuilder = CheckElementShownInTheDoEditTable();
            Assert.That(doEditListsForBuilder, Is.True, "Error: Verify that hidden material is not shown in the do edit table of child distributor packages");
            ExtentTestManager.TestSteps("Verify that the 'TestHiddenMaterial' material is displayed in the do edit table of the child distributor's framing rules\n " +
                "Verify that hidden material shown in the italic front and material text color is gray");
            DefaultJobElement.NavigateToHomePage();
        }

        private void CheckHideMaterialInParentDistributor()
        {
            ExtentTestManager.CreateTest("Check hidden material in the framing rules of parent distributor");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("1700");
            FramingRules.ClickDoEditButton("-- Truss Carrier --", "Truss Carrier Material");
            bool doEditLists = CheckElementShownInTheDoEditTable();
            Assert.That(doEditLists, Is.True, "Error: Verify that the 'TestHiddenMaterial' material is not displayed in the do edit table of the parent distributor's framing rules");
            ExtentTestManager.TestSteps("Verify that the 'TestHiddenMaterial' material is displayed in the do edit table of the parent distributor's framing rules");
            DefaultJobElement.NavigateToHomePage();
        }
    }
}
