using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestOnBuildersPage : BaseClass
    {
        #region XPath
        string NavigateField = "//a[normalize-space()='{0}']";
        string EnterInputField = "//input[@{0}='{1}']";
        #endregion

        [Test, Order(1)]
        public void BuildersPage()
        {
            ExtentTestManager.CreateTest("Smoke Test On Builders Page").Info("Login To AUTOTEST_EAGLEVIEW Distributor");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToTheBuilderPage();
            Builder.ClickAddNewBuilderButton();
            Builder.EnterNameInputField("Test Name Field");
            Checkboxes();
            Builder.BackToListButton();

            string aboutPageTitleDefault = Driver.Url;
            Assert.True(aboutPageTitleDefault.Equals(TestContext.Parameters.Get("DistributorPageURL")));
            ExtentTestManager.TestSteps("Verify that the page is redirect to the Distributor Page");
            HomePage.NavigateToTheBuilderPage();
            Builder.ClickAddNewBuilderButton();
            Builder.EnterNameInputField("Test Kritika Builder-1");
            Builder.ClickCreateButton();
            HomePage.NavigateToTheBuilderPage();
            Builder.ClickAddNewBuilderButton();
            Builder.EnterNameInputField("Test Kritika Builder-2");
            Builder.ClickCreateButton();

            HomePage.NavigateToTheBuilderPage();
            Builder.ClickAddNewBuilderButton();
            Builder.EnterNameInputField("Test Kritika Builder-3");
            Builder.ClickCreateButton();
            HomePage.NavigateToTheBuilderPage();
            Builder.ClickOnTheInviteUser("Test Kritika Builder-1");
            EnterDataInTheInviteUserField();
            CheckBoxesOfBuilderTable();
            JobButton();
            EmailVerification();
        }

        [Test, Order(2)]
        public void DeleteData()
        {
            ExtentTestManager.CreateTest("Delete Builder").Info("Login To AUTOTEST_EAGLEVIEW Distributor");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToTheBuilderPage();
            Delete();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Builder Page");
        }

        #region Private Method
        private void Checkboxes()
        {
            IReadOnlyList<IWebElement> checkboxes = Driver.FindElements(By.XPath("(//input[contains(@type,'checkbox')])"));
            foreach (IWebElement checkbox in checkboxes)
            {
                checkbox.Click();
            }

            ExtentTestManager.TestSteps("Check all checkboxes of New create Builder Page");
        }

        private void EmailVerification()
        {
            Driver.SwitchTo().NewWindow(WindowType.Tab);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("GMailPageURL"));
            ExtentTestManager.TestSteps("Navigate to Gmail account");

            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("//a[text()='Sign in']"));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[contains(@type,'email')]"))).SendKeys(TestContext.Parameters.Get("Username"));
                ExtentTestManager.TestSteps("Enter username");
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[contains(@type,'email')]"))).SendKeys(TestContext.Parameters.Get("Username"));
                ExtentTestManager.TestSteps("Enter username");
            }

            CommonMethod.Wait(5);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='identifierNext']//div)[1]//button")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the next button");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[contains(@type,'password')]"))).SendKeys(TestContext.Parameters.Get("Password"));
            ExtentTestManager.TestSteps("Enter Password");
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(),'Next')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(5)).Perform();
            ExtentTestManager.TestSteps("Click on the next button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(3)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@act,'19')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(3)).Perform();
            ExtentTestManager.TestSteps("The user login to GMail account successfully");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        public void CheckBoxesOfBuilderTable()
        {
            IReadOnlyList<IWebElement> checkboxes = Driver.FindElements(By.XPath("//input[@type='checkbox']"));
            foreach (IWebElement checkbox in checkboxes)
            {
                checkbox.Click();
            }
            ExtentTestManager.TestSteps("Click on the Invite User button");
        }

        public void EnterDataInTheInviteUserField()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EnterInputField, "id", "UserName")))).SendKeys("TestingData123");
            ExtentTestManager.TestSteps("Enter Data in the Username");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EnterInputField, "id", "CompanyAddress")))).SendKeys("Mumbai, India, Pin code-458556");
            ExtentTestManager.TestSteps("Enter Data in the Company Address");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EnterInputField, "id", "PhoneNumber")))).SendKeys("99256485655");
            ExtentTestManager.TestSteps("Enter Data in the Phone Number field");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EnterInputField, "id", "Email")))).SendKeys("kritika@keymark.com");
            ExtentTestManager.TestSteps("Enter Data in the Phone Number field");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//Select[@id='BillingAccount'])[1]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//Select[@id='BillingAccount'])[1]/option[2]"))).Click();
            ExtentTestManager.TestSteps("Change Billing Account");
            CommonMethod.Wait(2);
            Driver.Navigate().Back();
        }

        public void JobButton()
        {
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(NavigateField, "Jobs"))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Job Button");
            CheckAlert();

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            JobPage.OpenJob("Job3");
            CommonMethod.PageLoader();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='AUTOTEST_EAGLEVIEW BASE']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[text()='Test Kritika Builder-1'])[2]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the AUTOTEST_EAGLEVIEW BASE");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Yes button");
            CommonMethod.Wait(2);
            CommonMethod.PageLoader();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Test Kritika Builder-1']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Test Kritika Builder-1 builder");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[text()='Test Kritika Builder-2'])[2]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Test Kritika Builder-2 builder");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Yes button");
            CommonMethod.Wait(2);
            CommonMethod.PageLoader();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Test Kritika Builder-2']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Test Kritika Builder-2 builder");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[text()='Test Kritika Builder-3'])[2]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Test Kritika Builder-2 builder");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Yes button");
            CommonMethod.Wait(2);
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Verify that all builders are working");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[contains(text(),'Job List')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(2)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Job list button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='No']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the No button");
        }

        public void Delete()
        {
            string[] builderName = new string[3] { "Test Kritika Builder-1", "Test Kritika Builder-2", "Test Kritika Builder-3" };
            for (int i = 0; i < builderName.Length; i++)
            {
                Builder.DeleteBuilder(builderName[i]);
                HomePage.NavigateToTheBuilderPage();
            }
        }

        private bool CheckAlert()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
#endregion