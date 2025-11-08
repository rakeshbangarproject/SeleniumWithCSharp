using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.pageObjectModel
{
    public class Customize : BaseClass
    {
        #region IWebElement
        public static IWebElement UploadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.uploadButton)));         
        }

         public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.deleteButton)));         
        }

         public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.saveButton)));         
        }

        public static IWebElement IncludeCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.includeCheckbox)));         
        }

         public static IWebElement WaterMarkCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.waterMarkCheckbox)));         
        }

         public static IWebElement OkayButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.okayButton)));         
        }
        #endregion

        // This method is used for the checked the checkbox
        public static void CheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (!checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Check the '{checkboxName}' checkbox");
        }

        // This method is used for the unchecked the checkbox
        public static void UncheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Uncheck the '{checkboxName}' checkbox");
        }

        // This method is used for the check the Include checkbox
        public static void CheckedIncludeCheckbox()
        {
            CheckCheckbox(IncludeCheckbox, "Include checkbox");
        }

         public static void CheckedWaterMarkCheckbox()
        {
            CheckCheckbox(WaterMarkCheckbox, "WaterMark checkbox");
        }

        // This method is used for the check the notification checkboxes
        public static void ChangeNotificationsCheckbox()
        {
            for (int i = 3; i <= 32; i++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("(//input[contains(@type,'checkbox')])[{0}]", i)))).Click();
                CommonMethod.Wait(1);
            }
            ExtentTestManager.TestSteps("Verify that all checkboxes are check");
        }

        public static void ClicksTab(Func<IWebElement> methodName, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the '{elementName}' ");
        }

        public static void ClickOkayButton()
        {
            ClicksTab(OkayButton, "okay button");
        }

        public static void ClickDeleteButton()
        {
            ClicksTab(DeleteButton, "delete button");
        }

        public static void ClickSaveButton()
        {
            ClicksTab(SaveButton, "save button");
        }

        public static void UploadingFileInTheCustomizePage(string fileLocation, string fileName, string name)
        {
            // Click on Upload button and upload image 
            UploadButton().SendKeys($@"{fileLocation}\{fileName}");
            ExtentTestManager.TestSteps($"Click on Upload button and upload {name} file'");
            CommonMethod.Wait(4);
        }

        public static void EnterDataInTheHomeField(string homeFieldData)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.homeLinkInputField)));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys(homeFieldData);
            ExtentTestManager.TestSteps($"Enter Home field {homeFieldData}");
        }

        public static void EnterDataInTheAboutField(string aboutFieldData)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.aboutLinkInputField)));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys(aboutFieldData);
            ExtentTestManager.TestSteps($"Enter About field {aboutFieldData}");
        }

        public static void EnterDataInTheContactField(string contactFieldData)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CustomizeElement.contactLinkInputField)));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys(contactFieldData);
            ExtentTestManager.TestSteps($"Enter ContactS field {contactFieldData} ");
        }
    }
}
