using Forms.Reporting;
using NUnit.Framework;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class MonoRoof : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-207");

        [Test]
        public void Girt()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Mono roof girts missing on face");
            CommonMethod.DeleteFolderFile(pathFile);
            FolderPath.CreateFolder(pathFile);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectRoofStyleMaterial("Shed");
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallGirtFraming();
            DefaultJobElement.SelectGirtStyle("Bypass");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_3();
            DefaultJobElement.CaptureScreenShot($"{pathFile}", "BeforeUseTopGirt.png");
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierStyle("Use Top Girt");
            string topGirtMaterial = DefaultJobElement.GetTopGirtMaterialValue();

            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.CaptureScreenShot($"{pathFile}", "UseTopGirt.png");
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TopGirt", null, topGirtMaterial, null, "20'");

            PerformImageComparison("UseTopGirt.png", "BeforeUseTopGirt.png", "Verify that the Top Girts is not applied to the top of the Eave wall", "Verify that the Top Girts is applied to the top of the Eave wall");
            ExtentTestManager.TestSteps("Verify that the Top Girts is applied to the top of the Eave wall");
            CommonMethod.Wait(1);

            DefaultJobElement.SelectTrussCarrierStyle("Double");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();

            string trussCarrierMaterial = DefaultJobElement.GetTrussCarrierMaterialValue();
            DefaultJobElement.CheckMaterialLengthsOfSheathingDrawingTable("TrussBearer", null, trussCarrierMaterial, null, "40'");
            DefaultJobElement.CaptureScreenShot($"{pathFile}", "Double.png");
            ExtentTestManager.TestSteps("Verified that the length of the trusses is not changed after applied the Double Truss Carrier Material");
            Console.WriteLine("Verified that the length of the trusses is not changed after applied the Double Truss Carrier Material");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Mono roof girts missing on face Script");
        }

       
        #region Compare Two Images
        public bool CompareImages(string imagePath1, string imagePath2, int threshold = 5)
        {
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
        public void PerformImageComparison(string image1, string image2, string ifStatement, string elseStatement)
        {
            // Provide the file paths of the two images to compare
            string imagePath1 = $@"{pathFile}\{image1}";
            string imagePath2 = $@"{pathFile}\{image2}";

            // Create an instance of the ImageComparisonExample class
            var imageComparison = new MonoRoof();

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
