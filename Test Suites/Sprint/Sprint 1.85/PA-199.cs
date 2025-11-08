using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._85
{
    [TestFixture, Category("Sprint_1_.85")]
    public class TrussesCarrierLocked : BaseClass
    {

        [Test]
        public void TrussesCarrierMaterial()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Truss Carrier inputs locked and mixed up");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            TrussCarrierDropdown();
            ExtentTestManager.TestSteps("For Double Element:");
            Console.WriteLine("For Double Element:");

            if (!DefaultJobElement.TrussCarrierStyle().Enabled)
            {
                Assert.Fail("Verify that the truss carrier style field is grayed out.");
            }

            ExtentTestManager.TestSteps("Verify that the truss carrier style field is not grayed out.");
            Console.WriteLine("Verify that the truss carrier style field is not grayed out.");

            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            DefaultJobElement.SelectTopGirtMaterial("None");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            Console.WriteLine("For Use Top Girt Element:");
            ExtentTestManager.TestSteps("For Use Top Girt Element:");
            if (!DefaultJobElement.TrussCarrierStyle().Enabled)
            {
                Assert.Fail("Verify that the truss carrier style field is grayed out.");
            }

            ExtentTestManager.TestSteps("Verify that the truss carrier style field is not grayed out.");
            Console.WriteLine("Verify that the truss carrier style field is not grayed out.");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add Category field input Script");
        }

        #region private method
        private void TrussCarrierDropdown()
        {
            DefaultJobElement.ClickTrussCarrier();
            CommonMethod.Wait(1);
            DefaultJobElement.SelectTrussCarrierStyle("Double");
            CommonMethod.Wait(1);
            DefaultJobElement.SelectTrussCarrierMaterial("(Auto)");
            CommonMethod.Wait(1);
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }
    }
}
#endregion