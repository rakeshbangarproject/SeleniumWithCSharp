using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildProductionAutomation.Helper;
using Forms.Reporting;
using NUnit.Framework;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using System.Linq;

namespace SmartBuildAutomation.Pages1
{
    public class DefaultJobElement : BaseClass
    {
        #region All IWebElements
        public static IWebElement Colors()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.colors)));
        }

        public static IWebElement FasciaAndSoffit()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.fasciaAndSoffit)));
        }

        public static IWebElement EaveFasciaMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveFasciaMaterial)));
        }

        public static IWebElement EaveFasciaColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveFasciaColor)));
        }

        public static IWebElement GableFasciaColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableFasciaColor)));
        }

        public static IWebElement SoffitStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.soffitStyle)));
        }

        public static IWebElement EaveSoffitMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveSoffitMaterial)));
        }

        public static IWebElement GableSoffitMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableSoffitMaterial)));
        }

        public static IWebElement EaveSoffitColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveSoffitColor)));
        }

        public static IWebElement GableSoffitColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableSoffitColor)));
        }

        public static IWebElement GableFasciaMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableFasciaMaterial)));
        }

        public static IWebElement YesButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.yesButton)));
        }

        public static IWebElement StatusButton(string buttonName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.changeStatusButton, buttonName))));
        }

        public static IWebElement WalkdoorOfAddOns()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.walkdoorOfAddOns)));
        }

        public static IWebElement InteriorWallsFromThe2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorWallsFromThe2DView)));
        }

        public static IWebElement AddRoom()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addRoom)));
        }

        public static IWebElement LengthInputFieldOfInteriorWall()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.lengthInputFieldOfInteriorWall)));
        }

        public static IWebElement WallFramingOfInteriorWallOf2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallFramingOfInteriorWallOf2DView)));
        }

        public static IWebElement InteriorStudMaterialOfInteriorWallOf2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorStudMaterialOfInteriorWallOf2DView)));
        }

        public static IWebElement WidthInputFieldOfInteriorWall()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.widthInputFieldOfInteriorWall)));
        }

        public static IWebElement CeilingProductOfInteriorWallOf2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingProductOfInteriorWallOf2DView)));
        }

        public static IWebElement RoofColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofColor)));
        }

        public static IWebElement Foundation()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.foundation)));
        }

        public static IWebElement Cladding()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.cladding)));
        }

        public static IWebElement JobListButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.jobListButton)));
        }

        public static IWebElement AngledRoofCladdingExtension()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.angledRoofCladdingExtension)));
        }

        public static IWebElement AdvancedPostHoleSettingsCheckbox()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.advancedPostHoleSettingsCheckbox));
        }

        public static IWebElement WallColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallColor)));
        }

        public static IWebElement TrimColor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trimColor)));
        }

        public static IWebElement AccentColor1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.accentColor1)));
        }

        public static IWebElement AccentColor2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.accentColor2)));
        }

        public static IWebElement AccentColor3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.accentColor3)));
        }

        public static IWebElement AccentColor4()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.accentColor4)));
        }

        public static IWebElement MainBuilding()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.mainBuilding)));
        }

        public static IWebElement BuildingSize()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.buildingSizeSubMenuTab)));
        }

        public static IWebElement BuildingSizeDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.buildingSizeOfBuildingSize)));
        }

        public static IWebElement MeasureFromDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.measureFromOfBuildingSize)));
        }

        public static IWebElement LengthField()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.lengthInputFieldOfBuildingSize));
        }

        public static IWebElement WidthField()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.widthInputFieldOfBuildingSize));
        }

        public static IWebElement HomeButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.HomeButton)));
        }

        public static IWebElement RoofHeightStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofHeightStyleOfBuildingSize)));
        }

        public static IWebElement CeilingHeightField()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.ceilingHeightInputFieldOfBuildingSize));
        }

        public static IWebElement ExteriorMetalHeightField()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.exteriorMetalHeightInputFieldOfBuildingSize));
        }

        public static IWebElement RoofStyleDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofStyleOfBuildingSize)));
        }

        public static IWebElement RoofPitchField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofPitchInputFieldOfBuildingSize)));
        }

        public static IWebElement OverHangDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.overhangOfBuildingSize)));
        }

        public static IWebElement StyleOfAdvancedRoofStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.styleOfRoofStyleAdvanced)));
        }

        public static IWebElement SlopeOfAdvancedRoofStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.slopeOfRoofStyleAdvanced)));
        }

        public static IWebElement LeftSlopeOfRoofStyleAdvanced()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.leftSlopeOfRoofStyleAdvanced)));
        }

        public static IWebElement RightSlopeOfRoofStyleAdvanced()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.rightSlopeOfRoofStyleAdvanced)));
        }

        public static IWebElement ServerErrorMessageButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.serverErrorMessageButton)));
        }
        public static IWebElement AddMiscButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addMisc)));
        }

        public static IWebElement AddCatalogButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addCatalog)));
        }

        public static IWebElement CatalogCategory()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.catalogCategory)));
        }

        public static IWebElement CatalogItem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.catalogItem)));
        }

        public static IWebElement UsageOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.usageOfMisc)));
        }

        public static IWebElement MaterialOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.materialOfMisc)));
        }
        public static IWebElement PriceOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.priceOfMisc)));
        }

        public static IWebElement CalculationOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.calculationOfMisc)));
        }

        public static IWebElement CurlyBracketsButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.curlyBracketsButton)));
        }

        public static IWebElement SaveButtonOfMisc()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.saveButtonOfMisc)));
        }

        public static IWebElement SearchElementInTheMiscTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.searchElementInTheMiscTable)));
        }

        public static IWebElement FirstRowOfCalculationTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.firstRowOfCalculationTable)));
        }

        public static IWebElement CantPorchButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.cantPorch)));
        }

        public static IWebElement AddButtonOfMisc()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addButtonOfMisc)));
        }

        public static IWebElement CostOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.costOfMisc)));
        }

        public static IWebElement SKUOfMiscInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.skuOfMisc)));
        }

        public static IWebElement OffsetToPeakOfAdvancedRoofStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.offsetToPeakOfRoofStyleAdvanced)));
        }

        public static IWebElement UpperSlopeOfRoofStyleAdvanced()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.upperSlopeOfRoofStyleAdvanced)));
        }

        public static IWebElement LowerSlopeOfRoofStyleAdvanced()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.lowerSlopeOfRoofStyleAdvanced)));
        }

        public static IWebElement OffsetToCurbOfRoofStyleAdvanced()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.offsetToCurbOfRoofStyleAdvanced)));
        }

        public static IWebElement ProductSystem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.productSystem)));
        }

        public static IWebElement RoofProductSystem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofProductSystem)));
        }

        public static IWebElement CeilingProductSystem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingProductSystem)));
        }

        public static IWebElement Lofts()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.lofts)));
        }

        public static IWebElement AddButtonOfLofts()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addButtonOfLofts)));
        }

        public static IWebElement CeilingProductSystemOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingProductSystemOfLoft)));
        }

        public static IWebElement JoistMaterialOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.joistMaterialOfLoft)));
        }

        public static IWebElement JoistSpacingOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.joistSpacingOfLoft)));
        }

        public static IWebElement CeilingMaterialOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingMaterialOfLoft)));
        }

        public static IWebElement FloorSheathingOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.floorSheathingOfLoft)));
        }

        public static IWebElement HasCeilingCheckOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasCeilingCheckOfLoft)));
        }

        public static IWebElement MainProductSystem()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.mainProductSystem)));
        }

        public static IWebElement Wainscot()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wainscot)));
        }

        public static IWebElement HasWainscotCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasWainscotCheckbox)));
        }

        public static IWebElement WainscotHeightField()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.wainscotHeightField));
        }

        public static IWebElement WainscotColorDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wainscotColorDropdown)));
        }

        public static IWebElement HasLinerPanels()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasLinerPanelsCheckbox)));
        }

        public static IWebElement WallLiner()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallLiner)));
        }

        public static IWebElement WallLinerColors()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.wallLinerColors));
        }

        public static IWebElement HasInteriorWainscot()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasInteriorWainscotCheckbox)));
        }

        public static IWebElement InteriorTrimColor()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.interiorTrimColor));
        }

        public static IWebElement InteriorWainscotHeight()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.interiorWainscotHeight));
        }

        public static IWebElement InteriorWainscotColor()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.interiorWainscotColor));
        }

        public static IWebElement CeilingLiner()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingLiner)));
        }

        public static IWebElement HasCeiling()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasCeiling)));
        }

        public static IWebElement FlatCeiling()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.flatCeiling)));
        }

        public static IWebElement CeilingColorDropdown()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.ceilingColorDropdown));
        }

        public static IWebElement CeilingTrimColorDropdown()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.ceilingTrimColorDropdown));
        }

        public static IWebElement Details()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.detailsButton)));
        }

        public static IWebElement TrussCarrierLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussCarrierLengthOverrides)));
        }

        public static IWebElement RoofTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofTrim)));
        }

        public static IWebElement TrimMargins()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trimMargins)));
        }

        public static IWebElement EaveEdgeTrimMargins()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveEdgeTrimMargins)));
        }

        public static IWebElement RoofTrimForRoofingPassport()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofTrimForRoofingPassport)));
        }

        public static IWebElement TrussCarrier()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussCarrier)));
        }

        public static IWebElement TopGirtMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.topGirtMaterial)));
        }

        public static IWebElement TrussCarrierMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussCarrierMaterial)));
        }

        public static IWebElement RidgeCap()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ridgeCap)));
        }

        public static IWebElement EaveEdgeTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveEdgeTrim)));
        }

        public static IWebElement HipRidgeCap()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hipRidgeCap)));
        }

        public static IWebElement RidgeCapLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ridgeCapLengthOverrides)));
        }

        public static IWebElement WallTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallTrim)));
        }

        public static IWebElement BaseTrimColorsDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.baseTrimColors)));
        }

        public static IWebElement WallGirtFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallGirtFraming)));
        }

        public static IWebElement GirtMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.girtMaterial)));
        }

        public static IWebElement GirtStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.girtStyle)));
        }

        public static IWebElement WallSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallSheathing)));
        }

        public static IWebElement SheathingOffsetFromGrade()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingOffsetFromGrade)));
        }

        public static IWebElement SheathingLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingLengthOverrides)));
        }

        public static IWebElement GableWallMargin()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableWallMargin)));
        }

        public static IWebElement EaveWallMargin()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eaveWallMargin)));
        }

        public static IWebElement RoundSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roundSheathing)));
        }

        public static IWebElement RoundAngledSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roundAngledSheathing)));
        }

        public static IWebElement WainscotDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wainscotOfWallSheathing)));
        }

        public static IWebElement WallMaterialDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallMaterialOfWallSheathing)));
        }

        public static IWebElement InteriorWall()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorWall)));
        }

        public static IWebElement SheathingSideA()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingSideA)));
        }

        public static IWebElement SheathingSideB()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingSideB)));
        }

        public static IWebElement RoofSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofSheathing)));
        }

        public static IWebElement OpenWallTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTrim)));
        }

        public static IWebElement CeilingLinerFromDetailsMenuList()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingLinerOfDetailsMenuList)));
        }
        public static IWebElement CeilingMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingMaterial)));
        }

        public static IWebElement CeilingMargin()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingMargin)));
        }

        public static IWebElement CeilingPartLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ceilingPartLengthOverrides)));
        }

        public static IWebElement OpenTopOfWallTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openTopOfWallTrim)));
        }

        public static IWebElement OpenTopOfWallPartLengths()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openTopOfWallPartLengths)));
        }

        public static IWebElement OpenWallOffset()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallOffset)));
        }

        public static IWebElement RoofMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofMaterial)));
        }

        public static IWebElement Packages()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.packageButton)));
        }

        public static IWebElement DrawingButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.drawingButton)));
        }

        public static IWebElement InteriorSheathingEXT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorSheathingEXT_1)));
        }

        public static IWebElement SheathingDrawingEXT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingEXT_1)));
        }

        public static IWebElement SheathingDrawingEXT_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingEXT_2)));
        }

        public static IWebElement SheathingDrawingEXT_3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingEXT_3)));
        }

        public static IWebElement SheathingDrawingEXT_4()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingEXT_4)));
        }

        public static IWebElement SheathingDrawingROOF_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingROOF_1)));
        }

        public static IWebElement SheathingDrawingROOF_3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingROOF_3)));
        }

        public static IWebElement SheathingDrawingROOF_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sheathingDrawingROOF_2)));
        }

        public static IWebElement CladdingDrawingROOF_6()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.claddingDrawingROOF_6)));
        }

        public static IWebElement CladdingDrawingROOF_3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.claddingDrawingROOF_3)));
        }

        public static IWebElement DividerWall()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.dividerWall)));
        }

        public static IWebElement SideA()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sideA)));
        }

        public static IWebElement SideB()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sideB)));
        }

        public static IWebElement JobButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.jobMenu)));
        }

        public static IWebElement EnterJobNameField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.jobNameField)));
        }

        public static IWebElement SaveButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.SaveButton)));
        }

        public static IWebElement InteriorSheathingCEIL_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorSheathingCEIL_1)));
        }

        public static IWebElement WallFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallFraming)));
        }

        public static IWebElement KeepOpenWallGablePostsCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.keepOpenWallGablePostsCheckbox)));
        }

        public static IWebElement ExteriorStudFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.exteriorStudFraming)));
        }

        public static IWebElement StudMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.studMaterial)));
        }

        public static IWebElement PostMaterialDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.postMaterialDropdown)));
        }

        public static IWebElement WallFramingDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallFramingDropdown)));
        }

        public static IWebElement InteriorWallFramingDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.interiorWallFramingDropdown)));
        }

        public static IWebElement OpenWallPostMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallPostMaterial)));
        }

        public static IWebElement GablePostMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gablePostMaterial)));
        }

        public static IWebElement EavePostPlacement()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.eavePostPlacement)));
        }

        public static IWebElement UpperSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.upperSheathing)));
        }
        public static IWebElement HasUpperSheathing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.hasUpperSheathing)));
        }

        public static IWebElement UpperSheathingHeight()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.upperSheathingHeight));
        }

        public static IWebElement UpperSheathingColors()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.upperSheathingColors));
        }

        public static IWebElement RoofFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofFraming)));
        }

        public static IWebElement TrussHeelHeight()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussHeelHeight)));
        }

        public static IWebElement PurlinFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.purlinFraming)));
        }

        public static IWebElement PurlinType()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.purlinType)));
        }

        public static IWebElement BaseTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.baseTrim)));
        }

        public static IWebElement TopOfWallTrim()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.topOfWallTrim)));
        }

        public static IWebElement OpenWallButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.clickOpenWallButton)));
        }

        public static IWebElement OpenWallTrussCarrier()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTrussCarrier)));
        }

        public static IWebElement TrussCarrierStyle()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.trussCarrierStyle));
        }

        public static IWebElement OpenWallTrussCarrierMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTrussCarrierMaterial)));
        }

        public static IWebElement OpenWallTrussCarrierBaySpan()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTrussCarrierBaySpan)));
        }

        public static IWebElement OpenWallTopGirtMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTopGirtMaterial)));
        }

        public static IWebElement OpenWallCarrierLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallCarrierLengthOverrides)));
        }
        public static IWebElement ApplyButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.applyButton)));
        }

        public static IWebElement OpenWallTopGirtLengthOverrides()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.openWallTopGirtLengthOverrides)));
        }

        public static IWebElement DoorAndWindows()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.doorAndWindows)));
        }

        public static IWebElement SliderDoorPostFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.sliderDoorPostFraming)));
        }

        public static IWebElement TrackBoardForSliderDoorPostFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trackBoardForSliderDoorPostFraming)));
        }

        public static IWebElement TrackBoardExtensionForSliderDoorPostFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trackBoardExtensionForSliderDoorPostFraming)));
        }

        public static IWebElement OverheadDoorPostFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.overheadDoorPostFraming)));
        }

        public static IWebElement JambPostMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.jambPostMaterial)));
        }

        public static IWebElement HeaderHighCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.headerHighCheckbox)));
        }

        public static IWebElement HeaderHighBoundariesMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.headerHighBoundariesMaterial)));
        }

        public static IWebElement HeaderHighMaterial()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.headerHighMaterial)));
        }

        public static IWebElement Bays()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.bays)));
        }

        public static IWebElement UseBaysSpacingCheckbox()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.useBaysSpacingCheckbox)));
        }

        public static IWebElement BaySpacing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.baySpacing)));
        }

        public static IWebElement BayPlacement()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.bayPlacement)));
        }

        public static IWebElement FixTrussesButton(string usageName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.fixTrussesButton, usageName))));
        }

        public static IWebElement SKUInputFieldOfFixTruss()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.skuInputFieldOfFixTrusses)));
        }

        public static IWebElement AddToTrussTableButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addToTrussTableButton)));
        }

        public static IWebElement AttachedBuilding()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.attachedBuilding)));
        }

        public static IWebElement Opening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Opening)));
        }

        public static IWebElement WidthFieldOfSlider()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.widthFieldOfSlider));
        }

        public static IWebElement HeightFieldOfSlider()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.heightFieldOfSlider));
        }

        public static IWebElement SideFieldOfSlider()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.sideFieldOfSlider));
        }

        public static IWebElement WalkDoor()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.WalkDoor)));
        }

        public static IWebElement Overhead()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Overhead)));
        }

        public static IWebElement Sliders()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Sliders)));
        }

        public static IWebElement SelectAStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.selectAStyle)));
        }

        public static IWebElement SelectStandardSlider()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.selectStandardSlider)));
        }

        public static IWebElement Windows()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Windows)));
        }

        public static IWebElement SelectStyleFromDoors(string styleName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.SelectStyleFromDoors, styleName))));
        }

        public static IWebElement SelectStyle()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath((Locator.DefaultJob.SelectAStyle))));
        }

        public static IWebElement SelectOpeningDoors(string doorName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.SelectOpeningDoors, doorName))));
        }

        public static IWebElement SillHeight()
        {
            return Driver.FindElement(By.XPath(Locator.DefaultJob.sillHeight));
        }

        public static IWebElement LocationOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.locationOpening)));
        }

        public static IWebElement SelectLocation(string elementName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.selectLocation, elementName))));
        }

        public static IWebElement Canvas3DViewButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DViewButton)));
        }

        public static IWebElement RoofButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofButton)));
        }

        public static IWebElement DrawingAreaOf3D()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
        }

        public static IWebElement NonStructuralWalkdoorPostFraming()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.nonStructuralWalkdoorPostFraming)));
        }

        public static IWebElement JambType()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.jambType)));
        }

        public static IWebElement HeaderBoundaries()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.headerBoundaries)));
        }

        public static void PlaceOpening(int x_axis, int y_axis)
        {
            CommonMethod.GetActions().MoveToElement(DrawingAreaOf3D()).MoveByOffset(x_axis, y_axis).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void OpenPlaceOpening(int x_axis, int y_axis)
        {
            CommonMethod.GetActions().MoveToElement(DrawingAreaOf3D()).MoveByOffset(x_axis, y_axis).Pause(TimeSpan.FromSeconds(0.5)).Click().Pause(TimeSpan.FromSeconds(0.5)).DoubleClick().Pause(TimeSpan.FromSeconds(2)).Perform();
        }

        public static IWebElement NewDropdownInDefaultJob(string dropdownName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.dropdownElements, dropdownName))));
        }

        public static IWebElement DropdownElements(string labelName)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.dropdownElements, labelName))));
        }

        public static IWebElement RoofFramingOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofFramingDropdown)));
        }

        public static IWebElement AssemblyDrawingEXT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_1)));
        }

        public static IWebElement AssemblyDrawingEXT_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_2)));
        }

        public static IWebElement AssemblyDrawingEXT_3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_3)));
        }

        public static IWebElement AssemblyDrawingEXT_4()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_4)));
        }

        public static IWebElement AssemblyDrawingINT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingINT_1)));
        }

        public static IWebElement AssemblyDrawingEXT_6()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_6)));
        }

        public static IWebElement AssemblyDrawingEXT_8()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingEXT_8)));
        }

        public static IWebElement AssemblyDrawingROOF_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingROOF_1)));
        }

        public static IWebElement AssemblyDrawingROOF_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.assemblyDrawingROOF_2)));
        }

        public static IWebElement OutputButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.OutputsButton)));
        }

        public static IWebElement DownloadButtonOfOutputsTable()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.DownloadButton)));
        }

        public static IWebElement ChangeView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.changesView)));
        }

        public static IWebElement AdvancedEdit()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.AdvancedEdit)));
        }

        public static IWebElement ROOF_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ROOF_1)));
        }

        public static IWebElement LOFT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.LOFT_1)));
        }

        public static IWebElement LOFT_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.LOFT_2)));
        }

        public static IWebElement ROOF_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ROOF_2)));
        }

        public static IWebElement EXT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.EXT_1)));
        }

        public static IWebElement EXT_2()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.EXT_2)));
        }

        public static IWebElement EXT_3()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.EXT_3)));
        }

        public static IWebElement EXT_4()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.EXT_4)));
        }

        public static IWebElement INT_1()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.INT_1)));
        }

        public static IWebElement EXT_6()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.EXT_6)));
        }

        public static IWebElement AdvancedFrameApplyButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.advancedFrameApplyButton)));
        }

        public static IWebElement JobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.JobReview)));
        }

        public static IWebElement TrussesOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Trusses)));
        }

        public static IWebElement TestWalkDoorOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.testWalkDoor)));
        }

        public static IWebElement CladdingOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.claddingOfJobReview)));
        }

        public static IWebElement TestOverheadOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.testOverhead)));
        }

        public static IWebElement TestSliderOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.testSlider)));
        }

        public static IWebElement TestWindowOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.testWindow)));
        }

        public static IWebElement SheathingOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Sheathing)));
        }

        public static IWebElement FramingOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.framing)));
        }

        public static IWebElement AccessoriesOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.accessories)));
        }

        public static IWebElement SummaryOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.summary)));
        }

        public static IWebElement LaborOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.labor)));
        }

        public static IWebElement FreightOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.freight)));
        }

        public static IWebElement DoorAndWindowOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.doorAndWindowJobReview)));
        }

        public static IWebElement TrimOfJobReview()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trim)));
        }
        public static IWebElement StartInputFieldOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.startInputField)));
        }

        public static IWebElement LengthInputFieldOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.lengthInputField)));
        }

        public static IWebElement WidthInputFieldOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.widthInputField)));
        }

        public static IWebElement HeightInputFieldOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.heightInputField)));
        }

        public static IWebElement DistanceInputFieldOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.distanceInputFieldOfOpening)));
        }

        public static IWebElement UpdateButtonOf2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.updateButtonOf2DView)));
        }

        public static IWebElement UpdateButtonOfLoft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.updateButtonOfLoft)));
        }

        public static IWebElement UpdateButtonOfWall()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.updateButtonOfWall)));
        }

        public static IWebElement UpdateButtonOf3DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.updateButtonOf3DView)));
        }

        public static IWebElement ReturnButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.returnButton)));
        }

        public static IWebElement Edit2DView()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.edit2DView)));
        }

        public static IWebElement RoofPitchInputFieldOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofPitchInputField)));
        }

        public static IWebElement HeightDropdownOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.heightDropdown)));
        }

        public static IWebElement RoofOrientationDropdownOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofOrientationDropdown)));
        }

        public static IWebElement OverhangDropdownOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.overhangDropdown)));
        }

        public static IWebElement WallsDropdownOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.wallsDropdown)));
        }

        public static IWebElement RoofFramingDropdownOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofFramingDropdown)));
        }

        public static IWebElement AdvancedCheckboxOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.advancedCheckboxOfOpening)));
        }

        public static IWebElement UseBaySpacingCheckboxForOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.useBaySpacingCheckboxForOpening)));
        }

        public static IWebElement DoubleTrussCheckboxForOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.doubleTrussCheckboxForOpening)));
        }

        public static IWebElement DoNotCombineCheckboxForOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.doNotCombineCheckboxForOpening)));
        }

        public static IWebElement BaySpacingOptionFromOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.baySpacingOptionFromOpening)));
        }

        public static IWebElement BayPlacementFromOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.selectBayPlacementFromOpening)));
        }

        public static IWebElement IncludeBackWallFromOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.includeBackWallFromOpening)));
        }

        public static IWebElement BayLengthsFromOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.bayLengths)));
        }

        public static IWebElement ApplyButtonsOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.applyButtonsOfOpening)));
        }

        public static IWebElement RoofStyleOfOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofStyleOfOpening)));
        }

        public static IWebElement Porch()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.porch)));
        }

        public static IWebElement MainOfAdvancedEdit()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.mainOfAdvancedEdit)));
        }

        public static IWebElement FrontLeft()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.frontLeft)));
        }

        public static IWebElement FrontRight()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.frontRight)));
        }
        public static IWebElement Left()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.left)));
        }

        public static IWebElement Custom()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.custom)));
        }

        public static IWebElement GableWallsStyleDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableWallsStyleDropdown)));
        }

        public static IWebElement GableWallsStyleDropdownForDetailsTab()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gableWallsStyleDropdownForDetailsTab)));
        }

        public static IWebElement TrussSpecialDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussSpecialDropdown)));
        }

        public static IWebElement Cupolas()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.cupolas)));
        }

        public static IWebElement TrussMaterialDropdown()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.trussMaterialDropdown)));
        }
        public static IWebElement AtticRoomWidthOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.atticRoomWidthOpening)));
        }

        public static IWebElement AtticRoomHeightOpening()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.atticRoomHeightOpening)));
        }

        public static IWebElement Awning()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.awning)));
        }

        public static IWebElement Cancel()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.cancel)));
        }

        public static IWebElement LeanTo()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.leanTo)));
        }
        public static IWebElement NoButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.clickNoButton)));
        }

        public static IWebElement GablePostSpacing()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gablePostSpacing)));
        }
        public static IWebElement GablePostPlacement()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.gablePostPlacement)));
        }
        public static IWebElement QuotedInputField()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.quotedInputField)));
        }
        public static IWebElement SelectionDropdownOfRoofingPassport()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.selectionDropdownOfRoofingPassport)));
        }

        public static IWebElement ColorTabOfRoofingPassportFromAdvancedEdit()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.colorTabOfRoofingPassportFromAdvancedEdit)));
        }

        public static IWebElement RoofSystemDropdownOfRoofingPassport()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.roofSystemDropdownOfRoofingPassport)));
        }
        public static IWebElement SaveChangesButton()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.saveChangesButton)));
        }
        #endregion

        // This method is used for If the element is not visible then clicks again
        public static void ClicksTab(Func<IWebElement> methodName, string visibleElementPaths, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(visibleElementPaths)))
            {
                CommonMethod.GetActions().Click(methodName()).Perform();
            }

            ExtentTestManager.TestSteps($"Click on the '{elementName}' tab");
        }

        // This method is used for the clicks on the elements
        public static void ClicksTab(Func<IWebElement> methodName, string elementName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the '{elementName}' ");
        }

        // This method is used for enter data in the input field
        public static void InputFields(Func<IWebElement> methodName, string value, string inputName)
        {
            CommonMethod.GetActions().Click(methodName()).Perform();
            CommonMethod.GetActions().Click(methodName()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the {inputName} field");
        }

        // This method is used for select element from dropdown
        public static void SelectMaterialFromDropdowns(string materialName)
        {
            IWebElement materialElement = Driver.FindElement(By.XPath(string.Format(Locator.DefaultJob.SelectMaterialFromDropdown, materialName)));
            CommonMethod.GetActions().Click(materialElement).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        // This method is used for select element from dropdown using span tagName
        public static void SelectMaterialFromDropdownTagNameOfSpanElement(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.DefaultJob.MaterialTableRowsForColor);
        }

        // This method is used for select element from dropdown using td tagName
        public static void SelectMaterialFromDropdownTagNameOfTDElement(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.DefaultJob.selectMaterialFromAdvancedEdit);
        }

        // This method is used for select element from dropdown using div tagName
        public static void SelectMaterialFromDropdownTagNameOfDivElement(string materialName)
        {
            CommonMethod.SelectMaterialFromDropdown(materialName, Locator.DefaultJob.MaterialTableRows);
        }

        // This method is used for check the checkbox
        public static void CheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (!checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Check the '{checkboxName}' checkbox");
        }

        // This method is used for unchecked the checkbox
        public static void UncheckCheckbox(Func<IWebElement> checkbox, string checkboxName)
        {
            if (checkbox().Selected)
            {
                checkbox().Click();
            }

            ExtentTestManager.TestSteps($"Uncheck the '{checkboxName}' checkbox");
        }

        public static bool CheckElementShownInTheDropdown(string materialName, string xpath)
        {
            CommonMethod.Wait(1);
            bool result = false;
            IReadOnlyList<IWebElement> numberOfElements = Driver.FindElements(By.XPath(xpath));

            for (int index = 0; index < numberOfElements.Count; index++)
            {
                string elementText = numberOfElements[index].Text;

                if (!string.IsNullOrEmpty(elementText) && elementText.Equals(materialName))
                {
                    CommonMethod.GetActions().Click(numberOfElements[index]).Perform();
                    result = true;
                    break;
                }
            }

            return result;
        }

        #region Edit 2D View

        // This method is used for click on the 2D view tab
        public static void ClickEdit2DView()
        {
            ClicksTab(Edit2DView, Locator.DefaultJob.loftTab, "2D View");
        }

        // This method is used for click on the Interior Walls from 2D view
        public static void ClickInteriorWallsFromThe2DView()
        {
            ClicksTab(InteriorWallsFromThe2DView, "Interior Wall");
        }

        // This method is used for check interior wall material are shown in the 2D view
        public static void ClickInteriorWallElementsInThe2DView(string interiorWallElement)
        {
            bool result = false;
            CommonMethod.Wait(1);
            IReadOnlyList<IWebElement> listOfInteriorWall = Driver.FindElements(By.XPath(Locator.DefaultJob.getElementListOfInteriorWall2DView));

            if (listOfInteriorWall.Count.Equals(0))
            {
                Assert.Fail($"{interiorWallElement} is not shown in the interior wall element list");
            }

            foreach (IWebElement element in listOfInteriorWall)
            {
                string getElementText = element.Text;

                if (getElementText != null && getElementText.Equals(interiorWallElement))
                {
                    CommonMethod.GetActions().DoubleClick(element).Pause(TimeSpan.FromSeconds(1)).Perform();
                    ExtentTestManager.TestSteps($"Click on the {interiorWallElement}");
                    result = true;
                    break;
                }
            }

            Assert.That(result, Is.True, $"{interiorWallElement} is not shown in the interior wall element list");
        }

        // This method is used for click on the loft tab
        public static void ClickLoftsFromThe2DView()
        {
            ClicksTab(Lofts, "Lofts");
        }

        // This method is used for click on the add room tab
        public static void ClickAddRoom()
        {
            ClicksTab(AddRoom, Locator.CommonXPath.waitForPopupVisible, "Add Room");
        }

        // This method is used for click on the add button of loft field
        public static void ClickAddButtonOfLofts()
        {
            ClicksTab(AddButtonOfLofts, Locator.CommonXPath.waitForPopupVisible, "Add Button");
        }

        // This method is used for enter data in the Length field of interior wall
        public static void EnterLengthInputFieldOfInteriorWall(string value)
        {
            InputFields(LengthInputFieldOfInteriorWall, value, "length");
        }

        // This method is used for enter data in the width field of interior wall
        public static void EnterWidthInputFieldOfInteriorWall(string value)
        {
            InputFields(WidthInputFieldOfInteriorWall, value, "width");
        }

        // This method is used for select ceiling product system from loft poopup
        public static void SelectCeilingProductSystemOfLoft(string elementName)
        {
            CommonMethod.GetActions().Click(CeilingProductOfInteriorWallOf2DView()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the ceiling product system dropdown");
        }

        // This method is used for get the text from wall framing of interior wall
        public static string GetWallFramingValueOfInteriorWall2DView()
        {
            return WallFramingOfInteriorWallOf2DView().GetAttribute("title");
        }

        // This method is used for get the text from Interior Stud Material of interior wall
        public static string GetInteriorStudMaterialOfInteriorWallOf2DView()
        {
            return InteriorStudMaterialOfInteriorWallOf2DView().GetAttribute("title");
        }

        // This method is used for select Ceiling Material from loft popup
        public static void SelectCeilingMaterialOfLoft(string elementName)
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(CeilingMaterialOfLoft()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the ceiling material dropdown");
        }

        // This method is used for check the has ceiling checkbox
        public static void CheckHasCeilingCheckboxOfLoft()
        {
            CheckCheckbox(HasCeilingCheckOfLoft, "Has Ceiling");
        }

        // This method is used for double click on the place door on the 2D view
        public static void DoubleClickOnThePlaceDoorOnThe2DView(string doorName)
        {
            OpenElementInThe2DCanvasBuilding(doorName, Locator.DefaultJob.getTheDoorNameFromThe2DView);
        }

        // This method is used for double click on the interior wall on the 2D view
        public static void DoubleClickOnThePlaceInteriorWallOnThe2DView(string wallName)
        {
            OpenElementInThe2DCanvasBuilding(wallName, Locator.DefaultJob.getTheInteriorWallNameFromThe2DView);
        }

        // This method is used for open element from 2D view.
        public static void OpenElementInThe2DCanvasBuilding(string elementName, string xpath)
        {
            bool result = false;
            IReadOnlyList<IWebElement> row = Driver.FindElements(By.XPath(xpath));

            foreach (IWebElement webElement in row)
            {
                string cell = webElement.Text;
                if (cell != null && cell.Contains(elementName))
                {
                    CommonMethod.GetActions().DoubleClick(webElement).Perform();
                    result = true;
                }
            }

            Assert.That(result, Is.True, $"{elementName} is not shown in the 2D view");
        }
        #endregion

        #region Porch 
        // This method is used for open element from 2D view.
        public static void ClickPorch()
        {
            ClicksTab(Porch, Locator.CommonXPath.waitForDropdownElementVisible, "Porch");
        }

        // This method is used for click front left from porch popup.
        public static void ClickFrontLeft()
        {
            ClicksTab(FrontLeft, "Front Left");
        }

        // This method is used for click front right from porch popup.
        public static void ClickFrontRight()
        {
            ClicksTab(FrontRight, "Front Right");
        }

        // This method is used for click left from porch popup.
        public static void ClickLeft()
        {
            ClicksTab(Left, "Left");
        }

        // This method is used for click custom from porch popup.
        public static void ClickCustom()
        {
            ClicksTab(Custom, "Custom");
        }

        // This method is used for select gable wall style from porch popup.
        public static void SelectGableWallsStyleDropdownOption(string elementName)
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(GableWallsStyleDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Gable Walls Style' dropdown");
        }

        // This method is used for select truss special from porch popup.
        public static void SelectTrussSpecialDropdownOption(string elementName)
        {
            CommonMethod.GetActions().Click(TrussSpecialDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Truss Special' dropdown");
        }

        // This method is used for get the truss material value from porch popup.
        public static string GetTheTrussMaterialValue()
        {
            return TrussMaterialDropdown().GetAttribute("title");
        }

        // This method is used for get the truss material value from porch popup.
        public static string GetTheTrussSpecialValue()
        {
            return TrussSpecialDropdown().GetAttribute("title");
        }

        // This method is used for enter data in the attic room width input field from porch popup.
        public static void AtticRoomWidthOpeningInputField(string value)
        {
            InputFields(AtticRoomWidthOpening, value, "Attic Room width");
        }

        // This method is used for enter data in the attic height input field from porch popup.
        public static void AtticRoomHeightOpeningInputField(string value)
        {
            InputFields(AtticRoomHeightOpening, value, "Attic Room height");
        }
        #endregion

        #region Awning 
        // This method is used for click on the Awing tab.
        public static void ClickAwning()
        {
            ClicksTab(Awning, Locator.CommonXPath.waitForDropdownElementVisible, "Awning");
        }

        // This method is used for click on the cancel button.
        public static void ClickCancel()
        {
            CommonMethod.GetActions().Click(Cancel()).Pause(TimeSpan.FromSeconds(1)).Perform();
        }
        #endregion

        #region Lean To
        // This method is used for click on the LeanTo tab.
        public static void ClickLeanTo()
        {
            ClicksTab(LeanTo, Locator.CommonXPath.waitForDropdownElementVisible, "Lean To");
        }
        #endregion

        #region Attached Builidng
        // This method is used for click on the Attached Building tab.
        public static void ClickAttachedBuilding()
        {
            ClicksTab(AttachedBuilding, Locator.CommonXPath.waitForPopupVisible, "Attached Building");
        }

        // This method is used for enter data in teh start input field from opening popup 
        public static void EnterStartInputFieldOption(string value)
        {
            InputFields(StartInputFieldOpening, value, "start");
        }

        // This method is used for enter data in teh length input field from opening popup 
        public static void EnterLengthInputFieldOption(string value)
        {
            InputFields(LengthInputFieldOpening, value, "length");
        }

        // This method is used for enter data in teh width input field from opening popup 
        public static void EnterWidthInputFieldOption(string value)
        {
            InputFields(WidthInputFieldOpening, value, "width");
        }

        // This method is used for enter data in teh height input field from opening popup 
        public static void HeightInputFieldOption(string value)
        {
            InputFields(HeightInputFieldOpening, value, "height");
        }

        // This method is used for enter data in teh roof pitch input field from opening popup 
        public static void RoofPitchInputFieldOption(string value)
        {
            InputFields(RoofPitchInputFieldOpening, value, "RoofPitch");
        }

        // This method is used for get the height value from opening popup 
        public static string GetHeightInputFieldOpeningValue()
        {
            return HeightInputFieldOpening().GetAttribute("value");
        }

        // This method is used for select height dropdown from opening popup 
        public static void SelectHeightDropdownOpeningOption(string elementName)
        {
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(HeightDropdownOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Height' dropdown");
        }

        // This method is used for select roof orientation from opening popup 
        public static void SelectRoofOrientationDropdownOpeningOption(string elementName)
        {
            CommonMethod.GetActions().Click(RoofOrientationDropdownOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Roof Orientation' dropdown");
        }

        // This method is used for select overhang from opening popup 
        public static void SelectOverhangDropdownOfOpeningOption(string elementName)
        {
            CommonMethod.GetActions().Click(OverhangDropdownOfOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'overhang' dropdown");
        }

        // This method is used for walls from opening popup 
        public static void SelectWallsDropdownOfOpeningOption(string elementName)
        {
            CommonMethod.GetActions().Click(WallsDropdownOfOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'walls' dropdown");
        }

        // This method is used for roof framing from opening popup 
        public static void SelectRoofFramingDropdownOpeningOption(string elementName)
        {
            CommonMethod.GetActions().Click(RoofFramingDropdownOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'roof framing' dropdown");
        }

        // This method is used for select roof style from opening popup 
        public static void SelectRoofStyleOfOpeningOption(string elementName)
        {
            CommonMethod.GetActions().Click(RoofStyleOfOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'roof style' dropdown");
        }

        // This method is used for get the roof framing value from opening popup 
        public static string GeTheRoofFramingOptionValue()
        {
            return RoofFramingDropdownOpening().GetAttribute("title");
        }

        // This method is used for check the advanced checkbox from opening popup 
        public static void CheckAdvancedCheckboxOfOpening()
        {
            CheckCheckbox(AdvancedCheckboxOfOpening, "Advanced");
        }

        // This method is used for check the bays spacing checkbox from opening popup 
        public static void CheckUseBaySpacingCheckboxForOpening()
        {
            CheckCheckbox(UseBaySpacingCheckboxForOpening, "Use Bay Spacing Checkbox For Opening");
        }

        // This method is used for check double truss checkbox from opening popup 
        public static void CheckDoubleTrussCheckboxForOpening()
        {
            CheckCheckbox(DoubleTrussCheckboxForOpening, "Double Truss Checkbox For Opening");
        }

        // This method is used for uncheck do not combine wall checkbox from opening popup 
        public static void UncheckDoNotCombineWallsCheckboxForOpening()
        {
            UncheckCheckbox(DoNotCombineCheckboxForOpening, "Don't combine walls Checkbox For Opening");
        }

        // This method is used for get the bay spacing value from opening popup 
        public static string GetBaySpacingValueFromOpening()
        {
            return BaySpacingOptionFromOpening().GetAttribute("title");
        }

        // This method is used for select bay placement from opening popup 
        public static void SelectBayPlacementFromOpening(string elementName)
        {
            CommonMethod.GetActions().Click(BayPlacementFromOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'bay placement' dropdown");
        }

        // This method is used for select Include back wall from opening popup 
        public static void SelectIncludeBackWallFromOpening(string elementName)
        {
            CommonMethod.GetActions().Click(IncludeBackWallFromOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Include back wall' dropdown");
        }

        // This method is used for enter bay length and click on the apply button from opening popup 
        public static void EnterBayLengths(string value)
        {
            InputFields(BayLengthsFromOpening, value, "Bay Lengths");
            CommonMethod.GetActions().Click(ApplyButtonsOfOpening()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the apply button");
        }
        #endregion

        #region Main Building

        // This method is used for click on the main building tab
        public static void ClickMainBuilding()
        {
            ClicksTab(MainBuilding, "Main Building Tab");
        }

        // This method is used for click cant porch button
        public static void ClickCantPorchButton()
        {
            ClicksTab(CantPorchButton, "Cant Porch Tab");
        }

        // This method is used for click on main building from advanced edit 
        public static void ClickMainBuildingOfAdvancedEdit()
        {
            ClicksTab(MainOfAdvancedEdit, "Main Building Tab");
        }

        #region Main Building Option
        // This method is used for select Roof Style of main building from advanced edit 
        public static void SelectStyleOfRoofStyleAdvanced(string styleElement)
        {
            InputFields(StyleOfAdvancedRoofStyle, styleElement, "roof style");
        }

        // This method is used for get the style value from advanced edit
        public static string GetStyleValueOfAdvancedRoofStyle()
        {
            return StyleOfAdvancedRoofStyle().GetAttribute("title");
        }

        // This method is used for enter slope value of main building from advanced edit
        public static void SlopeOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(SlopeOfAdvancedRoofStyle, value, "slope");
        }

        // This method is used for get the slope value from advanced edit
        public static string GetSlopeOfAdvancedRoofStyleValue()
        {
            return SlopeOfAdvancedRoofStyle().GetAttribute("value");
        }

        // This method is used for select left slope value from advanced edit 
        public static void LeftSlopeOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(LeftSlopeOfRoofStyleAdvanced, value, "left slope");
        }

        // This method is used for get the left slope value from advanced edit 
        public static string GetLeftSlopeOfAdvancedRoofStyleValue()
        {
            return LeftSlopeOfRoofStyleAdvanced().GetAttribute("value");
        }

        // This method is used for enter upper slope from advanced edit 
        public static void UpperSlopeOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(UpperSlopeOfRoofStyleAdvanced, value, "upper slope");
        }

        // This method is used for get upper slope value from advanced edit
        public static string GetUpperSlopeOfAdvancedRoofStyleValue()
        {
            return UpperSlopeOfRoofStyleAdvanced().GetAttribute("value");
        }

        // This method is used for enter lower slope data from advanced edit 
        public static void LowerSlopeOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(LowerSlopeOfRoofStyleAdvanced, value, "lower slope");
        }

        // This method is used for get the lower slope value from advanced edit
        public static string GetLowerSlopeOfAdvancedRoofStyleValue()
        {
            return LowerSlopeOfRoofStyleAdvanced().GetAttribute("value");
        }

        // This method is used for enter offset of curb value from advanced edit
        public static void OffsetToCurbOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(OffsetToCurbOfRoofStyleAdvanced, value, "Offset To Curb");
        }

        // This method is used for get the offset of curb value from advanced edit
        public static string GetOffsetToCurbOfAdvancedRoofStyleValue()
        {
            return OffsetToCurbOfRoofStyleAdvanced().GetAttribute("value");
        }

        // This method is used for entre right slope value from advanced edit
        public static void RightSlopeOfRoofStyleAdvanced(string value)
        {
            InputFields(RightSlopeOfRoofStyleAdvanced, value, "right slope");
        }

        // This method is used for get the right slope value from advanced edit
        public static string GetRightSlopeOfRoofStyleAdvancedValue()
        {
            return RightSlopeOfRoofStyleAdvanced().GetAttribute("value");
        }

        // This method is used for enter offset to peak value from advanced edit
        public static void OffsetToPeakOfAdvancedRoofStyleInputField(string value)
        {
            InputFields(OffsetToPeakOfAdvancedRoofStyle, value, "Offset To Peak");
        }

        // This method is used for get the offset to peak value from advanced edit
        public static string GetOffsetToPeakOfAdvancedRoofStyleValue()
        {
            return OffsetToPeakOfAdvancedRoofStyle().GetAttribute("value");
        }

        // This method is used for click on the building size
        public static void ClickBuildingSize()
        {
            ClicksTab(BuildingSize, Locator.DefaultJob.waitForTheMainBuildingElementsVisible, "Building Size");
        }

        // This method is used for select building size element
        public static void SelectBuildingSizeMaterial(string nameOfBuildingSizeElement)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));

            try
            {
                CommonMethod.GetActions().Click(BuildingSizeDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdownTagNameOfDivElement(nameOfBuildingSizeElement);
            }
            catch (Exception)
            {
                CommonMethod.GetActions().Click(BuildingSizeDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdownTagNameOfDivElement(nameOfBuildingSizeElement);
            }
            CommonMethod.Wait(1);
            ExtentTestManager.TestSteps($"Set {nameOfBuildingSizeElement} to the 'Building Size' dropdown");
        }

        // This method is used for get building size element
        public static string GetBuildingSizeMaterialValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return BuildingSizeDropdown().GetAttribute("title");
        }

        // This method is used for select measure from element
        public static void SelectMeasureFromMaterial(string nameOfMeasureFromElement)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            CommonMethod.GetActions().Click(MeasureFromDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(nameOfMeasureFromElement);
            ExtentTestManager.TestSteps($"Set {nameOfMeasureFromElement} to the 'Measure From' dropdown");
        }

        // This method is used for get measure from element
        public static string GetMeasureFromValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return MeasureFromDropdown().GetAttribute("title");
        }

        // This method is used for enter data in the length input field
        public static void LengthInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(LengthField, value, "length");
        }

        // This method is used for get the length data
        public static string GetLengthValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return LengthField().GetAttribute("value");
        }

        // This method is used for enter data in the width input field
        public static void WidthInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(WidthField, value, "width");
        }
        // This method is used for get the width data
        public static string GetWidthValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return WidthField().GetAttribute("value");
        }

        // This method is used for select roof height style material from building size
        public static void SelectRoofHeightStyleMaterial(string nameOfRoofHeightStyleElement)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));

            try
            {
                CommonMethod.GetActions().Click(RoofHeightStyle()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdowns(nameOfRoofHeightStyleElement);
            }
            catch (NoSuchElementException)
            {
                CommonMethod.GetActions().Click(RoofHeightStyle()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdowns(nameOfRoofHeightStyleElement);
            }

            ExtentTestManager.TestSteps($"Set {nameOfRoofHeightStyleElement} to the 'Roof Height Style' dropdown");
        }

        // This method is used for enter data in the ceiling height input field from building size
        public static void CeilingHeightInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(CeilingHeightField, value, "ceiling height");
        }
        // This method is used for get the ceiling height data
        public static string GetCeilingHeightValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return CeilingHeightField().GetAttribute("value");
        }
        // This method is used for enter data in the exterior metal height input field
        public static void ExteriorMetalHeightInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(ExteriorMetalHeightField, value, "exterior metal height");
        }
        // This method is used for select roof style material from building size
        public static void SelectRoofStyleMaterial(string nameOfRoofHeightStyleElement)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));

            try
            {
                CommonMethod.GetActions().Click(RoofStyleDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdowns(nameOfRoofHeightStyleElement);
            }
            catch (NoSuchElementException)
            {
                CommonMethod.GetActions().Click(RoofStyleDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
                SelectMaterialFromDropdowns(nameOfRoofHeightStyleElement);
            }

            ExtentTestManager.TestSteps($"Set {nameOfRoofHeightStyleElement} to the 'Roof Style' dropdown");
        }


        // This method is used for enter data in the roof pitch from building size
        public static void RoofPitchInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(RoofPitchField, value, "roof pitch");
        }

        // This method is used for get the roof pitch data
        public static string GetRoofPitchValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            return RoofPitchField().GetAttribute("value");
        }

        // This method is used for select overhang material from building size
        public static void SelectOverhangMaterial(string nameOfRoofHeightStyleElement)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Click(OverHangDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.Wait(1);
            SelectMaterialFromDropdownTagNameOfDivElement(nameOfRoofHeightStyleElement);
            ExtentTestManager.TestSteps($"Set {nameOfRoofHeightStyleElement} to the 'overhang' dropdown");
        }
        #endregion

        #region Colors
        // This method is used for click on the colors tab
        public static void ClickColors()
        {
            ClicksTab(Colors, Locator.DefaultJob.trimColor, "Colors");
        }

        // This method is used for select colors
        public static void SelectRoofColor(string roofColors)
        {
            ClickRoofColor();
            SelectMaterialFromDropdownTagNameOfSpanElement(roofColors);
            ExtentTestManager.TestSteps($"Set {roofColors} on the roof color dropdown");
        }

        // This method is used for select wall colors
        public static void SelectWallColor(string wallColors)
        {
            ClickWallColor();
            SelectMaterialFromDropdownTagNameOfSpanElement(wallColors);
            ExtentTestManager.TestSteps($"Set {wallColors} on the wall color dropdown");
        }

        // This method is used for select accent colors 3
        public static void SelectAccentColor3(string accentColor3)
        {
            ClickAccentColor3();
            SelectMaterialFromDropdownTagNameOfSpanElement(accentColor3);
            ExtentTestManager.TestSteps($"Set {accentColor3} on the accent color 3 dropdown");
        }

        // This method is used for select accent color 4
        public static void SelectAccentColor4(string accentColor4)
        {
            ClickAccentColor4();
            SelectMaterialFromDropdownTagNameOfSpanElement(accentColor4);
            ExtentTestManager.TestSteps($"Set {accentColor4} on the accent color 4 dropdown");
        }

        // This method is used for click on the roof color tab
        public static void ClickRoofColor()
        {
            ClicksTab(RoofColor, "roof color dropdown");
        }

        // This method is used for wall color tab
        public static void ClickWallColor()
        {
            ClicksTab(WallColor, "wall color dropdown");
        }

        // This method is used for select trim color
        public static void ClickTrimColor()
        {
            ClicksTab(TrimColor, "Trim color dropdown");
        }

        // This method is used for select accent color 1
        public static void ClickAccentColor1()
        {
            ClicksTab(AccentColor1, "accent color 1 dropdown");
        }

        // This method is used for select accent color 2
        public static void ClickAccentColor2()
        {
            ClicksTab(AccentColor2, "accent color 2 dropdown");
        }

        // This method is used for select accent color 3
        public static void ClickAccentColor3()
        {
            ClicksTab(AccentColor3, "accent color 3 dropdown");
        }

        // This method is used for select accent color 4
        public static void ClickAccentColor4()
        {
            ClicksTab(AccentColor4, "accent color 4 dropdown");
        }

        // This method is used for get roof color value
        public static string GetRoofColorValue()
        {
            return RoofColor().GetAttribute("title");
        }

        // This method is used for get wall color value
        public static string GetWallColorValue()
        {
            return WallColor().GetAttribute("title");
        }

        // This method is used for get trim color value
        public static string GetTrimColorValue()
        {
            return TrimColor().GetAttribute("title");
        }

        // This method is used for get accent color 1 value
        public static string GetAccentColor1Value()
        {
            return AccentColor1().GetAttribute("title");
        }

        // This method is used for get accent color 2 value
        public static string GetAccentColor2Value()
        {
            return AccentColor2().GetAttribute("title");
        }

        // This method is used for get accent color 3 value
        public static string GetAccentColor3Value()
        {
            return AccentColor3().GetAttribute("title");
        }

        // This method is used for get accent color 4 value
        public static string GetAccentColor4Value()
        {
            return AccentColor4().GetAttribute("title");
        }
        #endregion

        #region Product System
        // This method is used for click on the product system tab
        public static void ClickProductSystem()
        {
            ClicksTab(ProductSystem, "'Product System' tab");
        }

        // This method is used for click roof system
        public static void ClickRoofSystem()
        {
            ClicksTab(RoofProductSystem, "'roof System' tab");
        }

        // This method is used for select roof product system
        public static void SelectRoofProductSystem(string productSystem)
        {
            CommonMethod.GetActions().Click(RoofProductSystem()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(productSystem);
            ExtentTestManager.TestSteps($"Select {productSystem} from the roof product system");
        }

        // This method is used for get ceiling product system
        public static string GetTheCeilingProductSystemValue()
        {
            return CeilingProductSystem().GetAttribute("title");
        }
        #endregion

        #region Wainscot 

        // Clicks on the 'Wainscot' tab 
        public static void ClickWainscot()
        {
            ClicksTab(Wainscot, "'Wainscot' tab");
        }

        // Checks the 'Has Wainscot' checkbox, enabling the option for wainscot.
        public static void CheckHasWainscotCheckbox()
        {
            CheckCheckbox(HasWainscotCheckbox, "Has Wainscot");
        }

        // Unchecks the 'Has Wainscot' checkbox, disabling the option for wainscot.
        public static void UncheckHasWainscotCheckbox()
        {
            UncheckCheckbox(HasWainscotCheckbox, "Has Wainscot");
        }

        // Inputs a specified value into the 'Wainscot Height' field.
        public static void WainscotHeightInputField(string value)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.waitForTheMainBuildingElementsVisible)));
            InputFields(WainscotHeightField, value, "wainscot height");
        }

        // Selects a wainscot color/material from the dropdown by name.
        public static void SelectWainscotColorMaterial(string nameOfWainscotColorElement)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(WainscotColorDropdown()).Perform();
            SelectMaterialFromDropdownTagNameOfSpanElement(nameOfWainscotColorElement);
            ExtentTestManager.TestSteps($"Set {nameOfWainscotColorElement} to the 'Wainscot Color' dropdown");
        }
        #endregion

        #region Wall Liner       
        // Clicks on the 'Wall Liner' tab
        public static void ClickWallLiner()
        {
            ClicksTab(WallLiner, Locator.DefaultJob.waitForTheMainBuildingElementsVisible, "Wall Liner");
        }

        // Unchecks the 'Has Liner Panels' checkbox.
        public static void UncheckedTheHasLinerPanelsCheckbox()
        {
            UncheckCheckbox(HasLinerPanels, "Has Liner Panel");
        }

        // Checks the 'Has Liner Panels' checkbox
        public static void CheckedTheHasLinerPanelsCheckbox()
        {
            CheckCheckbox(HasLinerPanels, "Has Liner Panel");
        }

        // Unchecks the 'Has Interior Wainscot' checkbox
        public static void UncheckedTheHasInteriorWainscotCheckbox()
        {
            UncheckCheckbox(HasInteriorWainscot, "Has Interior Wainscot");
        }

        // Checks the 'Has Interior Wainscot' checkbox
        public static void CheckedTheHasInteriorWainscotCheckbox()
        {
            CheckCheckbox(HasInteriorWainscot, "Has Interior Wainscot");
        }

        // Selects a wall liner colors for the wall liner.
        public static void SelectWallLinerColors(string nameOfWallLinerColorsElement)
        {
            CommonMethod.GetActions().Click(WallLinerColors()).Perform();
            SelectMaterialFromDropdownTagNameOfSpanElement(nameOfWallLinerColorsElement);
            ExtentTestManager.TestSteps($"Set {nameOfWallLinerColorsElement} to the 'Wall Liner Color' dropdown");
        }

        // This method is used for the select interior trim colors
        public static void SelectInteriorTrimColors(string nameOfWallLinerColorsElement)
        {
            CommonMethod.GetActions().Click(InteriorTrimColor()).Perform();
            SelectMaterialFromDropdownTagNameOfSpanElement(nameOfWallLinerColorsElement);
            ExtentTestManager.TestSteps($"Set {nameOfWallLinerColorsElement} to the 'Wall Liner Color' dropdown");
        }

        // This method is used for the get interior trim color value
        public static string GetTheInteriorTrimColorValue()
        {
            return InteriorTrimColor().GetAttribute("value");
        }

        // This method is used for the enter wainscot height input field
        public static void InternalWainscotHeightInputField(string wainscotHeight)
        {
            InputFields(InteriorWainscotHeight, wainscotHeight, "Internal Wainscot Height");
        }
        #endregion

        #region Ceiling Liner
        // This method is used for the click on the ceiling liner tab
        public static void ClickCeilingLiner()
        {
            ClicksTab(CeilingLiner, Locator.DefaultJob.waitForTheMainBuildingElementsVisible, "Ceiling Liner");
        }

        // This method is used for the check ceiling liner checkbox
        public static void CheckFlatCeilingCheckbox()
        {
            if (!FlatCeiling().Selected)
            {
                FlatCeiling().Click();
            }

            ExtentTestManager.TestSteps("Check the 'Flat Ceiling' checkbox");
        }

        // This method is used for the uncheck the flat ceiling liner checkbox
        public static void UncheckFlatCeilingCheckbox()
        {
            if (FlatCeiling().Selected)
            {
                FlatCeiling().Click();
            }

            ExtentTestManager.TestSteps("Uncheck the 'Flat Ceiling' checkbox");
        }

        // This method is used for the cehck has ceiling liner checkbox
        public static void CheckHasCeilingCheckbox()
        {
            if (!HasCeiling().Selected)
            {
                HasCeiling().Click();
            }

            ExtentTestManager.TestSteps("Check the 'Has Ceiling' checkbox");
        }

        // This method is used for the uncheck the has ceiling liner checkbox
        public static void UncheckHasCeilingCheckbox()
        {
            if (HasCeiling().Selected)
            {
                HasCeiling().Click();
            }

            ExtentTestManager.TestSteps("Uncheck the 'Has Ceiling' checkbox");
        }

        // This method is used for the select ceiling color
        public static void SelectCeilingColorDropdown(string ceilingColor)
        {
            CommonMethod.GetActions().Click(CeilingColorDropdown()).Perform();
            SelectMaterialFromDropdownTagNameOfSpanElement(ceilingColor);
            ExtentTestManager.TestSteps($"Set {ceilingColor} to the 'ceiling color' dropdown");
        }
        #endregion

        #region Upper Sheathing
        // This method is used for the click on the upper sheathing tab
        public static void ClickUpperSheathing()
        {
            ClicksTab(UpperSheathing, Locator.DefaultJob.waitForTheMainBuildingElementsVisible, "Upper Sheathing");
        }

        // This method is used for the check has upper cheathing checkbox
        public static void CheckHasUpperSheathingCheckbox()
        {
            if (!HasUpperSheathing().Selected)
            {
                HasUpperSheathing().Click();
            }

            ExtentTestManager.TestSteps("Check the 'Has Upper Sheathing' checkbox");
        }

        // This method is used for the uncheck upper sheathing checkbox
        public static void UncheckHasUpperSheathingCheckbox()
        {
            if (HasUpperSheathing().Selected)
            {
                HasUpperSheathing().Click();
            }

            ExtentTestManager.TestSteps("Uncheck the 'Has Upper Sheathing' checkbox");
        }
        #endregion

        #endregion

        #region Details Elements
        // This method is used for the click on the details tab
        public static void ClickDetails()
        {
            ClicksTab(Details, "'details' tab");
        }

        #region Foundation 
        // This method is used for click on the foundation tab
        public static void ClickFoundation()
        {
            ClicksTab(Foundation, "'foundation' tab");
        }

        // This method is used for check the advanced post hole settings checkbox
        public static void CheckAdvancedPostHoleSettingsCheckboxCheckbox()
        {
            CheckCheckbox(AdvancedPostHoleSettingsCheckbox, "Advanced Post Hole Settings Checkbox");
        }
        #endregion

        #region Bays
        public static void ClickBays()
        {
            ClicksTab(Bays, "'bays' tab");
        }


        public static void CheckUseBaysSpacingCheckbox()
        {
            CheckCheckbox(UseBaysSpacingCheckbox, "Use Bays Spacing");
        }

        public static void UncheckUseBaysSpacingCheckbox()
        {
            UncheckCheckbox(UseBaysSpacingCheckbox, "Use Bays Spacing");
        }

        public static void SelectBaySpacing(string elementName)
        {
            CommonMethod.GetActions().Click(BaySpacing()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Bays Spacing' dropdown");
        }

        public static void SelectBayPlacement(string elementName)
        {
            CommonMethod.GetActions().Click(BayPlacement()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Bays Placement' dropdown");
        }

        #endregion

        #region Wall Trim

        public static void ClickWallTrim()
        {
            ClicksTab(WallTrim, "wall trim tab");
        }

        public static void ClickBaseTrimColorsDropdown()
        {
            ClicksTab(BaseTrimColorsDropdown, "Base Trim Colors Dropdown");
        }

        public static void SelectBaseTrimElement(string materialName)
        {
            CommonMethod.GetActions().Click(BaseTrim()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the base trim dropdown");
        }
        public static void SelectTopOfWallTrim(string materialName)
        {
            CommonMethod.GetActions().Click(TopOfWallTrim()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the base trim dropdown");
        }

        public static string GetTopOfWallTrimValue()
        {
            return TopOfWallTrim().GetAttribute("title");
        }
        #endregion

        #region Wall Girt Framing       
        public static void ClickWallGirtFraming()
        {
            ClicksTab(WallGirtFraming, "Wall Girt Framing tab");
        }

        public static void SelectGirtMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(GirtMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the girt material dropdown");
        }

        public static void SelectGirtStyle(string materialName)
        {
            CommonMethod.GetActions().Click(GirtStyle()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the girt style dropdown");
        }
        #endregion

        #region Wall Sheathing

        public static void ClickWallSheathing()
        {
            ClicksTab(WallSheathing, "wall sheathing tab");
        }

        public static string GetSheathingOffsetFromGrade()
        {
            return SheathingOffsetFromGrade().GetAttribute("value");
        }

        public static void EnterSheathingOffsetFromGrade(string value)
        {
            InputFields(SheathingOffsetFromGrade, value, "Sheathing Offset From Grade");
        }

        public static void SelectWainscotElement(string materialName)
        {
            CommonMethod.GetActions().Click(WainscotDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} element from wainscot dropdown");
        }

        public static void SelectWallMaterialElement(string materialName)
        {
            CommonMethod.GetActions().Click(WallMaterialDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} element from wall material dropdown");
        }

        public static void EnterEaveWallMargin(string value)
        {
            InputFields(EaveWallMargin, value, "Eave wall margin");
        }

        public static void EnterSheathingLengthOverrides(string value)
        {
            InputFields(SheathingLengthOverrides, value, "Sheathing Length Overrides");
        }
        public static void EnterGableWallMargin(string value)
        {
            InputFields(GableWallMargin, value, "Gable wall margin");
        }
        public static void EnterRoundSheathing(string value)
        {
            InputFields(RoundSheathing, value, "round sheathing");
        }

        public static void EnterRoundAngledSheathing(string value)
        {
            InputFields(RoundAngledSheathing, value, "round angled sheathing");
        }

        public static string GetRoundSheathingValue()
        {
            return RoundSheathing().GetAttribute("value");
        }

        public static string GetRoundAngledSheathingValue()
        {
            return RoundAngledSheathing().GetAttribute("value");
        }

        #endregion

        #region Interior Wall 

        public static void ClickInteriorWall()
        {
            ClicksTab(InteriorWall, "Interior Wall tab");
        }

        public static string GetTheSheathingSideAValue()
        {
            return SheathingSideA().GetAttribute("title");
        }
        public static string GetTheSheathingSideBValue()
        {
            return SheathingSideB().GetAttribute("title");
        }
        #endregion

        #region Roof Sheathing 
        public static void ClickRoofSheathing()
        {
            ClicksTab(RoofSheathing, "Roof Sheathing tab");
        }

        public static void ClickRoofMaterial()
        {
            ClicksTab(RoofMaterial, "Roof material tab");
        }

        public static string GetTheRoofMaterialValue()
        {
            return RoofMaterial().GetAttribute("title");
        }

        public static void SelectRoofMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(RoofMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the roof material dropdown");
        }
        #endregion

        #region Fascia And Soffit
        public static void ClickFasciaAndSoffit()
        {
            ClicksTab(FasciaAndSoffit, "Fascia And Soffit");
        }

        public static void SelectEaveFasciaMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(EaveFasciaMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the eave fascia material dropdown");
        }
        public static void SelectEaveFasciaColor(string materialName)
        {
            CommonMethod.GetActions().Click(EaveFasciaColor()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the eave fascia color dropdown");
        }

        public static void SelectGableFasciaColor(string materialName)
        {
            CommonMethod.GetActions().Click(GableFasciaColor()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the gable fascia color dropdown");
        }
        public static void SelectGableFasciaMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(GableFasciaMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the gable fascia material dropdown");
        }
        public static void SelectSoffitStyle(string materialName)
        {
            CommonMethod.GetActions().Click(SoffitStyle()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the soffit style dropdown");
        }

        public static void DoubleClickOnTheUntitled()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("jobName")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Perform();
            ExtentTestManager.TestSteps("Double Click on (Untitled) Below the Create Job ");
        }

        public static string HideConfiguredPrice()
        {
            IWebElement untitledText = Driver.FindElement(By.ClassName("jprice"));
            return untitledText.Displayed ? "Configured price is displayed" : "Configured price is not displayed";
        }

        public static void SelectEaveSoffitMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(EaveSoffitMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the eave soffit material dropdown");
        }
        public static void SelectGableSoffitMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(GableSoffitMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the gable soffit material dropdown");
        }
        public static void SelectEaveSoffitColor(string materialName)
        {
            CommonMethod.GetActions().Click(EaveSoffitColor()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the eave soffit color dropdown");
        }
        public static void SelectGableSoffitColor(string materialName)
        {
            CommonMethod.GetActions().Click(GableSoffitColor()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the gable soffit color dropdown");
        }

        public static string GetGableSoffitColorValue()
        {
            return GableSoffitColor().GetAttribute("title");
        }
        public static string GetEaveSoffitColorValue()
        {
            return EaveSoffitColor().GetAttribute("title");
        }
        public static string GetGableFasciaColorValue()
        {
            return GableFasciaColor().GetAttribute("title");
        }
        public static string GetEaveFasciaColorValue()
        {
            return EaveFasciaColor().GetAttribute("title");
        }
        #endregion

        #region Wall Framing
        public static void ClickWallFraming()
        {
            ClicksTab(WallFraming, "wall framing tab");
        }

        public static void SelectPostMaterialDropdown(string postMaterial)
        {
            CommonMethod.GetActions().Click(PostMaterialDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the post material dropdown");
        }

        public static void SelectGableWallsStyleDropdown(string elementName)
        {
            CommonMethod.GetActions().Click(GableWallsStyleDropdownForDetailsTab()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Set {elementName} to the 'Gable Walls Style' dropdown");
        }

        public static void CheckKeepOpenWallGablePostsCheckbox()
        {
            CheckCheckbox(KeepOpenWallGablePostsCheckbox, "Keep open wall gable posts");
        }

        public static void UncheckKeepOpenWallGablePostsCheckbox()
        {
            UncheckCheckbox(KeepOpenWallGablePostsCheckbox, "Keep open wall gable posts");
        }

        public static string GetPostMaterial()
        {
            return PostMaterialDropdown().GetAttribute("title");
        }

        public static void SelectWallFramingDropdown(string wallFramingMaterial)
        {
            CommonMethod.GetActions().Click(WallFramingDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(wallFramingMaterial);
            ExtentTestManager.TestSteps($"Select {wallFramingMaterial} element from the wall framing dropdown");
        }

        public static void SelectWallFramingDropdownInTheAdvancedEdit(string wallFramingMaterial)
        {
            CommonMethod.GetActions().Click(WallFramingDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(wallFramingMaterial);
            ExtentTestManager.TestSteps($"Select {wallFramingMaterial} element from the wall framing dropdown");
        }

        public static void SelectInteriorWallFramingDropdown(string interiorWallFramingMaterial)
        {
            CommonMethod.GetActions().Click(InteriorWallFramingDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(interiorWallFramingMaterial);
            ExtentTestManager.TestSteps($"Select {interiorWallFramingMaterial} element from the interior wall framing dropdown");
        }

        public static void SelectInteriorWallFramingDropdownInTheAdvancedEdit(string interiorWallFramingMaterial)
        {
            CommonMethod.GetActions().Click(InteriorWallFramingDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(interiorWallFramingMaterial);
            ExtentTestManager.TestSteps($"Select {interiorWallFramingMaterial} element from the interior wall framing dropdown");
        }

        public static string GetInteriorWallFramingValue()
        {
            return InteriorWallFramingDropdown().GetAttribute("title");
        }

        public static void SelectGablePostSpacingDropdown(string postMaterial)
        {
            CommonMethod.GetActions().Click(GablePostSpacing()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the gable post spacing dropdown");
        }

        public static void SelectGablePostPlacementDropdown(string postMaterial)
        {
            CommonMethod.GetActions().Click(GablePostPlacement()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the gable post placement dropdown");
        }

        public static void SelectPostMaterialDropdownForAdvancedEdit(string postMaterial)
        {
            CommonMethod.GetActions().Click(PostMaterialDropdown()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the post material dropdown");
        }

        public static void SelectOpenWallPostMaterial(string postMaterial)
        {
            CommonMethod.GetActions().Click(OpenWallPostMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the open wall post material dropdown");
        }

        public static string GetOpenWallPostMaterial()
        {
            return OpenWallPostMaterial().GetAttribute("title");
        }

        public static void SelectGablePostMaterial(string gablePostMaterial)
        {
            CommonMethod.GetActions().Click(GablePostMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(gablePostMaterial);
            ExtentTestManager.TestSteps($"Select {gablePostMaterial} element from the gable post material dropdown");
        }

        public static void SelectEavePostPlacementForAdvancedEdit(string postMaterial)
        {
            CommonMethod.GetActions().Click(EavePostPlacement()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(postMaterial);
            ExtentTestManager.TestSteps($"Select {postMaterial} element from the eave post placement dropdown");
        }


        #endregion

        #region Exterior Stud Framing 
        public static void ClickExteriorStudFraming()
        {
            ClicksTab(ExteriorStudFraming, "exterior stud framing tab");
        }

        public static string GetStudMaterialValue()
        {
            return StudMaterial().GetAttribute("title");
        }
        #endregion

        #region Roof Sheathing
        public static void ClickRoofFraming()
        {
            ClicksTab(RoofFraming, "Roof Framing' tab");
        }

        public static void TrussHeelHeightInputField(string value)
        {
            InputFields(TrussHeelHeight, value, "truss heel height");
        }
        #endregion

        #region Purlin Framing
        public static void ClickPurlinFraming()
        {
            ClicksTab(PurlinFraming, "'Purlin Framing' tab");
        }

        public static void SelectPurlinType(string elementName)
        {
            CommonMethod.GetActions().Click(PurlinType()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the purlin type dropdown");
        }

        public static string GetPurlinTypeValue()
        {
            return PurlinType().GetAttribute("title");
        }


        #endregion

        #region Open Wall Truss Carrier

        public static void ClickOpenWallTrussCarrier()
        {
            ClicksTab(OpenWallTrussCarrier, "open wall truss carrier tab");
        }

        public static void ClickTrussCarrierStyle()
        {
            ClicksTab(TrussCarrierStyle, "Truss Carrier Style");
        }

        public static void SelectTrussCarrierStyle(string materialName)
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(TrussCarrierStyle()).Perform();
            CommonMethod.Wait(1);
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the truss carrier style dropdown");
        }

        public static void SelectOpenWallTrussCarrierMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(OpenWallTrussCarrierMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the open wall truss carrier material dropdown");
        }
        public static void SelectOpenWallTrussCarrierBaySpan(string materialName)
        {
            CommonMethod.GetActions().Click(OpenWallTrussCarrierBaySpan()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the open wall truss carrier bay span dropdown");
        }
        public static void SelectOpenWallTopGirtMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(OpenWallTopGirtMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the Open Wall Top Girt Material material dropdown");
        }

        public static void OpenWallCarrierLengthOverridesInputField(string value)
        {
            InputFields(OpenWallCarrierLengthOverrides, value, "open wall carrier length overrides");
        }
        public static void OpenWallTopGirtLengthOverridesInputField(string value)
        {
            InputFields(OpenWallTopGirtLengthOverrides, value, "Open Wall Top Girt Length Overrides");
        }
        #endregion

        #region Trim Margins
        public static void ClickTrimMargins()
        {
            ClicksTab(TrimMargins, "Trim Margins tab");
        }

        public static void EnterEaveEdgeInputField(string value)
        {
            InputFields(EaveEdgeTrimMargins, value, "Eave Edge");
        }
        #endregion

        #region Roof Trim 
        public static void ClickRoofTrim()
        {
            ClicksTab(RoofTrim, "Roof trim tab");
        }

        public static void ClickRoofTrimForRoofingPassport()
        {
            ClicksTab(RoofTrimForRoofingPassport, "Roof trim tab");
        }

        public static void SelectRidgeCap(string materialName)
        {
            CommonMethod.GetActions().Click(RidgeCap()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the ridge cap dropdown");
        }

        public static void SelectEaveEdgeTrim(string materialName)
        {
            CommonMethod.GetActions().Click(EaveEdgeTrim()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the eave edge trim dropdown");
        }

        public static void SelectHipRidgeCap(string materialName)
        {
            CommonMethod.GetActions().Click(HipRidgeCap()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the hip ridge cap dropdown");
        }

        public static void ClickRidgeCap()
        {
            CommonMethod.GetActions().Click(RidgeCap()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the ridge cap dropdown");
        }

        public static string GetTheRidgeCapValue()
        {
            return RidgeCap().GetAttribute("title");
        }

        public static void EnterRidgeCapLengthOverrides(string value)
        {
            InputFields(RidgeCapLengthOverrides, value, "ridge cap length overrides");
        }



        #endregion

        #region Truss Carrier
        public static void ClickTrussCarrier()
        {
            ClicksTab(TrussCarrier, "Truss Carrier tab");
        }

        public static void SelectTopGirtMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(TopGirtMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the top girt material dropdown");
        }

        public static void SelectTrussCarrierMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(TrussCarrierMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the truss carrier material dropdown");
        }

        public static void ClickTrussCarrierMaterial()
        {
            ClicksTab(TrussCarrierMaterial, "Trusses carrier material");
        }


        public static void SelectTrussCarrierMaterialForTheAdvancedEdit(string materialName)
        {
            CommonMethod.GetActions().Click(TrussCarrierMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the truss carrier material dropdown");
        }

        public static string GetTopGirtMaterialValue()
        {
            return TopGirtMaterial().GetAttribute("title");
        }

        public static string GetTrussCarrierMaterialValue()
        {
            return TrussCarrierMaterial().GetAttribute("title");
        }

        public static void EnterTrussCarrierLengthOverrides(string value)
        {
            InputFields(TrussCarrierLengthOverrides, value, "Truss carrier length overrides");
        }

        #endregion

        #region Open Wall Trim 
        public static void ClickOpenWallTrim()
        {
            ClicksTab(OpenWallTrim, "open wall trim tab");
        }

        public static void SelectOpenTopOfWallTrim(string materialName)
        {
            CommonMethod.GetActions().Click(OpenTopOfWallTrim()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the open top of wall trim dropdown");
        }

        public static string GetOpenTopOfWallTrimValue()
        {
            return OpenTopOfWallTrim().GetAttribute("title");
        }

        public static void EnterOpenTopOfWallPartLengths(string value)
        {
            InputFields(OpenTopOfWallPartLengths, value, "Open top of wall");
        }

        public static void EnterOpenWallOffset(string value)
        {
            InputFields(OpenWallOffset, value, "Open wall offset");
        }
        #endregion

        #region Cladding For Roof Framing
        public static void ClickCladding()
        {
            ClicksTab(Cladding, "'Cladding' tab");
        }

        public static void EnterAngledRoofCladdingExtension(string value)
        {
            InputFields(AngledRoofCladdingExtension, value, "Angled Roof Cladding Extension");
        }

        #endregion

        #region Ceiling Liner From Details Menu

        public static void ClickCeilingLinerFromDetailsMenuList()
        {
            ClicksTab(CeilingLinerFromDetailsMenuList, "'ceiling liner' tab");
        }

        public static void SelectCeilingMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(CeilingMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the ceiling material dropdown");
        }

        public static void EnterCeilingMargin(string value)
        {
            InputFields(CeilingMargin, value, "Ceiling margin");
        }

        public static void EnterCeilingPartLengthOverrides(string value)
        {
            InputFields(CeilingPartLengthOverrides, value, "Ceiling part length overrides");
        }



        #endregion

        #endregion

        #region Door And Windows
        public static void ClickDoorAndWindow()
        {
            ClicksTab(DoorAndWindows, "door and window tab");
        }

        #region Overhead Door Post Framing
        public static void ClickOverheadDoorPostFraming()
        {
            ClicksTab(OverheadDoorPostFraming, "overhead door post framing tab");
        }

        public static void SelectJambPostMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(JambPostMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the jamb post material dropdown");
        }

        public static void CheckHeaderHighCheckbox()
        {
            if (!HeaderHighCheckbox().Selected)
            {
                HeaderHighCheckbox().Click();
            }

            ExtentTestManager.TestSteps("Check the 'Header High' checkbox");
        }

        public static void UncheckHeaderHighCheckboxCheckbox()
        {
            if (HeaderHighCheckbox().Selected)
            {
                HeaderHighCheckbox().Click();
            }

            ExtentTestManager.TestSteps("Uncheck the 'Header High' checkbox");
        }

        public static void SelectHeaderHighMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(HeaderHighMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the Header High Material dropdown");
        }

        public static void SelectHeaderHighBoundariesMaterial(string materialName)
        {
            CommonMethod.GetActions().Click(HeaderHighBoundariesMaterial()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the Header High boundaries dropdown");
        }
        #endregion

        #region WalkDoor Post Framing
        public static void ClickNonStructuralWalkdoorPostFraming()
        {
            ClicksTab(NonStructuralWalkdoorPostFraming, "Non-Structural Walkdoor Post Framing Tab");
        }

        public static void SelectJambType(string materialName)
        {
            CommonMethod.GetActions().Click(JambType()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the jamb type dropdown");
        }

        public static void SelectHeaderBoundaries(string materialName)
        {
            CommonMethod.GetActions().Click(HeaderBoundaries()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the header boundaries dropdown");
        }



        #endregion

        #region Slider Door Panel Framing
        public static void ClickSliderDoorPostFraming()
        {
            ClicksTab(SliderDoorPostFraming, "Slider door post framing tab");
        }

        public static void SelectTrackBoardForSliderDoorPostFraming(string elementName)
        {
            CommonMethod.GetActions().Click(TrackBoardForSliderDoorPostFraming()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the Track Board dropdown for Slider Door Post Framing");
        }

        public static void SelectTrackBoardExtensionForSliderDoorPostFraming(string elementName)
        {
            CommonMethod.GetActions().Click(TrackBoardExtensionForSliderDoorPostFraming()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the Track Board Extension dropdown for Slider Door Post Framing");
        }

        public static string GetTheTrackBoardExtensionMaterialName()
        {
            return TrackBoardExtensionForSliderDoorPostFraming().GetAttribute("title");
        }

        #endregion

        #endregion

        #region Packages Elements

        public static void ClickPackages()
        {
            ClicksTab(Packages, Locator.DefaultJob.waitFroThePackageElementsVisible, "package");
        }

        public static void CheckPackageCheckbox(string packageNameToFind, string xpath)
        {
            IList<IWebElement> packageRows = Driver.FindElements(By.XPath($"{xpath}[position() > 2]"));

            for (int i = 0; i <= packageRows.Count; i++)
            {
                string packageNameXPath = $"({xpath}[position() = {i + 3}]//td[2]/div)[1]";
                string packageName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(packageNameXPath))).Text;

                if (packageName.Contains(packageNameToFind))
                {
                    string checkboxXPath = $"({xpath}[position() = {i + 3}]//td[1]/div)[1]";
                    IWebElement checkboxButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(checkboxXPath)));
                    CommonMethod.GetActions().MoveToElement(checkboxButton).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
                    break;
                }
            }
        }

        public static void CheckBundleCheckbox(string packageNameToFind)
        {
            CheckPackageCheckbox(packageNameToFind, Locator.DefaultJob.checkThePackagesCheckboxForBundleList);
        }

        public static void CheckAddOnsCheckbox(string packageNameToFind)
        {
            CheckPackageCheckbox(packageNameToFind, Locator.DefaultJob.checkThePackagesCheckboxForAddOns);
        }

        public static void CheckDoorPackageCheckbox(string packageNameToFind)
        {
            CheckPackageCheckbox(packageNameToFind, Locator.DefaultJob.doorPackageCheckbox);
        }

        public static void SelectBundleAndOption(string name)
        {
            IWebElement checkboxButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.selectBundleOption, name))));
            CommonMethod.GetActions().MoveToElement(checkboxButton).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
            CommonMethod.Wait(4);
        }

        #endregion

        #region Drawing Elements

        public static void ClickDrawingButton()
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DrawingButton()).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.DefaultJob.waitForTheDrawingPanelLoad)))
            {
                CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(DrawingButton()).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheDrawingPanelLoad)));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.canvas2D)));
            }
            ExtentTestManager.TestSteps("Click on the 'Drawing' tab");
        }

        public static void ClickSheathingDrawingEXT_1()
        {
            ClicksTab(SheathingDrawingEXT_1, "Sheathing Drawing EXT_1' tab");
        }
        public static void ClickInteriorSheathingCEIL_1()
        {
            ClicksTab(InteriorSheathingCEIL_1, "'Interior Sheathing CEIL_1' tab");
        }

        public static void ClickInteriorSheathingEXT_1()
        {
            ClicksTab(InteriorSheathingEXT_1, "'Sheathing Drawing EXT_1' tab");
        }

        public static void ClickJobListButton()
        {
            ClicksTab(JobListButton, "Job List' button");
        }

        public static void ClickSheathingDrawingEXT_2()
        {
            ClicksTab(SheathingDrawingEXT_2, "'Sheathing Drawing EXT_2'");
        }

        public static void ClickSheathingDrawingEXT_3()
        {
            ClicksTab(SheathingDrawingEXT_3, "'Sheathing Drawing EXT_3' tab");
        }

        public static void ClickSheathingDrawingEXT_4()
        {
            ClicksTab(SheathingDrawingEXT_4, "'Sheathing Drawing EXT_4' tab");
        }

        public static void ClickSheathingDrawingROOF_1()
        {
            ClicksTab(SheathingDrawingROOF_1, "'Sheathing Drawing ROOF_1' tab");
        }
        public static void ClickSheathingDrawingROOF_3()
        {
            ClicksTab(SheathingDrawingROOF_3, "'Sheathing Drawing ROOF_3' tab");
        }

        public static void ClickSheathingDrawingROOF_2()
        {
            ClicksTab(SheathingDrawingROOF_2, "Sheathing Drawing ROOF_2' tab");
        }

        public static void ClickCladdingDrawingROOF_6()
        {
            ClicksTab(CladdingDrawingROOF_6, "Cladding Drawing ROOF_6' tab");
        }

        public static void ClickCladdingDrawingROOF_3()
        {
            ClicksTab(CladdingDrawingROOF_3, "Cladding Drawing ROOF_3' tab");
        }

        public static void ClickAssemblyDrawingEXT_1()
        {
            ClicksTab(AssemblyDrawingEXT_1, "'Assembly Drawing EXT_1'");
        }

        public static void ClickAssemblyDrawingEXT_2()
        {
            ClicksTab(AssemblyDrawingEXT_2, "'Assembly Drawing EXT_2'");
        }

        public static void ClickAssemblyDrawingEXT_3()
        {
            ClicksTab(AssemblyDrawingEXT_3, "'Assembly Drawing EXT_3'");
        }

        public static void ClickAssemblyDrawingEXT_4()
        {
            ClicksTab(AssemblyDrawingEXT_4, "'Assembly Drawing EXT_4'");
        }

        public static void ClickAssemblyDrawingINT_1()
        {
            ClicksTab(AssemblyDrawingINT_1, "'Assembly Drawing INT_1'");
        }

        public static void ClickAssemblyDrawingEXT_6()
        {
            ClicksTab(AssemblyDrawingEXT_6, "'Assembly Drawing EXT_6'");
        }

        public static void ClickAssemblyDrawingEXT_8()
        {
            ClicksTab(AssemblyDrawingEXT_8, "'Assembly Drawing EXT_8'");
        }

        public static void ClickAssemblyDrawingROOF_1()
        {
            ClicksTab(AssemblyDrawingROOF_1, "'Assembly Drawing ROOF_1'");
        }

        public static void ClickAssemblyDrawingROOF_2()
        {
            ClicksTab(AssemblyDrawingROOF_2, "'Assembly Drawing ROOF_2'");
        }

        public static void CheckMaterialLengthsOfSheathingDrawingTable(
            string usageName,
            string skuName,
            string materialName,
            string actualQTYValue,
            string lengthValue)
        {
            IReadOnlyList<IWebElement> exteriorWallRows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.materialNameOfAssemblyTable, usageName)));

            foreach (IWebElement row in exteriorWallRows)
            {
                CheckColumnValues(row, Locator.DefaultJob.MaterialNameOfAssemblyTableOfSKUField, skuName, "SKU");
                CheckColumnValues(row, Locator.DefaultJob.MaterialNameOfAssemblyTableOfMaterialField, materialName, "Material");
                CheckColumnValues(row, Locator.DefaultJob.materialNameOfAssemblyTableOfQTYField, actualQTYValue, "QTY");
                CheckColumnValues(row, Locator.DefaultJob.materialNameOfAssemblyTableOfLengthField, lengthValue, "Length");
            }
        }

        private static void CheckColumnValues(IWebElement row, string locator, string expectedValue, string columnName)
        {
            IReadOnlyList<IWebElement> elements = row.FindElements(By.XPath(locator));

            foreach (IWebElement element in elements)
            {
                string actualValue = element.Text;
                Assert.That(expectedValue == null || actualValue.Contains(expectedValue), $"{expectedValue} is not shown in the drawing table of {columnName} column"); ;
            }
        }

        public static void CheckSingleMaterialValueFromDrawingTable(string usage, string skuName, string materialName, string actualQTYValue, string lengthValue)
        {
            bool result = false;
            bool usageResult = false;
            bool skuResult = false;
            bool materialResult = false;
            bool qtyResult = false;
            bool lengthResult = false;

            IReadOnlyList<IWebElement> exteriorWallRows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.materialNameOfAssemblyTable, usage)));

            if (exteriorWallRows.Count.Equals(0))
            {
                Assert.Fail($"{usage} material is not shown in the table");
            }

            foreach (IWebElement element in exteriorWallRows)
            {

                if (skuName != null)
                {
                    skuResult = CheckColumnValue(element, Locator.DefaultJob.MaterialNameOfAssemblyTableOfSKUField, skuName);
                }

                if (lengthValue != null)
                {
                    lengthResult = CheckColumnValue(element, Locator.DefaultJob.materialNameOfAssemblyTableOfLengthField, lengthValue);
                }

                if (materialName != null)
                {
                    materialResult = CheckColumnValue(element, Locator.DefaultJob.MaterialNameOfAssemblyTableOfMaterialField, materialName);
                }

                if (actualQTYValue != null)
                {
                    qtyResult = CheckColumnValue(element, Locator.DefaultJob.materialNameOfAssemblyTableOfQTYField, actualQTYValue);
                }

                if (lengthResult || qtyResult || materialResult || skuResult || usageResult)
                {
                    VerifyColumnValue(lengthResult, lengthValue, "length");
                    VerifyColumnValue(qtyResult, actualQTYValue, "quantity");
                    VerifyColumnValue(materialResult, materialName, "material");
                    VerifyColumnValue(skuResult, skuName, "sku");
                    result = true;
                    break;
                }
            }

            Assert.That(result, Is.True, $"{usage} material is not shown in the table");
        }

        public static void CheckMaterialValueFromSheathingDrawingTable(string usage, string skuName, string materialName, string actualQTYValue, string lengthValue)
        {
            bool result = false;
            bool usageResult = false;
            bool skuResult = false;
            bool materialResult = false;
            bool qtyResult = false;
            bool lengthResult = false;

            int usageCount = 0;
            int skuCount = 0;
            int materialCount = 0;
            int qtyCount = 0;
            int lengthCount = 0;

            IReadOnlyList<IWebElement> exteriorWallRows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.materialNameOfAssemblyTable, usage)));

            if (exteriorWallRows.Count.Equals(0))
            {
                Assert.Fail($"{usage} material is not shown in the table");
            }

            foreach (IWebElement element in exteriorWallRows)
            {

                if (usage != null)
                {
                    usageResult = CheckColumnValue(element, Locator.DefaultJob.materialNameOfSheathingDrawingTableOfUsageField, usage);
                    usageCount++;
                }

                if (skuName != null)
                {
                    skuResult = CheckColumnValue(element, Locator.DefaultJob.MaterialNameOfAssemblyTableOfSKUField, skuName);
                    skuCount++;
                }

                if (lengthValue != null)
                {
                    lengthResult = CheckColumnValue(element, Locator.DefaultJob.materialNameOfAssemblyTableOfLengthField, lengthValue);
                    lengthCount++;
                }

                if (materialName != null)
                {
                    materialResult = CheckColumnValue(element, Locator.DefaultJob.MaterialNameOfAssemblyTableOfMaterialField, materialName);
                    materialCount++;
                }

                if (actualQTYValue != null)
                {
                    qtyResult = CheckColumnValue(element, Locator.DefaultJob.materialNameOfAssemblyTableOfQTYField, actualQTYValue);
                    qtyCount++;
                }
            }

            if (exteriorWallRows.Equals(usageCount) || usage == null && exteriorWallRows.Equals(skuCount)
               || skuName == null && exteriorWallRows.Equals(lengthCount) || lengthValue == null && exteriorWallRows.Equals(materialCount)
              || materialName == null && exteriorWallRows.Equals(qtyCount) || actualQTYValue == null)
            {
                result = true;
            }

            Assert.That(result, Is.True, $"{usage} material is not shown in the table");
        }

        private static bool CheckColumnValue(IWebElement row, string columnXPath, string expectedValue)
        {
            IReadOnlyList<IWebElement> columnCells = row.FindElements(By.XPath(columnXPath));
            foreach (IWebElement cell in columnCells)
            {
                string values = cell.Text;
                if (values.Contains(expectedValue) || expectedValue == null)
                {
                    return true;
                }
            }
            return false;
        }

        private static void VerifyColumnValue(bool result, string expectedValue, string columnName)
        {
            Assert.That(string.IsNullOrEmpty(expectedValue) || result, $"{expectedValue} is not shown in the drawing table of {columnName} column");
        }

        public static void CheckMaterialIsNotShownInTheJobReview(string usageName)
        {
            IList<IWebElement> listOfMaterials = Driver.FindElements(By.XPath(string.Format("//tr[contains(@id,'grid_MaterialsGrid_rec_')]//td[@col='1']//div[text()='{0}']", usageName)));

            if (!listOfMaterials.Count.Equals(0))
            {
                Assert.Fail($"{usageName} is shown in the job review");
            }
        }

        public static void CheckMaterialIsNotShownInTheDrawing(string usageName)
        {
            IList<IWebElement> listOfMaterials = Driver.FindElements(By.XPath(string.Format("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_')]//td[@col='2']//div[text()='{0}']", usageName)));

            if (!listOfMaterials.Count.Equals(0))
            {
                Assert.Fail($"{usageName} is shown in the drawing");
            }
        }
        #endregion

        #region Divider Wall

        public static void ClickDividerWall()
        {
            ClicksTab(DividerWall, Locator.CommonXPath.waitForPopupVisible, "Divider Wall");
        }

        public static string GetTheSideAValue()
        {
            return SideA().GetAttribute("title");
        }
        public static string GetTheSideBValue()
        {
            return SideB().GetAttribute("title");
        }

        public static void SelectSideAElement(string elementName)
        {
            CommonMethod.GetActions().Click(SideA()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the side a dropdown");
        }

        public static void SelectSideBElement(string elementName)
        {
            CommonMethod.GetActions().Click(SideB()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(elementName);
            ExtentTestManager.TestSteps($"Select {elementName} from the side b dropdown");
        }
        #endregion

        #region Job Fields

        public static void ClicksJobButton()
        {
            ClicksTab(JobButton, Locator.DefaultJob.waitForTheJobElementsVisible, "job button");
        }

        public static void EnterJobNameInputField(string value)
        {
            CommonMethod.GetActions().Click(EnterJobNameField()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the job name field");
        }
        #endregion

        #region Save Buttons

        public static void ClicksSaveButton()
        {
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(SaveButton()).Perform();
            CommonMethod.PageLoaderForSaveButton();
            ExtentTestManager.TestSteps($"Click on the save button");
        }

        public static void ClicksSaveButtonAndYesButtonPop()
        {
            CommonMethod.GetActions().Click(SaveButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ClickYesButton();
            CommonMethod.PageLoaderForSaveButton();
            ExtentTestManager.TestSteps($"Click on the save button");
        }
        #endregion

        #region Outputs

        public static void ClicksOutputButton()
        {
            if (!SaveButton().Enabled)
            {
                ClicksSaveButton();
            }

            ClickOutputButtonWithRetry();
            ExtentTestManager.TestSteps($"Click on the outputs button");
        }

        private static void ClickOutputButtonWithRetry()
        {
            ClickOutputButton();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.WaitForTheOutputsElementVisible)));

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.DefaultJob.WaitForTheOutputsElementVisible)))
            {
                ClickOutputButton();
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.WaitForTheOutputsElementVisible)));
            }

            // Unchecked the all checkboxes from the output popup
            IReadOnlyList<IWebElement> checkboxes = Driver.FindElements(By.XPath(Locator.DefaultJob.UncheckAllCheckFromOutputs));
            foreach (IWebElement checkbox in checkboxes)
            {
                // Check if the checkbox is selected
                if (checkbox.Selected)
                {
                    checkbox.Click();
                }
            }
        }

        private static void ClickOutputButton()
        {
            CommonMethod.GetActions().Click(OutputButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        public static void CheckOutputsCheckbox(string nameOfCheckbox)
        {
            IWebElement outputCheckboxes = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.CheckTheOutputCheckbox, nameOfCheckbox))));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(outputCheckboxes).Perform();
            ExtentTestManager.TestSteps($"Check the {nameOfCheckbox} checkbox");
        }


        public static void ClicksDownloadButton()
        {
            CommonMethod.GetActions().Click(DownloadButtonOfOutputsTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the download button");
        }

        public static string CheckDataFromPDFFiles(string pdfFilePath)
        {
            using (PdfReader pdfReader = new(pdfFilePath))
            {
                using (PdfDocument pdfDocument = new(pdfReader))
                {
                    StringBuilder text = new();

                    for (int pageNumber = 1; pageNumber <= pdfDocument.GetNumberOfPages(); pageNumber++)
                    {
                        SimpleTextExtractionStrategy strategy = new();
                        string pageContent = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy); // Parse the content of each page
                        text.Append(pageContent);
                    }

                    string allPagesText = text.ToString();

                    return allPagesText;
                }
            }
        }

        public static void DownloadFileFromOutputFrame(string checkboxName)
        {
            ClicksOutputButton();
            CheckOutputsCheckbox(checkboxName);
            ClicksDownloadButton();
        }
        #endregion

        #region Changes View

        public static void ClickChangeView()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
            CommonMethod.Wait(1);
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", ChangeView());
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.waitForTheChangesViewLocators)));
            ExtentTestManager.TestSteps($"Click on the change view button");
        }

        public static void ChangeViewFrontLeft()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.FrontLeft))).Click();
            ExtentTestManager.TestSteps($"Click on the Front Left");
        }

        public static void ChangePlanView()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.planView))).Click();
            ExtentTestManager.TestSteps($"Click on the plan view");
        }

        public static void ChangeViewFrontRight()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.FrontRight))).Click();
            ExtentTestManager.TestSteps($"Click on the Front Right");
        }

        public static void ChangeViewLeftElevation()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.LeftElevation))).Click();
            ExtentTestManager.TestSteps($"Click on the Left Elevation");
        }

        public static void ChangeViewFrontElevation()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.FrontElevation))).Click();
            ExtentTestManager.TestSteps($"Click on the Front Elevation");
        }

        public static void ChangeViewBackLeft()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.BackLeft))).Click();
            ExtentTestManager.TestSteps($"Click on the Back Left");
        }

        public static void ChangeViewBackRight()
        {
            ClickChangeView();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.BackRight))).Click();
            ExtentTestManager.TestSteps($"Click on the Back Right");
        }
        #endregion

        #region Advanced Edit

        public static void ClickAdvancedEdit()
        {
            ClicksTab(AdvancedEdit, "advanced edit tab");
        }
        public static void ClickROOF_1()
        {
            ClicksTab(ROOF_1, "ROOF_1 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickLOFT_1()
        {
            ClicksTab(LOFT_1, "LOFT_1 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickLOFT_2()
        {
            ClicksTab(LOFT_2, "LOFT_1 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }

        public static void ClickROOF_2()
        {
            ClicksTab(ROOF_2, "ROOF_2 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickEXT_1()
        {
            ClicksTab(EXT_1, "EXT_1 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickEXT_2()
        {
            ClicksTab(EXT_2, "EXT_2 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickEXT_3()
        {
            ClicksTab(EXT_3, "EXT_3 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }

        public static void ClickEXT_4()
        {
            ClicksTab(EXT_4, "EXT_4 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }
        public static void ClickINT_1()
        {
            ClicksTab(INT_1, "INT_1 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }

        public static void ClickEXT_6()
        {
            ClicksTab(EXT_6, "EXT_6 tab");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
        }

        public static void SelectRoofColorFromAdvancedEdit(string roofColors)
        {
            ClickRoofColor();
            SelectMaterialFromDropdownTagNameOfTDElement(roofColors);
            ExtentTestManager.TestSteps($"Set {roofColors} on the roof color dropdown");
        }

        public static void SelectWallColorFromAdvancedEdit(string wallColors)
        {
            ClickWallColor();
            SelectMaterialFromDropdownTagNameOfTDElement(wallColors);
            ExtentTestManager.TestSteps($"Set {wallColors} on the wall color dropdown");
        }

        public static void SelectAccentColor1FromAdvancedEdit(string accentColor1)
        {
            ClickAccentColor1();
            SelectMaterialFromDropdownTagNameOfTDElement(accentColor1);
            ExtentTestManager.TestSteps($"Set {accentColor1} on the accent color 1 dropdown");
        }

        public static void SelectAccentColor2FromAdvancedEdit(string accentColor2)
        {
            ClickAccentColor2();
            SelectMaterialFromDropdownTagNameOfTDElement(accentColor2);
            ExtentTestManager.TestSteps($"Set {accentColor2} on the accent color 2 dropdown");
        }

        public static void SelectAccentColor3FromAdvancedEdit(string accentColor3)
        {
            ClickAccentColor3();
            SelectMaterialFromDropdownTagNameOfTDElement(accentColor3);
            ExtentTestManager.TestSteps($"Set {accentColor3} on the accent color 3 dropdown");
        }

        public static void SelectAccentColor4FromAdvancedEdit(string accentColor4)
        {
            ClickAccentColor4();
            SelectMaterialFromDropdownTagNameOfTDElement(accentColor4);
            ExtentTestManager.TestSteps($"Set {accentColor4} on the accent color 4 dropdown");
        }
        #endregion

        #region Apply button of advanced frame of roof style building size

        public static void ClickAdvancedFrameApplyButton()
        {
            ClicksTab(AdvancedFrameApplyButton, "apply button");
        }
        #endregion

        #region Roofing Passport
        public static void SelectionDropdown(string materialName)
        {
            CommonMethod.GetActions().Click(SelectionDropdownOfRoofingPassport()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfTDElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the selection dropdown");
        }

        public static void ClickSaveChangesButton()
        {
            ClicksTab(SaveChangesButton, "Save Changes Button");
        }

        public static void ClickColorTabOfRoofingPassportFromAdvancedEdit()
        {
            ClicksTab(ColorTabOfRoofingPassportFromAdvancedEdit, "Color tab");
        }

        public static void SelectRoofSystemDropdownOfRoofingPassport(string materialName)
        {
            CommonMethod.GetActions().Click(RoofSystemDropdownOfRoofingPassport()).Pause(TimeSpan.FromSeconds(1)).Perform();
            SelectMaterialFromDropdownTagNameOfDivElement(materialName);
            ExtentTestManager.TestSteps($"Select {materialName} from the roof system dropdown");
        }

        public static void StatusChangeButtonButton(string name)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.jobReviewElementTabSelector, name))));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the {name} button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space()='Confirmation']")));
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Yes']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps("Click on the Yes pop of button");
        }
        #endregion

        #region Job Review 
        public static void ClickJobReview()
        {
            ClicksTab(JobReview, Locator.DefaultJob.summary, "job review button");
        }

        public static void JobReviewButton(string jobElement)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.jobReviewTabSelection, jobElement))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the " + jobElement);
        }

        public static void ClickCladdingOfJobReview()
        {
            ClicksTab(CladdingOfJobReview, "Cladding tab");
        }

        public static void ClickTestWalkDoor()
        {
            ClicksTab(TestWalkDoorOfJobReview, "test walkDoor button");
        }

        public static void ClickTestOverhead()
        {
            ClicksTab(TestOverheadOfJobReview, "test overhead button");
        }

        public static void ClickTestSlider()
        {
            ClicksTab(TestSliderOfJobReview, "test slider button");
        }

        public static void ClickTestWindow()
        {
            ClicksTab(TestWindowOfJobReview, "test window button");
        }

        public static void ClickTrussesOfJobReview()
        {
            ClicksTab(TrussesOfJobReview, "trusses tab");
        }
        public static void ClickAddToTrussTableButton()
        {
            ClicksTab(AddToTrussTableButton, "add to truss table button tab");
        }

        public static string ClickJobReviewTabAndGetAllData(string jobReviewTabName)
        {
            string xpath;
            switch (jobReviewTabName)
            {
                case "Summary":
                    ClickSummaryOfJobReview();
                    xpath = "//div[@id='grid_SummaryGrid_records']";
                    break;
                case "Framing":
                    ClickFramingOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                case "Sheathing":
                    ClickSheathingOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                case "Trim":
                    ClickTrimOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                case "Doors & Windows":
                    ClickDoorAndWindowOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                case "Accessories":
                    ClickAccessoriesOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                case "Trusses":
                    ClickTrussesOfJobReview();
                    xpath = "//div[@id='grid_MaterialsGrid_records']";
                    break;
                default:
                    throw new ArgumentException("Invalid job review tab name", nameof(jobReviewTabName));
            }

            return GetElementTextByXPath(xpath);
        }

        private static string GetElementTextByXPath(string xpath)
        {
            return GetWebDriverWait()
                   .Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)))
                   .Text;
        }



        public static void ClickFixTrussesButtonOfTrussesTable(string elementName)
        {
            CommonMethod.GetActions().Click(FixTrussesButton(elementName)).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the i button of {elementName} element");
        }

        public static void ClickApplyButton()
        {
            CommonMethod.GetActions().Click(ApplyButton()).Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the apply button");
        }

        public static void ClickTrimOfJobReview()
        {
            ClicksTab(TrimOfJobReview, "Trim tab");
        }
        public static void ClickSheathingOfJobReview()
        {
            ClicksTab(SheathingOfJobReview, "sheathing tab");
        }
        public static void ClickFramingOfJobReview()
        {
            ClicksTab(FramingOfJobReview, "Framing tab");
        }
        public static void ClickAccessoriesOfJobReview()
        {
            ClicksTab(AccessoriesOfJobReview, "Accessories tab");
        }
        public static void ClickSummaryOfJobReview()
        {
            ClicksTab(SummaryOfJobReview, "Summary tab");
        }
        public static void ClickLaborOfJobReview()
        {
            ClicksTab(LaborOfJobReview, "Labor tab");
        }
        public static void ClickFreightOfJobReview()
        {
            ClicksTab(FreightOfJobReview, "Freight tab");
        }
        public static void ClickDoorAndWindowOfJobReview()
        {
            ClicksTab(DoorAndWindowOfJobReview, "Door and Window tab");
        }

        public static string GetTheSKUInputFieldOfFixTruss()
        {
            return SKUInputFieldOfFixTruss().GetAttribute("value");
        }

        public static string GeTheFirstElementFromDropdown(Func<IWebElement> methodName, string tagName)
        {
            CommonMethod.GetActions().Click(methodName()).Pause(TimeSpan.FromSeconds(1)).Perform();
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//div[@id='w2ui-overlay']//tr[@index='0']//{tagName}"))).Text;
        }

        public static void SKUInputFieldOfFixTruss(string value)
        {
            SKUInputFieldOfFixTruss().Click();
            CommonMethod.GetActions().Click(SKUInputFieldOfFixTruss()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(value + Keys.Enter).Perform();
            ExtentTestManager.TestSteps($"Enter {value} in the sku field");
        }
        public static void CheckMaterialsDataFromJobReviewAndDoubleClickOnTheMaterial(
   string tableName,
   string usageName,
   string sku,
   string material,
   string color,
   string angle,
   string quantity,
   string unit,
   string length,
   string cost,
   string price)
        {
            bool skuResult = false;
            bool materialResult = false;
            bool colorResult = false;
            bool angleResult = false;
            bool quantityResult = false;
            bool unitResult = false;
            bool lengthResult = false;
            bool costResult = false;
            bool priceResult = false;
            bool result = false;

            IReadOnlyList<IWebElement> rows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.GetTheTotalRowOfTable, usageName)));

            if (rows.Count.Equals(0))
            {
                Assert.Fail($"{usageName} material is not shown in the {tableName} table");
            }

            foreach (IWebElement element in rows)
            {

                if (sku != null)
                {
                    skuResult = CheckColumnValueOfJobReview(element, "2", sku);
                }

                if (material != null)
                {
                    materialResult = CheckColumnValueOfJobReview(element, "3", material);
                }

                if (color != null)
                {
                    colorResult = CheckColumnValueOfJobReview(element, "4", color);
                }

                if (angle != null)
                {
                    angleResult = CheckColumnValueOfJobReview(element, "5", color);
                }

                if (quantity != null)
                {
                    quantityResult = CheckColumnValueOfJobReview(element, "6", quantity);
                }

                if (unit != null)
                {
                    unitResult = CheckColumnValueOfJobReview(element, "7", unit);
                }

                if (length != null)
                {
                    lengthResult = CheckColumnValueOfJobReview(element, "8", length);
                }

                if (cost != null)
                {
                    costResult = CheckColumnValueOfJobReview(element, "12", cost);
                }

                if (price != null)
                {
                    priceResult = CheckColumnValueOfJobReview(element, "13", price);
                }

                if (skuResult || materialResult || colorResult || angleResult || quantityResult || unitResult || lengthResult || costResult || priceResult)
                {
                    VerifyMaterialValueFromJobReview(skuResult, tableName, "sku", usageName, sku);
                    VerifyMaterialValueFromJobReview(materialResult, tableName, "material", usageName, material);
                    VerifyMaterialValueFromJobReview(colorResult, tableName, "color", usageName, color);
                    VerifyMaterialValueFromJobReview(angleResult, tableName, "angle", usageName, angle);
                    VerifyMaterialValueFromJobReview(quantityResult, tableName, "quantity", usageName, quantity);
                    VerifyMaterialValueFromJobReview(unitResult, tableName, "unit", usageName, unit);
                    VerifyMaterialValueFromJobReview(lengthResult, tableName, "length", usageName, length);
                    VerifyMaterialValueFromJobReview(costResult, tableName, "cost", usageName, cost);
                    VerifyMaterialValueFromJobReview(priceResult, tableName, "price", usageName, price);
                    CommonMethod.GetActions().DoubleClick(element).Perform();
                    result = true;
                    break;
                }
            }

            Assert.That(result, Is.True, $"{usageName} material is not shown in the {tableName} table");
        }
        public static void CheckMaterialsDataFromJobReview(
    string tableName,
    string usageName,
    string sku,
    string material,
    string color,
    string angle,
    string quantity,
    string unit,
    string length,
    string cost,
    string price)
        {
            bool usageResult = false;
            bool skuResult = false;
            bool materialResult = false;
            bool colorResult = false;
            bool angleResult = false;
            bool quantityResult = false;
            bool unitResult = false;
            bool lengthResult = false;
            bool costResult = false;
            bool priceResult = false;
            bool result = false;

            IReadOnlyList<IWebElement> rows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.GetTheTotalRowOfTable, usageName)));

            if (rows.Count.Equals(0))
            {
                Assert.Fail($"{usageName} material is not shown in the {tableName} table");
            }

            foreach (IWebElement element in rows)
            {
                if (usageName != null)
                {
                    usageResult = CheckColumnValueOfJobReview(element, "1", usageName);
                }

                if (sku != null)
                {
                    skuResult = CheckColumnValueOfJobReview(element, "2", sku);
                }

                if (material != null)
                {
                    materialResult = CheckColumnValueOfJobReview(element, "3", material);
                }

                if (color != null)
                {
                    colorResult = CheckColumnValueOfJobReview(element, "4", color);
                }

                if (angle != null)
                {
                    angleResult = CheckColumnValueOfJobReview(element, "5", color);
                }

                if (quantity != null)
                {
                    quantityResult = CheckColumnValueOfJobReview(element, "6", quantity);
                }

                if (unit != null)
                {
                    unitResult = CheckColumnValueOfJobReview(element, "7", unit);
                }

                if (length != null)
                {
                    lengthResult = CheckColumnValueOfJobReview(element, "8", length);
                }

                if (cost != null)
                {
                    costResult = CheckColumnValueOfJobReview(element, "12", cost);
                }

                if (price != null)
                {
                    priceResult = CheckColumnValueOfJobReview(element, "13", price);
                }

                if (usageResult && skuResult || materialResult || colorResult || angleResult || quantityResult || unitResult || lengthResult || costResult || priceResult)
                {
                    VerifyMaterialValueFromJobReview(skuResult, tableName, "sku", usageName, sku);
                    VerifyMaterialValueFromJobReview(materialResult, tableName, "material", usageName, material);
                    VerifyMaterialValueFromJobReview(colorResult, tableName, "color", usageName, color);
                    VerifyMaterialValueFromJobReview(angleResult, tableName, "angle", usageName, angle);
                    VerifyMaterialValueFromJobReview(quantityResult, tableName, "quantity", usageName, quantity);
                    VerifyMaterialValueFromJobReview(unitResult, tableName, "unit", usageName, unit);
                    VerifyMaterialValueFromJobReview(lengthResult, tableName, "length", usageName, length);
                    VerifyMaterialValueFromJobReview(costResult, tableName, "cost", usageName, cost);
                    VerifyMaterialValueFromJobReview(priceResult, tableName, "price", usageName, price);
                    CommonMethod.GetActions().DoubleClick(element).Perform();

                    try
                    {
                        CommonMethod.element = Driver.FindElement(By.XPath("//td[text()='Delete']"));
                        CommonMethod.GetActions().Click(CommonMethod.element).Perform();
                    }
                    catch (StaleElementReferenceException)
                    {
                        CommonMethod.element = Driver.FindElement(By.XPath("//td[text()='Delete']"));
                        CommonMethod.GetActions().Click(CommonMethod.element).Perform();
                    }

                    result = true;
                    break;
                }
            }

            Assert.That(result, Is.True, $"{usageName} material is not shown in the {tableName} table");
        }

        public static void CheckUsageShownInTheJobReview(string tableName, string usageName)
        {
            IReadOnlyList<IWebElement> rows = Driver.FindElements(By.XPath(string.Format(Locator.DefaultJob.GetTheTotalRowOfTable, usageName)));

            if (rows.Count.Equals(0))
            {
                Assert.Fail($"{usageName} material is not shown in the {tableName} table");
            }
        }


        private static bool CheckColumnValueOfJobReview(IWebElement row, string columnXPath, string expectedValue)
        {
            IReadOnlyList<IWebElement> columnCells = row.FindElements(By.XPath(string.Format(Locator.DefaultJob.getTheColumnNumber, columnXPath)));
            foreach (IWebElement cell in columnCells)
            {
                string values = cell.Text;
                if (values.Contains(expectedValue) || string.IsNullOrEmpty(expectedValue))
                {
                    return true;
                }
            }
            return false;
        }

        private static void VerifyMaterialValueFromJobReview(bool result, string tableName, string columnName, string usageName, string expectedResult)
        {
            Assert.That(string.IsNullOrEmpty(expectedResult) || result, $"{usageName} material is not shown in the {tableName}, {expectedResult} is not shown in the {columnName}");
        }
        #endregion

        #region Opening Elements


        // This method is usedd for the select opening doors
        public static void SelectOpeningDoor(string opening, string styleName, string doorName)
        {
            OpeningDoorsSelection(opening);
            SelectStyleAndOpeningElement(styleName, doorName);
        }

        public static void EnterQuotedInputField(string value)
        {
            InputFields(QuotedInputField, value, "quoted field");
        }

        public static void OpeningDoorsSelection(string opening)
        {
            CommonMethod.GetActions().Click(Opening()).Perform();

            if (!CommonMethod.IsElementPresent(By.XPath(Locator.DefaultJob.WalkDoor)))
            {
                CommonMethod.GetActions().Click(Opening()).Perform();
            }
            ExtentTestManager.TestSteps("Click on the opening");

            switch (opening)
            {
                case "WalkDoor":
                    CommonMethod.GetActions().Click(WalkDoor()).Perform();
                    ExtentTestManager.TestSteps("Click on the walkdoor");
                    break;
                case "Overhead":
                    CommonMethod.GetActions().Click(Overhead()).Perform();
                    ExtentTestManager.TestSteps("Click on the overhead door");
                    break;
                case "Windows":
                    CommonMethod.GetActions().Click(Windows()).Perform();
                    ExtentTestManager.TestSteps("Click on the windows");
                    break;
                case "Slider":
                    CommonMethod.GetActions().Click(Sliders()).Perform();
                    ExtentTestManager.TestSteps("Click on the Slider");
                    break;
            }
        }

        public static void SelectSideSliderPopup(string locationOfSide)
        {
            string xpath = $"//div[@class='dropdown-content side-content']//button[normalize-space()='{locationOfSide}']";
            CommonMethod.GetActions().Click(SideFieldOfSlider()).Pause(TimeSpan.FromSeconds(2)).Perform();
            CommonMethod.Wait(3);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            CommonMethod.GetActions().Click(CommonMethod.element).Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps($"Selected {locationOfSide} from the side dropdown of slider");
        }

        public static string GetWidthOfOpening()
        {
            return WidthFieldOfSlider().GetAttribute("value");
        }

        public static string GetHeightOfOpening()
        {
            return HeightFieldOfSlider().GetAttribute("value");
        }
        public static string GetSideOfOpening()
        {
            return SideFieldOfSlider().GetAttribute("value");
        }

        public static void SelectStandardStyle()
        {
            CommonMethod.GetActions().Click(SelectAStyle()).Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Select A Style");
            CommonMethod.GetActions().Click(SelectStandardSlider()).Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Select Standard Slider");
        }


        public static void EnterSillHeight(string value)
        {
            InputFields(SillHeight, value, "Sill Height");
        }

        public static string GetSillHeightValue()
        {
            return SillHeight().GetAttribute("value");
        }
        public static string GetDistanceInputFieldOfOpeningValue()
        {
            return DistanceInputFieldOfOpening().GetAttribute("value");
        }
        public static string GetLocationOpeningOfOpeningValue()
        {
            return LocationOpening().GetAttribute("value");
        }

        public static void SelectLocationOpening(string elementName)
        {
            CommonMethod.GetActions().Click(LocationOpening()).Pause(TimeSpan.FromSeconds(2)).Perform();
            CommonMethod.GetActions().Click(SelectLocation(elementName)).Pause(TimeSpan.FromSeconds(2)).Perform();

        }

        public static void EnterDistance(string value)
        {
            InputFields(DistanceInputFieldOfOpening, value, "Distance");
        }


        public static void ClickUpdateButtonFrom2DView()
        {
            ClicksTab(UpdateButtonOf2DView, "Update");
        }

        public static void ClickUpdateButtonOfLoft()
        {
            ClicksTab(UpdateButtonOfLoft, "Update");
        }

        public static void ClickUpdateButtonOfWall()
        {
            ClicksTab(UpdateButtonOfWall, "Update");
        }

        public static void ClickUpdateButtonFrom3DView()
        {
            ClicksTab(UpdateButtonOf3DView, "Update");
        }

        public static void SaveButtonOf2DView()
        {
            CommonMethod.GetActions().MoveToElement(ReturnButton()).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Return button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@id='Yes'])[1]")));
            CommonMethod.GetActions().MoveToElement(YesButton()).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the yes button");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        public static void ClickReturnButton()
        {
            CommonMethod.GetActions().MoveToElement(ReturnButton()).Click().Pause(TimeSpan.FromSeconds(2)).Perform();
            ExtentTestManager.TestSteps("Click on the Return button");
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));
        }


        public static void SelectStyleAndOpeningElement(string styleName, string doorName)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(SelectStyleFromDoors(styleName)).Perform();
            ExtentTestManager.TestSteps($"Click on the {styleName}");
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(SelectOpeningDoors(doorName)).Perform();
            ExtentTestManager.TestSteps($"Click on the {doorName}");
        }

        public static void ClickSelectAStyleTabAndSelectSubElement(string styleName)
        {
            CommonMethod.GetActions().Click(SelectStyle()).Perform();
            ExtentTestManager.TestSteps($"Click on the style a style tab");
            CommonMethod.GetActions().Click(SelectStyleFromDoors(styleName)).Perform();
            ExtentTestManager.TestSteps($"Click on the {styleName}");
        }

        public static void ClickWalkdoorOfAddOns()
        {
            CommonMethod.GetActions().Click(WalkdoorOfAddOns()).Perform();
            ExtentTestManager.TestSteps($"Click on the Add ons");
        }

        public static IWebElement ClickAddButtonOfAddOns()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.plusButtonOfAddOns)));
        }

        public static void AddDoorFromAddOnsElement(string descriptionName)
        {
            CommonMethod.ExecuteJavaScript().ExecuteScript("arguments[0].click();", ClickAddButtonOfAddOns());
            ExtentTestManager.TestSteps("Click on the plus(+) icon of default job");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.materialName, descriptionName))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the {descriptionName}");
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.addItemButton)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps("Click on the plus(+) icon of default job");
            CommonMethod.Wait(2);
        }


        public static void PlaceOpeningOnTheCanvasBuilding(string styleName, string doorName, int x_axis, int y_axis)
        {
            SelectStyleAndOpeningElement(styleName, doorName);
            PlaceOpening(x_axis, y_axis);
        }
        #endregion

        #region Cupola 
        public static void ClickCupolas()
        {
            ClicksTab(Cupolas, "'cupolas' tab");
        }
        #endregion

        #region Move to canvas building 
        public static void ChangeViewOfBuildingOf3DCanvas(int x, int y)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).ClickAndHold().MoveByOffset(x, y).Release().Perform();
        }
        public static void ChangeViewOfBuildingOf2DCanvas(int x, int y)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).ClickAndHold().MoveByOffset(x, y).Release().Perform();
        }
        #endregion

        #region Capture Screenshot Method
        public static void CaptureScreenShotOfCanvasBuilding(string tagName, string location, string captureScreenShot, string imageName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.captureImageSelector, tagName, location))));
            CommonMethod.Wait(2);

            Screenshot elementScreenshot = ((ITakesScreenshot)CommonMethod.element).GetScreenshot();
            string imagePath = $@"{captureScreenShot}\{imageName}";
            elementScreenshot.SaveAsFile(imagePath);
        }
        #endregion

        #region Changes the Job Status 
        public static void ChangeStatusOfJob(string buttonName)
        {
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(StatusButton(buttonName)).Perform();
            ExtentTestManager.TestSteps($"Click on the '{buttonName}' tab");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(YesButton()).Perform();
            ExtentTestManager.TestSteps($"Click on the 'yes' button");
        }
        #endregion

        #region Add Miscellaneous Elements
        public static void ClickAddMiscellaneousButton()
        {
            ClicksTab(AddMiscButton, Locator.CommonXPath.waitForPopupVisible, "add misc button");
        }

        public static void ClickAddCatalogButton()
        {
            ClicksTab(AddCatalogButton, Locator.CommonXPath.waitForPopupVisible, "add catalog button");
        }

        public static void SelectCatalogCategory(string catalogCategory)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForPopupVisible)));
            CommonMethod.Wait(1);
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Click(CatalogCategory()).Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForDropdownElementVisible)));
            SelectMaterialFromDropdownTagNameOfTDElement(catalogCategory);
            ExtentTestManager.TestSteps($"Select {catalogCategory} from the catalog category dropdown");
        }

        public static void ClickCatalogItem()
        {
            ClicksTab(CatalogItem, "catalog item");
        }

        public static void EnterUsageOfMiscInputField(string value)
        {
            InputFields(UsageOfMiscInputField, value, "usage");
        }

        public static void EnterSKUOfMiscInputField(string value)
        {
            InputFields(SKUOfMiscInputField, value, "sku");
        }

        public static void EnterCostOfMiscInputField(string value)
        {
            InputFields(CostOfMiscInputField, value, "cost");
        }

        public static void EnterPriceOfMiscInputField(string value)
        {
            InputFields(PriceOfMiscInputField, value, "price");
        }

        public static void EnterMaterialOfMiscInputField(string value)
        {
            InputFields(MaterialOfMiscInputField, value, "material");
        }

        public static void EnterCalculationOfMiscInputField(string value)
        {
            InputFields(CalculationOfMiscInputField, value, "calculation");
        }

        public static void ClickCurlyBracketsButton()
        {
            ClicksTab(CurlyBracketsButton, "Curly bracket button");
        }

        public static void ClickSaveButtonOfMisc()
        {
            ClicksTab(SaveButtonOfMisc, "Save button");
        }

        public static void SearchElementInTheMisc(string searchElementName)
        {
            ClickCurlyBracketsButton();
            CommonMethod.GetActions().Click(SearchElementInTheMiscTable()).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys(searchElementName + Keys.Enter).Perform();
            CommonMethod.GetActions().Click(FirstRowOfCalculationTable()).Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.GetActions().Click(AddButtonOfMisc()).Pause(TimeSpan.FromSeconds(1)).Perform();
        }
        #endregion

        #region This methods used for Validation of Production in the Advanced edit      
        public static void VerifyThatProductSystemShow()
        {
            string productSystem = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Product Systems'])[1]"))).Text;
            Assert.That(productSystem, Is.EqualTo("Product Systems"));
        }
        public static void VerifyThatColorsShow()
        {
            string colors = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Colors'])[1]"))).Text;
            Assert.That(colors, Is.EqualTo("Colors"));
        }
        public static void VerifyThatWainscotShow()
        {
            string wainscot = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Wainscot'])[1]"))).Text;
            Assert.That(wainscot, Is.EqualTo("Wainscot"));
        }
        public static void VerifyThatUpperSheathing()
        {
            string upperSheathing = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Upper Sheathing'])[1]"))).Text;
            Assert.That(upperSheathing, Is.EqualTo("Upper Sheathing"));
        }
        public static void VerifyThatCeilingLinerShow()
        {
            string ceilingLiner = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Ceiling Liner'])[1]"))).Text;
            Assert.That(ceilingLiner, Is.EqualTo("Ceiling Liner"));
        }
        public static void VerifyThatWallLinerShow()
        {
            string wallLiner = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Wall Liner'])[1]"))).Text;
            Assert.That(wallLiner, Is.EqualTo("Wall Liner"));
        }
        #endregion

        // This method is used for the click on the open wall button
        public static void ClickOpenWallButton()
        {
            ClicksTab(OpenWallButton, "'Open Wall' tab");
        }

        // This method is used for the click cross icon
        public static void ClickCrossIcon()
        {
            IWebElement crossIcon = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.crossIcon)));
            CommonMethod.GetActions().Click(crossIcon).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        // This method is used for the click on the 3D Edit button
        public static void Click3DEdit()
        {
            IWebElement edit3D = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.click3DEditButton)));
            CommonMethod.GetActions().Click(edit3D).Pause(TimeSpan.FromSeconds(1)).Perform();
        }
        public static void ClickView3DEdit()
        {
            IWebElement edit3D = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.clickView3DButton)));
            CommonMethod.GetActions().Click(edit3D).Pause(TimeSpan.FromSeconds(1)).Perform();
        }

        // This method is used for the get the error massage 
        public static void ClickServerErrorMessageButton()
        {
            CommonMethod.GetActions().Click(ServerErrorMessageButton()).Perform();
        }

        // This method is used for the click 3D view button
        public static void ClickCanvas3DViewButton()
        {
            ClicksTab(Canvas3DViewButton, Locator.DefaultJob.Canvas3DBuilding, "'Canvas 3D View'");
        }

        // This method is used for the server delay (Volume button) 
        public static void ServerDelay()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ServerDelay)));
            CommonMethod.GetActions().DragAndDropToOffset(CommonMethod.element, 0, 15).Release().Perform();
        }

        // This method is used for the click on the home button
        public static void ClickHomeButton()
        {
            ClicksTab(HomeButton, "home button");
        }

        // This method ise used for the click on the No button from confirmation popup
        public static void ClickNoButton()
        {
            ClicksTab(NoButton, "No button");
        }

        // This method ise used for the click on the yes button from confirmation popup
        public static void ClickYesButton()
        {
            ClicksTab(YesButton, "Yes button");
        }

        // This method ise used for the click on the roof button from footer section
        public static void ClickRoofButton()
        {
            ClicksTab(RoofButton, "roof button");
        }

        // This method ise used for the click on the sync button from footer section
        public static void ClickSyncButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.SyncButton))).Click();
        }

        // This method ise used for the click on the shell button from footer section
        public static void ClicksShellButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.shellButton))).Click();
        }

        // This method is used for the capture screenshot
        public static void CaptureScreenShot(string folderName, string imageName)
        {
            Screenshot fullPage = ((ITakesScreenshot)Driver).GetScreenshot();
            string fileName = $@"{folderName}/{imageName}";
            fullPage.SaveAsFile(fileName);
        }

        // This method is used for the capture screenshot of advanced edit
        public static void CaptureScreenShotOfAdvanced(string folderName, string imageName)
        {
            IWebElement advanced = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.advancedPageElement)));
            Screenshot fullPage = ((ITakesScreenshot)advanced).GetScreenshot();
            string fileName = $@"{folderName}/{imageName}";
            fullPage.SaveAsFile(fileName);
        }

        public static IWebElement ConfiguredPrice()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.ConfiguredPrice)));
        }

        public static string GetTheConfiguredPrice()
        {
            return ConfiguredPrice().Text;
        }

        public static void PageLoaderForApplyElementOnCanvas2DBuilding()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
                CommonMethod.Wait(1);

                if (CommonMethod.IsElementPresent(By.XPath(Locator.CommonXPath.waitForTheSpinner)))
                {
                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
                    GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
                }

                string errorMessage = Driver.FindElement(By.XPath(Locator.DefaultJob.ErrorMessagePopup)).Text;
                Console.WriteLine(errorMessage);
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas2DBuilding)));
            }
        }

        // This method is used for the wait for the page load for canvas 2D view
        public static void PageLoaderFor2D()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.canvas2D)));
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.canvas2D)));
            }
        }

        // This method is used for the navigate to home page
        public static bool NavigateToHomePage()
        {
            try
            {
                Driver.Navigate().GoToUrl(TestContext.Parameters.Get("HomePageURL"));
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ClickAndHold(int xPosition)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("drawingArea")));
            CommonMethod.GetActions().ClickAndHold(CommonMethod.element).MoveByOffset(-xPosition, 0).Release().Perform();
        }

        // This method is used for the check data shown in the job review section
        public static void VerifyDataShownInTheJobReview(string[] targetLengths, string wallName, string partLength, string num)
        {
            IWebElement tableData = Driver.FindElement(By.XPath(Locator.DefaultJob.getTheDataOfJobReview));
            IList<IWebElement> tableTr = tableData.FindElements(By.TagName("tr"));
            var rowCountForJob = tableTr.Count();

            bool found = false;

            for (int i = 3; i <= rowCountForJob; i++)
            {
                string usageName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.getTheRows, i, 1)))).Text;

                if (usageName.Contains(wallName))
                {
                    foreach (string targetLength in targetLengths)
                    {
                        string length = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.getTheRows, i, num)))).Text;
                        string material = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.getTheRows, i, 3)))).Text;

                        if (length == targetLength.ToString() && material.Contains(partLength))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found)
                {
                    break;
                }
            }

            Assert.That(found, Is.True, $"{partLength} is not shown in the job review");
        }

        // This method is used for the check material shown in the drawing table
        public static bool CheckTheMaterialShownInTheDrawingOfAssembly(string materialUsagesName)
        {
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.getTheDataOfTableFromAssembly)));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    string usagesName = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheColumnDataOfTableFromAssembly, lineNumber, 2))).Text;

                    if (usagesName.Equals(materialUsagesName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // This method is used to check calculation of quantity is match with the material length
        public static void CheckTheCalculationOfQuantityFromDrawingTable(string materialUsagesName, string materialNameOfTruss, int lengthOfMaterial, string styleName)
        {
            IList<int> ints = new List<int>();
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.getTheDataOfTableFromAssembly)));

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    string usagesName = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheColumnDataOfTableFromAssembly, lineNumber, 2))).Text;

                    if (usagesName.Equals(materialUsagesName))
                    {
                        string material = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheColumnDataOfTableFromAssembly, lineNumber, 4))).Text;
                        Assert.That(material, Is.EqualTo(materialNameOfTruss), $"{styleName} length is not match with {lengthOfMaterial}");
                        string qty = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheColumnDataOfTableFromAssembly, lineNumber, 5))).Text;
                        string length = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheColumnDataOfTableFromAssembly, lineNumber, 6))).Text;
                        int qtyInt = int.Parse(qty.Replace("'", " "));
                        int lengthInt = int.Parse(length.Replace("'", " "));
                        int cal = qtyInt * lengthInt;
                        ints.Add(cal);
                    }
                }
            }

            int sum = ints.Sum();

            // Check truss material quantity is match with length
            if (sum != lengthOfMaterial)
            {
                Assert.Fail($"{styleName} length is not match with {lengthOfMaterial}");
            }
        }
        public static void DoubleClickOnPrice()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.totalPrice)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Perform();
        }

        // This method is used for the get the data from job review section
        public static string GetTheDataFromTheJobReview(string jobElement, string getTableData)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.jobReviewTabSelection, jobElement))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps($"Click on the {jobElement}");
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(Locator.DefaultJob.getTheDataFromJobReviewTable, getTableData)))).Text;
        }

        // This method is used for the check invalid data shown in the job review section
        public static void CheckInvalidMaterialLengthInTheJobReview(string materialUsagesName, string skuUsagesName, string material)
        {
            IWebElement table = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.getTheDataOfJobReview)));
            bool results = false;

            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                string lineNumber = row.GetAttribute("line");
                int number;

                if (int.TryParse(lineNumber, out number) && number > 0)
                {
                    string usagesName = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheRowsOfJobReview, lineNumber, 1))).Text;
                    string skuName = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheRowsOfJobReview, lineNumber, 2))).Text;

                    if (usagesName.Equals(materialUsagesName) && skuName.Equals(skuUsagesName))
                    {
                        results = true;
                        string materialLengthStyle = row.FindElement(By.XPath(string.Format(Locator.DefaultJob.getTheRowsOfJobReview, lineNumber, 2))).GetAttribute("style");
                        Assert.That(materialLengthStyle, Is.EqualTo("color: red;"));
                        ExtentTestManager.TestSteps($"Verify that the selected {material} material length is not shown in the Framing data.");
                        break;
                    }
                }
            }

            Assert.That(results, Is.True, $"Verify that the invalid {material} material length is not shown in the Framing data.");
        }
    }
}