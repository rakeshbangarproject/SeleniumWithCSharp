using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class TrussAndPorchAligned : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-277");

        [Test]
        public void BaySpacingIssue()
        {
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Trusses and post are not aligned correctly for porch if bay spacing is applied");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClicksShellButton();
            CheckBayAligned(null, "WithoutDoubleTruss.png", "WithoutDoubleTrussPlanView.png");
            Driver.Navigate().Refresh();
            CommonMethod.PageLoader();
            ExtentTestManager.CreateTest("Case 2").Info("Open Default job");
            CheckBayAligned("Double Truss", "WithDoubleTruss.png", "WithDoubleTrussPlanView.png");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Trusses and post are not aligned correctly for porch if bay spacing is applied");
        }

        #region Private Method
        private void CheckBayAligned(string trussValue, string imagesName, string imagesName2)
        {
            ApplyBaysSpacingOnTheCanvasBuilding();
            AttachedPorchOnLeftSide(trussValue);
            DefaultJobElement.CaptureScreenShot(pathFile, imagesName);
            DefaultJobElement.ChangePlanView();
            DefaultJobElement.CaptureScreenShot(pathFile, imagesName2);
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_8();
            CheckTrussBlockMaterialForPorch(trussValue);
        }

        private static void ApplyBaysSpacingOnTheCanvasBuilding()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickBays();
            DefaultJobElement.CheckUseBaysSpacingCheckbox();
            DefaultJobElement.SelectBaySpacing("12'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void AttachedPorchOnLeftSide(string trussValue)
        {
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickLeft();

            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.SelectOverhangDropdownOfOpeningOption("1' 6\"");
            DefaultJobElement.CheckAdvancedCheckboxOfOpening();
            DefaultJobElement.CheckUseBaySpacingCheckboxForOpening();
            string baySpacing = DefaultJobElement.GetBaySpacingValueFromOpening();
            Assert.That(baySpacing, Is.EqualTo("12'"), $"{baySpacing} is not match with 12' in the opening after bay spacing checkbox is checked");
            DefaultJobElement.UncheckDoNotCombineWallsCheckboxForOpening();
            DefaultJobElement.SelectIncludeBackWallFromOpening("Yes");

            if (trussValue == "Double Truss" | trussValue != null)
            {
                DefaultJobElement.CheckDoubleTrussCheckboxForOpening();
            }

            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void CheckTrussBlockMaterialForPorch(string trussValue)
        {
            if (trussValue == "Double Truss" | trussValue != null)
            {
                DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TrussBlock", null, null, "6", null);
                Console.WriteLine("Verify that the Truss Block material disappears when the user applies a porch without a double truss porch.");
                ExtentTestManager.TestSteps("Verify that the Truss Block material disappears when the user applies a porch without a double truss porch.");
            }
            else
            {
                DefaultJobElement.CheckMaterialIsNotShownInTheDrawing("TrussBlock");
                Console.WriteLine("Verify that the Truss Block material appears when the user applies a porch with a double truss porch.");
                ExtentTestManager.TestSteps("Verify that the Truss Block material appears when the user applies a porch with a double truss porch.");
            }
        }
    }
}
#endregion