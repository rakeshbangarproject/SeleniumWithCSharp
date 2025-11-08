using DocumentFormat.OpenXml.Wordprocessing;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._90
{
    [TestFixture, Category("Sprint_1._90")]
    public class CustomOpening : BaseClass
    {
        [Test]
        public void HotPatch()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH: Custom openings show NaN if the Opening location is switched");
            HomePage.ClicksStartFromScratch();
            Logic1();
            Logic2();
            Logic3();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH: Custom openings show NaN if the Opening location is switched");
        }

        #region Private Method
        private void Logic1()
        {
            Console.WriteLine("Logic 1: Change location type for custom opening");
            DefaultJobElement.OpeningDoorsSelection("Overhead");
            CommonMethod.GetActions().Click(DefaultJobElement.SelectStyleFromDoors("Custom")).Perform();
            ExtentTestManager.TestSteps($"Click on the custom style");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.OpenPlaceOpening(100, 150);
            DefaultJobElement.SelectLocationOpening("From Right");
            VerifyTheDistanceIsNotNaN();
            DefaultJobElement.EnterDistance("20");
            string GetTheDistanceAfterChange = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            DefaultJobElement.ClickUpdateButtonFrom3DView();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontRight();
            DefaultJobElement.OpenPlaceOpening(100, 200);
            VerifyTheDistanceIsNotChange(GetTheDistanceAfterChange);
            VerifyThatLocationIsNotChanged("From Right");
            Driver.Navigate().Refresh();
            Driver.SwitchTo().Alert().Accept();
            CommonMethod.PageLoader();
        }

        private void Logic2()
        {
            Console.WriteLine("Logic 2: Changing an opening to Custom");
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ChangeViewFrontLeft();
            OpenThePlaceDoor(100, 150);
            DefaultJobElement.ClickSelectAStyleTabAndSelectSubElement("Custom");
            string distance = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            string location = DefaultJobElement.GetLocationOpeningOfOpeningValue();
            DefaultJobElement.ClickUpdateButtonFrom3DView();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontLeft();
            OpenThePlaceDoor(100, 150);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='openingSettingsForm']//button[@class='dropdown-button sku-button'][normalize-space()='Custom']")));
            ExtentTestManager.TestSteps($" Verify that the opening is change to Custom");
            Console.WriteLine("Verify that the opening is change to Custom\n");
            VerifyTheDistanceIsNotChange(distance);
            VerifyThatLocationIsNotChanged(location);
            Driver.Navigate().Refresh();
            Driver.SwitchTo().Alert().Accept();
            CommonMethod.PageLoader();
        }

        private void Logic3()
        {
            Console.WriteLine("Logic 3: Change Opening style AND location type");
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ChangeViewFrontLeft();
            OpenThePlaceDoor(100, 150);
            VerifyTheDistanceIsNotNaN();
            DefaultJobElement.ClickSelectAStyleTabAndSelectSubElement("Custom");
            DefaultJobElement.SelectLocationOpening("From Left");
            string distance = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();
            DefaultJobElement.ClickUpdateButtonFrom3DView();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewFrontLeft();
            OpenThePlaceDoor(100, 150);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='openingSettingsForm']//button[@class='dropdown-button sku-button'][normalize-space()='Custom']")));
            ExtentTestManager.TestSteps($" Verify that the opening is change to Custom");
            Console.WriteLine("Verify that the opening is change to Custom");
            VerifyTheDistanceIsNotChange(distance);
            VerifyThatLocationIsNotChanged("From Left");
        }

        private static void VerifyTheDistanceIsNotNaN()
        {
            string distance = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();

            if (distance == "NaN")
            {
                ExtentTestManager.TestSteps($"Verify that the 'Distance' is shown as 'NaN' value");
                Console.WriteLine("Verify that the 'Distance' is shown as 'NaN' value");
                Assert.That(distance, Is.EqualTo("NaN"));
            }

            Console.WriteLine("Verify that the 'Distance' is not shown as 'NaN' value");
        }

        private static void VerifyTheDistanceIsNotChange(string elementValue)
        {
            string distance = DefaultJobElement.GetDistanceInputFieldOfOpeningValue();

            if (distance == elementValue)
            {
                ExtentTestManager.TestSteps($"Verify that the 'Distance' is not change {distance} = {elementValue}");
                Console.WriteLine($"Verify that the 'Distance' is not change {distance} = {elementValue}");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verify that the 'Distance' is change {distance} = {elementValue}");
                Console.WriteLine($"Verify that the 'Distance' is change {distance} = {elementValue}");
                Assert.That(distance, Is.EqualTo(elementValue));
            }
        }

        private static void VerifyThatLocationIsNotChanged(string elementValue)
        {
            string location = DefaultJobElement.GetLocationOpeningOfOpeningValue();

            if (location == elementValue)
            {
                ExtentTestManager.TestSteps($"Verify that the 'Location' is not change {location} = {elementValue}");
                Console.WriteLine($"Verify that the 'Location' is not change {location} = {elementValue}\n");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verify that the 'Location' is change {location} = {elementValue}");
                Console.WriteLine($"Verify that the 'Location' is change {location} = {elementValue} \n");
                Assert.That(location, Is.EqualTo(elementValue));
            }
        }

        private void OpenThePlaceDoor(int x, int y)
        {
            IWebElement canvas2 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(canvas2).MoveByOffset(x, y).Click().Pause(TimeSpan.FromSeconds(0.5)).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
        }
    }
}
#endregion