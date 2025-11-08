using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Roofing_Passport")]
    public class ZombieParts : BaseClass
    {
        [Test, Order(1)]
        public void ReflectPanelLength()
        {
            ExtentTestManager.CreateTest("Zombie Parts keep returning to the Materials List after they have been deleted");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();

            MiscData();
            CatalogData();

            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();
            string trimTableData = VerifyDataAddedInTheTrimTable();
            Assert.That(trimTableData, Is.EqualTo("Verify that the new Catalog and Usage material are shown on the Trim table"));
            DeleteTrimDataFromJobReview("Testing Catalog Element");
            DeleteTrimDataFromJobReview("Testing Usage Misc Element");
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickJobListButton();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();

            string trimTableData1 = VerifyDataAddedInTheTrimTable();
            Assert.That(trimTableData1, Is.EqualTo("Verify that the new material is not shown on the Trim table"));
            ExtentTestManager.TestSteps("Verify that the newly created Catalog item is deleted from the trim table.");
            Console.WriteLine("Verify that the newly created Catalog item is deleted from the trim table.");
            ExtentTestManager.TestSteps("Verify that the newly created Catalog item is deleted from the trim table.");
            Console.WriteLine("Verify that the newly created Misc item is deleted from the trim table.");
            DefaultJobElement.NavigateToHomePage();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Zombie Parts keep returning to the Materials List after they have been deleted");
        }

        #region Private Method
        private string VerifyDataAddedInTheTrimTable()
        {
            try
            {
                Driver.FindElement(By.XPath("//div[text()='Testing Catalog Element']")).Click();
                CommonMethod.Wait(2);
                Driver.FindElement(By.XPath("//div[text()='Testing Usage Misc Element']")).Click();
                CommonMethod.Wait(2);
                ExtentTestManager.TestSteps($"Verify that the new Catalog and Usage material are shown on the Trim table");
                return "Verify that the new Catalog and Usage material are shown on the Trim table";
            }
            catch (Exception)
            {
                return "Verify that the new material is not shown on the Trim table";
            }
        }

        private void DeleteTrimDataFromJobReview(string name)
        {
            string xpathOfRow = "//div[text()='{0}']";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(xpathOfRow, name))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Delete']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space()='Delete Confirmation']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Yes']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            CommonMethod.Wait(5);
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(text(),'Add Catalog')]")));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(5)).Perform();
            ExtentTestManager.TestSteps($"Delete the new {name} material from the Trim table");
        }

        private void MiscAndCatalogButton(string nameOfElement)
        {
            string elementXPath = "(//td[contains(text(),'{0}')])[1]";
          
            try
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, nameOfElement))));
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Perform();
            }
            catch(StaleElementReferenceException)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(elementXPath, nameOfElement))));
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CommonMethod.element).Perform();
            }
            ExtentTestManager.TestSteps($"Click on the {nameOfElement} button");
        }

        private void CatalogData()
        {
            MiscAndCatalogButton("Add Catalog");
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[contains(@id,'Usage')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys("Testing Catalog Element").Build().Perform();
            ExtentTestManager.TestSteps("Enter the data in the usage field of Catalog pop-up");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[contains(@id,'Save')])[1]"))).Click();
            ExtentTestManager.TestSteps("Click on the Save button of Catalog pop-up");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[contains(text(),'Add Catalog')]")));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(5)).Perform();
        }

        private void MiscData()
        {
            MiscAndCatalogButton("Add Misc");
            FillMiscPopUpFields();
        }

        private void FillMiscPopUpFields()
        {
            FillTextField("(//input[contains(@id,'Usage')])[1]", "Testing Usage Misc Element", "Enter the data in the usage field of Misc pop-up");
            FillTextField("(//input[contains(@id,'Sku')])[1]", "Testing Sku Misc Element", "Enter the data in the Sku field of Misc pop-up");
            FillTextField("//label[contains(text(),'Material')]//following :: input[1]", "Testing Material Misc Element", "Enter the data in the Material field of Misc pop-up");
            FillTextField("//label[contains(text(),'Material')]//following :: input[2]", "55", "Enter the data in the Cost field of Misc pop-up");
            FillTextField("//label[contains(text(),'Material')]//following :: input[3]", "45", "Enter the data in the price field of Misc pop-up");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Calculation')]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[contains(@id,'Save')])[1]"))).Click();
            ExtentTestManager.TestSteps("Click on the Save button of Catalog pop-up");

            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(5)).Perform();
        }

        private void FillTextField(string xpath, string text, string testStep)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().SendKeys(text).Build().Perform();
            ExtentTestManager.TestSteps(testStep);
        }

    }
}
#endregion