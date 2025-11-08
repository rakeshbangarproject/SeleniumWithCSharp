using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class ExcelSheetOfOutputCategories : BaseClass
    {
        [Test]
        public void InchesFunctionality()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Excel workbook does not support ' in output category names");
            HomePage.NavigateToOutputCategories();
            OutputCategories.ClickAddButton();

            string[] specialCharacters = { "'", ";", "=", ":", "[ ]", "*", "?", "/" };
            string[] duplicateValues = { "Trim", "TRIM", "trim" };

            foreach (string character in specialCharacters)
            {
                CheckOutputCategoriesInputFieldWithSymbols(character);
            }

            foreach (string duplicate in duplicateValues)
            {
                CheckForTheDuplicateElement(duplicate);
            }

            OutputCategories.AlertMessage();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Excel workbook does not support ' in output category names");
        }

        private void CheckOutputCategoriesInputFieldWithSymbols(string symbol)
        {
            OutputCategories.EnterNameOfCategories($"Test {symbol}");
            string errorMessage = OutputCategories.GetDataFromPopup();
            Assert.That(errorMessage.Contains("use '(apostrophe) as its first or last character"), $"After entering the {symbol} symbol in the input field, the error message does not appear.");
            ExtentTestManager.TestSteps($"Verified that the \"use '(apostrophe) as its first or last character\" error message appears when the user enters {symbol} in the input field.");
            OutputCategories.ClickOkButton();
            CommonMethod.Wait(1);
        }

        private void CheckForTheDuplicateElement(string elementName)
        {
            OutputCategories.EnterNameOfCategories(elementName);
            string errorMessage = OutputCategories.GetDataFromPopup();
            Assert.That(errorMessage.Contains("Duplicate Value"), $"After entering {elementName} in the input field, the duplicate value error message does not appear.");
            ExtentTestManager.TestSteps($"Verified that the \"Duplicate Value\" error message appears when the user enters {elementName} in the input field.");
            OutputCategories.ClickOkButton();
            CommonMethod.Wait(1);
        }
    }
}