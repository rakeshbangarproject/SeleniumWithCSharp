using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class AllOnAndAllOff : BaseClass
    {

        [Test, Order(1)]
        public void CheckBox()
        {
            LoginApplicationAndChangesDistributor("All On and All Off ");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Test Button");
            CommonMethod.PageLoader();
            DefaultJobElement.ClicksOutputButton();
            AllOnButtons();
            AllOffButton();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='AllOn']")));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click on the All On button");

            try
            {
                DefaultJobElement.ClicksDownloadButton();
                string zipFile = CommonMethod.DownloadFile();
                Assert.IsNotNull(zipFile, "The zip file is not null.");
                CommonMethod.element = Driver.FindElement(By.XPath("//td[contains(text(),'Home')]"));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            }
            catch (NoSuchElementException)
            {
                string errorMessage = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//p[@class='text-danger'])[1]"))).Text;
                Assert.Fail(errorMessage);
            }
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of All On and All Script");
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

        private void AllOnButtons()
        {
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='AllOn']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            if (CommonMethod.element.Displayed)
            {
                Console.WriteLine("All On button is Displayed");
                ExtentTestManager.TestSteps("All On button is Displayed");
            }
            else
            {
                Console.WriteLine("All On button is not Displayed");
                ExtentTestManager.TestSteps("All On button is not Displayed");
                Assert.Fail();
            }
            CommonMethod.Wait(2);
            List<CheckboxInfo> checkboxInfoList = new List<CheckboxInfo>();

            // Locate all checkbox elements
            IReadOnlyCollection<IWebElement> checkboxElements = Driver.FindElements(By.XPath("(//div[@class='w2ui-page page-0'])[3]//input[@type='checkbox']"));

            // Iterate through each checkbox element
            foreach (IWebElement checkbox in checkboxElements)
            {
                string checkboxId = checkbox.GetAttribute("id");
                bool isChecked = checkbox.Selected;

                // Add checkbox information to the list
                checkboxInfoList.Add(new CheckboxInfo { Id = checkboxId, IsChecked = isChecked });
            }
            Assert.IsTrue(checkboxInfoList.All(info => info.IsChecked), "All checkboxes are not checked.");
            ExtentTestManager.TestSteps("After clicking the 'All On' button, the assertion confirms that all checkboxes are checked");

            // Print checkbox information
            foreach (var checkboxInfo in checkboxInfoList)
            {
                Console.WriteLine($"Checkbox ID: {checkboxInfo.Id} - Checked: {checkboxInfo.IsChecked}");
                ExtentTestManager.TestSteps($"Checkbox ID: {checkboxInfo.Id} - Checked: {checkboxInfo.IsChecked}");
            }
        }

        private void AllOffButton()
        {
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='AllOff']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();

            if (CommonMethod.element.Displayed)
            {
                Console.WriteLine("All Off button is Displayed");
                ExtentTestManager.TestSteps("All Off button is Displayed");
            }
            else
            {
                Console.WriteLine("All Off button is not Displayed");
                ExtentTestManager.TestSteps("All Off button is not Displayed");
                Assert.Fail("All Off button is not Displayed");
            }
            CommonMethod.Wait(2);

            // List to store checkbox information
            List<CheckboxInfo> checkboxInfoList = new List<CheckboxInfo>();

            // Locate all checkbox elements
            IReadOnlyCollection<IWebElement> checkboxElements = Driver.FindElements(By.XPath("(//div[@class='w2ui-page page-0'])[3]//input[@type='checkbox']"));

            // Iterate through each checkbox element
            foreach (IWebElement checkbox in checkboxElements)
            {
                string checkboxId = checkbox.GetAttribute("id");
                bool isChecked = checkbox.Selected;

                // Add checkbox information to the list
                checkboxInfoList.Add(new CheckboxInfo { Id = checkboxId, IsChecked = isChecked });
            }
            Assert.IsTrue(checkboxInfoList.All(info => !info.IsChecked), "All checkboxes are not unchecked.");
            ExtentTestManager.TestSteps("After clicking the 'All Off' button, the assertion confirms that all checkboxes are unchecked");

            // Print checkbox information
            foreach (var checkboxInfo in checkboxInfoList)
            {
                Console.WriteLine($"Uncheckbox ID: {checkboxInfo.Id} - Unchecked: {!checkboxInfo.IsChecked}");
                ExtentTestManager.TestSteps($"Uncheckbox ID: {checkboxInfo.Id} - Unchecked: {!checkboxInfo.IsChecked}");
            }
        }

        public class CheckboxInfo
        {
            public string Id { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}
#endregion