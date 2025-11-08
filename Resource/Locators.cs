

namespace SmartBuildAutomation.Locators
{
    public static class Locator
    {
        public static class CommonXPath
        {
            public static string waitForTheSpinner = "//div[@class='w2ui-spinner']";
            public static string waitForSpinnerLoad = "//div[@class='w2ui-lock-msg']";
            public static string waitForDropdownElementVisible = "//div[@id='w2ui-overlay']";
            public static string waitForPopupVisible = "//div[@id='w2ui-popup']";
            public static string selectValueFromDropdown = "//div[@id='w2ui-overlay']//tr//td[1]";
            public static string signInButton = "(//span[text()='Sign in'])[2]";
            public static string emailInputField = "//input[contains(@type,'email')]";
            public static string nextButton = "(//div[@id='identifierNext']//div)[1]//button";
            public static string passwordInputField = "//input[contains(@type,'password')]";
            public static string nextButtons = "//span[contains(text(),'Next')]";
        }

        public static class LoginPage
        {
            public static string username = "//input[@name='Username']";
            public static string password = "//input[@name='Password']";
            public static string rememberMeCheckbox = "(//input[@name='RememberMe'])[1]";
            public static string loginButton = "(//input[@type='submit'])[1]";
        }

        public static class HomePage
        {
            // Start Scratch Button
            public static string startFromScratch = "//a[normalize-space()='Start from Scratch']";

            // Admin
            public static string admin = "//a[normalize-space()='Admin']";
            public static string distributors = "//a[normalize-space()='Distributors']";
            public static string distributorsOutputs = "//a[normalize-space()='Distributor Outputs']";
            public static string reports = "//a[normalize-space()='Reports']";
            public static string telemetry = "//a[normalize-space()='Telemetry']";
            public static string performance = "//a[normalize-space()='Performance']";
            public static string billingFromAdmin = "(//a[normalize-space()='Billing'])[1]";
            public static string checkData = "//a[normalize-space()='Check Data']";
            public static string taaSStatus = "//a[normalize-space()='TaaS Status']";
            public static string cannedPackages = "//a[normalize-space()='Canned Packages']";
            public static string oBJLibrary = "//a[normalize-space()='OBJ Library']";
            public static string textureLibraryFromAdmin = "(//a[normalize-space()='Texture Library'])[1]";
            public static string pushDisclaimer = "//a[normalize-space()='Push Disclaimer']";

            //Setting
            public static string settings = "//a[normalize-space()='Settings']";
            public static string customize = "//a[normalize-space()='Customize']";
            public static string eModeler = "//a[normalize-space()='eModeler']";
            public static string setupWizard = "//a[normalize-space()='Setup Wizard']";
            public static string outputCategories = "//a[normalize-space()='Output Categories']";
            public static string builders = "//a[normalize-space()='Builders']";
            public static string colors = "//a[normalize-space()='Colors']";
            public static string materials = "//a[normalize-space()='Materials']";
            public static string textureLibraryFromSetting = "(//a[normalize-space()='Texture Library'])[2]";
            public static string doorsAndWindows = "//a[normalize-space()='Doors and Windows']";
            public static string spanTables = "//a[normalize-space()='Span Tables']";
            public static string productSystems = "//a[normalize-space()='Product Systems']";
            public static string trusses = "//a[normalize-space()='Trusses']";
            public static string pricing = "//a[normalize-space()='Pricing']";
            public static string specialPricing = "//a[normalize-space()='Special Pricing']";
            public static string paymentSchedule = "//a[normalize-space()='Payment Schedule']";
            public static string framingRules = "//a[normalize-space()='Framing Rules']";
            public static string packages = "//a[normalize-space()='Packages']";
            public static string startingModels = "//a[normalize-space()='Starting Models']";
            public static string outputs = "//a[normalize-space()='Outputs']";
            public static string billingFromSetting = "(//a[normalize-space()='Billing'])[2]";

            // Header
            public static string homeTab = "//a[normalize-space()='Home']";
            public static string jobTab = "//a[normalize-space()='Jobs']";
            public static string aboutTab = "//a[normalize-space()='About']";
            public static string contactTab = "//a[normalize-space()='Contact']";
            public static string supportButton = "//button[text()='Support']";
            public static string manageTab = "//a[@title='Manage']";

            // Staring Model Jobs
            public static string smoke20x20x10 = "//span[normalize-space()='Smoke20x20x10']";
            public static string medPerformance = "//span[normalize-space()='Med Performance']";
            public static string lrgPerformanceTest = "//span[normalize-space()='LRG Performance Test']";
            public static string largeCross = "//span[normalize-space()='Large Cross']";
            public static string grandchildOpeningAddon = "//span[normalize-space()='Grandchild Opening Addon']";
            public static string job30x40x16 = "//span[normalize-space()='30x40x16']";
            public static string gambrelRoof = "//span[normalize-space()='Gambrel Roof']";
            public static string template2 = "//span[normalize-space()='Template 2']";
            public static string template3 = "//span[normalize-space()='Template 3']";
            public static string template4 = "//span[normalize-space()='Template 4']";
            public static string woodFlrAndPeakOut = "//span[normalize-space()='Wood Flr & Peak Out']";
            public static string inlineBuilding20x40 = "//span[normalize-space()='20x40 Inline Building']";
            public static string girtsOutsideCorners = "//span[normalize-space()='Girts Outside Corners']";
            public static string girtsOutsidePost = "//span[normalize-space()='Girts Outside Post']";
            public static string studFrame30x60 = "//span[normalize-space()='30x60 Stud Frame']";
            public static string cantPorchAttachedBuilding = "//span[normalize-space()='Cant Prch Attached Building']";
            public static string advancedEdits = "//span[normalize-space()='Advan Edits 1']";
            public static string parallelSteelTrusses = "//span[normalize-space()='Parallel Steel Trusses']";
            public static string barndominium = "//span[normalize-space()='Barndominium']";
            public static string overFramedRafterShed = "//span[normalize-space()='Over Framed Rafter Shed']";
            public static string getTheSettingListElement = "(//ul[@class='dropdown-menu'])[2]";
        }

        public static class DefaultJob
        {
            // Main Building Locators
            public static string mainBuilding = "//div[@id='form_myForm_tabs']//div[normalize-space()='MainBuilding']";
            // Building Size
            public static string waitForTheMainBuildingElementsVisible = "//div[@class='w2ui-page page-0']//div[@class='w2ui-group group-expand']";
            public static string buildingSizeSubMenuTab = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Building Size']";
            public static string buildingSizeOfBuildingSize = "(//div[@class='w2ui-page page-0']//label[text()='Building Size']//following::div[2])[1]";
            public static string measureFromOfBuildingSize = "(//div[@class='w2ui-page page-0']//label[text()='Measure From']//following::div[2])[1]";
            public static string widthInputFieldOfBuildingSize = "(//div[@class='w2ui-page page-0']//div[text()='Building Size']//following::input[@name='Width'])[1]";
            public static string lengthInputFieldOfBuildingSize = "(//div[@class='w2ui-page page-0']//div[text()='Building Size']//following::input[@name='Length'])[1]";
            public static string roofHeightStyleOfBuildingSize = "(//div[@class='w2ui-page page-0']//label[text()='Roof Height Style']//following::div[2])[1]";
            public static string ceilingHeightInputFieldOfBuildingSize = "(//div[@class='w2ui-page page-0']//div[text()='Building Size']//following::input[@name='CeilingHeight'])[1]";
            public static string exteriorMetalHeightInputFieldOfBuildingSize = "(//div[@class='w2ui-page page-0']//div[text()='Building Size']//following::input[@name='EaveHeight'])[1]";
            public static string roofStyleOfBuildingSize = "(//div[@class='w2ui-page page-0']//label[text()='Roof Style']//following::div[2])[1]";
            public static string styleOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Style']//following::div[2]";
            public static string slopeOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Slope']//following::input[@name='Slope']";
            public static string leftSlopeOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Left Slope']//following::input[@name='Slope']";
            public static string rightSlopeOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Right Slope']//following::input[@name='Slope2']";
            public static string upperSlopeOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Upper Slope']//following::input[@name='Slope']";
            public static string lowerSlopeOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Lower Slope']//following::input[@name='Slope2']";
            public static string offsetToCurbOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Offset to Curb']//following::input[@name='OffsetStr']";
            public static string offsetToPeakOfRoofStyleAdvanced = "//div[@id='roofDetailsForm']//label[text()='Offset to Peak']//following::input[@name='OffsetStr']";
            public static string advancedPageElement = "//div[@id='w2ui-overlay-roofDetailsDialog']";
            public static string advancedFrameApplyButton = "//div[@id='w2ui-overlay-roofDetailsDialog']//button[@name='Apply']";
            public static string roofPitchInputFieldOfBuildingSize = "(//div[@class='w2ui-page page-0']//div[text()='Building Size']//following::input[@name='Slope'])[1]";
            public static string overhangOfBuildingSize = "(//div[@class='w2ui-page page-0']//label[text()='Overhangs']//following::div[2])[1]";
            public static string selectOverhang = "//div[@id='w2ui-overlay']//tr[@index='{0}']";
            // Colors
            public static string colors = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Colors']";
            public static string roofColor = "(//label[text()='Roof Color']//following::div[2])[1]";
            public static string wallColor = "(//div[@class='w2ui-page page-0']//label[text()='Wall Color']//following::div[2])[1]";
            public static string trimColor = "(//div[@class='w2ui-page page-0']//label[text()='Trim Color']//following::div[2])[1]";
            public static string accentColor1 = "(//div[@class='w2ui-page page-0']//label[text()='Accent Color 1']//following::div[2])[1]";
            public static string accentColor2 = "(//div[@class='w2ui-page page-0']//label[text()='Accent Color 2']//following::div[2])[1]";
            public static string accentColor3 = "(//div[@class='w2ui-page page-0']//label[text()='Accent Color 3']//following::div[2])[1]";
            public static string accentColor4 = "(//div[@class='w2ui-page page-0']//label[text()='Accent Color 4']//following::div[2])[1]";
            public static string dropdownElements = "(//div[@class='w2ui-page page-0']//label[text()='{0}']//following::div[2])[1]";
            // Wainscot
            public static string wainscot = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Wainscot']";
            public static string hasWainscotCheckbox = "(//div[@class='w2ui-group group-expand']//label[text()='Has Wainscot']//following::input[@name='HasWainscot'])[1]";
            public static string wainscotHeightField = "(//div[@class='w2ui-group group-expand']//label[text()='Wainscot Height']//following::input[@name='WainscotHeight'])[1]";
            public static string wainscotColorDropdown = "(//div[@class='w2ui-page page-0']//label[text()='Wainscot Color']//following::div[2])[1]";
            // Wall Liner
            public static string wallLiner = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Wall Liner']";
            public static string hasLinerPanelsCheckbox = "(//label[text()='Has Liner Panels']//following::input[@name='InternalHasLiner'])[1]";
            public static string wallLinerColors = "(//label[text()='Wall Liner Color']//following::input[@name='InternalWallColor'])[1]";
            public static string interiorTrimColor = "(//label[text()='Interior Trim Color']//following::input[@name='InternalTrimColor'])[1]";
            public static string hasInteriorWainscotCheckbox = "(//label[text()='Has Interior Wainscot']//following::input[@name='InternalHasWainscot'])[1]";
            public static string interiorWainscotHeight = "(//label[text()='Interior Wainscot Height']//following::input[@name='InternalWainscotHeight'])[1]";
            public static string interiorWainscotColor = "(//label[text()='Interior Wainscot Color']//following::input[@name='InternalWainscotColor'])[1]";
            // Ceiling Liner
            public static string ceilingLiner = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Ceiling Liner']";
            public static string hasCeiling = "(//label[text()='Has Ceiling']//following::input[@name='HasCeiling'])[1]";
            public static string flatCeiling = "(//label[text()='Flat Ceiling']//following::input[@name='FlatCeiling'])[1]";
            public static string ceilingColorDropdown = "(//label[text()='Ceiling Color']//following::div[2])[1]";
            public static string ceilingTrimColorDropdown = "(//label[text()='Ceiling Trim Color']//following::div[2])[1]";
            // Product System 
            public static string productSystem = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Product Systems']";
            public static string mainProductSystem = "(//label[text()='Main Product System']//following::div[2])[1]";
            public static string roofProductSystem = "(//label[text()='Roof Product System']//following::div[2])[1]";
            public static string ceilingProductSystem = "(//label[text()='Ceiling Product System']//following::div[2])[1]";
            // Upper Sheathing
            public static string upperSheathing = "(//div[@class='w2ui-page page-0'])[1]//div[text()='Upper Sheathing']";
            public static string hasUpperSheathing = "(//label[text()='Has Upper Sheathing']//following::input[@name='HasUpperSheathing'])[1]";
            public static string upperSheathingHeight = "(//label[text()='Upper Sheathing Height']//following::input[@name='UpperSheathingHeight'])[1]";
            public static string upperSheathingColors = "(//label[text()='Upper Sheathing Color']//following::div[2])[1]";

            // Details
            public static string detailsButton = "//div[@id='form_myForm_tabs']//div[text()='Details']";
            //Cladding Roof Framing 
            public static string cladding = "(//div[@class='w2ui-page page-3'])[1]//div[text()='Cladding']";
            public static string angledRoofCladdingExtension = "(//label[text()='Angled Roof Cladding Extension']//following::input[@id='AngledRoofMargin'])[1]";
            // Foundation
            public static string foundation = "(//div[@class='w2ui-page page-2']//div[text()='Foundation'])[1]";
            public static string advancedPostHoleSettingsCheckbox = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Advanced Post Hole Settings']//following::input[@name='FoundationAdvanced'])[1]";
            // Bays
            public static string bays = "(//div[@class='w2ui-page page-2']//div[text()='Bays'])[1]";
            public static string useBaysSpacingCheckbox = "(//label[text()='Use Bay Spacing']//following::input[@name='BaySpacingEnabled'])[1]";
            public static string baySpacing = "(//label[text()='Bay Spacing']//following::div[2])[1]";
            public static string bayPlacement = "(//label[text()='Bay Placement']//following::div[2])[1]";
            // Wall Trim Elements
            public static string wallTrim = "(//div[@class='w2ui-page page-2'])[1]//div[text()='Wall Trim']";
            public static string baseTrimColors = "(//div[@class='w2ui-page page-2']//label[text()='Base Trim Color']//following::div[2])[1]";
            public static string baseTrim = "(//div[@class='w2ui-page page-2']//label[text()='Base Trim']//following::div[2])[1]";
            public static string topOfWallTrim = "(//label[text()='Top of Wall Trim']//following::div[2])[1]";
            // Wall Girt Framing 
            public static string wallGirtFraming = "(//div[@class='w2ui-page page-2'])[1]//div[text()='Wall Girt Framing']";
            public static string girtMaterial = "(//label[text()='Girt Material']//following::div[2])[1]";
            public static string girtStyle = "(//label[text()='Girt Style']//following::div[2])[1]";
            // Fascia and Soffit
            public static string fasciaAndSoffit = "(//div[@class='w2ui-page page-2'])[1]//div[text()='Fascia and Soffit']";
            public static string eaveFasciaMaterial = "(//div[@class='w2ui-page page-2']//label[text()='Eave Fascia Material']//following::div[2])[1]";
            public static string gableFasciaMaterial = "(//div[@class='w2ui-page page-2']//label[text()='Gable Fascia Material']//following::div[2])[1]";
            public static string eaveFasciaColor = "(//div[@class='w2ui-page page-2']//label[text()='Eave Fascia Color']//following::div[2])[1]";
            public static string gableFasciaColor = "(//div[@class='w2ui-page page-2']//label[text()='Gable Fascia Color']//following::div[2])[1]";
            public static string soffitStyle = "(//div[@class='w2ui-page page-2']//label[text()='Soffit Style']//following::div[2])[1]";
            public static string eaveSoffitMaterial = "(//div[@class='w2ui-page page-2']//label[text()='Eave Soffit Material']//following::div[2])[1]";
            public static string gableSoffitMaterial = "(//div[@class='w2ui-page page-2']//label[text()='Gable Soffit Material']//following::div[2])[1]";
            public static string eaveSoffitColor = "(//div[@class='w2ui-page page-2']//label[text()='Eave Soffit Color']//following::div[2])[1]";
            public static string gableSoffitColor = "(//div[@class='w2ui-page page-2']//label[text()='Gable Soffit Color']//following::div[2])[1]";
            // Wall Sheathing 
            public static string wallSheathing = "(//div[@class='w2ui-page page-2']//div[text()='Wall Sheathing'])[1]";
            public static string wainscotOfWallSheathing = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Wainscot']//following::div[2])[1]";
            public static string sheathingLengthOverrides = "(//label[text()='Sheathing Length Overrides']//following::input[@name='ExteriorWallPartLengths'])[1]";
            public static string wallMaterialOfWallSheathing = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Wall Material']//following::div[2])[1]";
            public static string eaveWallMargin = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Eave Wall Margin']//following::input[@name='EaveWallMargin'])[1]";
            public static string gableWallMargin = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Gable Wall Margin']//following::input[@name='GableWallMargin'])[1]";
            public static string roundSheathing = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Round Sheathing']//following::input[@name='SheathingRound'])[1]";
            public static string roundAngledSheathing = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Round Angled Sheathing']//following::input[@name='AngledSheathingRound'])[1]";
            public static string sheathingOffsetFromGrade = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Sheathing Offset From Grade']//following::input[@id='WallSheathingVerticalOffset'])[1]";
            //Roof Sheathing
            public static string roofSheathing = "(//div[@class='w2ui-page page-2']//div[text()='Roof Sheathing'])[1]";
            public static string roofMaterial = "(//label[text()='Roof Material']//following::div[2])[1]";
            // Interior Wall
            public static string interiorWall = "(//div[@class='w2ui-page page-2']//div[text()='Interior Walls'])[1]";
            public static string sheathingSideA = "(//label[text()='Sheathing Side A'])[1]//following::div[2]";
            public static string sheathingSideB = "(//label[text()='Sheathing Side B'])[1]//following::div[2]";
            // Wall Framing 
            public static string wallFraming = "(//div[@class='w2ui-page page-2']//div[text()='Wall Framing'])[1]";
            public static string keepOpenWallGablePostsCheckbox = "(//label[text()='Keep Open Wall Gable Posts']//following::input[@name='KeepOpenWallGablePosts'])[1]";
            public static string postMaterialDropdown = "(//label[text()='Post Material']//following::div[2])[1]";
            public static string wallFramingDropdown = "(//label[text()='Wall Framing']//following::div[2])[1]";
            public static string interiorWallFramingDropdown = "(//label[text()='Interior Wall Framing']//following::div[2])[1]";
            public static string openWallPostMaterial = "(//label[text()='Open Wall Post Material'])[1]//following::div[2]";
            public static string gablePostMaterial = "(//label[text()='Gable Post Material'])[1]//following::div[2]";
            public static string eavePostPlacement = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Eave Post Placement']//following::div[2])[1]";
            public static string gablePostSpacing = "(//label[text()='Gable Post Spacing']//following::div[2])[1]";
            public static string gablePostPlacement = "(//label[text()='Gable Post Placement']//following::div[2])[1]";
            // Exterior Stud Framing
            public static string exteriorStudFraming = "(//div[@class='w2ui-page page-2']//div[text()='Exterior Stud Framing'])[1]";
            public static string studMaterial = "(//label[text()='Stud Material']//following::div[2])[1]";
            // Roof Framing 
            public static string roofFraming = "(//div[@class='w2ui-page page-2']//div[text()='Roof Framing'])[1]";
            public static string trussHeelHeight = "(//label[text()='Truss Heel Height']//following::input[@name='HeelHeight'])[1]";
            // Purlin Framing 
            public static string purlinFraming = "(//div[@class='w2ui-page page-2']//div[text()='Purlin Framing'])[1]";
            public static string purlinType = "(//label[text()='Purlin Type']//following::div[2])[1]";
           //Trim Margins
           public static string trimMargins = "(//div[@class='w2ui-page page-2']//div[text()='Trim Margins'])[1]";
           public static string eaveEdgeTrimMargins = "(//label[text()='Eave Edge']//following::input[@id='EaveEdgeTrimMargin'])[1]";
            // Roof Trim 
            public static string roofTrimForRoofingPassport = "(//div[@class='w2ui-page page-3']//div[text()='Roof Trim'])[1]";
            public static string roofTrim = "(//div[@class='w2ui-page page-2']//div[text()='Roof Trim'])[1]";
            public static string ridgeCap = "(//label[text()='Ridge Cap']//following::div[2])[1]";
            public static string ridgeCapLengthOverrides = "(//div[@class='w2ui-group group-expand']//label[text()='Ridge Cap Length Overrides']//following::input[@name='RidgeCapPartLengths'])[1]";
            public static string eaveEdgeTrim = "(//div[@class='w2ui-group group-expand']//label[text()='Eave Edge Trim']//following::div[2])[1]";
            public static string hipRidgeCap = "(//div[@class='w2ui-group group-expand']//label[text()='Hip Ridge Cap']//following::div[2])[1]";
            // Open Wall Truss Carrier
            public static string openWallTrussCarrier = "(//div[@class='w2ui-page page-2']//div[text()='Open Wall Truss Carrier'])[1]";
            public static string trussCarrierStyle = "(//div[@class='w2ui-group group-expand']//label[text()='Truss Carrier Style']//following::div[2])[1]";
            public static string openWallTrussCarrierMaterial = "(//label[text()='Open Wall Truss Carrier Material']//following::div[2])[1]";
            public static string openWallTrussCarrierBaySpan = "(//label[text()='Open Wall Carrier Bay Span']//following::div[2])[1]";
            public static string openWallCarrierLengthOverrides = "(//label[contains(text(),'Open Wall Carrier Length Overrides')])[1]//following::input[1]";
            public static string openWallTopGirtMaterial = "(//div[@class='w2ui-group group-expand']//label[text()='Open Wall Top Girt Material']//following::div[2])[1]";
            public static string openWallTopGirtLengthOverrides = "(//label[contains(text(),'Open Wall Top Girt Length Overrides')])[1]//following::input[1]  ";
            // Truss Carrier
            public static string trussCarrier = "(//div[@class='w2ui-page page-2']//div[text()='Truss Carrier'])[1]";
            public static string topGirtMaterial = "(//div[@class='w2ui-group group-expand']//label[text()='Top Girt Material']//following::div[2])[1]";
            public static string trussCarrierMaterial = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Truss Carrier Material']//following::div[2])[1]";
            public static string trussCarrierLengthOverrides = "(//label[text()='Truss Carrier Length Overrides']//following::input[@name='TrussBearerPartLengths'])[1]";
            // Open Wall Trim
            public static string openWallTrim = "(//div[@class='w2ui-page page-2']//div[text()='Open Wall Trim'])[1]";
            public static string openTopOfWallTrim = "(//label[text()='Open Top of Wall Trim']//following::div[2])[1]";
            public static string openTopOfWallPartLengths = "(//label[text()='Open Top of Wall Length Overrides']//following::input[@name='OpenTopOfWallPartLengths'])[1]";
            public static string openWallOffset = "(//label[text()='Open Wall Offset']//following::input[@name='OpenWallOffset'])[1]";
            // Ceiling Liner
            public static string ceilingLinerOfDetailsMenuList = "(//div[@class='w2ui-page page-2']//div[text()='Ceiling Liner'])[1]";
            public static string ceilingMaterial = "(//label[text()='Ceiling Material']//following::div[2])[1]";
            public static string ceilingMargin = "(//label[text()='Ceiling Margin']//following::input[@name='CeilingMargin'])[1]";
            public static string ceilingPartLengthOverrides = "(//label[text()='Ceiling Part Length Overrides']//following::input[@name='InteriorRoofPartLengths'])[1]";

            // Door And Window
            public static string doorAndWindows = "//td[@id='tabs_myForm_tabs_tab_tab4']//div[normalize-space()='Door andWindow']";
            // Overhead Door Post Framing
            public static string jambPostMaterial = "//div[@class='w2ui-group group-expand']//label[text()='Jamb Post Material']//following::div[2]";
            public static string overheadDoorPostFraming = "(//div[@class='w2ui-page page-3'])[1]//div[text()='Overhead Door Post Framing']";
            public static string headerHighCheckbox = "(//label[text()='Header High']//following::input[@name='OHDoorHeaderHigh'])[1]";
            public static string headerHighMaterial = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Header High Material'])[2]//following::div[2]";
            public static string sliderDoorPostFraming = "(//div[text()='Sliding Door Post Framing'])[1]";
            public static string trackBoardForSliderDoorPostFraming = "(//label[text()='Track Board']//following::div[2])[1]";
            public static string trackBoardExtensionForSliderDoorPostFraming = "(//label[text()='Track Board Extension']//following::div[2])[1]";
            public static string headerHighBoundariesMaterial = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Header High boundaries'])[2]//following::div[2]";
            // WalkDoor Post Framing
            public static string nonStructuralWalkdoorPostFraming = "(//div[@class='w2ui-page page-3']//div[text()='Non-Structural Walkdoor Post Framing'])[1]";
            public static string jambType = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Jamb Type'])[1]//following::div[2]";
            public static string headerBoundaries = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Header boundaries'])[1]//following::div[2]";

            // Job
            public static string waitForTheJobElementsVisible = "(//div[@class='w2ui-page page-5'])[1]";
            public static string jobMenu = "//div[@id='form_myForm_tabs']//div[text()='Job']";
            public static string jobNameField = "(//input[@name='ProjectName'])[1]";
            public static string quotedField = "(//div[@class='w2ui-page page-5']//label[text()='Quote']//following::input[@id='Quote'])[1]";

            // Drawing 
            public static string drawingButton = "//td[@id='tb_middleToolBar_item_showDrawings']//td[text()='Drawings']";
            public static string waitForTheDrawingPanelLoad = "//div[@name='drawingsSidebar']";
            public static string canvas2D = "//canvas[@id='drawing2d']";
            public static string getTheDataOfTableFromAssembly = "//div[@id='grid_dwgMaterialsGrid_records']/table/tbody";
            public static string getTheColumnDataOfTableFromAssembly = "//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and @line='{0}']//td[@col='{1}']";
            // Interior Sheathing
            public static string interiorSheathingEXT_1 = "//div[@id='node_IntSheathing_sub']//div[text()='EXT-1']";
            // Sheathing Drawing 
            public static string sheathingDrawingEXT_1 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='EXT-1']";
            public static string sheathingDrawingEXT_2 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='EXT-2']";
            public static string sheathingDrawingEXT_3 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='EXT-3']";
            public static string sheathingDrawingEXT_4 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='EXT-4']";
            public static string sheathingDrawingROOF_1 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='ROOF-1']";
            public static string sheathingDrawingROOF_2 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='ROOF-2']";
            public static string sheathingDrawingROOF_3 = "//div[@name='drawingsSidebar']//div[@id='node_Sheathing_sub']//div[text()='ROOF-3']";
            // Cladding Drawing
            public static string claddingDrawingROOF_6 = "//div[@id='node_Cladding_sub']//div[text()='ROOF-6']";
            public static string claddingDrawingROOF_3 = "//div[@id='node_Cladding_sub']//div[text()='ROOF-3']";
            // Assembly Drawing 
            public static string assemblyDrawingEXT_1 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-1']";
            public static string assemblyDrawingEXT_2 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-2']";
            public static string assemblyDrawingEXT_3 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-3']";
            public static string assemblyDrawingEXT_4 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-4']";
            public static string assemblyDrawingEXT_6 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-6']";
            public static string assemblyDrawingEXT_8 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='EXT-8']";
            public static string assemblyDrawingINT_1 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='INT-1']";
            public static string assemblyDrawingROOF_1 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='ROOF-1']";
            public static string assemblyDrawingROOF_2 = "//div[@name='drawingsSidebar']//div[@id='node_Assembly_sub']//div[text()='ROOF-2']";
            // Get The rows of Assembly drawing table
            public static string getTheColumnValueFromDrawingTable = "//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and descendant::div[text()='{0}']]//td[@col='{1}']";
            public static string materialNameOfAssemblyTable = "//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and descendant::div[text()='{0}']]";
            public static string materialNameOfAssemblyTableOfLengthField = ".//td[@col='6']//div";
            public static string materialNameOfAssemblyTableOfQTYField = ".//td[@col='5']//div";
            public static string MaterialNameOfAssemblyTableOfSKUField = ".//td[@col='3']//div";
            public static string MaterialNameOfAssemblyTableOfMaterialField = ".//td[@col='4']//div";
            public static string materialNameOfSheathingDrawingTableOfUsageField = ".//td[@col='2']//div";
            // Interior Sheathing 
            public static string interiorSheathingCEIL_1 = "//div[@id='node_IntSheathing_sub']//div[text()='CEIL-1']";

            // Footer Elements
            // roof button
            public static string roofButton = "//div[@name='layout3dView_bottom_toolbar']//button[normalize-space()='Roof']";
            // Server delay(Volume Slider)
            public static string ServerDelay = "//input[@id='serverDelay']";
            public static string SyncButton = "//div[@id='serverRefresh']";
            public static string shellButton = "//td[@id='tb_layout3dView_bottom_toolbar_item_item_1']//button[text()='Shell']";
            // Changes View 
            public static string changesView = "//td[@id='tb_layout3dView_bottom_toolbar_item_changeView']//td[text()='Change View']";
            public static string waitForTheChangesViewLocators = "//div[@id='w2ui-overlay']";
            public static string FrontLeft = "//div[@id='w2ui-overlay']//div//img[@title='Front Left']";
            public static string FrontRight = "//div[@id='w2ui-overlay']//div//img[@title='Front Right']";
            public static string LeftElevation = "//div[@id='w2ui-overlay']//div//img[@title='Left Elevation']";
            public static string FrontElevation = "//div[@id='w2ui-overlay']//div//img[@title='Front Elevation']";
            public static string BackLeft = "//div[@id='w2ui-overlay']//div//img[@title='Back Left']";
            public static string BackRight = "//div[@id='w2ui-overlay']//div//img[@title='Back Right']";
            public static string applyButton = "//div[@id='w2ui-popup']//button[@name='Apply']";
            public static string jobReviewElementTabSelector = "//td[contains(text(),'{0}')]";
            public static string planView = "//div[@id='w2ui-overlay']//div//img[@title='Plan View']";

            // Get The dropdown material table row
            public static string MaterialTableRows = "//div[@id='w2ui-overlay']//tr//div[1]";
            public static string MaterialTableRowsForColor = "//div[@id='w2ui-overlay']//tr//span[1]";
            public static string selectMaterialFromAdvancedEdit = "//div[@id='w2ui-overlay']//tr//td[1]";
            public static string SelectMaterialFromDropdown = "//div[@id='w2ui-overlay']//following::div[text()='{0}']";
            public static string SelectColorMaterialFromDropdown = "//div[@id='w2ui-overlay']//following::span[text()='{0}']";

            // Header 
            public static string SaveButton = "//td[@id='tb_editToolbar_item_save']";
            public static string OutputsButton = "//td[@id='tb_editToolbar_item_outputs']//td[text()='Outputs']";
            public static string WaitForTheOutputsElementVisible = "(//div[@id='optionList']//div[@class='w2ui-page page-0'])";
            public static string CheckTheOutputCheckbox = "//div[@id='optionList']//div[@class='w2ui-page page-0']//span[text()='{0}']//preceding::input[1]";
            public static string DownloadButton = "//button[contains(text(),'Download')]";
            public static string UncheckAllCheckFromOutputs = "//span[contains(@onclick,'selectOutput')]//preceding :: input[1]";
            public static string HomeButton = "//div[@id='primaryToolbar']//td[@id='tb_editToolbar_item_cancel']//td[text()='Home']";
            public static string click3DEditButton = "//td[@id='tb_view3dToolbar_item_btnEdit3D']//td[normalize-space()='Edit3D']";
            public static string clickView3DButton = "//td[@id='tb_view3dToolbar_item_btnEdit3D']//td[normalize-space()='View3D']";
            public static string clickOpenWallButton = "//td[@id='tb_view3dToolbar_item_btnWallOpen']//td[normalize-space()='OpenWall']";
            public static string attachedBuilding = "//td[@id='tb_view3dToolbar_item_bntAttachedBldg']//td[normalize-space()='AttachedBuilding']";
            public static string jobListButton = "//td[@id='tb_editToolbar_item_cancel']//td[text()='Job List']";
            public static string totalPrice = "(//span[@id='totalPrice'])[1]";
            public static string cupolas = "//td[@id='tb_view3dToolbar_item_btnCupola']//td[text()='Cupola']";
            public static string quotedInputField = "(//label[text()='Quote']//following::input[@name='Quote'])[1]";

            // 3D view 
            public static string Canvas3DViewButton = "//td[@id='tb_middleToolBar_item_show3dView']//td[text()='3d View']";

            // Canvas 
            public static string Canvas3DBuilding = "//canvas[@id='drawingArea']";
            public static string Canvas2DBuilding = "//canvas[@id='drawing2d']";
            public static string ErrorMessagePopup = "//div[@id='w2ui-popup']//div[2]";
            public static string captureImageSelector = "//{0}[@id='{1}']";

            // Job Review Elements
            public static string JobReview = "//td[@id='tb_middleToolBar_item_showMaterials']//td[text()='Job Review']";
            public static string Trusses = "//div[@id='tabsup']//div[text()='Trusses']";
            public static string claddingOfJobReview = "//div[@id='tabsup']//div[text()='Cladding']";
            public static string testWalkDoor = "//div[@id='tabsup']//div[text()='TestWalkDoor']";
            public static string testOverhead = "//div[@id='tabsup']//div[text()='TestOverhead']";
            public static string testSlider = "//div[@id='tabsup']//div[text()='TestSlider']";
            public static string testWindow = "//div[@id='tabsup']//div[text()='TestWindow']";
            public static string firstMaterialOfTrusses = "//tr[@id='grid_MaterialsGrid_rec_0']//td[@col='3']//div[1]";
            public static string Sheathing = "//div[@id='tabsup']//div[text()='Sheathing']";
            public static string framing = "//div[@id='tabsup']//div[text()='Framing']";
            public static string jobReviewTabSelection = "//div[@id='tabsup']//div[text()='{0}']";
            public static string accessories = "//div[@id='tabsup']//div[text()='Accessories']";
            public static string summary = "//div[@id='tabsup']//div[text()='Summary']";
            public static string trim = "//div[@id='tabsup']//div[text()='Trim']";
            public static string doorAndWindowJobReview = "//div[@id='tabsup']//div[text()='Doors & Windows']";
            public static string labor = "//div[@id='tabsup']//div[text()='Labor']";
            public static string freight = "//div[@id='tabsup']//div[text()='Freight']";
            public static string GetTheTotalRowOfTable = "//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='{0}']]";
            public static string GetTheRowOfJobReviewTable = "//tr[contains(@id,'grid_MaterialsGrid_rec_') and @line='{0}']//td[@col='{1}']//div";
            public static string fixTrussesButton = "//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='{0}']//following::button[1]";
            public static string skuInputFieldOfFixTrusses = "//div[@id='form']//label[text()='Sku']//following::input[@name='Sku']";
            public static string addToTrussTableButton = "//div[@id='w2ui-popup']//following::button[text()='Add to Truss Table']";
            public static string checkNotMatchTextShown = "(//tr[contains(@id,'grid_MaterialsGrid_rec_')]//div[text()='{0}']//following::div[text()='NOT AN EXACT MATCH *'])[1]";
            public static string getTheColumnNumber = ".//td[@col='{0}']";
            public static string selectionDropdownOfRoofingPassport = "//label[text()='Selection:']//following::div[2]";
            public static string saveChangesButton = "//div[@id='w2ui-popup']//button[text()='Save Changes']";
            public static string getTheDataFromJobReviewTable = "//div[@id='{0}']";

            // Configured Price
            public static string ConfiguredPrice = "//div[@class='jprice']//div[@class='color-price']";

            // Opening 
            public static string Opening = "//td[@id='tb_view3dToolbar_item_btnOpenings']//td[text()='Openings']";
            public static string WaitForTheOpeningPopup = "//td[@id='tabs_tabs_tab_settingsTab']";
            public static string WalkDoor = "//div[@id='w2ui-overlay']//span[text()='Walk Door']";
            public static string Overhead = "//div[@id='w2ui-overlay']//span[text()='Overhead Doors']";
            public static string Sliders = "//div[@id='w2ui-overlay']//span[text()='Sliders']";
            public static string Windows = "//div[@id='w2ui-overlay']//span[text()='Windows']";
            public static string SelectStyleFromDoors = "//div[@id='Style-group']//div[@class='style-selection-box']//div[normalize-space()='{0}']";
            public static string SelectAStyle = "//div[@id='mainLayout']//div[text()='Select A Style']";
            public static string SelectOpeningDoors = "//div[@class='dropdown-content sku-content']//button[@name='SkuSel'][normalize-space()='{0}']";
            public static string doorPackageCheckbox = "//label[text()='Packages']//following::div[@id='doorPackages']//following::div[@class='w2ui-grid-body']//tr";
            public static string walkdoorOfAddOns = "//td[@id='tabs_tabs_tab_addOnsTab']//div[text()='Add-Ons']";
            public static string plusButtonOfAddOns = "//div[@id='addOnsTab']//button[@name='addaddon']";
            public static string getTheListOfAddOnsMaterial = "//div[@id='grid_addAddOnsGrid_records']//tr";
            public static string materialName = "//div[@id='grid_addAddOnsGrid_records']//div[text()='{0}']";
            public static string addItemButton = "//div[@id='addOnsTab']//button[@class='apply-button']";
            public static string sillHeight = "//div[@id='settingsTab']//label[text()='Sill Height']//following::input[@name='SillHeightStr']";
            public static string distanceInputFieldOfOpening = "//div[@id='w2ui-popup']//label[text()='Distance']//following::input[@name='DistanceStr']";
            public static string updateButtonOf2DView = "//div[@id='w2ui-popup']//button[@name='update2dDoorButton']";
            public static string updateButtonOfLoft = "//div[@id='w2ui-popup']//button[@name='update2dLoftButton']";
            public static string updateButtonOfWall = "//div[@id='w2ui-popup']//button[@name='update2dWallButton']";
            public static string updateButtonOf3DView = "//div[@id='w2ui-popup']//button[@name='updateModelButton']";
            public static string returnButton = "//button[text()='Return']";
            public static string selectAStyle = "//div[@id='w2ui-popup']//div[text()='Select A Style']";
            public static string selectStandardSlider = "//div[@id='w2ui-popup']//div[text()='Standard']";
            public static string selectLocation = "//div[@class='dropdown-content location-content']//button[normalize-space()='{0}']";
            public static string useBaySpacingCheckboxForOpening = "//div[@id='w2ui-popup']//label[text()='Use Bay Spacing']//following::input[@name='AttachedBaySpacingEnabled']";
            public static string baySpacingOptionFromOpening = "//div[@id='w2ui-popup']//label[text()='Bay Spacing']//following::div[2]";
            public static string doubleTrussCheckboxForOpening = "//div[@id='w2ui-popup']//label[text()='Double Truss']//following::input[@name='AttachedDoubleTruss']";
            public static string doNotCombineCheckboxForOpening = "//div[@id='w2ui-popup']//label[contains(text(),'Combine Walls')]//following::input[@name='NoCombineWalls']";
            public static string selectBayPlacementFromOpening = "//div[@id='w2ui-popup']//label[text()='Bay Placement']//following::div[2]";
            public static string includeBackWallFromOpening = "//div[@id='w2ui-popup']//label[text()='Include Back Wall']//following::div[2]";
            public static string bayLengths = "//div[@id='w2ui-overlay-customSpacingDialog']//label[text()='Bay Lengths']//following::input[@name='CustomStr']";
            public static string applyButtonsOfOpening = "//div[@id='w2ui-overlay-customSpacingDialog']//button[@name='Apply']";

            // Divider Wall
            public static string dividerWall = "//td[@id='tb_view3dToolbar_item_btnDivWall']//td[normalize-space()='DividerWall']";
            public static string sideA = "(//label[text()='Side A'])[1]//following::div[2]";
            public static string sideB = "(//label[text()='Side B'])[1]//following::div[2]";

            // Cross Icon
            public static string crossIcon = "//div[@id='w2ui-popup']//div[text()='Close']";

            // Advanced Edit Element
            public static string AdvancedEdit = "//td[@id='tb_middleToolBar_item_showAdvanced']//td[text()='Advanced Edit']";
            public static string ROOF_1 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='ROOF-1']";
            public static string ROOF_2 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='ROOF-2']";
            public static string EXT_1 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='EXT-1']";
            public static string EXT_2 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='EXT-2']";
            public static string EXT_3 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='EXT-3']";
            public static string INT_1 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='INT-1']";
            public static string EXT_4 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='EXT-4']";
            public static string EXT_6 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='EXT-6']";
            public static string SLD_1 = "(//div[normalize-space()='SLD-1'])[1]";
            public static string LOFT_1 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='LOFT-1']";
            public static string LOFT_2 = "//div[@id='layout_advancedEditSideLayout_panel_main']//div[@id='node_Panels_sub']//div[text()='LOFT-2']";
            public static string mainOfAdvancedEdit = "//td[@id='tabs_myForm_tabs_tab_tab0']//div[normalize-space()='Main']";
            public static string catalogCategory = "//label[text()='Catalog Category']//following::div[2]";
            public static string catalogItem = "//label[text()='Catalog Item']//following::div[2]";

            // Package Elements
            public static string packageButton = "//td[@id='tabs_myForm_tabs_tab_tab6']//div[text()='Packages']";
            public static string waitFroThePackageElementsVisible = "(//div[@class='w2ui-page page-4'])[1]";
            public static string checkThePackagesCheckboxForBundleList = "//div[contains(text(),'Bundles')]//following::div[@class='w2ui-grid-body']//tr";
            public static string checkThePackagesCheckboxForAddOns = "//div[contains(text(),'Add-ons')]//following::div[@class='w2ui-grid-body']//tr";
            public static string selectBundleOption = "//div[@id='w2ui-overlay']//td[text()='{0}']";

            // Extra XPaths of test case
            public static string getTheSheathingDrawingElement = "grid_dwgMaterialsGrid_records";
            public static string getTheDataOfJobReview = "//div[@id='grid_MaterialsGrid_records']/table/tbody";
            public static string getTheRows = "//div[@id='grid_MaterialsGrid_records']/table/tbody/tr[{0}]/td[{1}]/div";
            public static string getTheRowsOfJobReview = "//tr[contains(@id,'grid_MaterialsGrid_rec_') and @line='{0}']//td[@col='{1}']/div";

            // Create Opening Element
            public static string startInputField = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Start']//following::input[@name='StartStr']";
            public static string lengthInputField = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Length']//following::input[@name='LengthStr']";
            public static string widthInputField = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Width']//following::input[@name='WidthStr']";
            public static string heightInputField = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Height']//following::input[@name='HeightStr']";
            public static string roofPitchInputField = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Roof Pitch']//following::input[@name='Slope']";
            public static string heightDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Height']//following::div[2]";
            public static string overhangDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Overhangs']//following::div[2]";
            public static string wallsDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Walls']//following::div[2]";
            public static string roofFramingDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Roof Framing']//following::div[2]";
            public static string roofOrientationDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Roof Orientation']//following::div[2]";
            public static string advancedCheckboxOfOpening = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Advanced']//following::input[@id='Advanced']";
            public static string roofStyleOfOpening = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Roof Style']//following::div[2]";
            public static string locationOpening = "//div[@id='w2ui-popup']//label[text()='Location']//following::input[@name='LocationSel']";
            public static string cantPorch = "//td[@id='tb_view3dToolbar_item_btnCantPorch']//td[normalize-space()='CantPorch']";
            public static string widthFieldOfSlider = "//div[@id='openingSettingsForm']//label[text()='Width']//following::input[@name='WidthStr']";
            public static string heightFieldOfSlider = "//div[@id='openingSettingsForm']//label[text()='Height']//following::input[@name='HeightStr']";
            public static string sideFieldOfSlider = "//div[@id='openingSettingsForm']//label[text()='Side']//following::input[@name='SideSel']";

            // Porch 
            public static string porch = "//td[@id='tb_view3dToolbar_item_btnPorch']//td[text()='Porch']";
            public static string frontLeft = "//div[@id='w2ui-overlay']//button[@title='Front Left']";
            public static string frontRight = "//div[@id='w2ui-overlay']//button[@title='Front Right']";
            public static string left = "//div[@id='w2ui-overlay']//button[@title='Left']";
            public static string custom = "//div[@id='w2ui-overlay']//button[@title='Custom']";
            public static string gableWallsStyleDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Gable Wall Style']//following::div[2]";
            public static string gableWallsStyleDropdownForDetailsTab = "(//div[@class='w2ui-field w2ui-span6']//label[text()='Gable Wall Style']//following::div[2])[1]";
            public static string trussSpecialDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Truss Special']//following::div[2]";
            public static string trussMaterialDropdown = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Truss Material']//following::div[2]";
            public static string atticRoomWidthOpening = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Attic Room Width']//following::input[@id='AttachedAtticWidthStr']";
            public static string atticRoomHeightOpening = "//div[@id='w2ui-popup']//div[@class='w2ui-field w2ui-span6']//label[text()='Attic Room Height']//following::input[@id='AttachedAtticHeightStr']";

            // Awning 
            public static string awning = "//td[@id='tb_view3dToolbar_item_btnAwning']//td[text()='Awning']";
            public static string cancel = "//div[@id='w2ui-popup']//button[@id='Cancel']";
            public static string noButton = "//div[@id='w2ui-popup']//button[@id='No']";

            // Lean-to
            public static string leanTo = "//td[@id='tb_view3dToolbar_item_btnLeanto']//td[text()='Lean-to']";

            // Get the dropdown element
            public static string getTheElementFromDropdown = "//div[@id='w2ui-overlay']//tr[@index='{0}']//div[1]";
            public static string serverErrorMessageButton = "//td[@id='tb_editToolbar_item_showMessages']//span[@id='serverMessagesBtn']";
            public static string serverErrorMessagePopup = "(//div[@class='w2ui-msg-body'])[1]";
            public static string okayButton = "//div[@id='w2ui-popup']//input[@type='button']";

            // Change The job status button
            public static string changeStatusButton = "//td[@id='tb_editToolbar_item_nextstatus']//td[text()='{0}']";
            public static string yesButton = "//div[@id='w2ui-popup']//button[@id='Yes']";

            // 2D view Element
            public static string edit2DView = "//td[@id='tb_middleToolBar_item_show2dView']//td[text()='2d View']";
            public static string loftTab = "//td[@id='tabs_tabs2d_tab_lofts']//div[text()='Lofts']";
            public static string getTheDoorNameFromThe2DView = "//tr[contains(@id,'grid_doorList2d_rec_')]//td[@col='0']//div[1]";
            public static string getTheInteriorWallNameFromThe2DView = "//tr[contains(@id,'grid_wallList2d_rec_')]//td[@col='0']//div[1]";
            public static string interiorWallsFromThe2DView = "(//div[normalize-space()='InteriorWalls'])[1]";
            public static string addRoom = "//td[@id='tb_wallList2d_toolbar_item_addRoom']//td[text()='Add Room']";
            public static string lengthInputFieldOfInteriorWall = "//div[@id='w2ui-popup']//label[text()='Length']//following::input[@name='lenstr']";
            public static string widthInputFieldOfInteriorWall = "//div[@id='w2ui-popup']//label[text()='Width']//following::input[@name='widstr']";
            public static string ceilingProductOfInteriorWallOf2DView = "//div[@id='w2ui-popup']//label[text()='Ceiling Product System']//following::div[2]";
            public static string wallFramingOfInteriorWallOf2DView = "//div[@id='w2ui-popup']//label[text()='Wall Framing']//following::div[2]";
            public static string interiorStudMaterialOfInteriorWallOf2DView = "//div[@id='w2ui-popup']//label[text()='Interior Stud Material']//following::div[2]";
            public static string lofts = "//td[@id='tabs_tabs2d_tab_lofts']//div[text()='Lofts']";
            public static string getElementListOfInteriorWall2DView = "//div[@id='grid_wallList2d_records']//tr[contains(@id,'grid_wallList2d_rec_')]//td[@col='0']/div";
            public static string addButtonOfLofts = "//td[@id='tb_loftList2d_toolbar_item_addLoft']//td[text()='Add']";
            public static string ceilingProductSystemOfLoft = "//div[@id='w2ui-popup']//label[text()='Ceiling Product System']//following::div[2]";
            public static string joistMaterialOfLoft = "//div[@id='w2ui-popup']//label[text()='Joist Material']//following::div[2]";
            public static string joistSpacingOfLoft = "//div[@id='w2ui-popup']//label[text()='Joist Spacing']//following::div[2]";
            public static string ceilingMaterialOfLoft = "//div[@id='w2ui-popup']//label[text()='Ceiling Material']//following::div[2]";
            public static string floorSheathingOfLoft = "//div[@id='w2ui-popup']//label[text()='Floor Sheathing']//following::div[2]";
            public static string hasCeilingCheckOfLoft = "//div[@id='w2ui-popup']//label[text()='Has Ceiling']//following::input[@name='HasCeiling']";

            // Misc button 
            public static string addMisc = "//td[@id='tb_MaterialsGrid_toolbar_item_addmisc']//td[text()='Add Misc']";
            public static string addCatalog = "//td[@id='tb_MaterialsGrid_toolbar_item_addcat']//td[text()='Add Catalog']";
            public static string usageOfMisc = "//div[@id='w2ui-popup']//label[text()='Usage']//following::input[@name='Usage']";
            public static string skuOfMisc = "//div[@id='w2ui-popup']//label[text()='SKU']//following::input[@name='Sku']";
            public static string materialOfMisc = "//div[@id='w2ui-popup']//label[text()='Material']//following::input[@name='Material']";
            public static string costOfMisc = "//div[@id='w2ui-popup']//label[text()='Cost']//following::input[@name='Cost']";
            public static string priceOfMisc = "//div[@id='w2ui-popup']//label[text()='Price']//following::input[@name='Price']";
            public static string calculationOfMisc = "//div[@id='w2ui-popup']//label[text()='Calculation']//following::textarea[@name='Calculation']";
            public static string curlyBracketsButton = "//div[@id='w2ui-popup']//button[@id='calcBtn']";
            public static string saveButtonOfMisc = "//div[@id='w2ui-popup']//button[@id='Save']";
            public static string searchElementInTheMiscTable = "//input[@id='grid_selectCalcBaseOverlay_grid_search_all']";
            public static string firstRowOfCalculationTable = "//tr[contains(@id,'grid_selectCalcBaseOverlay_grid_rec') and @line='1']";
            public static string addButtonOfMisc = "//td[@id='tb_selectCalcBaseOverlay_grid_toolbar_item_add']//td[text()='Add']";
            public static string clickNoButton = "//div[@id='w2ui-popup']//button[@id='No']";
            public static string colorTabOfRoofingPassportFromAdvancedEdit = "(//div[@class='w2ui-page page-3'])[1]//div[text()='Colors']";
            public static string roofSystemDropdownOfRoofingPassport = "(//label[text()='Roof System']//following::div[2])[1]";
        }

        public static class FramingRules
        {
            public static string pageScrollDown = "document.querySelector('#grid_formGrid_records').scrollBy(0,{0})";
            public static string EditButton = "(//div[@class='table-responsive']//td[normalize-space()='{0}']//following::a[text()='Edit'])[1]";
            public static string WaitForTheFramingRulePageLoad = "(//div[@id='grid_formGrid_records'])[1]";
            public static string WaitForTheFramingRuleTableLoad = "(//div[@id='layout_baseLayout_panel_main'])";
            public static string DoEditButton = "(//div[text()='{0}']//following::div[text()='{1}']//following::td[@col='5']//button[1])[1]";
            public static string Prompt = "(//div[@id='w2ui-popup'])//label[text()='Prompt']/following::input[@name='caption']";
            public static string SaveButtonOfDoEditField = "(//td[@id='tb_questionLayout_top_toolbar_item_item6']//td[text()='Save   '])[1]";
            public static string SaveButtonOfDoEditFieldOnJobPage = "(//div[@id='w2ui-popup']//button[text()='Save'])[1]";
            public static string SaveButton = "(//td[@id='tb_baseLayout_top_toolbar_item_item6']//td[normalize-space()='Save'])[1]";
            public static string InputField = "(//div[text()='{0}'])[1]//following::div[text()='{1}'][1]//following::td[@col='1'][1]//div";
            public static string details = "//td[@id='tabs_formTabs_tab_tab3']//div[text()='Details']";
            public static string doorAndWindow = "//td[@id='tabs_formTabs_tab_tab4']//div[normalize-space()='Door andWindow']";
            public static string job = "//td[@id='tabs_formTabs_tab_tab1']//div[text()='Job']";
            public static string jobButtonPreviewFrame = "//td[@id='tabs_myForm_tabs_tab_tab3']//div[text()='Job']";
            public static string getTheElementOfDropdown = "//div[contains(text(),'{0}')]//following::td[1]";
            public static string selectNoneValue = "(//div[@class='w2ui-editable']//option[text()='None'])[1]";
            public static string getTheAllDataFromEditOption = "//div[@id='grid_questionGrid_records']";
            public static string crossIcon = "//div[@id='w2ui-popup']//div[text()='Close']";
            public static string addButton = "//td[@id='tb_formGrid_toolbar_item_add']//td[text()='Add']";
            public static string previewButton = "//td[@id='tb_baseLayout_top_toolbar_item_item30']//td[text()='Preview']";
            public static string selectTypeOptionOfEditNewQuestionTable = "//div[@id='w2ui-popup']//label[text()='Type']/following::div[2]";
            public static string deleteButton = "(//div[contains(text(),'{0}')])[1]//following::button[2]";
            public static string checkEmailCheckbox = "(//div[contains(text(),'Email')])[1]//following::input[1]";
            public static string InputFieldLocator = "(//div[text()='{0}'])[1]//following::div[text()='{1}'][1]//following::td[@col='1'][1]";
            public static string CheckboxesLocator = "(//div[text()='{0}'])[1]//following::div[text()='{1}'][1]//following::td[@col='{2}'][1]//input";
            public static string clickOnTheDropdownElementTab = "(//div[contains(text(),'{0}')]//following :: div[{1}])[1]";
            public static string selectElementFromDropdown = "(//div[@class='w2ui-editable']/select/option)[{0}]";
            public static string getTheListFromDoEditTable = "//tr[contains(@id,'grid_questionGrid_rec_')]//td[@col='0']//div";
        }

        public static class JobPage
        {
            public static string SearchField = "//input[@id='grid_grid_search_all']";
            public static string WaitForTheSpinner = "//div[@class='w2ui-lock-msg']";
            public static string GetTableData = "//div[@id='grid_grid_records']/table/tbody";
            public static string GetFirstElementOfText = "//tr[contains(@id,'grid_grid_rec_') and @line='{0}']//td[@col='{1}']/div";
            public static string GetTheJobName = "((((//div[@id='grid_grid_records']//following::tr[contains(@id,'grid_grid_rec_') and @line='{0}']//following::div[@title='{1}']))//preceding::td[@col='1'])[2])/div/button[1]";
            public static string getTheDeleteButton = "((((//div[@id='grid_grid_records']//following::tr[contains(@id,'grid_grid_rec_') and @line='{0}']//following::div[@title='{1}']))//preceding::td[@col='1'])[2])/div/button[4]";
            public static string deleteButtonXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[1]/div[1]/button[4]";
            public static string jobNameXpath = "//div[@id='grid_grid_records']/table/tbody/tr[{0}]/td[2]";
            public static string DeleteButton = "//td[normalize-space()='Delete']";
            public static string YesButton = "//button[@id='Yes']";
            public static string jobListReport = "//a[@id='downloadJobListReport']";
            public static string uploadModel = "//a[text()='Upload Model']";
            public static string chooseFile = "//input[@id='fileBox']";
            public static string uploadButton = "//button[text()='Upload']";
            public static string confirmation = "//h3[text()='Done!']";
            public static string status = "//h3[@id='status']";
            public static string backToList = "//a[text()='Back to List']";
            public static string filterIcon = "//td[@id='tb_grid_toolbar_item_filter']//td[text()='Filter']";
            public static string selectUser = "//select[@id='user']";
            public static string checkStatusCheckbox = "//label[text()='{0}']//preceding::input[@id='{0}']";
            public static string getJobStatusButton = "(//span[text()='{0}']//preceding::td[@col='1'])[2]//button[text()='{1}']";
            public static string waitForConfirmationPopup = "//div[@id='w2ui-popup']/div[text()='Confirmation']";
            public static string yesButton = "//div[@id='w2ui-popup']//button[@id='Yes']";
            public static string re_QuotedOption = "//div[@class='menu']//td[text()='Re-Quote']";
            public static string getTheJobName = "//tr[contains(@id,'grid_grid_rec_') and @line='1']//td[@col='2']/div";
        }

        public static class SetupWizard
        {
            public static string extension = "//div[@id='w2ui-popup']//label[text()='Extension']//following::input[@name='Margin']";
            public static string styleDropdown = "//div[@id='w2ui-popup']//label[text()='Style']//following::div[2]";
            public static string getTheAllCheckboxFromShowAndHideFrame = "//div[@id='w2ui-overlay']//label[text()='{0}']//preceding::input[1]";
            public static string shownAndHideButton = "//td[@id='tb_grid_toolbar_item_columns']";
            public static string checkFirstColumnOfCheckbox = "//div[contains(@id,'grid_grid_records')]//following::input[1]";
            public static string checkAllCheckboxFromShownAndHideFrame = "//div[@id='w2ui-overlay']//input[@id='All']";
            public static string homeIconButton = "//td[@id='tb_grid_toolbar_item_usage']";
            public static string Framing = "//ol[@id='breadcrumbs']//li[text()='Framing']";
            public static string ColorsTab = "//ol[@id='breadcrumbs']//li[text()='Colors']";
            public static string Systems = "//ol[@id='breadcrumbs']//li[text()='Systems']";
            public static string Sheathing = "//ol[@id='breadcrumbs']//li[text()='Sheathing']";
            public static string Trim = "//ol[@id='breadcrumbs']//li[text()='Trim']";
            public static string Foundation = "//ol[@id='breadcrumbs']//li[text()='Foundation']";
            public static string WalkDoors = "//ol[@id='breadcrumbs']//li[text()='WalkDoors']";
            public static string WalkDoorHardware = "//ol[@id='breadcrumbs']//li[text()='WalkDoor Hardware']";
            public static string OverheadDoors = "//ol[@id='breadcrumbs']//li[text()='Overhead Doors']";
            public static string OverheadHardware = "//ol[@id='breadcrumbs']//li[text()='Overhead Hardware']";
            public static string Sliders = "//ol[@id='breadcrumbs']//li[text()='Sliders']";
            public static string SliderHardware = "//ol[@id='breadcrumbs']//li[text()='Slider Hardware']";
            public static string Windows = "//ol[@id='breadcrumbs']//li[text()='Windows']";
            public static string WindowHardware = "//ol[@id='breadcrumbs']//li[text()='Window Hardware']";
            public static string Cupolas = "//ol[@id='breadcrumbs']//li[text()='Cupolas']";
            public static string CupolaHardware = "//ol[@id='breadcrumbs']//li[text()='Cupola Hardware']";
            public static string Connectors = "//ol[@id='breadcrumbs']//li[text()='Connectors']";
            public static string Fasteners = "//ol[@id='breadcrumbs']//li[text()='Fasteners']";
            public static string Hardware = "//ol[@id='breadcrumbs']//li[text()='Hardware']";
            public static string Labor = "//ol[@id='breadcrumbs']//li[text()='Labor']";
            public static string Freight = "//ol[@id='breadcrumbs']//li[text()='Freight']";
            public static string SheathingAssemblies = "//ol[@id='breadcrumbs']//li[text()='Sheathing Assemblies']";
            public static string TrimAssemblies = "//ol[@id='breadcrumbs']//li[text()='Trim Assemblies']";
            public static string WaitForTHeSubMenuVisible = "//div[@id='page']//ol[@id='breadcrumbs']";
            public static string SearchElementInTheTable = "//input[@id='grid_grid_search_all']";
            public static string AfterSearchClickFirstElement = "(//div[contains(@id,'grid_grid_records')]//following::span[contains(text(),'{0}')])[1]";
            public static string DeleteButton = "//td[@id='tb_grid_toolbar_item_delete']";
            public static string WaitForTheConfirmationPopup = "//div[contains(text(),'Confirmation')]";
            public static string confirmation = "//div[text()='Confirmation']";
            public static string YesButton = "//div[@id='w2ui-popup']//button[@id='Yes']";
            public static string SaveAllButton = "//button[contains(@onclick,'clickFinish()')]";
            public static string GetTheButtonName = "//div[@id='w2ui-popup']//div[@class='w2ui-msg-buttons']//button[1]";
            public static string SaveButton = "//div[@id='w2ui-popup']//button[@name='Save']";
            public static string cancelButton = "//div[@id='w2ui-popup']//button[@name='Cancel']";
            public static string OkayButton = "//div[@id='w2ui-popup']//button[@onclick='w2popup.close();']";
            public static string CloneButton = "//td[@id='tb_grid_toolbar_item_clone']";
            public static string FirstRowElementOfTable = "//div[@id='grid_grid_records']//following::tr[contains(@id,'grid_grid_rec_') and @line='1']";
            public static string getTheHexCodeFromTable = "(//div[contains(@id,'grid_grid_records')]//following::div[contains(text(),'{0}')])[1]";
            public static string ColorName = "//div[@id='w2ui-popup']//label[text()='Color Name']//following::input[@name='ColorName']";
            public static string CodeTransparency = "//div[@id='w2ui-popup']//label[text()='Color Transparency']//following::input[@name='Alpha']";
            public static string ColorCode = "//div[@id='w2ui-popup']//label[text()='Color Code']//following::input[@name='ColorCode']";
            public static string HEXCode = "//div[@id='w2ui-popup']//label[text()='HEX Code']//following::div[3]";
            public static string ColorMap = "//div[@id='w2ui-popup']//label[text()='Color Map']//following::div[2]";
            public static string Color = "//div[@id='w2ui-popup']//label[text()='Color']//following::div[2]";
            public static string BumpMap = "//div[@id='w2ui-popup']//label[text()='Bump Map']//following::div[2]";
            public static string Profile = "//div[@id='w2ui-popup']//label[text()='Profile']//following::div[2]";
            public static string GetTheHexCodeName = "//div[@id='w2ui-overlay']//following::div[@name='{0}']";
            public static string GetAllDataOfTables = "//div[@id='grid_grid_records']/table";
            public static string GetAllDataOfTables1 = "//tr[contains(@id,'grid_grid_rec_')]";
            public static string ScrollDownTableData = "document.querySelector('#grid_grid_records').scrollTop=document.getElementById('grid_grid_records').scrollHeight";
            public static string ScrollDownTheSubTableData = "document.querySelector('#grid_partcosts_records').scrollBy(0,2000)";
            public static string GetTheAllDatFromSubTable = "grid_partcosts_records";
            public static string AddButtonOfTable = "//td[@id='tb_grid_toolbar_item_add']";
            public static string WaitForFrameVisibleAfterClicksAddButton = "//div[@id='w2ui-popup']";
            public static string WaitForTheDownloadButtonVisible = "//div[@id='w2ui-overlay']";
            public static string keysInputField = "//label[text()='Key']//following::input[@name='Key']";
            public static string SKUInputField = "//label[text()='Sku']//following::input[@name='Sku']";
            public static string NameInputField = "//label[text()='Name']//following::input[@name='Description']";
            public static string DescriptionInputField = "//label[text()='Description']//following::input[@name='Description']";
            public static string supplierId = "//label[normalize-space()='SupplierId']//following::input[@name='SupplierId']";
            public static string supplierSku = "//label[normalize-space()='SupplierSku']//following::input[@name='SupplierSku']";
            public static string packagingCode = "//label[normalize-space()='PackagingCode']//following::input[@name='PackagingCode']";
            public static string cost = "//label[normalize-space()='Cost']//following::input[@name='Cost']";
            public static string price = "//label[normalize-space()='Price']//following::input[@name='Price']";
            public static string WidthInputField = "//label[text()='Width']//following::input[@name='Dim1']";
            public static string HeightInputField = "//label[text()='Height']//following::input[@name='Dim2']";
            public static string DepthInputField = "//label[text()='Depth']//following::input[@name='Dim2']";
            public static string coverageWidth = "//label[normalize-space()='CoverageWidth']//following::input[@name='Dim1']";
            public static string fullWidth = "//label[normalize-space()='FullWidth']//following::input[@name='Dim2']";
            public static string underlapLength = "//label[normalize-space()='UnderlapLength']//following::input[@name='UnderlapLength']";
            public static string maximumLength = "//label[normalize-space()='MaximumLength']//following::input[@name='MaximumLength']";
            public static string minimumCutLength = "//label[normalize-space()='MinimumCut Length']//following::input[@name='MinimumCutLength']";
            public static string thickness = "//label[normalize-space()='Thickness']//following::input[@name='Dim3']";
            public static string FirstElementOfUsageTable = "//tr[contains(@id,'grid_UsagesItemsGrid_rec_') and @line='1']";
            public static string FirstElementOfSystemTable = "//tr[contains(@id,'grid_SystemsItemsGrid_rec_') and @line='1']";
            public static string AddButtonOfUsageTable = "//td[@id='tb_UsagesItemsGrid_toolbar_item_add']";
            public static string AddButtonOfSystemTable = "//td[@id='tb_SystemsItemsGrid_toolbar_item_add']";
            public static string GetTheTextAfterUploadFile = "//div[@id='w2ui-popup']//div[@class='w2ui-box1']";
            public static string DownloadButton = "//td[@id='tb_grid_toolbar_item_download']//td[text()='Download']";
            public static string CSVButton = "//div[@id='w2ui-overlay']//td[text()='as CSV file']";
            public static string ExcelButton = "//div[@id='w2ui-overlay']//td[text()='as XLSX file']";
            public static string UploadButton = "//td[@id='tb_grid_toolbar_item_upload']//td[text()='Upload']";
            public static string ChooseFile = "//input[@id='fileWizard']";
            public static string roofPitch = "//label[normalize-space()='RoofPitch']//following::input[@name='Dim3']";
            public static string geTheLineNumberOfTable = "//tr[contains(@id,'grid_grid_rec_')]";
            public static string findElementForDelete = "//tr[contains(@id,'grid_grid_rec_') and @line='{0}']//td[@col='{1}']/div";
            public static string primaryDropdown = "//label[text()='Primary Material']//following::div[2]";
            public static string getTheErrorMessagePath = "//div[@id='w2ui-message0']//div[@class='w2ui-centered']";
            public static string usageTableSearchField = "//input[@id='grid_UsagesItemsGrid_search_all']";
            public static string howManyInputField = "(//div[@id='w2ui-popup']//input[@name='QtyUsed'])[1]";
            public static string systemTableSearchField = "//input[@id='grid_SystemsItemsGrid_search_all']";
            public static string leftSideOfUsageTale = "//tr[contains(@id,'grid_UsagesSelectedGrid_rec_')]//td[@col='1']/div";
            public static string removeButton = "//td[@id='tb_UsagesSelectedGrid_toolbar_item_remove']";
            public static string materialPricingsTableInputBox = "//tr[@id='grid_pricingsGrid_rec_0']//td[@col='{0}']";
            public static string colorMapText = "//label[text()='Color Map']";
            public static string partLength = "//td[@id='tb_pricingsGrid_toolbar_item_partlengths']//td[text()='Part Lengths']";
            public static string pricingText = "//label[text()='Pricings']";
            public static string addButtonOfPricingTable = "//td[@id='tb_pricingsGrid_toolbar_item_add']//td[text()='Add']";
            public static string partLengthXPath = "(//div[contains(@id,'grid_pricingsGrid_records')]//following :: td)[{0}]";
            public static string partLengthColumn = "(//tr[contains(@id,'grid_pricingsGrid_rec_')]//td[@col='2'])[{0}]";
            public static string colorButtonOfPricingTable = "//td[@id='tb_pricingsGrid_toolbar_item_hascolor']//td[text()='Colors']";
            public static string costAndPriceColumnOfTrim = "(//tr[@id='grid_pricingsGrid_rec_top']//following::td[@col='{0}'])[1]";
            public static string addNewButtonOfAssemblies = "//td[@id='tb_entriesGrid_toolbar_item_w2ui-add']//td[text()='Add New']";
            public static string materialButtonOfAssemblies = "(//label[text()='Material']//following::button[@id='materialBtn'])[1]";
            public static string catalogCategoryOfAssemblies = "//label[text()='Catalog Category']//following::div[2]";
            public static string inputSearchFieldOfCatalogCategoryAssemblies = "//input[@id='grid_fixGrid_search_all']";
            public static string firstElementOfCatalogTable = "//tr[contains(@id,'grid_fixGrid_rec_') and @line='1']";
            public static string lengthFieldOfAssemblies = "(//label[contains(text(),'Length')]//following:: div[4])[1]";
            public static string editButton = "//td[@id='tb_grid_toolbar_item_edit']";
            public static string typeDropdown = "(//label[text()='Type'])[1]//following::div[2]";
            public static string outputCategoryDropdown = "(//label[text()='Output Category'])[1]//following::div[2]";
            public static string entriesOfAssemblies = "//tr[contains(@id,'grid_entriesGrid_rec_')]//td[@col='0']//div";
            public static string editButtonOfEntriesAssemblies = "//td[@id='tb_entriesGrid_toolbar_item_w2ui-edit']";
            public static string restoreButton = "//td[@id='tb_grid_toolbar_item_undelete']//td[text()='Restore']";
            public static string partLengthFirstColumn = "(//div[contains(@id,'grid_pricingsGrid_records')]//following :: div)[1]";
            public static string filterIcon = "//td[@id='tb_grid_toolbar_item_filter']";
            public static string cladding = "//li[text()='Cladding']";
            public static string claddingAssemblies = "//li[text()='Cladding Assemblies']";
        }

        public class Packages
        {
            public static string waitForThePackagePageLoad = "//div[text()='Roof Metal Screws']";
            public static string getTheElementFromPackageTable = "(//div[@id='grid_packageList_records']//div[normalize-space()='{0}'])[1]";
            public static string deleteButton = "//div[@id='grid_packageList_toolbar']//td[@id='tb_packageList_toolbar_item_w2ui-delete']";
            public static string waitForTheDeleteFrameVisible = "//div[text()='Delete Confirmation']";
            public static string yesButton = "//div[text()='Delete Confirmation']//following::button[@id='Yes']";
            public static string addNewButton = "//td[contains(@id,'tb_packageList_toolbar_item_add')]//td[contains(text(),'Add New')]";
            public static string waitForTheAddNewButtonVisible = "//div[@id='w2ui-overlay']";
            public static string blankButton = "//td[normalize-space()='Blank']";
            public static string groupNameField = "//label[text()='Group Name']//following::input[@name='Group']";
            public static string packageNameField = "//label[text()='Package Name']//following::input[@name='Name']";
            public static string mainSaveButton = "//td[@id='tb_baseLayout_top_toolbar_item_item6']//following::td[normalize-space()='Save']";
            public static string packageTypeDropdown = "//label[text()='Package Type']//following::div[2]";
            public static string usage = "//div[@id='w2ui-popup']//label[text()='Usage']//following::input[@name='Usage']";
            public static string defaultSettingDropdown = "//label[text()='Default Setting']//following::div[2]";
            public static string addCatalogButton = "//td[@id='tb_MaterialsGrid_toolbar_item_addcat']//following::td[text()='Add Catalog']";
            public static string addMiscButton = "//td[@id='tb_MaterialsGrid_toolbar_item_addmisc']//following::td[text()='Add Misc']";
            public static string outputCategory = "//label[text()='Output Category']//following::div[2]";
            public static string catalogCategory = "//label[text()='Catalog Category']//following::div[2]";
            public static string skuInputField = "//div[@id='w2ui-popup']//label[text()='SKU']//following::input[@name='Sku']";
            public static string catalogItem = "//label[text()='Catalog Item']//following::div[2]";
            public static string priceField = "//input[@name='Price']";
            public static string SaveButton = "//div[@id='w2ui-popup']//div[@class='w2ui-msg-buttons']//button[@id='Save']";
            public static string usageInputField = "//div[@id='w2ui-popup']//label[text()='Usage']//following::input[@name='Usage']";
            public static string calculationInputField = "//textarea[@name='Calculation']";
            public static string selectPackageType = "(//select[@id='packageClass'])[2]";
            public static string catalogTableFirstRowElement = "//div[@id='grid_MaterialsGrid_records']//following::tr[@id='grid_MaterialsGrid_rec_0' and @line='1']";
            public static string editButton = "//td[@id='tb_MaterialsGrid_toolbar_item_edit']//td[text()='Edit']";
        }

        public class Materials
        {
            public static string selectMaterialsFromTable = "//tr[contains(@id,'grid_grid_rec_')]//td[@col='1']//div[1]";
            public static string editButton = "//td[@id='tb_grid_toolbar_item_editLength']//td[text()='Edit']";
            public static string dimension1 = "//label[text()='Dimension1']//following::input[@id='Dimension1']";
            public static string dimension2 = "//label[text()='Dimension2']//following::input[@id='Dimension2']";
            public static string backToList = "//a[text()='Back to List']";
            public static string deleteButton = "//td[@id='tb_grid_toolbar_item_deleteLength']//td[text()='Delete']";
            public static string addButton = "//td[@id='tb_grid_toolbar_item_addLength']//td[text()='Add']";
            public static string skuInputField = "//label[text()='Sku']//following::input[@id='Sku']";
            public static string supplierIdInputField = "//label[text()='SupplierId']//following::input[@id='SupplierId']";
            public static string supplierSKUInputField = "//label[text()='SupplierSku']//following::input[@id='SupplierSku']";
            public static string descriptionInputField = "//label[text()='Description']//following::input[@id='Description']";
            public static string framingProfile = "//select[@name='FramingProfile']";
            public static string framingColor = "//select[@name='FramingColor']";
            public static string saveButton = "//input[@value='Save']";
            public static string DownloadButton = "//td[@id='tb_grid_toolbar_item_download']//td[text()='Download']";
            public static string CSVButton = "//div[@id='w2ui-overlay']//td[text()='as CSV file']";
            public static string ExcelButton = "//div[@id='w2ui-overlay']//td[text()='as XLSX file']";
        }

        public class Trusses
        {
            public static string saveButton = "//div[@id='w2ui-popup']//button[@id='Save']";
            public static string searchInputField = "//input[@id='grid_grid_search_all']";
            public static string clickTableElement = "//div[@id='grid_grid_records']//span[text()='{0}']";
            public static string deleteButton = "//div[@id='trussList']//td[@id='tb_grid_toolbar_item_delete']";
            public static string waitForTheDeletePopupOpen = "//div[text()='Delete the selected trusses?']";
            public static string yesButton = "//div[@id='w2ui-popup']//button[text()='Yes']";
            public static string waitForTheTableDataLoad = "(//div[text()='$250.00'])[1]";
            public static string firstRowElement = "(//span[contains(text(),'{0}')])[2]";
            public static string skuInputField = "//div[@class='w2ui-page page-0']//label[text()='Sku']//following::input[@name='Sku']";
            public static string descriptionInputField = "//div[@class='w2ui-page page-0']//label[text()='Description']//following::input[@name='Description']";
            public static string vendorSkuInputField = "//div[@class='w2ui-page page-0']//label[text()='Vendor SKU']//following::input[@name='VendorSku']";
            public static string spanInputField = "//div[@class='w2ui-page page-0']//label[text()='Span']//following::input[@name='SpanStr']";
            public static string dim2InputField = "//div[@class='w2ui-page page-0']//label[text()='Dim2']//following::input[@name='Dim2Str']";
            public static string pitchInputField = "//div[@class='w2ui-page page-0']//label[text()='Pitch']//following::input[@name='Pitch']";
            public static string pitch2InputField = "//div[@class='w2ui-page page-0']//label[text()='Pitch2']//following::input[@name='Pitch2']";
            public static string heelInputField = "//div[@class='w2ui-page page-0']//label[text()='Heel']//following::input[@name='HHStr']";
            public static string minOHLInputField = "//div[@class='w2ui-page page-0']//label[text()='Min OH L']//following::input[@name='MinOHLStr']";
            public static string maxOHLInputField = "//div[@class='w2ui-page page-0']//label[text()='Max OH L']//following::input[@name='MaxOHLStr']";
            public static string minOHRInputField = "//div[@class='w2ui-page page-0']//label[text()='Min OH R']//following::input[@name='MinOHRStr']";
            public static string maxOHRInputField = "//div[@class='w2ui-page page-0']//label[text()='Max OH R']//following::input[@name='MaxOHRStr']";
            public static string cantLInputField = "//div[@class='w2ui-page page-0']//label[text()='Cant L']//following::input[@name='CantLStr']";
            public static string cantRInputField = "//div[@class='w2ui-page page-0']//label[text()='Cant R']//following::input[@name='CantRStr']";
            public static string minSpacingInputField = "//div[@class='w2ui-page page-0']//label[text()='Min Spacing']//following::input[@name='MinSpacingStr']";
            public static string maxSpacingInputField = "//div[@class='w2ui-page page-0']//label[text()='Max Spacing']//following::input[@name='MaxSpacingStr']";
            public static string loadingInputField = "//div[@class='w2ui-page page-0']//label[text()='Loading']//following::input[@name='Loading']";
            public static string downloadButton = "//td[@id='tb_grid_toolbar_item_download']//td[text()='Download']";
            public static string excelFileButton = "//div[@id='w2ui-overlay']//td[text()='as XLSX file']";
            public static string uploadButton = "//td[@id='tb_grid_toolbar_item_upload']//td[text()='Upload']";
            public static string waitForTheUploadList = "//section[@id='upload-truss-list']";
            public static string chooseFile = "//input[@id='fileBox']";
            public static string uploadFile = "//button[text()='Upload']";
            public static string waitForTheConfirmationMessage = "//h3[contains(text(),'Your update is now processing.')]";
            public static string backToListButton = "//a[text()='Back to List']";
            public static string addButton = "//td[@id='tb_grid_toolbar_item_add']//td[text()='Add']";
            public static string sku = "//div[@id='w2ui-popup']//label[text()='Sku']//following::input[@name='Sku']";
            public static string description = "//div[@id='w2ui-popup']//label[text()='Description']//following::input[@name='Description']";
            public static string isGableCheckbox = "//div[@id='w2ui-popup']//label[text()='Is Gable']//following::input[@name='isGable']";
            public static string tcStyleDropdown = "//div[@id='w2ui-popup']//label[text()='TC Style']//following::div[2]";
            public static string materialDropdown = "//div[@id='w2ui-popup']//label[text()='Material']//following::div[2]";
            public static string specialFlagsDropdown = "//div[@id='w2ui-popup']//label[text()='Special Flags']//following::div[2]";

        }

        public class OutputPagesLocator
        {
            public static string addButton = "//td[@id='tb_grid_toolbar_item_add']//td[text()='Add']";
            public static string description = "//div[@class='w2ui-page page-0']//label[text()='Description']//following::input[@name='Description']";
            public static string typeDropdown = "//div[@class='w2ui-page page-0']//label[text()='Type']//following::div[2]";
            public static string ignoreUsageCheckbox = "//div[@class='w2ui-page page-0']//label[text()='IgnoreUsage']//following::input[@name='IgnoreUsage']";
            public static string groupAddonsCheckbox = "//div[@class='w2ui-page page-0']//label[text()='GroupAddons']//following::input[@name='GroupAddons']";
            public static string saveButton = "//div[@class='w2ui-page page-0']//following::button[@name='Save']";
            public static string mainSaveButton = "//td[@id='tb_grid_toolbar_item_save']//td[text()='Save']";
            public static string getTheAllElementName = "//div[@id='grid_grid_records']//tr//td[7]//div";
            public static string deleteButton = "//td[@id='tb_grid_toolbar_item_delete']//td[text()='Delete']";
            public static string yesButton = "//div[@id='w2ui-popup']//button[@id='Yes']";
            public static string uploadButton = "//button[@id='uploadBtn']";
            public static string chooseFile = "//input[@id='fileTemplate']";
            public static string outputType = "//div[@id='w2ui-popup']//label[text()='OutputType']//following::div[2]";
            public static string editButton = "//td[@id='tb_grid_toolbar_item_edit']//td[text()='Edit']";
            public static string doorAndWindowCheckbox = "//div[@id='w2ui-popup']//label[text()='Doors & Windows']//following::input[@name='Doors & Windows']";
        }

        public class DistributorLocators
        {
            public static string inputSearchField = "//input[@id='grid_grid_search_all']";
            public static string checkboxes = "(//tr[@id='grid_grid_rec_1147']//input[@type='checkbox'])[{0}]";
            public static string saveButton = "//td[@id='tb_grid_toolbar_item_save']//td[text()='Save']";
            public static string addDistributor = "//td[@id='tb_grid_toolbar_item_addDistributor']//td[text()='Add Distributor']";
            public static string postFrame = "//div[@id='w2ui-overlay']//td[text()='Post Frame']";
            public static string distributorName = "//input[@name='Name']";
            public static string selectParentDistributor = "//select[contains(@id,'SourceDist')]";
            public static string createButton = "//input[@value='Create']";
            public static string pageScroll = "document.querySelector('#grid_grid_records').scrollBy({0},{1})";
        }

        public class EModeler
        {
            public static string uploadFile = "//input[@id='fileBox']";
            public static string saveButton = "//input[@value='Save Changes']";
            public static string CopyEModelerLink = "//td[text()='{0}']//following::i[1]";
            public static string acknowledgment = "//textarea[@id='RequestQuoteAcknowledgment']";
        }

        public class OutputCategories
        {
            public static string addButton = "//td[@id='tb_grid_toolbar_item_add']//td[text()='Add']";
            public static string lastInputField = "(//tr[contains(@class,'w2ui-empty-record')])[1]//preceding::tr[contains(@id,'grid_grid_rec')][3]//td[@class='w2ui-grid-data'][1]";
            public static string saveButton = "//td[@id='tb_grid_toolbar_item_save']//td[text()='Save']";
            public static string selectMaterialFromOutputsCategoriesTable = "//tr[contains(@id,'grid_grid_rec_')]//td[@col='0']//div";
            public static string deleteButton = "//td[@id='tb_grid_toolbar_item_delete']//td[text()='Delete']";
            public static string usageTableData = "//tr[contains(@id,'grid_usageGrid_rec_')]//td[@col='0']//div";
            public static string nameOfOutputCategoriesOption = "//div[@id='w2ui-overlay']//td[text()='{0}']";
            public static string moveButton = "//td[@id='tb_usageGrid_toolbar_item_move']//td[text()='Move']";
            public static string getTheDataFromPopup = "//div[@id='w2ui-popup']//div[@class='w2ui-centered']";
            public static string okButton = "//div[@id='w2ui-popup']//button[text()='Ok']";
        }

        public class DoorsAndWindowsElement
        {
            public static string getTheAllElementFromTable = "//tr[contains(@id,'grid_grid_rec_')]//td[@col='2']//div";
            public static string widthInputField = "//label[text()='Width']//following::input[@id='Dimension1']";
            public static string backToList = "//a[text()='Back to List']";
            public static string uploadButton = "//td[@id='tb_grid_toolbar_item_upload']//td[text()='Upload']";
            public static string chooseFile = "//input[@id='fileBox']";
            public static string uploadFileButton = "//button[@id='uploadBtn']";
            public static string waitForTheFileUpload = "//h3[contains(text(),'Your update is now processing.')]";
        }

        public class CustomizeElement
        {
            public static string uploadButton = "//input[@type='file']";
            public static string deleteButton = "//div[@id='objClear']";
            public static string saveButton = "//input[@value='Save Changes']";
            public static string homeLinkInputField = "//input[@name='HomeLink']";
            public static string aboutLinkInputField = "//input[@name='AboutLink']";
            public static string contactLinkInputField = "//input[@name='ContactLink']";
            public static string includeCheckbox = "//input[@id='IncludeFeedback']";
            public static string waterMarkCheckbox = "//input[@id='AddWatermark']";
            public static string okayButton = "//div[@id='w2ui-popup']//button[text()='Ok']";
        }

        public class PaymentSchedule
        {
            public static string getPaymentScheduleTableData = "(//div[@id='grid_grid_records']//td[@col='{0}']/div)[{1}]";
            public static string saveButton = "//td[@id='tb_grid_toolbar_item_save']//td[text()='Save']";
            public static string yesButton = "//div[@id='w2ui-popup']//button[text()='Yes']";
        }

        public class PricingLocator
        {
            public static string searchElement = "//input[@id='grid_grid_search_all']";
            public static string activeDistributor = "//select[@id='activeDist']";
            public static string checkHideCheckbox = "//tr[contains(@id,'grid_grid_rec_') and @line='1']//td[@col='7']//input[1]";
        }
    }
}
