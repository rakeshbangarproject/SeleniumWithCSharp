using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Setup_wizard")]
    public class Filter : BaseClass
    {
        [Test]
        public void ColorFilter()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Filter Assemblies");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();

            if (SetupWizard.FilterIcon().Displayed)
            {
                SetupWizard.ClickFilterIcon();
                Console.WriteLine($"Filter Icon is Visible on Color Tab");
                ExtentTestManager.TestSteps($"Filter Icon is Visible on Color Tab");
            }
            else
            {
                Assert.Fail("Filter Icon is not Visible on Color Tab");
            }

            // Click on Filter DropDown Value(3 tab Shingle)
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='3 tab Shingle']")));
            string ColorFilterData = CommonMethod.element.Text;
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on 3 tab Shingle from the Filter lists");

            // Click on First row of Color Table value 
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_grid_records']//td[@col='2'])[2]")));
            string firstRowElement = CommonMethod.element.Text;
            Assert.IsNotNull(firstRowElement, "3 tab Shingle data is not shown in the colors table");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).DoubleClick(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on First row of Color Table");

            // Get the product System Table Data 
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("grid_SystemsSelectedGrid_body")));
            string systemData = CommonMethod.element.Text;
            Assert.IsNotNull(systemData, "The system's color element is null");
            ExtentTestManager.TestSteps("Get the product System Table Data");

            if (systemData.Contains(ColorFilterData))
            {
                Console.WriteLine($"Selected the filter Icon Data is\n {ColorFilterData} \nThe Filter icon data is shown in the Product System table\n {systemData}");
                ExtentTestManager.TestSteps($"Selected the filter Icon Data is\n {ColorFilterData} \nThe Filter icon data is shown in the Product System table\n {systemData}");
            }
            else
            {
                ExtentTestManager.TestSteps($"Selected the filter Icon Data is\n {ColorFilterData} \nThe Filter icon data is not shown in the Product System table\n {systemData}");
                Assert.Fail($"Selected the filter Icon Data is\n {ColorFilterData} \nThe Filter icon data is not shown in the Product System table\n {systemData}");
            }

            SetupWizard.ClickCancelButton();
            SetupWizard.ClickSheathingAssemblies();

            if (SetupWizard.FilterIcon().Displayed)
            {
                SetupWizard.ClickFilterIcon();
                Console.WriteLine($"Filter Icon is Visible on Sheathing Assemblies Tab");
                ExtentTestManager.TestSteps($"Filter Icon is Visible on Sheathing Assemblies Tab");
            }
            else
            {
                Assert.Fail($"Filter Icon is not Visible on Sheathing Assemblies Tab");
            }

            // Click on Filter DropDown Value(3 tab Shingle)
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='3 tab Shingle']")));
            string filterValueOfSheathingAssemblies = CommonMethod.element.Text;
            Assert.IsNotNull(filterValueOfSheathingAssemblies, "The data is not shown in the Filter");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on 3 tab Shingle from the Filter lists");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_grid_records']//td[@col='1'])[2]")));
            string elementName = CommonMethod.element.Text;           
            Assert.That(!string.IsNullOrEmpty(elementName), "Sheathing Assemblies table is empty");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).DoubleClick(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on The First Row Of Sheathing Assemblies Table");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Primary Material']//following :: div[2]")));
            string primaryMaterialOfSheathing = CommonMethod.element.GetAttribute("title");
            Assert.IsNotNull(primaryMaterialOfSheathing, "The system's color element is null");
            SetupWizard.ClickCancelButton();

            SetupWizard.ClickSheathing();
            SetupWizard.SearchElementAndClickOnTheEdit(primaryMaterialOfSheathing);

            // Get the Product System Table Data 
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("grid_SystemsSelectedGrid_body")));
            string systemDataSheathing = CommonMethod.element.Text;
            Assert.IsNotNull(primaryMaterialOfSheathing, "The system's sheathing element is null");
            ExtentTestManager.TestSteps("Get the Product System Table Data");

            if (systemDataSheathing.Contains(filterValueOfSheathingAssemblies))
            {
                Console.WriteLine("The product system that was applied in the Sheathing Assembly tab is shown to the user in the primary material");
                ExtentTestManager.TestSteps("The product system that was applied in the Sheathing Assembly tab is shown to the user in the primary material");
            }
            else
            {
                Console.WriteLine("The product system that was applied in the Sheathing Assembly tab is not shown to the user in the primary material");
                ExtentTestManager.TestSteps("The product system that was applied in the Sheathing Assembly tab is not shown to the user in the primary material");
                Assert.Fail("$The product system that was applied in the Sheathing Assembly tab is not shown to the user in the primary material");
            }

            SetupWizard.ClickCancelButton();
            SetupWizard.ClickTrimAssemblies();

            if (SetupWizard.FilterIcon().Displayed)
            {
                SetupWizard.ClickFilterIcon();
                Console.WriteLine($"Filter Icon is Visible on Trim Assemblies Tab");
                ExtentTestManager.TestSteps($"Filter Icon is Visible on Trim Assemblies Tab");
            }
            else
            {
                Assert.Fail($"Filter Icon is not Visible on Trim Assemblies Tab");
            }

            // Click on Filter DropDown Value(3 tab Shingle)
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='3 tab Shingle']")));
            string filterValueOfTrimAssemblies = CommonMethod.element.Text;
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on 3 tab Shingle from the Filter lists");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='grid_grid_records']//td[@col='1'])[2]")));
            string firstRowElementTrimAssemblies = CommonMethod.element.Text;
            Assert.IsNotNull(firstRowElementTrimAssemblies, "Trim assemblies data is not shown");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).DoubleClick(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on The First Row Of Sheathing Assemblies Table");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[text()='Primary Material']//following :: div[2]")));
            string primaryMaterialOfTrim = CommonMethod.element.GetAttribute("title");
            Assert.IsNotNull(primaryMaterialOfTrim, "The primary material of trim assemblies element is null");
            SetupWizard.ClickCancelButton();
            SetupWizard.ClickTrim();
            SetupWizard.SearchElementAndClickOnTheEdit(primaryMaterialOfTrim);

            // Get the Product System Table Data 
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("grid_SystemsSelectedGrid_body")));
            string systemDataTrim = CommonMethod.element.Text;
            Assert.IsNotNull(systemDataTrim, "The system's of trim element is null");
            ExtentTestManager.TestSteps("Get the Product System Table Data");

            if (systemDataTrim.Contains(filterValueOfTrimAssemblies))
            {
                Console.WriteLine("The product system that was applied in the Trim Assembly tab is shown to the user in the primary material");
                ExtentTestManager.TestSteps("The product system that was applied in the Trim Assembly tab is shown to the user in the primary material");
            }
            else
            {
                Console.WriteLine("The product system that was applied in the Trim Assembly tab is not shown to the user in the primary material");
                ExtentTestManager.TestSteps("The product system that was applied in the Trim Assembly tab is not shown to the user in the primary material");
                Assert.Fail("The product system that was applied in the Trim Assembly tab is not shown to the user in the primary material");
            }

            SetupWizard.ClickCancelButton();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Filter Assemblies");
        }
    }
}