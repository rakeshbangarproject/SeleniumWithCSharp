using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class SettingInterior : BaseClass
    {
        [Test]
        public void InteriorWallSide()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Set Interior Wall Side as a None");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            CommonMethod.Wait(1);
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("6900");
            SetSheathingAsNone();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Set Interior Wall Side as a None Script");
        }

        #region Private Methods
        private void SetSheathingAsNone()
        {
            SetNoneInTheFramingRulesOfSheathingSides();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickInteriorWall();

            string sheathingSideA = DefaultJobElement.GetTheSheathingSideAValue();
            string sheathingSideB = DefaultJobElement.GetTheSheathingSideAValue();

            if (!sheathingSideA.Equals("None") | !sheathingSideB.Equals("None"))
            {
                ExtentTestManager.TestSteps($"Verify that both sheathing side options are not shown as none");
                Assert.Fail("Verify that both sheathing side options are not shown as none");
            }
            ExtentTestManager.TestSteps($"Verify that both sheathing side options are shown as none");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();

            DefaultJobElement.ClickDividerWall();
            CommonMethod.Wait(2);
            string sideA = DefaultJobElement.GetTheSideAValue();
            string sideB = DefaultJobElement.GetTheSideBValue();

            if (sideA.Equals("None") && sideB.Equals("None"))
            {
                DefaultJobElement.PlaceOpening(100, 100);
                ExtentTestManager.TestSteps($"Place a divider wall with both sides none");
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                DefaultJobElement.ClickSyncButton();
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                DefaultJobElement.ClickCrossIcon();
                string currentValue = DefaultJobElement.GetTheConfiguredPrice();
                VerifyThatDividerWallPlaceOnTheCanvasBuilding(initialValue, currentValue);
            }
            else
            {
                DefaultJobElement.SelectSideAElement("None");
                DefaultJobElement.SelectSideBElement("None");
                DefaultJobElement.PlaceOpening(100, 100);
                DefaultJobElement.ClickSyncButton();
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                DefaultJobElement.ClickCrossIcon();
                string currentValue = DefaultJobElement.GetTheConfiguredPrice();
                VerifyThatDividerWallPlaceOnTheCanvasBuilding(initialValue, currentValue);
                ExtentTestManager.TestSteps($"Place a divider wall with both sides none");
            }

            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Interior Wall");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Interior Wall");
            CommonMethod.PageLoader();

            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickRoofButton();
            DefaultJobElement.Click3DEdit();
            CommonMethod.Wait(2);
            DefaultJobElement.OpenPlaceOpening(100,100);

            string sideA_AfterChanges = DefaultJobElement.GetTheSideAValue();
            string sideB_AfterChanges = DefaultJobElement.GetTheSideBValue();

            if (sheathingSideA.Equals(sideA_AfterChanges) && sheathingSideB.Equals(sideB_AfterChanges))
            {
                ExtentTestManager.TestSteps($"Verify that both sheathing sides A and B are still shown as none");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verify that both sheathing sides A and B are not still shown as none");
                Assert.Fail("Verify that both sheathing sides A and B are not still shown as none");
            }

            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickHomeButton();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='No']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Interior Wall");
        }

        private void SetNoneInTheFramingRulesOfSheathingSides()
        {
            string sheathingA = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.getTheElementOfDropdown, "Sheathing Side A")))).Text;
            string sheathingB = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.getTheElementOfDropdown, "Sheathing Side B")))).Text;

            if (!sheathingA.Equals("None") | !sheathingB.Equals("None"))
            {
                SetSheathingSideToNone("Sheathing Side A");
                SetSheathingSideToNone("Sheathing Side B");
                FramingRules.ClickSaveButton();
                DefaultJobElement.NavigateToHomePage();
                ExtentTestManager.TestSteps($"Click on the Home button");
            }
            else
            {
                DefaultJobElement.NavigateToHomePage();
                ExtentTestManager.TestSteps($"Click on the Home button");
            }
        }

        private void SetSheathingSideToNone(string sheathingType)
        {
            string sheathing = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.FramingRules.selectNoneValue, sheathingType)))).Text;

            if (!sheathing.Equals("None"))
            {
                FramingRules.SetNoneValueInTheDropdown(sheathingType);
            }
        }

        private void VerifyThatDividerWallPlaceOnTheCanvasBuilding(string initialValue, string currentValue)
        {
            if (initialValue.Equals(currentValue))
            {
                Console.WriteLine($"Verify that divider wall is not place on the canvas building");
                ExtentTestManager.TestSteps($"Verify that divider wall is not place on the canvas building");
                Assert.Fail($"Verify that divider wall is not place on the canvas building");
            }
            else
            {
                Console.WriteLine($"Verify that divider wall is place on the canvas building");
                ExtentTestManager.TestSteps($"Verify that divider wall is place on the canvas building");
            }
        }
    }
}
#endregion