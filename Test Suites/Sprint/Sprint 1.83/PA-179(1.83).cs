using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class TrussMaterialOFCatalogData : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-178");

        [Test]
        public void TrussCarrier()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Trachte-The catalog based on a range of spacings");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            AddTrussMaterial();
            NavigateToTrussesPageForT1();
            NavigateToTrussesPageForL1();
            VerifyMinSpacingInDefaultJob();
            DeleteTrussesMaterials();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Trachte - The catalog based on a range of spacings Script");
        }

        #region Private Method
        private void DeleteTrussesMaterials()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            TrussesElement.DeleteDataFromTrussesTable("C30P4HH7SP12L20-10-10GB");
            TrussesElement.DeleteDataFromTrussesTable("C30P4HH7SP12L20-10-10");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        private void VerifyMinSpacingInDefaultJob()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            VerifyMaterialError();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            VerifyMaterialError();
            ExtentTestManager.TestSteps("Verified that if the truss is outside the valid spacing range then the program shows an error of not an exact match.");
            Console.WriteLine("Verified that if the truss is outside the valid spacing range then\n" + "the program shows an error of not an exact match.");
        }

        private void VerifyMaterialError()
        {
            // Verify that trusses material is change in the default job  
            string checkFroT_1 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.checkNotMatchTextShown, "T-1")))).Text;
            Assert.True(checkFroT_1.Contains("NOT AN EXACT MATCH *"));

            string checkFroL_1 = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.checkNotMatchTextShown, "L-1")))).Text;
            Assert.True(checkFroL_1.Contains("NOT AN EXACT MATCH *"));
        }

        private void NavigateToTrussesPageForL1()
        {
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            OpenTrussElementAndChangeMaxMinValues("C30P4HH7SP12L20-10-10GB");
        }

        private void NavigateToTrussesPageForT1()
        {
            OpenNewWindowAndNavigateToTrussPage();
            OpenTrussElementAndChangeMaxMinValues("C30P4HH7SP12L20-10-10");
        }

        private void OpenTrussElementAndChangeMaxMinValues(string elementName)
        {
            TrussesElement.SearchInputField(elementName);
            CommonMethod.Wait(2);
            TrussesElement.ClickFirstElementOfTrussesTable(elementName);
            ExtentTestManager.TestSteps($"Verify that the {elementName} is existed in the trusses table");
            Console.WriteLine($"Verify that the {elementName} is existed in the trusses table");
            ChangeMinSpacing();
        }

        private void ChangeMinSpacing()
        {
            // Change the Min Spacing value from Truss Material Data
            TrussesElement.MinSpacingInputFields("8");
            ExtentTestManager.TestSteps("Change the Minimum Spacing value from Truss Material Data");

            // Change the Min Spacing value from Truss Material Data
            TrussesElement.MaxSpacingInputFields("8");
            ExtentTestManager.TestSteps("Change the Maximum Spacing value from Truss Material Data");

            // Click on the create new material of Truss material
            TrussesElement.ClickSaveButton();
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        private void AddTrussMaterial()
        {
            // Start from scratch and navigate to Truss Descriptions
            HomePage.ClicksStartFromScratch();
            OpenNewWindowAndNavigateToTrussPage();

            // Check old data shown on the trusses table then deleted.
            TrussesElement.DeleteDataFromTrussesTable("C30P4HH7SP12L20-10-10GB");
            TrussesElement.DeleteDataFromTrussesTable("C30P4HH7SP12L20-10-10");
            CloseAdditionalWindow();

            // Switch back to the main window and continue with 3D view
            SwitchToMainWindow();
            CommonMethod.Wait(3);
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CommonMethod.Wait(3);
            ApplyBaysOnCanvasBuilding();

            // Click on L-1 button and change its name
            ClickOnL1Button();
            ChangeNameForL1();

            // Click on the info button for T-1 and change its name
            ClickInfoButtonForT1();
            ChangeNameForT1();
        }

        private void OpenNewWindowAndNavigateToTrussPage()
        {
            // Open new window and navigate to truss page
            Driver.SwitchTo().NewWindow(WindowType.Tab);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("TrussPageURL"));
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        private void CloseAdditionalWindow()
        {
            Driver.Close();
            SwitchToMainWindow();
        }

        private void SwitchToMainWindow()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
        }

        private void ClickInfoButtonForT1()
        {
            // Click on the info button associated with T-1
            DefaultJobElement.ClickFixTrussesButtonOfTrussesTable("T-1");
        }

        private void ClickOnL1Button()
        {
            // Click on the i button of L-1
            DefaultJobElement.ClickFixTrussesButtonOfTrussesTable("L-1");
        }

        private void ChangeTrussName(string name)
        {
            // Change Sku name 
            string skuName = DefaultJobElement.GetTheSKUInputFieldOfFixTruss();

            if (skuName.Equals(name))
            {
                DefaultJobElement.ClickAddToTrussTableButton();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            }
            else
            {
                DefaultJobElement.SKUInputFieldOfFixTruss(name);
                DefaultJobElement.ClickAddToTrussTableButton();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            }
        }

        private void ChangeNameForT1()
        {
            ChangeTrussName("C30P4HH7SP12L20-10-10");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        private void ChangeNameForL1()
        {
            ChangeTrussName("C30P4HH7SP12L20-10-10GB");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }

        private void ApplyBaysOnCanvasBuilding()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBays();
            DefaultJobElement.CheckUseBaysSpacingCheckbox();
            DefaultJobElement.SelectBaySpacing("12'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrussesOfJobReview();
        }
    }
}
#endregion