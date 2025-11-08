using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._93
{
    public class BundleAndOption : BaseClass
    {
        private readonly List<string> caseOnePrices = new();
        private readonly List<string> caseTwoPrices = new();
        private readonly List<string> caseThreePrices = new();
        private readonly List<string> caseFourPricesWithUsage = new();
        private readonly List<string> caseFivePricesWithoutUsage = new();
        private readonly List<string> caseSixPricesSameUsage = new();

        [Test, Order(1)]
        public void PackagesCalculation()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("2 packages that had the same first 20 or so characters pricing mix up");
            HomePage.NavigateToPackagePagesForPostFrame();
            CheckAndDeleteOldData();

            // Create new packages.
            CreateNewPackages();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickPackages();
            DefaultJobElement.ClickJobReview();

            CheckBundleAndOptionValues("Bundle");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickAccessoriesOfJobReview();
            CheckMaterialShownInTheAccessories();
            DefaultJobElement.ClickSummaryOfJobReview();

            // Get the bundle data from the summary.
            string getTheBundleDataFromSummary = GetTheSummaryData();

            DefaultJobElement.ClickCanvas3DViewButton();
            ClickJobTabAndEnterJobName();
            SaveJobAndNavigateToHomePage();
            NavigateToJobPageAndOpenNewlyCreatedJob();
            DefaultJobElement.ClickPackages();
            DefaultJobElement.ClickJobReview();

            // Fetch the data from the summary and compare it with the previously saved data.
            string fetchDataFromSummary = GetTheSummaryData();
            Assert.That(getTheBundleDataFromSummary, Is.EqualTo(fetchDataFromSummary), "After opening the saved job, the summary data does not match the old data.");

            // Check the option values in the summary.
            CheckBundleAndOptionValues("Option");

            // Fetch the summary data for the option.
            string fetchSummaryForOption = GetTheSummaryData();
            SaveJobAndNavigateToHomePage();
            NavigateToJobPageAndOpenNewlyCreatedJob();
            DefaultJobElement.ClickJobReview();

            // Get the default data from the summary and compare it with the option summary data.
            string defaultData = GetTheSummaryData();
            Assert.That(fetchSummaryForOption, Is.EqualTo(defaultData), "After opening the saved job, the summary data does not match the old data.");
        }

        [Test, Order(2)]
        public void DeleteTheNewlyCreatePackage()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete packages");
            HomePage.NavigateToPackagePagesForPostFrame();
            DeleteDataFromPackagesTable();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("Packages");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of 2 packages that had the same first 20 or so characters pricing mix up");
        }

        #region Private Method
        // This method saves the current job and navigates back to the home page.
        private static void SaveJobAndNavigateToHomePage()
        {
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickHomeButton();
        }

        // This method navigates to the job page, opens the newly created job, and click on the sync button.
        private static void NavigateToJobPageAndOpenNewlyCreatedJob()
        {
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Packages");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        // This method clicks on the job tab and enters the job name "Packages".
        private static void ClickJobTabAndEnterJobName()
        {
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("Packages");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        // This method verifies whether the user-set packages, bundles, or options are correctly shown in the summary.
        private void CheckBundleAndOptionValues(string changesStatus)
        {
            VerifyPackageAndBundle(changesStatus, "Interior Concrete", caseOnePrices[0], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "Interior Concrete Insulation", caseOnePrices[1], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "Exterior Concrete", caseTwoPrices[0], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "Exterior Concrete Insulation", caseTwoPrices[1], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "Output Exterior Concrete", caseThreePrices[0], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "Output Exterior Concrete Insulation", caseThreePrices[1], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "GroupWithUsages--TestGroup1", "GroupWithUsages\r\nTestGroup1\r\nTestGroup2", caseFourPricesWithUsage[0], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "GroupWithoutUsages--TestGroup3", "GroupWithoutUsages\r\nTestGroup3\r\nTestGroup4", caseFivePricesWithoutUsage[0], $"Make {changesStatus}");
            VerifyPackageAndBundle(changesStatus, "GroupSameUsages--TestGroup5", "GroupSameUsages\r\nTestGroup5\r\nTestGroup6", caseSixPricesSameUsage[0], $"Make {changesStatus}");
        }

        private static void CheckAndDeleteOldData()
        {
            bool anyPackageDeleted = false;
            string[] packageData = new string[12] { "Interior Concrete", "Interior Concrete Insulation", "Exterior Concrete", "Exterior Concrete Insulation", "Output Exterior Concrete", "Output Exterior Concrete Insulation", "GroupWithUsages (TestGroup1)", "GroupWithUsages (TestGroup2)", "GroupWithoutUsages (TestGroup3)", "GroupWithoutUsages (TestGroup4)", "GroupSameUsages (TestGroup5)", "GroupSameUsages (TestGroup6)" };

            for (int index = 0; index < packageData.Length; index++)
            {
                if (PackageElement.DeleteDataFromPackageTable(packageData[index]))
                {
                    anyPackageDeleted = true;
                }
            }

            if (anyPackageDeleted)
            {
                PackageElement.ClickMainSaveButton();
                HomePage.NavigateToPackagePagesForPostFrame();
            }
        }

        private static void DeleteDataFromPackagesTable()
        {
            bool anyPackageDeleted = false;
            string[] packageData = new string[12] { "Interior Concrete", "Interior Concrete Insulation", "Exterior Concrete", "Exterior Concrete Insulation", "Output Exterior Concrete", "Output Exterior Concrete Insulation", "GroupWithUsages (TestGroup1)", "GroupWithUsages (TestGroup2)", "GroupWithoutUsages (TestGroup3)", "GroupWithoutUsages (TestGroup4)", "GroupSameUsages (TestGroup5)", "GroupSameUsages (TestGroup6)" };

            for (int index = 0; index < packageData.Length; index++)
            {
                if (PackageElement.DeleteDataFromPackageTable(packageData[index]))
                {
                    anyPackageDeleted = true;
                }
            }

            if (anyPackageDeleted)
            {
                PackageElement.ClickMainSaveButton();
            }
        }

        // This method retrieves the summary data from the Job review.
        private string GetTheSummaryData()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_SummaryGrid_records']"))).Text;
        }

        // This method execute the methods of create new package.
        private void CreateNewPackages()
        {
            ExecuteCase(ProcessCaseOne);
            ExecuteCase(ProcessCaseTwo);
            ExecuteCase(ProcessCaseThree);
            ExecuteCase(ProcessCaseFour);
            ExecuteCase(ProcessCaseFive);
            ExecuteCase(ProcessCaseSix);
            PackageElement.ClickMainSaveButton();
        }

        // This method executes a given case method.
        private void ExecuteCase(Action processCaseMethod)
        {
            processCaseMethod.Invoke();
        }

        // This method verifies the package and bundle price in the job review, checking against the expected price.
        private void VerifyPackageAndBundle(string actionType, string packageName, string expectedPrice, string bundleAndOption)
        {
            DefaultJobElement.CheckBundleCheckbox(packageName);
            DefaultJobElement.SelectBundleAndOption(bundleAndOption);
            string bundleAndOptionPrice = VerifyBundleAndOptionInTheJobReview($"{actionType} - {packageName}");
            Assert.True(bundleAndOptionPrice.Equals(expectedPrice));
        }

        // This overloaded method verifies the package and bundle price in the job review, 
        // using a different checkbox name for verification.
        private void VerifyPackageAndBundle(string actionType, string packageName, string checkboxName, string expectedPrice, string bundleAndOption)
        {
            DefaultJobElement.CheckBundleCheckbox(checkboxName);
            DefaultJobElement.SelectBundleAndOption(bundleAndOption);
            string bundleAndOptionPrice = VerifyBundleAndOptionInTheJobReview($"{actionType} - {packageName}");
            Assert.True(bundleAndOptionPrice.Equals(expectedPrice));
        }

        // This method retrieves the price value from the configured field in the job review.
        private string GetPriceValue()
        {
            CommonMethod.Wait(1);
            return Driver.FindElement(By.XPath("//label[text()='Price']//following::input[@name='Price']"))
                         .GetAttribute("value");
        }

        // This method adds data to the catalog frame table, selecting options from dropdowns and catalog tables, and returns the price value.
        private string AddDataToCatalogFrameTable(string catalogItem, string packageType)
        {
            // Select "Option" from the package type dropdown.
            PackageElement.SelectPackageType("Option");

            // If packageType is not null or empty, select it from the default setting dropdown.
            if (!string.IsNullOrEmpty(packageType))
            {
                PackageElement.SelectDefaultSetting(packageType);
            }

            PackageElement.ClickAddCatalogButton();
            PackageElement.SelectOutputCategory("Accessories");
            PackageElement.SelectCatalogCategory("Hardware");
            PackageElement.SelectCatalogItem(catalogItem);
            return GetPriceValue();
        }

        // This method adds a new package, ensuring the "Roof Metal Screws" element is visible before proceeding.
        private void AddNewPackage()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Roof Metal Screws']")));

            // Click the "Add New" button and select the "Blank" option.
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
        }

        // This method processes a case by adding new packages, entering data, and saving the catalog table.
        private void ProcessCase(string[] packageNames, string[] catalogItems, string[] usages, List<string> priceList)
        {
            for (int i = 0; i < packageNames.Length; i++)
            {
                AddNewPackage();
                PackageElement.PackageNameInputField(packageNames[i]);
                CommonMethod.Wait(2);
                string price = AddDataToCatalogFrameTable(catalogItems[i], "Hidden");
                CommonMethod.Wait(2);

                // If usages is not null, enter data in the usage field.
                if (usages != null)
                {
                    PackageElement.UsageInputField(usages[i]);
                }

                priceList.Add(price);
                PackageElement.ClickSaveButton();
                CommonMethod.Wait(2);
            }
        }

        // This method processes a case group by adding new packages to a group, entering data, and saving the catalog table.
        private void ProcessCaseGroup(string groupName, string[] packageNames, string[] catalogItems, string[] usages, List<string> priceList)
        {
            for (int i = 0; i < packageNames.Length; i++)
            {
                AddNewPackage();
                PackageElement.GroupNameInputField(groupName);
                PackageElement.PackageNameInputField(packageNames[i]);
                string price = AddDataToCatalogFrameTable(catalogItems[i], null);
                CommonMethod.Wait(2);

                // If usages is not null, enter data in the usage field.
                if (usages != null)
                {
                    PackageElement.UsageInputField(usages[i]);
                }

                priceList.Add(price);
                PackageElement.ClickSaveButton();
                CommonMethod.Wait(2);
            }
        }

        // This method processes case one by adding new packages and verifying their prices.
        private void ProcessCaseOne()
        {
            string[] packageNames = { "Interior Concrete", "Interior Concrete Insulation" };
            string[] catalogItems = { "FMW10035 ARCTIC RIDGE VENT", "FMW10035 ARCTIC RIDGE VENT" };
            string[] usages = { "RIDGE VENT", "RIDGE VENT" };

            // Process case with provided package names, catalog items, usages, and price list.
            ProcessCase(packageNames, catalogItems, usages, caseOnePrices);
        }

        // This method processes case two by adding new packages and verifying their prices without usages.
        private void ProcessCaseTwo()
        {
            string[] packageNames = { "Exterior Concrete", "Exterior Concrete Insulation" };
            string[] catalogItems = { "FMW10035 BLACK RIDGE VENT", "FMW10035 GALLERY RIDGE VENT" };
            ProcessCase(packageNames, catalogItems, null, caseTwoPrices);
        }

        // This method processes case three by adding new packages and verifying their prices.
        private void ProcessCaseThree()
        {
            string[] packageNames = { "Output Exterior Concrete", "Output Exterior Concrete Insulation" };
            string[] catalogItems = { "FMW10035 BLACK RIDGE VENT", "FMW10035 GALLERY RIDGE VENT" };
            string[] usages = { "BLACK RIDGE VENT", "GALLERY RIDGE VENT" };
            ProcessCase(packageNames, catalogItems, usages, caseThreePrices);
        }

        // This method processes case four by adding new packages to a group and verifying their prices.
        private void ProcessCaseFour()
        {
            string[] packageNames = { "TestGroup1", "TestGroup2" };
            string[] catalogItems = { "FMW10035 BLACK RIDGE VENT", "FMW10035 GALLERY RIDGE VENT" };
            string[] usages = { "BLACK VENT", "GALLERY VENT" };
            ProcessCaseGroup("GroupWithUsages", packageNames, catalogItems, usages, caseFourPricesWithUsage);
        }

        // This method processes case five by adding new packages to a group and verifying their prices without usages.
        private void ProcessCaseFive()
        {
            string[] packageNames = { "TestGroup3", "TestGroup4" };
            string[] catalogItems = { "FMW10035 BLACK RIDGE VENT", "FMW10035 GALLERY RIDGE VENT" };
            ProcessCaseGroup("GroupWithoutUsages", packageNames, catalogItems, null, caseFivePricesWithoutUsage);
        }

        // This method processes case six by adding new packages to a group and verifying their prices.
        private void ProcessCaseSix()
        {
            string[] packageNames = { "TestGroup5", "TestGroup6" };
            string[] catalogItems = { "FMW10035 GALLERY RIDGE VENT", "FMW10035 GALLERY RIDGE VENT" };
            string[] usages = { "GALLERY VENT", "GALLERY VENT" };
            ProcessCaseGroup("GroupSameUsages", packageNames, catalogItems, usages, caseSixPricesSameUsage);
        }

        // This method verifies the bundle and option in the job review and returns the price value.
        private string VerifyBundleAndOptionInTheJobReview(string packageName)
        {
            string elementXPath = "(//tr[contains(@id,'grid_SummaryGrid_rec_')]//div[text()='{0}']//following::td[@col='3']/div)[1]";
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, packageName)))).Text;
        }

        // This method checks if the specified materials are shown in the accessories section.
        private void CheckMaterialShownInTheAccessories()
        {
            // List of expected material names and usages.
            var materialNameData = new[]
            {
        "Output Exterior Concrete-BLACK RIDGE VENT", "Exterior Concrete", "Exterior Concrete Insulation",
        "Output Exterior Concrete Insulation-GALLERY RIDGE VENT", "Interior Concrete-RIDGE VENT",
        "Interior Concrete Insulation-RIDGE VENT", "Interior Concrete Insulation-RIDGE VENT",
        "GroupWithUsages--TestGroup1-BLACK VENT", "GroupWithoutUsages--TestGroup3"
    };

            var usageName = new[]
            {
        "-BLACK RIDGE VENT", "Exterior Concrete", "Exterior Concrete Insulation", "-GALLERY RIDGE VENT",
        "-RIDGE VENT", "-RIDGE VENT", "--TestGroup1-BLACK VENT", "GroupWithoutUsages--TestGroup3",
    };

            // Find all rows in the materials grid.
            var rows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_MaterialsGrid_rec_')]//td[@col='1']//div"));

            foreach (var rowElement in rows)
            {
                string elementText = rowElement.Text;

                if (string.IsNullOrEmpty(elementText) || !usageName.Any(usage => elementText.Contains(usage)))
                    continue;
                OpenMaterialPopup(rowElement);
                bool materialFound = ValidateMaterialPopup(materialNameData);
                Assert.That(materialFound, Is.True, $"{elementText} material is not shown in the accessories table");
            }
        }

        private void OpenMaterialPopup(IWebElement rowElement)
        {
            CommonMethod.GetActions()
                .DoubleClick(rowElement)
                .Pause(TimeSpan.FromSeconds(1))
                .Perform();
        }

        private bool ValidateMaterialPopup(string[] materialNameData)
        {
            var popupElements = Driver.FindElements(By.XPath("//div[@id='w2ui-overlay']//tr//td"));
            for (int i = 0; i < popupElements.Count; i++)
            {
                string popupText = popupElements[0].Text;
                if (string.IsNullOrEmpty(popupText))
                    continue;

                if (materialNameData.Length > i && popupText.Contains(materialNameData[i]))
                {
                    GetWebDriverWait()
                        .Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[text()='Delete']")))
                        .Click();
                    return true;
                }
            }
            return false;
        }

    }
}
#endregion