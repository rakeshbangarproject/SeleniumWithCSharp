using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.pageObjectModel
{
    public class EModelerElement : BaseClass
    {
        public static void UploadFile(string uploadFile, string fileName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.EModeler.uploadFile))).SendKeys(uploadFile);
            ExtentTestManager.TestSteps($"Upload the {fileName} file");
        }

        public static void ClickSaveButton()
        {
            IWebElement saveButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.EModeler.saveButton)));
            CommonMethod.GetActions().MoveToElement(saveButton).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        public static string GetTheEModelerLink(string elementName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.EModeler.CopyEModelerLink, elementName)))).Text;
        }

        public static string GetTheAcknowledgment()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.EModeler.acknowledgment))).Text;
        }

        public static void EnterDetailsOfJobInTheViewJobLinkPage(string firstWindows, string pathValue, string jobName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Submit For Quote')]")));
            CommonMethod.Wait(7);
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", CommonMethod.element);
            ExtentTestManager.TestSteps("Click on the Submit For Quote");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='submitMain']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='submitForm']//following :: input[@id='ProjectName'])[1]")));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys(jobName).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Enter data in name field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(text(),'Email')])//following :: input[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys("kdhillon@gmail.com").Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Enter data in email field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Submit for Quote')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Submit For Quote");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[@id='w2ui-popup']//p[text()='{pathValue}']")));
            CommonMethod.Wait(3);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='OK']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Ok button");
            CommonMethod.Wait(3);
        }

    }
}
