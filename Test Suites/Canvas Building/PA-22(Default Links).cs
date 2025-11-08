using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Canvas")]
    class DefaultLinks : BaseClass
    {
        #region XPath 
        By aboutPage = By.PartialLinkText("About");
        By contactPage = By.PartialLinkText("Contact");
        #endregion

        [Test]
        public void OverrideDefaultLinks()
        {
            LoginApplicationAndChangesDistributor("Override Default Links");
            HomePage.NavigateToCustomizePage();
            EnterDataInTheHomeAboutAndContactField();
            OpenNewTabForLogo(TestContext.Parameters.Get("GooglePageURL"), TestContext.Parameters.Get("WikipediaPageURL"), TestContext.Parameters.Get("FacebookPageURL"));
            ClearDataFromHomeAboutContactField();
            OpenNewTabForLogo(TestContext.Parameters.Get("SmartBuildSystemPageURL"), TestContext.Parameters.Get("SmartBuildResourcesPageURL"), TestContext.Parameters.Get("SmartBuildContactPageURL"));
        }
        
        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Override Default Links Script");
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

        private void EnterDataInTheHomeAboutAndContactField()
        {
            Customize.EnterDataInTheHomeField(TestContext.Parameters.Get("GooglePageURL"));
            Customize.EnterDataInTheAboutField(TestContext.Parameters.Get("WikipediaPageURL"));
            Customize.EnterDataInTheContactField(TestContext.Parameters.Get("FacebookPageURL"));
            Customize.ClickSaveButton();
        }

        private void OpenNewTabForLogo(string logoLink, string aboutLink, string contactLink)
        {
            string firstWindows = NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='SmartBuild']"))).Click();
            CommonMethod.Wait(10);
            string logoPageTitleDefault = Driver.Url;
            Assert.True(logoPageTitleDefault.Contains(logoLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the logo icon is redirected to the {logoPageTitleDefault}");

            NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(aboutPage)).Click();
            CommonMethod.Wait(10);
            string aboutPageTitleDefault = Driver.Url;
            Assert.True(aboutPageTitleDefault.Contains(aboutLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the about button is redirected to the {logoPageTitleDefault}");

            NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(contactPage)).Click();
            CommonMethod.Wait(10);
            string contactPageTitleDefault = Driver.Url;
            Assert.True(contactPageTitleDefault.Contains(contactLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the contact button is redirected to the {logoPageTitleDefault}");

        }

        private string NavigateToJobPage()
        {
            string jobLink = TestContext.Parameters.Get("HomePageURL");
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{jobLink}', '_blank');");
            string firstWindows = WindowHandle();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            return firstWindows;
        }

        private string WindowHandle()
        {
            // Switch to the new window
            string mainHandle = Driver.CurrentWindowHandle;
            foreach (string handle in Driver.WindowHandles)
            {
                if (handle != mainHandle)
                {
                    Driver.SwitchTo().Window(handle);
                    break;
                }
            }
            return mainHandle;
        }

        private void ClearDataFromHomeAboutContactField()
        {
            HomePage.NavigateToCustomizePage();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("HomeLink"))).Clear();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("AboutLink"))).Clear();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("ContactLink"))).Clear();
            ExtentTestManager.TestSteps("Clear data from the Home, About, and Contact field");
            Customize.ClickSaveButton();
        }
    }
}
#endregion