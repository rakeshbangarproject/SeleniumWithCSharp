using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.pageObjectModel
{
    public class PaymentSchedule : BaseClass
    {
        public static string GetTheValueFromPaymentScheduleTable(int pointA, int pointB)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.PaymentSchedule.getPaymentScheduleTableData, pointA, pointB)))).Text;
        }

        public static void EnterDataInThePaymentScheduleField(int pointA, int pointB, string data)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.PaymentSchedule.getPaymentScheduleTableData, pointA, pointB))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(Keys.Backspace).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(CommonMethod.element).SendKeys(data + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {data} in the payment schedule field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//h2[contains(text(),'Payment Schedule')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void ClickSaveButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.PaymentSchedule.saveButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the save button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.PaymentSchedule.yesButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the yes button");
            HomePage.StartFromScratch();
        }
    }
}
