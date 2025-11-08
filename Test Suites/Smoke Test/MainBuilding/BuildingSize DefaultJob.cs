using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Test_Suites.Smoke_Test
{
    public class BuildingSizeTests : BaseClass
    {
        public List<string> storeColorName = new();
        private const string TestReportTitle = "Test Report of Smoke Test";
        private static readonly string[] WidthMaterialValues = { "20'", "30'", "40'", "50'" };
        private static readonly string[] LengthMaterialValues = { "20'", "60'", "40'", "100'" };
        private static readonly string[] colorName = { "Accent Color 1", "Accent Color 2", "Accent Color 3", "Accent Color 4" };
        private static readonly string[] ChangesColorName = { "Test Color 1", "Test Color 2", "Test Color 3", "Test Color 4" };
        private static readonly string DownloadFolderPath = FolderPath.Download();

        [Test, Order(1)]
        public void BuildingSizeFunctionality()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Smoke test on the Main Building Sub-Menu Functionality");
            CreateAndDeleteFolder(DownloadFolderPath);
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            SetTheColorNameInTheFramingRulesToDefault();
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksStartFromScratch();         
            BuildingSize();    
        }

        [Test, Order(2)]
        public void WainscotFunctionality()
        {
            Wainscot();
            Colors();
            WallLiner();
            CeilingLiner();
            UpperSheathing();
        }

        [Test, Order(3)]
        public void ChangeColorsNameAndDeleteCreateJob()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Delete Jobs");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            SetTheColorNameInTheFramingRulesToDefault();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("CheckMeasureFrom");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail(TestReportTitle);
        }

        #region Building Size
        // This method is used to get the folder path of SmokeTestOnBuildingSize
        private static string FolderPathOfScreenshot(string fileName)
        {
            string getFile = FolderPath.SmokeTestOnBuildingSize(fileName);
            return getFile;
        }

        // This method is used to get the folder path of Advanced
        private static string AdvancedFolderPath(string fileName)
        {
            string advancedFolderPath = FolderPath.Advanced(fileName);
            return advancedFolderPath;
        }

        private void BuildingSize()
        {
            ExtentTestManager.CreateTest("Smoke test on the Building Size Functionality");
            DefaultJobElement.ClickBuildingSize();
            CheckAllElementsOfBuildingSizeDropdown();
            CheckAllElementsOfMeasureFromDropdown();
            CheckRoofHeightStyleElements();
            CheckAllRoofStyleElements();
            CheckOverhangElements();
        }

        // This method is used to check static building size of canvas. 
        private void CheckAllElementsOfBuildingSizeDropdown()
        {
            DefaultJobElement.ServerDelay();

            for (int index = 0; index < LengthMaterialValues.Length; index++)
            {
                string captureScreenOfBuildingSize = FolderPathOfScreenshot("BuildingSizeCanvas");
                CreateAndDeleteFolder(captureScreenOfBuildingSize);
                string sizeSelection = $"{WidthMaterialValues[index]} x {LengthMaterialValues[index]}";
                DefaultJobElement.SelectBuildingSizeMaterial(sizeSelection);
                CommonMethod.Wait(2);
                RefreshJobPage();
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                CommonMethod.Wait(2);

                bool isLengthEnabled = DefaultJobElement.LengthField().Enabled;
                bool isWidthEnabled = DefaultJobElement.WidthField().Enabled;
                Assert.That(isLengthEnabled || isWidthEnabled, Is.False,
                    $"After selecting {sizeSelection}, the length and width fields should be disabled.");
                ExtentTestManager.TestSteps($"After selecting {sizeSelection}, the length and width fields are disabled");

                string lengthValue = DefaultJobElement.GetLengthValue();
                string widthValue = DefaultJobElement.GetWidthValue();
                Assert.That(lengthValue, Is.EqualTo(LengthMaterialValues[index]));
                Assert.That(widthValue, Is.EqualTo(WidthMaterialValues[index]));
                DefaultJobElement.CaptureScreenShot(captureScreenOfBuildingSize, $"{sizeSelection}.png");
            }

            TestCustomSizeFunctionality();
        }

        // This method is used to get the custom size canvas building
        private void TestCustomSizeFunctionality()
        {
            CommonMethod.Wait(1);
            DefaultJobElement.SelectBuildingSizeMaterial("Custom Size");
            CommonMethod.Wait(2);
            RefreshJobPage();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CommonMethod.Wait(2);

            string captureScreenOfBuildingSize = FolderPathOfScreenshot("BuildingSizeCanvas");
            string customSize = DefaultJobElement.GetBuildingSizeMaterialValue();
            Assert.That(customSize, Is.EqualTo("Custom Size"));
            CommonMethod.Wait(2);

            bool isCustomLengthEnabled = DefaultJobElement.LengthField().Enabled;
            bool isCustomWidthEnabled = DefaultJobElement.WidthField().Enabled;
            Assert.That(isCustomLengthEnabled && isCustomWidthEnabled, Is.True,
                $"After selecting {customSize}, the length and width fields should be enabled.");
            ExtentTestManager.TestSteps($"After selecting {customSize}, the length and width fields are enabled");

            DefaultJobElement.LengthInputField("40");
            DefaultJobElement.WidthInputField("30");

            RefreshJobPage();

            string finalLengthValue = DefaultJobElement.GetLengthValue();
            string finalWidthValue = DefaultJobElement.GetWidthValue();
            Assert.That(finalLengthValue, Is.EqualTo("40'"));
            Assert.That(finalWidthValue, Is.EqualTo("30'"),
                "After selecting Custom Size, the length and width fields should be editable.");
            ExtentTestManager.TestSteps($"After selecting Custom Size, the length and width fields are editable.");
            DefaultJobElement.CaptureScreenShot(captureScreenOfBuildingSize, $"Custom Size.png");
        }

        // This method is used to check outside of girt and post material lengths are shown in the pdf file
        private void CheckAllElementsOfMeasureFromDropdown()
        {
            ExtentTestManager.CreateTest("Measure From");
            TestMeasureFromElement("Outside Of Girt", new List<string> { "50'", "40'", "30'" });
            DefaultJobElement.ClickMainBuilding();
            TestMeasureFromElement("Outside of Post", new List<string> { "50' 4 3/16\"", "40' 3\"", "30' 3\"" });
        }

        // This method is used to changes the measure from material and download pdf file.
        private void TestMeasureFromElement(string measureFrom, List<string> expectedLengths)
        {
            DefaultJobElement.SelectMeasureFromMaterial(measureFrom);
            string measureFromText = DefaultJobElement.GetMeasureFromValue();

            if (measureFromText == "Outside Of Girt")
            {
                DefaultJobElement.ClicksJobButton();
                DefaultJobElement.EnterJobNameInputField("CheckMeasureFrom");
            }

            SaveJobAndDownloadOutputsPdfFile("Post Layout Overall & Diag OoF");

            if (measureFromText == "Outside Of Girt")
            {
                string pdfFilePath = GetFilePath("CheckMeasureFrom", ".pdf");
                CheckDataFromThePdfFile(pdfFilePath, expectedLengths, measureFromText);
            }
            else
            {
                string pdfFilePath = GetFilePath("CheckMeasureFrom", " (1).pdf");
                CheckDataFromThePdfFile(pdfFilePath, expectedLengths, measureFromText);
            }
        }

        // This method is used to check all materials of Roof Height style dropdown
        private void CheckRoofHeightStyleElements()
        {
            ExtentTestManager.CreateTest("Roof Height Style");
            TopOfWallMaterialElement();
            CheckCeilingHeightAndRoofPitchElements();
        }

        // This method is used to check Ceiling height and roof pitch materials length using cross-section pdf 
        private void CheckCeilingHeightAndRoofPitchElements()
        {
            DefaultJobElement.SelectRoofHeightStyleMaterial("Ceiling Height");
            RefreshJobPage();

            bool isExteriorMetalHeightDisabled = !DefaultJobElement.ExteriorMetalHeightField().Enabled;
            Assert.That(isExteriorMetalHeightDisabled, Is.True, "If the user sets 'Ceiling Height' to 'Roof Height Style' dropdown, the Exterior Metal Height should be disabled.");
            ExtentTestManager.TestSteps($"If the user sets 'Ceiling Height' to 'Roof Height Style' dropdown, the Exterior Metal Height field is disabled");

            DefaultJobElement.CeilingHeightInputField("17'");
            string ceilingHeight = DefaultJobElement.GetCeilingHeightValue();
            DefaultJobElement.RoofPitchInputField("3");
            SaveJobAndDownloadOutputsPdfFile("Cross Sections");
            string pdfFilePath = GetFilePath("CheckMeasureFrom", ".pdf");
            string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            Assert.That(readDataFromPdfFile.Contains(ceilingHeight), "Ceiling height is not correctly shown in the cross section pdf file");
            ExtentTestManager.TestSteps($"Ceiling height is shown in the cross section pdf file");
            Assert.That(readDataFromPdfFile.Contains("3/12"), "Roof pitch data is not correctly shown in the cross section pdf file");
            ExtentTestManager.TestSteps($"Roof pitch is shown in the cross section pdf file");
        }

        // This method is used to check top of wall material from the drawing table
        private void TopOfWallMaterialElement()
        {
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            CreateAndDeleteFolder(DownloadFolderPath);
            RefreshJobPage();

            bool isCeilingHeightDisabled = !DefaultJobElement.CeilingHeightField().Enabled;
            Assert.That(isCeilingHeightDisabled, Is.True, "If the user sets 'Top Of Wall Material' to 'Roof Height Style' dropdown, the Ceiling Height should be disabled.");
            ExtentTestManager.TestSteps($"If the user sets 'Top Of Wall Material' to 'Roof Height Style' dropdown, the ceiling height field is disabled");

            DefaultJobElement.ClickWainscot();
            DefaultJobElement.UncheckHasWainscotCheckbox();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.ExteriorMetalHeightInputField("12'");
            RefreshJobPage();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", null, null, null, "12'");
            ExtentTestManager.TestSteps($"Exterior Wall Length is update after changing the exterior metal height");

            DefaultJobElement.ClickCanvas3DViewButton();
        }

        // This Method is used to check Roof Style elements
        private void CheckAllRoofStyleElements()
        {
            DefaultJobElement.CeilingHeightInputField("16'");
            DefaultJobElement.RoofPitchInputField("4");
            string captureScreenOfRoofStyle = FolderPathOfScreenshot("RoofStyle");
            CreateAndDeleteFolder(captureScreenOfRoofStyle);

            ExtentTestManager.CreateTest("Roof Style");
            CaptureRoofStyle("Shed", "FrontRight", captureScreenOfRoofStyle, "Shed.png");
            CaptureRoofStyle("Gable", "BackRight", captureScreenOfRoofStyle, "Gable.png");
            CaptureRoofStyle("Gambrel", "FrontElevation", captureScreenOfRoofStyle, "Gambrel.png");

            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            string offsetToGable = OpenAdvancedElementOfRoofStyleAndCheckStyleElement("Offset Gable");
            EnterDataInTheSlopeField(offsetToGable);

            DefaultJobElement.ClickAdvancedFrameApplyButton();
            RefreshJobPage();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string roofPitch = DefaultJobElement.GetRoofPitchValue();
            Assert.That(roofPitch, Is.EqualTo("9"), "After changing the slope of Offset Gable, the roof pitch value is not update in the main building.");
            ExtentTestManager.TestSteps($"Roof pitch value updated after changing the slope value of Offset Gable.");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            CheckOffsetGableInputField();
            CheckStyleOfAdvancedInputField("Asymetric Gable", "left slope", "10");
            CheckAsymmetricInputField();

            CheckStyleOfAdvancedInputField("Western", "upper slope", "9");
            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            CheckInputFieldOfWestern();
            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            CheckStyleOfAdvancedInputField("Gambrel", "upper slope", "9");
        }

        // This method is used to check slope and offset materials value of Offset Gable style from roof style of Advanced
        private static void CheckOffsetGableInputField()
        {
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            string checkOffsetGableStyle = DefaultJobElement.GetStyleValueOfAdvancedRoofStyle();
            Assert.That(checkOffsetGableStyle, Is.EqualTo("Offset Gable"), "Reopening the roof style field changed the style value.");
            string checkSlope = DefaultJobElement.GetSlopeOfAdvancedRoofStyleValue();
            Assert.That(checkSlope, Is.EqualTo("9"), "Reopening the roof style field changed the slope value.");
            string checkOffsetToPeak = DefaultJobElement.GetOffsetToPeakOfAdvancedRoofStyleValue();
            Assert.That(checkOffsetToPeak, Is.EqualTo("10'"), "Reopening the roof style field changed the Offset To Peak value.");
        }

        // This method is used to check left slope and right slope materials value of Asymetric Gable style from roof style of Advanced
        private static void CheckAsymmetricInputField()
        {
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.SelectRoofStyleMaterial("Advanced...");
            CommonMethod.Wait(1);
            string checkAsymmetricGableStyle = DefaultJobElement.GetStyleValueOfAdvancedRoofStyle();
            Assert.That(checkAsymmetricGableStyle, Is.EqualTo("Asymetric Gable"), "Reopening the roof style field changed the Asymmetric Gable value.");
            string checkLeftSlope = DefaultJobElement.GetLeftSlopeOfAdvancedRoofStyleValue();
            Assert.That(checkLeftSlope, Is.EqualTo("10"), "Reopening the roof style field changed the left slope value.");
            string checkRightSlope = DefaultJobElement.GetRightSlopeOfRoofStyleAdvancedValue();
            Assert.That(checkRightSlope, Is.EqualTo("9"), "Reopening the roof style field changed the right slope value.");
        }

        // This method is used to check upper slope and upper slope materials value of Western style from roof style of Advanced
        private static void CheckInputFieldOfWestern()
        {
            string checkWestern = DefaultJobElement.GetStyleValueOfAdvancedRoofStyle();
            Assert.That(checkWestern, Is.EqualTo("Western"), "Reopening the roof style field changed the Western value.");
            string checkUpperSlope = DefaultJobElement.GetUpperSlopeOfAdvancedRoofStyleValue();
            Assert.That(checkUpperSlope, Is.EqualTo("9"), "Reopening the roof style field changed the upper slope value.");
            string checkLowerSlope = DefaultJobElement.GetLowerSlopeOfAdvancedRoofStyleValue();
            Assert.That(checkLowerSlope, Is.EqualTo("6"), "Reopening the roof style field changed the lower slope value.");
            string checkOffsetToCurb = DefaultJobElement.GetOffsetToCurbOfAdvancedRoofStyleValue();
            Assert.That(checkOffsetToCurb, Is.EqualTo("10'"), "Reopening the roof style field changed the Offset To Curb value.");
        }

        // This method is to click Advanced.. element of Roof Style and perform actions
        private void CheckStyleOfAdvancedInputField(string nameOfElement, string slopeName, string roofPitchValue)
        {
            string style = OpenAdvancedElementOfRoofStyleAndCheckStyleElement(nameOfElement);
            EnterDataInTheSlopeField(style);
            DefaultJobElement.ClickAdvancedFrameApplyButton();
            RefreshJobPage();

            string roofPitch = DefaultJobElement.GetRoofPitchValue();
            Assert.That(roofPitch, Is.EqualTo(roofPitchValue), $"After changing the {slopeName} of {nameOfElement}, the roof pitch value did not update in the main building.");
            ExtentTestManager.TestSteps($"Roof pitch value updated after changing the {slopeName} value of {nameOfElement}.");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        // This method is used to select roof style element and create folder
        private string OpenAdvancedElementOfRoofStyleAndCheckStyleElement(string elementName)
        {
            try
            {
                DefaultJobElement.SelectStyleOfRoofStyleAdvanced(elementName);
            }
            catch (StaleElementReferenceException)
            {
                DefaultJobElement.SelectStyleOfRoofStyleAdvanced(elementName);
            }

            string folderPath = AdvancedFolderPath(elementName);
            CreateAndDeleteFolder(folderPath);
            return folderPath;
        }

        private void CaptureRoofStyle(string style, string view, string folderPath, string fileName)
        {
            DefaultJobElement.SelectRoofStyleMaterial(style);
            ChangeView(view);
            RefreshJobPage();
            DefaultJobElement.CaptureScreenShot(folderPath, fileName);
        }

        private void ChangeView(string view)
        {
            switch (view)
            {
                case "FrontRight":
                    DefaultJobElement.ChangeViewFrontRight();
                    break;
                case "BackRight":
                    DefaultJobElement.ChangeViewBackRight();
                    break;
                case "FrontElevation":
                    DefaultJobElement.ChangeViewFrontElevation();
                    break;
            }
        }

        private void EnterDataInTheSlopeField(string location)
        {
            CommonMethod.Wait(1);
            string style = DefaultJobElement.GetStyleValueOfAdvancedRoofStyle();

            if (style != null && (style.Equals("Offset Gable") || style.Equals("Asymetric Gable")))
            {
                string[] slopes = { "5", "7", "9" };
                string[] offsetToPeaks = { "20", "15", "10" };
                for (int i = 0; i < slopes.Length; i++)
                {
                    if (style.Equals("Offset Gable"))
                    {
                        DefaultJobElement.SlopeOfAdvancedRoofStyleInputField(slopes[i]);
                        DefaultJobElement.OffsetToPeakOfAdvancedRoofStyleInputField(offsetToPeaks[i]);
                        DefaultJobElement.CaptureScreenShotOfAdvanced(location, $"Slope{slopes[i]}xOffsetToPeak{offsetToPeaks[i]}.png");
                    }
                    else
                    {
                        DefaultJobElement.RightSlopeOfRoofStyleAdvanced(slopes[i]);
                        DefaultJobElement.LeftSlopeOfAdvancedRoofStyleInputField(offsetToPeaks[i]);
                        DefaultJobElement.CaptureScreenShotOfAdvanced(location, $"RightSlope{slopes[i]}xLeftSlope{offsetToPeaks[i]}.png");
                    }
                }
            }
            else
            {
                string[] upperSlopes = { "6", "8", "9" };
                string[] lowerSlopes = { "4", "5", "6" };
                string[] offsetToCurbs = { "8", "9", "10" };

                for (int i = 0; i < upperSlopes.Length; i++)
                {
                    DefaultJobElement.UpperSlopeOfAdvancedRoofStyleInputField(upperSlopes[i]);
                    DefaultJobElement.LowerSlopeOfAdvancedRoofStyleInputField(lowerSlopes[i]);
                    DefaultJobElement.OffsetToCurbOfAdvancedRoofStyleInputField(offsetToCurbs[i]);
                    DefaultJobElement.CaptureScreenShotOfAdvanced(location, $"UpperSlope{upperSlopes[i]}xLowerSlope{lowerSlopes[i]}xOffsetToCurb{offsetToCurbs[i]}.png");
                }
            }
        }

        private void CheckOverhangElements()
        {
            string captureScreenOfOverhang = FolderPathOfScreenshot("Overhang");
            CreateAndDeleteFolder(captureScreenOfOverhang);

            if (CommonMethod.IsElementPresent(By.XPath(Locator.CommonXPath.waitForTheSpinner)))
            {
                CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            }

            DefaultJobElement.SelectRoofStyleMaterial("Gable");
            DefaultJobElement.LengthInputField("18");
            DefaultJobElement.WidthInputField("18");
            DefaultJobElement.RoofPitchInputField("4");

            string[] overhangTrusses = new string[] { "0' 6\"", "1'", "1' 4\"", "1' 6\"", "2'", "2' 6\"", "3'" };
            string[] materialOfTrusses = new string[] { "0.5", "1", "1.5", "1.5", "2", "2.5", "3" };

            for (int i = 0; i < overhangTrusses.Length; i++)
            {
                CommonMethod.Wait(2);
                DefaultJobElement.SelectOverhangMaterial(overhangTrusses[i]);
                RefreshJobPage();
                DefaultJobElement.CaptureScreenShot(captureScreenOfOverhang, $"Overhang Of {materialOfTrusses[i]}.png");
                DefaultJobElement.ClickJobReview();
                DefaultJobElement.ClickTrussesOfJobReview();
                string overhangValue = CheckMaterialOfTrusses();
                Assert.That(overhangValue.Contains(materialOfTrusses[i]), $"Overhang is not apply on the canvas building {overhangTrusses[i]}");
                ExtentTestManager.TestSteps($"Verify that the Overhang is apply on the canvas building {overhangTrusses[i]}");
                DefaultJobElement.ClickCanvas3DViewButton();
            }

            DefaultJobElement.ClicksSaveButton();
        }

        private string CheckMaterialOfTrusses()
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.DefaultJob.firstMaterialOfTrusses))).Text;
        }

        private void RefreshJobPage()
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private string GetDate()
        {
            string currentDate = DateTime.Now.ToString("MM-dd-yyyy");
            return currentDate;
        }

        private string GetFilePath(string jobName, string fileType)
        {
            string currentDate = GetDate();
            string pdfFileName = $"{jobName}_{currentDate}{fileType}";
            string pdfFilePath = System.IO.Path.Combine(DownloadFolderPath, pdfFileName);
            ExtentTestManager.TestSteps($"Verify PDF File is downloaded for {jobName}");
            FolderPath.WaitForFileDownload(pdfFilePath, 60);
            return pdfFilePath;
        }

        private void SaveJobAndDownloadOutputsPdfFile(string checkboxName)
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClicksOutputButton();
            DefaultJobElement.CheckOutputsCheckbox(checkboxName);
            DefaultJobElement.ClicksDownloadButton();
        }

        private void CheckDataFromThePdfFile(string pathOfFile, List<string> measureLengths, string nameOfMeasureFromElement)
        {
            string readDataFromPdfFile = DefaultJobElement.CheckDataFromPDFFiles(pathOfFile);

            int elementCount = 0;
            foreach (string measureLength in measureLengths)
            {
                if (readDataFromPdfFile != null && readDataFromPdfFile.Contains(measureLength))
                {
                    ExtentTestManager.TestSteps($"{nameOfMeasureFromElement} material {measureLength} length is shown in the PDF file");
                    elementCount++;
                }
            }

            Assert.That(elementCount, Is.EqualTo(measureLengths.Count), $"{nameOfMeasureFromElement} are not correctly shown in the PDF file");
        }

        private void CreateAndDeleteFolder(string folder)
        {
            FolderPath.CreateFolder(folder);
            CommonMethod.DeleteFolderFile(folder);
        }
        #endregion

        #region Wainscot 
        private void Wainscot()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Smoke test on the Wainscot Functionality");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("CheckMeasureFrom");
            CommonMethod.PageLoader();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickWainscot();
            DefaultJobElement.UncheckHasWainscotCheckbox();
            bool isDisabledWainscotHeightField = !DefaultJobElement.WainscotHeightField().Enabled;
            Assert.That(isDisabledWainscotHeightField, Is.True, "Verify that if 'Has Wainscot' checkbox is uncheck, the Wainscot Height input field is enable");
            ExtentTestManager.TestSteps($"Verify that if the 'Has Wainscot' checkbox is unchecked, the Wainscot Height is disabled");

            DefaultJobElement.CheckHasWainscotCheckbox();
            bool isEnableWainscotHeightField = DefaultJobElement.WainscotHeightField().Enabled;
            Assert.That(isEnableWainscotHeightField, Is.True, "Verify that if 'Has Wainscot' checkbox is check, the Wainscot Height input field is disabled");
            ExtentTestManager.TestSteps($"Verify that if the 'Has Wainscot' checkbox is checked, the Wainscot Height input field is enabled");

            DefaultJobElement.WainscotHeightInputField("5");
            DefaultJobElement.SelectWainscotColorMaterial("BRIGHT RED");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("Wainscot", null, null, null, "5'");
            ExtentTestManager.TestSteps($"Wainscot Length is update after changing the wainscot height field");

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "Wainscot", null, null, "BRIGHT RED", null, null, null, "5'", null, null);
            ExtentTestManager.TestSteps($"Verify that the wainscot color is apply on the canvas");
            DefaultJobElement.ClickCanvas3DViewButton();
        }
        #endregion

        #region The Colors
        private void Colors()
        {
            ExtentTestManager.CreateTest("Smoke test on the Colors Functionality");
            DefaultJobElement.ClickColors();
            GetColorName();
            DefaultJobElement.SelectRoofColor("BRIGHT RED");
            DefaultJobElement.SelectWallColor("ROYAL BLUE");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
                                                                                                                                                                                                                                         
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "ExteriorRoof", null, null, "BRIGHT RED", null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the roof color is apply on the canvas");
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "ExteriorWall", null, null, "ROYAL BLUE", null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the wall color is apply on the canvas");
            CheckColorElementShownInTheWallTrim();
                                                                                                                                                                                                                 
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();   
            ChangeTheColorNameInTheFramingRules();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("CheckMeasureFrom");
            CommonMethod.PageLoader();
            storeColorName.Clear();
            DefaultJobElement.ClickColors();
            CheckColorNameIsUpdate();
            GetColorName();
            CheckColorElementShownInTheWallTrim();

            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickROOF_1();
            ApplyColorOnRoof("ESPRESSO");
            DefaultJobElement.ClickROOF_2();
            ApplyColorOnRoof("CHARCOAL");
            DefaultJobElement.ClickEXT_1();
            ApplyColorOnTheExteriorWall("BRIGHT RED");
            DefaultJobElement.ClickEXT_2();
            ApplyColorOnTheExteriorWall("Cambridge");
            DefaultJobElement.ClickEXT_3();
            ApplyColorOnTheExteriorWall("CHARCOAL");
            DefaultJobElement.ClickEXT_4();
            ApplyColorOnTheExteriorWall("COFFEE BROWN");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderForApplyElementOnCanvas2DBuilding();

            // Check colors is applying on the canvas building using drawing table data
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingROOF_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorRoof", "ESPRESSO", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply roof color in the advanced edit field of ROOF-1 is displayed in the sheathing assembly roof-1 table.");
            DefaultJobElement.ClickSheathingDrawingROOF_2();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorRoof", "CHARCOAL", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply roof color in the advanced edit field of ROOF-2 is displayed in the sheathing assembly roof-2 table.");
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", "BRIGHT RED", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply wall color in the advanced edit field of EXT-1 is displayed in the sheathing assembly EXT-1 table.");
            DefaultJobElement.ClickAssemblyDrawingEXT_2();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", "CHARCOAL", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply wall color in the advanced edit field of EXT-2 is displayed in the sheathing assembly EXT-2 table.");
            DefaultJobElement.ClickAssemblyDrawingEXT_3();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", "Cambridge", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply wall color in the advanced edit field of EXT-3 is displayed in the sheathing assembly EXT-3 table.");
            DefaultJobElement.ClickAssemblyDrawingEXT_4();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("ExteriorWall", "COFFEE BROWN", null, null, null);
            ExtentTestManager.TestSteps("Verify that the apply wall color in the advanced edit field of EXT-4 is displayed in the sheathing assembly EXT-4 table.");
            DefaultJobElement.ClickCanvas3DViewButton();
        }
        #endregion

        #region Wall Liner
        private void WallLiner()
        {
            ExtentTestManager.CreateTest("Smoke test on the Wall Liner");
            DefaultJobElement.ClickWallLiner();
            DefaultJobElement.UncheckedTheHasLinerPanelsCheckbox();
            Assert.That(!DefaultJobElement.WallLinerColors().Enabled, "If 'Has Liner Panels' is unchecked then 'Wall Liner Colors is disabled");
            Assert.That(!DefaultJobElement.InteriorTrimColor().Enabled, "If 'Interior Trim Color' is unchecked then 'Wall Liner Colors is disabled");
            Assert.That(!DefaultJobElement.InteriorWainscotHeight().Enabled, "If 'Interior Wainscot Height' is unchecked then 'Wall Liner Colors is disabled");
            Assert.That(!DefaultJobElement.InteriorWainscotColor().Enabled, "If 'Interior Wainscot Color' is unchecked then 'Wall Liner Colors is disabled");
            ExtentTestManager.TestSteps("If 'Has Liner Panels' is unchecked then 'Wall Liner Colors, Interior Trim Color, Interior Wainscot Color, Interior Wainscot Color are disabled");

            DefaultJobElement.CheckedTheHasLinerPanelsCheckbox();
            Assert.That(DefaultJobElement.WallLinerColors().Enabled, "If 'Has Liner Panels' is checked then 'Wall Liner Colors is disabled");
            Assert.That(DefaultJobElement.InteriorTrimColor().Enabled, "If 'Has Liner Panels' is checked then 'Wall Liner Colors is disabled");
            Assert.That(!DefaultJobElement.InteriorWainscotHeight().Enabled, "If 'Has Liner Panels' is checked then 'Interior Wainscot Height' is enabled");
            Assert.That(!DefaultJobElement.InteriorWainscotColor().Enabled, "If 'Has Liner Panels' is checked then 'Interior Wainscot Color' is enabled");
            ExtentTestManager.TestSteps($"Verify that if 'Has Liner Panels' is checked, then the 'Wall Liner Colors' and 'Wall Liner Colors' fields are enabled, and 'Interior Wainscot Height' and 'Interior Wainscot Color' are disabled.");

            DefaultJobElement.SelectWallLinerColors("BRIGHT RED");
            DefaultJobElement.SelectInteriorTrimColors("BURGUNDY");
            DefaultJobElement.CheckedTheHasInteriorWainscotCheckbox();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();       

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "InteriorWall", null, null, "BRIGHT RED", null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the wall liner color is apply on the canvas");
            DefaultJobElement.ConfiguredPrice().Click();
            DefaultJobElement.ClickTrimOfJobReview();

            string interiorTrimColor = DefaultJobElement.GetTheInteriorTrimColorValue();

            DefaultJobElement.CheckMaterialsDataFromJobReview("Trim", "InteriorWainscotTrim", null, null, interiorTrimColor, null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the interior trim color is apply on the canvas");

            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.UncheckedTheHasInteriorWainscotCheckbox();
            Assert.That(!DefaultJobElement.InteriorWainscotHeight().Enabled, "If 'Has Interior Wainscot' is unchecked then 'Interior Wainscot Height' is enabled");
            Assert.That(!DefaultJobElement.InteriorWainscotColor().Enabled, "If 'Has Interior Wainscot' is unchecked then 'Interior Wainscot Color' is enabled");
            ExtentTestManager.TestSteps($"Verify that if 'Has Interior Wainscot' is unchecked, then the 'Interior Wainscot Height' and 'Interior Wainscot Color' are disabled.");

            DefaultJobElement.CheckedTheHasInteriorWainscotCheckbox();
            Assert.That(DefaultJobElement.InteriorWainscotHeight().Enabled, "If 'Has Interior Wainscot' is checked then 'Interior Wainscot Height' is disabled");
            Assert.That(DefaultJobElement.InteriorWainscotColor().Enabled, "If 'Has Interior Wainscot' is checked then 'Interior Wainscot Color' is disabled");
            ExtentTestManager.TestSteps($"Verify that if 'Has Interior Wainscot' is checked, then the 'Interior Wainscot Height' and 'Interior Wainscot Color' are enabled.");

            DefaultJobElement.InternalWainscotHeightInputField("5");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickInteriorSheathingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("InteriorWainscot", null, null, null, "5'");
            ExtentTestManager.TestSteps($"Wainscot Length is update after changing the wainscot height field");
            DefaultJobElement.ClickCanvas3DViewButton();
        }
        #endregion

        #region Ceiling Liner
        private void CeilingLiner()
        {
            ExtentTestManager.CreateTest("Smoke test on the Ceiling Liner");
            DefaultJobElement.ClickWallLiner();
            DefaultJobElement.CheckedTheHasLinerPanelsCheckbox();
            DefaultJobElement.ClickWainscot();
            DefaultJobElement.UncheckHasWainscotCheckbox();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickCeilingLiner();
            DefaultJobElement.UncheckHasCeilingCheckbox();
            CheckCeilingColorAndCeilingTrimColorAreDisabled("Has Ceiling");
            DefaultJobElement.UncheckFlatCeilingCheckbox();
            CheckCeilingColorAndCeilingTrimColorAreDisabled("Flat Ceiling");
            DefaultJobElement.CheckHasCeilingCheckbox();
            DefaultJobElement.CheckFlatCeilingCheckbox();
            DefaultJobElement.SelectCeilingColorDropdown("BRIGHT RED");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Sheathing", "InteriorRoof", null, null, "BRIGHT RED", null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the ceiling color is apply on the canvas");

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickInteriorSheathingCEIL_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("InteriorRoof", null, null, null, null);
            ExtentTestManager.TestSteps($"InteriorRoof Length is update after changing the post material height field");
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToTheMaterialsPage();
            Materials.ClickOnTheMaterialElementAndEditButton("IB-1214-{LF}");
            string dimension1 = Materials.GetTheDimension1Value();
            Assert.That(dimension1, Is.EqualTo("3.97"), "Dimension 1 value is not set to 3.97");

            string dimension2 = Materials.GetTheDimension2Value();
            Assert.That(dimension2, Is.EqualTo("11.91"), "Dimension 2 value is not set to 11.91");
            Materials.ClickBackToListButton();
            ExtentTestManager.TestSteps($"Verify that the I-BEAM 12 X 14# are set the dimension1 and ");

            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("CheckMeasureFrom");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectPostMaterialDropdown("I-BEAM 12 X 14#");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();

            // Check drawing material for IBeam- Material
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickInteriorSheathingCEIL_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("InteriorRoof", null, null, null, null);
            ExtentTestManager.TestSteps($"InteriorRoof Length is update after changing the post material height field");
            DefaultJobElement.ClickCanvas3DViewButton();
        }

        private static void CheckCeilingColorAndCeilingTrimColorAreDisabled(string checkboxName)
        {
            Assert.That(DefaultJobElement.CeilingColorDropdown().Enabled, $"If '{checkboxName}' is unchecked then 'Ceiling Colors is enabled");
            Assert.That(DefaultJobElement.CeilingTrimColorDropdown().Enabled, $"If '{checkboxName}' is unchecked then 'Ceiling Trim Colors is enabled");
            ExtentTestManager.TestSteps($"If '{checkboxName}' is unchecked then 'Ceiling Colors and Ceiling Trim Colors fields are disabled");
        }
        #endregion

        #region Upper Sheathing
        private void UpperSheathing()
        {
            ExtentTestManager.CreateTest("Smoke test on the Upper Sheathing");
            DefaultJobElement.ClickMainBuilding();
            DefaultJobElement.ClickUpperSheathing();
            DefaultJobElement.UncheckHasUpperSheathingCheckbox();
            Assert.That(!DefaultJobElement.UpperSheathingHeight().Enabled, "If 'Has Upper Sheathing' is unchecked then 'Upper Sheathing Height' is disabled");
            Assert.That(DefaultJobElement.UpperSheathingColors().Enabled, "If 'Has Upper Sheathing' is unchecked then 'Upper Sheathing Colors' is disabled");
            ExtentTestManager.TestSteps($"If 'Has Upper Sheathing' is unchecked then 'Upper Sheathing Height' and 'Upper Sheathing Colors' fields are disabled");
            DefaultJobElement.CheckHasUpperSheathingCheckbox();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofFraming();
            DefaultJobElement.TrussHeelHeightInputField("1");
            DefaultJobElement.ClickPurlinFraming();
            DefaultJobElement.SelectPurlinType("Flat");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("UpperSheathing", null, null, null, null);
            ExtentTestManager.TestSteps($"UpperSheathing Length is update after changing the upper sheathing height field");
        }
        #endregion

        #region Private Method 
        private void ApplyColorOnRoof(string colorName)
        {
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectRoofColorFromAdvancedEdit(colorName);
        }

        private void ApplyColorOnTheExteriorWall(string colorName)
        {
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectWallColorFromAdvancedEdit(colorName);
        }

        private void CheckColorElementShownInTheWallTrim()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallTrim();
            DefaultJobElement.ClickBaseTrimColorsDropdown();
            ColorsElementShownInTheBaseTrimDropdown(storeColorName);
        }

        private void CheckColorNameIsUpdate()
        {
            for (int i = 0; i < ChangesColorName.Length; i++)
            {
                IReadOnlyList<IWebElement> colorList = Driver.FindElements(By.XPath("(//div[text()='Colors'])[1]//following::div[1]//label"));

                foreach (IWebElement colorElement in colorList)
                {
                    string colorName = colorElement.Text;

                    if (colorName.Contains(ChangesColorName[i]))
                    {
                        ExtentTestManager.TestSteps($"Verify that the {colorElement.Text} is update in the default job");
                        break;
                    }
                }
            }
        }

        private void GetColorName()
        {
            IReadOnlyList<IWebElement> colorList = Driver.FindElements(By.XPath("(//div[text()='Colors'])[1]//following::div[1]//label"));

            for (int i = 0; i < colorList.Count; i++)
            {
                string colorName = colorList[i].Text;
                string remove = colorName.Replace(" Color", "");
                storeColorName.Add(remove);
            }
        }

        public void ColorsElementShownInTheBaseTrimDropdown(List<string> listOfColors)
        {
            var count = 0;
            CommonMethod.Wait(1);

            for (int i = 0; i <= 6; i++)
            {
                IReadOnlyList<IWebElement> numberOfElements = Driver.FindElements(By.XPath(Locator.DefaultJob.MaterialTableRows));

                foreach (IWebElement element in numberOfElements)
                {
                    string material = element.Text;
                    string remove = material.Replace(" Color", "");

                    if (remove.Contains(listOfColors[i]))
                    {
                        count++;
                        break;
                    }

                }
            }

            Assert.That(count, Is.EqualTo(7), "Verify that the color elements are not shown in the dropdown menu for the base trim colors.");
            ExtentTestManager.TestSteps($"Verify that the color elements are shown in the dropdown menu for the base trim colors.");
        }

        private void ChangeTheColorNameInTheFramingRules()
        {
            FramingRules.TableScrollDown("200");
            for (int index = 0; index < colorName.Length; index++)
            {
                FramingRules.ClickDoEditButtonAndChangeColorName(colorName[index], ChangesColorName[index]);
            }

            FramingRules.ClickSaveButton();
        }

        private bool SetTheColorNameInTheFramingRulesToDefault()
        {
            FramingRules.TableScrollDown("200");

            for (int index = 0; index < ChangesColorName.Length; index++)
            {
                try
                {
                    FramingRules.ClickDoEditButtonAndChangeColorName(ChangesColorName[index], colorName[index]);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            FramingRules.ClickSaveButton();
            return true;
        }
    }
}
#endregion