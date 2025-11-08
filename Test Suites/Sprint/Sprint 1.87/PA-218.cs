using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class HeaderHighBoundaries : BaseClass
    {
       public string captureScreenShot = FolderPath.StoreCaptureImage("ScreenShot of PA-218");

        [Test]
        public void HeaderHighMaterial()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Header High boundaries");
            FolderPath.CreateFolder(captureScreenShot);
            CommonMethod.DeleteFolderFile(captureScreenShot);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.SelectOpeningDoor("Overhead", "Raised Panel", "10x10 OHD-no windows");
            DefaultJobElement.PlaceOpening(140, 90);
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClicksShellButton();
            DefaultJobElement.ClickDoorAndWindow();
            DefaultJobElement.ClickOverheadDoorPostFraming();
            DefaultJobElement.CheckHeaderHighCheckbox();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.SelectHeaderHighBoundariesMaterial("Inside of Post");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas","drawing2d", captureScreenShot, "Inside of PostScreenShot.png");
            Console.WriteLine("Verify that the Inside of post material is apply on the Canvas building");
            ExtentTestManager.TestSteps("Verify that the Inside of post material is apply on the Canvas building");

            DefaultJobElement.SelectHeaderHighBoundariesMaterial("Outside of Post");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "Outside of PostScreenShot.png");
            Console.WriteLine("Verify that the Outside of post material is apply on the Canvas building");
            ExtentTestManager.TestSteps("Verify that the Outside of post material is apply on the Canvas building");

            DefaultJobElement.SelectHeaderHighBoundariesMaterial("Next Column");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawing2d", captureScreenShot, "Next ColumnScreenShot.png");
            Console.WriteLine("Verify that the Next Column material is apply on the Canvas building");
            ExtentTestManager.TestSteps("Verify that the Next Column material is apply on the Canvas building");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Header High boundaries");
        }
    }
}
