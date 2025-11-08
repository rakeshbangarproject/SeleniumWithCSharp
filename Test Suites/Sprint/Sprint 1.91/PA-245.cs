using Forms.Reporting;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation.Helper;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Pages_Application;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._91
{

    [TestFixture, Category("Sprint_1._91")]
    public class CladdingExtension : BaseClass
    {
        public string folderPath = FolderPath.Download();
        public string outputElement = "//span[contains(text(),'{0}')]//preceding :: input[1]";

        [Test]
        public void PanelLengthWithAngledRoofCladdingExtensionForRoofingPassport()
        {
            LoginApplicationAndChangesDistributor("Angled Roof Cladding Extension Value Not Adding To Panel Length");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            SwitchToDrawingTabAndClickOnAssemblyDrawingElement();

            List<string[]> beforeApplyAngledRoofCladdingExtension = GetTheLengthFromSheathingRoof();
            SwitchToCladdingMenuAndEnterDataInTheAngledCladdingExtension("1'");
            List<string[]> afterApplyAngledRoofCladdingExtension = GetTheLengthFromSheathingRoof();
            ExtentTestManager.TestSteps($"Get the length of elements from sheathing drawing roof-6 table");
            VerifyLengthIsUpdated(beforeApplyAngledRoofCladdingExtension, afterApplyAngledRoofCladdingExtension);
            ExtentTestManager.TestSteps($"Get the length of elements from sheathing drawing roof-6 table");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickCladdingOfJobReview();
            CheckSheathingDrawingLengthsShownInTheCladdingTables(afterApplyAngledRoofCladdingExtension);
            SwitchTo3DViewTabAndSaveChanges();
            DownloadAndVerifyOutputDataFromPDF(afterApplyAngledRoofCladdingExtension);
            CommonMethod.DeleteFolderData();
            EnterDataInTheAngledRoofCladdingExtension("0");
            ApplyElementsOnCanvasBuildingAndSaveChanges();
            NavigateToJobListAndChangeDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Angled Roof Cladding Extension Value Not Adding To Panel Length");
        }

        #region Private Method
        /// <summary>
        /// Verify the roof length is updated or not
        /// </summary>
        private static void VerifyLengthIsUpdated(List<string[]> beforeApplyAngledRoofCladdingExtension, List<string[]> afterApplyAngledRoofCladdingExtension)
        {
            bool sheathingDrawingLength = AreListsOfArraysNotEqual(beforeApplyAngledRoofCladdingExtension, afterApplyAngledRoofCladdingExtension);
            if (sheathingDrawingLength)
            {
                ExtentTestManager.TestSteps("Exterior roof length is updated after apply angled roof cladding extension");
            }
            else
            {
                ExtentTestManager.TestSteps("Exterior roof length is not updated after apply angled roof cladding extension");
            }
        }

        /// <summary>
        /// Compare two list of array data 
        /// </summary>
        /// <param name="list1">First list array element</param>
        /// <param name="list2">Second list array element</param>
        /// <returns></returns>
        static bool AreListsOfArraysNotEqual(List<string[]> list1, List<string[]> list2)
        {
            if (list1.Count != list2.Count)
                return true;

            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i].Length != list2[i].Length)
                    return true;

                for (int j = 0; j < list1[i].Length; j++)
                {
                    if (list1[i][j] != list2[i][j])
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Wait for page load 
        /// Click on the Save button
        /// </summary>
        private void ApplyElementsOnCanvasBuildingAndSaveChanges()
        {
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClicksSaveButton();
        }

        /// <summary>
        /// Click on the Job list button and change distributor as AUTOTEST_PHTEST
        /// </summary>
        private void NavigateToJobListAndChangeDistributor()
        {
            DefaultJobElement.ClickJobListButton();
            CommonMethod.ChangeDistributor("AUTOTEST_PHTEST");
        }

        /// <summary>
        /// Click on the 3D View tab and save the job
        /// </summary>
        private void SwitchTo3DViewTabAndSaveChanges()
        {
            DefaultJobElement.ClickCanvas3DViewButton();
            DefaultJobElement.ClicksSaveButton();
        }

        /// <summary>
        /// Click on the details tab and click on the cladding tab
        /// Enter data in the Angled Cladding Extension field.
        /// </summary>
        /// <param name="value">The value to enter in the field.</param>
        private void SwitchToCladdingMenuAndEnterDataInTheAngledCladdingExtension(string value)
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickCladding();
            EnterDataInTheAngledRoofCladdingExtension(value);
            DefaultJobElement.PageLoaderFor2D();
            CommonMethod.Wait(2);
        }

        /// <summary>
        /// Check if sheathing drawing lengths are shown in the Cladding tables.
        /// </summary>
        /// <param name="tableData">The list of string arrays representing table data.</param>
        private static void CheckSheathingDrawingLengthsShownInTheCladdingTables(List<string[]> tableData)
        {
            foreach (string[] rowData in tableData)
            {
                string rowDataAsString = string.Join(" ", rowData);
                CommonMethod.Wait(2);

                // Find the Length column from the cladding table
                IReadOnlyList<IWebElement> columnElements = Driver.FindElements(By.XPath($"//tr[contains(@id,'grid_MaterialsGrid_rec') and descendant::div[text()='Roof']]//td[@col='8']"));

                bool rowDataFoundInColumn = false;

                // Check the sheathing drawing roof-6 lengths shown in the Cladding table
                foreach (IWebElement element in columnElements)
                {
                    if (rowDataAsString.Contains(element.Text))
                    {
                        rowDataFoundInColumn = true;
                        break;
                    }
                }

                if (rowDataFoundInColumn)
                {
                    ExtentTestManager.TestSteps($"Verify that the sheathing drawing of length '{rowDataAsString}' found in the cladding length column.");
                    Console.WriteLine($"Verify that the sheathing drawing of length '{rowDataAsString}' found in the cladding length column.");
                }
                else
                {
                    Assert.Fail($"Verify that the sheathing drawing of length '{rowDataAsString}' not found in the cladding length column.");
                }
            }
        }

        /// <summary>
        /// Fetches data from a PDF file and checks for Sheathing Drawing - ROOF-6 length.
        /// </summary>
        /// <param name="tableData">The list of string arrays representing table data to check.</param>
        private void DownloadAndVerifyOutputDataFromPDF(List<string[]> tableData)
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Cladding Drawings");

            // Get the PDF file name and path
            string pdfFilePath = CommonMethod.VerifyPDFContent("Zombie Parts");
            ExtentTestManager.TestSteps("Verify PDF File is downloaded");

            bool isTextFound = false;
            bool isDimensionFound = false;

            // Check if the text "Sheathing Drawing - ROOF-6" is found in the PDF content
            isTextFound = pdfFilePath.ToString().Contains("Sheathing Drawing - ROOF-6");

            // Check if any of the table data is found in the PDF content
            foreach (string[] rowData in tableData)
            {
                string rowDataAsString = string.Join(" ", rowData);
                if (!pdfFilePath.ToString().Contains(rowDataAsString))
                {
                    isDimensionFound = false;
                    break;
                }
                else
                {
                    isDimensionFound = true;
                }
            }

            // Perform assertions based on the found text and table data
            if (isTextFound)
            {
                if (isDimensionFound)
                {
                    ExtentTestManager.TestSteps("Verify that the updated length of Roof-6 is shown in the cladding drawing pdf.");
                    Console.WriteLine("\nVerify that the updated length of Roof-6 is shown in the cladding drawing pdf.");
                }
                else
                {
                    Assert.Fail("Verify that the updated length of Roof-6 is not shown in the cladding drawing pdf.");
                }
            }
            else
            {
                Assert.Fail("Text not found in the PDF file.");
            }
        }

        /// <summary>
        /// Retrieves the length data from the sheathing roof table for Roof-6.
        /// </summary>
        /// <returns>A list of string arrays containing the length data.</returns>
        private List<string[]> GetTheLengthFromSheathingRoof()
        {
            // Find all rows in the table matching the condition
            IReadOnlyList<IWebElement> matchingRows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec') and descendant::div[text()='ExteriorRoof']]"));

            // Create a list to store the data from the matching rows
            List<string[]> tableData = new();

            foreach (IWebElement row in matchingRows)
            {
                // Find the columns in the current row
                IReadOnlyList<IWebElement> columns = row.FindElements(By.XPath(".//td[@col='6']"));

                // Create an array to store the data of the current row
                string[] rowData = new string[columns.Count];

                // Iterate through each column of the current row
                for (int i = 0; i < columns.Count; i++)
                {
                    // Store the text of the column in the array
                    rowData[i] = columns[i].Text;
                }

                // Add the data of the current row to the list
                tableData.Add(rowData);
            }

            return tableData;
        }

        /// <summary>
        /// Login to the application and set distributor as AUTOTEST_EAGLEVIEW Base
        /// </summary>
        private void LoginApplicationAndChangesDistributor(string taskName)
        {
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_EAGLEVIEW Base Distributor for Test Environment");
        }

        /// <summary>
        /// Click on the Roof-6 element in the Assembly drawing.
        /// </summary>
        private void SwitchToDrawingTabAndClickOnAssemblyDrawingElement()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickCladdingDrawingROOF_6();
        }

        /// <summary>
        /// Enter data in the Angled Roof Cladding Extension field.
        /// </summary>
        /// <param name="value">The value to enter in the field.</param>
        private void EnterDataInTheAngledRoofCladdingExtension(string value)
        {
            DefaultJobElement.EnterAngledRoofCladdingExtension(value);
        }
    }
}
#endregion