using ClosedXML.Excel;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Sprint_1._87;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildAutomation.Pages1
{
    public class HomePage : BaseClass
    {
        public static WebDriverWait WebDriverWait => new WebDriverWait(Driver, TimeSpan.FromSeconds(180));

        public static IWebElement StartFromScratch()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.startFromScratch)));
        }

        public static IWebElement Smoke20x20x10()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.smoke20x20x10)));
        }

        public static IWebElement MedPerformance()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.medPerformance)));
        }

        public static IWebElement LargeCross()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.largeCross)));
        }

        public static IWebElement Pricing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.pricing)));
        }

        public static IWebElement LRGPerformanceTest()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.lrgPerformanceTest)));
        }

        public static IWebElement GrandchildOpeningAddon()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.grandchildOpeningAddon)));
        }

        public static IWebElement Job30x40x16()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.job30x40x16)));
        }

        public static IWebElement GambrelRoof()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.gambrelRoof)));
        }

        public static IWebElement Template2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.template2)));
        }

        public static IWebElement Trusses()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.trusses)));
        }

        public static IWebElement Template3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.template3)));
        }
        public static IWebElement Template4()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.template4)));
        }

        public static IWebElement WoodFlrAndPeakOut()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.woodFlrAndPeakOut)));
        }

        public static IWebElement InlineBuilding20x40()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.inlineBuilding20x40)));
        }
        public static IWebElement GirtsOutsideCorners()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.girtsOutsideCorners)));
        }
        public static IWebElement GirtsOutsidePost()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.girtsOutsidePost)));
        }
        public static IWebElement StudFrame30x60()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.studFrame30x60)));
        }
        public static IWebElement CantPorchAttachedBuilding()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.cantPorchAttachedBuilding)));
        }
        public static IWebElement AdvancedEdits()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.advancedEdits)));
        }
        public static IWebElement ParallelSteelTrusses()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.parallelSteelTrusses)));
        }
        public static IWebElement Barndominium()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.barndominium)));
        }

        public static IWebElement OverFramedRafterShed()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.overFramedRafterShed)));
        }
        public static IWebElement HomeButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.homeTab)));
        }
        public static IWebElement JobTab()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.jobTab)));
        }
        public static IWebElement AboutTab()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.aboutTab)));
        }
        public static IWebElement ContactTab()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.contactTab)));
        }

        public static void ClicksStartFromScratch()
        {
            CommonMethod.GetActions().Click(StartFromScratch()).Perform();
            CommonMethod.PageLoader();
            ExtentTestManager.TestSteps($"Click on the start from scratch");
            CommonMethod.Wait(2);
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        public static void ClicksSmoke20x20x10()
        {
            CommonMethod.GetActions().Click(Smoke20x20x10()).Perform();
        }
        public static void ClicksMedPerformance()
        {
            CommonMethod.GetActions().Click(MedPerformance()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksLRGPerformanceTest()
        {
            CommonMethod.GetActions().Click(LRGPerformanceTest()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksLargeCross()
        {
            CommonMethod.GetActions().Click(LargeCross()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksGrandchildOpeningAddon()
        {
            CommonMethod.GetActions().Click(GrandchildOpeningAddon()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksJob30x40x16()
        {
            CommonMethod.GetActions().Click(Job30x40x16()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksGambrelRoof()
        {
            CommonMethod.GetActions().Click(GambrelRoof()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksTemplate2()
        {
            CommonMethod.GetActions().Click(Template2()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksTemplate3()
        {
            CommonMethod.GetActions().Click(Template3()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksTemplate4()
        {
            CommonMethod.GetActions().Click(Template4()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksWoodFlrAndPeakOut()
        {
            CommonMethod.GetActions().Click(WoodFlrAndPeakOut()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksInlineBuilding20x40()
        {
            CommonMethod.GetActions().Click(InlineBuilding20x40()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksGirtsOutsideCorners()
        {
            CommonMethod.GetActions().Click(GirtsOutsideCorners()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksGirtsOutsidePost()
        {
            CommonMethod.GetActions().Click(GirtsOutsidePost()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksStudFrame30x60()
        {
            CommonMethod.GetActions().Click(StudFrame30x60()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksCantPorchAttachedBuilding()
        {
            CommonMethod.GetActions().Click(CantPorchAttachedBuilding()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksAdvancedEdits()
        {
            CommonMethod.GetActions().Click(AdvancedEdits()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksParallelSteelTrusses()
        {
            CommonMethod.GetActions().Click(ParallelSteelTrusses()).Perform();
            CommonMethod.PageLoader();
        }

        public static void ClicksBarndominium()
        {
            CommonMethod.GetActions().Click(Barndominium()).Perform();
            CommonMethod.PageLoader();
        }
        public static void ClicksOverFramedRafterShed()
        {
            CommonMethod.GetActions().Click(OverFramedRafterShed()).Perform();
            CommonMethod.PageLoader();
        }

        public static void ClicksHomeButton()
        {
            CommonMethod.GetActions().Click(HomeButton()).Perform();
        }
        public static void ClicksJobTab()
        {
            CommonMethod.GetActions().Click(JobTab()).Perform();
            CommonMethod.WaitForPageElementInvisibility(Locator.JobPage.WaitForTheSpinner);
            ExtentTestManager.TestSteps($"Click on the job tab");
        }
        public static void ClicksAboutTab()
        {
            CommonMethod.GetActions().Click(AboutTab()).Perform();
        }
        public static void ClicksContactTab()
        {
            CommonMethod.GetActions().Click(ContactTab()).Perform();
        }

        public static IWebElement Admin()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.admin)));
        }
        public static IWebElement Setting()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.settings)));
        }

        public static IWebElement FramingRules()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.framingRules)));
        }

        public static IWebElement SetupWizard()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.setupWizard)));
        }

        public static IWebElement Packages()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.packages)));
        }

        public static IWebElement Materials()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.materials)));
        }

        public static IWebElement Builders()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.builders)));
        }

         public static IWebElement Colors()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.colors)));
        }

        public static IWebElement Outputs()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.outputs)));
        }

        public static IWebElement Distributor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.distributors)));
        }

        public static IWebElement DoorsAndWindows()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.doorsAndWindows)));
        }
         public static IWebElement EModeler()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.eModeler)));
        }
        public static IWebElement OutputCategories()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.outputCategories)));
        }

        public static IWebElement PaymentSchedule()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.paymentSchedule)));
        }

         public static IWebElement Customize()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.customize)));
        }

        public static IWebElement GetTheListOfElementFromSettings()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.HomePage.getTheSettingListElement)));
        }

        public static void ClickSetting()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(Setting()).Perform();
            ExtentTestManager.TestSteps($"Click on th setting button");
        }
        public static void ClickAdmin()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(Admin()).Perform();
            ExtentTestManager.TestSteps($"Click on th setting button");
        }

        public static void NavigateToFramingRulesPages()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(FramingRules()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the framing rules");
        }
        public static void NavigateToSetupWizardPages()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(SetupWizard()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.SetupWizard.WaitForTHeSubMenuVisible)));
            ExtentTestManager.TestSteps($"Navigate to the setup wizard");
        }

        public static void NavigateToPackagePagesForPostFrame()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Packages()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Packages.waitForThePackagePageLoad)));
            ExtentTestManager.TestSteps($"Navigate to the job page");
        }

         public static void NavigateToPackagePagesForRoofingPassport()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Packages()).Perform();
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps($"Navigate to the job page");
        }

        public static void NavigateToTheMaterialsPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Materials()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Navigate to the materials page");
        }

        public static void NavigateToTheBuilderPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Builders()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Navigate to the builder page");
        }

         public static void NavigateToThePricingPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Pricing()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Navigate to the pricing page");
            CommonMethod.Wait(1);
        }

        public static void NavigateToTheColorsPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Colors()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the color page");
        }

        public static void NavigateToTheOutputPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Outputs()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the materials page");
            CommonMethod.Wait(3);
        }

        public static void NavigateToDistributor()
        {
            ClickAdmin();
            CommonMethod.GetActions().Click(Distributor()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the distributor page");
            WebDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(3);
        }

        public static void NavigateToCustomizePage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Customize()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the customize page");
        }

        public static void NavigateToTrusses()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(Trusses()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the trusses page");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.Trusses.searchInputField)));
            CommonMethod.Wait(3);
        }

        public static void NavigateToDoorAndWindowPage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(DoorsAndWindows()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the Doors And Windows page");
            WebDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(1);
        }

        public static void NavigateToPaymentSchedulePage()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(PaymentSchedule()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the Payment Schedule page");
        }

        public static void NavigateToEModeler()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(EModeler()).Perform();
            ExtentTestManager.TestSteps($"Navigate to the EModeler page");
        }

        public static void NavigateToOutputCategories()
        {
            ClickSetting();
            CommonMethod.GetActions().Click(OutputCategories()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Navigate to the Output Categories page");
        }

        public static void VerifyElementIsNotShownInTheSettingList(string nameOfElement)
        {
            ClickSetting();
            string dropDownList = GetTheListOfElementFromSettings().Text;

            if(dropDownList.Contains(nameOfElement))
            {
                Assert.Fail($"Verify that the {nameOfElement} appears from the Settings dropdown list.");
            }

            ExtentTestManager.TestSteps($"Verify that the {nameOfElement} disappears from the Settings dropdown list.");
            Console.WriteLine($"Verify that the {nameOfElement} disappears from the Settings dropdown list.");
        }

        public static void VerifyElementInTheSettingList(string nameOfElement)
        {
            string dropDownList = GetTheListOfElementFromSettings().Text;

            if (dropDownList.Contains(nameOfElement))
            {
                ExtentTestManager.TestSteps($"Verify that the {nameOfElement} appears from the Settings dropdown list.");
                Console.WriteLine($"Verify that the {nameOfElement} appears from the Settings dropdown list.");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verify that the {nameOfElement} disappears from the Settings dropdown list.");
                Assert.Fail($"Verify that the {nameOfElement} disappears from the Settings dropdown list.");
            }
        }

        public static void PerformImageComparison(string firstPath, string secondPath, string ifStatement, string elseStatement, string iconImage1, string iconImage2)
        {
            // Provide the file paths of the two images to compare
            string imagePath1 = $@"{secondPath}\{iconImage1}";
            string imagePath2 = $@"{firstPath}\{iconImage2}";

            // Create an instance of the ImageComparisonExample class
            var imageComparison = new AddNewStyle();

            // Compare the images with the default threshold (5)
            bool areImagesSimilar = imageComparison.CompareImages(imagePath1, imagePath2);

            // Print the result
            if (areImagesSimilar)
            {
                Console.WriteLine($"{ifStatement}");
                ExtentTestManager.TestSteps($"{ifStatement}");
            }
            else
            {
                Console.WriteLine($"{elseStatement}");
                ExtentTestManager.TestSteps($"{elseStatement}");
            }
        }

        public static bool GetTheAllElementFromSettingsList(string settingsListMaterialName)
        {
            bool result = false;
            CommonMethod.Wait(1);
            IReadOnlyList<IWebElement> elements = Driver.FindElements(By.XPath("(//ul[@class='dropdown-menu'])[2]//a"));
        
            foreach (IWebElement element in elements)
            {
                string elementName = element.Text;

                if(!string.IsNullOrEmpty(elementName) && elementName.Equals(settingsListMaterialName))
                {
                    result = true;
                }
            }

            return result;
        }

        public static void CheckElementShownInTheSettingsList(string settingsListMaterialName)
        {
            bool materialLists = GetTheAllElementFromSettingsList(settingsListMaterialName);
            Assert.True(materialLists,$"{settingsListMaterialName} element is not shown in the setting list");
        }

        public static void CheckElementIsNotShownInTheSettingsList(string settingsListMaterialName)
        {
            bool materialLists = GetTheAllElementFromSettingsList(settingsListMaterialName);
            Assert.IsFalse(materialLists,$"{settingsListMaterialName} element shown in the setting list");
        }



        #region Compare Two Excel file
        public static List<List<string>> ReadExcelFile(string filePath, string sheetName)
        {
            List<List<string>> data = new List<List<string>>();

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(sheetName);
                foreach (var row in worksheet.RowsUsed())
                {
                    data.Add(row.Cells().Select(c => c.GetString()).ToList());
                }
            }

            return data;
        }

        public static bool CompareExcelSheets(string filePath1, string sheetName1, string filePath2, string sheetName2)
        {
            var data1 = ReadExcelFile(filePath1, sheetName1);
            var data2 = ReadExcelFile(filePath2, sheetName2);

            if (data1.Count != data2.Count)
            {
                return false;
            }

            for (int i = 0; i < data1.Count; i++)
            {
                var row1 = data1[i];
                var row2 = data2[i];

                if (!row1.SequenceEqual(row2))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
#endregion