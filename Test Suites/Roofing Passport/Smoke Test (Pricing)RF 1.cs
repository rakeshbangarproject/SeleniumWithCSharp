using Forms.Reporting;
using Microsoft.VisualBasic.FileIO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.IO;

namespace SmartBuildAutomation.Roofing_Passport
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestPricing_RF : BaseClass
    {
        public string folderPath = FolderPath.Download();
        #region XPath
        readonly string AddNewMaterialInputBoxes = "//input[@name='{0}']";
        readonly string MaterialPricingsTableInputBox = "//tr[@id='{0}']//td[@col='{1}']";
        readonly string PricingPageTabOptions = "//div[text()='{0}']";
        readonly string DownloadMaterialTableOption = "//input[@value='{0}']";

        readonly By SettingsDropDown = By.XPath("//a[text()='Settings ']");
        readonly By PartLengthPricingOption = By.XPath("//td[text()='Part Lengths']");
        readonly By ColorMapDropdown = By.XPath("(//label[text()='Color Map']//following::div[contains(@class,'w2ui-list-title')])[1]");
        readonly By BumpMapDropdown = By.XPath("(//label[text()='Bump Map']//following::div[contains(@class,'w2ui-list-title')])[1]");
        readonly By PricingPageLink = By.XPath("//a[text()='Pricing']");
        readonly By PricingPageDownloadButton = By.XPath("//td[text()='Download']");
        #endregion

        SmokeTestMaterialPage_RF MaterialPage = new SmokeTestMaterialPage_RF();

        string[] MaterialsAdded = { "Test Cladding Material 1", "Test Cladding Material 2", "Test Connectors Material 1", "Test Fasteners Material 1", "Test Hardware Material 1", "Test Labor Material 1", "Test Freight Material 1" };
        string[] CostAndPriceOfMaterialsAdded = { "$30.00", "$40.00", "$10.00", "$20.00", "$20.00", "$30.00", "$30.00", "$40.00", "$50.00", "$60.00", "$10.00", "$20.00", "$20.00", "$30.00" };

        [Test, Order(1)]
        public void Pricing()
        {
            ExtentTestManager.CreateTest("Smoke Test On Pricing Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickCladding();
            AddCladdingMaterial_PartLength();
            AddCladdingMaterial_RandomLength();
            SetupWizard.ClickConnector();
            AddConnectorsMaterial();
            SetupWizard.ClickFasteners();
            AddFastenersMaterial();
            SetupWizard.ClickHardware();
            AddHardwareMaterial();
            SetupWizard.ClickLabor();
            AddLaborMaterial();
            SetupWizard.ClickFreight();
            AddFreightMaterial();
            SetupWizard.SaveDataInTheSetupWizard();
            NavigateToPricingsPage();
            SearchMaterialAddedInPricingTable("Test Cladding Material 1");
            VerifyMaterialsAddedInPricingTable("Test Cladding Material 1");
            SearchMaterialAddedInPricingTable("Test Cladding Material 2");
            VerifyMaterialsAddedInPricingTable("Test Cladding Material 2");
            ClickOnPricingPageTabOption("Hardware");
            SearchMaterialAddedInPricingTable("Test Hardware Material 1");
            VerifyMaterialsAddedInPricingTable("Test Hardware Material 1");
            ClickOnPricingPageTabOption("Connector");
            SearchMaterialAddedInPricingTable("Test Connectors Material 1");
            VerifyMaterialsAddedInPricingTable("Test Connectors Material 1");
            ClickOnPricingPageTabOption("Fastener");
            SearchMaterialAddedInPricingTable("Test Fasteners Material 1");
            VerifyMaterialsAddedInPricingTable("Test Fasteners Material 1");
            ClickOnPricingPageTabOption("Labor");
            SearchMaterialAddedInPricingTable("Test Labor Material 1");
            VerifyMaterialsAddedInPricingTable("Test Labor Material 1");
            ClickOnPricingPageTabOption("Freight");
            SearchMaterialAddedInPricingTable("Test Freight Material 1");
            VerifyMaterialsAddedInPricingTable("Test Freight Material 1");
            DownloadPricingTable_Excel();
            VerifyMaterialsAdded_Excel();
            DownloadPricingTable_Csv();
            VerifyMaterialsAdded_Csv();
        }

        [Test, Order(2)]
        public void DeleteMaterialsAdded()
        {
            ExtentTestManager.CreateTest("Delete the Materials added");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickCladding();
            SetupWizard.DeleteSetupWizardData("Test Cladding Material 1");
            SetupWizard.DeleteSetupWizardData("Test Cladding Material 2");
            SetupWizard.ClickConnector();
            SetupWizard.DeleteSetupWizardData("Test Connectors Material 1");
            SetupWizard.ClickFasteners();
            SetupWizard.DeleteSetupWizardData("Test Fasteners Material 1");
            SetupWizard.ClickHardware();
            SetupWizard.DeleteSetupWizardData("Test Hardware Material 1");
            SetupWizard.ClickLabor();
            SetupWizard.DeleteSetupWizardData("Test Labor Material 1");
            SetupWizard.ClickFreight();
            SetupWizard.DeleteSetupWizardData("Test Freight Material 1");
            SetupWizard.SaveDataInTheSetupWizard();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Materials Page");
        }

        #region Private Method
        private void AddCladdingMaterial_PartLength()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            EnterCladdingMaterialDetails("Test Cladding Material 1");
            CommonMethod.Wait(2);
            AddPricing("3", "4", "30", "40");
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(PartLengthPricingOption)).Click();
            ExtentTestManager.TestSteps("Click the part lengths pricing option");
            MaterialPage.SaveNewMaterial();
        }

        private void AddCladdingMaterial_RandomLength()
        {
            CommonMethod.Wait(3);
            MaterialPage.ClickOnAddMaterialIcon();
            EnterCladdingMaterialDetails("Test Cladding Material 2");
            CommonMethod.Wait(2);
            AddPricing("3", "4", "10", "20");
            CommonMethod.Wait(2);
            MaterialPage.SaveNewMaterial();
        }

        private void EnterCladdingMaterialDetails(string MaterialName)
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys(MaterialName);
            ExtentTestManager.TestSteps("Enter the Sku value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys(MaterialName);
            ExtentTestManager.TestSteps("Enter the description value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Dim1")))).SendKeys("36");
            ExtentTestManager.TestSteps("Enter the coverage width value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Dim2")))).SendKeys("37.5");
            ExtentTestManager.TestSteps("Enter the full width value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Dim3")))).SendKeys("0.25");
            ExtentTestManager.TestSteps("Enter the thickness value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "MaximumLength")))).SendKeys("50");
            ExtentTestManager.TestSteps("Enter the maximum length value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "UnderlapLength")))).SendKeys("5");
            ExtentTestManager.TestSteps("Enter the underlap length value for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(ColorMapDropdown)).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//tr[2]"))).Click();
            ExtentTestManager.TestSteps("Choose the color map for " + MaterialName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(BumpMapDropdown)).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='w2ui-overlay']//tr[1]"))).Click();
            ExtentTestManager.TestSteps("Choose the bump map for " + MaterialName);
            MaterialPage.AddSystems();
        }

        private void AddConnectorsMaterial()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys("Test Connectors Material 1");
            ExtentTestManager.TestSteps("Enter the Sku value for connectors material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys("Test Connectors Material 1");
            ExtentTestManager.TestSteps("Enter the description value for connectors material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierId")))).SendKeys("4");
            ExtentTestManager.TestSteps("Enter the supplier id value for connectors material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierSku")))).SendKeys("5");
            ExtentTestManager.TestSteps("Enter the supplier sku value for connectors material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Cost"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("50");
            ExtentTestManager.TestSteps("Enter the cost for connectors material");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Price"))));
            CommonMethod.element.Clear();
            CommonMethod.element.SendKeys("60");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price for connectors material");
            MaterialPage.SaveNewMaterial();
        }

        private void AddFastenersMaterial()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys("Test Fasteners Material 1");
            ExtentTestManager.TestSteps("Enter the Sku value for fasteners material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys("Test Fasteners Material 1");
            ExtentTestManager.TestSteps("Enter the description value for fasteners material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierId")))).SendKeys("2");
            ExtentTestManager.TestSteps("Enter the supplier id value for fasteners material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierSku")))).SendKeys("5");
            ExtentTestManager.TestSteps("Enter the supplier sku value for fasteners material");
            AddPricing("3", "4", "10", "20");
            MaterialPage.SaveNewMaterial();
        }

        private void AddHardwareMaterial()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys("Test Hardware Material 1");
            ExtentTestManager.TestSteps("Enter the Sku value for hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys("Test Hardware Material 1");
            ExtentTestManager.TestSteps("Enter the description value for hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierId")))).SendKeys("2");
            ExtentTestManager.TestSteps("Enter the supplier id value for hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierSku")))).SendKeys("2");
            ExtentTestManager.TestSteps("Enter the supplier sku value for hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Cost")))).SendKeys("30");
            ExtentTestManager.TestSteps("Enter the supplier sku value for hardware material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Price")))).SendKeys("40");
            ExtentTestManager.TestSteps("Enter the supplier sku value for hardware material");
            MaterialPage.SaveNewMaterial();
        }

        private void AddLaborMaterial()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys("Test Labor Material 1");
            ExtentTestManager.TestSteps("Enter the Sku value for labor material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys("Test Labor Material 1");
            ExtentTestManager.TestSteps("Enter the description value for labor material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Cost")))).SendKeys("20");
            ExtentTestManager.TestSteps("Enter the cost for labor material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Price")))).SendKeys("30");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price for labor material");
            MaterialPage.SaveNewMaterial();
        }

        private void AddFreightMaterial()
        {
            MaterialPage.ClickOnAddMaterialIcon();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Sku")))).SendKeys("Test Freight Material 1");
            ExtentTestManager.TestSteps("Enter the Sku value for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Description")))).SendKeys("Test Freight Material 1");
            ExtentTestManager.TestSteps("Enter the description value for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierId")))).SendKeys("2");
            ExtentTestManager.TestSteps("Enter the supplier id value for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "SupplierSku")))).SendKeys("2");
            ExtentTestManager.TestSteps("Enter the supplier sku value for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "PackagingCode")))).SendKeys("1");
            ExtentTestManager.TestSteps("Enter the packaging code value for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Cost")))).SendKeys("20");
            ExtentTestManager.TestSteps("Enter the cost for freight material");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(AddNewMaterialInputBoxes, "Price")))).SendKeys("30");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price for freight material");
            MaterialPage.SaveNewMaterial();
        }

        private void AddPricing(string CostColValue, string PriceColValue, string Cost, string Price)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPricingsTableInputBox, "grid_pricingsGrid_rec_0", CostColValue))));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Pause(TimeSpan.FromSeconds(1)).SendKeys(Cost).Perform();
            ExtentTestManager.TestSteps("Enter the cost in the pricings table");
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(MaterialPricingsTableInputBox, "grid_pricingsGrid_rec_0", PriceColValue))));
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).MoveToElement(CommonMethod.element).DoubleClick().Pause(TimeSpan.FromSeconds(2)).SendKeys(Price).Perform();
            CommonMethod.GetActions().SendKeys(Keys.Enter).Perform();
            ExtentTestManager.TestSteps("Enter the price in the pricings table");
        }

        private void SearchMaterialAddedInPricingTable(string MaterialName)
        {
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("grid_grid_search_all")));
            CommonMethod.GetActions().Click(CommonMethod.element).SendKeys(MaterialName + Keys.Enter).Perform();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Enter the name of the material in the pricing table search box");
        }

        private void VerifyMaterialsAddedInPricingTable(string MaterialNameAdded)
        {
            CommonMethod.Wait(2);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td[@class='w2ui-grid-data']//span)[1]")));
            Assert.That(CommonMethod.element.Text, Is.EqualTo(MaterialNameAdded));
            ExtentTestManager.TestSteps("Verify " + MaterialNameAdded + " is present in the pricing table");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("grid_grid_search_all")));
            CommonMethod.element.Clear();
            CommonMethod.Wait(1);
        }

        private void VerifyMaterialsAdded_Excel()
        {
            string excelFileName = "MaterialPricing-AUTOTEST_EAGLEVIEW BASE.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            ExtentTestManager.TestSteps("Verify that the XLSX file is downloaded");

            using (FileStream fileStream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = new XSSFWorkbook(fileStream);
                ISheet worksheet = workbook.GetSheetAt(0);
                List<string> matchedRows = new List<string>();
                for (int row = 0; row <= worksheet.LastRowNum; row++)
                {
                    IRow excelRow = worksheet.GetRow(row);
                    if (excelRow != null)
                    {
                        ICell cell = excelRow.GetCell(0);
                        string cellValue = cell.StringCellValue;
                        foreach (string matchText in MaterialsAdded)
                        {
                            if (cellValue.Contains(matchText))
                            {
                                string rowValues = "";
                                for (int col = 0; col < excelRow.LastCellNum; col++)
                                {
                                    ICell valueCell = excelRow.GetCell(col);
                                    rowValues += valueCell.StringCellValue + "\t";
                                }
                                matchedRows.Add(rowValues);
                                break;
                            }
                        }
                    }
                }

                int i = 0;
                Console.WriteLine("------------ Materials added data from Excel ------------");
                foreach (string row in matchedRows)
                {
                    Console.WriteLine(row);
                    for (; i < CostAndPriceOfMaterialsAdded.Length;)
                    {
                        string[] columns = row.Split('\t');
                        Assert.That(columns[2], Is.EqualTo(CostAndPriceOfMaterialsAdded[i]));
                        i++;
                        Assert.That(columns[3], Is.EqualTo(CostAndPriceOfMaterialsAdded[i]));
                        i++;
                        break;
                    }
                }
            }
            ExtentTestManager.TestSteps("Verify the new materials added are present in the excel file and verify the cost and price of the materials");
        }

        private void VerifyMaterialsAdded_Csv()
        {
            string csvFileName = "MaterialPricing-AUTOTEST_EAGLEVIEW BASE.csv";
            string csvFilePath = Path.Combine(folderPath, csvFileName);
            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");
            bool results = false;
            string SkuColumn = "Vendor SKU";
            using (var parser = new TextFieldParser(csvFilePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                string[] header = parser.ReadFields();
                int columnIndex = Array.IndexOf(header, SkuColumn);

                Console.WriteLine("------------ Materials added data from CSV ------------");
                if (columnIndex != -1)
                {
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        string columnValue = fields[columnIndex];
                        if (MaterialPage.ContainsAnyName(columnValue, MaterialsAdded))
                        {
                            results = true;
                            Console.WriteLine(string.Join(",", fields));
                            ExtentTestManager.TestSteps(string.Join(",", fields));
                        }
                    }
                }
            }
            Assert.That(results, Is.True, "Verify the new materials added are not present in the csv file");
            ExtentTestManager.TestSteps("Verify the new materials added are present in the csv file");
        }

        public void NavigateToPricingsPage()
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SettingsDropDown)).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(PricingPageLink)).Click();
            ExtentTestManager.TestSteps("Navigate to the pricings page");
        }

        public void ClickOnPricingPageTabOption(string MaterialType)
        {
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(PricingPageTabOptions, MaterialType)))).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Click on the " + MaterialType + " pricing page tab option");
        }

        public void DownloadPricingTable_Excel()
        {
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(PricingPageDownloadButton));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click the download button from the pricing table");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(DownloadMaterialTableOption, "XLSX")))).Click();
            ExtentTestManager.TestSteps("Select the XLSX option to download the excel file");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@value='Download']"))).Click();
            CommonMethod.Wait(5);
        }

        public void DownloadPricingTable_Csv()
        {
            CommonMethod.Wait(1);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(PricingPageDownloadButton));
            CommonMethod.element.Click();
            ExtentTestManager.TestSteps("Click the download button from the pricing table");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(DownloadMaterialTableOption, "CSV")))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@value='Download']"))).Click();
            ExtentTestManager.TestSteps("Select the CSV option to download the excel file");
            CommonMethod.Wait(5);
        }
    }
}
#endregion