using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Canvas")]
    public class GablePost : BaseClass
    {

        [Test]
        public void Gable()
        {
            LoginApplicationAndChangesDistributor("Gable post spacing issue");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.WidthInputField("50");
            DefaultJobElement.LengthInputField("30");
            DefaultJobElement.CeilingHeightInputField("6");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectGablePostSpacingDropdown("10'");
            DefaultJobElement.SelectGablePostPlacementDropdown("Even");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();

            string postQuantityBeforeChanges = GetThePostQty();
            Console.WriteLine($"Get Post quantity before changes {postQuantityBeforeChanges}\n");
            ExtentTestManager.TestSteps($"Get Post quantity before changes {postQuantityBeforeChanges}");

            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.RoofPitchInputField("3");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));

            string postQuantityAfterChanges = GetThePostQty();
            Console.WriteLine($"Get Post quantity after changes {postQuantityAfterChanges}\n");
            ExtentTestManager.TestSteps($"Get Post quantity after changes {postQuantityAfterChanges}");
            Assert.That(postQuantityBeforeChanges, Is.EqualTo(postQuantityAfterChanges));
            Console.WriteLine($"Verify that Post Quantity is the same as we get earlier: {postQuantityBeforeChanges} == {postQuantityAfterChanges}");
            ExtentTestManager.TestSteps($"Verify that Post Quantity is the same as we get earlier: {postQuantityBeforeChanges} == {postQuantityAfterChanges}");

            string[] std = new string[8] { "8", "10", "12", "13", "14", "15", "16", "18" };
            for (int i = 0; i <= 7; i++)
            {
                DefaultJobElement.CeilingHeightInputField(std[i]);
                Console.WriteLine($"Ceiling Height is {std[i]}");
                ExtentTestManager.TestSteps($"Ceiling Height is {std[i]}");
                DefaultJobElement.RoofPitchInputField("4");
                CeilingHeight();
            }
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Gable post spacing issue Script");
        }

        #region Private Method
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

        private string GetThePostQty()
        {
            // Get Post Quantity
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='Post']//following :: td[@col='6']/div)[1]")));
            string postQty = CommonMethod.element.Text;
            return postQty;
        }

        public void CeilingHeight()
        {
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));

            string postQuantityBeforeChanges = GetThePostQty();
            ExtentTestManager.TestSteps("Get Post Quantity");
            DefaultJobElement.RoofPitchInputField("3");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));

            string postQuantityAfterChanges = GetThePostQty();
            ExtentTestManager.TestSteps("Get Post Quantity");
            Assert.That(postQuantityBeforeChanges, Is.EqualTo(postQuantityAfterChanges));
            Console.WriteLine($"Verify that Post Quantity are same: {postQuantityBeforeChanges} == {postQuantityAfterChanges}");
            ExtentTestManager.TestSteps($"Verify that Post Quantity are same: {postQuantityBeforeChanges} == {postQuantityAfterChanges}");
        }
    }
}
#endregion