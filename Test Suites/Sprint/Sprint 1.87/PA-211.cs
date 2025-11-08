using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class AddNewStyle : BaseClass
    {
        #region XPath
        public static string screenshotOfIcon = FolderPath.StoreCaptureImage("ScreenShot of PA-211");
        public static string downloadIconImage = FolderPath.StoreCaptureImage("Icon Images");
        #endregion

        [Test]
        public void VerifyIcon()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add New Styles and (icons)");
            FolderPath.CreateFolder(screenshotOfIcon);
            CommonMethod.DeleteFolderFile(screenshotOfIcon);
            HomePage.NavigateToSetupWizardPages();
            RemainingDeleteElement();
            WindowsData();
            WalkDoorData();
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.ClicksStartFromScratch();
            GetTheWindowsIcon();
            GetTheWalkDoorIcon();
            VerifyIconsUpdated();
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToSetupWizardPages();
            DeleteDataFromWindowTable();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add New Styles and (icons)");
        }

        #region Private Method
        private void VerifyIconsUpdated()
        {
            // Verify that the icons is updated or not
            PerformImageComparison("Verify that the Single Hung icon is updated to the Windows style", "Verify that the Single Hung icon is not updated to the Windows style", "Single-HungWindow.png", "Single-Hung.png");
            PerformImageComparison("Verify that the Double Hung icon is updated to the Windows style", "Verify that the Double Hung icon is not updated to the Windows style", "Double-HungWindow.png", "Double-Hung.png");
            PerformImageComparison("Verify that the Vent icon is updated to the Windows style", "Verify that the Vent icon is not updated to the Windows style", "VentWindow.png", "Vent.png");
            PerformImageComparison("Verify that the Other icon is updated to the Windows style", "Verify that the Other icon is not updated to the Windows style", "OtherWindow.png", "Other.png");
            PerformImageComparison("Verify that the Other icon is updated to the WalkDoor style", "Verify that the Other icon is not updated to the WalkDoor style", "OtherWalkDoor.png", "Other.png");
        }

        private void DeleteDataFromWindowTable()
        {
            string[] styleDropdownElement = new string[4] { "Single HungTest", "Double HungTest", "VentTest", "OtherTest" };
            SetupWizard.ClickWindows();

            for (int i = 0; i < styleDropdownElement.Length; i++)
            {
                SetupWizard.DeleteSetupWizardData(styleDropdownElement[i]);
            }

            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickWalkDoors();
            SetupWizard.DeleteSetupWizardData("OtherTestDoor");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void RemainingDeleteElement()
        {
            SetupWizard.ClickWalkDoors();
            SetupWizard.DeleteSetupWizardData("OtherTestDoor");
            SetupWizard.ClickWindows();
            string[] styleDropdownElement = new string[4] { "Double HungTest", "Single HungTest", "VentTest", "OtherTest" };

            for (int i = 0; i < styleDropdownElement.Length; i++)
            {
                SetupWizard.DeleteSetupWizardData(styleDropdownElement[i]);
            }

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickWindows();
            }
        }

        private void WindowsData()
        {
            string[] styleDropdownElement = new string[4] { "Single Hung", "Double Hung", "Vent", "Other" };

            for (int i = 0; i < styleDropdownElement.Length; i++)
            {
                SetupWizard.ClickAddButton();
                SetupWizard.EnterSKUInputField(styleDropdownElement[i] + "Test");
                SetupWizard.EnterDescriptionInputField(styleDropdownElement[i] + "Test");
                SetupWizard.EnterWidthInputField("5");
                SetupWizard.EnterHeightInputField("6");
                SetupWizard.SelectStyleElement(styleDropdownElement[i]);
                SetupWizard.ClickSaveButton();
            }
        }

        private void WalkDoorData()
        {
            SetupWizard.ClickWalkDoors();
            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("OtherTestDoor");
            SetupWizard.EnterDescriptionInputField("OtherTestDoor");
            SetupWizard.EnterWidthInputField("5");
            SetupWizard.EnterHeightInputField("6");
            SetupWizard.SelectStyleElement("Other");
            SetupWizard.ClickSaveButton();
        }

        private void GetTheWalkDoorIcon()
        {
            DefaultJobElement.OpeningDoorsSelection("WalkDoor");
            IconScreenShot("style-image-Other", "OtherWalkDoor.png");
        }

        private void GetTheWindowsIcon()
        {
            // Click on the Windows tab and capture the Single,Double,Vent,and Other icon screenshots
            DefaultJobElement.OpeningDoorsSelection("Windows");
            IconScreenShot("style-image-Single-Hung", "Single-HungWindow.png");
            IconScreenShot("style-image-Double-Hung", "Double-HungWindow.png");
            IconScreenShot("style-image-Vent", "VentWindow.png");
            IconScreenShot("style-image-Other", "OtherWindow.png");
            DefaultJobElement.ClickCrossIcon();
        }

        public void IconScreenShot(string idName, string ImageName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id(idName)));
            CommonMethod.Wait(2);
            // Capture the screenshot of the element
            Screenshot elementScreenshot = ((ITakesScreenshot)CommonMethod.element).GetScreenshot();

            // Save the screenshot to a file
            string imagePath = $"{screenshotOfIcon}/{ImageName}";
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

        public void PerformImageComparison(string ifStatement, string elseStatement, string iconImage1, string iconImage2)
        {
            // Provide the file paths of the two images to compare
            string imagePath1 = $@"{screenshotOfIcon}\{iconImage1}";
            string imagePath2 = $@"{downloadIconImage}\{iconImage2}";

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