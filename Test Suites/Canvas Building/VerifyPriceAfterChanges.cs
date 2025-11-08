using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class VerifyPrice : BaseClass
    {

        [Test]
        public void VerifyAll()
        {
            LoginApplicationAndChangesDistributor("Verify Price After Changes");

            // Verify prices in different environments
            string testPrice = VerifyPriceInEnvironment("Test");
            Driver.SwitchTo().NewWindow(WindowType.Tab);

            CommonMethod.GoToBetaEnvironment();
            string betaPrice = VerifyPriceInEnvironment("Beta");
            Driver.SwitchTo().NewWindow(WindowType.Tab);
            CommonMethod.GoToProductionEnvironment();
            string productionPrice = VerifyPriceInEnvironment("Production");

            // Assert that prices are the same across environments
            Assert.Multiple(() =>
            {
                Assert.That(testPrice, Is.EqualTo(betaPrice).And.EqualTo(productionPrice), "Prices are not the same on the Test, Beta, and Production Environments");
            });
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Verify Price After Changes");
        }

        #region Private Method

        private string VerifyPriceInEnvironment(string environment)
        {
            Changes();
            string price = DefaultJobElement.GetTheConfiguredPrice();
            Console.WriteLine($"Total configured price of {environment} environment: {price}");
            ExtentTestManager.TestSteps($"Total configured price of {environment} environment: {price}");
            return price;
        }

        private void Changes()
        {
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickAwning();
            DefaultJobElement.ClickFrontRight();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCupolas();
            DefaultJobElement.PlaceOpeningOnTheCanvasBuilding("Louvered", "Cup24x24", 10, 10);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
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
#endregion