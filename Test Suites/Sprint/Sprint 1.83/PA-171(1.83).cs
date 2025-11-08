using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint_1._83")]
    public class Overhangs : BaseClass
    {
        /// <summary>
        ///  Navigate to Default job and click on the Building Size.
        ///  Add the Top of wall material from the Roof Height Style dropdown
        ///  Enter the 12' in the Exterior metal height and click on the drawing tab
        ///  Click on the EXT-1 of sheathing drawing and verify exterior wall length is 12 or not
        ///  Select 3' from the overhangs dropdown and verify the exterior wall length is still shown as 12'
        ///  Select None' from the overhangs dropdown and verify the exterior wall length is still shown as 12'
        /// </summary>

        [Test]
        public void ExteriorHeight()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Exterior metal height");    
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            DefaultJobElement.ExteriorMetalHeightInputField("12'");
            DefaultJobElement.ClickWainscot();
            DefaultJobElement.CheckHasWainscotCheckbox();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            VerifyExteriorWall();
            Console.WriteLine("Verify that the Exterior Wall Material length is matched with  Exterior metal height");
            ExtentTestManager.TestSteps("Verify that the Exterior Wall Material length is matched with  Exterior metal height");

            ChangeOverhangFrom3DView("3'");
            VerifyExteriorWall();
            Console.WriteLine("Verify that the Exterior Wall Material length is still shown as 12' after applying the Overhang is 3");
            ExtentTestManager.TestSteps("Verify that the Exterior Wall Material length is still shown as 12' after applying the Overhang is 3'");
            ChangeOverhangFrom3DView("None");
            VerifyExteriorWall();
            Console.WriteLine("Verify that the Exterior Wall Material length is still shown as 12' after applying Overhang is None'");
            ExtentTestManager.TestSteps("Verify that the Exterior Wall Material length is still shown as 12' after applying Overhang is None'");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Exterior metal height Script");
        }

        #region Private Methods
        /// <summary>
        /// Verify that the Exterior Wall length is 12 or not'
        /// </summary>
        private void VerifyExteriorWall()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.SheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", null, null, null, "12'");  
        }

        private void ChangeOverhangFrom3DView(string overhang)
        {
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial(overhang);
            DefaultJobElement.ChangeViewLeftElevation();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }        
    }
}
#endregion