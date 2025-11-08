using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class BundleOption : BaseClass
    {
        [Test, Order(1)]
        public void CheckBundleOptionValueShownInTheJobReview()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Options from Packages price is incorrect");
            HomePage.NavigateToPackagePagesForPostFrame();
            CheckOldDataShownInTheTableThenDeletedAndNavigateToPackage();
            CreatePackageMethod("Group 1", "Test 1", "Option", "Accessories", "Foundation", "3 PLY 2\" X 6\" POST H-Bracket");

            string priceForTest1 = GetThePriceOfCatalogElement("Test 1");
            PackageElement.ClickSaveButton();
            CreatePackageMethod("Group 1", "Test 2", "Option", "Accessories", "Foundation", "1 Yard of Concrete");
            string priceForTest2 = GetThePriceOfCatalogElement("Test 1");
            PackageElement.ClickSaveButton();
            PackageElement.ClickMainSaveButton();

            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickPackages();

            VerifyOptionInBundle(priceForTest1, priceForTest2, "Make Bundle", "Bundle", "Option", "Test");
            VerifyOptionInBundle(priceForTest1, priceForTest2, "Make Option", "Option", "Option", null);
        }

        [Test, Order(2)]
        public void Delete()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete");
            HomePage.NavigateToPackagePagesForPostFrame();
            DeleteElementAfterTestOrderOneCompleted();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Options from Packages price is incorrect Script");
        }

        #region private Methods
        private void VerifyOptionInBundle(string priceForTest1, string priceForTest2, string optionType, string itemName1, string itemName2, string checkForMaterial)
        {
            DefaultJobElement.CheckBundleCheckbox("Group 1\r\nTest 1\r\nTest 2");
            DefaultJobElement.SelectBundleAndOption(optionType);
            DefaultJobElement.ClickSyncButton();

            if(!string.IsNullOrEmpty(checkForMaterial))
            {
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                DefaultJobElement.ClickJobReview();
            }
            else
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
            }

            string elementXPath = $"(//div[text()='{itemName1} - Group 1--Test 1']//following :: td[@col='3']//div)[1]";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath(elementXPath)));
            string itemForTest1 = CommonMethod.element.Text;

            elementXPath = $"(//div[text()='{itemName2} - Group 1--Test 2']//following :: td[@col='3']//div)[1]";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath(elementXPath)));
            string itemForTest2 = CommonMethod.element.Text;

            string successMessage = $"Verify that if the “{optionType}” is selected into a Bundle then the price shows up correctly.";
            string failureMessage = $"Verify that if the “{optionType}” is selected into a Bundle then the price shows up incorrectly.";

            if ((priceForTest1 == itemForTest1) && (priceForTest2 == itemForTest2))
            {
                ExtentTestManager.TestSteps($"{successMessage} {priceForTest1} == {itemForTest1} && {priceForTest2} == {itemForTest2}");
                Console.WriteLine($"{successMessage} {priceForTest1} == {itemForTest1} && {priceForTest2} == {itemForTest2}");
            }
            else
            {
                ExtentTestManager.TestSteps($"{failureMessage} {priceForTest1} == {itemForTest1} && {priceForTest2} == {itemForTest2}");
                Console.WriteLine($"{failureMessage} {priceForTest1} == {itemForTest1} && {priceForTest2} == {itemForTest2}");
                Assert.Fail($"{failureMessage} {priceForTest1} == {itemForTest1} && {priceForTest2} == {itemForTest2}");
            }
        }

        private static string GetThePriceOfCatalogElement(string packageName)
        {
            CommonMethod.Wait(1);
            string elementText = PackageElement.GetThePriceValue();
            Console.WriteLine($"The Price Of Catalog Items For {packageName} Is {elementText}");
            return elementText;
        }

        private void CreatePackageMethod(string groupName, string packageName, string packageType, string catalogCategory, string outputCategory, string catalogItem)
        {
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.GroupNameInputField(groupName);
            PackageElement.PackageNameInputField(packageName);
            PackageElement.SelectPackageType(packageType);
            PackageElement.ClickAddCatalogButton();
            PackageElement.SelectOutputCategory(catalogCategory);
            PackageElement.SelectCatalogCategory(outputCategory);
            PackageElement.SelectCatalogItem(catalogItem);
        }

        private void DeleteElementAfterTestOrderOneCompleted()
        {
            for (int k = 1; k <= 2; k++)
            {
                PackageElement.DeleteDataFromPackageTable($"Group 1 (Test {k})");
            }

            PackageElement.ClickMainSaveButton();
        }

        private void CheckOldDataShownInTheTableThenDeletedAndNavigateToPackage()
        {
            for (int k = 1; k <= 2; k++)
            {
                bool result = PackageElement.DeleteDataFromPackageTable($"Group 1 (Test {k})");

                if (result == true && k.Equals(2))
                {
                    PackageElement.ClickMainSaveButton();
                    HomePage.NavigateToPackagePagesForPostFrame();
                }
            }
        }
    }
}
#endregion