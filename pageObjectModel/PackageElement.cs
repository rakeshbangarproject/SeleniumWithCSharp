using Forms.Reporting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Pages_Application
{
    public class PackageElement : BaseClass
    {
        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.addNewButton)));
        }

        public static IWebElement BlankButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.blankButton)));
        }

        public static IWebElement GroupName()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.groupNameField)));
        }

        public static IWebElement PackageName()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.packageNameField)));
        }

        public static IWebElement YesButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.yesButton)));
        }

        public static IWebElement MainSaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.mainSaveButton)));
        }

        public static IWebElement PackageType()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.packageTypeDropdown)));
        }

        public static IWebElement Usage()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.usage)));
        }

         public static IWebElement DefaultSettingDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.defaultSettingDropdown)));
        }

        public static IWebElement AddCatalog()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.addCatalogButton)));
        }

        public static IWebElement AddMisc()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.addMiscButton)));
        }

        public static IWebElement OutputCategory()
        {
            return Driver.FindElement(By.XPath(Locator.Packages.outputCategory));
        }

        public static IWebElement CatalogCategory()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.catalogCategory)));
        }

        public static IWebElement SKUInputField()
        {
            return Driver.FindElement(By.XPath(Locator.Packages.skuInputField));
        }

        public static IWebElement CatalogItem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.catalogItem)));
        }

        public static IWebElement PriceField()
        {
            return Driver.FindElement(By.XPath(Locator.Packages.priceField));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.SaveButton)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.deleteButton)));
        }

        public static IWebElement UsageInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.usageInputField)));
        }

         public static IWebElement CalculationInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.calculationInputField)));
        }

        public static void ClicksTab(Func<IWebElement> methodName, string visibleElementPaths, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(visibleElementPaths)))
            {
                CommonMethod.GetActions().Click(methodName()).Perform();
            }

            ExtentTestManager.TestSteps($"Click on the '{elementName}' tab");
        }

        public static void ClickAddButton()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(0.5)).Click(AddButton()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Packages.waitForTheAddNewButtonVisible)));
            ExtentTestManager.TestSteps("Click on the add new button");
        }

        public static void ClickMainSaveButton()
        {
            CommonMethod.GetActions().Click(MainSaveButton()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Click on the save button");
        }

        public static void ClickBlankButton()
        {
            CommonMethod.GetActions().Click(BlankButton()).Perform();
            ExtentTestManager.TestSteps("Click on the blank button");
        }

        public static void GroupNameInputField(string groupName)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(GroupName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(groupName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {groupName} in the group name field");
        }

        public static void InfoTextField(string enterName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Info Text')]//following :: textarea[1]"))).SendKeys(enterName);
            ExtentTestManager.TestSteps("Enter data in the Info Text Field ");
            CommonMethod.Wait(1);
        }

        public static void PackageNameInputField(string packageName)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(PackageName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(packageName + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {packageName} in the package name field");
        }

         public static void UsageInputField(string usage)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(UsageInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(usage + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {usage} in the usage field");
        }

        public static void EnterCalculationInputField(string usage)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CalculationInputField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(usage + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {usage} in the calculation field");
        }

        public static void SelectPackageType(string packageType)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(PackageType()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdown(packageType);
            ExtentTestManager.TestSteps($"Select {packageType} from the packages type dropdown");
        }

        public static void SelectDefaultSetting(string packageType)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DefaultSettingDropdown()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdown(packageType);
            ExtentTestManager.TestSteps($"Select {packageType} from the default setting dropdown");
        }

        public static void SelectOutputCategory(string outputCategory)
        {
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(OutputCategory()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdown(outputCategory);
            ExtentTestManager.TestSteps($"Select {outputCategory} from the output category dropdown");
        }

        public static string GetTheOutputCategoryValue()
        {
            return OutputCategory().GetAttribute("title");
        }

        public static string GetTheSKUValue()
        {
            return SKUInputField().GetAttribute("value");
        }

        public static void ChangePackages(string changes)
        {
            SelectElement dropdownBump = new SelectElement(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.selectPackageType))));
            dropdownBump.SelectByText(changes);
            ExtentTestManager.TestSteps($"Change the {changes} Package from the ");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(2)).Perform();
        }

        public static void SelectCatalogCategory(string catalogCategory)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForPopupVisible)));
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CatalogCategory()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdown(catalogCategory);
            ExtentTestManager.TestSteps($"Select {catalogCategory} from the catalog category dropdown");
        }
        
        public static void SelectCatalogItem(string catalogItem)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForPopupVisible)));
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(CatalogItem()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdown(catalogItem);
            ExtentTestManager.TestSteps($"Select {catalogItem} from the catalog item dropdown");
        }

        public static string GetThePriceValue()
        {
            return PriceField().GetAttribute("value");
        }

        public static void SelectMaterialFromDropdown(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.CommonXPath.selectValueFromDropdown);
        }

        public static void ClickAddCatalogButton()
        {
            ClicksTab(AddCatalog, Locator.CommonXPath.waitForPopupVisible, "add catalog button");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the add misc button");
        }

        public static void ClickAddMiscButton()
        {
            CommonMethod.GetActions().Click(AddMisc()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForPopupVisible)));
            ExtentTestManager.TestSteps("Click on the add misc button");
        }

        // This method is used for the delete the New Entries from package table
        public static bool DeleteDataFromPackageTable(string name)
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath(string.Format(Locator.Packages.getTheElementFromPackageTable, name)));
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Perform();
                CommonMethod.GetActions().MoveToElement(DeleteButton()).Click().Perform();

                if (!CommonMethod.IsElementPresent(By.XPath(Locator.Packages.yesButton)))
                {
                    CommonMethod.GetActions().MoveToElement(DeleteButton()).Click().Perform();
                }

                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).MoveToElement(YesButton()).Click().Perform();
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
