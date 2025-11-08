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
    class LogoUpdate : BaseClass
    {
        public static string path = FolderPath.ImagesFolder();

        [Test]
        public void LogoUpdateForWebsite()
        {
            LoginApplicationAndChangesDistributor("Logo Update");
            CheckLogoUpdate();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Logo Update Script");
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

        private void CheckLogoUpdate()
        {
            DeleteImage();
            string oldImageSRCPath = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='SmartBuild']"))).GetAttribute("src");

            HomePage.NavigateToCustomizePage();
            Customize.UploadingFileInTheCustomizePage(path, "Logo.png", "Logo");
            Customize.ClickSaveButton();

            string newImage = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='SmartBuild']"))).GetAttribute("src");

            if (newImage.Equals(oldImageSRCPath))
            {
                Assert.Fail("Error: Image is not uploaded successfully");
            }

            Console.WriteLine("Image is uploaded successfully.");
            ExtentTestManager.TestSteps("Image is uploaded successfully.");

            DeleteImage();
        }

        private static void DeleteImage()
        {
            HomePage.NavigateToCustomizePage();
            Customize.ClickDeleteButton();
            Customize.ClickSaveButton();
        }
    }
}
#endregion