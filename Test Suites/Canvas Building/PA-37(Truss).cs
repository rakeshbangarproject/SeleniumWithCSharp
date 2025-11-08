using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    public class Truss : BaseClass
    {
        [Test]
        public void AddTruss()
        {
            LoginApplicationAndChangesDistributor("Uncheck the TaaS Config");
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("Autotest_PHTest");
            Distributor.UncheckCheckbox(12);
            Console.WriteLine("uncheck the 'TaaS Config' checkbox");
            ExtentTestManager.TestSteps("uncheck the Can Customize checkbox");
            Distributor.ClickSaveButton();

            FlatTruss();
            ScissorTruss();
            AtticTruss();
            ParallelChord();

            TrussesElement.DeleteDataFromTrussesTable("Flat Truss");
            TrussesElement.DeleteDataFromTrussesTable("Scissor Truss Sku");
            TrussesElement.DeleteDataFromTrussesTable("Attic Truss Sku");
            TrussesElement.DeleteDataFromTrussesTable("Parallel Chord Truss Sku");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Truss Data Script");
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

        private void FlatTruss()
        {
            ExtentTestManager.CreateTest("Add Truss(Test case = 1").Info("Flat Truss");
            HomePage.NavigateToTrusses();
            TrussesElement.DeleteDataFromTrussesTable("Flat Truss");
            TrussesElement.DeleteDataFromTrussesTable("Scissor Truss Sku");
            TrussesElement.DeleteDataFromTrussesTable("Attic Truss Sku");
            TrussesElement.DeleteDataFromTrussesTable("Parallel Chord Truss Sku");
            TrussesElement.ClickAddButton();
            TrussesElement.SearchInputField("Flat Truss");
            TrussesElement.EnterSKUInputField("Flat Truss");
            TrussesElement.EnterDescriptionInputField("Flat Truss");
            FieldDetails();
            TrussesElement.SelectSpecialFlags("Flat");
            string result = CheckEnableElement();
            Assert.That(result, Is.EqualTo("Verify that Depth, bottom Slop, Left base, and right base fields are disabled"));
            ExtentTestManager.TestSteps("Verify that Depth, bottom Slop, Left base, and right base fields are disabled");
            TrussesElement.ClickSaveButton();
        }

        private void ScissorTruss()
        {
            ExtentTestManager.TestSteps("Add Truss(Test case = 2").Info("Scissor Truss");
            CommonMethod.Wait(2);
            TrussesElement.ClickAddButton();
            CommonMethod.Wait(2);
            TrussesElement.EnterSKUInputField("Scissor Truss Sku");
            TrussesElement.EnterDescriptionInputField("Scissor Truss");
            CommonMethod.Wait(2);
            FieldDetails();
            TrussesElement.SelectSpecialFlags("Scissor");
            CommonMethod.Wait(2);
            string result = CheckEnableElement();
            Assert.That(result, Is.EqualTo("Verify that Left Base, Right Base and the Bottom slop field are editable and Depth is disabled"));
            ExtentTestManager.TestSteps("Verify that Left Base, Right Base and the Bottom slop field are editable and Depth is disabled");
            TrussesElement.ClickSaveButton();
        }

        private void AtticTruss()
        {
            ExtentTestManager.TestSteps("Add Truss(Test case = 3").Info("Attic Truss");
            CommonMethod.Wait(2);
            TrussesElement.ClickAddButton();
            CommonMethod.Wait(2);
            TrussesElement.EnterSKUInputField("Attic Truss Sku");
            TrussesElement.EnterDescriptionInputField("Attic Truss");
            FieldDetails();
            CommonMethod.Wait(2);
            TrussesElement.SelectSpecialFlags("Attic");
            string result = CheckEnableElement();
            Assert.That(result, Is.EqualTo("Verify that Depth, bottom Slop, Left base, and right base fields are disabled"));
            ExtentTestManager.TestSteps("Verify that Depth, bottom Slop, Left base, and right base fields are disabled");
            TrussesElement.ClickSaveButton();
        }

        private void ParallelChord()
        {
            ExtentTestManager.TestSteps("Add Truss(Test case = 4").Info("Parallel Chord");
            CommonMethod.Wait(2);
            TrussesElement.ClickAddButton();
            CommonMethod.Wait(2);
            TrussesElement.EnterSKUInputField("Parallel Chord Truss Sku");
            TrussesElement.EnterDescriptionInputField("Parallel Chord");
            CommonMethod.Wait(2);
            FieldDetails();
            CommonMethod.Wait(2);
            TrussesElement.SelectSpecialFlags("Parallel Chord");
            string result = CheckEnableElement();
            Assert.That(result, Is.EqualTo("Verify that Depth, Left Base, Right Base fields are editable and Bottom slop is disabled"));
            ExtentTestManager.TestSteps("Verify that Depth, Left Base, Right Base fields are editable and Bottom slop is disabled");
            TrussesElement.ClickSaveButton();
        }

        private void FieldDetails()
        {
            TrussesElement.SelectTCStyle("Common");
            TrussesElement.EnterSpanInputField("30");
            TrussesElement.EnterDim2InputField("15");
            TrussesElement.EnterPitch1InputField("7.5");
            TrussesElement.EnterHeelInputField("0'7");
            TrussesElement.EnterMinOHLInputField("1");
            TrussesElement.EnterMaxOHLInputField("1");
            TrussesElement.EnterMinSpacingInputField("4");
            TrussesElement.EnterMaxSpacingInputField("4");
            TrussesElement.EnterLoadingInputField("20-10-10");
            TrussesElement.SelectMaterial("Wood");
        }

        private string CheckEnableElement()
        {
            try
            {
                IWebElement depth = Driver.FindElement(By.XPath("//input[@id='DepthStr']"));
                IWebElement bottomSlop = Driver.FindElement(By.XPath("//input[@id='BCPitch']"));
                IWebElement leftBase = Driver.FindElement(By.XPath("//input[@id='LeftBaseStr']"));
                IWebElement rightBase = Driver.FindElement(By.XPath("//input[@id='RightBaseStr']"));

                if (!depth.Enabled && !bottomSlop.Enabled && !leftBase.Enabled && !rightBase.Enabled)
                {
                    return "Verify that Depth, bottom Slop, Left base, and right base fields are disabled";
                }
                else if (depth.Enabled && bottomSlop.Enabled && leftBase.Enabled)
                {
                    return "Verify that the Depth, Bottom Slop, Left Base fields are editable and  Right Base field is disabled";
                }
                else if (depth.Enabled && bottomSlop.Enabled && rightBase.Enabled)
                {
                    return "Verify that Depth, Right Base Bottom slop fields are editable and Left Base is disabled";
                }
                else if (depth.Enabled && leftBase.Enabled && rightBase.Enabled)
                {
                    return "Verify that Depth, Left Base, Right Base fields are editable and Bottom slop is disabled";
                }
                else if (bottomSlop.Enabled && leftBase.Enabled && rightBase.Enabled)
                {
                    return "Verify that Left Base, Right Base and the Bottom slop field are editable and Depth is disabled";
                }
            }
            catch (NoSuchElementException)
            {
                return "Element not found";
            }
            catch (Exception ex)
            {
                return $"An unexpected error occurred: {ex.Message}";
            }

            return "Conditions not met";
        }
    }
}
#endregion