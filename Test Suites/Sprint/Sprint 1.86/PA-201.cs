using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Resource;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class Separators : BaseClass
    {
        [Test]
        public void JobQuestions()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Allow user to define separators in the Job Questions");
            CreateNewSeparator();
            NavigateToTheFramingRulesAddAndDeletePrompt();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of separators in the Job Questions Script");
        }

        #region Private Method 
        private void NavigateToTheFramingRulesAddAndDeletePrompt()
        {
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickJob();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='-- Header Line Test --'])[1]//following::button[contains(@onclick,'HeaderLineTest')][2]"))).Click();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-popup']//button[text()='Yes']"))).Click();
        }

        public void CreateNewSeparator()
        {
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickJob();
            FramingRules.ClickAddButton();
            ClickOnEDitButtonAndEnterDataInPromptField();
            bool newSeparator = CheckSeparatorShownInTheFramingRules(TestData.Separator.newSeparator); ;
            Assert.That(newSeparator, Is.EqualTo(true), "Verify that the new Separator is not create");
            Console.WriteLine($"Verify that the new Separator is created");
            ExtentTestManager.TestSteps($"Verify that the new Separator is created");

            FramingRules.ClickPreviewButton();
            FramingRules.ClickJobButtonPreviewFrame();
            bool checkSeparatorShownInThePreviewOfFramingRule = CheckSeparatorShownInTheFramingRules(TestData.Separator.searchElementFromJobTableOfPreview);
            Assert.That(checkSeparatorShownInThePreviewOfFramingRule, Is.EqualTo(true), "Verify that the new Separator is not shown in the Preview");
            Console.WriteLine($"Verify that the new Separator is shown in the Preview iFrame");
            ExtentTestManager.TestSteps($"Verify that the new Separator is shown in the Preview iFrame");
            DefaultJobElement.ClickCrossIcon();
            FramingRules.ClickSaveButton();
            HomePage.HomeButton().Click();
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClicksJobButton();
            bool checkSeparatorShownInTheJob = CheckSeparatorShownInTheFramingRules(TestData.Separator.jobTableMenuLists);
            Assert.That(checkSeparatorShownInTheJob, Is.EqualTo(true), "Verify that the new Separator is not shown in the Default Job");
            Console.WriteLine($"Verify that the new Separator is shown in the Default Job");
            ExtentTestManager.TestSteps($"Verify that the new Separator is shown in the Default Job");
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
        }

        private bool CheckSeparatorShownInTheFramingRules(string xpath)
        {
            IReadOnlyList<IWebElement> row = Driver.FindElements(By.XPath(xpath));

            foreach (IWebElement webElement in row)
            {
                if (webElement.Text.Contains("Header Line Test"))
                {
                    CommonMethod.GetActions().Click(webElement).Perform();
                    return true;
                }
            }
            return false;
        }

        private void ClickOnEDitButtonAndEnterDataInPromptField()
        {
            FramingRules.SelectTypeOptionOfEditNewQuestionTable("Separator");
            FramingRules.EnterPrompt("Header Line Test");
            FramingRules.ClickSaveButtonOfDoEditFieldOnJobPage();
        }
    }
}
#endregion