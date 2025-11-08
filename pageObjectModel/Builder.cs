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
    public class Builder : BaseClass
    {
        public static void ClicksTab(Func<IWebElement> methodName, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the '{elementName}' ");
        }

        public static IWebElement AddNewButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_addBuilder']//td[text()='Add Builder']")));
        }

        public static IWebElement CreateBuilderPageCheck()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_addBuilder']//td[text()='Add Builder']")));
        }

        // This method is used for the click on the add new button
        public static void ClickAddNewBuilderButton()
        {
            ClicksTab(AddNewButton, "Add New Builder button");
        }

        // This method is used for the click on the add button and select element from dropdown
        public static void ClickAddButtonAndSelectFieldFromDropdown(string buttonName)
        {
            string addButtonElements = "//div[@id='w2ui-overlay']//td[@colspan='3' and text()='{0}']";
            ClickAddNewBuilderButton();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(addButtonElements, buttonName)))).Click();
            ExtentTestManager.TestSteps($"Click on the '{buttonName}' ");
        }

        // This method is used for the enter data in the name field
        public static void EnterNameInputField(string value)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Name']")));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys(value);
            ExtentTestManager.TestSteps("Enter data in the Name Field");
        }

        // This method is used for the check newly create builder shown in the builder table
        public static void CheckBuilderShownInTheTable(string builderElement)
        {
            bool result = false;
            for (int attempt = 0; attempt < 20; attempt++)
            {
                CommonMethod.Wait(1);
                IList<IWebElement> builderNames = Driver.FindElements(By.XPath("//div[@id='grid_grid_records']//td[@col='1']/div"));

                foreach (IWebElement element in builderNames)
                {
                    if (element.Text.Equals(builderElement))
                    {
                        result = true;
                        break;
                    }
                }

                if (!result)
                {
                    if (attempt < 19)
                    {
                        Driver.Navigate().Refresh();
                        GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                    }
                }
                else
                {
                    break;
                }
            }

            Assert.That(result, Is.True, $"{builderElement} builder is not shown in the builder table");
        }

        // This method is used for the click on the download button
        public static void ClickOnTheDownloadButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Download']"))).Click();
            ExtentTestManager.TestSteps("Click on the download button");
        }

        // This method is used for the get the checkbox path from table
        public static string GetCheckboxXpathUsingColumnIndex(string nameOfHeader, string tableName, string builderName)
        {
            string headerCheckboxPath = CheckTheColumnAppearFromTheColumn(nameOfHeader, tableName);
            string getThePositionPath = "//tr[contains(@id,'grid_grid_rec_') and @line]";
            IReadOnlyList<IWebElement> getThePosition = Driver.FindElements(By.XPath(getThePositionPath));

            foreach (IWebElement element in getThePosition)
            {
                string lineNumber = element.GetAttribute("line");

                if (lineNumber.Equals("top") || lineNumber.Equals("bottom") || lineNumber.Equals("0"))
                    continue;

                string nameOfTheBuilderPath = $"//tr[contains(@id,'grid_grid_rec_') and @line='{lineNumber}']//td[@col='1']/div";
                string builderNameText = Driver.FindElement(By.XPath(nameOfTheBuilderPath)).Text;

                if (!string.IsNullOrEmpty(builderNameText) && builderNameText.Equals(builderName))
                {
                    string checkboxXPath = $"//tr[contains(@id,'grid_grid_rec_') and @line='{lineNumber}']//td[@col='{headerCheckboxPath}']//input";
                    return checkboxXPath;
                }
            }

            return null;
        }

        // This method is used for if we get the xpath of check then check the checkbox from table
        public static bool CheckCheckbox(string nameOfHeader, string tableName, string builderName)
        {
            bool isTheCheckbox = false;
            string getThePathForTheCheckbox = GetCheckboxXpathUsingColumnIndex(nameOfHeader, tableName, builderName);
            if (getThePathForTheCheckbox != null)
            {
                IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(getThePathForTheCheckbox)));
                if (checkbox != null && !checkbox.Selected)
                {
                    isTheCheckbox = true;
                    checkbox.Click();
                }
            }

            return isTheCheckbox;
        }

        // This method is used for if we get the xpath of checkbox then unchecked the checkbox from table
        public static bool UncheckCheckbox(string nameOfHeader, string tableName, string builderName)
        {
            bool isTheCheckbox = false;
            string getThePathForTheCheckbox = GetCheckboxXpathUsingColumnIndex(nameOfHeader, tableName, builderName);
            if (getThePathForTheCheckbox != null)
            {
                IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(getThePathForTheCheckbox)));
                if (checkbox != null && checkbox.Selected)
                {
                    isTheCheckbox = true;
                    checkbox.Click();
                }
            }

            return isTheCheckbox;
        }

        // This method is used for the check column is shown in the table
        public static string CheckTheColumnAppearFromTheColumn(string columnName, string tableName)
        {
            string headerCheckboxPath = "//div[@id='grid_grid_columns']//td[@class='w2ui-head ']";

            IReadOnlyList<IWebElement> headerCheckbox = Driver.FindElements(By.XPath(headerCheckboxPath));

            foreach (IWebElement element in headerCheckbox)
            {
                string getTheHeaderAttribute = element.GetAttribute("onclick");

                if (getTheHeaderAttribute.Contains(columnName, StringComparison.OrdinalIgnoreCase))
                {
                    // Get the column count and return it
                    string columnCount = element.GetAttribute("col");
                    ExtentTestManager.TestSteps($"Verify that the {columnName} shown in the table column of {tableName}");
                    return columnCount;
                }
            }

            return null;
        }

        // This method is used for the create new builder and check specific checkboxes are unchecked 
        public static void AddNewBuilderAndCheckboxesAreUnchecked(string builderName, string firstCheckName, string secondCheckboxName)
        {
            ClickAddButtonAndSelectFieldFromDropdown("Normal");
            EnterNameInputField(builderName);
            CreateBuilderCheckboxIsUnchecked(firstCheckName);
            CreateBuilderCheckboxIsUnchecked(secondCheckboxName);
            ClickCreateButton();
        }

        // This method is used for check builder checkbox is unchecked
        public static void CreateBuilderCheckboxIsUnchecked(string checkboxName)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//label[@class='control-label' and text()='{checkboxName}']//following::input[@id='{checkboxName}']")));

            if (checkbox.Selected)
            {
                Assert.Fail($"{checkboxName} checkbox is checked in the create builder page");
            }

            ExtentTestManager.TestSteps($"{checkboxName} checkbox is unchecked in the create builder page");
        }

        // This method is used for click on the back to list button 
        public static void BackToListButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Back to List']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Click on the Back to list button");
        }

        // This method is used for click on the create button
        public static void ClickCreateButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@value='Create']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Create button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
        }

        // This method is used for deleted builder
        public static void DeleteBuilder(string builder)
        {
            string builderName = "(//div[text()='{0}']//following :: div[text()='PerSystem'])[1]";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(builderName, builder))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[contains(text(),'Delete')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Delete button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Yes button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
        }

        // This method is used for click on the builder and after invite button is viable then click on it
        public static void ClickOnTheInviteUser(string builder)
        {
            string builderName = "(//div[text()='{0}']//following :: div[text()='PerSystem'])[1]";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(builderName, builder))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_grid_toolbar_item_inviteUser']//td[text()='Invite User']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Invite User button");
        }
    }
}
