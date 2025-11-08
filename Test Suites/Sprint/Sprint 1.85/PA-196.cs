using AventStack.ExtentReports.Model;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._85
{
    [TestFixture, Category("Sprint_1_.85")]
    public class CategoryField : BaseClass
    {
        #region XPath      
        public string mainElementValue;
        public string mainJobReviewElement;
        public string afterChangesCategory;
        #endregion

        [Test, Order(1)]
        public void OpeningPackages()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add Category field input");
            CreateNewPackages();
            string updatedValue = PlaceWalkDoorForTheMainPackage();
            string updatedValue1 = PlaceWalkDoorForTheOverheadDoorPackage(updatedValue);
            string updatedValue2 = PlaceWalkDoorForTheSliderPackage(updatedValue1);
            PlaceWalkDoorForTheWindowsPackageAndSaveTheJob(updatedValue2);
            NavigateToPackagePageAndChangeCategoryName();
            OpenCategoryJobAndVerifyDoorCategoryAreChanges();
        }

        [Test, Order(2)]
        public void DeletePackagesFromTable()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Data");
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.DeleteDataFromPackageTable("MainPackage (TestMainPackageData)");
            DeletePackage("WalkDoor", "WalkDoorPackage (TestWalkDoorPackageData)");
            DeletePackage("Overhead", "OverheadPackage (TestOverheadPackageData)");
            DeletePackage("Slider", "SliderPackage (TestSliderPackageData)");
            DeletePackage("Window", "WindowPackage (TestWindowPackageData)");
            PackageElement.ClickMainSaveButton();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Add Category Field");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Category field input Script");
        }

        #region Private Method
        private void OpenCategoryJobAndVerifyDoorCategoryAreChanges()
        {
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Add Category Field");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            ReviewJob("Labor", "--TestMainPackageData-MainPackageUsageMaterial");
            Console.WriteLine("Verify that the new category is applied to Main Package elements");
            ExtentTestManager.TestSteps($"Verify that the new category is applied to Main Package elements");
            ReviewJob("Sheathing", "--TestWalkDoorPackageData-WalkDoorPackageUsageMaterial");
            Console.WriteLine("Verify that the new category is applied to WalkDoor Package elements");
            ExtentTestManager.TestSteps($"Verify that the new category is applied to WalkDoor Package elements");
            ReviewJob("Accessories", "--TestOverheadPackageData-OverheadPackageUsageMaterial");
            Console.WriteLine("Verify that the new category is applied to OverHead Package elements");
            ExtentTestManager.TestSteps($"Verify that the new category is applied to OverHead Package elements");

            ReviewJob("Labor", "--TestSliderPackageData-SliderPackageUsageMaterial");
            Console.WriteLine("Verify that the new category is applied to Slider Package elements");
            ExtentTestManager.TestSteps($"Verify that the new category is applied to Slider Package elements");

            ReviewJob("Accessories", "--TestWindowPackageData-WindowPackageUsageMaterial");
            Console.WriteLine("Verify that the new category is applied to Window Package elements");
            ExtentTestManager.TestSteps($"Verify that the new category is applied to Window Package elements");

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClickHomeButton();
        }

        private void NavigateToPackagePageAndChangeCategoryName()
        {
            HomePage.NavigateToPackagePagesForPostFrame();
            EditCategoryName("MainPackage (TestMainPackageData)", "Labor");
            PackageElement.ChangePackages("WalkDoor");
            EditCategoryName("WalkDoorPackage (TestWalkDoorPackageData)", "Sheathing");
            PackageElement.ChangePackages("Overhead");
            EditCategoryName("OverheadPackage (TestOverheadPackageData)", "Accessories");
            PackageElement.ChangePackages("Slider");
            EditCategoryName("SliderPackage (TestSliderPackageData)", "Labor");
            PackageElement.ChangePackages("Window");
            EditCategoryName("WindowPackage (TestWindowPackageData)", "Accessories");
            PackageElement.ClickMainSaveButton();
        }

        private void PlaceWalkDoorForTheWindowsPackageAndSaveTheJob(string updatedValue2)
        {
            ChangeToFrontRightView();
            SelectAndPlaceDoor("Windows", "Slider", "30x30 Slider", 100, 120, "WindowPackage\r\nTestWindowPackageData", "Window");
            SyncAndVerifyDoorPlacement(updatedValue2);

            DefaultJobElement.ClickJobReview();
            ReviewJob("Trim", "--TestWindowPackageData-WindowPackageUsageMaterial");
            Console.WriteLine($"Verify that the Window Package is applied to the canvas building");
            ExtentTestManager.TestSteps($"Verify that the Window Package is applied to the canvas building");
            DefaultJobElement.ClickCanvas3DViewButton();
            CompleteAndSaveJob();
        }

        private string PlaceWalkDoorForTheSliderPackage(string updatedValue1)
        {
            SelectAndPlaceSliderDoor("SliderPackage\r\nTestSliderPackageData", 200, 0);
            string updatedValue2 = SyncAndVerifyDoorPlacement(updatedValue1);

            DefaultJobElement.ClickJobReview();
            ReviewJob("Freight", "--TestSliderPackageData-SliderPackageUsageMaterial");
            Console.WriteLine($"Verify that the Slider Package is applied to the canvas building");
            ExtentTestManager.TestSteps($"Verify that the Slider Package is applied to the canvas building");
            DefaultJobElement.ClickCanvas3DViewButton();
            return updatedValue2;
        }

        private string PlaceWalkDoorForTheOverheadDoorPackage(string updatedValue)
        {
            ChangeToBackRightView();
            SelectAndPlaceDoor("Overhead", "Raised Panel", "10x10 OHD-no windows", 100, 120, "OverheadPackage\r\nTestOverheadPackageData", "OverHead");
            string updatedValue1 = SyncAndVerifyDoorPlacement(updatedValue);

            DefaultJobElement.ClickJobReview();
            ReviewJob("Labor", "--TestOverheadPackageData-OverheadPackageUsageMaterial");
            Console.WriteLine($"Verify that the OverHead Package is applied to the canvas building");
            ExtentTestManager.TestSteps($"Verify that the OverHead Package is applied to the canvas building");
            DefaultJobElement.ClickCanvas3DViewButton();
            return updatedValue1;
        }

        private string PlaceWalkDoorForTheMainPackage()
        {
            HomePage.ClicksStartFromScratch();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 100);
            DefaultJobElement.ClickCrossIcon();
            PackageButton();
            string currentValue = SyncAndVerifyDoorPlacement(initialValue);

            DefaultJobElement.ClickJobReview();
            ReviewJob("Accessories", "--TestMainPackageData-MainPackageUsageMaterial");
            Console.WriteLine("Verify that the Main Package is applied to the canvas building");
            ExtentTestManager.TestSteps("Verify that the Main Package is applied to the canvas building");
            DefaultJobElement.ClickCanvas3DViewButton();

            SelectAndPlaceDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door", 30, 150, "WalkDoorPackage\r\nTestWalkDoorPackageData", "WalkDoor");
            string updatedValue = SyncAndVerifyDoorPlacement(currentValue);

            DefaultJobElement.ClickJobReview();
            ReviewJob("Labor", "--TestWalkDoorPackageData-WalkDoorPackageUsageMaterial");
            Console.WriteLine("Verify that the Main Package is applied to the canvas building");
            ExtentTestManager.TestSteps("Verify that the Main Package is applied to the canvas building");
            DefaultJobElement.ClickCanvas3DViewButton();
            return updatedValue;
        }

        private void ChangeToFrontRightView() => DefaultJobElement.ChangeViewFrontRight();

        private void ChangeToBackRightView() => DefaultJobElement.ChangeViewBackRight();

        private void SelectAndPlaceDoor(string doorType, string doorStyle, string doorSize, int x, int y, string packageData, string doorElement)
        {
            DefaultJobElement.OpeningDoorsSelection(doorType);
            SelectDoorForOtherElement(doorStyle, doorSize, x, y, packageData, doorElement);
            DefaultJobElement.ClickCrossIcon();
        }

        private void SelectAndPlaceSliderDoor(string packageData, int x, int y)
        {
            DefaultJobElement.OpeningDoorsSelection("Slider");
            CommonMethod.Wait(2);
            SliderDoorPlace(packageData, x, y);
            DefaultJobElement.ClickCrossIcon();
        }

        private string SyncAndVerifyDoorPlacement(string initialValue)
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            VerifyThatDoorPlaceOnTheCanvasBuilding(initialValue, currentValue);
            return currentValue;
        }

        private void ReviewJob(string reviewType, string materialsData)
        {
            switch (reviewType)
            {
                case "Trim":
                    DefaultJobElement.ClickTrimOfJobReview();
                    break;
                case "Freight":
                    DefaultJobElement.ClickFreightOfJobReview();
                    break;
                case "Labor":
                    DefaultJobElement.ClickLaborOfJobReview();
                    break;
                case "Accessories":
                    DefaultJobElement.ClickAccessoriesOfJobReview();
                    break;
                case "Sheathing":
                    DefaultJobElement.ClickSheathingOfJobReview();
                    break;
            }
            DefaultJobElement.CheckUsageShownInTheJobReview(reviewType, materialsData);
        }

        private void CompleteAndSaveJob()
        {
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Add Category Field");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
        }

        private void CreateNewPackages()
        {
            AddDataInTheMainPackages();
            AddDataToTheWalkDoorPackages();
            AddDataToTheOverheadDoorPackages();
            AddDataToTheSliderPackages();
            AddDataToTheWindowPackages();
            PackageElement.ClickMainSaveButton();
        }

        private void AddDataToPackage(string packageType, string groupName, string packageName, string category, string catalog, string usageName, string tableName)
        {
            PackageElement.ChangePackages(packageType);
            PackageElement.DeleteDataFromPackageTable($"{packageType}Package ({packageName})");
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.GroupNameInputField(groupName);
            PackageElement.PackageNameInputField(packageName);
            VerifyCategoryDropdown(category, catalog, usageName, tableName);
        }

        private void AddDataToTheWindowPackages()
        {
            AddDataToPackage("Window", "WindowPackage", "TestWindowPackageData", "Trim", "Window Hardware", "WindowPackageUsageMaterial", "the Window Packages");
        }

        private void AddDataToTheSliderPackages()
        {
            AddDataToPackage("Slider", "SliderPackage", "TestSliderPackageData", "Freight", "Slider Hardware", "SliderPackageUsageMaterial", "the Slider Packages");
        }

        private void AddDataToTheOverheadDoorPackages()
        {
            AddDataToPackage("Overhead", "OverheadPackage", "TestOverheadPackageData", "Labor", "Overhead Hardware", "OverheadPackageUsageMaterial", "the Overhead Packages");
        }

        private void AddDataToTheWalkDoorPackages()
        {
            AddDataToPackage("WalkDoor", "WalkDoorPackage", "TestWalkDoorPackageData", "Labor", "WalkDoor Hardware", "WalkDoorPackageUsageMaterial", "the WalkDoor Packages");
        }

        private void AddDataInTheMainPackages()
        {
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.DeleteDataFromPackageTable("MainPackage (TestMainPackageData)");
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.GroupNameInputField("MainPackage");
            PackageElement.PackageNameInputField("TestMainPackageData");
            VerifyCategoryDropdown("Accessories", "WalkDoor Hardware", "MainPackageUsageMaterial", "the Main Packages");
        }

        public void VerifyCategoryDropdown(string categoryElement, string catalogElement, string usagesName, string tableName)
        {
            PackageElement.ClickAddCatalogButton();
            CommonMethod.Wait(1);
            bool categoryDropdownDisplayed = PackageElement.OutputCategory().Displayed;

            if (categoryDropdownDisplayed)
            {
                Console.WriteLine($"Category Dropdown is shown to {tableName}");
                ExtentTestManager.TestSteps($"Category Dropdown is shown to {tableName}");
            }
            else
            {
                Assert.Fail($"Category Dropdown is not shown to the Edit Added Material - Catalog table {tableName}");
            }

            PackageElement.SelectOutputCategory(categoryElement);
            string main = PackageElement.GetTheOutputCategoryValue();
            mainElementValue = main;

            PackageElement.SelectCatalogCategory(catalogElement);
            PackageElement.UsageInputField(usagesName);
            PackageElement.ClickSaveButton();
        }

        public void SelectDoorForOtherElement(string doorCategory, string tableDoor, int x_axis, int y_axis, string checkboxName, string SelectDoor)
        {
            DefaultJobElement.SelectStyleAndOpeningElement(doorCategory, tableDoor);
            CommonMethod.Wait(2);
            DefaultJobElement.CheckDoorPackageCheckbox(checkboxName);
            CommonMethod.Wait(2);
            DefaultJobElement.PlaceOpening(x_axis, y_axis);
            ExtentTestManager.TestSteps($"Apply the {SelectDoor} on the canvas Building");
        }

        public void SliderDoorPlace(string checkboxName, int x_axis, int y_axis)
        {
            DefaultJobElement.CheckDoorPackageCheckbox(checkboxName);
            DefaultJobElement.PlaceOpening(x_axis, y_axis);
        }

        public void PackageButton()
        {
            DefaultJobElement.ClickPackages();
            DefaultJobElement.CheckAddOnsCheckbox("MainPackage\r\nTestMainPackageData");
            ExtentTestManager.TestSteps("Click on the Main Package Checkbox ");
        }

        public void EditCategoryName(string EditPackage, string ChangeCategory)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.Packages.getTheElementFromPackageTable, EditPackage))));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Perform();
            ExtentTestManager.TestSteps($"Click on the newly added material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.catalogTableFirstRowElement)));
            CommonMethod.GetActions().Click(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the edit button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.Packages.editButton)));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Perform();
            PackageElement.SelectOutputCategory(ChangeCategory);
            PackageElement.ClickSaveButton();
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

        private void DeletePackage(string packageFieldName, string deleteElementNameOfPackage)
        {
            PackageElement.ChangePackages(packageFieldName);
            PackageElement.DeleteDataFromPackageTable(deleteElementNameOfPackage);
        }
    }
}
#endregion