using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Pages_Application
{
    public class FramingRules : BaseClass
    {
        public static IWebElement EditButtonOfFramingRulesDistributor(string distributorName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.EditButton, distributorName))));
        }

        public static IWebElement Prompt()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.Prompt)));
        }

        public static IWebElement SaveButtonOfDoEditField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.SaveButtonOfDoEditField)));
        }

        public static IWebElement SaveButtonOfDoEditFieldOnJobPage()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.SaveButtonOfDoEditFieldOnJobPage)));
        }

        public static IWebElement Details()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.details)));
        }

        public static IWebElement DoorAndWindow()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.doorAndWindow)));
        }

        public static IWebElement PreviewButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.previewButton)));
        }

        public static IWebElement JobButtonPreviewFrame()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.jobButtonPreviewFrame)));
        }

        public static IWebElement Job()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.job)));
        }

        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.addButton)));
        }

        public static IWebElement DeleteButton(string elementName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.deleteButton, elementName))));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.SaveButton)));
        }

        public static IWebElement CrossIcon()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.crossIcon)));
        }

        public static IWebElement GetTheAllDataFromEditOption()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.getTheAllDataFromEditOption)));
        }

        public static IWebElement TypeOptionOfEditNewQuestionTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.selectTypeOptionOfEditNewQuestionTable)));
        }

        public static IWebElement DoEditButton(string subMenu, string colorName)
        {
            return Driver.FindElement(By.XPath(string.Format(Locator.FramingRules.DoEditButton, subMenu, colorName)));
        }

        public static void ClickSaveButtonOfDoEditField()
        {
            CommonMethod.GetActions().Click(SaveButtonOfDoEditField()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the save button");
        }

         public static void ClickSaveButtonOfDoEditFieldOnJobPage()
        {
            CommonMethod.GetActions().Click(SaveButtonOfDoEditFieldOnJobPage()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        public static void ClickCrossIcon()
        {
            CommonMethod.GetActions().Click(CrossIcon()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the cross icon button");
        }

        public static void OpenAUTOTEST__PHTEST_FramingRules()
        {
            CommonMethod.GetActions().Click(EditButtonOfFramingRulesDistributor("AUTOTEST_PHTEST")).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the AUTOTEST_PHTEST framing rules edit button");
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
        }

        public static bool CheckElementShownInTheDropdown(string materialName, string colorName, string tagName)
        {
            CommonMethod.Wait(1);
            bool result = false;
            IReadOnlyList<IWebElement> numberOfElements = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_questionGrid_rec_')]//td[@col='0']//div"));

            foreach (IWebElement element in numberOfElements)
            {
                string elementText = element.Text;

                if (!string.IsNullOrEmpty(elementText) && elementText.Equals(materialName))
                {
                    CommonMethod.GetActions().Click(element).Perform();
                    result = true;
                    IReadOnlyList<IWebElement> getColor = element.FindElements(By.XPath(".//span[1]"));

                    foreach (IWebElement color in getColor)
                    {
                        Assert.That(color.GetAttribute("style"), Is.EqualTo(colorName));
                        break;
                    }

                    IReadOnlyList<IWebElement> front = element.FindElements(By.XPath(".//span[1]//i"));

                    foreach (IWebElement frontName in front)
                    {
                        Assert.That(frontName.TagName, Is.EqualTo(tagName));
                        break;
                    }

                    break;
                }
            }

            return result;
        }

        public static void OpenAUTOTEST__PHTEST_AnonymousFramingRules()
        {
            CommonMethod.GetActions().Click(EditButtonOfFramingRulesDistributor("AUTOTEST_PHTEST - Anonymous")).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the AUTOTEST_PHTEST framing rules edit button");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
        }

        public static void ClickOnEditButtonOfBuilderFromFramingRules(string builderName)
        {
            CommonMethod.GetActions().Click(EditButtonOfFramingRulesDistributor(builderName)).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {builderName} framing rules edit button");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.FramingRules.WaitForTheFramingRulePageLoad)));
        }

        public static void SelectTypeOptionOfEditNewQuestionTable(string elementName)
        {
            CommonMethod.GetActions().Click(TypeOptionOfEditNewQuestionTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.SelectMaterialFromDropdown(elementName, Locator.CommonXPath.selectValueFromDropdown);
            ExtentTestManager.TestSteps($"Select {elementName} option from the type dropdown");
        }

        public static void ClickDoEditButtonAndChangeColorName(string colorName, string value)
        {
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(DoEditButton("-- Colors --", colorName)).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            EnterPrompt(value);
            ClickSaveButtonOfDoEditField();
        }

        public static void ClickDoEditButton(string menuListName, string nameOfElement)
        {
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(DoEditButton(menuListName, nameOfElement)).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {nameOfElement} of do edit button");
        }

        // This method is used for the click on the left side of material from do edit material
        private static void ClickOnTheLeftSideTableOfDoEditFrame(string elementName)
        {
            IList<IWebElement> elements = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_questionGrid_rec_') and @line]//div"));

            foreach (IWebElement element in elements)
            {
                string getElementName = element.Text;

                if (getElementName.Equals(elementName))
                {
                    element.Click();
                    CommonMethod.Wait(1);
                }
            }
        }

        public static void DeleteDataFromDoEditTable(string elementName)
        {
            ClickOnTheLeftSideTableOfDoEditFrame(elementName);
            ClickOnTheDeleteButton();
        }

        public static void MoveElementAtTopInDoEditFrame(string elementName)
        {
            ClickOnTheLeftSideTableOfDoEditFrame(elementName);
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_questionGrid_toolbar_item_top']"))).Click();    
        }

        private static void ClickOnTheDeleteButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_questionGrid_toolbar_item_w2ui-delete']"))).Click();
            CommonMethod.Wait(1);
            Driver.FindElement(By.XPath("//div[@id='w2ui-message0']//button[text()='Yes']")).Click();
        }

        public static void AddMaterialInDoEditFrame(string elementName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='grid_fixGrid_search_all']"))).SendKeys(elementName+Keys.Enter);
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//tr[contains(@id,'grid_fixGrid_rec_') and @line='1']//span[text()='{elementName}']"))).Click();       
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[@id='tb_fixGrid_toolbar_item_add']//following::td[normalize-space()='Add']"))).Click();       
        }

        public static void EnterPrompt(string value)
        {
            CommonMethod.Wait(1);
            Prompt().Click();
            CommonMethod.GetActions().Click(Prompt()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter the {value} in the prompt field");
        }

        public static string ClickDoEditButtonOfProductSystemAndGetTheData(string productSystem, string condition)
        {
            CommonMethod.GetActions().Click(DoEditButton("-- Product Systems --", productSystem)).Pause(TimeSpan.FromSeconds(1)).Perform();
            string entries = GetTheAllDataFromEditOption().Text;
            ClickCrossIcon();
            ExtentTestManager.TestSteps($"Get the {entries} data {condition} the setup wizard changes");
            return entries;
        }

        public static void ClickDetails()
        {
            CommonMethod.GetActions().Click(Details()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the details tab");
            CommonMethod.Wait(1);
        }

        public static void ClickDoorAndWindow()
        {
            CommonMethod.GetActions().Click(DoorAndWindow()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the Door And Window tab");
        }

        public static void ClickPreviewButton()
        {
            CommonMethod.GetActions().Click(PreviewButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps($"Click on the preview tab");
        }

        public static void ClickJobButtonPreviewFrame()
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(JobButtonPreviewFrame()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the job button from preview frame");
        }

        public static void ClickJob()
        {
            CommonMethod.GetActions().Click(Job()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the job tab");
        }

        public static void ClickAddButton()
        {
            CommonMethod.GetActions().Click(AddButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the add button");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        public static IWebElement InputField(string menu, string subMenu)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.InputField, menu, subMenu))));
        }

        public static void RoofPitchInputField(string value)
        {
            CommonMethod.GetActions().MoveToElement(InputField("-- Building Size --", "Roof Pitch")).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Click().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            Console.WriteLine($"Enter {value} in the Roof pitch of Framing Rules");
            ExtentTestManager.TestSteps($"Enter {value} in the Roof pitch of Framing Rules");
        }

        public static void TableScrollDown(string dimension)
        {
            // Scroll Down JS Table
            EventFiringWebDriver eventFiringWebDriver = new(Driver);
            eventFiringWebDriver.ExecuteScript(string.Format(Locator.FramingRules.pageScrollDown, dimension));
            CommonMethod.Wait(1);
        }

        public static void SetNoneValueInTheDropdown(string dropdownName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.getTheElementOfDropdown, dropdownName))));
            CommonMethod.GetActions().DoubleClick(CommonMethod.element).Pause(TimeSpan.FromSeconds(2)).Perform();
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", CommonMethod.element);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.selectNoneValue))).Click();
            ExtentTestManager.TestSteps($"Set the {dropdownName} Side as a None");
            Console.WriteLine($"Set the {dropdownName} Side as a None");
        }

        public static void SelectDropdownMaterials(string titleName, string subElementName, string SelectMaterial)
        {
            ExtentTestManager.TestSteps($"The {titleName} Menu lists");
            try
            {
                IWebElement dropdownElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.InputFieldLocator, titleName, subElementName))));
                CommonMethod.GetActions().MoveToElement(dropdownElement).DoubleClick().Build().Perform();
                CommonMethod.Wait(1);
                dropdownElement.Click();
                Driver.FindElement(By.XPath(string.Format(Locator.FramingRules.selectElementFromDropdown, SelectMaterial))).Click();
            }
            catch (Exception)
            {
                IWebElement dropdownElement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.InputFieldLocator, titleName, subElementName))));
                CommonMethod.GetActions().MoveToElement(dropdownElement).DoubleClick().Build().Perform();
                CommonMethod.Wait(1);
                dropdownElement.Click();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.selectElementFromDropdown, SelectMaterial)))).Click();
            }

            ExtentTestManager.TestSteps($"Select {subElementName} from {SelectMaterial} dropdown");
        }

        public static void ChecksCheckboxes(string titleName, string subElementName, int colNumber)
        {
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.CheckboxesLocator, titleName, subElementName, colNumber))));
            CommonMethod.GetActions().MoveToElement(checkbox).Click().Perform();
        }

        public static void EnterValueInTheInputField(string titleName, string subElementName)
        {
            IWebElement blankElementField = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.InputFieldLocator, titleName, subElementName))));
            CommonMethod.GetActions().MoveToElement(blankElementField).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Click().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("1" + Keys.Enter).Perform();
        }
  
        public static void ApplyInputFieldFromFramingRuleEditPage(string materialName)
        {
            ClickNameInputField();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='fld']"))).SendKeys(materialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@class='menu']//td[text()='{materialName}']"))).Click();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-popup']//div[@class='w2ui-buttons']/button[@name='Apply']"))).Click();
        }

        public static void ClickNameInputField()
        {
            IWebElement nameInputField = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='table-responsive']//div[@id='flddiv']")));
            ExtentTestManager.TestSteps($"Click on the name input field");
            CommonMethod.GetActions().Click(nameInputField).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void VerifyBuilderAndEditButton(string builderName, string fieldName)
        {
            CommonMethod.Wait(1);

            IReadOnlyList<IWebElement> elements = Driver.FindElements(By.XPath("//div[@class='table-responsive']//td[1]//div"));
            bool isChildControlled = false;
            bool builderFound = false;

            foreach (IWebElement element in elements)
            {
                string currentBuilderName = element.Text;

                if (currentBuilderName.Equals(builderName))
                {
                    builderFound = true;
                    string editButtonXpath = "//td[normalize-space()='{0}']//following::td[3]";
                    IWebElement buttonContainer = Driver.FindElement(By.XPath(string.Format(editButtonXpath, currentBuilderName)));
                    IReadOnlyList<IWebElement> buttons = buttonContainer.FindElements(By.XPath("./*"));

                    int editButtonCount = 0;

                    foreach (IWebElement button in buttons)
                    {
                        string buttonText = button.Text;
                        string buttonTag = button.TagName;

                        if (buttonText.Equals("Edit") && buttonTag.Equals("a"))
                        {
                            editButtonCount++;
                        }
                        else if (buttonText.Equals("**") && buttonTag.Equals("div"))
                        {
                            editButtonCount++;
                        }
                        else if (buttonText.Equals("Child-Controlled"))
                        {
                            isChildControlled = true;
                        }
                        else
                        {
                            Assert.Fail($"{builderName} builder has an unexpected element in the edit framing rules.");
                        }
                    }

                    if (fieldName == "ChildDistributor")
                    {
                        ValidateChildDistributor(editButtonCount, isChildControlled);
                    }
                    else if (fieldName == "ParentDistributor")
                    {
                        ValidateParentDistributor(editButtonCount, isChildControlled);
                    }
                    else
                    {
                        Assert.Fail("Invalid field name provided for validation.");
                    }

                    break;
                }
            }

            if (!builderFound)
            {
                Assert.Fail($"Builder {builderName} was not found in the table.");
            }
        }

        private static void ValidateChildDistributor(int editButtonCount, bool isChildControlled)
        {
            if (editButtonCount == 2)
            {
                Assert.IsFalse(isChildControlled, "Child-Controlled text is shown after 'IsControlled' checkbox is checked.");
                Assert.AreEqual(editButtonCount, 2, "Both 'Edit' and '**' buttons should be visible after 'IsControlled' is unchecked.");
            }
            else if (isChildControlled)
            {
                Assert.IsTrue(isChildControlled, "Child-Controlled text should be visible after 'IsControlled' is checked.");
                Assert.AreNotEqual(editButtonCount, 2, "Both 'Edit' and '**' buttons should disappear after 'IsControlled' is unchecked.");
            }
            else
            {
                Assert.Fail("IsControlled functionality is not working as expected for ChildDistributor.");
            }
        }

        private static void ValidateParentDistributor(int editButtonCount, bool isChildControlled)
        {
            if (editButtonCount == 1)
            {
                Assert.IsFalse(isChildControlled, "Child-Controlled text is shown after 'IsControlled' checkbox is checked.");
                Assert.AreEqual(editButtonCount, 1, "Only the '**' text should disappear after 'CanFramingRules' is unchecked.");
            }
            else
            {
                Assert.Fail("IsControlled functionality is not working as expected for ParentDistributor.");
            }
        }
    }
}


