using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.pageObjectModel
{
    public class Distributor : BaseClass
    {
        public static IWebElement SearchField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.inputSearchField)));
        }
        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.saveButton)));
        }
        public static IWebElement AddDistributor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.addDistributor)));
        }
        public static IWebElement PostFrame()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.postFrame)));
        }
        public static IWebElement DistributorName()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.distributorName)));
        }
        public static IWebElement CreateButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DistributorLocators.createButton)));
        }

        public static void SearchInputField(string searchElement)
        {
            CommonMethod.GetActions().Click(SearchField()).Perform();
            CommonMethod.GetActions().Click(SearchField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(searchElement + Keys.Enter).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(3);
        }

        // This method is used for the enter distributor name
        public static void EnterDistributorName(string name)
        {
            CommonMethod.GetActions().Click(DistributorName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(name).Perform();
            ExtentTestManager.TestSteps($"Enter {name} Distributor Name");
        }

        // This method is used for the select source distributor
        public static void SelectSourceDistributor(string name)
        {
            By Dropdown = By.XPath(Locator.DistributorLocators.selectParentDistributor);
            SelectElement select = new SelectElement(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(Dropdown)));
            select.SelectByText(name);
            ExtentTestManager.TestSteps($"Select {name} distributor from the source distributor dropdown");
        }

        // This method is used for the click on he create button 
        public static void ClickCreateButton()
        {
            CommonMethod.GetActions().MoveToElement(CreateButton()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the add create button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        // This method is used for the table scroll from left to right
        public static void TableScrollRightSide(string x_axis, string y_axis)
        {
            // Scroll Down JS Table
            EventFiringWebDriver eventFiringWebDriver = new(Driver);
            eventFiringWebDriver.ExecuteScript(string.Format(Locator.DistributorLocators.pageScroll, x_axis, y_axis));
        }

        // This method is used for the check the checkbox
        public static void CheckCheckboxes(int indexNumber, string checkboxName)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DistributorLocators.checkboxes, indexNumber))));

            if (!checkbox.Selected)
            {
                checkbox.Click();
            }

            ExtentTestManager.TestSteps($"Check the {checkboxName} checkbox");
        }

        // This method is used for the unchecked the checkbox
        public static void UncheckCheckboxesOfDistributorPage(int indexNumber, string checkboxName)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DistributorLocators.checkboxes, indexNumber))));

            if (checkbox.Selected)
            {
                checkbox.Click();
            }

            ExtentTestManager.TestSteps($"Uncheck the {checkboxName} checkbox");
        }

        public static void UncheckCheckbox(int indexNumber)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DistributorLocators.checkboxes, indexNumber))));

            if (checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        public static void CheckCheckbox(int indexNumber)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DistributorLocators.checkboxes, indexNumber))));

            if (!checkbox.Selected)
            {
                checkbox.Click();
            }
        }

        public static void VerifyElementNotInTheSettingList(string nameOfElement)
        {
            try
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//ul[@class='dropdown-menu'])[2]")));
                string dropDownList = CommonMethod.element.Text;
                Assert.IsFalse(dropDownList.Contains(nameOfElement), $"{nameOfElement} is not shown in the setting dropdown list after unchecked the 'Can {nameOfElement}' checkbox");
                ExtentTestManager.TestSteps($"{nameOfElement} is not shown in the setting dropdown list after unchecked the 'Can {nameOfElement}' checkbox");
            }
            catch (AssertionException ex)
            {
                Console.WriteLine($"Assertion failed: {ex.Message}");
            }
        }

        public static void CheckCheckboxByIndex(int checkboxIndex)
        {
            CheckCheckbox(checkboxIndex);
            CommonMethod.Wait(1);
        }

        public static void CheckAllCheckboxOfAutoTestDistributor()
        {
            for (int i = 1; i <= 19; i++)
            {
                try
                {
                    CheckCheckboxByIndex(i);
                }
                catch (StaleElementReferenceException)
                {
                    CheckCheckboxByIndex(i);
                }
                TableScrollRightSide("100", "0");
            }
            ExtentTestManager.TestSteps("All checkBox are checked");
        }

        public static void RefreshButton()
        {
            // Click on Refresh Button
            try
            {
                Driver.Navigate().Refresh();
                Driver.SwitchTo().Alert().Accept();
            }
            catch
            {
                Driver.Navigate().Refresh();
            }

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Refresh the Distributor page");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().MoveToElement(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(3);
            ExtentTestManager.TestSteps("Click on the save button");
        }

        public static void ClickAddDistributorButton()
        {
            CommonMethod.GetActions().MoveToElement(AddDistributor()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the add distributor button");
        }

        public static void ClickPostFrameButton()
        {
            CommonMethod.GetActions().MoveToElement(PostFrame()).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the add post frame button");
        }

        public static void DeleteDistributor(string nameOfDistributor)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='grid_grid_search_all']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys(nameOfDistributor + Keys.Enter).Pause(TimeSpan.FromSeconds(1)).Perform();
            string verifyDistributor = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='w2ui-marker']"))).Text;

            if (verifyDistributor == nameOfDistributor)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//span[text()='{nameOfDistributor}']//following :: td[1]")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                ClickDeleteButtonAndYesButton();
            }
        }

        public static void ClickDeleteButtonAndYesButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Delete']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Delete selected Distributor']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Yes']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void ClickOnTheDistributorElement(string distributorName)
        {
            bool result = false;
            CommonMethod.Wait(1);
            IList<IWebElement> getTheTotalNumberOfElement = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_grid_rec_') and @line]"));
        
            foreach(IWebElement webElement in getTheTotalNumberOfElement)
            {
                string lineNumber = webElement.GetAttribute("line");

                if (lineNumber.Equals("top") || lineNumber.Equals("bottom") || lineNumber.Equals("0"))
                    continue;

                string getTheElementNameXPaths = $"//tr[contains(@id,'grid_grid_rec_') and @line ={lineNumber}]//span";
                string getDistributorName = Driver.FindElement(By.XPath(getTheElementNameXPaths)).Text;
                if (getDistributorName.Equals(distributorName) && getDistributorName != null)
                {
                    string parentName = $"//tr[contains(@id,'grid_grid_rec_') and @line ={lineNumber}]//td[@col='2']/div";  
                    Driver.FindElement(By.XPath(parentName)).Click();
                    result = true;
                    break;
                }
            }
        
            if(!result)
            {
                Assert.Fail($"{distributorName} element is not clickable");
            }
        }

        public static void CheckElementShownInTheDistributorTable(string distributorElement)
        {
            bool result = false;
            for (int attempt = 0; attempt < 20; attempt++)
            {
                CommonMethod.Wait(1);
                SearchInputField(distributorElement);
                IList<IWebElement> builderNames = Driver.FindElements(By.XPath("//div[@id='grid_grid_records']//td[@col='1']/div"));

                foreach (IWebElement element in builderNames)
                {
                    if (element.Text.Equals(distributorElement))
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

            Assert.That(result, Is.True, $"{distributorElement} builder is not shown in the distributor table");
        }

    }
}
