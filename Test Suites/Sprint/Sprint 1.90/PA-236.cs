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
    public class CustomizePermission : BaseClass
    {

        [Test, Order(1)]
        public void Disconnect()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Disconnect Can Customize permission from EModeler");
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("Autotest_PHTest");
            Distributor.UncheckCheckboxesOfDistributorPage(1, "Can Customize");
            Distributor.UncheckCheckboxesOfDistributorPage(13, "Using RTO National");
            Distributor.ClickSaveButton();
            HomePage.ClicksHomeButton();
            HomePage.ClicksHomeButton();
            HomePage.VerifyElementIsNotShownInTheSettingList("Customize");
            HomePage.EModeler().Click();
            ExtentTestManager.TestSteps("Click on EModeler tab'");

            string jobLink = EModelerElement.GetTheEModelerLink("30x40x16");
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{jobLink}', '_blank');");
            string firstWindows = CommonMethod.WindowHandle();
            CommonMethod.PageLoader();

            if (CommonMethod.IsElementPresent(By.XPath("//div[@id='introMain']")))
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='introMain']")));
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='close-button']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                CommonMethod.Wait(1);
            }

            ExtentTestManager.TestSteps($"If the Can Customize checkbox is unchecked, Verify that the EModeler job opens successfully.");
            Console.WriteLine("If the Can Customize checkbox is unchecked, Verify that the EModeler job opens successfully.");
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            HomePage.ClicksHomeButton();
        }

        [Test, Order(2)]
        public void ResetTheCustomizeCheckbox()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Changes the distributor checkbox");
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("Autotest_PHTest");
            Distributor.CheckCheckboxes(1, "Can Customize");
            Distributor.ClickSaveButton();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Disconnect Can Customize permission from EModeler");
        }
    }
}
