using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{
    [TestFixture, Category("Smoke_test")]
    public class TestATB : BaseClass
    {
        public string folderPath = FolderPath.Download();
        private List<string> text = new List<string>();
        private IList<IWebElement> posts;

        [Test]
        public void TestAttachedBuilding()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("HOT PATCH - Open wall gets filled with post");

            HomePage.ClicksStartFromScratch();
            ModifiedTheWidthAndLengthOfBuildingSize();
            ApplyBaysElements();
            AttachedBuildingOnTheFrontSide();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            VerifyPostsInTheDrawingPage();
            DefaultJobElement.ClickAssemblyDrawingEXT_3();
            VerifyPostsInTheDrawingPage();
            ExtentTestManager.TestSteps($"Verify that the attached building's portion of the wall does not contain any mid-span posts");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH - Open wall gets filled with post");
        }

        /// <summary>
        /// Click on the Attached Building tab and Enter data in the start and length fields
        /// Select Offset Down from the Height dropdown
        /// Check the advanced and Bays spacing 
        /// Attached canvas building on the front side
        /// </summary>
        private void AttachedBuildingOnTheFrontSide()
        {
            DefaultJobElement.ClickAttachedBuilding();
            DefaultJobElement.EnterStartInputFieldOption("0");
            DefaultJobElement.EnterLengthInputFieldOption("30");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.CheckAdvancedCheckboxOfOpening();
            DefaultJobElement.CheckUseBaySpacingCheckboxForOpening();

            SelectCustomFromBayPlacement();
            DefaultJobElement.ChangeViewFrontRight();
            DefaultJobElement.PlaceOpening(100, 100);
            DefaultJobElement.ClickCrossIcon();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        /// <summary>
        /// Click on the details tab and check use Bay Spacing checkbox
        /// Select materials from Bay spacing and Bay placement dropdowns
        /// </summary>
        private void ApplyBaysElements()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickBays();
            DefaultJobElement.CheckUseBaysSpacingCheckbox();
            DefaultJobElement.SelectBaySpacing("10'");
            DefaultJobElement.SelectBayPlacement("Front");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        /// <summary>
        /// Click on the Building size tab and Enter data in the width and length fields
        /// Select Outside of Post of measure from dropdown
        /// </summary>
        private void ModifiedTheWidthAndLengthOfBuildingSize()
        {
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            SelectElementToMeasureFromDropdown();
            DefaultJobElement.WidthInputField("30");
            DefaultJobElement.LengthInputField("30");
        }

        /// <summary>
        /// Select Outside of Post from measure from dropdown
        /// </summary>
        private void SelectElementToMeasureFromDropdown()
        {
            DefaultJobElement.SelectMeasureFromMaterial("Outside of Post");
        }

        /// <summary>
        /// Select Custom from Bay Placement dropdown
        /// When bay length field is visible then enter 12.125 value
        /// Click on the apply button
        /// </summary>
        private void SelectCustomFromBayPlacement()
        {
            DefaultJobElement.SelectBayPlacementFromOpening("Custom...");
            DefaultJobElement.EnterBayLengths("12.125");
        }

        /// <summary>
        /// Verify that the posts of wall is not more the 3 
        /// </summary>
        private void VerifyPostsInTheDrawingPage()
        {
            posts = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and descendant::div[text()='Post']]//td[@col='5']"));
            var count = posts.Count();

            for (int i = 0; i < count; i++)
            {
                string length = posts[i].Text;
                text.Add(length);
            }

            // Calculate sum of lengths
            int sum = 0;
            foreach (var length in text)
            {
                if (int.TryParse(length, out int value))
                {
                    sum += value;
                }
                else
                {
                    Assert.Fail("Failed to fetch data from quantity field");
                }
            }

            // Verify sum is less than 4
            Assert.That(sum, Is.LessThan(4), "Verify that the attached building's portion of the wall contains mid-span posts");

            // Clear data from lists
            text.Clear();
            posts = null;
        }
    }
}
