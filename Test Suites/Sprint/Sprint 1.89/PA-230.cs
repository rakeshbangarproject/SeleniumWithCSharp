using ClosedXML.Excel;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Resource;
using SmartBuildProductionAutomation.Helper;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartBuildAutomation
{
    [TestFixture, Category("Sprint_1._89")]
    public class Extension : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void AutoRoofExtension()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Auto Roof Margin Roof Panel Extensions");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickSheathing();
            CreateNewSheathingMaterial();
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DetailsTab();
            WallMaterialTab();
            ClickDrawingAndSheathingWallOne();
            string setExtensionZero = GetTheDataOfExteriorWall();
            CommonMethod.Wait(3);
            double inches1 = ProcessInput(setExtensionZero);
            CommonMethod.Wait(5);
            ChangeExtension();

            string setExtensionSix = GetTheDataOfExteriorWall();
            double inches2 = ProcessInput(setExtensionSix);
            double difference = Math.Abs(inches1 - inches2);
            double feet = Math.Floor(difference / 12);
            double remainingInches = difference % 12;

            if (remainingInches == 6)
            {
                Console.WriteLine($"After setting the Extension to 6, verify that the exterior wall length increases by 6 inches.({setExtensionZero} and {setExtensionSix} is {feet} feet ({remainingInches} inches)).");
                ExtentTestManager.TestSteps($"After setting the Extension to 6, verify that the exterior wall length increases by 6 inches.({setExtensionZero} and {setExtensionSix} is {feet} feet ({remainingInches} inches)).");
            }
            else
            {
                Console.WriteLine("Exterior wall length is not increases");
                ExtentTestManager.TestSteps($"Exterior wall length is not increases");
                Assert.Fail($"Exterior wall length is not increases. ({setExtensionZero} and {setExtensionSix} is {feet} feet ({remainingInches} inches)).");
            }

            CheckEaveWallMargin();
            string setEaveWallMargin = GetTheDataOfExteriorWall();
            CommonMethod.Wait(5);
            double inches3 = ProcessInput(setEaveWallMargin);
            double eaveWallDifference = Math.Abs(inches1 - inches3);
            double feet1 = Math.Floor(eaveWallDifference / 12);
            double remainingInches1 = eaveWallDifference % 12;

            if (remainingInches1 == 9)
            {
                Console.WriteLine($"After setting the Eave Wall Margin to  3”, verify that the exterior wall length increases by 6 inches..({setExtensionSix} and {setEaveWallMargin} is {feet1} feet ({remainingInches1} inches)).");
                ExtentTestManager.TestSteps($"After setting the Eave Wall Margin to  3”, verify that the exterior wall length increases by 6 inches..({setExtensionSix} and {setEaveWallMargin} is {feet1} feet ({remainingInches1} inches)).");
            }
            else
            {
                Console.WriteLine("Exterior wall length is not increases");
                ExtentTestManager.TestSteps($"Exterior wall length is not increases");
                Assert.Fail();
            }

            CheckRoundSheathing();

            string setRoundSheathing = GetTheDataOfExteriorWall();
            CommonMethod.Wait(5);
            double inches4 = ProcessInput(setRoundSheathing);

            if (inches4 % 1 == 0)
            {
                Console.WriteLine($"Verify that the ExteriorWall parts are rounded up {setRoundSheathing} to the next inch, After setting the Round Sheathing is 1”.");
                ExtentTestManager.TestSteps($"Verify that the ExteriorWall parts are rounded up {setRoundSheathing} to the next inch, After setting the Round Sheathing is 1”.");
            }
            else
            {
                Console.WriteLine($"Verify that the ExteriorWall parts are not rounded up {setRoundSheathing} to the next inch, After setting the Round Sheathing is 1”.");
                ExtentTestManager.TestSteps($"Verify that the ExteriorWall parts are not rounded up {setRoundSheathing} to the next inch, After setting the Round Sheathing is 1”.");
                Assert.Fail($"Verify that the ExteriorWall parts are not rounded up {setRoundSheathing} to the next inch, After setting the Round Sheathing is 1”.");
            }

            VerifyExtensionInTheExcelFile();
            CommonMethod.DeleteFolderData();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Auto Roof Margin Roof Panel Extensions");
        }

        #region Private Method
        private void CreateNewSheathingMaterial()
        {
            SetupWizard.DeleteSetupWizardData("RoofExtensionTest");

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickSheathing();
            }

            SetupWizard.ClickAddButton();
            SetupWizard.EnterSKUInputField("TestAutoRoofExtension");
            SetupWizard.EnterDescriptionInputField("RoofExtensionTest");
            SetupWizard.EnterCoverageWidthInputField("36");
            SetupWizard.EnterFullWidthInputField("37.5");
            SetupWizard.EnterThicknessInputField("0.25");
            SetupWizard.EnterMinimumCutLengthInputField("36");
            SetupWizard.SelectAllElementFromUsageTable();
            SetupWizard.EnterPricingDetails("3", "4");
            SetupWizard.ClickColorButtonOfPricingTable();
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        private void DetailsTab()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallSheathing();
            CommonMethod.Wait(2);
        }

        private void WallMaterialTab()
        {
            DefaultJobElement.SelectWallMaterialElement("RoofExtensionTest");
            DefaultJobElement.EnterEaveWallMargin("0'");
            DefaultJobElement.EnterRoundSheathing("0'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void ClickDrawingAndSheathingWallOne()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
        }

        private void CheckEaveWallMargin()
        {
            DetailsTab();
            DefaultJobElement.EnterEaveWallMargin("3\"");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
            CommonMethod.Wait(3);
        }

        private void CheckRoundSheathing()
        {
            DefaultJobElement.EnterRoundSheathing("1\"");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForTheSpinner)));
            CommonMethod.Wait(3);
        }

        private string GetTheDataOfExteriorWall()
        {
            string exteriorWall = GetElementText(TestData.RoofExtension.exteriorWallValue);
            return exteriorWall;
        }

        private string GetElementText(string xpath)
        {
            return GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath))).Text;
        }

        private void EnterJobName()
        {
            DefaultJobElement.ClicksJobButton();
            DefaultJobElement.EnterJobNameInputField("AutoRoofExtension");
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            DefaultJobElement.ClicksSaveButton();
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("SetupWizardPageURL"));
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            GetWebDriverWait().Until(ExpectedConditions.ElementExists(By.XPath("//div[@class='tabs-wizrd']")));
            ExtentTestManager.TestSteps("Navigate to Setup Wizard");
            CommonMethod.Wait(1);
        }

        private void ChangeExtension()
        {
            EnterJobName();
            SetupWizard.ClickSheathing();
            SetupWizard.SearchElementAndClickOnTheEdit("RoofExtensionTest");
            SetupWizard.EnterExtensionInputField("6'");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard(); 
            HomePage.ClicksJobTab();
            JobPage.OpenJob("AutoRoofExtension");
            CommonMethod.PageLoader();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            ClickDrawingAndSheathingWallOne();
        }

        private void VerifyExtensionInTheExcelFile()
        {
            DefaultJobElement.NavigateToHomePage();
            HomePage.ClicksJobTab();
            JobPage.DeleteJobFromJobPages("AutoRoofExtension");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickSheathing();
            SetupWizard.DownloadTheExcelFile();

            string excelFileName = "SetupWizard-Sheathing.xlsx";
            string excelFileOfSheathing = Path.Combine(folderPath, excelFileName);
            CommonMethod.Wait(1);
            FolderPath.WaitForFileDownload(excelFileOfSheathing, 60);
            ExtensionColumn(excelFileOfSheathing, "Sheathing Material Excel file");

            SetupWizard.DeleteSetupWizardData("RoofExtensionTest");
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.NavigateToTheMaterialsPage();
            Materials.DownloadExcelFile();
            string excelFileNameOfMaterial = "Materials-AUTOTEST_PHTEST.xlsx";
            string excelFileOfMaterial = Path.Combine(folderPath, excelFileNameOfMaterial);
            FolderPath.WaitForFileDownload(excelFileOfSheathing, 60);
            CommonMethod.Wait(1);
            ExtensionColumn(excelFileOfMaterial, "Materials Excel file");
        }

        private void ExtensionColumn(string filePath, string elementName)
        {
            string columnNameToFind = "Extension";

            using (var workbook = new XLWorkbook(filePath))
            {
                // Assuming there's only one worksheet; if not, adjust as needed
                var worksheet = workbook.Worksheets.First();

                // Find the column index for the "Extension" column in the first row
                int columnIndex = -1;
                var firstRow = worksheet.FirstRow();
                var headerCell = firstRow.CellsUsed(c => c.Value.ToString().Equals(columnNameToFind)).FirstOrDefault();

                if (headerCell != null)
                {
                    columnIndex = headerCell.WorksheetColumn().ColumnNumber();
                    Console.WriteLine($"The '{columnNameToFind}' column is present in column {columnIndex} of {elementName}");
                    ExtentTestManager.TestSteps($"The '{columnNameToFind}' column is present in column {columnIndex} of {elementName}");
                }
                else
                {
                    Assert.Fail($"Column '{columnNameToFind}' not found in the first row of the {elementName}");
                }
            }
        }

        static double ProcessInput(string input)
        {
            // Use regular expressions to extract feet, inches, and fractions of an inch.
            Match match = Regex.Match(input, @"(\d+)'\s+(\d+)(?:\s+(\d+)/(\d+))?""");

            if (match.Success)
            {
                int feet = int.Parse(match.Groups[1].Value);
                int inches = int.Parse(match.Groups[2].Value);
                int numerator = 0;
                int denominator = 1;

                // Check if a fraction is provided and extract it.
                if (match.Groups[3].Success && match.Groups[4].Success)
                {
                    numerator = int.Parse(match.Groups[3].Value);
                    denominator = int.Parse(match.Groups[4].Value);
                }

                // Convert the fractions to a decimal value.
                double fraction = (double)numerator / denominator;

                // Calculate the total length in inches and return it.
                double totalInches = (feet * 12) + inches + fraction;
                return totalInches;
            }
            else
            {
                Console.WriteLine("Invalid input format: " + input);
                return 0; // Return 0 for invalid input.
            }
        }
    }
}
#endregion

