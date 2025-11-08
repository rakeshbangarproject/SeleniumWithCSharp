using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Forms.Reporting;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using SmartBuildAutomation.Helper;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Pages_Application;


namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Roofing_Passport")]
    public class ReflectPanel : BaseClass
    {
        public string folderPath = FolderPath.Download();
        public string outputElement = "//span[contains(text(),'{0}')]//preceding :: input[1]";

        [Test, Order(1)]
        public void ReflectPanelLength()
        {
            ExtentTestManager.CreateTest("HOT PATCH - Reflect Panel Length changes in Drawing Outputs");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Reflect Panel Length");
            CommonMethod.PageLoader();
            EditLength1();
            EditLengthFromDrawing();
            DefaultJobElement.ClicksSaveButton();
            DefaultJobElement.ClickJobReview();
            CheckAndUpdateCladdingLength();
            DownloadOutputData();
            VerifyPDFFileData();
            DefaultJobElement.StatusChangeButtonButton("Unlock");
            DefaultJobElement.NavigateToHomePage();
            CommonMethod.ChangesDistributor();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of HOT PATCH - Reflect Panel Length changes in Drawing Outputs");
        }

        #region Private Method
        private void EditLength1()
        {
            try
            {
                Driver.FindElement(By.XPath("//td[normalize-space()='Prep for Order']"));
            }
            catch
            {
                DefaultJobElement.StatusChangeButtonButton("Unlock");
            }

            CommonMethod.Wait(2);

            try
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Prep for Order']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            }
            catch
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Prep for Order']")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            }

            ExtentTestManager.TestSteps("Click on the Prep for Order button");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[normalize-space()='Confirmation']")));
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[normalize-space()='Yes']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps("Click on the Yes pop of button");
            CommonMethod.PageLoader();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[normalize-space()='Drawings']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps("Click on the Drawings button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[contains(@id,'node_Cladding_ROOF-15_ROOF-15')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            ExtentTestManager.TestSteps("Click on the ROOF-15 button");
        }

        private void EditLengthFromDrawing()
        {
            string rowXPath = "(//div[contains(text(),'S{0}')])[1]";

            for (int i = 1; i <= 2; i++)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(rowXPath, i))));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td[contains(text(),'Edit Length')])[1]")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//input[contains(@id,'newLengthStr')])[1]")));
                CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("3").Perform(); ;
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[contains(@id,'Ok')])[1]")));
                CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Click().Build().Perform();
            }
            ExtentTestManager.TestSteps("Edit the length from the Drawing");
        }

        private void CheckAndUpdateCladdingLength()
        {
            DefaultJobElement.ClickCladdingOfJobReview();

            string gridXPath = "//div[@id='grid_MaterialsGrid_records']/table/tbody";

            IList<IWebElement> rows = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(gridXPath))).FindElements(By.TagName("tr"));

            bool result = false;

            for (int i = 3; i < rows.Count - 2; i++)
            {
                string usages = GetCellText(i, 1);

                if (usages.Contains("Roof") && GetCellText(i, 2).Contains("36-AG-29GA-SC-1") && GetCellText(i, 5) == "2" && GetCellText(i, 7) == "3'")
                {
                    result = true;
                    PerformDoubleClickAction(i, 7);

                    Assert.Multiple(() =>
                    {
                        Assert.That(GetLabelText(2, 4), Is.EqualTo("3'"));
                        Assert.That(GetLabelText(2, 6), Is.EqualTo("S1"));
                        Assert.That(GetLabelText(3, 4), Is.EqualTo("3'"));
                        Assert.That(GetLabelText(3, 6), Is.EqualTo("S2"));
                    });

                    ExtentTestManager.TestSteps("Verify that the cladding length(Job Review) is updated after the roof length(Drawing) has been changed.");
                    break;
                }
            }

            Assert.That(result, Is.True, "Verify that the cladding length(Job Review) is not updated after the roof length(Drawing) has been changed.");
            DefaultJobElement.ClickCanvas3DViewButton();
        }

        private string GetCellText(int row, int column)
        {
            string xpath = $"//div[@id='grid_MaterialsGrid_records']/table/tbody/tr[{row}]/td[{column}]/div";
            return Driver.FindElement(By.XPath(xpath)).Text;
        }

        private string GetLabelText(int row, int column)
        {
            string xpath = string.Format("//table[@id='mlpopup']/tbody/tr[{0}]/td[{1}]", row, column);
            return Driver.FindElement(By.XPath(xpath)).Text;
        }

        private void PerformDoubleClickAction(int row, int column)
        {
            string xpath = $"//div[@id='grid_MaterialsGrid_records']/table/tbody/tr[{row}]/td[{column}]/div";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Build().Perform();
        }

        private void DownloadOutputData()
        {
            OutputButton();

            // Unchecked the all checkboxes from the output popup
            IReadOnlyList<IWebElement> checkboxes = Driver.FindElements(By.XPath("//span[contains(@onclick,'selectOutput')]//preceding :: input[1]"));
            foreach (IWebElement checkbox in checkboxes)
            {
                // Check if the checkbox is selected
                if (checkbox.Selected)
                {
                    checkbox.Click();
                }
            }

            string[] checkCheckbox = new string[] { "Roof Layout", "Roof Report", "Cladding Drawings" };
            for (int i = 0; i < checkCheckbox.Length; i++)
            {
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(outputElement, checkCheckbox[i]))));

                if (!CommonMethod.element.Selected)
                {
                    CommonMethod.element.Click();
                }
            }

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Download')]")));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click on the Roof Layout, Roof Report, and Cladding Drawing checkbox");
            CommonMethod.Wait(5);
        }

        public class CheckboxInfo
        {
            public string Id { get; set; }
            public bool IsChecked { get; set; }
        }

        private void OutputButton()
        {
            string InputButtonOfOutput = "//td[contains(text(),'{0}')]";
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(InputButtonOfOutput, "Outputs"))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).Perform();
            IJavaScriptExecutor j = (IJavaScriptExecutor)Driver;
            j.ExecuteScript("arguments[0].click();", CommonMethod.element);
            ExtentTestManager.TestSteps("Click on the Outputs button of default job");
        }

        private void VerifyPDFFileData()
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string sanitizedDate = date.Replace('/', '-');
            string pdfFileName = $"Reflect Panel Length_{sanitizedDate}.pdf";
            CommonMethod.Wait(5);
            string pdfFilePath = System.IO.Path.Combine(folderPath, pdfFileName);
            string searchString1 = "Details";
            string searchString2 = "ROOF-15";
            string searchString3 = "ExteriorRoof 36\"-  AG Panel 2 3'";

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                {
                    for (int pageNumber = 1; pageNumber <= pdfDocument.GetNumberOfPages(); pageNumber++)
                    {
                        // Create a listener to extract text
                        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                        // Parse the content of each page
                        string pageContent = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy);

                        // Check conditions and log messages
                        if (pageContent.Contains(searchString1) &&
                            pageContent.Contains(searchString2) &&
                            pageContent.Contains(searchString3))
                        {
                            // Log the message and continue checking other pages
                            LogVerificationMessage("Verify that the length data 3' has been updated in the PDF file. \n Drawing Roof-15 data and Cladding data are matched", searchString3);
                        }
                    }
                }
            }
        }

        private void LogVerificationMessage(string message, string searchString)
        {
            // Print or log the message
            Console.WriteLine($"{message} {searchString}");

            // Log to your test framework or logging mechanism (e.g., ExtentReport)
            ExtentTestManager.TestSteps($"{message} {searchString}");
        }
    }
}
#endregion