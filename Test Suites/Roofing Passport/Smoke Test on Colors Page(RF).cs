using Forms.Reporting;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System.IO;
using System.Linq;

namespace Roofing_Passport
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestOnColorsPage : BaseClass
    {
        #region XPath
        By testMaster = By.XPath("//div[contains(text(),'Test Master 123')]");
        By colorMap = By.XPath("(//label[contains(text(),'Color Map')])[2]//following :: div[2]");
        By bumpMap = By.XPath("(//label[contains(text(),'Bump Map')])[2]//following :: div[2]");
        By cancelButton = By.XPath("(//button[contains(text(),'Cancel')])[2]");
        By deleteButton = By.XPath("(//table[contains(@title,'- Delete the selected material')])[1]");
        By yesButton = By.XPath("//button[contains(text(),'Yes')][1]");
        By test0673Color = By.XPath("//td[contains(text(),'Test Color 0673')]//following::a[contains(text(),'Edit')]");
        By backToListButton = By.XPath("//a[contains(text(),'Back to List')]");
        By changeColorNameOfColorPage = By.XPath("//input[@id='Name']");
        By colorMapSelectDropdown = By.XPath("//select[@id='Texture']");
        By bumpMapSelectDropdown = By.XPath("//select[@id='BumpMap']");
        By savebuttonOfColorPage = By.XPath("//input[@class='btn btn-default']");
        By DownloadXLSXButton = By.XPath("//a[contains(text(),'Download XLSX')]");
        By DownloadCSVXButton = By.XPath("//a[contains(text(),'Download CSV')]");
        public string folderPath = FolderPath.Download();
        #endregion

        [Test]
        public void ColorsPage()
        {
            ExtentTestManager.CreateTest("Smoke Test On Colors Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();
            AddDataInTheSetupWizard();
            HomePage.NavigateToTheColorsPage();
            VerifyDataInColorsPage();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();
            DeleteData();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Colors Page");
        }

        #region Private Method
        private void DeleteData()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(testMaster));
            string colorName = CommonMethod.element.Text;
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).DoubleClick().Perform();
            Assert.True(colorName.Equals("Test Master 123"));
            ExtentTestManager.TestSteps("Verify that Color Name has been changing after color name change on the colors page.");
            CommonMethod.Wait(1);

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(colorMap));
            string colorMapValue = CommonMethod.element.GetAttribute("title");

            Assert.True(colorMapValue.Equals("Lap Siding Texture"));
            ExtentTestManager.TestSteps("Verify that Color Map has been changing after color Map change on the colors page.");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(bumpMap));
            string bumpMapValue = CommonMethod.element.GetAttribute("title");

            Assert.True(bumpMapValue.Equals("Lap Siding Panel"));
            ExtentTestManager.TestSteps("Verify that Bump Map has been changing after color Map change on the colors page.");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(cancelButton)).Click();
            ExtentTestManager.TestSteps("Click on the cancel button");
            SetupWizard.DeleteSetupWizardData("Test Master 123");
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void VerifyDataInColorsPage()
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(test0673Color));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps("Verify that the new color is add to the color table.");
            ExtentTestManager.TestSteps("Click on the New material color from the Colors table");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(backToListButton)).Click();
            ExtentTestManager.TestSteps("Click on the Back to List button");

            string colorURL = Driver.Url;
            Assert.True(colorURL.Contains(TestContext.Parameters.Get("ColorsPageURL"))); 
            ExtentTestManager.TestSteps("Verify that the back-to-list button navigates to the colors page.");
            XLSXFile();
            CSVFile();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(test0673Color));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Perform();
            ExtentTestManager.TestSteps("Again Click on the New material color from the Colors table");

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(changeColorNameOfColorPage));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("Test Master 123").Perform();
            ExtentTestManager.TestSteps("Change the Color Name");

            SelectElement dropdown = new SelectElement(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(colorMapSelectDropdown)));
            dropdown.SelectByValue("tex-lap-siding");
            ExtentTestManager.TestSteps("Change the Texture dropdown value on Colors Page.");

            SelectElement dropdownBump = new SelectElement(GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(bumpMapSelectDropdown)));
            dropdownBump.SelectByValue("lap-siding");
            ExtentTestManager.TestSteps("Change the BumpMap dropdown value on Colors Page.");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(savebuttonOfColorPage)).Click();
            ExtentTestManager.TestSteps("Click on the Save button");
        }

        private void AddDataInTheSetupWizard()
        {
            SetupWizard.ClickAddButton();
            SetupWizard.ColorNameInputField("Test Color 0673");
            SetupWizard.ColorCodeInputField("#545686");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.SelectHexCode("FF9838");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
            CommonMethod.Wait(2);
        }

        private void XLSXFile()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(DownloadXLSXButton)).Click();
            ExtentTestManager.TestSteps("Click on the Download XLSX file button");
            CommonMethod.Wait(5);

            // Set up file paths and names
            string excelFileName = "Colors-AUTOTEST_EAGLEVIEW BASE.xlsx";
            string excelFilePath = Path.Combine(folderPath, excelFileName);
            CommonMethod.Wait(5);
            ExtentTestManager.TestSteps("Verify that the XLSX file is downloaded");

            // Open Excel File 
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(excelFilePath, FileMode.Open));

            // Get the First Sheet of excel
            ISheet sheet = workbook.GetSheetAt(0);

            // Get the last row of excel sheet
            int lastRowNum = sheet.LastRowNum;

            // Edit the last row of 3 column
            XSSFRow dataRow = (XSSFRow)sheet.GetRow(lastRowNum);
            string colorNameOfLastRow = dataRow.Cells[0].ToString();

            Assert.True(colorNameOfLastRow.Equals("Test Color 0673"));
            workbook.Close();
        }

        public void CSVFile()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(DownloadCSVXButton)).Click();
            ExtentTestManager.TestSteps("Click on the Download CSV file button");
            CommonMethod.Wait(5);

            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");
            string excelFileName = "Colors-AUTOTEST_EAGLEVIEW BASE.csv";
            string downloadCSVFile = Path.Combine(folderPath, excelFileName);
            CommonMethod.Wait(5);
            ExtentTestManager.TestSteps("Verify that the CSV file is downloaded");

            // Read the contents of the CSV file into a string array
            string[] lines = File.ReadAllLines(downloadCSVFile);

            // Split the last line of the array into its individual columns
            string[] columns = lines.Last().Split(',');

            Assert.True(columns[0].Equals("Test Color 0673"));
        }
    }
}
#endregion