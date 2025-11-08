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
    public class CladdingExtensionForPostFrame : BaseClass
    {
        public string folderPath = FolderPath.Download();

        [Test]
        public void PanelLengthWithAngledRoofCladdingExtensionForPostFrame()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Round Sheathing and Round Angled Sheathing must apply to job drawings, material list and pricing");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("PFS-4510Test");
            CommonMethod.PageLoader();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallSheathing();
            EnterDataInTheRoundAngledSheathing("0'");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            SwitchToDrawingTabAndClickOnSheathingDrawingElement();
            List<string[]> beforeApplyRoundAngledSheathing = GetTheLengthFromSheathingWall();
            SwitchToCladdingMenuAndEnterDataInTheAngledCladdingExtension("1'");
            List<string[]> afterApplyRoundAngledSheathing = GetTheLengthFromSheathingWall();
            ExtentTestManager.TestSteps($"Get the length of elements from sheathing drawing EXT-4 table");
            VerifyLengthIsUpdated(beforeApplyRoundAngledSheathing, afterApplyRoundAngledSheathing);
            ExtentTestManager.TestSteps($"Get the length of elements from sheathing drawing EXT-4 table");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            CheckSheathingDrawingLengthsShownInTheCladdingTables(afterApplyRoundAngledSheathing);
            SwitchTo3DViewTabAndSaveChanges();
            DownloadAndVerifyOutputDataFromPDF(afterApplyRoundAngledSheathing);
            CommonMethod.DeleteFolderData();
            EnterDataInTheRoundAngledSheathing("0'");
            ApplyElementsOnCanvasBuildingAndSaveChanges();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Round Sheathing and Round Angled Sheathing must apply to job drawings, material list and pricing");
        }

        /// <summary>
        /// Click on the EXT-4 element in the Sheathing drawing.
        /// </summary>
        private void SwitchToDrawingTabAndClickOnSheathingDrawingElement()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_4();
        }

        /// <summary>
        /// Retrieves the length data from the sheathing roof table for EXT-4(Wall).
        /// </summary>
        /// <returns>A list of string arrays containing the length data.</returns>
        private List<string[]> GetTheLengthFromSheathingWall()
        {
            // Find all rows in the table matching the condition
            IReadOnlyList<IWebElement> matchingRows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec') and descendant::div[text()='ExteriorWall']]"));

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
        /// Click on the details tab and click on the cladding tab
        /// Enter data in the Angled Cladding Extension field.
        /// </summary>
        /// <param name="value">The value to enter in the field.</param>
        private void SwitchToCladdingMenuAndEnterDataInTheAngledCladdingExtension(string value)
        {
            EnterDataInTheRoundAngledSheathing(value);
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
            CheckValue(value);
        }

        private void CheckValue(string value)
        {
            string angledSheathingRound = DefaultJobElement.GetRoundSheathingValue();
            string sheathingRound = DefaultJobElement.GetRoundAngledSheathingValue();
            Assert.That(angledSheathingRound.Equals(value), Is.True);
            Assert.That(sheathingRound.Equals(value), Is.True);
        }

        /// <summary>
        /// Enter data in the Round Angled Sheathing field.
        /// </summary>
        /// <param name="value">The value to enter in the field.</param>
        private void EnterDataInTheRoundAngledSheathing(string value)
        {
            DefaultJobElement.EnterRoundAngledSheathing(value);
            DefaultJobElement.EnterRoundSheathing(value);
        }

        private static void VerifyLengthIsUpdated(List<string[]> beforeApplyAngledRoofCladdingExtension, List<string[]> afterApplyAngledRoofCladdingExtension)
        {
            bool sheathingDrawingLength = AreListsOfArraysNotEqual(beforeApplyAngledRoofCladdingExtension, afterApplyAngledRoofCladdingExtension);
            if (sheathingDrawingLength)
            {
                ExtentTestManager.TestSteps("Exterior Wall length is updated after apply round angled sheathing");
            }
            else
            {
                ExtentTestManager.TestSteps("Exterior Wall length is not updated after apply round angled sheathing");
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
        /// Check sheathing drawing lengths are shown in the Sheathing tables.
        /// </summary>
        /// <param name="tableData">The list of string arrays representing table data.</param>
        private static void CheckSheathingDrawingLengthsShownInTheCladdingTables(List<string[]> tableData)
        {
            CommonMethod.Wait(2);

            foreach (string[] rowData in tableData)
            {
                string rowDataAsString = string.Join(" ", rowData);

                // Find the Length column from the Sheathing table
                IReadOnlyList<IWebElement> columnElements = Driver.FindElements(By.XPath($"//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='ExteriorWall']]//td[@col='8']"));

                bool rowDataFoundInColumn = false;

                // Check the sheathing drawing EXT-4(Walls) lengths shown in the Sheathing table
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
                    ExtentTestManager.TestSteps($"Verify that the sheathing drawing of length '{rowDataAsString}' found in the Sheathing length column.");
                    Console.WriteLine($"Verify that the sheathing drawing of length '{rowDataAsString}' found in the Sheathing length column.");
                }
                else
                {
                    Assert.Fail($"Verify that the sheathing drawing of length '{rowDataAsString}' not found in the Sheathing length column.");
                }
            }
        }

        /// <summary>
        /// Wait for page load 
        /// Click on the Save button
        /// </summary>
        private void ApplyElementsOnCanvasBuildingAndSaveChanges()
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CheckValue("0'");
            DefaultJobElement.ClicksSaveButton();
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
        /// Fetches data from a PDF file and checks for Sheathing Drawing - EXT-4(Walls) length.
        /// </summary>
        /// <param name="tableData">The list of string arrays representing table data to check.</param>
        private void DownloadAndVerifyOutputDataFromPDF(List<string[]> tableData)
        {
            DefaultJobElement.DownloadFileFromOutputFrame("Sheathing Drawings");

            // Get the PDF file name and path
            string pdfFilePath = CommonMethod.VerifyPDFContent("PFS-4510Test");

            bool isTextFound = false;
            bool isDimensionFound = false;

            // Check if the text "Sheathing Drawing - EXT-4" is found in the PDF content
            isTextFound = pdfFilePath.ToString().Contains("Sheathing Drawing - EXT-4");

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
                    ExtentTestManager.TestSteps("Verify that the updated length of Sheathing Drawing (EXT-4) is shown in the Sheathing drawing pdf.");
                    Console.WriteLine("\nVerify that the updated length of Sheathing Drawing (EXT-4) is shown in the Sheathing drawing pdf.");
                }
                else
                {
                    Assert.Fail("Verify that the updated length of Sheathing Drawing (EXT-4) is not shown in the Sheathing drawing pdf.");
                }
            }
            else
            {
                Assert.Fail("Text not found in the PDF file.");
            }
        }
    }
}