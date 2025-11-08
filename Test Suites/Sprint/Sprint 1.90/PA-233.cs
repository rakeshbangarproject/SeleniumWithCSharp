using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class BlankOutputField : BaseClass
    {

        [Test]
        public void OutputCategoriesFunctionality()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("If users create blank output categories");
            HomePage.NavigateToOutputCategories();
            DeleteDataFromOutputCategories();
            OutputCategories.ClickAddButton();

            OutputCategories.EnterNameOfCategories(" ");
            OutputCategories.AlertMessage();
            OutputCategories.EnterNameOfCategories("TestOutputCategories");
            OutputCategories.ClickSaveButton();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickJobReview();

            Assert.IsNotNull(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='TestOutputCategories'])[1]"))), "TestOutputCategories tab is not shown in the Job Review");
            Console.WriteLine("Verify that the newly create Output category is shown in the Job Review tab.");
            ExtentTestManager.TestSteps("Verify that the newly create Output category is shown in the Job Review tab.");

            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToOutputCategories();
            DeleteDataFromOutputCategories();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of users create blank output categories");
        }

        private static bool DeleteDataFromOutputCategories()
        {
            try
            {
                OutputCategories.DeleteElementFromOutputCategoriesTable("TestOutputCategories");
                OutputCategories.ClickSaveButton();
                HomePage.NavigateToOutputCategories();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
