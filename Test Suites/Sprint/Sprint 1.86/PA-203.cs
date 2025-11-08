using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class DoorShifting : BaseClass
    {
        [Test]
        public void QuoteJob()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Newly Quoted jobs are shifting the opening up");
            HomePage.ClicksStartFromScratch();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.PlaceOpening(100, 100);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string updatedValue = DefaultJobElement.GetTheConfiguredPrice();
            VerifyThatDoorPlaceOnTheCanvasBuilding(initialValue, updatedValue);
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("New Quote Job");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();

            DefaultJobElement.ChangeStatusOfJob("Make Quote");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("New Quote Job");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on New Quote Job Job View button");
            DefaultJobElement.ClickView3DEdit();
            DefaultJobElement.ClickChangeView();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.BackLeft)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            DefaultJobElement.OpenPlaceOpening(150,80);

            string sillHeight = DefaultJobElement.GetSillHeightValue();
            Assert.That(sillHeight, Is.EqualTo("0'"), "Verify that the walk door is shifted up");
            Console.WriteLine("Verify that the walk door is not shifted up");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report Newly Quoted jobs are shifting the opening up Script");
        }

        private void VerifyThatDoorPlaceOnTheCanvasBuilding(string initialValue, string currentValue)
        {
            if (initialValue.Equals(currentValue))
            {
                Console.WriteLine($"Verify that Door is not place on the canvas building");
                ExtentTestManager.TestSteps($"Verify that Door is not place on the canvas building");
                Assert.Fail($"Verify that Door is not place on the canvas building");
            }
            else
            {
                Console.WriteLine($"Verify that Door is place on the canvas building");
                ExtentTestManager.TestSteps($"Verify that Door is place on the canvas building");
            }
        }
    }
}