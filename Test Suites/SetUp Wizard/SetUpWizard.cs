using Forms.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Setup_wizard")]
    class SetUpWizard : BaseClass
    {

        [Test, Order(1)]
        public void AllOptions()
        {
            Colors();
            Connectors();
            CupolaHardware();
            Cupolas();
            Fasteners();
            Foundation();
            Framing();
            Freight();
            Hardware();
            Labor();
            OverheadDoors();
            OverheadHardware();
            Sheathing();
            SliderHardware();
            Sliders();
            Systems();
            Trim();
            WalkDoorHardware();
            WindowHardware();
            Windows();
            WalkDoor();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            LoginApplicationAndChangesDistributor("Delete Data");
            HomePage.NavigateToSetupWizardPages();
            DeleteDataFromSetupWizard();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private static void DeleteDataFromSetupWizard()
        {
            SetupWizard.ClickColors();
            SetupWizard.DeleteSetupWizardData("Colors1");
            SetupWizard.ClickConnector();
            SetupWizard.DeleteSetupWizardData("ConnectorMaterial");
            SetupWizard.ClickCupolaHardware();
            SetupWizard.DeleteSetupWizardData("CupolaHardwareMaterial");
            SetupWizard.ClickCupolas();
            SetupWizard.DeleteSetupWizardData("CupolasMaterial");
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("FastenersMaterial");
            SetupWizard.ClickFoundation();
            SetupWizard.DeleteSetupWizardData("FoundationMaterial");
            SetupWizard.ClickFraming();
            SetupWizard.DeleteSetupWizardData("FramingMaterial");
            SetupWizard.ClickFreight();
            SetupWizard.DeleteSetupWizardData("FreightMaterial");
            SetupWizard.ClickHardware();
            SetupWizard.DeleteSetupWizardData("HardwareMaterial");
            SetupWizard.ClickLabor();
            SetupWizard.DeleteSetupWizardData("LaborMaterial");
            SetupWizard.ClickOverheadDoors();
            SetupWizard.DeleteSetupWizardData("OverHeadDoorMaterial");
            SetupWizard.ClickOverheadHardware();
            SetupWizard.DeleteSetupWizardData("OverheadHardwareMaterial");
            SetupWizard.ClickSheathing();
            SetupWizard.DeleteSetupWizardData("SheathingMaterial");
            SetupWizard.ClickSliderHardware();
            SetupWizard.DeleteSetupWizardData("SliderHardwareMaterial");
            SetupWizard.ClickSlider();
            SetupWizard.DeleteSetupWizardData("SliderMaterial");
            SetupWizard.ClickSystems();
            SetupWizard.DeleteSetupWizardData("SystemsData");
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("TrimMaterial");
            SetupWizard.ClickWalkDoors();
            SetupWizard.DeleteSetupWizardData("WalkdoorMaterial");
            SetupWizard.ClickWalkDoorHardware();
            SetupWizard.DeleteSetupWizardData("WalkdoorHardwareMaterial");
            SetupWizard.ClickWindowHardware();
            SetupWizard.DeleteSetupWizardData("WindowHardwareMaterial");
            SetupWizard.ClickWindows();
            SetupWizard.DeleteSetupWizardData("WindowsMaterial");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of SetupWizard");
        }

        #region Private Method
        /// <summary>
        /// Login to the application and set distributor as AutoTest_PHTest
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");
        }

        public static void DeleteOldDataFromSetupWizard()
        {
            DeleteDataFromSetupWizard();

            if(SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
            }
        }


        public void Colors()
        {
            LoginApplicationAndChangesDistributor("SetUp Wizard(Test case = 1)");
            HomePage.NavigateToSetupWizardPages();
            DeleteOldDataFromSetupWizard();
            SetupWizard.ClickColors();
            SetupWizard.ClickAddButton();
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ColorNameInputField("Colors1");
            SetupWizard.SelectHexCode("E06666");
            SetupWizard.ColorCodeInputField("E06666");
            SetupWizard.ClickSaveButton();
        }

        public void Connectors()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 2)").Info("Add Connectors");
            SetupWizard.ClickConnector();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("ConnectorMaterial");
            SetupWizard.EnterDescriptionInputField("ConnectorMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void CupolaHardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 3)").Info("Add Cupola Hardware");
            SetupWizard.ClickCupolaHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("CupolaHardwareMaterial");
            SetupWizard.EnterDescriptionInputField("CupolaHardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Cupolas()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 4)").Info("Add Cupolas");
            SetupWizard.ClickCupolas();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("CupolasMaterial");
            SetupWizard.EnterDescriptionInputField("CupolasMaterial");
            CommonMethod.Wait(2);
            SetupWizard.EnterHeightInputField("5");
            SetupWizard.EnterRoofPitchInputField("5");
            SetupWizard.EnterWidthInputField("5");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Fasteners()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 5)").Info("Add Fasteners");
            SetupWizard.ClickFasteners();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FastenersMaterial");
            SetupWizard.EnterDescriptionInputField("FastenersMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.ClickSaveButton();
        }

        public void Foundation()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 6)").Info("Add Foundation");
            SetupWizard.ClickFoundation();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FoundationMaterial");
            SetupWizard.EnterDescriptionInputField("FoundationMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Framing()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 7").Info("Add Framing");
            SetupWizard.ClickFraming();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FramingMaterial");
            SetupWizard.EnterDescriptionInputField("FramingMaterial");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterDepthInputField("1");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.ClickSaveButton();
        }

        public void Freight()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 8)").Info("Add Freight");
            SetupWizard.ClickFreight();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FreightMaterial");
            SetupWizard.EnterDescriptionInputField("FreightMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Hardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 9)").Info("Add Hardware");
            SetupWizard.ClickHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("HardwareMaterial");
            SetupWizard.EnterDescriptionInputField("HardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Labor()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 10)").Info("Add Labor");
            SetupWizard.ClickLabor();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("LaborMaterial");
            SetupWizard.EnterDescriptionInputField("LaborMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void OverheadDoors()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 11)").Info("Add OverHead Doors");
            SetupWizard.ClickOverheadDoors();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("OverHeadDoorMaterial");
            SetupWizard.EnterDescriptionInputField("OverHeadDoorMaterial");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterHeightInputField("1");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void OverheadHardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 12)").Info("Add OverheadMaterial");
            SetupWizard.ClickOverheadHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("OverheadHardwareMaterial");
            SetupWizard.EnterDescriptionInputField("OverheadHardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Sheathing()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 13)").Info("Add Sheathing");
            SetupWizard.ClickSheathing();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("SheathingMaterial");
            SetupWizard.EnterDescriptionInputField("SheathingMaterial");
            SetupWizard.EnterCoverageWidthInputField("1");
            SetupWizard.EnterFullWidthInputField("1");
            SetupWizard.EnterThicknessInputField("1");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.ClickSaveButton();
        }

        public void SliderHardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 14)").Info("Add Slider Hardware");
            SetupWizard.ClickSliderHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("SliderHardwareMaterial");
            SetupWizard.EnterDescriptionInputField("SliderHardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Sliders()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 15)").Info("Add Sliders");
            SetupWizard.ClickSlider();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("SliderMaterial");
            SetupWizard.EnterDescriptionInputField("SliderMaterial");
            SetupWizard.EnterWidthInputField("10");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("10");
            SetupWizard.EnterPriceInputField("10");
            SetupWizard.ClickSaveButton();
        }

        public void Systems()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 16)").Info("Add Systems");
            SetupWizard.ClickSystems();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterDescriptionInputField("SystemsData");
            SetupWizard.KeysInputField("SystemsData456");
            SetupWizard.ClickSaveButton();
        }

        public void Trim()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 17)").Info("Add Trim");
            SetupWizard.ClickTrim();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("TrimMaterial");
            SetupWizard.EnterDescriptionInputField("TrimMaterial");
            SetupWizard.EnterWidthInputField("12");
            SetupWizard.EnterHeightInputField("12");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.ClickSaveButton();
        }

        public void WalkDoor()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 18)").Info("Add Walkdoor");
            SetupWizard.ClickWalkDoors();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("WalkdoorMaterial");
            SetupWizard.EnterDescriptionInputField("WalkdoorMaterial");
            SetupWizard.EnterWidthInputField("5");
            SetupWizard.EnterHeightInputField("5");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.ClickSaveButton();
            CommonMethod.Wait(5);
            SetupWizard.SaveDataInTheSetupWizard();
        }

        public void WalkDoorHardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 19)").Info("Add Walkdoor Hardware");
            SetupWizard.ClickWalkDoorHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("WalkdoorHardwareMaterial");
            SetupWizard.EnterDescriptionInputField("WalkdoorHardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("45");
            SetupWizard.EnterPriceInputField("50");
            SetupWizard.ClickSaveButton();
        }

        public void WindowHardware()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 20)").Info("Add Window Hardware");
            SetupWizard.ClickWindowHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("WindowHardwareMaterial");
            SetupWizard.EnterDescriptionInputField("WindowHardwareMaterial");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("45");
            SetupWizard.EnterPriceInputField("50");
            SetupWizard.ClickSaveButton();
        }

        public void Windows()
        {
            ExtentTestManager.CreateTest("SetUp Wizard(Test case = 21)").Info("Add Windows");
            SetupWizard.ClickWindows();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("WindowMaterial");
            SetupWizard.EnterDescriptionInputField("WindowMaterial");
            SetupWizard.EnterWidthInputField("12");
            SetupWizard.EnterHeightInputField("12");
            SetupWizard.EnterSupplierIDInputField("11");
            SetupWizard.EnterSupplierSKUInputField("1234");
            SetupWizard.EnterPackagingCodeInputField("12345");
            SetupWizard.EnterCostInputField("45");
            SetupWizard.EnterPriceInputField("50");
            SetupWizard.ClickSaveButton();
        }
    }
}
#endregion
