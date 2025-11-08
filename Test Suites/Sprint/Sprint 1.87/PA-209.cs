using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class HeaderHighTriple : BaseClass
    {
        [Test]
        public void TripleNotWorking()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Header High Triple and Quadruple not working");
            HomePage.ClicksStartFromScratch();
            VerifyDataOfTrussCarrierStyle();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Header High Triple and Quadruple not working");
        }

        #region Private Method
        private void VerifyDataOfTrussCarrierStyle()
        {
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ExtentTestManager.TestSteps("Open any wall from canvas building");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_3();
            DefaultJobElement.SelectTrussCarrierStyle("Triple");
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.Wait(4);
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TrussBearer", null, null, "3", "40'");
            ExtentTestManager.TestSteps($"Verify that  the TrussBearer quantity is 3' after selecting Triple from the Truss Carrier Style dropdown");
            Console.WriteLine("Verify that  the TrussBearer quantity is 3' after selecting Triple from the Truss Carrier Style dropdown");
            DefaultJobElement.SelectTrussCarrierStyle("Quadruple");
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TrussBearer", null, null, "4", "40'");
            ExtentTestManager.TestSteps($"Verify that  the TrussBearer quantity is 4' after selecting Quadruple from the Truss Carrier Style dropdown");
            Console.WriteLine("Verify that  the TrussBearer quantity is 4' after selecting Quadruple from the Truss Carrier Style dropdown");
        }
    }
}
#endregion