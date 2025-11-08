using Forms.Reporting;
using Microsoft.VisualBasic.FileIO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestMaterialPage_RF : BaseClass
    {
        public string folderPath = FolderPath.Download();

        #region XPath
        public static string SetupWizardTabOptions = "//li[text()='{0}']";
        public static string AddNewMaterialInputBoxes = "//input[@name='{0}']";
        public static string MaterialPricingsTableInputBox = "//tr[@id='{0}']//td[@col='{1}']";
        public static string MaterialPageTabOptions = "//div[text()='{0}']";
        public static string NewMaterialAdded_MaterialPageTable = "(//td//div[text()='{0}'])[1]";
        public static string EditMaterialInputBoxes = "//input[@name='{0}']";
        public static string DownloadMaterialTableOption = "//td[contains(text(),'{0}')]";
        public static string MaterialAdded_SetupWizardTable = "(//div[text()='{0}'])[1]";

        public static By SettingsDropDown = By.XPath("//a[text()='Settings ']");
        public static By SetupWizardPageLink = By.XPath("//a[text()='Setup Wizard']");
        public static By AddIcon = By.XPath("//span[@class='w2ui-icon-plus']");
        public static By AddSystemButton = By.XPath("//div[@name='SystemsItemsGrid_toolbar']//table[@class='w2ui-button ']");
        public static By PartLengthPricingOption = By.XPath("//td[text()='Part Lengths']");
        public static By NewMaterialSaveBtn = By.XPath("//button[text()='Save']");
        public static By HipRidgeCapUsage = By.XPath("//div[text()='Hip Ridge Cap']");
        public static By AddUsageButton = By.XPath("//td[@id='tb_UsagesItemsGrid_toolbar_item_add']");
        public static By SaveSetupWizardBtn = By.XPath("//button[@id='btnFinish']");
        public static By MaterialsPageLink = By.XPath("//a[text()='Materials']");
        public static By EditMaterialButton = By.XPath("//td[@id='tb_grid_toolbar_item_editLength']");
        public static By SaveMaterialChangesButton = By.XPath("//input[contains(@class,'btn-default')]");
        public static By MaterialPageDownloadButton = By.XPath("//td[text()='Download']");
        public static By MaterialDeleteButton = By.XPath("//td[@id='tb_grid_toolbar_item_delete']");
        public static By DeleteConfirmButton = By.XPath("//button[text()='Yes']");
        #endregion

        [Test, Order(1)]
        public void MaterialPage()
        {
            ExtentTestManager.CreateTest("Smoke Test On Material Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            DeleteData();

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
            }

            AddNewCladdingMaterial();
            AddNewTrimMaterial();
            AddNewConnectorsMaterial();
            AddNewFastenersMaterial();
            AddNewHardwareMaterial();
            AddNewLaborMaterial();
            AddNewFreightMaterial();
            HomePage.NavigateToTheMaterialsPage();
            EditNewCladdingMaterialAdded();
            ClickOnTrimMaterialTabOption();
            EditNewTrimMaterialAdded();
            ClickOnHardwareMaterialTabOption();
            EditNewHardwareMaterialAdded();
            ClickOnConnectorMaterialTabOption();
            EditNewConnectorMaterialAdded();
            ClickOnFastenerMaterialTabOption();
            EditNewFastenerMaterialAdded();
            ClickOnLaborMaterialTabOption();
            EditNewLaborMaterialAdded();
            ClickOnFreightMaterialTabOption();
            EditNewFreightMaterialAdded();
            DownloadMaterialTable_Excel();
            VerifyChangesMadeToMaterials_Excel();
            DownloadMaterialTable_Csv();
            VerifyChangesMadeToMaterials_Csv();
            CommonMethod.DeleteFolderData();
        }

        [Test, Order(2)]
        public void Delete()
        {
            ExtentTestManager.CreateTest("Delete Data");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            DeleteMaterialAdded();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Material Page");
        }

        #region Private Method
        private void AddNewCladdingMaterial()
        {
            SetupWizard.ClickCladding();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Cladding Material");
            SetupWizard.EnterDescriptionInputField("Test Cladding Material");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("37.5");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterMaximumLengthInputField("50");
            SetupWizard.EnterUnderlapLengthInputField("5");
            SetupWizard.AddSystemTableElement("Asphalt Shingle");
            SetupWizard.AddUsageElement("Roof Cladding");
            SetupWizard.EnterPricingDetails("3", "4");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(PartLengthPricingOption)).Click();
            ExtentTestManager.TestSteps("Click the part lengths pricing option");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewTrimMaterial()
        {
            SetupWizard.ClickTrim();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Trim Material");
            SetupWizard.EnterDescriptionInputField("Test Trim Material");
            SetupWizard.EnterWidthInputField("1");
            SetupWizard.EnterHeightInputField("1");
            SetupWizard.AddSystemTableElement("Asphalt Shingle");
            SetupWizard.AddUsageElement("Ridge Cap");
            SetupWizard.EnterPricingDetails("5", "6");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewConnectorsMaterial()
        {
            SetupWizard.ClickConnector();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Connectors Material");
            SetupWizard.EnterDescriptionInputField("Test Connectors Material");
            SetupWizard.EnterCostInputField("20");
            SetupWizard.EnterPriceInputField("30");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewFastenersMaterial()
        {
            SetupWizard.ClickFasteners();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Fastener Material");
            SetupWizard.EnterDescriptionInputField("Test Fastener Material");
            SetupWizard.EnterSupplierIDInputField("123");
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewHardwareMaterial()
        {
            SetupWizard.ClickHardware();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Hardware Material");
            SetupWizard.EnterDescriptionInputField("Test Hardware Material");
            SetupWizard.EnterSupplierIDInputField("123");
            SetupWizard.EnterSupplierSKUInputField("1456");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewLaborMaterial()
        {
            SetupWizard.ClickLabor();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Labor Material");
            SetupWizard.EnterDescriptionInputField("Test Labor Material");
            SetupWizard.EnterCostInputField("20");
            SetupWizard.EnterPriceInputField("30");
            SetupWizard.ClickSaveButton();
        }

        private void AddNewFreightMaterial()
        {
            SetupWizard.ClickFreight();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("Test Freight Material");
            SetupWizard.EnterDescriptionInputField("Test Freight Material");
            SetupWizard.EnterCostInputField("20");
            SetupWizard.EnterPriceInputField("30");
            SetupWizard.EnterSupplierIDInputField("5420");
            SetupWizard.EnterSupplierSKUInputField("320");
            SetupWizard.EnterPackagingCodeInputField("8547");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void EditNewCladdingMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Cladding Material")))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(EditMaterialButton)).Click();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new cladding material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("38");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("0.75");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("40");
            ExtentTestManager.TestSteps("Edit the maximum length of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the underlap length of the new cladding material");
            var OrientationDropdown = new SelectElement(Driver.FindElement(By.XPath("//select[@name='Orientation']")));
            OrientationDropdown.SelectByIndex(1);
            ExtentTestManager.TestSteps("Edit the orientation type of the new cladding material");
            var ColorMapDropdown = new SelectElement(Driver.FindElement(By.XPath("//select[@name='Texture']")));
            ColorMapDropdown.SelectByText("OC Amber");
            ExtentTestManager.TestSteps("Edit the color map of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "TextureSize"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("22");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureSizeReset"))).Click();
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("13");
            ExtentTestManager.TestSteps("Edit the color map size of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "TextureOffset"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("12");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureOffsetNone"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureOffsetHoriz"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureOffsetVert"))).Click();
            ExtentTestManager.TestSteps("Edit the color map offset of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "TextureRotation"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureRotateLeft"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureRotateUp"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureRotateRight"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnTextureRotateDown"))).Click();
            ExtentTestManager.TestSteps("Edit the color map rotation of the new cladding material");
            var BumpMapDropdown = new SelectElement(Driver.FindElement(By.XPath("//select[@name='BumpMap']")));
            BumpMapDropdown.SelectByText("Shingle Grey");
            ExtentTestManager.TestSteps("Edit the bump map of the new cladding material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapSizeReset"))).Click();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "BumpMapSize"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("1,5");
            ExtentTestManager.TestSteps("Edit the bump map size of the new cladding material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "BumpMapOffset"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5,5");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapOffsetNone"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapOffsetHoriz"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapOffsetVert"))).Click();
            ExtentTestManager.TestSteps("Edit the bump map offset of the new cladding material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapRotateLeft"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapRotateUp"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapRotateRight"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("btnBumpMapRotateDown"))).Click();
            ExtentTestManager.TestSteps("Edit the bump map rotation of the new cladding material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the cladding material");
        }

        private void EditNewTrimMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Trim Material")))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(EditMaterialButton)).Click();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new trim material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new trim material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new trim material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new trim material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the maximum length of the new trim material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new trim material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the trim material");
        }

        private void EditNewHardwareMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Hardware Material")))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(EditMaterialButton)).Click();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new hardware material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new hardware material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new hardware material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("25");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new hardware material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new hardware material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the maximum length of the new hardware material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the hardware material");
        }

        private void EditNewConnectorMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Connectors Material")))).Click();
            ClickOnEditMaterialButton();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new connector material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new connector material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("35");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new connector material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("27");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new connector material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new connector material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the maximum length of the new connector material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new connector material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the connector material");
        }

        private void EditNewFastenerMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Fastener Material")))).Click();
            ClickOnEditMaterialButton();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new fastener material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new fastener material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("27");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new fastener material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("25");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new fastener material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("27");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new fastener material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the maximum length of the new fastener material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new fastener material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the fastener material");
        }

        private void EditNewLaborMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Labor Material")))).Click();
            ClickOnEditMaterialButton();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new labor material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new labor material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new labor material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("25");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new labor material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("37");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new labor material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the maximum length of the new labor material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new labor material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the labor material");
        }

        private void EditNewFreightMaterialAdded()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NewMaterialAdded_MaterialPageTable, "Test Freight Material")))).Click();
            ClickOnEditMaterialButton();
            ExtentTestManager.TestSteps("Click on the edit button to edit the details of the new freight material added");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Description")))).SendKeys(" Data");
            ExtentTestManager.TestSteps("Edit the description of the new freight material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension1"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("35");
            ExtentTestManager.TestSteps("Edit the dimension 1 of the new freight material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension2"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("27");
            ExtentTestManager.TestSteps("Edit the dimension 2 of the new freight material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "Dimension3"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("35");
            ExtentTestManager.TestSteps("Edit the dimension 3 of the new freight material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "MaximumLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("2");
            ExtentTestManager.TestSteps("Edit the maximum length of the new freight material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EditMaterialInputBoxes, "UnderlapLength"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("5");
            ExtentTestManager.TestSteps("Edit the underlap length of the new freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveMaterialChangesButton)).Click();
            ExtentTestManager.TestSteps("Click save button to save the changes made to the freight material");
        }

        private void DeleteMaterialAdded()
        {
            HomePage.NavigateToSetupWizardPages();
            DeleteData();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private static void DeleteData()
        {
            SetupWizard.ClickCladding();
            SetupWizard.DeleteSetupWizardData("Test Cladding Material Data");
            SetupWizard.DeleteSetupWizardData("Test Cladding Material");
            SetupWizard.ClickTrim();
            SetupWizard.DeleteSetupWizardData("Test Trim Material Data");
            SetupWizard.DeleteSetupWizardData("Test Trim Material");
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("Test Fastener Material Data");
            SetupWizard.DeleteSetupWizardData("Test Fastener Material");
            SetupWizard.ClickConnector();
            SetupWizard.DeleteSetupWizardData("Test Connectors Material Data");
            SetupWizard.DeleteSetupWizardData("Test Connectors Material");
            SetupWizard.ClickFreight();
            SetupWizard.DeleteSetupWizardData("Test Freight Material Data");
            SetupWizard.ClickLabor();
            SetupWizard.DeleteSetupWizardData("Test Labor Material Data");
            SetupWizard.DeleteSetupWizardData("Test Labor Material");
            SetupWizard.ClickHardware();
            SetupWizard.DeleteSetupWizardData("Test Hardware Material Data");
            SetupWizard.DeleteSetupWizardData("Test Hardware Material");
        }

        public void ClickOnAddMaterialIcon()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(AddIcon)).Click();
            ExtentTestManager.TestSteps("Click on the Add icon");
        }

        public void AddSystems()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_SystemsItemsGrid_body']//tr[@class='w2ui-odd'])[2]"))).Click();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(AddSystemButton)).Click();
            ExtentTestManager.TestSteps("Add Asphalt Shingle system");
        }

        public void SaveNewMaterial()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(NewMaterialSaveBtn)).Click();
            ExtentTestManager.TestSteps("Click the save button to add the material");
        }

        public void ClickOnEditMaterialButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(EditMaterialButton));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click on the cladding material page tab option");
        }

        public void ClickOnTrimMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Trim")))).Click();
            ExtentTestManager.TestSteps("Click on the trim material page tab option");
        }

        public void ClickOnHardwareMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Hardware")))).Click();
            ExtentTestManager.TestSteps("Click on the hardware material page tab option");
        }

        public void ClickOnConnectorMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Connector")))).Click();
        }

        public void ClickOnFastenerMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Fastener")))).Click();
            ExtentTestManager.TestSteps("Click on the fastener material page tab option");
        }

        public void ClickOnLaborMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Labor")))).Click();
            ExtentTestManager.TestSteps("Click on the cladding labor page tab option");
        }

        public void ClickOnFreightMaterialTabOption()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPageTabOptions, "Freight")))).Click();
            ExtentTestManager.TestSteps("Click on the freight material page tab option");
        }

        public void DownloadMaterialTable_Excel()
        {
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(MaterialPageDownloadButton));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click the download button from the material table");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(DownloadMaterialTableOption, "XLSX")))).Click();
            ExtentTestManager.TestSteps("Select the XLSX option to download the excel file");
            CommonMethod.Wait(5);
        }

        public void VerifyChangesMadeToMaterials_Excel()
        {
            string excelFileName = "Materials-AUTOTEST_EAGLEVIEW BASE.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify that the XLSX file is downloaded");
            XSSFWorkbook Workbook = new XSSFWorkbook(File.Open(excelFilePath, FileMode.Open));
            var sheet = Workbook.GetSheetAt(0);
            if (sheet != null)
            {
                var RowsCount = 0;
                int LastRowNumber = sheet.LastRowNum;

                for (int i = 0; i <= 21; i++)
                {
                    IRow Cells = sheet.GetRow(0);
                    var Testfile = Cells.Cells[i];
                }

                string[] MaterialsAdded = new string[7] { "Test Trim Material", "Test Cladding Material", "Test Connectors Material", "Test Fasteners Material", "Test Hardware Material", "Test Labor Material", "Test Freight Material" };

                for (int j = 0; j < MaterialsAdded.Length;)
                {
                    for (int k = 0; k <= LastRowNumber; k++)
                    {
                        IRow currentRow = sheet.GetRow(k);
                        var testfile = currentRow.Cells[1];
                        if (testfile.ToString().Contains(MaterialsAdded[j]))
                        {
                            for (int l = 1; l <= 21; l++)
                            {
                                var matchbox = currentRow.Cells[l];
                                Console.WriteLine(matchbox.ToString());
                            }
                        }
                        RowsCount++;
                    }
                    RowsCount = 0;
                    j++;
                }
            }
            ExtentTestManager.TestSteps("Verify the new materials added are present in the excel file");
        }

        public void DownloadMaterialTable_Csv()
        {
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(MaterialPageDownloadButton));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click the download button from the material table");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(DownloadMaterialTableOption, "CSV")))).Click();
            ExtentTestManager.TestSteps("Select the CSV option to download the excel file");
            CommonMethod.Wait(5);
        }

        public void VerifyChangesMadeToMaterials_Csv()
        {
            string csvFileName = "Materials-AUTOTEST_EAGLEVIEW BASE.csv";
            string csvFilePath = Path.Combine(folderPath, csvFileName);
            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");

            string[] MaterialsAdded = new string[7] { "Test Trim Material", "Test Cladding Material", "Test Labor Material", "Test Hardware Material", "Test Connectors Material", "Test Fasteners Material", "Test Freight Material" };

            string SkuColumn = "SKU";
            using (var parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                // Read the header row
                string[] header = parser.ReadFields();

                // Find the column index for the specified column name
                int columnIndex = Array.IndexOf(header, SkuColumn);

                if (columnIndex != -1)
                {
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        string columnValue = fields[columnIndex];
                        // Check if the column value contains any of the names to find
                        if (ContainsAnyName(columnValue, MaterialsAdded))
                        {
                            Console.WriteLine(string.Join(",", fields));
                        }
                    }
                }
            }
            ExtentTestManager.TestSteps("Verify the new materials added are present in the csv file");
        }

        public bool ContainsAnyName(string columnValue, string[] namesToFind)
        {
            foreach (string name in namesToFind)
            {
                if (columnValue.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
#endregion