using Forms.Reporting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Drawing;
using System.IO;
using static SmartBuildAutomation.pageObjectModel.Performance;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Compare_Job")]
    class AllJobData : BaseClass
    {
        public static string path = FolderPath.CompareJobData();

        /// <summary>
        /// 1. Login to AUTOTEST_PHTEST Distributor for Test Environment.
        /// 2. Click on Smoke20x20x10 Job and wait for load model.
        /// 3. Click on Job Review Tab and get the All data.
        /// 4. Login to AUTOTEST_PHTEST Distributor for Beta Environment.
        /// 5. Click on Smoke20x20x10 Job and wait for load model.
        /// 6. Click on Job Review Tab and get the All data.
        /// 7. Login to AUTOTEST_PHTEST Distributor for Production Environment.
        /// 8. Click on Smoke20x20x10 Job and wait for load model.
        /// 9. Click on Job Review Tab and get the All data.
        /// 10.Compare All data on Test, Beta, and Production Environment
        /// </summary>

        [Test, Order(1)]
        public void Smoke20x20x10()
        {
            LoginApplicationAndChangesDistributor("Smoke20x20x10 Job");
            CreateExcelSheet();

            // On the Test Environment, get all data for Smoke20x20x10 
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Smoke20x20x10
            CommonMethod.GoToBetaEnvironment();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Smoke20x20x10
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 2, "Smoke20x20x10", "PA-39", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 3, "Smoke20x20x10", "PA-40", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 4, "Smoke20x20x10", "PA-41", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 5, "Smoke20x20x10", "PA-42", "Trim Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 6, "Smoke20x20x10", "PA-43", "Trusses Data");
        }

        [Test, Order(2)]
        public void MediumPerformance()
        {
            ExtentTestManager.CreateTest("Medium Performance Job ");

            CommonMethod.Login();
            // On the Test Environment, get all data for Medium Performance
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksMedPerformance();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Medium Performance
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksMedPerformance();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Medium Performance 
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksMedPerformance();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 7, "Medium Performance Job", "PA-44", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 8, "Medium Performance Job", "PA-45", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 9, "Medium Performance Job", "PA-46", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 10, "Medium Performance Job", "PA-47", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 11, "Medium Performance Job", "PA-48", "Door & Windows Data");
            CompareData(accessoriesOnTest, accessoriesOnBeta, accessoriesOnLive, 12, "Medium Performance Job", "PA-49", "Accessories Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 13, "Medium Performance Job", "PA-50", "Trusses Data");
        }

        [Test, Order(3)]
        public void LargePerformanceTest()
        {
            ExtentTestManager.CreateTest("Large Performance Test Job ");
            CommonMethod.Login();
            // On the Test Environment, get all data for Large Performance Test Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksLRGPerformanceTest();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Large Performance Test Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksLRGPerformanceTest();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Large Performance Test Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksLRGPerformanceTest();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 14, "Large Performance Test Job", "PA-51", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 15, "Large Performance Test Job", "PA-52", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 16, "Large Performance Test Job", "PA-53", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 17, "Large Performance Test Job", "PA-54", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 18, "Large Performance Test Job", "PA-55", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 19, "Large Performance Test Job", "PA-56", "Trusses Data");
        }

        [Test, Order(4)]
        public void CrossLarge()
        {
            ExtentTestManager.CreateTest("Large Cross Job").Info(TestContext.Parameters.Get("DistributorInfo"));
            CommonMethod.Login();
            // On the Test Environment, get all data for Cross Large Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksLargeCross();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Cross Large Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksLargeCross();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Cross Large Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksLargeCross();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 20, "Large Cross Job", "PA-58", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 21, "Large Cross Job", "PA-59", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 22, "Large Cross Job", "PA-60", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 23, "Large Cross Job", "PA-61", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 24, "Large Cross Job", "PA-62", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 25, "Large Cross Job", "PA-63", "Trusses Data");
        }

        [Test, Order(5)]
        public void DataOfJob30x40x16()
        {
            ExtentTestManager.CreateTest("30x40x16 Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for 30x40x16 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksJob30x40x16();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for 30x40x16 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksJob30x40x16();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for 30x40x16 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksJob30x40x16();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 26, "30x40x16 Job", "PA-66", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 27, "30x40x16 Job", "PA-67", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 28, "30x40x16 Job", "PA-68", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 29, "30x40x16 Job", "PA-69", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 30, "30x40x16 Job", "PA-70", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 31, "30x40x16 Job", "PA-71", "Trusses Data");
        }

        [Test, Order(6)]
        public void GambrelRoof()
        {
            ExtentTestManager.CreateTest("Gambrel Roof Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Gambrel Roof Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksGambrelRoof();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Gambrel Roof Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksGambrelRoof();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Gambrel Roof Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksGambrelRoof();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 32, "Gambrel Roof Job", "PA-72", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 33, "Gambrel Roof Job", "PA-73", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 34, "Gambrel Roof Job", "PA-74", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 35, "Gambrel Roof Job", "PA-75", "Trim Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 36, "Gambrel Roof Job", "PA-76", "Trusses Data");
        }

        [Test, Order(7)]
        public void Template2()
        {
            ExtentTestManager.CreateTest("Template 2 Job").Info(TestContext.Parameters.Get("DistributorInfo"));
            CommonMethod.Login();
            // On the Test Environment, get all data for Template 2 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksTemplate2();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Template 2 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksTemplate2();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Template 2 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksTemplate2();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 37, "Template 2 Job", "PA-77", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 38, "Template 2 Job", "PA-78", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 39, "Template 2 Job", "PA-79", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 40, "Template 2 Job", "PA-80", "Trim Data");
        }

        [Test, Order(8)]
        public void Template3()
        {
            ExtentTestManager.CreateTest("Template 3 Job ");
            CommonMethod.Login();
            // On the Test Environment, get all data for Template 3 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksTemplate3();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Template 3 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksTemplate3();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Template 3 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksTemplate3();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 41, "Template 3 Job", "PA-81", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 42, "Template 3 Job", "PA-85", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 43, "Template 3 Job", "PA-86", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 44, "Template 3 Job", "PA-87", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 45, "Template 3 Job", "PA-88", "Door & Windows Data");
            CompareData(accessoriesOnTest, accessoriesOnBeta, accessoriesOnLive, 46, "Template 3 Job", "PA-89", "Accessories Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 47, "Template 3 Job", "PA-90", "Trusses Data");
        }

        [Test, Order(9)]
        public void Template4()
        {
            ExtentTestManager.CreateTest("Template 4 Job ");
            CommonMethod.Login();
            // On the Test Environment, get all data for Template 4 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksTemplate4();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Template 4 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksTemplate4();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Template 4 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksTemplate4();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string accessoriesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Accessories", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 48, "Template 4 Job", "PA-91", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 49, "Template 4 Job", "PA-92", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 50, "Template 4 Job", "PA-93", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 51, "Template 4 Job", "PA-94", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 52, "Template 4 Job", "PA-95", "Door & Windows Data");
            CompareData(accessoriesOnTest, accessoriesOnBeta, accessoriesOnLive, 53, "Template 4 Job", "PA-96", "Accessories Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 54, "Template 4 Job", "PA-97", "Trusses Data");
        }

        [Test, Order(10)]
        public void WoodFlrNPeakOut()
        {
            ExtentTestManager.CreateTest("Wood Flr N Peak Out Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Wood Flr N Peak Out Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksWoodFlrAndPeakOut();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Wood Flr N Peak Out Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksWoodFlrAndPeakOut();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Wood Flr N Peak Out Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksWoodFlrAndPeakOut();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 55, "Wood Flr N Peak Out Job", "PA-98", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 56, "Wood Flr N Peak Out Job", "PA-99", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 57, "Wood Flr N Peak Out Job", "PA-100", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 58, "Wood Flr N Peak Out Job", "PA-101", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 59, "Wood Flr N Peak Out Job", "PA-102", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 60, "Wood Flr N Peak Out Job", "PA-103", "Trusses Data");
        }

        [Test, Order(11)]
        public void GrandChild()
        {
            ExtentTestManager.CreateTest("GrandChild Opening Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for GrandChild Opening Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksGrandchildOpeningAddon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for GrandChild Opening Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksGrandchildOpeningAddon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for GrandChild Opening Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksGrandchildOpeningAddon();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 61, "GrandChild Opening Job", "PA-108", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 62, "GrandChild Opening Job", "PA-109", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 63, "GrandChild Opening Job", "PA-110", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 64, "GrandChild Opening Job", "PA-111", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 65, "GrandChild Opening Job", "PA-112", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 66, "GrandChild Opening Job", "PA-113", "Trusses Data");
        }

        [Test, Order(12)]
        public void InlineBuilding20x40()
        {
            ExtentTestManager.CreateTest("Inline Building 20x40 Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Inline Building 20x40 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksInlineBuilding20x40();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Inline Building 20x40 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksInlineBuilding20x40();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Inline Building 20x40 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksInlineBuilding20x40();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 67, "Inline Building 20x40 Job", "PA-117", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 68, "Inline Building 20x40 Job", "PA-118", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 69, "Inline Building 20x40 Job", "PA-119", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 70, "Inline Building 20x40 Job", "PA-120", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 71, "Inline Building 20x40 Job", "PA-121", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 72, "Inline Building 20x40 Job", "PA-122", "Trusses Data");
        }

        [Test, Order(13)]
        public void GirtOutsideCorners()
        {
            ExtentTestManager.CreateTest("Girt Outside Corners Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Girt Outside Corners Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksGirtsOutsideCorners();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Girt Outside Corners Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksGirtsOutsideCorners();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Girt Outside Corners Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksGirtsOutsideCorners();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 73, "Girt Outside Corners Job", "PA-123", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 74, "Girt Outside Corners Job", "PA-124", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 75, "Girt Outside Corners Job", "PA-125", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 76, "Girt Outside Corners Job", "PA-126", "Trim Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 77, "Girt Outside Corners Job", "PA-127", "Trusses Data");
        }

        [Test, Order(14)]
        public void GirtOutsidePost()
        {
            ExtentTestManager.CreateTest("Girt Outside Post Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Girt Outside Post Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksGirtsOutsidePost();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Girt Outside Post Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksGirtsOutsidePost();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Girt Outside Post Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksGirtsOutsidePost();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 78, "Girt Outside Post Job", "PA-133", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 79, "Girt Outside Post Job", "PA-134", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 80, "Girt Outside Post Job", "PA-135", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 81, "Girt Outside Post Job", "PA-136", "Trim Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 82, "Girt Outside Post Job", "PA-137", "Trusses Data");
        }

        [Test, Order(15)]
        public void StudFrame30x60()
        {
            ExtentTestManager.CreateTest("Stud Frame 30x60 Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Stud Frame 30x60 Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksStudFrame30x60();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Stud Frame 30x60 Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksStudFrame30x60();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Stud Frame 30x60 Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksStudFrame30x60();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 83, "Stud Frame 30x60 Job", "PA-138", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 84, "Stud Frame 30x60 Job", "PA-139", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 85, "Stud Frame 30x60 Job", "PA-140", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 86, "Stud Frame 30x60 Job", "PA-141", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 87, "Stud Frame 30x60 Job", "PA-142", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 88, "Stud Frame 30x60 Job", "PA-143", "Trusses Data");
        }

        [Test, Order(16)]
        public void CantPorchAttachedBuilding()
        {
            ExtentTestManager.CreateTest("Cant Porch Attached Building Job");
            CommonMethod.Login();
            // On the Production Environment, get all data for Cant Porch Attached Building Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksCantPorchAttachedBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Cant Porch Attached Building Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksCantPorchAttachedBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Cant Porch Attached Building Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksCantPorchAttachedBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 89, "Cant Porch Attached Building Job", "PA-144", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 90, "Cant Porch Attached Building Job", "PA-155", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 91, "Cant Porch Attached Building Job", "PA-146", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 92, "Cant Porch Attached Building Job", "PA-147", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 93, "Cant Porch Attached Building Job", "PA-148", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 94, "Cant Porch Attached Building Job", "PA-149", "Trusses Data");
        }

        [Test, Order(17)]
        public void AdvancedEdit()
        {
            ExtentTestManager.CreateTest("Advanced Edit Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Advanced Edit Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksAdvancedEdits();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Advanced Edit Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksAdvancedEdits();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Advanced Edit Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksAdvancedEdits();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 95, "Advanced Edit Job", "PA-150", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 96, "Advanced Edit Job", "PA-151", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 97, "Advanced Edit Job", "PA-152", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 98, "Advanced Edit Job", "PA-153", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 99, "Advanced Edit Job", "PA-154", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 100, "Advanced Edit Job", "PA-155", "Trusses Data");
        }

        [Test, Order(18)]
        public void ParallelSteelTrusses()
        {
            ExtentTestManager.CreateTest("Parallel Steel Trusses Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Parallel Steel Trusses Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksParallelSteelTrusses();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Parallel Steel Trusses Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksParallelSteelTrusses();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Parallel Steel Trusses Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksParallelSteelTrusses();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 101, "Parallel Steel Trusses Job", "PA-156", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 102, "Parallel Steel Trusses Job", "PA-157", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 103, "Parallel Steel Trusses Job", "PA-158", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 104, "Parallel Steel Trusses Job", "PA-159", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 105, "Parallel Steel Trusses Job", "PA-160", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 106, "Parallel Steel Trusses Job", "PA-161", "Trusses Data");
        }

        [Test, Order(19)]
        public void Barndominium()
        {
            ExtentTestManager.CreateTest("Barndominium Job");
            CommonMethod.Login();
            // On the Test Environment, get all data for Barndominium Job
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Test Environment");
            HomePage.ClicksBarndominium();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnTest = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Beta Environment, get all data for Barndominium Job
            CommonMethod.GoToBetaEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Beta Environment");
            HomePage.ClicksBarndominium();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnBeta = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            // On the Production Environment, get all data for Barndominium Job
            CommonMethod.GoToProductionEnvironment();
            ExtentTestManager.TestSteps($"Login to AUTOTEST_PHTEST Distributor for Production Environment");
            HomePage.ClicksBarndominium();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string summaryOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Summary", "grid_SummaryGrid_body");
            string framingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Framing", "grid_MaterialsGrid_records");
            string sheathingOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Sheathing", "grid_MaterialsGrid_records");
            string trimOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trim", "grid_MaterialsGrid_records");
            string doorsAndWindowsOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Doors & Windows", "grid_MaterialsGrid_records");
            string trussesOnLive = DefaultJobElement.GetTheDataFromTheJobReview("Trusses", "grid_MaterialsGrid_records");

            CompareData(summaryOnTest, summaryOnBeta, summaryOnLive, 107, "Barndominium Job", "PA-162", "Summary Data");
            CompareData(framingOnTest, framingOnBeta, framingOnLive, 108, "Barndominium Job", "PA-163", "Framing Data");
            CompareData(sheathingOnTest, sheathingOnBeta, sheathingOnLive, 109, "Barndominium Job", "PA-164", "Sheathing Data");
            CompareData(trimOnTest, trimOnBeta, trimOnLive, 104, "Barndominium Job", "PA-165", "Trim Data");
            CompareData(doorsAndWindowsOnTest, doorsAndWindowsOnBeta, doorsAndWindowsOnLive, 110, "Barndominium Job", "PA-166", "Door & Windows Data");
            CompareData(trussesOnTest, trussesOnBeta, trussesOnLive, 111, "Barndominium Job", "PA-167", "Trusses Data");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Compare job");
        }

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

        #region Create Excel Sheet
        public void CreateExcelSheet()
        {
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("dd-MM-yyyy");
            string staticName = NameProvider.StaticName;
            string excelFileData = $@"{path}\Compare Job Report.xlsx";

            // Open Excel File 
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(excelFileData, FileMode.Open));

            // Create a new sheet or get the existing one
            ISheet sheet = workbook.GetSheet(staticName) ?? workbook.CreateSheet(staticName);

            // Write data to the sheet
            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Jobs Name");
            headerRow.CreateCell(1).SetCellValue("Script Name");
            headerRow.CreateCell(2).SetCellValue("Material Name");
            headerRow.CreateCell(3).SetCellValue("Verified Material Data on Test, Beta and Production");

            // Style the header row
            ICellStyle style = workbook.CreateCellStyle();
            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = IndexedColors.LightBlue.Index;

            IFont font = workbook.CreateFont();
            font.FontName = "Times New Roman";
            font.FontHeightInPoints = 14;
            style.SetFont(font);

            for (int i = 0; i < 4; i++)
            {
                headerRow.GetCell(i).CellStyle = style;
            }

            using (FileStream fileStream = new FileStream(excelFileData, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fileStream);
            }
        }
        #endregion
        public static bool CompareData(string testData, string beta, string live, int i, string jobName, string ticketNumber, string dataName)
        {
            DateTime dateTime = DateTime.Now;
            string date = dateTime.ToString("dd-MM-yyyy");
            string excelFileData = $@"{path}\Compare Job Report.xlsx";
            string name;
            name = dateTime.ToString("dd-MM-yyyy");


            // Open Excel File   
            using (var excelSheet = new ExcelPackage(new FileInfo(excelFileData)))
            {
                // Create a new sheet or get the existing one
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var workbook = excelSheet.Workbook;
                var sheet = workbook.Worksheets[workbook.Worksheets.Count - 1];

                // Set the data in the specified row (i) and column 3 (C)
                sheet.Cells[i, 1].Value = jobName;
                sheet.Cells[i, 2].Value = ticketNumber;
                sheet.Cells[i, 3].Value = dataName;

                ExcelRange cellA = sheet.Cells[i, 1];
                cellA.Style.Font.Name = "Times New Roman";
                cellA.Style.Font.Size = 14;
                ExcelRange cellB = sheet.Cells[i, 2];
                cellB.Style.Font.Name = "Times New Roman";
                cellB.Style.Font.Size = 14;
                ExcelRange cellC = sheet.Cells[i, 3];
                cellC.Style.Font.Name = "Times New Roman";
                cellC.Style.Font.Size = 14;

                // Bold the text in column 3 (cell 3)
                ExcelRange cell4 = sheet.Cells[i, 4];
                cell4.Style.Font.Bold = true;
                cell4.Style.Font.Name = "Times New Roman";
                cell4.Style.Font.Size = 14;

                try
                {
                    // Compare data on Test, Beta, and Production Environments
                    if (testData.Equals(beta) && beta.Equals(live) && testData.Equals(live) && !string.IsNullOrEmpty(testData) && !string.IsNullOrEmpty(beta) && !string.IsNullOrEmpty(live))
                    {
                        Console.WriteLine($"{dataName} are the same for Beta, Test, and Production");
                        cell4.Value = dataName + " are the same for Beta, Test, and Production";
                        cell4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell4.Style.Fill.BackgroundColor.SetColor(Color.LightGreen);
                        ExtentTestManager.TestSteps($"{dataName} are the same for Beta, Test, and Production");
                        excelSheet.Save();
                    }
                    else if (testData.Equals(beta))
                    {
                        cell4.Value = dataName + " are the same for Test, Beta, and Different for Production";
                        cell4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell4.Style.Fill.BackgroundColor.SetColor(Color.Red);
                        ExtentTestManager.TestSteps($"{dataName} are the same for Test, Beta, and Different for Production");
                        excelSheet.Save();
                        Assert.Fail($"{dataName} are the same for Test, Beta, and Different for Production");
                    }
                    else if (beta.Equals(live))
                    {
                        cell4.Value = dataName + " are the same for Production, Beta, and Different for Test";
                        cell4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell4.Style.Fill.BackgroundColor.SetColor(Color.Red);
                        ExtentTestManager.TestSteps($"{dataName} are the same for Production, Beta, and Different for Test");
                        excelSheet.Save();
                        Assert.Fail($"{dataName} are the same for Production, Beta, and Different for Test");
                    }
                    else if (testData.Equals(live))
                    {
                        cell4.Value = dataName + " are the same for Test, Production, and Different for Beta";
                        cell4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell4.Style.Fill.BackgroundColor.SetColor(Color.Red);
                        ExtentTestManager.TestSteps($"{dataName} are the same for Test, Production, and Different for Beta");
                        excelSheet.Save();
                        Assert.Fail($"{dataName} are the same for Test, Production, and Different for Beta");
                    }
                    else
                    {
                        cell4.Value = dataName + " is different on all servers";
                        cell4.Style.Fill.PatternType = ExcelFillStyle.Solid;
                        cell4.Style.Fill.BackgroundColor.SetColor(Color.Yellow);
                        ExtentTestManager.TestSteps($"{dataName} is different on all servers");
                        excelSheet.Save();
                        Assert.Fail($"{dataName} is different on all servers");
                    }
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
