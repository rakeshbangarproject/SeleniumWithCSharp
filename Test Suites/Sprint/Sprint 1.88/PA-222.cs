using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Sprint_1._88
{
    [TestFixture, Category("Sprint_1._88")]
    public class RegressionTest : BaseClass
    {
        public string captureScreenShot = FolderPath.StoreCaptureImage("ScreenShot of PA-222");

        [Test]
        public void Overhang()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Overhang of main building is getting removed from one side");
            FolderPath.CreateFolder(captureScreenShot);
            CommonMethod.DeleteFolderFile(captureScreenShot);
            HomePage.ClicksStartFromScratch();
            CommonMethod.Wait(2);
            AttachedBuilding();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickEXT_2();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "EXT_1.png");
            DefaultJobElement.ClickEXT_4();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "EXT_2.png");
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickEXT_2();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "firstSideOfOverhang.png");
            DefaultJobElement.ClickEXT_4();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "SecondSideOfOverhang.png");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Overhang of main building is getting removed from one side");
        }

        #region Private Method
        private void AttachedBuilding()
        {
            DefaultJobElement.ClickAttachedBuilding();
            DefaultJobElement.EnterStartInputFieldOption("0");
            DefaultJobElement.EnterLengthInputFieldOption("40");
            DefaultJobElement.EnterWidthInputFieldOption("30");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            DefaultJobElement.SelectRoofOrientationDropdownOpeningOption("Rotated");
        }
    }
}
#endregion