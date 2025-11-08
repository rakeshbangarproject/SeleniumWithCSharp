using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._88
{
    [TestFixture, Category("Sprint_1._88")]
    public class InteriorWall : BaseClass
    {
        [Test]
        public void HOTPATCH()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH - Interior wall width is zero on input");
            HomePage.ClicksStartFromScratch();
            ApplyWallLinerElement();
            PlaceWallInThe2DView();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH - Interior wall width is zero on input");
        }

        #region Private Methods 
        private void ApplyWallLinerElement()
        {
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickWallLiner();
            DefaultJobElement.CheckedTheHasLinerPanelsCheckbox();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.CheckedTheHasInteriorWainscotCheckbox();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontLeft();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).ClickAndHold().MoveByOffset(0, -200).Release().Perform();
        }

        private void PlaceWallInThe2DView()
        {
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickInteriorWallsFromThe2DView();
            DefaultJobElement.ClickAddRoom();
            DefaultJobElement.PlaceOpening(270, 270);
            ExtentTestManager.TestSteps("Place Room in the 2D view");
            DefaultJobElement.ClickCrossIcon();

            DefaultJobElement.DoubleClickOnThePlaceInteriorWallOnThe2DView("INT-1");
            string sideAElement = DefaultJobElement.GetTheSideAValue();
            string sideBElement = DefaultJobElement.GetTheSideBValue();
            Console.WriteLine(sideAElement == sideBElement);
            ExtentTestManager.TestSteps("Get the data of Side A and Side B element");
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.SaveButtonOf2DView();

            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickInteriorWallsFromThe2DView();
            DefaultJobElement.DoubleClickOnThePlaceInteriorWallOnThe2DView("INT-1");

            string sideAElementAfterChanges = DefaultJobElement.GetTheSideAValue();
            string sideBElementAfterChanges = DefaultJobElement.GetTheSideBValue();

            if (sideAElement == sideAElementAfterChanges && sideBElement == sideBElementAfterChanges)
            {
                Console.WriteLine("Verify that Side A and Side B elements are not changed after saving data in the 2D view.");
                ExtentTestManager.TestSteps("Verify that Side A and Side B elements are not changed after saving data in the 2D view.");
            }
            else
            {
                Console.WriteLine("Verify that Side A and Side B elements are changed after saving data in the 2D view.");
                ExtentTestManager.TestSteps("Verify that Side A and Side B elements are changed after saving data in the 2D view.");
                Assert.Fail("Verify that Side A and Side B elements are changed after saving data in the 2D view.");
            }
        }
    }
}
#endregion