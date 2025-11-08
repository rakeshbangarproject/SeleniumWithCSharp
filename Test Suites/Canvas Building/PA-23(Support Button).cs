using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class SupportButton : BaseClass
    {

        [Test]
        public void SupportButtonCheck()
        {
            LoginApplicationAndChangesDistributor("Support Button ");
            HomePage.NavigateToCustomizePage();
            VerifySupportAndHelpButtonShownIfUncheckIncludeCheckbox();
            VerifySupportAndHelpButtonShownIfCheckIncludeCheckbox();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Support Button Script");
        }

        #region Private Method
        /// <summary>
        /// Login to the application and set distributor as AutoTest_PHTest
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");
        }

        private string VerifyHelpButton()
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("(//button[contains(text(),'Help')])[1]"));

                if (CommonMethod.element.Displayed)
                {
                    return "The Help button appears when the include support checkbox is check";
                }
                else
                {
                    return "The Help button disappears when the include support checkbox is Unchecked";
                }
            }
            catch (NoSuchElementException)
            {
                return "The Help button disappears when the include support checkbox is Unchecked";
            }
        }

        private string VerifyIncludeSupport()
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("//button[@id='feedbackBtn']"));

                if (CommonMethod.element.Displayed)
                {
                    return "The Support button appears when the include support checkbox is check";
                }
                else
                {
                    return "The support button disappears when the include support checkbox is Unchecked";
                }
            }
            catch (NoSuchElementException)
            {
                return "The support button disappears when the include support checkbox is Unchecked";
            }
        }

        private void VerifySupportAndHelpButtonShownIfCheckIncludeCheckbox()
        {
            // Click on checkbox
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='IncludeFeedback']")));

            if (!CommonMethod.element.Selected)
            {
                CommonMethod.element.Click();
            }

            Console.WriteLine("Check the Support Checkbox");
            ExtentTestManager.TestSteps("Check the Support Checkbox'");
            Customize.ClickSaveButton();
            Console.WriteLine("In the home Page:");
            ExtentTestManager.TestSteps("In the home Page:");
            string home = VerifyIncludeSupport();
            Assert.That(home, Is.EqualTo("The Support button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Support button appears when the include support checkbox is check");
            Console.WriteLine("The Support button appears when the include support checkbox is check");
            HomePage.ClicksStartFromScratch();
            Console.WriteLine("In the default job:");
            ExtentTestManager.TestSteps("In the default job:");
            string defaultJob = VerifyIncludeSupport();
            Assert.That(defaultJob, Is.EqualTo("The Support button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Support button appears when the include support checkbox is check");
            Console.WriteLine("The Support button appears when the include support checkbox is check");
            string help = VerifyHelpButton();
            Assert.That(help, Is.EqualTo("The Help button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Help button appears when the include support checkbox is check");
            Console.WriteLine("The Help button appears when the include support checkbox is check");
        }

        private void VerifySupportAndHelpButtonShownIfUncheckIncludeCheckbox()
        {
            // Click on checkbox
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='IncludeFeedback']")));

            if (CommonMethod.element.Selected)
            {
                CommonMethod.element.Click();
            }

            Console.WriteLine("Uncheck the Support Checkbox");
            ExtentTestManager.TestSteps("Uncheck the Support Checkbox'");
            Customize.ClickSaveButton();
            Console.WriteLine("In the home Page:");
            ExtentTestManager.TestSteps("In the home Page:");
            string home = VerifyIncludeSupport();
            Assert.That(home, Is.EqualTo("The support button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The support button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The support button disappears when the include support checkbox is Unchecked");
            HomePage.ClicksStartFromScratch();
            Console.WriteLine("In the default job:");
            ExtentTestManager.TestSteps("In the default job:");
            string defaultJob = VerifyIncludeSupport();
            Assert.That(defaultJob, Is.EqualTo("The support button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The support button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The support button disappears when the include support checkbox is Unchecked");
            string help = VerifyHelpButton();
            Assert.That(help, Is.EqualTo("The Help button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The Help button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The Help button disappears when the include support checkbox is Unchecked\n");
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToCustomizePage();
        }
    }
}
#endregion