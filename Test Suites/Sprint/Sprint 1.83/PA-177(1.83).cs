using Forms.Reporting;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Sprint")]
    public class OpenWallTrussCarries : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-177");

        [Test]
        public void TrussCarrier()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Trachte-Open Wall Truss Carrier Options");
            UseTopGirtMaterial();
            SingleMaterial();
            DoubleMaterial();
            TripleMaterial();
            QuadrupleMaterial();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Assemblies do not save Part Lengths Script");
        }

        #region Private Method
        /// <summary>
        /// Select 'Single' Truss Carrier Style and 'BAR JOIST' Material
        /// Enter invalid length, sync, and capture screenshot
        /// Navigate to Job Review, check invalid material length, enter valid length, and check valid data
        /// </summary>
        private void SingleMaterial()
        {
            ApplyTrussMaterialAndStyle("Single", "BAR JOIST", "31'", "TrussBearer", "BAR JOIST[Not Found]", "32'");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "TrussBearer", "BAR JOIST32", "BAR JOIST", null, null,"2" , null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the selected Single material length is shown in the Framing data.");
            CheckTrussBearerDataInTheDrawingTable("TrussBearer", "BAR JOIST", 40, "Single");
        }

        private void DoubleMaterial()
        {
            ApplyTrussMaterialAndStyle("Double", "Zee Steel Shape", "42'", "TrussBearer", "Zee Steel Shape[Not Found]", "10'");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "TrussBearer", "Zee Steel Shape10", "Zee Steel Shape", null, null, "10", null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the selected Single material length is shown in the Framing data.");
            CheckTrussBearerDataInTheDrawingTable("TrussBearer", "Zee Steel Shape", 80, "Double");
        }

        private void TripleMaterial()
        {
            ApplyTrussMaterialAndStyle("Triple", "I-BEAM 12 X 14#", "31'", "TrussBearer", "IB-1214-[Not Found]", "50'");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "TrussBearer", "IB-1214-50", "I-BEAM 12 X 14#", null, null, "3", null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the selected Triple material length is shown in the Framing data.");
            CheckTrussBearerDataInTheDrawingTable("TrussBearer", "I-BEAM 12 X 14#", 120, "Triple");
        }

        private void QuadrupleMaterial()
        {
            ApplyTrussMaterialAndStyle("Quadruple", "Zee Rotated", "31'", "TrussBearer", "Zee Rotated[Not Found]", "20'");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "TrussBearer", "Zee Rotated20", "Zee Rotated", null, null, "10", null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the selected Quadruple material length is shown in the Framing data.");
            CheckTrussBearerDataInTheDrawingTable("TrussBearer", "Zee Rotated", 160, "Quadruple");
        }

        private void UseTopGirtMaterial()
        {
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.ClicksStartFromScratch();

            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClicksShellButton();

            string initialValue = DefaultJobElement.GetTheConfiguredPrice();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            bool girt = DefaultJobElement.CheckTheMaterialShownInTheDrawingOfAssembly("Girt");
            Assert.IsFalse(girt, "Verify that extra girt is visible in the open wall");
            ExtentTestManager.TestSteps("Verify that extra girt is not visible in the open wall");
            DefaultJobElement.ClickCanvas3DViewButton();

            // Verify the placement of Open Wall on the canvas building
            VerifyOpenWallPlacementOnCanvasBuilding(initialValue, currentValue);

            // Adjust building size in the 3D view
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.WidthInputField("15");
            DefaultJobElement.CeilingHeightInputField("10");
            DefaultJobElement.RoofPitchInputField("1");

            // Navigate to the Details tab in 3D view and select Open Wall Truss Carrier
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectOpenWallPostMaterial("4x12 I-Beam");
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            DefaultJobElement.SelectTopGirtMaterial("None");
            DefaultJobElement.ClickOpenWallTrussCarrier();
            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            DefaultJobElement.SelectOpenWallTopGirtMaterial("BAR JOIST");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();

            bool result = DefaultJobElement.CheckTheMaterialShownInTheDrawingOfAssembly("TopGirt");
            Assert.IsTrue(result, "Verify that the use of top girt material is not applied on the open wall");

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.OpenWallTopGirtLengthOverridesInputField("31");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CaptureScreenshot("Use Top Girt.png");

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            DefaultJobElement.CheckInvalidMaterialLengthInTheJobReview("TopGirt", "BAR JOIST[Not Found]", "Use Top Girt");
            DefaultJobElement.OpenWallTopGirtLengthOverridesInputField("20");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "TopGirt", "BAR JOIST20", "BAR JOIST", null, null, null, null, "2", null, null);
            ExtentTestManager.TestSteps($"Verify that the selected TopGirt material length is shown in the Framing data.");
            CheckTrussBearerDataInTheDrawingTable("TopGirt", "BAR JOIST", 40, "Use Top Girt");
        }

        private void SelectTrussCarrierStyleAndSelectOpenWallTrussCarrierMaterial(string trussStyle, string trussMaterial)
        {
            DefaultJobElement.SelectTrussCarrierStyle(trussStyle);
            DefaultJobElement.SelectOpenWallTrussCarrierMaterial(trussMaterial);
        }

        private void EnterInvalidDataInTheOpenWallCarrierLengthOverridesInputField(string value)
        {
            EnterDataInTheOpenWallCarrierLengthOverridesInputField(value, "Invalid");
        }

        private void EnterValidDataInTheOpenWallCarrierLengthOverridesInputField(string value)
        {
            EnterDataInTheOpenWallCarrierLengthOverridesInputField(value, "Valid");
        }

        private void CheckTrussBearerDataInTheDrawingTable(string usage, string materialName, int calculationValue, string trussStyle)
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckTheCalculationOfQuantityFromDrawingTable(usage, materialName, calculationValue, trussStyle);
            ExtentTestManager.TestSteps($"Verify that {trussStyle} material length is update");
            DefaultJobElement.ClickCanvas3DViewButton();
        }

        private void EnterDataInTheOpenWallCarrierLengthOverridesInputField(string length, string validOrInvalidValue)
        {
            DefaultJobElement.OpenWallCarrierLengthOverridesInputField(length);
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            ExtentTestManager.TestSteps($"Enter any {validOrInvalidValue} value in Open Wall Truss Carrier Material field for material with length {length}");
        }

        private void VerifyOpenWallPlacementOnCanvasBuilding(string initialValue, string currentValue)
        {
            // Verify if the open wall is placed on the canvas building
            if (initialValue.Equals(currentValue))
            {
                Assert.Fail("Verify that the Open wall is not placed on the canvas building");
            }
        }

        private void CaptureScreenshot(string imageName)
        {
            DefaultJobElement.CaptureScreenShot($@"{pathFile}", $"{imageName}");
        }

        private void ApplyTrussMaterialAndStyle(string style, string material, string invalidValue, string usageName, string invalidMaterial, string validValue)
        {
            SelectTrussCarrierStyleAndSelectOpenWallTrussCarrierMaterial(style, material);
            EnterInvalidDataInTheOpenWallCarrierLengthOverridesInputField(invalidValue);
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CaptureScreenshot($"{style}.png");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.CheckInvalidMaterialLengthInTheJobReview(usageName, invalidMaterial, style);
            EnterValidDataInTheOpenWallCarrierLengthOverridesInputField(validValue);
        }
    }
}
#endregion