using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class CheckOfQuotedJob : BaseClass
    {
        [Test]
        public void CheckOfQuoted()
        {
            LoginApplicationAndChangesDistributor("Price Check");
            HomePage.ClicksLargeCross();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            Assert.AreEqual("Create Job - SmartBuild Framer", Driver.Title, "Error: Incorrect page title after login");
            string actualPrice = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the Configured Price before job quoted");

            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Price Check");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ChangeStatusOfJob("Make Quote");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Price Check");
            CommonMethod.PageLoader();
            string quotedPrice = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the Configured Price after job quoted");

            // Check if the quoted price is the same as the configured price
            Assert.That(actualPrice, Is.EqualTo(quotedPrice), $"Error: The configured price of quoted job is not same with configured price of before quoted job");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Price Check Script");
        }

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
    }
}