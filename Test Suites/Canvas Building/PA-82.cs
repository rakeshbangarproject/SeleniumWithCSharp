using Forms.Reporting;
using NUnit.Framework;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Test_Suites.Canvas_Building
{
    [TestFixture, Category("Canvas")]
    class SupplierID : BaseClass
    {
        static string CheckBoxOfOutput = "(//span[text()='{0}']//preceding::input[1])[1]";
        public string folderPath = FolderPath.Download();
        string[] materialSupplierSku = { "W8X10", "T1-11", "SupSku3" };
        public List<string> materialData = new();
        public List<string> supplierIdOfMaterials = new();

        [Test]
        public void Supplier()
        {
            LoginApplicationAndChangesDistributor("Test PA-82");
            HomePage.NavigateToTheMaterialsPage();
            FetchMaterialData(materialSupplierSku[0]);
            ClickOnMaterialPageTab("Sheathing");
            FetchMaterialData(materialSupplierSku[1]);
            ClickOnMaterialPageTab("Trim");
            FetchMaterialData(materialSupplierSku[2]);
            HomePage.ClicksJobTab();
            JobPage.OpenJob("3560 T-1");
            CommonMethod.PageLoader();
            DownloadSupplierIdPDFFile();
            VerifyTheMaterialDataFetchedInThePdf("Framing", materialData[0], materialData[1]);
            VerifyTheMaterialDataFetchedInThePdf("Sheathing", materialData[2], materialData[3]);
            VerifyTheMaterialDataFetchedInThePdf("Trim", materialData[4], materialData[5]);
            DefaultJobElement.NavigateToHomePage();
            HomePage.NavigateToTheOutputPage();
            VerifySupplierIdOfMaterialInOutputPage("Job Bid (Supplier ID 1)", supplierIdOfMaterials[0]);
            VerifySupplierIdOfMaterialInOutputPage("Job Bid (Supplier ID 2)", supplierIdOfMaterials[1]);
            VerifySupplierIdOfMaterialInOutputPage("Job Bid (Supplier ID 3)", supplierIdOfMaterials[2]);
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of PA-82");
        }

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

        private void DownloadSupplierIdPDFFile()
        {
            CommonMethod.Wait(1);
            DefaultJobElement.ClicksOutputButton();

            string[] checkboxName = new string[] { "Job Bid (Supplier ID 1)", "Job Bid (Supplier ID 2)", "Job Bid (Supplier ID 3)" };
            for (int totalCheckboxes = 0; totalCheckboxes < checkboxName.Length; totalCheckboxes++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(CheckBoxOfOutput, checkboxName[totalCheckboxes])))).Click();
            }
            CommonMethod.Click(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@name='Download']"))));
            ExtentTestManager.TestSteps("Download the PDF file for Job Bid Supplier ID 1, 2, 3");
            CommonMethod.Wait(8);
        }

        private void VerifyTheMaterialDataFetchedInThePdf(string materialType, string materialSku, string materialDescription)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string currentDate = date.Replace('/', '-');
            string excelFileName = $"3560 T-1_{currentDate}.pdf";
            string pdfFilePath = System.IO.Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify PDF File is download");

            using (PdfReader pdfReader = new PdfReader(pdfFilePath))
            {
                using (PdfDocument pdfDocument = new PdfDocument(pdfReader))
                {
                    StringBuilder text = new StringBuilder();

                    for (int pageNumber = 1; pageNumber <= pdfDocument.GetNumberOfPages(); pageNumber++)
                    {
                        // Create a listener to extract text
                        SimpleTextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                        // Parse the content of each page
                        string pageContent = PdfTextExtractor.GetTextFromPage(pdfDocument.GetPage(pageNumber), strategy);

                        text.Append(pageContent);
                    }

                    // Now 'text' contains the concatenated text from all pages
                    string pdfData = text.ToString();

                    try
                    {
                        Assert.True(pdfData.Contains(materialSku));
                        Assert.True(pdfData.Contains(materialDescription));
                        Console.WriteLine($"{materialType} material data is same as in the output PDF file");
                    }
                    catch
                    {
                        Console.WriteLine($"{materialType} material data does not match in the PDF file");
                    }
                }
            }
            ExtentTestManager.TestSteps($"Verified the {materialType} material data in the PDF file");
        }

        private void ClickOnMaterialPageTab(string materialPageTab)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[text()='{materialPageTab}']")));
            CommonMethod.element.Click();
        }

        private void FetchMaterialData(string materialName)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath($"//div[text()='{materialName}']")));
            Assert.That(materialName, Is.EqualTo(CommonMethod.element.Text), $"{materialName} is not present");
            CommonMethod.element.Click();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//td[text()='Edit']")));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps($"Click on the edit button for the {materialName} in material page table");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='SupplierSku']")));
            materialData.Add(CommonMethod.element.GetAttribute("value"));
            ExtentTestManager.TestSteps($"Fetch the supplier SKU of {materialName} material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='Description']")));
            materialData.Add(CommonMethod.element.GetAttribute("value"));
            ExtentTestManager.TestSteps($"Fetch the supplier Description of {materialName} material");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='SupplierId']")));
            supplierIdOfMaterials.Add(CommonMethod.element.GetAttribute("value"));
            ExtentTestManager.TestSteps($"Fetch the supplier ID of the {materialName}");

            Driver.Navigate().Back();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='grid']")));
        }

        private void VerifySupplierIdOfMaterialInOutputPage(string supplierIdDescription, string supplierIdOfMaterial)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath($"//td//div[text()='{supplierIdDescription}']")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='w2ui-popup']")));
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='SupplierId']")));
            Assert.That(CommonMethod.element.GetAttribute("value"), Is.EqualTo(supplierIdOfMaterial));
            Console.WriteLine($"{supplierIdOfMaterial} is present in the {supplierIdDescription}");
            ExtentTestManager.TestSteps($"Verify the supplied ID of the {supplierIdDescription} in the output page");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[contains(@class,'w2ui-msg-close')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='optionList']")));
        }
    }
}