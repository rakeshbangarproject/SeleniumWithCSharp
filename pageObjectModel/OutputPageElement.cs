using Forms.Reporting;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.pageObjectModel
{
    public class OutputPageElement : BaseClass
    {
        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.addButton)));
        }

        public static IWebElement DoorAndWindowCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.doorAndWindowCheckbox)));
        }

        public static IWebElement Description()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.description)));
        }

        public static IWebElement TypeDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.typeDropdown)));
        }

        public static IWebElement IgnoreUsageCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.ignoreUsageCheckbox)));
        }

        public static IWebElement GroupAddonsCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.groupAddonsCheckbox)));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.saveButton)));
        }

        public static IWebElement MainSaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.mainSaveButton)));
        }

        public static IWebElement OutputType()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.outputType)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.deleteButton)));
        }

        public static IWebElement YesButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.yesButton)));
        }

         public static IWebElement EditButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.editButton)));
        }

        public static void CheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (!checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Check the '{checkboxName}' checkbox");
        }

        public static void UncheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Uncheck the '{checkboxName}' checkbox");
        }

        public static void CheckDoorAndWindowCheckbox()
        {
            CheckCheckbox(DoorAndWindowCheckbox, "Door And Window");
        }

        public static void CheckIgnoreUsageCheckbox()
        {
            CheckCheckbox(IgnoreUsageCheckbox, "Ignore Usage");
        }

        public static void CheckGroupAddonsCheckbox()
        {
            CheckCheckbox(GroupAddonsCheckbox, "Group Addons");
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

        public static void EnterDescription(string value)
        {
            CommonMethod.GetActions().Click(Description()).Perform();
            CommonMethod.GetActions().Click(Description()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the description field");
        }

        public static void SelectMaterialFromDropdownTagNameOfTDElement(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.DefaultJob.selectMaterialFromAdvancedEdit);
        }

        public static void ClickAddButton()
        {
            ClicksTab(AddButton, Locator.CommonXPath.waitForPopupVisible, "add button");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Save' button");
        }

        public static void ClickMainSaveButtonForPostFrame()
        {
            CommonMethod.GetActions().Click(MainSaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the 'Main Save' button");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.startFromScratch)));
        }

        public static void SelectTypeOption(string elementName)
        {
            CommonMethod.GetActions().Click(TypeDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.SelectMaterialFromDropdown(elementName, Locator.CommonXPath.selectValueFromDropdown);
            ExtentTestManager.TestSteps($"Select {elementName} from the type dropdown");
        }

        public static string GetTheTypeDropdownValue()
        {
            return TypeDropdown().GetAttribute("title");
        }

        public static void DeleteDataFromOutputTable(string elementName)
        {
            CommonMethod.SelectMaterialFromDropdown(elementName, Locator.OutputPagesLocator.getTheAllElementName);
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(DeleteButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(YesButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Delete {elementName} from outputs table");
        }

        public static void OpenExistingElement(string elementName)
        {
            CommonMethod.SelectMaterialFromDropdown(elementName, Locator.OutputPagesLocator.getTheAllElementName);
            CommonMethod.Wait(3);
            CommonMethod.GetActions().Click(EditButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {elementName} element and click on the edit button");
        }

        public static void UploadFile(string filePath, string fileName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.uploadButton))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.OutputPagesLocator.chooseFile))).SendKeys(@$"{filePath}/{fileName}");
            ExtentTestManager.TestSteps($"Upload the {fileName}");
        }

        public static void SelectOutputType(string elementName)
        {
            CommonMethod.GetActions().Click(OutputType()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the output type dropdown");
        }
    }
}
