using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;
using Locator = SmartBuildAutomation.Locators.Locator;


namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class EModeler : BaseClass
    {
        string pathFile = FolderPath.DocumentOfPA_208();

        [Test]
        public void EModelerEmail()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("eModeler - Auto Response");
            NavigateToDistributorPageAndUncheckRTONationalCheckBox();
            string postAcknowledgment = NavigateToTheFramingRulesPageAndCheckEmailCheckboxOfJob();

            string jobLink = UploadEModelerResponseDocFileInTheCustomizePage();
            string firstWindows = JobPage.OpenAnyJobCopyOfEModelerPage(jobLink);

            EModelerElement.EnterDetailsOfJobInTheViewJobLinkPage(firstWindows, postAcknowledgment, "Kritika Test Job");
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            CommonMethod.Wait(5);
            LoginGmailAccount();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of eModeler - Auto Response Script");
        }

        #region Private Method
        private static void EnterDetailsOfJobInTheViewJobLinkPage(string firstWindows,string pathValue)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(text(),'Submit For Quote')]")));
            CommonMethod.Wait(7);
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", CommonMethod.element);
            ExtentTestManager.TestSteps("Click on the Submit For Quote");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='submitMain']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='submitForm']//following :: input[@id='ProjectName'])[1]")));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys("Kritika Test Job").Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Enter data in name field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[contains(text(),'Email')])//following :: input[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys("kdhillon@gmail.com").Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Enter data in email field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Submit for Quote')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Submit For Quote");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[@id='w2ui-popup']//p[text()='{pathValue}']")));
            CommonMethod.Wait(3);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='OK']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the Ok button");
            CommonMethod.Wait(3);
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            CommonMethod.Wait(5);
        }

        private string OpenAnyJobCopyOfEModelerPage(string jobLink)
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{jobLink}', '_blank');");
            string firstWindows = WindowHandle();
            try
            {
                CommonMethod.PageLoader();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='introMain']")));
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='close-button']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ExtentTestManager.TestSteps("Open a new tab with the job link copied from eModeler ");
            return firstWindows;
        }

        private string UploadEModelerResponseDocFileInTheCustomizePage()
        {
            EModelerElement.UploadFile($@"{pathFile}/Canned_eModeler_Response.docx", "doc");
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps("The Email check box is already check");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//i[@id='startFromScratch']")));
            string jobLink = CommonMethod.element.Text;
            EModelerElement.ClickSaveButton();
            return jobLink;
        }

        private string NavigateToTheFramingRulesPageAndCheckEmailCheckboxOfJob()
        {
            NavigateToFramingRulesPage();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.FramingRules.checkEmailCheckbox)));
            if (!CommonMethod.element.Selected)
            {
                CommonMethod.element.Click();
                ExtentTestManager.TestSteps("Click on the Email check box");
                FramingRules.ClickSaveButton();
                HomePage.NavigateToEModeler();
            }
            else
            {
                ExtentTestManager.TestSteps("The Email check box is already check");
                NavigateToEModelerPage();
            }

            return EModelerElement.GetTheAcknowledgment();
        }

        private bool NavigateToEModelerPage()
        {
            HomePage.NavigateToEModeler();

            try
            {
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch(NoAlertPresentException)
            {
                return false;
            }

        }
        private static void NavigateToDistributorPageAndUncheckRTONationalCheckBox()
        {
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("Autotest_PHTest");
            Distributor.UncheckCheckboxesOfDistributorPage(13, "Using RTO National");
            Distributor.ClickSaveButton();
        }

        private void LoginGmailAccount()
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('https://mail.google.com/mail/', '_blank');");
            ExtentTestManager.TestSteps("Open new tab and login Gmail account");
            CommonMethod.Wait(3);
            string emailWindows = WindowHandle();
            CommonMethod.LoginGmail();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(3)).Perform();
            ExtentTestManager.TestSteps("Verify that the user received the eModeler Building Design email.");
        }

        private void NavigateToFramingRulesPage()
        {
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_AnonymousFramingRules();
            FramingRules.ClickJob();
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps("Navigate to Framing Rules Page");
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
    }
}
#endregion