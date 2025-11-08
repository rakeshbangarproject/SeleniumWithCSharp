using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.pageObjectModel
{
    public class PricingElement : BaseClass
    {
        public static IWebElement SearchElement()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.PricingLocator.searchElement)));
        }

         public static IWebElement ActiveDistributor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.PricingLocator.activeDistributor)));
        }

        public static void CheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (!checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Check the '{checkboxName}' checkbox");
        }

       public static IWebElement HideCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.PricingLocator.checkHideCheckbox)));
        }

        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().Click(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        public static void SearchElement(string value)
        {
            CommonMethod.GetActions().Click(SearchElement()).SendKeys(value + Keys.Enter).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(5);
        }

        public static void SelectActiveDistributor(string valueOfDistributor)
        {
            CommonMethod.SelectElement(ActiveDistributor()).SelectByText(valueOfDistributor);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Select {valueOfDistributor} of pricing distributor");
        }

        public static void CheckHideCheckbox()
        {
            try
            {
                CheckCheckbox(HideCheckbox, "Hide check");
            }
            catch(StaleElementReferenceException)
            {
                CheckCheckbox(HideCheckbox, "Hide check");
            }

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Check Hide check checkbox");
        }     
    }
}
