using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class ConfiguredPrice : BaseClass
    {

        [Test]
        public void ConfiguredAllPrice()
        {
            LoginApplicationAndChangesDistributor("Configured Price");
           
            string xPath = "(//div[@id='model-group']//descendant :: span[{0}])[1]";

            for (int i = 1; i <= 20; i++)
            {
                Assert.AreEqual(TestContext.Parameters.Get("HomePageURL"), Driver.Url, "Error: Incorrect page URL after Click on the Home button of job");
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(xPath, i))));
                string jobName = CommonMethod.element.Text;
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
                CommonMethod.PageLoader();
                ExtentTestManager.TestSteps($"Click on {jobName}");
                VerifyPrice(jobName);
            }
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Configured Price Script");
        }

        #region Compare Total Price and Quote Price
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

        public void VerifyPrice(string jobName)
        {
            string actualPrice = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClicksJobButton();
            string quotePrice = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@name='Quote'])[1]"))).GetAttribute("value");

            // Assertion: Check if actual price is equal to the latest price
            Assert.AreEqual(actualPrice, quotePrice, $"Error: Prices are different. Actual Price: {actualPrice}, Quote Price: {quotePrice}");

            Console.WriteLine($"Prices are equal on the {jobName}. Actual Price: {actualPrice}, Quote Price: {quotePrice}");
            ExtentTestManager.TestSteps($"Prices are equal on the {jobName}. Actual Price: {actualPrice}, Quote Price: {quotePrice}");

            DefaultJobElement.ClickHomeButton();
        }
        #endregion
    }
}