using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._97
{
    public class ValidatePostFramingMaterial : BaseClass
    {
        [Test]
        public void OffsetDownOnSheds()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Span table does not recognize Offset Down on Sheds");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.CeilingHeightInputField("20'");
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            DefaultJobElement.ExteriorMetalHeightInputField("20'");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickBays();
            DefaultJobElement.CheckUseBaysSpacingCheckbox();
            DefaultJobElement.SelectBaySpacing("12'");
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectPostMaterialDropdown("(Auto)");
            DefaultJobElement.SelectGableWallsStyleDropdown("Inset Gable");
            DefaultJobElement.ClickSyncButton();

            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickLeanTo();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.HeightInputFieldOption("16'");
            DefaultJobElement.CheckAdvancedCheckboxOfOpening();
            DefaultJobElement.SelectTrussSpecialDropdownOption("Parallel Chord Truss");
            DefaultJobElement.AtticRoomWidthOpeningInputField("0");
            DefaultJobElement.AtticRoomHeightOpeningInputField("0");
            ClickApplyButtonAndWaitForPageLoad();
            ClickDrawingTabAndSwitchToEXT_6AssemblyDrawing();

            string ifHeightDropdownIsSelectCeilingHeight = getPostMaterialName();
            ExtentTestManager.TestSteps($"Get the {ifHeightDropdownIsSelectCeilingHeight} post material value");

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.ClickChangeView();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.FrontLeft)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            DefaultJobElement.OpenPlaceOpening(60,60);
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            ClickApplyButtonAndWaitForPageLoad();
            ClickDrawingTabAndSwitchToEXT_6AssemblyDrawing();

            string ifHeightDropdownIsSelectOffsetDown = getPostMaterialName();
            Assert.AreEqual(ifHeightDropdownIsSelectOffsetDown, ifHeightDropdownIsSelectCeilingHeight, "Error: the Post-Material value is changed after modifying the Attached Building Height.");
            ExtentTestManager.TestSteps($"Verify that the Post-Material value remains unchanged after modifying the Attached Building Height.");
            Console.WriteLine($"Verify that the Post-Material value remains unchanged after modifying the Attached Building Height.");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Span table does not recognize Offset Down on Sheds");
        }

        private string getPostMaterialName()
        {
          return  GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and contains(@onclick,'dwgMaterialsGrid')]//div[text()='Post']//following::td[2]/div"))).Text;
        }

        private void ClickDrawingTabAndSwitchToEXT_6AssemblyDrawing()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_6();
        }

        private void ClickApplyButtonAndWaitForPageLoad()
        {
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }
    }   
}
