using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Sprint_1._87;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._88
{
    [TestFixture, Category("Sprint_1._88")]
    public class SliderDoor : BaseClass
    {
        string captureScreenShot = FolderPath.StoreScreenShot();

        [Test]
        public void ChangeDoorColor()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Sliding door colors when sill height is greater than zero");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.OpeningDoorsSelection("Slider");
            DefaultJobElement.SelectStandardStyle();
            DefaultJobElement.PlaceOpening(100, 100);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.Click3DEdit();
            DefaultJobElement.OpenPlaceOpening(100, 200);
            UpdatedSillHeight();
            ChangesView();
            CaptureScreenShotOfCanvasBuilding("BeforeApplySliderColor.png");
            ApplyColorOnTheSlider();
            ChangesView();
            CaptureScreenShotOfCanvasBuilding("AfterApplySliderColor.png");
            PerformImageComparison("Verify that the Slider color is not change", "Verify that the Slider color is change", "BeforeApplySliderColor.png", "AfterApplySliderColor.png");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Sliding door colors when sill height is greater than zero");
        }

        #region Private Method
        private void UpdatedSillHeight()
        {
            DefaultJobElement.EnterSillHeight("1");
            DefaultJobElement.ClickUpdateButtonFrom3DView();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void ApplyColorOnTheSlider()
        {
            DefaultJobElement.ClickAdvancedEdit();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.SLD_1)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the SLD-1 tab");
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectWallColorFromAdvancedEdit("BRIGHT RED");
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.Wait(1);
            DefaultJobElement.ClickCanvas3DViewButton();
        }

        private void ChangesView()
        {
            DefaultJobElement.ChangeView();
            DefaultJobElement.ChangeViewLeftElevation();
        }

        private void CaptureScreenShotOfCanvasBuilding(string imageName)
        {
            DefaultJobElement.CaptureScreenShotOfCanvasBuilding("canvas", "drawingArea", captureScreenShot, $"{imageName}");
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

        public void PerformImageComparison(string ifStatement, string elseStatement, string firstImageName, string secondImageName)
        {
            // Provide the file paths of the two images to compare
            string imagePath1 = $@"{captureScreenShot}\{firstImageName}";
            string imagePath2 = $@"{captureScreenShot}\{secondImageName}";

            // Create an instance of the ImageComparisonExample class
            var imageComparison = new AddNewStyle();

            // Compare the images with the default threshold (5)
            bool areImagesSimilar = imageComparison.CompareImages(imagePath1, imagePath2);

            // Print the result
            if (areImagesSimilar)
            {
                Console.WriteLine($"{ifStatement}");
                ExtentTestManager.TestSteps($"{ifStatement}");
            }
            else
            {
                Console.WriteLine($"{elseStatement}");
                ExtentTestManager.TestSteps($"{elseStatement}");
            }
        }
    }
}
#endregion
