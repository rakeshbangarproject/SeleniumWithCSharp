using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{

    [TestFixture, Category("Sprint_1._91")]
    public class OpenWallTrim : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-242");

        [Test]
        public void OpenTopOfWallTrim()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Open Wall Top of Wall Trim");
            FolderPath.CreateFolder(pathFile);
            CommonMethod.DeleteFolderFile(pathFile);
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDetails();
            FramingRules.TableScrollDown("9000");
            VerifyNewQuestionsShownInTheFramingRules();
            VerifyAngleMaterialOfOpenTopOfWallTrimElement();
            VerifyOpenTopOfWallTrimMaterialForNone();
            VerifyOpenTopOfWallTrimMaterialForDefault();
            CheckLengthOverrides();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Open Wall Top of Wall Trim");
        }

        #region Private Method
        /// <summary>
        /// This method is use for verify open top of wall trim element using 3/4\" x 3/4\" Angle Material
        /// </summary>
        private void VerifyAngleMaterialOfOpenTopOfWallTrimElement()
        {
            HomePage.ClicksSmoke20x20x10();
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickOpenWallTrim();
            CheckOpenTopOfWallDefaultValue();
            DefaultJobElement.SelectOpenTopOfWallTrim("3/4\" x 3/4\" Angle+");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickOpenWallButton();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Trim", "OpenTopOfWall", null, "3/4\" x 3/4\" Angle", null, null, null, null, null, null, null);
            Console.WriteLine("Verify Open Top of Wall trim is on the list and show the 3 / 4” x 3 / 4” Angle material");
            ExtentTestManager.TestSteps("Verify Open Top of Wall trim is on the list and show the 3 / 4” x 3 / 4” Angle material");
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("OpenTopOfWall", null, "3/4\" x 3/4\" Angle", null, null);
            Console.WriteLine("3/4\" x 3/4\" Angle", "Sheathing Drawings for EXT 1");
            ExtentTestManager.TestSteps("Verify the Sheathing Drawings for EXT 1 Shows the 3/4” x 3/4” Angle material.");
            DefaultJobElement.ClickCanvas3DViewButton();
        }

        /// <summary>
        /// This method is use for 
        /// Check part length of pieces using Open top of wall length overrides question
        /// </summary>
        private void CheckLengthOverrides()
        {
            DefaultJobElement.ClickOpenWallTrim();
            DefaultJobElement.EnterOpenTopOfWallPartLengths("12,14");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.Wait(2);
            CheckPiecesOfPartLength();
        }

        /// <summary>
        /// This method is use for verify open top of wall trim element using None Material
        /// </summary>
        private void VerifyOpenTopOfWallTrimMaterialForNone()
        {
            DefaultJobElement.SelectOpenTopOfWallTrim("None");
            DefaultJobElement.EnterOpenWallOffset("3");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, -100);
            CaptureScreenShotOfCanvasBuilding("top of walls with soffits.png");
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();

            try
            {
                Driver.FindElement(By.XPath("//div[text()='TopOfWall']"));
                Assert.Fail("Verify that trim part to the top of walls with soffits shown after Open Top of Wall Trim Set to 'None'");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Verify that Open Top of Wall Trim Set to None does not input any trim part to the top of walls with soffits. ");
                ExtentTestManager.TestSteps("Verify that Open Top of Wall Trim Set to None does not input any trim part to the top of walls with soffits. ");
            }

            DefaultJobElement.ClickCanvas3DViewButton();
        }

        /// <summary>
        /// This method is use for verify open top of wall trim element using match Top Of Wall Material
        /// </summary>
        private void VerifyOpenTopOfWallTrimMaterialForDefault()
        {
            DefaultJobElement.SelectOpenTopOfWallTrim("(match Top Of Wall)");
            DefaultJobElement.ClickWallTrim();

            string topOfWallTrim = DefaultJobElement.GetTopOfWallTrimValue();
            if (topOfWallTrim.Equals("Ceiling Double J"))
            {
                ExtentTestManager.TestSteps("Select Ceiling Double J from open top of wall trim");
            }
            else
            {
                DefaultJobElement.SelectTopOfWallTrim("Ceiling Double J");
            }

            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ClickOnTheEXT_1FromDrawingPage();

            VerifyMaterialShown("Ceiling Double J", "Sheathing Drawings for EXT 1");
            Console.WriteLine("Verify that Open Wall Top of Wall trim shown as the Ceiling Double J in the Sheathing Drawings EXT 1 table");
            ExtentTestManager.TestSteps("Verify that Open Wall Top of Wall trim shown as the Ceiling Double J in the Sheathing Drawings EXT 1 table");
        }

        /// <summary>
        /// Capture the screenshot of elements
        /// </summary>
        /// <param name="imageName"></param>
        private void CaptureScreenShotOfCanvasBuilding(string imageName)
        {

            IWebElement canvasElement = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));

            string desiredWidthStr = canvasElement.GetAttribute("width");
            string desiredHeightStr = canvasElement.GetAttribute("height");

            int desiredWidth = Convert.ToInt32(desiredWidthStr);
            int desiredHeight = Convert.ToInt32(desiredHeightStr);
            CommonMethod.Wait(2);

            IJavaScriptExecutor screenshotOfCanvas = (IJavaScriptExecutor)Driver;
            screenshotOfCanvas.ExecuteScript(
                "arguments[0].style.height = arguments[1] + 'px'; arguments[0].style.width = arguments[2] + 'px';",
                 canvasElement, desiredHeight, desiredWidth);

            Screenshot elementScreenshot = ((ITakesScreenshot)canvasElement).GetScreenshot();
            string imagePath = $@"{pathFile}\{imageName}";
            elementScreenshot.SaveAsFile(imagePath);
            
        }

        /// <summary>
        /// Enter data in the open wall offset field of open wall trim menu
        /// </summary>
        private void EnterDataInTheOpeWallOffsetField()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[@name='OpenWallOffset'])[1]")));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("3" + Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter data in the open wall offset field");
        }

        /// <summary>
        /// Check Questions are created in the Framing rules table
        /// </summary>
        private void VerifyNewQuestionsShownInTheFramingRules()
        {
            try
            {
                Driver.FindElement(By.XPath("//div[text()='Open Wall Base Trim Color']"));
                Driver.FindElement(By.XPath("//div[text()='Open Top of Wall Trim']"));
                Driver.FindElement(By.XPath("//div[text()='Open Top of Wall Length Overrides']"));
                ExtentTestManager.TestSteps("Verify that OpenTopOfWallTrim, OpenTopOfWallLengthOverrides, OpenTopOfWallTrimColor questions are shown in the open wall trim field");
                Console.WriteLine("Verify that OpenTopOfWallTrim, OpenTopOfWallLengthOverrides, OpenTopOfWallTrimColor questions are shown in the open wall trim field");
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Verify that OpenTopOfWallTrim, OpenTopOfWallLengthOverrides, OpenTopOfWallTrimColor questions are not shown in the open wall trim field");
            }

            DefaultJobElement.NavigateToHomePage();
            ExtentTestManager.TestSteps($"Navigate to the home page");
        }

        private void ClickOnTheWallTrimTab()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='Wall Trim'])[1]")));
            CommonMethod.Wait(2);
            CommonMethod.GetActions().Click(CommonMethod.element).Build().Perform();
            ExtentTestManager.TestSteps("Click on the Wall Trim tab");
        }

        private void CheckOpenTopOfWallDefaultValue()
        {
            string openTopOfWallTrim = DefaultJobElement.GetOpenTopOfWallTrimValue();
            Assert.That(openTopOfWallTrim, Is.EqualTo("(match Top Of Wall)"), "Verify that Open Wall of Wall Trim is not set as a (match Top Of Wall)");
            ExtentTestManager.TestSteps("Verify that Open Wall of Wall Trim set as a (match Top Of Wall)");
        }

        /// <summary>
        /// Check Material shown in the table 
        /// </summary>
        /// <param name="material"></param>
        /// <param name="location"></param>
        private void VerifyMaterialShown(string material, string location)
        {
            try
            {
                string elementXPath = $"(//div[text()='OpenTopOfWall']//following::div[text()='{material}'])[1]";
                Driver.FindElement(By.XPath(elementXPath));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"Verify {location} does not show the {material} material.");
            }
        }

        /// <summary>
        /// Click on the Drawing tab in the Canvas building page and Click on the EXT_1 of Sheathing Drawing in the Drawing page
        /// </summary>
        private void ClickOnTheEXT_1FromDrawingPage()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
        }

        /// <summary>
        /// This method is use for check the pieces of open top of wall shown only 12' and 14'
        /// </summary>
        private void CheckPiecesOfPartLength()
        {
            IList<IWebElement> matchingRows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and descendant::div[text()='OpenTopOfWall']]//td[@col='6']"));

            string length1 = matchingRows[0].Text;
            string length2 = matchingRows[1].Text;

            if ((length1 == "14'" || length1 == "12'") && (length2 == "14'" || length2 == "12'"))
            {
                ExtentTestManager.TestSteps("Verify the OpenTopofWall material is only using 14' and 12' pieces on a 20x20 ");
                Console.WriteLine("Verify the OpenTopofWall material is only using 14' and 12' pieces on a 20x20 ");
            }
            else
            {
                Assert.Fail("Verify the OpenTopofWall material is not using 14' and 12' pieces on a 20x20");
            }
        }
    }
}
#endregion