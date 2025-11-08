using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class MatchPost : BaseClass
    {
        [Test]
        public void SetAuto()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Match Post is Broken with Auto");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("Overhead", "All", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(100, 150);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectPostMaterialDropdown("(Auto)");
            DefaultJobElement.ClickDoorAndWindow();
            DefaultJobElement.ClickOverheadDoorPostFraming();
            DefaultJobElement.SelectJambPostMaterial("(Match Post)");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("Post", null, "4Ply2x8", null, "21");
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("JambPost", null, "4Ply2x8", null, "21");
            ExtentTestManager.TestSteps("Verify that the overhead door's jamb post material matches the main post material. ");
            Console.WriteLine("Verify that the overhead door's jamb post material matches the main post material. ");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Match Post is Broken with Auto");
        }
    }
}
