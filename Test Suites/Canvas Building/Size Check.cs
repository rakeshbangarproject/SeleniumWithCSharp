using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildProject
{
    [TestFixture, Category("Canvas")]
    public class SizeCheck : BaseClass
    {
        string path = FolderPath.ImagesFolder();

        [Test]
        public void UploadFiles()
        {
            LoginApplicationAndChangesDistributor("Size Check");

            DeleteImage();
            string oldImageSRCPath = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='SmartBuild']"))).GetAttribute("src");
            HomePage.NavigateToCustomizePage();
            Customize.UploadingFileInTheCustomizePage(path, "sample.pdf", "PDF File");
            Console.WriteLine("Upload pdf file");
            AlertMessage();

            Customize.UploadingFileInTheCustomizePage(path, "file-csv.csv", "CSV File");
            AlertMessage();
            Console.WriteLine("Upload CSV File file");

            Customize.UploadingFileInTheCustomizePage(path, "5mb.png", "5 MB Image");
            Console.WriteLine("Upload image size should be more than 1 mb");
            ExtentTestManager.TestSteps("File size should be more than 1 MB'");
            AlertMessage();

            Customize.UploadingFileInTheCustomizePage(path, "Logo.png", "Images");
            Console.WriteLine("Upload image size should be less than 1 mb");
            Customize.ClickSaveButton();
            CheckImageUpload(oldImageSRCPath);
            DeleteImage();

        }

        private static void DeleteImage()
        {
            HomePage.NavigateToCustomizePage();
            Customize.ClickDeleteButton();
            Customize.ClickSaveButton();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Size Check Script");
        }

        #region Private Method
        /// <summary>
        /// Login to the application and set distributor as AutoTest_PHTest
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");

        }

        private void AlertMessage()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-popup']//div[2]")));
            string alertMessageText = CommonMethod.element.Text;
            Console.WriteLine($"Shows alert messages: {alertMessageText}");
            ExtentTestManager.TestSteps($"Shows alert messages: {alertMessageText}");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Ok']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            ExtentTestManager.TestSteps($"Click on the Okay button");
        }

        private void CheckImageUpload(string oldImageSRCPath)
        {
            IWebElement uploadedImage = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@src='https://postframesolver.blob.core.windows.net/test-logo-files/1147.png']")));
            string newImage = uploadedImage.GetAttribute("src");

            if (oldImageSRCPath.Equals(newImage))
            {
                Console.WriteLine("Image is not upload.");
                ExtentTestManager.TestSteps("Image is not upload.");
                Assert.Fail("Image is not upload.");
            }
            else
            {
                Console.WriteLine("Image is upload successfully.");
                ExtentTestManager.TestSteps("Image is upload successfully.");
            }
        }
    }
}
#endregion