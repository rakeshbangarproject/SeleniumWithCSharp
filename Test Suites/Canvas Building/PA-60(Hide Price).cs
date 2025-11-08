using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class HidePrice : BaseClass
    {

        [Test]
        public void ConfiguredPrice()
        {
            LoginApplicationAndChangesDistributor("Hide Price");

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.DoubleClickOnTheUntitled();

            Assert.That(DefaultJobElement.HideConfiguredPrice(), Is.EqualTo("Configured price is not displayed"));
            ExtentTestManager.TestSteps("Configured price is not displayed after double click on the untitled text");

            DefaultJobElement.ClickJobReview();

            Assert.That(SummaryTab(), Is.EqualTo("Summary Tab is not displayed"));
            ExtentTestManager.TestSteps("Summary tab is not displayed in the job review\n");

            DefaultJobElement.DoubleClickOnTheUntitled();

            Assert.That(SummaryTab(), Is.EqualTo("Summary Tab is displayed"));
            ExtentTestManager.TestSteps("Summary tab is displayed in the job review");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Hide Price Script");
        }

        #region privateMethods
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

        private string SummaryTab()
        {
            // Summary Tab is hide 
            if (Driver.FindElement(By.XPath("//div[text()='Summary']")).Displayed)
            {
                return "Summary Tab is displayed";
            }
            else
            {
                return "Summary Tab is not displayed";
            }
        }
    }
}
#endregion