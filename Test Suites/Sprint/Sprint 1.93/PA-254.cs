using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    [TestFixture, Category("Smoke_test")]
    public class Cantilever : BaseClass
    {
        [Test]
        public void CantileverPorch()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add Cantilever Porch tokens");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickAccessoriesOfJobReview();

            int qtyValue = AddDataInTheMiscellaneous();
            int valueOfCantPorch = AttachedCantPorch();

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickAccessoriesOfJobReview();

            int getQtyAfterAttachedPorch = GetTheQtyValue();

            int calculationAfterApply = qtyValue - getQtyAfterAttachedPorch;
            Assert.That(valueOfCantPorch, Is.EqualTo(calculationAfterApply), "Cantilever formula is not working for the cant porch");
            ExtentTestManager.TestSteps($"Verify that the cantilever calculation {getQtyAfterAttachedPorch} is correct shown in the job review after attached cant porch in canvas building");

        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Cantilever Porch tokens");
        }

        private int AttachedCantPorch()
        {
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClickCantPorchButton();
            int valueOfCantPorch = CalculateTheCantPorchValue();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            return valueOfCantPorch;
        }

        private int AddDataInTheMiscellaneous()
        {
            DefaultJobElement.ClickAddMiscellaneousButton();
            DefaultJobElement.EnterUsageOfMiscInputField("TestUsage");
            DefaultJobElement.EnterSKUOfMiscInputField("TestSKU");
            DefaultJobElement.EnterCostOfMiscInputField("0");
            DefaultJobElement.EnterMaterialOfMiscInputField("TestMaterial");
            DefaultJobElement.EnterPriceOfMiscInputField("0");
            DefaultJobElement.EnterCalculationOfMiscInputField("1000 +");

            AddCantileverInTheCalculationField();
            int qtyValue = GetTheQtyValue();
            ExtentTestManager.TestSteps($"Apply cantilever on canvas building without attached porch and calculation is {qtyValue}");
            return qtyValue;
        }

        private void AddCantileverInTheCalculationField()
        {
            AddToken("SFMain");
            IWebElement inputField = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.calculationOfMisc)));
            CommonMethod.GetActions().Click(inputField).SendKeys("-" + Keys.Enter).Perform();
            AddToken("SFCantPorch");
            DefaultJobElement.ClickSaveButtonOfMisc();
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        private int GetTheQtyValue()
        {
            string qtyValue = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(getTheQuantityOfCantileverXPath))).Text;
            int totalQty = int.Parse(qtyValue.Replace(",", ""));
            return totalQty;
        }

        private void AddToken(string tokenName)
        {
            DefaultJobElement.SearchElementInTheMisc(tokenName);
        }

        private int CalculateTheCantPorchValue()
        {
            string start = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(StartInputXPath))).GetAttribute("value");
            string length = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(LengthInputXPath))).GetAttribute("value");
            int startValue;
            int lengthValue;

            if (!int.TryParse(start.Replace("'", ""), out startValue) || !int.TryParse(length.Replace("'", ""), out lengthValue))
            {
                throw new InvalidOperationException("Start or length value is not a valid integer.");
            }

            ExtentTestManager.TestSteps($"Apply cant porch on the canvas building and cant porch calculation is {startValue * lengthValue}");
            return startValue * lengthValue;
        }

        #region XPaths
        private const string StartInputXPath = "//input[@id='StartStr']";
        private const string LengthInputXPath = "//input[@id='LengthStr']";
        private const string getTheQuantityOfCantileverXPath = "(//div[text()='TestUsage']//following::td[@col='6'])[1]/div";
        #endregion
    }
}