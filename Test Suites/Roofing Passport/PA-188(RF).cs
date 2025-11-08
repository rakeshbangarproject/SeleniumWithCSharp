using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Roofing_Passport")]
    public class RPFMetal : BaseClass
    {
        #region XPath
        public string superPro5V = "//div[contains(text(),'Super Pro 5V')]";
        public string standingPro24GA = "//div[contains(text(),'Pro-Loc Standing Seam 24GA')]";
        public string standingPro26GA = "//div[contains(text(),'Pro-Loc Standing Seam 26GA')]";
        public string standingPro32GA = "//div[contains(text(),'Pro-Loc Standing Seam 032AL')]";
        public string testSuperPro5V = "Select Roof System “Super Pro 5V";
        public string testStandingPro24GA = "Select Roof System “Pro Loc Standing Seam 24GA";
        public string testStandingPro26GA = "Select Roof System “Pro Loc Standing Seam 24GA";
        public string testStandingPro32GA = "Select Roof System “Pro Loc Standing Seam 032AL";
        #endregion

        [Test]
        public void WastePanel()
        {
            ExtentTestManager.CreateTest("RPS Metal Roofing Systems Contractor database");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Job3");
            CommonMethod.PageLoader();

            string[] xpathString = new string[4] { superPro5V, standingPro24GA, standingPro26GA, standingPro32GA };
            string[] testName = new string[4] { "Super Pro 5V", "Pro-Loc Standing Seam 24GA", "Pro-Loc Standing Seam 26GA", "Pro-Loc Standing Seam 032AL" };
            for (int j = 0; j < testName.Length;)
            {
                for (int i = 0; i < xpathString.Length; i++)
                {
                    DefaultJobElement.SelectRoofSystemDropdownOfRoofingPassport(testName[i]);
                    CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

                    CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(@id,'totalRW')]")));
                    string panelValue = CommonMethod.element.Text;

                    if (panelValue.Contains("-100.00%"))
                    {
                        Assert.That(panelValue, Is.EqualTo("-100.00%"), "Verify that the Panel waste is shown as -100%");
                    }
                    else
                    {
                        ExtentTestManager.TestSteps("Verify that the Panel waste is not shown as -100%");
                        Console.WriteLine("The Panel waste is not shown as -100%");
                    }
                    j++;
                }
            }

            DefaultJobElement.ClickJobListButton();
            DefaultJobElement.NavigateToHomePage();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of RPS Metal Roofing Systems Contractor database");
        }
    }
}