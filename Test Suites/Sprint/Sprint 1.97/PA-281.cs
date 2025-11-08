using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._97
{
    public class TrackBoard : BaseClass
    {
        [Test]
        public void ValidateTrackBoardData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Span table does not recognize Offset Down on Sheds");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.OpeningDoorsSelection("Slider");
            DefaultJobElement.SelectStandardStyle();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickDoorAndWindow();
            DefaultJobElement.ClickSliderDoorPostFraming();
            string trackBoardExtension = DefaultJobElement.GetTheTrackBoardExtensionMaterialName();
            Assert.That(trackBoardExtension.Equals("(match track board)"), "Error: the Track board extension material by default is not set as (match track board)");
            ExtentTestManager.TestSteps($"Verify that the Track board extension material by default is set as (match track board)");
            DefaultJobElement.SelectTrackBoardForSliderDoorPostFraming("2x6");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("TrackBoard", null, "2x6", "2", "5'");
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("TrackBoard", null, "2x6", "1", "10'");
            DefaultJobElement.SelectTrackBoardExtensionForSliderDoorPostFraming("2x4");
            DefaultJobElement.PageLoaderFor2D();

            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("TrackBoard", null, "2x4", "2", "5'");
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("TrackBoard", null, "2x6", "1", "10'");

            Driver.Navigate().Refresh();
            CommonMethod.HandleAlert();
            CommonMethod.PageLoader();

            DefaultJobElement.OpeningDoorsSelection("Slider");
            DefaultJobElement.SelectStandardStyle();
            DefaultJobElement.SelectSideSliderPopup("Right");
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();


        }

        private
    }
}
