using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class AdvancedPoleSetting : BaseClass
    {
        [Test]
        public void AdvancedEdit()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Never auto turn on Advanced Post Hole Settings in Advanced Edit");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(100, 150);
            ExtentTestManager.TestSteps("Apply the Overhead Door on the canvas Building");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            CheckFoundationMaterial();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report Never auto turn on Advanced Post Script");
        }

        #region Private Method
        private void CheckFoundationMaterial()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickFoundation();
            DefaultJobElement.CheckAdvancedPostHoleSettingsCheckboxCheckbox();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@name='FoundationAdvanced'])[1]")));
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            Console.WriteLine("Click on  the Advanced Post Hole Setting checkbox in the Main Building Page");
            ExtentTestManager.TestSteps("Click on  the Advanced Post Hole Setting checkbox in the Main Building Page");
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickEXT_1();
            FoundationElement();
        }

        private void FoundationElement()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickFoundation();
            VerifyCheckbox();
        }

        private void VerifyCheckbox()
        {
            if (DefaultJobElement.AdvancedPostHoleSettingsCheckbox().Selected)
            {
                Console.WriteLine("Verify that the Advanced Post Hole Setting checkbox is checked in the Advanced Edit Page");
                ExtentTestManager.TestSteps("Verify that the Advanced Post Hole Setting checkbox is checked in the Advanced Edit Page");
            }
            else
            {
                Console.WriteLine("Verify that the Advanced Post Hole Setting checkbox is unchecked in the Advanced Edit Page");
                ExtentTestManager.TestSteps("Verify that the Advanced Post Hole Setting checkbox is unchecked in the Advanced Edit Page");
                Assert.Fail("Verify that the Advanced Post Hole Setting checkbox is unchecked in the Advanced Edit Page");
            }
        }
    }
}
#endregion