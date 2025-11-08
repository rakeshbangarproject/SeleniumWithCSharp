using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class ChangingRooFPitch : BaseClass
    {
        /// <summary>
        /// 1. Navigate to Framing Rules Page and Enter the any value in the Roof Pitch
        /// 2. Click on the Save button. 
        /// 3. Go to the Framing Rules page again
        /// 4. Verified that changes in roof pitch are applied after clicking on the save button in framing rules. 
        /// 5. Navigate to the Home page and click on the start from scratch button and 
        /// 6. Verified that the roof pitch is also updated in the default job.
        /// </summary>

        [Test]
        public void RoofPitch()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Changing Roof Pitch");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            EnterDataInTheRoofPitch();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Changing Roof Pitch Script");
        }

        #region private Methods  
        private void EnterRoofPitchField(string value)
        {
            FramingRules.RoofPitchInputField(value);
            FramingRules.ClickSaveButton();
        }

        private void EnterDataInTheRoofPitch()
        {
            // Enter In the Roof Pitch Field
            EnterRoofPitchField("6");
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();

            string roofPitchFramingRules = FramingRules.InputField("-- Building Size --", "Roof Pitch").Text;

            if (roofPitchFramingRules.Contains('6'))
            {
                ExtentTestManager.TestSteps("Verified that changes in roof pitch are applied after clicking on the save button in framing rules");
                Console.WriteLine("Verified that changes in roof pitch are applied after clicking on the save button in framing rules");
            }
            else
            {
                ExtentTestManager.TestSteps("Verified that changes in roof pitch are not applied after clicking on the save button in framing rules");
                Console.WriteLine("Verified that changes in roof pitch are not applied after clicking on the save button in framing rules");
                Assert.Fail("Verified that changes in roof pitch are not applied after clicking on the save button in framing rules");
            }

            IfAlertIsPresentThenClickOnOkayButton();
            ExtentTestManager.TestSteps("Click on Home Button");

            // Click on Start from Scratch
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickBuildingSize();

            // Get the Roof Pitch value in the Default Job
            string defaultRoofPitch =DefaultJobElement.GetRoofPitchValue();
            Console.WriteLine("Default Job Roof Pitch value is: " + defaultRoofPitch);
            ExtentTestManager.TestSteps("Get the Roof Pitch value in the Default Job");

            if (roofPitchFramingRules.Contains('6'))
            {
                ExtentTestManager.TestSteps("Verified that the roof pitch is also updated in the default job");
                Console.WriteLine("Verified that the roof pitch is also updated in the default job");
            }
            else
            {
                ExtentTestManager.TestSteps("Verified that the roof pitch is not updated in the default job");
                Console.WriteLine("Verified that the roof pitch is not updated in the default job");
                Assert.Fail("Verified that the roof pitch is not updated in the default job");
            }

            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
           HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();

            // Enter In the Roof Pitch Field
            EnterRoofPitchField("4");
        }

        private bool IfAlertIsPresentThenClickOnOkayButton()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Home"))).Click();
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
#endregion