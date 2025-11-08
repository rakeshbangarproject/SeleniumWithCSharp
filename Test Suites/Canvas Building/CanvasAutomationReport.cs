using DocumentFormat.OpenXml.Wordprocessing;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class AddNew : BaseClass
    {
        /// <summary>
        /// 1. We are clicking Start from scratch button and applying the functionalities to the model.
        /// 2. Every time after applying the changes , we are waiting for the elements to appear.
        /// 3. Checking the price before and after applying the changes and appending it to a doc file.
        /// 4. For Edit method we are checking for the saved test and selecting the Edit button for that test from the "recent jobs" table on the home page.
        /// 5. For Delete Method we click on Jobs menu and find our saved job and then delete it.
        /// </summary>

        [Test]
        public void AllChanges()
        {
            WalkDoor();
            OverHeadDoor();
            Sliders();
            Window();
            Porch();
            Awning();
            LeanTo();
            AttachedBuilding();
            CantPorch();
            DividerWall();
            Cupola();
            OpenWall();
            SaveJob();
            EditJob();
            DeleteJob();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of CanvasAutomationReport Script");
        }

        #region Public Method(s)
        /// <summary>
        /// Login to the application and set distributor as AutoTest_PHTest
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");
        }
        private void OverHeadDoor()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 2) ").Info("Add OverHeadDoor");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(100, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Place the OverHead Door on the canvas");

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get Latest Amount");
            ComparePrice(initialValue, currentValue, "OverHead");
            RefreshPage();
        }

        private void Sliders()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 3) ").Info("Add Sliders");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.OpeningDoorsSelection("Slider");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Place the Slider on the canvas");

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get Latest Amount");
            ComparePrice(initialValue, currentValue, "Slider");
            RefreshPage();
        }

        private void Window()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 4) ").Info("Add Window");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.SelectOpeningDoor("Windows", "Slider", "30x30 Slider");
            DefaultJobElement.PlaceOpening(60, 130);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Place the window on the canvas");

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get Latest Amount");
            ComparePrice(initialValue, currentValue, "window");
            RefreshPage();
        }

        private void Porch()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 5) ").Info("Add Porch");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Porch");
            RefreshPage();
        }

        private void Awning()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 6) ").Info("Add Awning");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ClickAwning();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Awning");
            RefreshPage();
        }

        private void LeanTo()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 7) ").Info("Add Lean To");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ClickLeanTo();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Lean-To");
            RefreshPage();
        }

        private void AttachedBuilding()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 2) ").Info("Add Attached Building");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ClickAttachedBuilding();
            DefaultJobElement.EnterLengthInputFieldOption("30");
            DefaultJobElement.EnterWidthInputFieldOption("30");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.PlaceOpening(150, 150);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Attached Building");
            RefreshPage();
        }

        private void CantPorch()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 9) ").Info("Add CantPorch");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ClickCantPorchButton();
            DefaultJobElement.EnterStartInputFieldOption("10");
            DefaultJobElement.PlaceOpening(120, 120);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Cant Porch");
            RefreshPage();
        }

        private void DividerWall()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 10) ").Info("Add Divider Wall");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ClickDividerWall();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Divider Wall");
            RefreshPage();
        }

        private void Cupola()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 11) ").Info("Add Cupola");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ClickCupolas();
            DefaultJobElement.SelectStyleAndOpeningElement("Louvered", "Cup24x24");
            DefaultJobElement.PlaceOpening(10, 10);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Cupola");
            RefreshPage();
        }

        private void OpenWall()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 12) ").Info("Add Open Wall");
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Apply on the canvas");

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get the latest amount");
            ComparePrice(initialValue, currentValue, "Open Wall");
            RefreshPage();
        }

        private void SaveJob()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 13) ").Info("Save job");
            GetWebDriverWait().IgnoreExceptionTypes(typeof(NoSuchElementException));
            CommonMethod.PageLoader();
            CommonMethod.Wait(3);
            ExtentTestManager.TestSteps("Click on Start from Scratch");

            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Place the walkdoor on the canvas");
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("My Auto_Test");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CommonMethod.Wait(3);
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
        }

        private void EditJob()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 14) ").Info("Edit saved job");
            GetWebDriverWait().IgnoreExceptionTypes(typeof(NoSuchElementException));
            HomePage.ClicksJobTab();
            JobPage.OpenJob("My Auto_Test");
            CommonMethod.PageLoader();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.OpenPlaceOpening(100, 200);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomePageURL"));
        }

        private void DeleteJob()
        {
            ExtentTestManager.CreateTest("Canvas Automation (Test Case = 15) ").Info("Delete the job");
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("My Auto_Test");
        }

        private void RefreshPage()
        {
            Driver.Navigate().Refresh();
            CommonMethod.HandleAlert();
        }

        private void WalkDoor()
        {
            LoginApplicationAndChangesDistributor("Canvas Automation (Test Case = 1)");
            HomePage.ClicksStartFromScratch();

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Check the Total Price");
            DefaultJobElement.ChangeViewFrontLeft();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            ExtentTestManager.TestSteps("Get Latest Amount");
            ComparePrice(initialValue, currentValue, "WalkDoors");
            RefreshPage();
        }

        private void ComparePrice(string initialValue, string currentValue, string name)
        {
            if (initialValue.Equals(currentValue))
            {
                Console.WriteLine($"Error: {name} does not added and therefore Price does not Updated");
                ExtentTestManager.TestSteps($"Error: Price does not Updated after {name}");
                Assert.Fail($"Price does not Updated after {name}");
            }
            else
            {
                Console.WriteLine($"Price Updated after {name} added");
                ExtentTestManager.TestSteps($"Price Updated after {name} added");
            }
        }
    }
}
#endregion
