using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class DistributorCheckBox : BaseClass
    {
        string NavigateToPage = "//a[normalize-space()='{0}']";

        [Test]
        public void DistributorPermission()
        {
            LoginApplicationAndChangesDistributor("Distributor Permission");

            Customize();
            HomePage.NavigateToDistributor();
            Assert.AreEqual("Distributors - SmartBuild Framer", Driver.Title, "Error: Incorrect page title after login");
            Assert.AreEqual(TestContext.Parameters.Get("DistributorPageURL"), Driver.Url, "Error: Incorrect page URL after login");
            Distributor.SearchInputField("AUTOTEST_PHTEST");
            Distributor.CheckAllCheckboxOfAutoTestDistributor();
            Distributor.UncheckCheckbox(12);
            Distributor.UncheckCheckbox(13);
            Distributor.ClickSaveButton();
            HomePage.ClicksHomeButton();

            AssertElementDisplayed(By.PartialLinkText("Start from Scratch"), "Verify that Start From Scratch button is not displayed in the 'Home' page after check the 'Can Start From Scratch' checkbox",
               "Verify that Start From Scratch button is displayed in the 'Home' page after check the 'Can Start From Scratch' checkbox");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NavigateToPage, "Settings")))).Click();
            ExtentTestManager.TestSteps("Click on the Setting tab");
            HomePage.VerifyElementInTheSettingList("Customize");
            HomePage.VerifyElementInTheSettingList("Setup Wizard");
            HomePage.VerifyElementInTheSettingList("Output Categories");
            HomePage.VerifyElementInTheSettingList("Colors");
            HomePage.VerifyElementInTheSettingList("Materials");
            HomePage.VerifyElementInTheSettingList("Texture Library");
            HomePage.VerifyElementInTheSettingList("Doors and Windows");
            HomePage.VerifyElementInTheSettingList("Span Table");
            HomePage.VerifyElementInTheSettingList("Product Systems");
            HomePage.VerifyElementInTheSettingList("Special Pricing");
            HomePage.VerifyElementInTheSettingList("Payment Schedule");
            HomePage.VerifyElementInTheSettingList("Framing Rules");
            HomePage.VerifyElementInTheSettingList("Packages");
            HomePage.VerifyElementInTheSettingList("Starting Models");
            HomePage.VerifyElementInTheSettingList("Outputs");

            HomePage.ClicksJobTab();
            JobPage.OpenJob("Price Check");
            CommonMethod.PageLoader();
            AssertElementDisplayed(By.Id("totalPrice"), "Verify that Configured Price is not shown in the Price check job after check the 'Can See Pricing' checkbox",
                "Verify that Configured Price is shown in the Price check job after check the 'Can See Pricing' checkbox");

            DefaultJobElement.ClickJobReview();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Distributor Permission Script");
        }

        #region Private Method(s)
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
        
        private void Customize()
        {
            HomePage.NavigateToDistributor();
            Assert.AreEqual("Distributors - SmartBuild Framer", Driver.Title, "Error: Incorrect page title after login");
            Assert.AreEqual(TestContext.Parameters.Get("DistributorPageURL"), Driver.Url, "Error: Incorrect page URL after login");

            // Check all checkboxes
            Distributor.SearchInputField("AUTOTEST_PHTEST");

            // Uncheck all checkboxes
            UncheckAllDistributorCheckboxes();
            Distributor.ClickSaveButton();
            Distributor.RefreshButton();

            // Verify that the elements are not shown in the Setting list
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NavigateToPage, "Settings")))).Click();
            ExtentTestManager.TestSteps("Click on the Setting tab");
            Distributor.VerifyElementNotInTheSettingList("Customize");
            Distributor.VerifyElementNotInTheSettingList("RTO National Config");
            Distributor.VerifyElementNotInTheSettingList("Setup Wizard");
            Distributor.VerifyElementNotInTheSettingList("Output Categories");
            Distributor.VerifyElementNotInTheSettingList("Colors");
            Distributor.VerifyElementNotInTheSettingList("Materials");
            Distributor.VerifyElementNotInTheSettingList("Texture Library");
            Distributor.VerifyElementNotInTheSettingList("Doors and Windows");
            Distributor.VerifyElementNotInTheSettingList("Span Table");
            Distributor.VerifyElementNotInTheSettingList("Product Systems");
            Distributor.VerifyElementNotInTheSettingList("TaaS Config");
            Distributor.VerifyElementNotInTheSettingList("Special Pricing");
            Distributor.VerifyElementNotInTheSettingList("Payment Schedule");
            Distributor.VerifyElementNotInTheSettingList("Framing Rules");
            Distributor.VerifyElementNotInTheSettingList("Packages");
            Distributor.VerifyElementNotInTheSettingList("Starting Models");
            HomePage.ClicksHomeButton();

            AssertElementDisplayed(By.PartialLinkText("Start from Scratch"), "Verified that Start From Scratch button is not displayed in the 'Home' page after unchecked the 'Can Start From Scratch' checkbox",
                "Start From Scratch button is displayed in the 'Home' page after unchecked the 'Can Start From Scratch' checkbox");

            HomePage.ClicksJobTab();
            JobPage.OpenJob("Price Check");
            CommonMethod.PageLoader();
            AssertElementDisplayed(By.Id("totalPrice"), "Verified that Configured Price is not shown in the Price check job after unchecked the 'Can See Pricing' checkbox",
                "Verified that Configured Price is shown in the Price check job after unchecked the 'Can See Pricing' checkbox");

            DefaultJobElement.ClickHomeButton();
        }

        private void UncheckAllDistributorCheckboxes()
        {
            for (int i = 1; i <= 19; i++)
            {
                try
                {
                    Distributor.UncheckCheckbox(i);
                }
                catch(StaleElementReferenceException)
                {
                    Distributor.UncheckCheckbox(i);
                }

                CommonMethod.Wait(1);
                Distributor.TableScrollRightSide("100", "0");
            }
            ExtentTestManager.TestSteps("Uncheck all checkbox is check");
        }

        private void AssertElementDisplayed(By by, string failureMessage, string successMessage)
        {
            try
            {
                if (Driver.FindElement(by).Displayed)
                {
                    ExtentTestManager.TestSteps(successMessage);
                }
            }
            catch
            {
                ExtentTestManager.TestSteps(failureMessage);
            }
        }
    }
}
#endregion