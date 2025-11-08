using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Roofing_Passport")]
    class RoofingPassword : BaseClass
    {
        [Test]
        public void CladdingColor()
        {
            ExtentTestManager.CreateTest("Roofing Password Calculation");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();

            // Get the total panel sf value
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='totalRP']")));
            string totalPanelSF = CommonMethod.element.Text;
            ExtentTestManager.TestSteps(" Get the total panel sf value");
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickROOF_1();
            DefaultJobElement.ClickColorTabOfRoofingPassportFromAdvancedEdit();
            DefaultJobElement.SelectRoofColorFromAdvancedEdit("Mill Finish");
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.ClickCanvas3DViewButton();

            // Get the total panel sf value
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[@id='totalRP']")));
            string totalPanel = CommonMethod.element.Text;

            // Verify Total Panel SF value
            if (totalPanel == totalPanelSF)
            {
                Console.WriteLine("After changes the Total Pane value are same");
                ExtentTestManager.TestSteps("After changes the Total Pane value are same");
            }
            else
            {
                Console.WriteLine("After changes the Total Pane value are not same");
                ExtentTestManager.TestSteps("After changes the Total Pane value are not same");
                Assert.That(totalPanel, Is.EqualTo(totalPanelSF));
            }

            DefaultJobElement.NavigateToHomePage();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Roofing Password Calculation");
        }
    }
}