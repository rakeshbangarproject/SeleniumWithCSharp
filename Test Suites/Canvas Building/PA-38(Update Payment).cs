using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    class UpdatedPayment : BaseClass
    {
        string getSummaryData = "//tr[contains(@id,'grid_SummaryGrid_rec_')]//td[@col='{0}']//div[text()='{1}']";

        [Test]
        public void PaymentSchedules()
        {
            LoginApplicationAndChangesDistributor("Updated Payment(Test case = 1");
            HomePage.NavigateToPaymentSchedulePage();

            string start = PaymentSchedule.GetTheValueFromPaymentScheduleTable(0, 1);
            string percentForStart = PaymentSchedule.GetTheValueFromPaymentScheduleTable(1, 1);
            Console.WriteLine("Payment Schedule table data:-\n" + $"First row of data: {start} {percentForStart}");
            ExtentTestManager.TestSteps("Payment Schedule table data:-\n" + $"First row of data: {start} {percentForStart}");
            string onDelivery = PaymentSchedule.GetTheValueFromPaymentScheduleTable(0, 2);
            string percentForOnDelivery = PaymentSchedule.GetTheValueFromPaymentScheduleTable(1, 2);
            ExtentTestManager.TestSteps($"Second row of data: {onDelivery} {percentForOnDelivery}");
            Console.WriteLine($"Second row of data: {onDelivery} {percentForOnDelivery}");
            string remainingTotal = PaymentSchedule.GetTheValueFromPaymentScheduleTable(0, 3);
            string percentForRemainingTotal = PaymentSchedule.GetTheValueFromPaymentScheduleTable(1, 3);
            Console.WriteLine($"Third row of data: {remainingTotal} {percentForRemainingTotal}");
            ExtentTestManager.TestSteps($"Third row of data: {remainingTotal} {percentForRemainingTotal}");
            ExtentTestManager.TestSteps("Get the Values stored in the payment schedule");

            HomePage.ClicksHomeButton();
            HomePage.ClicksStartFromScratch();
            Console.WriteLine("Start From Scratch:-");
            DefaultJobElement.ClickJobReview();

            string startForStartFromScratch = GetTheValueFromSummaryTable(1, start);
            string percentForStartFromScratch = GetTheValueFromSummaryTable(2, percentForStart);
            string onDeliveryForStartFromScratch = GetTheValueFromSummaryTable(1, onDelivery);
            string precentorDeliveryForStartFromScratch = GetTheValueFromSummaryTable(2, percentForOnDelivery);
            string remainingTotalForStartFromScratch = GetTheValueFromSummaryTable(1, remainingTotal);
            string percentForRemainingTotalForStartFromScratch = GetTheValueFromSummaryTable(2, percentForRemainingTotal);
            CompareValues(start, startForStartFromScratch, percentForStart, percentForStartFromScratch);
            CompareValues(onDelivery, onDeliveryForStartFromScratch, percentForOnDelivery, precentorDeliveryForStartFromScratch);
            CompareValues(remainingTotal, remainingTotalForStartFromScratch, percentForRemainingTotal, percentForRemainingTotalForStartFromScratch);

            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            Console.WriteLine("Smoke20x20x10:-");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string startForSmoke20x20x10 = GetTheValueFromSummaryTable(1, start);
            string percentForSmoke20x20x10 = GetTheValueFromSummaryTable(2, percentForStart);
            string onDeliveryForSmoke20x20x10 = GetTheValueFromSummaryTable(1, onDelivery);
            string precentorDeliveryForSmoke20x20x10 = GetTheValueFromSummaryTable(2, percentForOnDelivery);
            string remainingTotalForSmoke20x20x10 = GetTheValueFromSummaryTable(1, remainingTotal);
            string percentForRemainingTotalForSmoke20x20x10 = GetTheValueFromSummaryTable(2, percentForRemainingTotal);

            CompareValues(start, startForSmoke20x20x10, percentForStart, percentForSmoke20x20x10);
            CompareValues(onDelivery, onDeliveryForSmoke20x20x10, percentForOnDelivery, precentorDeliveryForSmoke20x20x10);
            CompareValues(remainingTotal, remainingTotalForSmoke20x20x10, percentForRemainingTotal, percentForRemainingTotalForSmoke20x20x10);
            ExtentTestManager.TestSteps("Verify that the values that are stored in payment Schedules are shown to the user ");
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToPaymentSchedulePage();
            PaymentSchedule.EnterDataInThePaymentScheduleField(0, 2, "30% On Delivery");
            PaymentSchedule.EnterDataInThePaymentScheduleField(1, 2, "30");
            string defaultValueStart = PaymentSchedule.GetTheValueFromPaymentScheduleTable(0, 2);
            string percentForDefaultValueStart = PaymentSchedule.GetTheValueFromPaymentScheduleTable(1, 2);
            string percentForRemainingTotal1 = PaymentSchedule.GetTheValueFromPaymentScheduleTable(1, 3);
            Console.WriteLine($"Payment Schedule For Default Value:- {defaultValueStart} {percentForDefaultValueStart}");
            ExtentTestManager.TestSteps($"Payment Schedule For Default Value:- {defaultValueStart} {percentForDefaultValueStart}");
            ExtentTestManager.TestSteps("Get the Values stored in the payment schedule");
            PaymentSchedule.ClickSaveButton();
            HomePage.ClicksStartFromScratch();
            Console.WriteLine("Start From Scratch:-");
            DefaultJobElement.ClickJobReview();

            string startForAgainCheck = GetTheValueFromSummaryTable(1, start);
            string percentForAgainCheck = GetTheValueFromSummaryTable(2, percentForStart);
            string onDeliveryForAgainCheck = GetTheValueFromSummaryTable(1, defaultValueStart);
            string precentorDeliveryForAgainCheck = GetTheValueFromSummaryTable(2, percentForDefaultValueStart);
            string remainingTotalForAgainCheck = GetTheValueFromSummaryTable(1, remainingTotal);
            string percentForRemainingTotalForAgainCheck = GetTheValueFromSummaryTable(2, percentForRemainingTotal1);

            CompareValues(start, startForAgainCheck, percentForStart, percentForAgainCheck);
            CompareValues(defaultValueStart, onDeliveryForAgainCheck, percentForDefaultValueStart, precentorDeliveryForAgainCheck);
            CompareValues(remainingTotal, remainingTotalForAgainCheck, percentForRemainingTotal1, percentForRemainingTotalForAgainCheck);

            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            Console.WriteLine("Smoke20x20x10:-");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();

            string startForSmoke20x20x10Again = GetTheValueFromSummaryTable(1, start);
            string percentForSmoke20x20x10Again = GetTheValueFromSummaryTable(2, percentForStart);
            string onDeliveryForSmoke20x20x10Again = GetTheValueFromSummaryTable(1, defaultValueStart);
            string percentonDeliveryForSmoke20x20x10Again = GetTheValueFromSummaryTable(2, percentForDefaultValueStart);
            string remainingTotalForSmoke20x20x10Again = GetTheValueFromSummaryTable(1, remainingTotal);
            string percentForRemainingTotalForSmoke20x20x10Again = GetTheValueFromSummaryTable(2, percentForRemainingTotal1);

            CompareValues(start, startForSmoke20x20x10Again, percentForStart, percentForSmoke20x20x10Again);
            CompareValues(defaultValueStart, onDeliveryForSmoke20x20x10Again, percentForDefaultValueStart, percentonDeliveryForSmoke20x20x10Again);
            CompareValues(remainingTotal, remainingTotalForSmoke20x20x10Again, percentForRemainingTotal1, percentForRemainingTotalForSmoke20x20x10Again);
            ExtentTestManager.TestSteps("Verify that the values that are stored in payment Schedules are shown to the user ");

            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToPaymentSchedulePage();
            PaymentSchedule.EnterDataInThePaymentScheduleField(0, 2, "25% On Delivery");
            PaymentSchedule.EnterDataInThePaymentScheduleField(1, 2, "25");
            PaymentSchedule.ClickSaveButton();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Updated Payment Script");
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

        private string GetTheValueFromSummaryTable(int pointA, string pointB)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(getSummaryData, pointA, pointB))));
            string getValue = CommonMethod.element.Text;
            return getValue;
        }

        private void CompareValues(string payment, string startFromScratch, string percentForStart, string percentForStartFromScratch)
        {
            Assert.AreEqual(payment, startFromScratch, $"Payment values are different: {payment} != {startFromScratch}");
            Assert.AreEqual(percentForStart, percentForStartFromScratch, $"Percentage values are different: {percentForStart} != {percentForStartFromScratch}");
            Console.WriteLine($"Both values are the same: {payment} {percentForStart} == {startFromScratch} {percentForStartFromScratch}");
            ExtentTestManager.TestSteps($"Both values are the same: {payment} {percentForStart} == {startFromScratch} {percentForStartFromScratch}");
        }
    }
}
#endregion