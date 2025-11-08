using Forms.Reporting;
using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuildAutomation.pageObjectModel
{
    public class ColorPageElement : BaseClass
    {

        public static IWebElement CreateNewButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@class='create-link']/a[contains(@class, 'btn-create') and contains(text(), 'Create New')]")));
        }

        public static IWebElement CreateButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@type='submit'])[2]")));
        }

        public static IWebElement BackToListButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Back to List']")));
        }

        public static IWebElement Texture()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='Texture']")));
        }

        public static IWebElement BumpMap()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='BumpMap']")));
        }

        public static IWebElement ColorName()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Name']")));
        }

        public static IWebElement ColorTransparency()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='Alpha']")));
        }


        public static IWebElement ColorCode()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='MfrCode']")));
        }


        // This method is used for the clicks on the elements
        public static void ClicksTab(Func<IWebElement> methodName, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the '{elementName}' ");
        }

        // This method is used for enter data in the input field
        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().Click(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        public static void SelectTexture(string textureElementName)
        {
            CommonMethod.SelectElement(Texture()).SelectByText(textureElementName);
            ExtentTestManager.TestSteps($"Selected {textureElementName} from the texture");
        }

        public static void SelectBumpMap(string bumpMapElementName)
        {
            CommonMethod.SelectElement(BumpMap()).SelectByText(bumpMapElementName);
            ExtentTestManager.TestSteps($"Selected {bumpMapElementName} from the BumpMap");
        }

        public static void ClickCreateNewButtonForColorPage()
        {
            ClicksTab(CreateNewButton, "Create New Button");
        }

        public static void ClickCreateForColorPage()
        {
            ClicksTab(CreateButton, "Create Button");
        }

        public static void ClickBackToListButtonForColorPage()
        {
            ClicksTab(BackToListButton, "Back to list Button");
        }

        public static void EnterColorNameForColorPage(string value)
        {
            InputFields(ColorName, value, "ColorName");
        }

        public static void EnterColorTransparencyForColorPage(string value)
        {
            InputFields(ColorTransparency, value, "ColorTransparency");
        }

        public static void EnterColorCodeForColorPage(string value)
        {
            InputFields(ColorCode, value, "ColorCode");
        }

        public static string FetchColorNameForColorPage()
        {
            return ColorName().GetAttribute("value");
        }

        public static string FetchColorTransparencyForColorPage()
        {
            return ColorTransparency().GetAttribute("value");
        }
    }
}
