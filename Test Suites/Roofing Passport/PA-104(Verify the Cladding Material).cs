using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Roofing_Passport")]
    public class Cladding : BaseClass
    {
        readonly string EntriesTableElement = "(//div[@id='grid_entriesGrid_records']//div[text()='{0}'])[1]";

        [Test]
        public void EditColorMaterial()
        {
            ExtentTestManager.CreateTest("Edit Cladding Material List does not show Closure");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();

            GetDataFromCladdingAssemblies(out string clipOutputCategory, out string clipMaterial, out string fastenerOutputCategory,
            out string fastenerMaterial, out string sealantOutputCategory, out string sealantMaterial, out string UnderlaymentMaterial,
            out string DeckingOutputCategory, out string DeckingMaterial, out string OtherOutputCategory, out string OtherMaterial);

            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            CommonMethod.Wait(2);
            DefaultJobElement.PlaceOpening(100, 50);
            ExtentTestManager.TestSteps("Click on any panel of roof");
            DefaultJobElement.SelectionDropdown("Cladding Assembly 1+");
            DefaultJobElement.ClickSaveChangesButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.PlaceOpening(100, 50);
            ExtentTestManager.TestSteps("Click on any panel of roof");

            string primaryMaterial = GetThePrimaryMaterialsData();
            Assert.That(primaryMaterial, Is.EqualTo("Cladding Data Test Material"));
            ExtentTestManager.TestSteps("The primary material and entries are shown in the material list");
            DefaultJobElement.ClickSaveChangesButton();

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickCladdingOfJobReview();
            ExtentTestManager.TestSteps("For Cladding Assemblies");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Cladding", "-Other", null, OtherMaterial, null, null, null, null, null, null, null);
            ExtentReport(OtherOutputCategory);
            DefaultJobElement.JobReviewButton(fastenerOutputCategory);
            DefaultJobElement.ClickTrimOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Trim", "-Fastener", null, fastenerMaterial, null, null, null, null, null, null, null);
            ExtentReport(fastenerOutputCategory);
            DefaultJobElement.ClickAccessoriesOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Accessories", "-Clip", null, clipMaterial, null, null, null, null, null, null, null);
            DefaultJobElement.CheckMaterialsDataFromJobReview("Accessories", "-Underlayment", null, UnderlaymentMaterial, null, null, null, null, null, null, null);
            ExtentReport(clipOutputCategory);
            DefaultJobElement.ClickLaborOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Labor", "-Decking", null, DeckingMaterial, null, null, null, null, null, null, null);
            ExtentReport(DeckingOutputCategory);
            DefaultJobElement.ClickFreightOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Labor", "-Sealant", null, sealantMaterial, null, null, null, null, null, null, null);
            ExtentReport(sealantOutputCategory);
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.NavigateToHomePage();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Jobs Page");
        }

        #region private Methods
        private void GetDataFromCladdingAssemblies(out string clipOutputCategory, out string clipMaterial, out string fastenerOutputCategory, out string fastenerMaterial, out string sealantOutputCategory, out string sealantMaterial, out string UnderlaymentMaterial, out string DeckingOutputCategory, out string DeckingMaterial, out string OtherOutputCategory, out string OtherMaterial)
        {
            SetupWizard.ClickCladdingAssemblies();
            SetupWizard.SearchElementAndClickOnTheEdit("Cladding Assembly 1");

            GetTheElementsDataOfCladdingTable("Clip");
            clipOutputCategory = GetTheOutputCategoryData();
            clipMaterial = GetTheMaterialsData();
            CancelButton();

            GetTheElementsDataOfCladdingTable("Fastener");
            fastenerOutputCategory = GetTheOutputCategoryData();
            fastenerMaterial = GetTheMaterialsData();
            CancelButton();

            GetTheElementsDataOfCladdingTable("Sealant");
            sealantOutputCategory = GetTheOutputCategoryData();
            sealantMaterial = GetTheMaterialsData();
            CancelButton();

            GetTheElementsDataOfCladdingTable("Underlayment");
            string UnderlaymentOutputCategory = GetTheOutputCategoryData();
            UnderlaymentMaterial = GetTheMaterialsData();
            CancelButton();

            GetTheElementsDataOfCladdingTable("Decking");
            DeckingOutputCategory = GetTheOutputCategoryData();
            DeckingMaterial = GetTheMaterialsData();
            CancelButton();

            GetTheElementsDataOfCladdingTable("Other");
            OtherOutputCategory = GetTheOutputCategoryData();
            OtherMaterial = GetTheMaterialsData();
            CancelButton();
            CancelButton();
        }

        private void GetTheElementsDataOfCladdingTable(string elementName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(EntriesTableElement, elementName))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"DoubleClick on the {elementName}");
        }

        private string GetTheOutputCategoryData()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//label[text()='Output Category'])[1]//following :: div[2]")));
            string outputCategory = CommonMethod.element.GetAttribute("title");
            return outputCategory;
        }

        private string GetTheMaterialsData()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@id='materialBtn'])[1]")));
            string material = CommonMethod.element.Text;
            return material;
        }

        private void CancelButton()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@id='Cancel'])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the cancel");
        }

        private string GetThePrimaryMaterialsData()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='primaryMaterial']")));
            string primaryMaterial = CommonMethod.element.Text;
            return primaryMaterial;
        }

        private void ExtentReport(string elementName)
        {
            Console.WriteLine($"Verify that the stored entry is shown to the user in the {elementName}");
            ExtentTestManager.TestSteps($" Verify that the stored entry is shown to the user in the {elementName}");
        }
    }
}
#endregion