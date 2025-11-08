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
    public class DoorsAndWindow : BaseClass
    {
        public static IWebElement WidthInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DoorsAndWindowsElement.widthInputField)));
        }

        public static IWebElement BackToList()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DoorsAndWindowsElement.backToList)));
        }

        public static IWebElement DownloadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.DownloadButton)));
        }
        public static IWebElement CSVButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.CSVButton)));
        }
        public static IWebElement EXcelButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Materials.ExcelButton)));
        }
        public static IWebElement UploadButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DoorsAndWindowsElement.uploadButton)));
        }
        public static IWebElement ChooseFile()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DoorsAndWindowsElement.chooseFile)));
        }
        public static IWebElement UploadFileButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DoorsAndWindowsElement.uploadFileButton)));
        }

        public static void OpenDoorAndWindowMaterialFromDoubleClickOnTheMaterialName(string elementName)
        {
            CommonMethod.Wait(1);
            bool result = false;
            IReadOnlyList<IWebElement> row = Driver.FindElements(By.XPath(Locator.DoorsAndWindowsElement.getTheAllElementFromTable));

            foreach (IWebElement element in row)
            {
                string getTheName = element.Text;

                if (getTheName.Equals(elementName))
                {
                    CommonMethod.GetActions().DoubleClick(element).Perform();
                    ExtentTestManager.TestSteps($"Open the {elementName} element from the door and window table");
                    result = true;
                    break;
                }
            }
            Assert.That(result, Is.True, $"{elementName} element is not shown in the door and window table");
        }

        public static string GetWidthInputValue()
        {
            return WidthInputField().GetAttribute("value");
        }

        public static void ClickBackToList()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(BackToList()).Perform();
            ExtentTestManager.TestSteps("Click on the add back to list button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        public static void DownloadExcelFile()
        {
            CommonMethod.GetActions().Click(DownloadButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(EXcelButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps("Download the excel file");
        }

        public static void UploadExcelAndCSVFile(string filePath)
        {
            CommonMethod.GetActions().Click(UploadButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the upload button");
            CommonMethod.Wait(1);
            ChooseFile().SendKeys(filePath);
            CommonMethod.GetActions().Click(UploadFileButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Upload file and click on the upload button");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DoorsAndWindowsElement.waitForTheFileUpload)));
            CommonMethod.Wait(3);
        }
    }
}
