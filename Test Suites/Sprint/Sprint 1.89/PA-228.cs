using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Sprint_1._87;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint.Sprint_1._89
{
    [TestFixture, Category("Sprint_1._89")]
    public class Overridden : BaseClass
    {
        public string CaptureScreenShot = FolderPath.StoreCaptureImage("ScreenShot of PA-228");

        [Test]
        public void AdvancedEdit()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Show what's been overridden in Advanced Edit");
            FolderPath.CreateFolder(CaptureScreenShot);
            CommonMethod.DeleteFolderFile(CaptureScreenShot);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.SelectOpeningDoor("WalkDoor", "Solid", "3x7 LIS Solid Steel Door");
            DefaultJobElement.PlaceOpening(100, 120);
            DefaultJobElement.ClickCrossIcon();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickCanvas3DViewButton();
            CaptureScreenShotOfCanvasBuilding("ApplyColorOnTheWallInTheAdvancedEdit.png");
            DefaultJobElement.ClickAdvancedEdit();
            VerifyPanel();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Show what's been overridden in Advanced Edit");
        }

        #region Private Method
        private void VerifyPanel()
        {
            DefaultJobElement.ClickROOF_2();
            DefaultJobElement.ClickProductSystem();
            DefaultJobElement.VerifyThatProductSystemShow();
            DefaultJobElement.VerifyThatColorsShow();
            DefaultJobElement.VerifyThatCeilingLinerShow();
            DefaultJobElement.VerifyThatWallLinerShow();
            DefaultJobElement.ClickEXT_1();
            DefaultJobElement.VerifyThatProductSystemShow();
            DefaultJobElement.VerifyThatColorsShow();
            DefaultJobElement.VerifyThatCeilingLinerShow();
            DefaultJobElement.VerifyThatWallLinerShow();
            DefaultJobElement.VerifyThatWainscotShow();
            DefaultJobElement.VerifyThatUpperSheathing();
            Console.WriteLine("Verify that the panel is displayed in the advanced edit.");
            ExtentTestManager.TestSteps("Verify that the panel is displayed in the advanced edit.");

            DetailsTab();
            MainBuilding();
            VerifyDataInOverlay();
        }

        private void DetailsTab()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectEavePostPlacementForAdvancedEdit("Custom...");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name='CustomStr']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("6,8,7,6,1,3").Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='Apply']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(5)).Perform();
            ExtentTestManager.TestSteps("Select Custom from the Eave Post Placement dropdown and Enter data in the Bay length field.");
        }

        private void MainBuilding()
        {
            DefaultJobElement.ClickMainBuildingOfAdvancedEdit();
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectWallColorFromAdvancedEdit("BRIGHT RED");
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(5)).Perform();
        }

        private void VerifyDataInOverlay()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[contains(@class, 'w2ui-icon-pencil')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Pencil icon of EXT_1");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='w2ui-overlay']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(5)).Perform();

            string wallColor = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[1]"))).Text;
            Assert.That(wallColor, Is.EqualTo("WallColor:"));
            string colorCode = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[2]"))).Text;
            Assert.That(colorCode, Is.EqualTo("1479"));
            string studPlacement = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[3]"))).Text;
            Assert.That(studPlacement, Is.EqualTo("StudPlacement:"));
            string custom = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[4]"))).Text;
            Assert.That(custom, Is.EqualTo("Custom"));
            string studCustom = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[5]"))).Text;
            Assert.That(studCustom, Is.EqualTo("StudCustom:"));
            string studCustomNumber = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[@id='w2ui-overlay']//span)[6]"))).Text;
            Assert.That(studCustomNumber, Is.EqualTo("6,8,7,6,1,3"));
            ExtentTestManager.TestSteps("Verify that Wall color and Custom data shown in the overlay");
            Console.WriteLine("Verify that Wall color and Custom data shown in the overlay");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//div[text()='Reset All']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps("Click on the Reset All of overlay");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[text()='Reset Overrides']")));
            CommonMethod.Wait(2);

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@id='Yes']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps("Click on the yes of Reset Overrides pop up");
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.ClickCanvas3DViewButton();
            CaptureScreenShotOfCanvasBuilding("ResetChanges.png");
            CommonMethod.Wait(2);
            PerformImageComparison();
        }

        private void CaptureScreenShotOfCanvasBuilding(string imageName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("drawingArea")));
            CommonMethod.Wait(2);

            Screenshot elementScreenshot = ((ITakesScreenshot)CommonMethod.element).GetScreenshot();
            string imagePath = $@"{CaptureScreenShot}\{imageName}";
            elementScreenshot.SaveAsFile(imagePath);
        }

        public bool CompareImages(string imagePath1, string imagePath2, int threshold = 5)
        {
            // Compare image Height and with matched or not
            using (var image1 = Image.Load<Rgba32>(imagePath1))
            using (var image2 = Image.Load<Rgba32>(imagePath2))
            {
                if (image1.Width != image2.Width || image1.Height != image2.Height)
                {
                    return false;
                }

                int differences = 0;

                for (int y = 0; y < image1.Height; y++)
                {
                    for (int x = 0; x < image1.Width; x++)
                    {
                        if (!ArePixelsSimilar(image1[x, y], image2[x, y], threshold))
                        {
                            differences++;
                            if (differences > threshold)
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }

        private bool ArePixelsSimilar(Rgba32 pixel1, Rgba32 pixel2, int threshold)
        {
            // Compare the RGBA color channels of the pixels
            return Math.Abs(pixel1.R - pixel2.R) <= threshold
                && Math.Abs(pixel1.G - pixel2.G) <= threshold
                && Math.Abs(pixel1.B - pixel2.B) <= threshold
                && Math.Abs(pixel1.A - pixel2.A) <= threshold;
        }

        public void PerformImageComparison()
        {
            // Provide the file paths of the two images to compare
            string imagePath1 = $@"{CaptureScreenShot}\ResetChanges.png";
            string imagePath2 = $@"{CaptureScreenShot}\ApplyColorOnTheWallInTheAdvancedEdit.png";

            // Create an instance of the ImageComparisonExample class
            var imageComparison = new AddNewStyle();

            // Compare the images with the default threshold (5)
            bool areImagesSimilar = imageComparison.CompareImages(imagePath1, imagePath2);

            // Print the result
            if (areImagesSimilar)
            {
                Console.WriteLine($"Verify that all changes to the EXT_1 wall are not set to default ");
                ExtentTestManager.TestSteps($"Verify that all changes to the EXT_1 wall not are set to default");
            }
            else
            {
                Console.WriteLine($"Verify that all changes to the EXT_1 wall are set to default ");
                ExtentTestManager.TestSteps($"Verify that all changes to the EXT_1 wall are set to default ");
            }
        }
    }
}
#endregion