using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class WrappedPorch : BaseClass
    {
        [Test]
        public void AttachedDoor()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Door in wrapped porches");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Wrapped Porches");
            CommonMethod.PageLoader();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(150, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();

            try
            {
                DefaultJobElement.ChangeViewFrontLeft();
                DefaultJobElement.OpenPlaceOpening(150, 150);
                Driver.FindElement(By.XPath(Locator.DefaultJob.distanceInputFieldOfOpening));
                ExtentTestManager.TestSteps("Click on the 3D edit");
            }
            catch (Exception)
            {
                Assert.Fail("Edit walkdoor field pop is not visible");
            }
            ExtentTestManager.TestSteps($"Edit the opening");

            string distanceOf3DView = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            ExtentTestManager.TestSteps($"get the value of distance = {distanceOf3DView}");
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.DoubleClickOnThePlaceDoorOnThe2DView("3x7 LIS Solid Steel Door");
            ExtentTestManager.TestSteps("Double click on the Door name of 2D view Page");

            string distanceOf2DView = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            Assert.That(distanceOf3DView, Is.EqualTo(distanceOf2DView), "The 3D view and 2D view page of doors distance is not same");
            Console.WriteLine($"The 3D view and 2D view page of doors distance are same:- '{distanceOf2DView}' == '{distanceOf3DView}'");
            ExtentTestManager.TestSteps($"The 3D view and 2D view page of doors distance are same:- '{distanceOf2DView}' == '{distanceOf3DView}'");
            DefaultJobElement.EnterDistance("20");
            DefaultJobElement.ClickUpdateButtonFrom2DView();
            DefaultJobElement.SaveButtonOf2DView();

            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.OpenPlaceOpening(130, 150);
            string distanceOf3DViewAfterChanges = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            Assert.That(distanceOf3DViewAfterChanges, Is.EqualTo("20'"), "The 3D view and 2D view page of doors distance is not same");
            Console.WriteLine($"After updating the distance in the 2D view, the same distance is displayed in the 3D view.'{distanceOf2DView}' == '{distanceOf3DView}'");
            ExtentTestManager.TestSteps($"After updating the distance in the 2D view, the same distance is displayed in the 3D view.'{distanceOf2DView}' == '{distanceOf3DView}'");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report Of Door in wrapped porches Script");
        }
    }
}
