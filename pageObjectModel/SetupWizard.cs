using Forms.Reporting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartBuildAutomation.Pages_Application
{
    public class SetupWizard : BaseClass
    {
        private static WebDriverWait WaitForElement => new WebDriverWait(Driver, TimeSpan.FromSeconds(10));

        #region IWebElements
        public static IWebElement Extension()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.extension)));
        }

        public static IWebElement Cladding()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.cladding)));
        }

        public static IWebElement CladdingAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.claddingAssemblies)));
        }

        public static IWebElement FilterIcon()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.filterIcon)));
        }

        public static IWebElement HowManyInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.howManyInputField)));
        }

        public static IWebElement HomeIconButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.homeIconButton)));
        }

        public static IWebElement CheckAllCheckboxFromShownAndHideFrame()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.checkAllCheckboxFromShownAndHideFrame)));
        }

        public static IWebElement CheckTheCheckboxFromShownAndHideFrame(string checkboxName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.getTheAllCheckboxFromShowAndHideFrame, checkboxName))));
        }

        public static IWebElement ShownAndHideButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.shownAndHideButton)));
        }

        public static IWebElement ColorsTab()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ColorsTab)));
        }

        public static IWebElement Systems()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Systems)));
        }

        public static IWebElement Framing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Framing)));
        }

        public static IWebElement Sheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Sheathing)));
        }

        public static IWebElement Trim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Trim)));
        }

        public static IWebElement Foundation()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Foundation)));
        }

        public static IWebElement WalkDoors()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WalkDoors)));
        }

        public static IWebElement WalkDoorHardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WalkDoorHardware)));
        }

        public static IWebElement OverheadDoors()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.OverheadDoors)));
        }

        public static IWebElement OverheadHardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.OverheadHardware)));
        }

        public static IWebElement Sliders()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Sliders)));
        }

        public static IWebElement SliderHardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.SliderHardware)));
        }

        public static IWebElement Windows()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Windows)));
        }

        public static IWebElement StyleDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.styleDropdown)));
        }

        public static IWebElement WindowHardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WindowHardware)));
        }

        public static IWebElement EditButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.editButton)));
        }

        public static IWebElement Cupolas()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Cupolas)));
        }

        public static IWebElement CupolaHardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.CupolaHardware)));
        }

        public static IWebElement Connectors()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Connectors)));
        }

        public static IWebElement Fasteners()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Fasteners)));
        }

        public static IWebElement Hardware()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Hardware)));
        }

        public static IWebElement Labor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Labor)));
        }

        public static IWebElement Freight()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Freight)));
        }

        public static IWebElement SheathingAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.SheathingAssemblies)));
        }

        public static IWebElement TrimAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.TrimAssemblies)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.DeleteButton)));
        }

        public static IWebElement SearchElementInTheTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.SearchElementInTheTable)));
        }

        public static IWebElement PartLength()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.partLength)));
        }

        public static IWebElement SaveAllButton()
        {
            return Driver.FindElement(By.XPath(Locator.SetupWizard.SaveAllButton));
        }

        public static IWebElement YesButton()
        {
            return WaitForElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.YesButton)));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.SaveButton)));
        }

        public static IWebElement CancelButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.cancelButton)));
        }

        public static IWebElement CloneButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.CloneButton)));
        }

        public static IWebElement FirstRowElementOfTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.FirstRowElementOfTable)));
        }

        public static IWebElement ColorName()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ColorName)));
        }

        public static IWebElement CodeTransparency()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.CodeTransparency)));
        }

        public static IWebElement ColorCode()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ColorCode)));
        }

        public static IWebElement HEXCode()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.HEXCode)));
        }

        public static IWebElement ColorMap()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ColorMap)));
        }

        public static IWebElement BumpMap()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.BumpMap)));
        }

        public static IWebElement Color()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Color)));
        }

        public static IWebElement Profile()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.Profile)));
        }

        public static IWebElement SelectElementFromHexCodeColors(string name)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.GetTheHexCodeName, name))));
        }

        public static IWebElement ClickFirstElementAfterSearch(string elementName)
        {
            return Driver.FindElement(By.XPath(string.Format(Locator.SetupWizard.AfterSearchClickFirstElement, elementName)));
        }

        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.AddButtonOfTable)));
        }

        public static IWebElement UsageTableSearchField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.usageTableSearchField)));
        }

        public static IWebElement SystemsTableSearchField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.systemTableSearchField)));
        }

        public static IWebElement SKUInputField()
        {
            return Driver.FindElement(By.XPath(Locator.SetupWizard.SKUInputField));
        }

        public static IWebElement NameInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.NameInputField)));
        }

        public static IWebElement DescriptionInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.DescriptionInputField)));
        }

        public static IWebElement SupplierIDInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.supplierId)));
        }

        public static IWebElement SupplierSKUInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.supplierSku)));
        }

        public static IWebElement PackagingCodeInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.packagingCode)));
        }

        public static IWebElement CostInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.cost)));
        }

        public static IWebElement PriceInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.price)));
        }

        public static IWebElement RemoveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.removeButton)));
        }

        public static IWebElement WidthInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WidthInputField)));
        }

        public static IWebElement HeightInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.HeightInputField)));
        }

        public static IWebElement RoofPitchInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.roofPitch)));
        }

        public static IWebElement Depth()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.DepthInputField)));
        }

        public static IWebElement FirstElementOfUsageTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.FirstElementOfUsageTable)));
        }

        public static IWebElement FirstElementOfSystemTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.FirstElementOfSystemTable)));
        }

        public static IWebElement CoverageWidth()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.coverageWidth)));
        }

        public static IWebElement FullWidth()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.fullWidth)));
        }

        public static IWebElement UnderlapLength()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.underlapLength)));
        }

        public static IWebElement MaximumLength()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.maximumLength)));
        }

        public static IWebElement MinimumCutLength()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.minimumCutLength)));
        }

        public static IWebElement Thickness()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.thickness)));
        }

        public static IWebElement AddButtonOfUsageTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.AddButtonOfUsageTable)));
        }

        public static IWebElement AddButtonOfSystemTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.AddButtonOfSystemTable)));
        }

        public static IWebElement KeysInput()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.keysInputField)));
        }

        public static IWebElement PrimaryDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.primaryDropdown)));
        }

        public static IWebElement AddButtonOfPricingTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.addButtonOfPricingTable)));
        }

        public static IWebElement PartLengthColumns(int index)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.partLengthColumn, index))));
        }

        public static IWebElement ColorButtonOfPricingTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.colorButtonOfPricingTable)));
        }

        public static IWebElement AddNewButtonOfAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.addNewButtonOfAssemblies)));
        }

        public static IWebElement TypeDropdownOfAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.typeDropdown)));
        }

        public static IWebElement CatalogCategoryDropdownOfAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.outputCategoryDropdown)));
        }

        public static IWebElement MaterialButtonOfAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.materialButtonOfAssemblies)));
        }

        public static IWebElement CatalogCategoryOfAssembliesDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.catalogCategoryOfAssemblies)));
        }

        public static IWebElement InputSearchFieldOfCatalogCategoryAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.inputSearchFieldOfCatalogCategoryAssemblies)));
        }

        public static IWebElement LengthFieldOfAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.lengthFieldOfAssemblies)));
        }

        public static IWebElement EditButtonOfEntriesAssemblies()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.editButtonOfEntriesAssemblies)));
        }

        public static IWebElement RestoreButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.restoreButton)));
        }
        #endregion

        #region Select Element from usage and system tables 
        public static void SelectAllElementFromUsageTable()
        {
            CommonMethod.GetActions().Click(FirstElementOfUsageTable()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            CommonMethod.GetActions().Click(AddButtonOfUsageTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Select All element from usage table");
        }

        public static void SelectAllElementFromSystemTable()
        {
            CommonMethod.GetActions().Click(FirstElementOfSystemTable()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).Perform();
            CommonMethod.GetActions().Click(AddButtonOfSystemTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Select All element from usage table");
        }

        public static void AddSystemTableElement(string elementName)
        {
            CommonMethod.GetActions().Click(SystemsTableSearchField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(elementName + Keys.Enter).Perform();
            CommonMethod.GetActions().Click(FirstElementOfSystemTable()).Perform();
            CommonMethod.GetActions().Click(AddButtonOfSystemTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Select {elementName} element from system table");
        }

        public static void AddUsageElement(string elementName)
        {
            CommonMethod.GetActions().Click(UsageTableSearchField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(elementName + Keys.Enter).Perform();
            CommonMethod.GetActions().Click(FirstElementOfUsageTable()).Perform();
            CommonMethod.GetActions().Click(AddButtonOfUsageTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Select {elementName} element from usage table");
        }
        #endregion

        #region InputFields
        public static void EnterSKUInputField(string skuName)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(SKUInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(skuName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {skuName} in the sku input field");
        }

        public static void EnterCoverageWidthInputField(string coverageWidth)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CoverageWidth()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(coverageWidth + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {coverageWidth} in the coverage width input field");
        }

        public static void EnterFullWidthInputField(string fullWidth)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(FullWidth()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(fullWidth + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {fullWidth} in the full width input field");
        }

        public static void EnterUnderlapLengthInputField(string underlapLengthValue)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(UnderlapLength()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(underlapLengthValue + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {underlapLengthValue} in the underlap length input field");
        }

        public static void EnterCostInputField(string underlapLengthValue)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CostInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(underlapLengthValue + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {underlapLengthValue} in the cost input field");
        }

        public static void EnterPriceInputField(string underlapLengthValue)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(PriceInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(underlapLengthValue + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {underlapLengthValue} in the price input field");
        }

        public static void EnterMaximumLengthInputField(string maximumLengthValue)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(MaximumLength()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(maximumLengthValue + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {maximumLengthValue} in the maximum length input field");
        }

        public static void EnterMinimumCutLengthInputField(string maximumLengthValue)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(MinimumCutLength()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(maximumLengthValue + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {maximumLengthValue} in the maximum length input field");
        }

        public static void EnterHowManyInputField(string howMany)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(HowManyInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(howMany + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {howMany} in the hom many input field");
        }

        public static void EnterDescriptionInputField(string description)
        {
            CommonMethod.GetActions().Click(DescriptionInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(description + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {description} in the description input field");
        }

        public static void EnterExtensionInputField(string description)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(Extension()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(description + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {description} in the extension input field");
        }

        public static void EnterThicknessInputField(string thickness)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(Thickness()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(thickness + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {thickness} in the thickness input field");
        }

        public static void EnterWidthInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(WidthInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the width input field");
        }

        public static void EnterHeightInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(HeightInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the width input field");
        }

        public static void EnterRoofPitchInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(RoofPitchInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the roof pitch input field");
        }

        public static void EnterSupplierIDInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(SupplierIDInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the supplier Id input field");
        }

        public static void EnterSupplierSKUInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(SupplierSKUInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the supplier sku input field");
        }

        public static void EnterPackagingCodeInputField(string widthName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(PackagingCodeInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(widthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {widthName} in the Packaging Code input field");
        }

        public static void EnterDepthInputField(string depthName)
        {
            CommonMethod.GetActions().Click(Depth()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(depthName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {depthName} in the depth input field");
        }
        #endregion

        public static void ClickTab(Func<IWebElement> tab, string tabName)
        {
            CommonMethod.GetActions().Click(tab()).Pause(TimeSpan.FromSeconds(1)).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.SetupWizard.AddButtonOfTable)))
            {
                CommonMethod.GetActions().Click(tab()).Pause(TimeSpan.FromSeconds(1)).Perform();
            }

            ExtentTestManager.TestSteps($"Click on the '{tabName}' tab");
        }

        #region Slider
        public static void ClickSlider()
        {
            ClickTab(Sliders, "Slider");
        }
        #endregion 

        #region Slider Hardware
        public static void ClickSliderHardware()
        {
            ClickTab(SliderHardware, "Slider Hardware");
        }
        #endregion

        #region Overhead 
        public static void ClickOverheadDoors()
        {
            ClickTab(OverheadDoors, "Overhead Doors");
        }
        #endregion 

        #region Overhead Hardware
        public static void ClickOverheadHardware()
        {
            ClickTab(OverheadHardware, "Overhead Hardware");
        }
        #endregion 

        #region Hardware
        public static void ClickHardware()
        {
            ClickTab(Hardware, "Freight");
        }
        #endregion  

        #region Labor
        public static void ClickLabor()
        {
            ClickTab(Labor, "Labor");
        }
        #endregion

        #region Freight
        public static void ClickFreight()
        {
            ClickTab(Freight, "Freight");
        }
        #endregion

        #region Cupola 
        public static void ClickCupolas()
        {
            ClickTab(Cupolas, "Cupolas");
        }
        #endregion

        #region Cupola Hardware 
        public static void ClickCupolaHardware()
        {
            ClickTab(CupolaHardware, "Cupola Hardware");
        }
        #endregion

        #region Connector
        public static void ClickConnector()
        {
            ClickTab(Connectors, "Connector");
        }
        #endregion

        #region System 
        public static void ClickSystems()
        {
            ClickTab(Systems, "System");
        }

        public static void RemoveElementFromUsageTable(string elementName)
        {
            CommonMethod.Wait(2);
            IWebElement firstElementOfRemove = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.leftSideOfUsageTale, elementName))));
            CommonMethod.GetActions().Click(firstElementOfRemove).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(RemoveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Remove {elementName} element from usage table");
        }

        public static void KeysInputField(string keys)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(KeysInput()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(keys + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {keys} in the keys input field");
        }
        #endregion

        #region Framing Elements
        public static void ClickFraming()
        {
            CommonMethod.GetActions().Click(Framing()).Pause(TimeSpan.FromSeconds(1)).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.SetupWizard.AddButtonOfTable)))
            {
                CommonMethod.GetActions().Click(Framing()).Pause(TimeSpan.FromSeconds(1)).Perform();
            }
            ExtentTestManager.TestSteps("Click on the 'Framing' tab");
        }
        #endregion

        #region Windows Hardware
        public static void ClickWindowHardware()
        {
            ClickTab(WindowHardware, "Window Hardware");
        }
        #endregion

        #region Colors Element
        public static void ClickColors()
        {
            ClickTab(ColorsTab, "Colors");
        }

        public static void ColorNameInputField(string value)
        {
            CommonMethod.GetActions().Click(ColorName()).Pause(TimeSpan.FromSeconds(1)).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the color name field");
        }

        public static void CodeTransparencyInputField(string value)
        {
            CommonMethod.GetActions().Click(CodeTransparency()).Pause(TimeSpan.FromSeconds(1)).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the color transparency input field");
        }

        public static void ColorCodeInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(ColorCode()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the Color Code field");
        }

        public static void ClickHEXCode()
        {
            CommonMethod.GetActions().Click(HEXCode()).Perform();
        }

        public static void SelectHexCode(string value)
        {
            try
            {
                ClickHEXCode();
                SelectElementFromHexCodeColors(value);
            }
            catch (Exception)
            {
                ClickHEXCode();
                SelectElementFromHexCodeColors(value);
            }

            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.colorMapText))).Click();
            ExtentTestManager.TestSteps($"Select color from hex code");
        }

        public static void SelectColorMap(string materialName)
        {
            CommonMethod.GetActions().Click(ColorMap()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(materialName);
            Driver.FindElement(By.XPath("//label[text()='Color Map']")).Click();
            ExtentTestManager.TestSteps($"Select {materialName} element from color map dropdown");
        }

        public static void SelectBumpMap(string materialName)
        {
            CommonMethod.GetActions().Click(BumpMap()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(materialName);
            Driver.FindElement(By.XPath("//label[text()='Color Map']")).Click();
            ExtentTestManager.TestSteps($"Select {materialName} element from bump map dropdown");
        }

        public static void SelectColor(string materialName)
        {
            CommonMethod.GetActions().Click(Color()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} element from color dropdown");
        }

        public static void SelectProfile(string materialName)
        {
            CommonMethod.GetActions().Click(Profile()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} element from profile dropdown");
        }
        #endregion

        #region Sheathing 
        public static void ClickSheathing()
        {
            ClickTab(Sheathing, "Sheathing");
        }

        public static void ClickPartLength()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.pricingText))).Click();
            CommonMethod.GetActions().Click(PartLength()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Part Length' button");
        }

        public static void ClickColorButtonOfPricingTable()
        {
            CommonMethod.GetActions().Click(ColorButtonOfPricingTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void ClickAddButtonOfPricingTable()
        {
            CommonMethod.GetActions().Click(AddButtonOfPricingTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
        }
        #endregion

        #region Trim
        public static void ClickTrim()
        {
            ClickTab(Trim, "Trim");
        }
        #endregion

        #region WalkDoor
        public static void ClickWalkDoorHardware()
        {
            ClickTab(WalkDoorHardware, "WalkDoor Hardware");
        }
        #endregion

        #region Trim Assemblies
        public static void ClickTrimAssemblies()
        {
            CommonMethod.GetActions().Click(TrimAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Trim Assemblies' tab");
        }

        public static void EnterPricingDetailsOfTrim(string CostColValue, string PriceColValue)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.costAndPriceColumnOfTrim, 5))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys(CostColValue).Perform();
            ExtentTestManager.TestSteps("Enter the cost in the pricings table");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.costAndPriceColumnOfTrim, 6))));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys(PriceColValue).Perform();
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price in the pricings table");
        }

        public static void ClickAddNewButtonOfAssemblies()
        {
            CommonMethod.GetActions().Click(AddNewButtonOfAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Add New' button");
        }

        public static void ClickMaterialButtonOfAssemblies()
        {
            CommonMethod.GetActions().Click(MaterialButtonOfAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Material' button");
        }

        public static void SearchFieldOfCatalogCategoryAssemblies(string elementName)
        {
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(InputSearchFieldOfCatalogCategoryAssemblies()).SendKeys(elementName + Keys.Enter).Perform();
        }

        public static void SelectCatalogCategoryOfAssembliesDropdown(string elementName)
        {
            CommonMethod.GetActions().Click(CatalogCategoryOfAssembliesDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} element from the catalog category dropdown");
        }

        public static void SelectMaterialFromSheathingAssemblies(string MaterialName, string elementName)
        {
            // Click on the Material button
            ClickMaterialButtonOfAssemblies();
            SelectCatalogCategoryOfAssembliesDropdown(MaterialName);
            SearchFieldOfCatalogCategoryAssemblies(elementName);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.firstElementOfCatalogTable)));
            CommonMethod.GetActions().DoubleClick(CommonMethod.element).Perform();
            ExtentTestManager.TestSteps($"Select {elementName} of {MaterialName} from table");
            CommonMethod.Wait(1);
        }

        public static void SelectLengthOfAssemblies(string lengthMaterial)
        {
            CommonMethod.GetActions().Click(LengthFieldOfAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(lengthMaterial);
            ExtentTestManager.TestSteps($"Select {lengthMaterial} from the length dropdown");
        }

        public static string GetTheLengthValue()
        {
            return LengthFieldOfAssemblies().GetAttribute("title");
        }

        public static void SelectTypeOfAssemblies(string typeMaterial)
        {
            CommonMethod.GetActions().Click(TypeDropdownOfAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(typeMaterial);
            ExtentTestManager.TestSteps($"Select {typeMaterial} from the type dropdown");
        }

        public static void SelectOutputCategoryOfAssemblies(string outputMaterial)
        {
            CommonMethod.GetActions().Click(CatalogCategoryDropdownOfAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(outputMaterial);
            ExtentTestManager.TestSteps($"Select {outputMaterial} from the output category dropdown");
        }

        public static void OpenNewlyCreatedEntriesOfAssembliesTable(string element)
        {
            ClickOnTheAssembliesEntries(element);
            CommonMethod.GetActions().Click(EditButtonOfEntriesAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {element}  and click on the edit button");
        }
        #endregion

        #region Sheathing Assemblies
        public static void ClickSheathingAssemblies()
        {
            CommonMethod.GetActions().Click(SheathingAssemblies()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Sheathing Assemblies' tab");
        }

        public static void NameInputField(string name)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)));
            CommonMethod.GetActions().Click(NameInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(name + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {name} in the name input field");
        }

        public static void SelectPrimaryMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(PrimaryDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the primary dropdown");
        }
        #endregion

        #region Windows 
        public static void ClickWindows()
        {
            ClickTab(Windows, "Windows");
        }

        public static void SelectStyleElement(string style)
        {
            CommonMethod.GetActions().Click(StyleDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdown(style);
            ExtentTestManager.TestSteps($"Select {style} from the style dropdown");
        }
        #endregion

        #region WalkDoor
        public static void ClickWalkDoors()
        {
            ClickTab(WalkDoors, "WalkDoors");
        }
        #endregion

        #region Fasteners 
        public static void ClickFasteners()
        {
            ClickTab(Fasteners, "Fasteners");
        }
        #endregion

        #region Foundation 
        public static void ClickFoundation()
        {
            ClickTab(Foundation, "Foundation");
        }
        #endregion

        #region Cladding 
        public static void ClickCladding()
        {
            ClickTab(Cladding, "Cladding");
        }
        #endregion

        #region Cladding Assemblies 
        public static void ClickCladdingAssemblies()
        {
            ClickTab(CladdingAssemblies, "Cladding Assemblies");
        }
        #endregion

        public static void ClickDeleteButtonAndYesButton()
        {
            CommonMethod.GetActions().Click(DeleteButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.confirmation)));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(YesButton()).Perform();
            CommonMethod.Wait(2);
        }

        public static void DeleteSetupWizardData(string elementName)
        {
            try
            {
                SearchElement(elementName, "2");
                ClickDeleteButtonAndYesButton();
                ExtentTestManager.TestSteps($"Delete {elementName} data from setup wizard");
            }
            catch (NoSuchElementException)
            {
                SearchElementInTheTable().Clear();
            }
        }

        public static void ClickFilterIcon()
        {
            CommonMethod.GetActions().MoveToElement(FilterIcon()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the filter icon");
        }

        public static void SearchElement(string elementName, string col)
        {
            CommonMethod.GetActions().MoveToElement(SearchElementInTheTable()).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys(elementName + Keys.Enter).Perform();
            CommonMethod.Wait(2);

            bool result = false;
            IList<IWebElement> row = Driver.FindElements(By.XPath(Locator.SetupWizard.geTheLineNumberOfTable));

            foreach (IWebElement rowElement in row)
            {
                string lineNumber = rowElement.GetAttribute("line");

                if (lineNumber.Equals("bottom"))
                {
                    Driver.FindElement(By.XPath(Locator.HomePage.startFromScratch));
                    break;
                }

                if (lineNumber != null && !lineNumber.Equals("0") && !lineNumber.Equals("top"))
                {
                    IList<IWebElement> getMaterialText = Driver.FindElements(By.XPath(string.Format(Locator.SetupWizard.findElementForDelete, lineNumber, col)));

                    foreach (IWebElement getMaterialElement in getMaterialText)
                    {
                        string getElement = getMaterialElement.Text;

                        if (getElement.Equals(elementName))
                        {
                            result = true;
                            CommonMethod.GetActions().Click(getMaterialElement).Perform();
                            break;
                        }
                    }
                }

                if (result)
                {
                    break;
                }
            }
        }

        public static IWebElement OkayButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.OkayButton)));
        }

        public static void ClickOkayButtonAfterClickOnSaveButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-message0']//button"))).Click();
        }

        public static void ClickRestoreButton()
        {
            try
            {
                CommonMethod.GetActions().MoveToElement(RestoreButton()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            }
            catch (Exception)
            {
                CommonMethod.GetActions().MoveToElement(RestoreButton()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            }

            ExtentTestManager.TestSteps("Click on the restore button");
            CommonMethod.GetActions().MoveToElement(YesButton()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the yes button");
        }

        public static void ClickAddButton()
        {
            CommonMethod.GetActions().MoveToElement(AddButton()).Click().Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.SetupWizard.WaitForFrameVisibleAfterClicksAddButton)))
            {
                CommonMethod.GetActions().MoveToElement(AddButton()).Click().Perform();
            }

            CommonMethod.Wait(1);
            ExtentTestManager.TestSteps("Click on the add button");
        }

        #region Save Data In The Setup Wizard
        public static void SaveDataInTheSetupWizard()
        {
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", SaveAllButton());
            CommonMethod.Wait(2);
            PerformActionAfterClickOnTheSaveAllButton();
            ExtentTestManager.TestSteps("Save the Data in the Setup Wizard");
        }

        public static void PushUsageChangesToBuilderInSetupWizard()
        {
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", SaveAllButton());
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='pushUsages']"))).Click();
            PerformActionAfterClickOnTheSaveAllButton();
            ExtentTestManager.TestSteps("Save the data in the setup wizard using 'Push Usage Changes to Builders'.");
        }

        private static void PerformActionAfterClickOnTheSaveAllButton()
        {
            try
            {
                string buttonName = WaitForElement.Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.GetTheButtonName))).Text;

                if (buttonName.Equals("Save"))
                {
                    CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", SaveButton());
                    ClickYesButtonAndWaitForTheOkayButtonVisible();
                }
                else if (buttonName.Equals("Yes"))
                {
                    ClickYesButtonAndWaitForTheOkayButtonVisible();
                }
                else if (buttonName.Equals("Ok"))
                {
                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.JobPage.WaitForTheSpinner)));
                    CommonMethod.GetActions().MoveToElement(OkayButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                }
                else
                {
                    CommonMethod.GetActions().MoveToElement(OkayButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                }
            }
            catch
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.JobPage.WaitForTheSpinner)));
                CommonMethod.GetActions().MoveToElement(OkayButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            }
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().MoveToElement(SaveButton()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the save button");
        }
        #endregion

        public static void ClickHomeIconButton()
        {
            CommonMethod.GetActions().MoveToElement(HomeIconButton()).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.shownAndHideButton)));
            ExtentTestManager.TestSteps("Click on the home icon button");
        }

        public static void ClickShownAndHideButton()
        {
            CommonMethod.GetActions().MoveToElement(ShownAndHideButton()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the shown and hide button");
        }

        public static void CheckTheCheckBoxFromHideAndShownFrame(string checkboxName)
        {
            CommonMethod.GetActions().MoveToElement(CheckAllCheckboxFromShownAndHideFrame()).Click().Perform();
            ExtentTestManager.TestSteps("Uncheck on the all checkbox");
            CommonMethod.GetActions().MoveToElement(CheckTheCheckboxFromShownAndHideFrame(checkboxName)).Click().Perform();
            ExtentTestManager.TestSteps($"Check on the {checkboxName} checkbox");
        }

        public static void ClickCancelButton()
        {
            CommonMethod.GetActions().MoveToElement(CancelButton()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the cancel button");
        }

        private static void ClickYesButtonAndWaitForTheOkayButtonVisible()
        {
            CommonMethod.GetActions().MoveToElement(YesButton()).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.JobPage.WaitForTheSpinner)));
            CommonMethod.GetActions().MoveToElement(OkayButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void ClickOnFirstElementThenClickOnCloneIcon()
        {
            CommonMethod.GetActions().MoveToElement(FirstRowElementOfTable()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the first material of table");
            CommonMethod.GetActions().MoveToElement(CloneButton()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the clone button");
        }

        public static void SearchElementAndClickOnTheEdit(string elementName)
        {
            SearchElement(elementName, "2");
            CommonMethod.GetActions().MoveToElement(EditButton()).Click().Perform();
            ExtentTestManager.TestSteps($"{elementName} search in the table and click on the edit button");
        }

        public static void DeleteFromSystemTableData(string elementName)
        {
            try
            {
                SearchElement(elementName, "1");
                ClickDeleteButtonAndYesButton();
                ExtentTestManager.TestSteps($"Delete {elementName} data from setup wizard");
            }
            catch (NoSuchElementException)
            {
                SearchElementInTheTable().Clear();
            }
        }

        public static void CheckNewEntries(string elementName, string EnterIfStatement, string EnterElseStatement)
        {
            CommonMethod.GetActions().MoveToElement(SearchElementInTheTable()).Click().Pause(TimeSpan.FromSeconds(1)).SendKeys(elementName + Keys.Enter).Perform();
            CommonMethod.Wait(2);
            string getData = ClickFirstElementAfterSearch(elementName).Text;
            CommonMethod.Wait(2);

            if (getData.Contains(elementName))
            {
                ExtentTestManager.TestSteps(EnterIfStatement);
            }
            else
            {
                ExtentTestManager.TestSteps(EnterElseStatement);
                Assert.Fail(EnterElseStatement);
            }
        }

        public static void CheckAfterUploadFileInTheSetupWizardMessage(string frameMessage, string trueStatement, string falselStatement)
        {
            string popUpMessage = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.GetTheTextAfterUploadFile))).Text;

            if (popUpMessage.Contains(frameMessage))
            {
                ExtentTestManager.TestSteps($"{trueStatement}\n Messages: {popUpMessage}");
                Console.WriteLine($"{trueStatement}\n Messages: {popUpMessage}");
            }
            else
            {
                Assert.Fail($"{falselStatement}\n Messages: {popUpMessage}");
            }

            CommonMethod.GetActions().MoveToElement(OkayButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on Ok button");
        }

        #region Download Files and Upload 
        public static IWebElement DownloadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.DownloadButton)));
        }
        public static IWebElement UploadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.UploadButton)));
        }

        public static IWebElement ExcelButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ExcelButton)));
        }

        public static IWebElement CSVButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.CSVButton)));
        }
        public static IWebElement ChooseFile()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.ChooseFile)));
        }

        public static void DownloadTheExcelFile()
        {
            CommonMethod.GetActions().MoveToElement(DownloadButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForTheDownloadButtonVisible)));
            CommonMethod.GetActions().MoveToElement(ExcelButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WaitForTHeSubMenuVisible)));
            ExtentTestManager.TestSteps("Click on the download button and download excel file");
        }

        public static void DownloadTheCSVFile()
        {
            CommonMethod.GetActions().MoveToElement(DownloadButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForTheDownloadButtonVisible)));
            CommonMethod.GetActions().MoveToElement(CSVButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WaitForTHeSubMenuVisible)));
            ExtentTestManager.TestSteps("Click on the download button and download csv file");
        }

        public static void UploadFile(string filePath)
        {
            CommonMethod.GetActions().MoveToElement(UploadButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ChooseFile().SendKeys(filePath);
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.SetupWizard.WaitForTHeSubMenuVisible)));
        }
        #endregion

        public static string GetCheckboxPaths(string columnName)
        {
            string getHeaderNameXPaths = "//div[@id='grid_grid_columns']//tr[3]//td[@class='w2ui-head ' and @onclick]";
            IList<IWebElement> totalNumberOfColumn = Driver.FindElements(By.XPath(getHeaderNameXPaths));

            foreach (IWebElement element in totalNumberOfColumn)
            {
                string getTheHeaderAttribute = element.GetAttribute("onclick");

                if (getTheHeaderAttribute.Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    // Get the column count and return it
                    string columnCount = element.GetAttribute("col");
                    return columnCount;
                }
            }
            return null;
        }


        public static IWebElement CheckboxFromHouseGridField(string columnName, string materialName)
        {
            string colCount = GetCheckboxPaths(columnName);
            string checkboxInputPath = $"(//tr[contains(@id,'grid_grid_rec_')]//td[2]/div[text()='{materialName}']//following::td[@col='{colCount}']//input)[1]";
            IWebElement element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(checkboxInputPath)));
            return element;
        }

        public static void HouseGridCheckboxCheck(string columnName, string materialName)
        {
            if (!CheckboxFromHouseGridField(columnName, materialName).Selected)
            {
                CheckboxFromHouseGridField(columnName, materialName).Click();
            }

            ExtentTestManager.TestSteps($"Check the {materialName} material checkbox from the {columnName} column in the house grid of setup wizard");
        }

        public static void HouseGridCheckboxUncheck(string columnName, string materialName)
        {
            if (CheckboxFromHouseGridField(columnName, materialName).Selected)
            {
                CheckboxFromHouseGridField(columnName, materialName).Click();
            }

            ExtentTestManager.TestSteps($"Uncheck the {materialName} material checkbox from the {columnName} column in the house grid of setup wizard");
        }

        public static void CheckCheckboxIsCheck(string columnName, string materialName)
        {
            Assert.That(!CheckboxFromHouseGridField(columnName, materialName).Selected, Is.False, $"Error: {materialName} is not check in the {columnName} of house grid setup wizard");
        }

        public static void CheckCheckboxIsUncheck(string columnName, string materialName)
        {
            Assert.That(CheckboxFromHouseGridField(columnName, materialName).Selected, Is.True, $"Error: {materialName} is not check in the {columnName} of house grid setup wizard");
        }

        public static void ModifyTheLastRowOfCSVFile(string downloadCSVFile, string data, int columnNumber)
        {
            // Read the contents of the CSV file into a string array
            string[] lines = File.ReadAllLines(downloadCSVFile);

            // Split the last line of the array into its individual columns
            string[] columns = lines.Last().Split(',');

            // Edit the values in the desired columns
            columns[columnNumber] = data;

            // Update the last line of the CSV file with the edited values
            lines[lines.Length - 1] = string.Join(",", columns);

            // Save the updated contents back to the CSV file
            File.WriteAllLines(downloadCSVFile, lines);
        }

        public static int GetLastRowOfColumnByColumnName(string filePath, string columnName, string searchTerm)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    XSSFWorkbook workbook = new XSSFWorkbook(fileStream);
                    var sheet = workbook.GetSheetAt(0); // Assuming the data is on the first sheet

                    int columnCount = sheet.GetRow(0).LastCellNum;
                    int columnIndex = -1;

                    // Find the column index by matching the column name
                    for (int i = 0; i < columnCount; i++)
                    {
                        if (sheet.GetRow(0).GetCell(i).StringCellValue.Equals(columnName, StringComparison.OrdinalIgnoreCase))
                        {
                            columnIndex = i;
                            break;
                        }
                    }

                    if (columnIndex != -1)
                    {
                        int rowCount = sheet.LastRowNum + 1;

                        // Search for the specified name in the column
                        for (int row = 1; row < rowCount; row++) // Start from row 1 to skip the header
                        {
                            var cellValue = sheet.GetRow(row).GetCell(columnIndex).StringCellValue;
                            if (cellValue.Equals(searchTerm, StringComparison.OrdinalIgnoreCase))
                            {
                                return row;
                            }
                        }

                        return -1;
                    }
                    else
                    {
                        Console.WriteLine($"Column '{columnName}' not found in the Excel file.");
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the Excel file: {ex.Message}");
                return -1;
            }
        }

        public static void UpdateTheDataOfExcelSheetLastRow(string excelFilePath, string data, int cellNumber, string fistElement)
        {
            using (var fs = new FileStream(excelFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fs);
                ISheet sheet = workbook.GetSheetAt(0);

                int lastRowNum = sheet.LastRowNum;
                string editField = data;

                XSSFRow dataRow = (XSSFRow)sheet.GetRow(lastRowNum);
                dataRow.Cells[1].SetCellValue(fistElement);
                dataRow.Cells[cellNumber].SetCellValue(editField);

                using (FileStream stream = new FileStream(excelFilePath, FileMode.Create, FileAccess.Write))
                {
                    workbook.Write(stream);
                }
            }
        }

        public static string ScrollDownSubTableAndCheckMaterialDataIsShown()
        {
            // Click on the first row of the Sheathing table
            CommonMethod.GetActions().MoveToElement(FirstRowElementOfTable()).Click().Perform();
            ExtentTestManager.TestSteps("Click on the First row of Sheathing table");
            CommonMethod.Wait(3);

            // Scroll to the bottom of the Color Code Table
            EventFiringWebDriver eventFiringWebDriver = new(Driver);
            eventFiringWebDriver.ExecuteScript(Locator.SetupWizard.ScrollDownTheSubTableData);

            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id(Locator.SetupWizard.GetTheAllDatFromSubTable))).Text;
        }

        public static void SelectMaterialFromDropdown(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.CommonXPath.selectValueFromDropdown);
        }

        public static void EnterPricingDetails(string CostColValue, string PriceColValue)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.materialPricingsTableInputBox, CostColValue))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys("10").Perform();
            ExtentTestManager.TestSteps("Enter the cost in the pricings table");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.SetupWizard.materialPricingsTableInputBox, PriceColValue))));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys("20").Perform();
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price in the pricings table");
        }

        public static void ClickOnTheAssembliesEntries(string elementName)
        {
            CommonMethod.Wait(1);

            IList<IWebElement> totalEntries = Driver.FindElements(By.XPath(Locator.SetupWizard.entriesOfAssemblies));

            foreach (IWebElement entry in totalEntries)
            {
                string nameOfRows = entry.Text;

                if (nameOfRows.Equals(elementName))
                {
                    CommonMethod.GetActions().Click(entry).Perform();
                    break;
                }
            }
        }
    }
}