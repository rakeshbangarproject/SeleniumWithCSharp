using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.pageObjectModel
{
    public class OutputCategories : BaseClass
    {
        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.addButton)));
        }

        public static IWebElement LastRowInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.lastInputField)));
        }

        public static IWebElement MoveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.moveButton)));
        }

        public static IWebElement NameOfOutputCategoriesOption(string elementName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.OutputCategories.nameOfOutputCategoriesOption, elementName))));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.saveButton)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.deleteButton)));
        }

        public static IWebElement DataFromPopup()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.getTheDataFromPopup)));
        }

        public static IWebElement OkButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputCategories.okButton)));
        }


        public static void ClickAddButton()
        {
            CommonMethod.GetActions().Click(AddButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Add' button");
        }

        public static void ClickOkButton()
        {
            CommonMethod.GetActions().Click(OkButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Ok' button");
        }

        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().DoubleClick(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        public static void EnterNameOfCategories(string value)
        {
            InputFields(LastRowInputField, value, "last row of output categories table");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'save' button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void AlertMessage()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'save' button");
            string message = Driver.SwitchTo().Alert().Text;
            Driver.SwitchTo().Alert().Accept();
            Assert.That(message.Equals("Please provide a Name for all records before saving."), "Verified that an alert message is not shown to the user if any output category name is empty.");
            ExtentTestManager.TestSteps($"Verified that an alert message is shown to the user if any output category name is empty.");
        }

        public static bool ClickOutputCategoriesElement(string outputCategoriesName)
        {
            CommonMethod.Wait(1);
            IReadOnlyList<IWebElement> elements = Driver.FindElements(By.XPath(Locator.OutputCategories.selectMaterialFromOutputsCategoriesTable));

            foreach (IWebElement element in elements)
            {
                string elementName = element.Text;

                if (elementName.Equals(outputCategoriesName))
                {
                    CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(element).Perform();
                    ExtentTestManager.TestSteps($"Click on the {outputCategoriesName}");
                    return true;
                }
            }
            return false;
        }

        public static void ClickOutputCategoriesMaterial(string outputCategoriesName)
        {
            bool result = ClickOutputCategoriesElement(outputCategoriesName);
            Assert.That(result, Is.True, $"{outputCategoriesName} is not shown in the output categories table");
        }

        public static void ClickOnTheUsageElement(string outputCategoriesName)
        {
            bool result = false;
            CommonMethod.Wait(1);
            IReadOnlyList<IWebElement> elements = Driver.FindElements(By.XPath(Locator.OutputCategories.usageTableData));

            foreach (IWebElement element in elements)
            {
                string elementName = element.Text;

                if (elementName.Equals(outputCategoriesName))
                {
                    result = true;
                    CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(element).Perform();
                    ExtentTestManager.TestSteps($"Click on the {outputCategoriesName}");
                }
            }
            Assert.That(result, Is.True, $"{outputCategoriesName} is not shown in the usages table");
        }

        public static void DeleteElementFromOutputCategoriesTable(string elementName)
        {
            bool result = ClickOutputCategoriesElement(elementName);

            if (result)
            {
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DeleteButton()).Perform();
                ExtentTestManager.TestSteps($"Click on the Delete Button");
            }
        }

        public static void MoveElementOneUsageTableToAnotherUsageTable(string usageElement, string elementName)
        {
            ClickOnTheUsageElement(usageElement);
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(MoveButton()).Perform();
            ExtentTestManager.TestSteps($"Click on the move button");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(NameOfOutputCategoriesOption(elementName)).Perform();
            ExtentTestManager.TestSteps($"Click on the {elementName}");
        }

        public static string GetDataFromPopup()
        {
            return DataFromPopup().Text;
        }
    }
}
