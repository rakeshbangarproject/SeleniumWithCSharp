using AventStack.ExtentReports.Utils;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using static SmartBuildAutomation.Sprint_1._87.ReflectPanel;

namespace SmartBuildProjectBeta.Test_Suites.Roofing_Passport
{
    [TestFixture, Category("Roofing_Passport")]
    public class Setup_Wizard : BaseClass
    {
        static readonly string inputButtonOfSetupTable = "//td[text()='{0}']";
        static readonly string materialButtonInputs = "(//button[@id='{0}'])[1]";
        static readonly string AddButtonData = "//table[contains(@title,'{0}')][1]";

        [Test, Order(1)]
        public void SmokeTestOnSetupWizardPage()
        {
            ExtentTestManager.CreateTest("Smoke Test On Setup Wizard Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            Entries();
            Systems();
            Colors();
            Cladding();
            Trim();
            Connectors();
            Fasteners();
            Hardware();
            Labor();
            Freight();
            CladdingAssemblies();
            TrimAssemblies();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            ExtentTestManager.CreateTest("Smoke Test On Setup Wizard Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            Entries();
            SetupWizard.SaveDataInTheSetupWizard();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On setup wizard Page");
        }

        private static void Entries()
        {
            SetupWizard.ClickTrimAssemblies();
            SetupWizard.DeleteSetupWizardData("TrimAssembliesForBeta");
            SetupWizard.ClickCladdingAssemblies();
            SetupWizard.DeleteSetupWizardData("CladdingAssembliesForBeta");
            SetupWizard.ClickFreight();
            SetupWizard.DeleteSetupWizardData("FreightForBeta");
            SetupWizard.DeleteSetupWizardData("FreightForBeta2");
            SetupWizard.ClickLabor();
            SetupWizard.DeleteSetupWizardData("LaborForBeta");
            SetupWizard.DeleteSetupWizardData("LaborForBeta2");
            SetupWizard.ClickHardware();
            SetupWizard.DeleteSetupWizardData("HardwareForBeta");
            SetupWizard.DeleteSetupWizardData("HardwareForBeta2");
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("FastenersForBeta");
            SetupWizard.DeleteSetupWizardData("FastenersForBeta2");
            SetupWizard.ClickConnector();
            SetupWizard.DeleteSetupWizardData("ConnectorsForBeta");
            SetupWizard.DeleteSetupWizardData("ConnectorsForBeta2");
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("TrimForBeta");
            SetupWizard.DeleteSetupWizardData("TrimForBeta2");
            SetupWizard.ClickCladding();
            SetupWizard.DeleteSetupWizardData("CladdingForBeta");
            SetupWizard.ClickColors();
            SetupWizard.DeleteSetupWizardData("ColorsForBeta2");
            SetupWizard.DeleteSetupWizardData("ColorsForBeta3");
            SetupWizard.ClickSystems();
            SetupWizard.DeleteFromSystemTableData("TestSetupWizard_Beta2");
        }

        private void TrimAssemblies()
        {
            SetupWizard.ClickTrimAssemblies();
            SetupWizard.ClickAddButton();
            SetupWizard.NameInputField("TrimAssembliesForBeta");
            SelectPrimaryMaterial();
            string elementNameForFilter = SelectDataFromSystemsTable();
            string material = iFrameMaterialOfSheathing();
            QtyUsed("100");
            SpecialConditions();
            string conditionMaterial = SelectSpecialConditionMaterial();
            ClickPlusIconOfSpecialCondition();
            VerifyNewRowCreated();
            SetupWizard.ClickSaveButton();
            CommonMethod.Wait(2);
            SetupWizard.ClickSaveButton();

            bool checkFilterMaterial = CheckFilterFunctionality(elementNameForFilter, "TrimAssembliesForBeta");
            Assert.IsTrue(checkFilterMaterial, "Filter functionality is not working");

            SearchMaterialInTheSetupWizardTable("TrimAssembliesForBeta", "Trim Assemblies");
            ClicksEditButton("Edit Trim Assemblies");
            CheckDescriptionName("TrimAssembliesForBeta");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_entriesGrid_records']//tr[3]//div)[1]")));
            string clip = CommonMethod.element.Text;

            if (clip.Equals(material))
            {
                ExtentTestManager.TestSteps("Type material is not change after click on the save button");
            }
            else
            {
                Assert.Fail("Type material is change after click on the save button");
            }

            ClicksCancelButton();
            HomeIconButton();
            CheckBoxesOfHomeIconTable();
            UsageShowAndHideButton();
            UsageShowAndHideCheckbox("All");
            UncheckCheckboxes();
            UsageShowAndHideCheckbox("All");
            CheckCheckboxes();
            UsageShowAndHideCheckbox1();
            UsageShowAndHideCheckbox("All");
            ClicksTitle();
            CheckBoxesOfHomeIconTable();
        }

        private void CladdingAssemblies()
        {
            SetupWizard.ClickCladdingAssemblies();
            SetupWizard.ClickAddButton();
            SetupWizard.NameInputField("CladdingAssembliesForBeta");
            SelectPrimaryMaterial();
            string elementNameForFilter = SelectDataFromSystemsTable();
            string material = iFrameMaterialOfSheathing();
            QtyUsed("100");
            SpecialConditions();
            string conditionMaterial = SelectSpecialConditionMaterial();
            ClickPlusIconOfSpecialCondition();
            VerifyNewRowCreated();
            SetupWizard.ClickSaveButton();
            CommonMethod.Wait(2);
            SetupWizard.ClickSaveButton();

            bool checkFilterMaterial = CheckFilterFunctionality(elementNameForFilter, "CladdingAssembliesForBeta");
            Assert.IsTrue(checkFilterMaterial, "Filter functionality is not working");

            SearchMaterialInTheSetupWizardTable("CladdingAssembliesForBeta", "CladdingCladdingAssemblies");
            ClicksEditButton("Edit Cladding Assemblies");
            CheckDescriptionName("CladdingAssembliesForBeta");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_entriesGrid_records']//tr[3]//div)[1]")));
            string clip = CommonMethod.element.Text;

            if (clip.Equals(material))
            {
                ExtentTestManager.TestSteps("Type material is not change after click on the save button");
            }
            else
            {
                Assert.Fail("Type material is change after click on the save button");
            }

            ClicksCancelButton();
            HomeIconButton();
            CheckBoxesOfHomeIconTable();
            UsageShowAndHideButton();
            UsageShowAndHideCheckbox("All");
            UncheckCheckboxes();
            UsageShowAndHideCheckbox("All");
            CheckCheckboxes();
            UsageShowAndHideCheckbox1();
            UsageShowAndHideCheckbox("All");
            ClicksTitle();
            CheckBoxesOfHomeIconTable();
        }

        private string SelectSpecialConditionMaterial()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='cond-0-0']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            IWebElement select = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@id,'grid_selectCalcBaseOverlay_grid_rec_') and @line='1']//div)[2]")));
            string getText = select.Text;
            CommonMethod.GetActions().MoveToElement(select).DoubleClick().Pause(TimeSpan.FromSeconds(1)).Perform();
            return getText;
        }

        private static void ClickPlusIconOfSpecialCondition()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='addbtn-0-0']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        private static void VerifyNewRowCreated()
        {
            IWebElement buttons = Driver.FindElement(By.XPath("//div[@id='conditionBuilder']//button"));
            IList<IWebElement> webElements = buttons.FindElements(By.TagName("button"));
            var count = webElements.Count;

            if (count <= 7)
            {
                ExtentTestManager.TestSteps("New row is create after click on the plus icon");
            }
            else
            {
                Assert.Fail("New row is not create after click on the plus icon");
            }
        }

        private static void SpecialConditions()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@name='grup-0']")));
            CommonMethod.SelectElement(CommonMethod.element).SelectByValue("all");
        }

        private void Freight()
        {
            SetupWizard.ClickFreight();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FreightForBeta");
            SetupWizard.EnterDescriptionInputField("FreightForBeta");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            SettingUnit("5");
            QtyPerSellingUnit("2");
            Cost("55");
            Price("45");
            VendorSku("12");
            TaxClass();
            LockMarkup();
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("FreightForBeta", "Freight");
            ClicksEditButton("Edit Freight");
            SetupWizard.EnterDescriptionInputField("FreightForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("FreightForBeta2", "Freight");
            ClicksEditButton("Edit Freight");
            CheckDescriptionName("FreightForBeta2");
            ClicksCancelButton();
        }

        private void Labor()
        {
            SetupWizard.ClickLabor();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("LaborForBeta");
            SetupWizard.EnterDescriptionInputField("LaborForBeta");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            SettingUnit("5");
            QtyPerSellingUnit("2");
            Cost("55");
            Price("45");
            VendorSku("12");
            TaxClass();
            LockMarkup();
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("LaborForBeta", "Labor");
            ClicksEditButton("Edit Labor");
            SetupWizard.EnterDescriptionInputField("LaborForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("LaborForBeta2", "Labor");
            ClicksEditButton("Edit Labor");
            CheckDescriptionName("LaborForBeta2");
            ClicksCancelButton();
        }

        private void Hardware()
        {
            SetupWizard.ClickHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("HardwareForBeta");
            SetupWizard.EnterDescriptionInputField("HardwareForBeta");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            SettingUnit("5");
            QtyPerSellingUnit("2");
            Cost("55");
            Price("45");
            Weight("32");
            VendorSku("12");
            TaxClass();
            LockMarkup();
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("HardwareForBeta", "Hardware");
            ClicksEditButton("Edit Hardware");
            SetupWizard.EnterDescriptionInputField("HardwareForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("HardwareForBeta2", "Hardware");
            ClicksEditButton("Edit Hardware");
            CheckDescriptionName("HardwareForBeta2");
            ClicksCancelButton();
        }

        private void Fasteners()
        {
            SetupWizard.ClickFasteners();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("FastenersForBeta");
            SetupWizard.EnterDescriptionInputField("FastenersForBeta");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            SettingUnit("5");
            QtyPerSellingUnit("2");
            SetupWizard.EnterPricingDetails("3", "4");

            PricingsTable();
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("FastenersForBeta", "Connectors");
            ClicksEditButton("Edit Fasteners");
            SetupWizard.EnterDescriptionInputField("FastenersForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("FastenersForBeta2", "Connectors");
            ClicksEditButton("Edit Fasteners");
            CheckDescriptionName("FastenersForBeta2");
            ClicksCancelButton();
        }

        private void Connectors()
        {
            SetupWizard.ClickConnector();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("ConnectorsForBeta");
            SetupWizard.EnterDescriptionInputField("ConnectorsForBeta");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");

            SettingUnit("5");
            QtyPerSellingUnit("2");
            Cost("55");
            Price("45");
            Weight("32");
            VendorSku("12");
            TaxClass();
            LockMarkup();
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("ConnectorsForBeta", "Connectors");
            ClicksEditButton("Edit Connectors");
            SetupWizard.EnterDescriptionInputField("ConnectorsForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("ConnectorsForBeta2", "Connectors");
            ClicksEditButton("Edit Connectors");
            CheckDescriptionName("ConnectorsForBeta2");
            ClicksCancelButton();
        }

        private void Trim()
        {
            SetupWizard.ClickTrim();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("TrimForBeta");
            SetupWizard.EnterDescriptionInputField("TrimForBeta");
            SetupWizard.EnterWidthInputField("5");
            SetupWizard.EnterHeightInputField("5");
            OverlapField("4");
            SetupWizard.EnterMaximumLengthInputField("5");
            SetupWizard.EnterMinimumCutLengthInputField("3");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            string elementNameForFilter = SelectDataFromSystemsTable();
            SetupWizard.SelectAllElementFromUsageTable();
            EnterPricingDetailsTrim();
            PricingsTable();
            SetupWizard.ClickSaveButton();

            bool checkFilterMaterial = CheckFilterFunctionality(elementNameForFilter, "TrimForBeta");
            Assert.IsTrue(checkFilterMaterial, "Filter functionality is not working");

            SearchMaterialInTheSetupWizardTable("TrimForBeta", "Trim");
            ClicksEditButton("Edit Trim");
            SetupWizard.EnterDescriptionInputField("TrimForBeta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("TrimForBeta2", "Trim");
            ClicksEditButton("Edit Trim");
            CheckDescriptionName("TrimForBeta2");
            ClicksCancelButton();
            HomeIconButton();
            CheckBoxesOfHomeIconTable();
            UsageShowAndHideButton();
            UsageShowAndHideCheckbox("All");
            UncheckCheckboxes();
            UsageShowAndHideCheckbox("All");
            CheckCheckboxes();
            UsageShowAndHideCheckbox1();
            UsageShowAndHideCheckbox("All");
            ClicksTitle();
            CheckBoxesOfHomeIconTable();
        }

        private void Cladding()
        {
            SetupWizard.ClickCladding();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("CladdingForBeta");
            SetupWizard.EnterDescriptionInputField("CladdingForBeta");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("36");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterMaximumLengthInputField("36");
            SetupWizard.EnterUnderlapLengthInputField("3");
            SetupWizard.EnterMinimumCutLengthInputField("3");
            ExtensionField("3");
            SetupWizard.EnterSupplierIDInputField("RE3");
            SetupWizard.EnterSupplierSKUInputField("3");
            SetupWizard.EnterPackagingCodeInputField("35DDS");
            SetupWizard.SelectColorMap("Shingle Texture");
            SetupWizard.SelectBumpMap("Standing Seam");
            string elementNameForFilter = SelectDataFromSystemsTable();
            string usageElement = AddedDataFromTheUsageTable();
            SetupWizard.EnterPricingDetails("3", "4");

            PricingsTable();

            // Click on the Part Length Button
            string partLengthButtonXPath = string.Format(inputButtonOfSetupTable, "Part Lengths");
            ClickOnTheButton(partLengthButtonXPath, "Part Lengths button of pricing table");
            SetupWizard.ClickSaveButton();

            bool checkFilterMaterial = CheckFilterFunctionality(elementNameForFilter, "CladdingForBeta");
            Assert.IsTrue(checkFilterMaterial, "Filter functionality is not working");

            SearchMaterialInTheSetupWizardTable("CladdingForBeta", "Cladding");
            ClicksEditButton("Edit Cladding");
            CheckDescriptionName("CladdingForBeta");
            ClicksCancelButton();
            HomeIconButton();
            CheckBoxesOfHomeIconTable();
            UsageShowAndHideButton();
            UsageShowAndHideCheckbox("All");
            UncheckCheckboxes();
            UsageShowAndHideCheckbox("All");
            CheckCheckboxes();
            UsageShowAndHideCheckbox1();
            UsageShowAndHideCheckbox("All");
            ClicksTitle();
            CheckBoxesOfHomeIconTable();
        }

        private void Colors()
        {
            SetupWizard.ClickColors();
            SetupWizard.ClickAddButton();
            SetupWizard.ColorNameInputField("ColorsForBeta");
            SetupWizard.SelectHexCode("E06666");
            SetupWizard.ColorCodeInputField("E06666");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.SelectColorMap("Shingle Texture");
            SetupWizard.SelectBumpMap("Standing Seam");
            string elementNameForFilter = SelectDataFromSystemsTable();
            SetupWizard.ClickSaveButton();
            bool checkFilterMaterial = CheckFilterFunctionality(elementNameForFilter, "ColorsForBeta");
            Assert.IsTrue(checkFilterMaterial, "Filter functionality is not working");
            SearchMaterialInTheSetupWizardTable("ColorsForBeta", "Colors");
            ClicksEditButton("Edit Colors");
            CheckColorName("ColorsForBeta");
            SetupWizard.ColorNameInputField("ColorsForBeta2");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("ColorsForBeta2", "Colors");
            ClicksCloneButton();
            SetupWizard.ColorNameInputField("ColorsForBeta3");
            SetupWizard.ColorCodeInputField("E6546");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("ColorsForBeta3", "Colors");

        }

        private void Systems()
        {
            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSystems();
            }

            SetupWizard.ClickAddButton();
            SetupWizard.EnterDescriptionInputField("TestSetupWizard_Beta");
            SetupWizard.KeysInputField("S-252");
            SetupWizard.RemoveElementFromUsageTable("Roof System - null");
            string remove = CheckDataRemoveFromUsageTable();
            Assert.That(remove.IsNullOrEmpty(), Is.True, "Remove element from usage table functionality is not working");
            SetupWizard.AddUsageElement("Roof System - null");
            string addNewData = CheckDataRemoveFromUsageTable();
            Assert.That(addNewData.Equals("Roof System - null"), "New data is not added in the usage table");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("TestSetupWizard_Beta", "Systems");
            ClicksEditButton("Edit Systems");
            SetupWizard.EnterDescriptionInputField("TestSetupWizard_Beta2");
            SetupWizard.ClickSaveButton();
            SearchMaterialInTheSetupWizardTable("TestSetupWizard_Beta2", "Systems");
            ClicksEditButton("Edit Systems");
            CheckDescriptionName("TestSetupWizard_Beta2");
            ClicksCancelButton();
            HomeIconButton();
            CheckBoxesOfHomeIconTable();
            UsageShowAndHideButton();
            UsageShowAndHideCheckbox("All");
            UncheckCheckboxes();
            CheckSubMenuListsWhenAllCheckboxIsUncheck("Description", "");
            bool checkRoofSystem = CheckSubMenuLists("RoofMaterial");
            Assert.IsFalse(checkRoofSystem, "Roof Cladding is shown in the menu list after main uncheck the RoofMaterial checkbox");
            UsageShowAndHideCheckbox("All");
            CheckCheckboxes();
            UsageShowAndHideCheckbox1();
            ClicksTitle();
            CheckBoxesOfHomeIconTable();
        }

        private void PricingsTable()
        {
            string addButtonXPath = string.Format(AddButtonData, "- Add a new price");
            string deleteButtonXPath = string.Format(AddButtonData, "- Delete the selected price");
            string yesButtonPopUpXPath = string.Format(materialButtonInputs, "Yes");
            string colorButtonXPath = string.Format(inputButtonOfSetupTable, "Colors");
            string taxableButtonXPath = string.Format(inputButtonOfSetupTable, "Taxable");
            string lockMarkupButtonXPath = string.Format(inputButtonOfSetupTable, "Lock Markup");

            ClickOnTheButton(addButtonXPath, "Add button of pricing table");
            ClickOnTheButton(deleteButtonXPath, "Delete button of pricing table");
            ClickOnTheButton(yesButtonPopUpXPath, "Yes button button pop up after click on the delete button of pricing table");
            ClickOnTheButton(colorButtonXPath, "Colors button of pricing table");
            ClickOnTheButton(taxableButtonXPath, "Taxable button of pricing table");
            ClickOnTheButton(lockMarkupButtonXPath, "Lock Markup button of pricing table");
        }

        public static void EnterPricingDetailsTrim()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='$0.00'])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys("10").Perform();
            ExtentTestManager.TestSteps("Enter the cost in the pricings table");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='$0.00'])[1]")));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys("20").Perform();
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price in the pricings table");
        }

        private string iFrameMaterialOfSheathing()
        {
            SetupWizard.ClickAddNewButtonOfAssemblies();
            string getMaterial = SelectType();
            SelectOutputCategory();
            // Click on the Material button
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@id='materialBtn'])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Material button");

            // Click on the Catalog Category Dropdown
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Catalog Category')]//following :: div[5]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Catalog Category Dropdown");

            // Select Material from Catalog Category dropdown  
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//tr[@index='0']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Select Catalog Category material");
            CommonMethod.Wait(1);

            // Click on the part length material 
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_fixGrid_rec_') and @line='3']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            return getMaterial;
        }


        private string SelectType()
        {
            ClickOnTheButton("(//label[text()='Type'])[1]//following::div[5]", "Type");
            IWebElement typeMaterial = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//tr[@index='0']")));
            string clip = typeMaterial.Text;
            typeMaterial.Click();
            return clip;
        }

        private void SelectOutputCategory()
        {
            ClickOnTheButton("(//label[text()='Output Category'])[1]//following::div[5]", "Output Category");
            ClickOnTheButton("//div[@id='w2ui-overlay']//tr[@index='0']", "Type");
        }


        private void ClickOnTheButton(string elementXPath, string buttonName)
        {
            try
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementXPath)));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            }
            catch (StaleElementReferenceException)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(elementXPath)));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            }

            ExtentTestManager.TestSteps($"Click on the {buttonName}");
            CommonMethod.Wait(1);
        }

        private void ExtensionField(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Margin']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the extension Field '{number}'");
        }

        private void OverlapField(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Dim3']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the overlap Field '{number}'");
        }

        private void SettingUnit(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='SellingUnit']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the Selling Unit Field '{number}'");
        }

        private void QtyUsed(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='QtyUsed']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the QtyUsed Field '{number}'");
        }

        private void QtyPerSellingUnit(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='QtyPerSellingUnit']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the Qty Per Selling Unit Field '{number}'");
        }

        private void Cost(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Cost']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the Cost Field '{number}'");
        }

        private void Price(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Price']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the Price Field '{number}'");
        }

        private void Weight(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='Weight']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the Weight Field '{number}'");
        }

        private void VendorSku(string number)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='VendorSku']")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(number + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter Data in the VendorSku Field '{number}'");
        }

        private void TaxClass()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='TaxClass']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps($"Click on the tax checkbox");
        }

        private void LockMarkup()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='LockMarkup']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps($"Click on the LockMarkup checkbox");
        }

        private string CheckDataRemoveFromUsageTable()
        {
            string getAllElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_UsagesSelectedGrid_records']"))).Text;
            return getAllElement;
        }

        private string SelectDataFromSystemsTable()
        {
            IWebElement systemElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_SystemsItemsGrid_rec_') and @line='1']//div")));
            string elementName = systemElement.Text;
            CommonMethod.GetActions().MoveToElement(systemElement).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_SystemsItemsGrid_toolbar_item_add']"))).Click();
            return elementName;
        }

        private string AddedDataFromTheUsageTable()
        {
            IWebElement usageElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_UsagesItemsGrid_rec_') and @line='1']//div")));
            string elementName = usageElement.Text;
            CommonMethod.GetActions().MoveToElement(usageElement).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_UsagesItemsGrid_toolbar_item_add']"))).Click();
            return elementName;
        }

        public bool CheckFilterFunctionality(string filterElement, string materialUsagesName)
        {
            string selectFilterElement = "//div[@id='w2ui-overlay']//td[text()='{0}']";
            IWebElement filterButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_filter']")));
            CommonMethod.GetActions().MoveToElement(filterButton).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.Wait(2);
            IWebElement selectFilter = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(selectFilterElement, filterElement))));
            CommonMethod.GetActions().MoveToElement(selectFilter).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.Wait(1);

            IList<int> ints = new List<int>();
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_grid_records']/table/tbody")));
            string materialXPath = "//tr[contains(@id,'grid_grid_rec_') and @line='{0}']//td[@col='2']/div";

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    string usagesName = row.FindElement(By.XPath(string.Format(materialXPath, lineNumber, 2))).Text;

                    if (usagesName.Equals(materialUsagesName))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void SelectPrimaryMaterial()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Primary Material')]//following :: div[5]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//tr[@index='0']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps($"Select Primary Material");
            CommonMethod.Wait(1);
        }

        private void SearchMaterialInTheSetupWizardTable(string name, string searchTableName)
        {
            string elementXPath = "(//div[contains(@id,'grid_grid_records')]//following::span[contains(text(),'{0}')])[1]";

            IWebElement searchMaterialInTheTable = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='grid_grid_search_all']")));
            searchMaterialInTheTable.Clear();
            CommonMethod.GetActions().MoveToElement(searchMaterialInTheTable).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys(name + Keys.Enter).Perform();
            CommonMethod.Wait(2);
            IWebElement clickOnTheSearchElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, name))));
            string materialName = clickOnTheSearchElement.Text;
            Assert.That(materialName, Is.EqualTo(name), $"The {name} material is not shown in the {searchTableName} table");
            CommonMethod.GetActions().MoveToElement(clickOnTheSearchElement).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.Wait(1);
            ExtentTestManager.TestSteps($"Search new added material in the {searchTableName}");
        }

        private void ClicksEditButton(string title)
        {
            try
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_edit']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
                ExtentTestManager.TestSteps($"Click on the edit button");
                CommonMethod.Wait(1);
                string subMenuName = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='w2ui-msg-title']"))).Text;
                Assert.That(subMenuName, Is.EqualTo(title), $"{title} is visible");
            }
            catch (TimeoutException)
            {
                Assert.Fail($"{title} is visible");
            }
        }

        private void CheckDescriptionName(string name)
        {
            string subMenuName = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='Description']"))).GetAttribute("value");
            Assert.That(subMenuName, Is.EqualTo(name), $"{name} is not match with name of newly added material");
            CommonMethod.Wait(1);
        }

        private void CheckColorName(string name)
        {
            string subMenuName = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='ColorName']"))).GetAttribute("value");
            Assert.That(subMenuName, Is.EqualTo(name), $"{name} is not match with description of newly added material");
            CommonMethod.Wait(1);
        }

        private void ClicksCancelButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='Cancel']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the cancel button");
        }

        private void ClicksTitle()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h2[text()='Setup Wizard for AUTOTEST_EAGLEVIEW BASE']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
        }

        private void ClicksCloneButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_clone']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
        }

        private void HomeIconButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_usage']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_columns']")));
            ExtentTestManager.TestSteps($"Click on the home button");
            CommonMethod.Wait(1);
        }

        private void UsageShowAndHideButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_columns']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the Usage Show And Hide Button");
        }

        private void UsageShowAndHideCheckbox(string nameOfCheckbox)
        {
            string checkbox = "//div[@id='columnsoverlay']//input[@id='{0}']";
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(checkbox, nameOfCheckbox)))).Click();
        }

        private void UsageShowAndHideCheckbox1()
        {
            string checkbox = "//div[@id='columnsoverlay']//input[@id='{0}']";
            IReadOnlyCollection<IWebElement> checkboxElements = Driver.FindElements(By.XPath("//div[@id='columnsoverlay']//input[@type='checkbox']"));

            foreach (IWebElement checkboxElement in checkboxElements)
            {
                string checkboxId = checkboxElement.GetAttribute("id");
                if (checkboxId != "All")
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(checkbox, checkboxId)))).Click();
                    CommonMethod.Wait(1);
                    bool main = CheckSubMenuLists(checkboxId);
                    Assert.IsFalse(main, $"{checkboxId} is shown in the menu list after {checkboxId} checkbox is uncheck");
                }
            }
        }

        private List<CheckboxInfo> GetCheckboxInfoList()
        {
            List<CheckboxInfo> checkboxInfoList = new List<CheckboxInfo>();

            // Locate all checkbox elements
            IReadOnlyCollection<IWebElement> checkboxElements = Driver.FindElements(By.XPath("//div[@id='columnsoverlay']//input[@type='checkbox']"));

            // Iterate through each checkbox element
            foreach (IWebElement checkbox in checkboxElements)
            {
                string checkboxId = checkbox.GetAttribute("id");
                bool isChecked = checkbox.Selected;

                // Add checkbox information to the list
                checkboxInfoList.Add(new CheckboxInfo { Id = checkboxId, IsChecked = isChecked });
            }

            return checkboxInfoList;
        }

        private void VerifyCheckboxesAreChecked(bool expectedState)
        {
            List<CheckboxInfo> checkboxInfoList = GetCheckboxInfoList();

            // Assert the state of each checkbox
            Assert.IsTrue(checkboxInfoList.All(info => info.IsChecked == expectedState), $"All checkboxes are not {(expectedState ? "checked" : "unchecked")}.");
        }

        private void UncheckCheckboxes()
        {
            VerifyCheckboxesAreChecked(false);
        }

        private void CheckCheckboxes()
        {
            VerifyCheckboxesAreChecked(true);
        }

        private bool CheckSubMenuLists(string nameOfList)
        {
            string list = "//div[@id='grid_grid_columns']/table/tbody/tr[3]/td[{0}]";

            IWebElement listElements = Driver.FindElement(By.XPath("//div[@id='grid_grid_columns']/table/tbody/tr[3]"));
            IList<IWebElement> list33 = listElements.FindElements(By.TagName("td"));
            var columnCount = list33.Count;

            for (int i = 1; i <= columnCount; i++)
            {
                string getTheNameOfSubMenu = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(list, i)))).GetAttribute("onclick");
                string modifiedOnClick = $"w2ui['grid'].columnClick('{nameOfList}', event);";

                if (getTheNameOfSubMenu != null && getTheNameOfSubMenu.Contains(modifiedOnClick))
                {
                    return true;
                }

                EventFiringWebDriver eventFiringWebDriver = new(Driver);
                eventFiringWebDriver.ExecuteScript("document.querySelector('#grid_grid_records').scrollBy(20,0)");
            }

            return false;
        }

        private bool CheckSubMenuListsWhenAllCheckboxIsUncheck(string first, string second)
        {
            string list = "//div[@id='grid_grid_columns']/table/tbody/tr[3]/td[{0}]";

            IWebElement listElements = Driver.FindElement(By.XPath("//div[@id='grid_grid_columns']/table/tbody/tr[3]"));
            IList<IWebElement> list33 = listElements.FindElements(By.TagName("td"));
            var columnCount = list33.Count;

            for (int i = 0; i < columnCount; i++)
            {
                string getTheNameOfSubMenu = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(list, i + 1)))).GetAttribute("onclick");

                if (getTheNameOfSubMenu != null && getTheNameOfSubMenu.Contains(first) && getTheNameOfSubMenu.Contains(second))
                {
                    return true;
                }
            }

            return false;
        }

        private void CheckBoxesOfHomeIconTable()
        {
            IReadOnlyList<IWebElement> checkboxes = Driver.FindElements(By.XPath("//input[@type='checkbox']"));
            CommonMethod.Wait(1);
            var checkbox = checkboxes.Count;
            for (int i = 1; i <= checkbox; i++)
            {
                try
                {
                    CommonMethod.Click(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("(//input[contains(@type ,'checkbox')])[{0}]", i)))));
                }
                catch (StaleElementReferenceException)
                {
                    CommonMethod.Click(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("(//input[contains(@type ,'checkbox')])[{0}]", i)))));
                }
            }
        }
    }
}
