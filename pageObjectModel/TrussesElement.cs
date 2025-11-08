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
    public class TrussesElement : BaseClass
    {
        public static IWebElement SearchInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.searchInputField)));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.saveButton)));
        }

        public static IWebElement AddButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.addButton)));
        }

        public static IWebElement YesButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.yesButton)));
        }

        public static IWebElement DeleteButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.deleteButton)));
        }

        public static IWebElement ClickElementFromTrussesTable(string elementName)
        {
            return Driver.FindElement(By.XPath(string.Format(Locator.Trusses.clickTableElement, elementName)));
        }

        public static IWebElement FirstRowElement(string elementName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.Trusses.clickTableElement, elementName))));
        }

        public static IWebElement MinSpacing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.minSpacingInputField)));
        }

        public static IWebElement MaxSpacing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.maxSpacingInputField)));
        }

        public static IWebElement MinOHL()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='w2ui-page page-0']//label[text()='Min OH L']//following::input[@name='MinOHLStr']")));
        }

        public static IWebElement MinOHR()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='w2ui-page page-0']//label[text()='Min OH R']//following::input[@name='MinOHRStr']")));
        }

        public static IWebElement MaxOHL()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='w2ui-page page-0']//label[text()='Max OH L']//following::input[@name='MaxOHLStr']")));
        }

        public static IWebElement MaxOHR()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='w2ui-page page-0']//label[text()='Max OH R']//following::input[@name='MaxOHRStr']")));
        }

        public static IWebElement SKUInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.sku)));
        }

        public static IWebElement DescriptionInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.description)));
        }

        public static IWebElement SpanInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.spanInputField)));
        }

        public static IWebElement Dim2InputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.dim2InputField)));
        }

        public static IWebElement Pitch1InputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.pitchInputField)));
        }

        public static IWebElement Pitch2InputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.pitch2InputField)));
        }

        public static IWebElement HeelInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.heelInputField)));
        }

        public static IWebElement MinOHLInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.minOHLInputField)));
        }

        public static IWebElement MinOHRInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.minOHRInputField)));
        }

        public static IWebElement MaxOHLInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.maxOHLInputField)));
        }

        public static IWebElement MaxOHRInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.maxOHRInputField)));
        }

        public static IWebElement MinSpacingInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.minSpacingInputField)));
        }

        public static IWebElement MaxSpacingInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.maxSpacingInputField)));
        }

        public static IWebElement IsGableCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.isGableCheckbox)));
        }

        public static IWebElement LoadingInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.loadingInputField)));
        }

         public static IWebElement TCStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.tcStyleDropdown)));
        }

        public static IWebElement SpecialFlagsDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.specialFlagsDropdown)));
        }

        public static IWebElement MaterialDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.materialDropdown)));
        }

        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().Click(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        public static void ClicksTab(Func<IWebElement> methodName, string visibleElementPaths, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(visibleElementPaths)))
            {
                CommonMethod.Wait(1);
                CommonMethod.GetActions().Click(methodName()).Perform();
            }

            ExtentTestManager.TestSteps($"Click on the '{elementName}' tab");
        }

        public static void SearchInputField(string trussName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath(Locator.Trusses.searchInputField)));
            CommonMethod.GetActions().Click(SearchInputField()).SendKeys(trussName + Keys.Enter).Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void EnterSKUInputField(string value)
        {
            InputFields(SKUInputField, value, "sku");
        }

        public static void EnterDescriptionInputField(string value)
        {
            InputFields(DescriptionInputField, value, "description");
        }

        public static void EnterSpanInputField(string value)
        {
            InputFields(SpanInputField, value, "span");
        }

        public static void EnterDim2InputField(string value)
        {
            InputFields(Dim2InputField, value, "dim 2");
        }

        public static void EnterPitch1InputField(string value)
        {
            InputFields(Pitch1InputField, value, "pitch 1");
        }

        public static void EnterPitch2InputField(string value)
        {
            InputFields(Pitch2InputField, value, "pitch 2");
        }

        public static void EnterHeelInputField(string value)
        {
            InputFields(HeelInputField, value, "heel");
        }

        public static void EnterMinOHLInputField(string value)
        {
            InputFields(MinOHLInputField, value, "Min OH L");
        }

        public static void EnterMinOHRInputField(string value)
        {
            InputFields(MinOHRInputField, value, "Min OH R");
        }

        public static void EnterMaxOHLInputField(string value)
        {
            InputFields(MaxOHLInputField, value, "Min OH L");
        }

        public static void EnterMaxOHRInputField(string value)
        {
            InputFields(MaxOHRInputField, value, "Min OH R");
        }

        public static void EnterLoadingInputField(string value)
        {
            InputFields(LoadingInputField, value, "loading");
        }

        public static void EnterMinSpacingInputField(string value)
        {
            InputFields(MinSpacingInputField, value, "Min spacing");
        }

        public static void EnterMaxSpacingInputField(string value)
        {
            InputFields(MaxSpacingInputField, value, "Max spacing");
        }

        public static void ClickFirstElementOfTrussesTable(string elementName)
        {
            CommonMethod.GetActions().MoveToElement(FirstRowElement(elementName)).DoubleClick().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps($"Double Click on the {elementName} element");
        }

        public static void MinSpacingInputFields(string value)
        {
            MinSpacing().Click();
            CommonMethod.GetActions().Click(MinSpacing()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the min spacing field");
        }

        public static void SelectMaterialFromDropdownTagNameOfTDElement(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.DefaultJob.selectMaterialFromAdvancedEdit);
        }

        public static void MaxSpacingInputFields(string value)
        {
            MaxSpacing().Click();
            CommonMethod.GetActions().Click(MaxSpacing()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the max spacing field");
        }

        public static void SelectTCStyle(string elementName)
        {
            CommonMethod.GetActions().MoveToElement(TCStyle()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} in the tc style dropdown");
        }

        public static void SelectSpecialFlags(string elementName)
        {
            CommonMethod.GetActions().MoveToElement(SpecialFlagsDropdown()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} in the special flag dropdown");
        }

         public static void SelectMaterial(string elementName)
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(MaterialDropdown()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} in the tc material dropdown");
        }

        public static void ClickSaveButton()
        {
            CommonMethod.GetActions().MoveToElement(SaveButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.searchInputField)));
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        public static void ClickAddButton()
        {
            ClicksTab(AddButton, Locator.CommonXPath.waitForPopupVisible, "Add button");
        }

        public static void ClickDeleteButton()
        {
            CommonMethod.GetActions().MoveToElement(DeleteButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the delete button");
        }

        public static void ClickYesButton()
        {
            CommonMethod.GetActions().MoveToElement(YesButton()).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the yes button");
        }

        public static void ClickDownloadButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.downloadButton)));
            CommonMethod.GetActions().Click(CommonMethod.element).Perform();
        }

        public static void DownloadExcelFile()
        {
            ClickDownloadButton();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.excelFileButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Download excel sheet file");
        }

        public static void UploadFileInTheTrussTable(string filePath)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.uploadButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.waitForTheUploadList)));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.chooseFile)));
            CommonMethod.element.SendKeys(filePath);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.uploadFile)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.waitForTheConfirmationMessage)));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Trusses.backToListButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[text()='$250.00'])[1]")));
            ExtentTestManager.TestSteps($"Upload file in the trusses table");
        }

        public static void CheckMaterialValueOfMinAndMax(string materialName, string minValue, string maxValue)
        {
            SearchInputField(materialName);
            CommonMethod.Wait(1);
            string costElementXPath = "(//tr[contains(@id,'grid_grid_rec_') and @line='1']//span[text()='{0}']//following::td[@col='4'])[1]";
            string elementXPath = "//tr[contains(@id,'grid_grid_rec_')]//span[text()='{0}']";

            IWebElement cost = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(costElementXPath, materialName))));
            CommonMethod.GetActions().MoveToElement(cost).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys("100").Perform();
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            CommonMethod.Wait(3);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, materialName))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath("//div[@class='w2ui-page page-0']")))
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, materialName))));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='w2ui-page page-0']")));
            }

            string minOHL = MinOHL().GetAttribute("value");
            string minOHR = MinOHR().GetAttribute("value");
            string maxOHL = MaxOHL().GetAttribute("value");
            string maxOHR = MaxOHL().GetAttribute("value");

            if (!minValue.Equals(minOHL) && !minValue.Equals(minOHR) && !maxValue.Equals(maxOHL) && !maxValue.Equals(maxOHR))
            {
                Assert.Fail("The overhang min and Max data are not shown correct in the trusses table");
            }

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='w2ui-msg-buttons']//button[@id='Cancel']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Verify that after changes in the excel sheet the data shown correct in the trusses table ");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='grid_grid_search_all']"))).Clear();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.Wait(3);
        }

        public static void DeleteDataFromTrussesTable(string trussName)
        {
            try
            {
                SearchInputField(trussName);
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                CommonMethod.Wait(4);
                CommonMethod.GetActions().MoveToElement(ClickElementFromTrussesTable(trussName)).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
                ClickDeleteButton();
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.waitForTheDeletePopupOpen)));
                ClickYesButton();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.waitForTheTableDataLoad)));
            }
            catch (NoSuchElementException)
            {
                SearchInputField().Clear();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
                CommonMethod.Wait(2);
            }
        }

        public static List<string> ProcessHeaders(string headerName, string listType)
        {
            List<string> minL = new();
            List<string> minR = new();
            List<string> maxL = new();
            List<string> maxR = new();

            string headerXPath = "//div[@id='grid_grid_columns']//td[@class='w2ui-head ']";
            int retryCount = 3;

            for (int attempt = 0; attempt < retryCount; attempt++)
            {
                try
                {
                    IReadOnlyList<IWebElement> headers = Driver.FindElements(By.XPath(headerXPath));

                    for (int i = 1; i < headers.Count; i++)
                    {
                        IWebElement headerElement = headers[i];
                        string columnNumber = headerElement.GetAttribute("col");

                        IReadOnlyList<IWebElement> subHeaders = Driver.FindElements(By.XPath($"{headerXPath}//div[2]"));
                        IWebElement subHeaderElement = subHeaders[i];
                        string subHeaderText = subHeaderElement.Text;

                        if (subHeaderText.Equals(headerName))
                        {
                            string rowXPath = "//tr[contains(@id,'grid_grid_rec_')]";
                            IReadOnlyList<IWebElement> rows = Driver.FindElements(By.XPath(rowXPath));

                            foreach (IWebElement rowElement in rows)
                            {
                                string lineNumber = rowElement.GetAttribute("line");

                                if (lineNumber.Equals("bottom"))
                                {
                                    return GetList(listType, minL, minR, maxL, maxR);
                                }

                                if (!lineNumber.Equals("top") && !lineNumber.Equals("0") && lineNumber != null)
                                {
                                    string cellXPath = "//tr[contains(@id,'grid_grid_rec_') and @line='{0}']//td[@col='{1}']/div";
                                    string cellText = Driver.FindElement(By.XPath(string.Format(cellXPath, lineNumber, columnNumber))).Text;

                                    switch (subHeaderText)
                                    {
                                        case "Min OH L":
                                            minL.Add(cellText);
                                            break;
                                        case "Min OH R":
                                            minR.Add(cellText);
                                            break;
                                        case "Max OH L":
                                            maxL.Add(cellText);
                                            break;
                                        case "Max OH R":
                                            maxR.Add(cellText);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (StaleElementReferenceException)
                {
                    if (attempt == retryCount - 1)
                    {
                        throw;
                    }
                }
            }

            return GetList(listType, minL, minR, maxL, maxR);
        }

        private static List<string> GetList(string listType, List<string> minL, List<string> minR, List<string> maxL, List<string> maxR)
        {
            return listType switch
            {
                "MinL" => minL,
                "MinR" => minR,
                "MaxL" => maxL,
                "MaxR" => maxR,
                _ => throw new ArgumentException("Invalid list type")
            };
        }

    }
}
