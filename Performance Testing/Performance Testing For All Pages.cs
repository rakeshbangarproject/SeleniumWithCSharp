using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Diagnostics;
using System.IO;

namespace SmartBuildAutomation.Performance_Testing
{
    [TestFixture, Category("Pages")]
    public class PerformanceTestOnThePages : BaseClass
    {
        public static string path = FolderPath.PerformanceReport();
        static readonly string PathOfPage = "(//a[normalize-space()='{0}'])[{1}]";

        [Test]
        public void ApplicationPages()
        {
            LoginApplicationAndChangesDistributor("Check performance of pages");
            AdminListElements();
            SettingsListElements();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Check performance of pages");
        }

        #region Private Method
        private void SettingsListElements()
        {
            CustomizePage();
            EModelerPage();
            RTONationalConfigPage();
            SetupWizardPage();
            OutputCategoriesPage();
            BuildersPage();
            UsersPage();
            ColorsPage();
            MaterialsPage();
            TextureLibrarySettingListPage();
            DoorsAndWindowsPage();
            SpanTablesPage();
            ProductSystemsPage();
            TrussesPage();
            TaaSConfigPage();
            PricingPage();
            SpecialPricingPage();
            PaymentSchedulePage();
            PackagesPage();
            StartingModelsPage();
            OutputsPage();
            BillingSettingListPage();
            FramingRulesPage();
        }

        private void AdminListElements()
        {
            Console.WriteLine("Admin List Elements");
            UsersPageAdmin();
            DistributorPage();
            ReportsPage();
            DistributorOutputsPage();
            TelemetryPage();
            PerformancePage();
            BillingPage();
            CheckDataPage();
            TaaSStatusPage();
            CannedPackagesPage();
            OBJLibraryPage();
            TextureLibraryPage();
            PushDisclaimerPage();
            Console.WriteLine("\nSettings List Elements");
        }

        #region Admin List Elements
        private void UsersPageAdmin()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Users", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Users Page loaded in:-");
        }

        private void DistributorPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Distributors", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Distributors Page loaded in:-");
        }

        private void DistributorOutputsPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Distributor Outputs", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid_distributorSelectionGrid_selected_records']", stopwatch, $"Distributor Outputs Page loaded in:-");
        }

        private void ReportsPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Reports", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//select[@id='joblist-status']", stopwatch, $"Reports Page loaded in:-");
        }

        private void TelemetryPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Telemetry", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Telemetry Page loaded in:-");
        }

        private void PerformancePage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Performance", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='getpaneldatatimes']", stopwatch, $"Performance Page loaded in:-");
        }

        private void BillingPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Billing", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//select[@id='billing-type']", stopwatch, $"Billing Page loaded in:-");
        }

        private void CheckDataPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Check Data", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            WaitForElement("//div[@id='grid_checkGrid_records']", stopwatch, $"Check Data Page loaded in:-");
        }

        private void TaaSStatusPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("TaaS Status", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"TaaS Status Page loaded in:-");
        }

        private void CannedPackagesPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Canned Packages", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid_packageList_records']", stopwatch, $"Canned Packages Page loaded in:-");
        }

        private void OBJLibraryPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("OBJ Library", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"OBJ Library Page loaded in:-");
        }

        private void TextureLibraryPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Texture Library", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Texture Library Page loaded in:-");
        }

        private void PushDisclaimerPage()
        {
            ClickMenuOption("Admin", 1);
            ClickMenuOption("Push Disclaimer", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//select[@id='DistributorClass']", stopwatch, $"Push Disclaimer Page loaded in:-");
        }
        #endregion

        #region Settings List Elements
        private void CustomizePage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Customize", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//label[text()='Home Link']", stopwatch, $"Customize Page loaded in:-");
        }

        private void EModelerPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Emodeler", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//td[text()='Start From Scratch']", stopwatch, $"EModeler Page loaded in:-");
        }

        private void RTONationalConfigPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("RTO National Config", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//button[text()='Verify']", stopwatch, $"RTO National Config Page loaded in:-");
        }

        private void SetupWizardPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Setup Wizard", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='description']", stopwatch, $"Setup Wizard Page loaded in:-");
        }

        private void OutputCategoriesPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Output Categories", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[text()='Framing']", stopwatch, $"Output Categories Page loaded in:-");
        }

        private void BuildersPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Builders", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_columns']", stopwatch, $"Builders Page loaded in:-");
        }

        private void UsersPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Users", 2);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_columns']", stopwatch, $"Users Page loaded in:-");
        }

        private void ColorsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Colors", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//th[normalize-space()='Color Name']", stopwatch, $"Colors Page loaded in:-");
        }

        private void MaterialsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Materials", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Materials Page loaded in:-");
        }

        private void TextureLibrarySettingListPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Texture Library", 2);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Texture Library Page loaded in:-");
        }

        private void DoorsAndWindowsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Doors and Windows", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Doors and Windows Page loaded in:-");
        }

        private void SpanTablesPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Span Tables", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Span Tables Page loaded in:-");
        }

        private void ProductSystemsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Product Systems", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Product Systems Page loaded in:-");
        }

        private void TrussesPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Trusses", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Trusses Page loaded in:-");
        }

        private void TaaSConfigPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("TaaS Config", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//label[text()='Truss Design Aging']", stopwatch, $"TaaS Config Page loaded in:-");
        }

        private void PricingPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Pricing", 1);
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Pricing Page loaded in:-");
        }

        private void SpecialPricingPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Special Pricing", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid_grid_records']", stopwatch, $"Special Pricing Page loaded in:-");
        }

        private void PaymentSchedulePage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Payment Schedule", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[@id='grid']", stopwatch, $"Payment Schedule Page loaded in:-");
        }

        private void FramingRulesPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Framing Rules", 1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td[normalize-space()='AUTOTEST_PHTEST']//following::a[text()='Edit'])[1]"))).Click();
            var stopwatch = Stopwatch.StartNew();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("(//div[@id='grid_formGrid_records'])[1]")));
            WaitForElement("(//div[text()='-- Building Size --'])[1]", stopwatch, $"Framing Rules Page loaded in:-");
        }

        private void PackagesPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Packages", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[text()='Roof Metal Screws']", stopwatch, $"Packages Page loaded in:-");
        }

        private void StartingModelsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Starting Models", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[text()='Smoke20x20x10']", stopwatch, $"Starting Models Page loaded in:-");
        }

        private void OutputsPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Outputs", 1);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//div[text()='Job Bid']", stopwatch, $"Outputs Page loaded in:-");
        }

        private void BillingSettingListPage()
        {
            ClickMenuOption("Settings", 1);
            ClickMenuOption("Billing", 2);
            var stopwatch = Stopwatch.StartNew();
            WaitForElement("//input[@id='billing-type']", stopwatch, $"Billing Page loaded in:-");
        }
        #endregion

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

        private void ClickMenuOption(string menuName, int position)
        {
            string menuXPath = string.Format(PathOfPage, menuName, position);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(menuXPath))).Click();
            ExtentTestManager.TestSteps($"Click on the {menuName}");
        }

        private void WaitForElement(string xpath, Stopwatch stopwatch, string message)
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath(xpath)));

                stopwatch.Stop();
                var totalTime = stopwatch.Elapsed;

                File.AppendAllText(@$"{path}/Pages.txt", $"{message} {totalTime}{Environment.NewLine}");
                ExtentTestManager.TestSteps($"{message} {totalTime}{Environment.NewLine}");
                Console.WriteLine($"{message} {totalTime}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:{message} " + ex.Message);
                ExtentTestManager.TestSteps($"ERROR:{message} " + ex.Message);
            }
        }
    }
}
#endregion