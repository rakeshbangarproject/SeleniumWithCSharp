using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.pageObjectModel
{
    public class Materials : BaseClass
    {
        public static IWebElement EditButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.editButton)));
        }

        public static IWebElement Dimension1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.dimension1)));
        }

        public static IWebElement SkuInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.skuInputField)));
        }

        public static IWebElement SupplierIdInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.supplierIdInputField)));
        }

        public static IWebElement Dimension2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.dimension2)));
        }

        public static IWebElement SupplierSKUInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.supplierSKUInputField)));
        }

        public static IWebElement DescriptionInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.descriptionInputField)));
        }

        public static IWebElement BackToList()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.backToList)));
        }

        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.addButton)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.deleteButton)));
        }
        public static IWebElement DownloadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.DownloadButton)));
        }

        public static IWebElement EXcelButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.ExcelButton)));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.saveButton)));
        }

        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().Click(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        public static void SelectElementFromTable(string elementName)
        {
            CommonMethod.SelectMaterialFromDropdown(elementName, Locator.Materials.selectMaterialsFromTable);
            ExtentTestManager.TestSteps($"Click on the '{elementName}' element");
        }

        public static void ClickEditButton()
        {
            CommonMethod.GetActions().Click(EditButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Edit' button");
        }

        public static void ClickBackToListButton()
        {
            CommonMethod.GetActions().Click(BackToList()).Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Click on the 'Back to List' button");
        }

        public static void ClickOnTheMaterialElementAndEditButton(string materialName)
        {
            SelectElementFromTable(materialName);
            ClickEditButton();
        }

        public static string GetTheDimension1Value()
        {
            return Dimension1().GetAttribute("value");
        }

        public static string GetTheDimension2Value()
        {
            return Dimension2().GetAttribute("value");
        }

        public static void DeleteMaterialFromTable(string materialName)
        {
            CommonMethod.Wait(2);
            bool materialList = ClickElementFromMaterialTable(materialName);
            if (materialList)
            {
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DeleteButton()).Perform();
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(SetupWizard.YesButton()).Perform();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                CommonMethod.Wait(2);
            }
        }

        public static bool ClickElementFromMaterialTable(string materialName)
        {
            bool result = false;
            IReadOnlyList<IWebElement> row = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_grid_rec_')]//td[@col='2']//div"));

            foreach (IWebElement rowElement in row)
            {
                string cell = rowElement.Text;

                if (cell != null && cell.Contains(materialName))
                {
                    result = true;
                    CommonMethod.GetActions().Click(rowElement).Perform();
                }
            }

            return result;
        }

        public static void ClickAddButton()
        {
            CommonMethod.GetActions().Click(AddButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Add' button");
        }

        public static void EnterSKU(string value)
        {
            InputFields(SkuInputField, value, "SKU");
        }

        public static void EnterSupplierId(string value)
        {
            InputFields(SupplierIdInputField, value, "Supplier Id");

        }

        public static void EnterDimension2(string value)
        {
            InputFields(Dimension2, value, "Dimension 2");
        }

        public static void EnterDimension1(string value)
        {
            InputFields(Dimension1, value, "Dimension 1");
        }

        public static void EnterSupplierSKU(string value)
        {
            InputFields(SupplierSKUInputField, value, "Supplier SKU");
        }

        public static void EnterDescription(string value)
        {
            InputFields(DescriptionInputField, value, "Description");
        }

        public static void SelectFramingProfile(string value)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.framingProfile)));
            CommonMethod.SelectElement(CommonMethod.element).SelectByValue(value);
            ExtentTestManager.TestSteps($"Select {value} from the framing profile dropdown");
        }

        public static void SelectFramingColor(string value)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.framingColor)));
            CommonMethod.SelectElement(CommonMethod.element).SelectByValue(value);
            ExtentTestManager.TestSteps($"Select {value} from the framing color dropdown");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Save' button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void DownloadExcelFile()
        {
            CommonMethod.GetActions().Click(DownloadButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(EXcelButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Download the excel file");
        }
    }
}
