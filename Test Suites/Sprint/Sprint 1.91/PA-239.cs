using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Presentation;
using Forms.Reporting;
using NPOI.XWPF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SharpCompress.Common;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;


namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{
    [TestFixture, Category("Sprint_1._91")]
    public class NewDocumentTemplate : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void AccentColors()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add new document template {tokens} Accent Colors");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("ColorToken");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickColors();

            string roofColor = DefaultJobElement.GetRoofColorValue();
            string wallColor = DefaultJobElement.GetWallColorValue();
            string trimColor = DefaultJobElement.GetTrimColorValue();
            string accent1Color1Color = DefaultJobElement.GetAccentColor1Value();
            string accent2Color1Color = DefaultJobElement.GetAccentColor2Value();
            string accent3Color1Color = DefaultJobElement.GetAccentColor3Value();
            string accent4Color1Color = DefaultJobElement.GetAccentColor4Value();
            ExtentTestManager.TestSteps("Get the names of Roof, Wall,Trim, Accent 1, Accent 2, Accent 3, and Accent 4 Colors.");

            DefaultJobElement.DownloadFileFromOutputFrame("Document Template NEW");
            string paragraphText = GetTheDocumentFilePath();
            ExtentTestManager.TestSteps("verify the document file is successfully downloaded.");

            Assert.That(paragraphText.Contains($"Roof Color = {roofColor}"), "Verify that the 'Roof Color' is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Wall Color = {wallColor}"), "Verify that the 'Wall Color' is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Trim Color = {trimColor}"), "Verify that the 'Trim Color' is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Accent 1 Color Name = {accent1Color1Color}"), "Verify that the 'Accent 1 Color; is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Accent 2 Color Name = {accent2Color1Color}"), "Verify that the 'Accent 2 Color; is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Accent 3 Color Name = {accent3Color1Color}"), "Verify that the 'Accent 3 Color; is not shown full name of color in the document file");
            Assert.That(paragraphText.Contains($"Accent 4 Color Name = {accent4Color1Color}"), "Verify that the 'Accent 4 Color; is not shown full name of color in the document file");
            ExtentTestManager.TestSteps("Verify that the names of Roof, Trim, Wall, Accent 1, Accent 2,Accent 3, and Accent 4 Colors match with ColorToken job colors");
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add new document template {tokens} Accent Colors");
        }

        private string GetTheDocumentFilePath()
        {
            try
            {
                var date = DateTime.Now.ToString("MM/dd/yyyy");
                string currentDate = date.Replace('/', '-');
                string docFileName = $"ColorToken-Document Template NEW_{currentDate}.docx";
                string filePath = Path.Combine(folderPath, docFileName);
                FolderPath.WaitForFileDownload(filePath, 30);
                return VerifyDataFromDocFile(filePath);
            }
            catch (Exception)
            {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                string currentDate = date.Replace('/', '-');
                string docFileName = $"ColorToken-Document Template NEW_{currentDate}.docx";
                string filePath = Path.Combine(folderPath, docFileName);
                FolderPath.WaitForFileDownload(filePath, 30);
                return VerifyDataFromDocFile(filePath);
            }
        }

        private string VerifyDataFromDocFile(string filePath)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                XWPFDocument doc = new XWPFDocument(fileStream);

                string paragraphText = string.Empty;

                // Iterate over paragraphs in the document
                foreach (XWPFParagraph paragraph in doc.Paragraphs)
                {
                    paragraphText += paragraph.Text + Environment.NewLine;
                }

                return paragraphText;
            }
        }
    }
}
