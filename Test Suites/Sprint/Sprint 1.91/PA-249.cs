using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{

    [TestFixture, Category("Smoke_test")]
    public class PackagesQuestion : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void PanelLengthWithAngledRoofCladdingExtensionForPostFrame()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Adding an inch sign \" to the Package question doesn't seed the default answer");
            string skuValue = AddDataInTheCalculationFieldUsingDoubleQuotationMark();
            VerifyDepthCalculationValueInTheDefaultJob(skuValue);
            DeleteDataFromPackages();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Adding an inch sign \" to the Package question doesn't seed the default answer");
        }

        #region Private Method
        /// <summary>
        /// Navigate to the packages page and Create new package using double quotation mark
        /// </summary>
        private string AddDataInTheCalculationFieldUsingDoubleQuotationMark()
        {
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.DeleteDataFromPackageTable("Driveway");
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.PackageNameInputField("Driveway");
            PackageElement.ClickAddCatalogButton();
            PackageElement.SelectOutputCategory("Accessories");
            PackageElement.SelectCatalogCategory("Foundation");
            PackageElement.SelectCatalogItem("1 m cube gravel");
            EnterDataInTheCalculationField();
            PackageElement.UsageInputField("DoubleQuotation");
            string skuName = PackageElement.GetTheSKUValue();
            PackageElement.ClickSaveButton();
            PackageElement.ClickMainSaveButton();
            return skuName;
        }

        /// <summary>
        /// Check double quotation value shown in the depth field when we use Driveway packages
        /// </summary>
        private void VerifyDepthCalculationValueInTheDefaultJob(string value)
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickPackages();
            DefaultJobElement.CheckAddOnsCheckbox("Driveway...");
            CheckDepthValue();
            CheckMaterialShownInTheJobReview(value);
        }

        /// <summary>
        /// Enter data in the calculation field
        /// </summary>
        private void EnterDataInTheCalculationField()
        {
            string formula = "(({?DEPTH 1\"? (Inches):4}/12){?Width(Feet):10}{?Length (Feet):10})/27";
            PackageElement.EnterCalculationInputField(formula);
        }

        /// <summary>
        /// Check depth field shown the correct value and click on the ok button
        /// </summary>
        private void CheckDepthValue()
        {
            string depthValue = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='DEPTH 1? (Inches)']"))).GetAttribute("value");
            Assert.That(depthValue, Is.EqualTo("4"), "Verify that the default value is not shown in the  DEPTH 1”? (Inches)");
            ExtentTestManager.TestSteps("Verify that the default value shown in the  DEPTH 1”? (Inches)");
            Console.WriteLine("Verify that the default value shown in the  DEPTH 1”? (Inches)");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(" //button[@id='Ok']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the OK button");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        /// <summary>
        /// Click on the job review tab and accessories tab
        /// Check the material value of Driveway package shown in the accessories table
        /// </summary>
        private void CheckMaterialShownInTheJobReview(string value)
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickAccessoriesOfJobReview();
            string materialValue = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='-DoubleQuotation']]/td[@col='2']/div"))).Text;
            Assert.That(materialValue, Is.EqualTo(value), "Verify that the newly created package is not shown in the Accessories table");
            ExtentTestManager.TestSteps("Verify that the newly created package is shown in the Accessories table");
            Console.WriteLine("Verify that the newly created package is shown in the Accessories table");
        }

        private void DeleteDataFromPackages()
        {
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToPackagePagesForPostFrame();
            PackageElement.DeleteDataFromPackageTable("Driveway");
            ExtentTestManager.TestSteps("Delete Driveway package");
            PackageElement.ClickMainSaveButton();
        }
    }
}
#endregion