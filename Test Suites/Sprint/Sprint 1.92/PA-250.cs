using NUnit.Framework;
using SmartBuildAutomation;
using SmartBuildProductionAutomation.Helper;
using OpenQA.Selenium;
using Forms.Reporting;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System;
using System.Linq;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Locators;

namespace SmartBuildProjectBeta.Test_Suites.Sprint.Sprint_1._92
{
    public class CeilingLinerOverrides : BaseClass
    {
        [Test]
        public void Overrides()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Ceiling Liner Overrides do not apply setting");
            InvalidPart();
            CeilingMarginZero();
            CeilingMarginOne();
            PartLengthWithNoMargin();
            PartLengthWithMargin();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Ceiling Liner Overrides do not apply setting");
        }

        #region Private Method
        // Check material value with part length material and margin value
        private void PartLengthWithMargin()
        {
            ExtentTestManager.CreateTest("Case 4: Part Length, with margin");
            DefaultJobElement.EnterCeilingMargin("1");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            VerifyDataFromCutSheet("9' 6 1/2\"");
            ExtentTestManager.TestSteps("Margin one: Verify that the ceiling part length override is apply and all parts are cut from 20' pieces, for the part length material");
        }

        // Check material value with part length material and no margin value
        private void PartLengthWithNoMargin()
        {
            ExtentTestManager.CreateTest("Case 3: Part Length, no margin");
            DefaultJobElement.SelectCeilingMaterial("Test Part Length");
            DefaultJobElement.EnterCeilingMargin("0");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            IList<IWebElement> table = Driver.FindElements(By.XPath("//div[contains(@id,'grid_MaterialsGrid_records')]//div[text()='InteriorRoof']"));
            int count = table.Count();
            Assert.That(count, Is.EqualTo(1), "Multiple part lengths are used for InteriorRoof.");
            VerifyDataFromCutSheet("8' 6 1/2\"");
            ExtentTestManager.TestSteps("Margin Zero: Verify that the ceiling part length override is apply and all parts are cut from 20' pieces, for the part length material");
        }

        // Check material value with Random length material and margin value
        private void CeilingMarginOne()
        {
            ExtentTestManager.CreateTest("Case 2: Random Length, with margin");
            DefaultJobElement.EnterCeilingMargin("1");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            VerifyDataFromCutSheet("9' 6 1/2\"");
            ExtentTestManager.TestSteps("Margin One: Verify that the ceiling part length override is apply and all parts are cut from 20' pieces, for the random part length material");
        }

        // Check material value with Random length material and no margin value
        private void CeilingMarginZero()
        {
            ExtentTestManager.CreateTest("Case 1: Random Length, no margin");
            Driver.Navigate().Refresh();
           // Driver.SwitchTo().Alert().Accept();
            CommonMethod.PageLoader();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickCeilingLiner();
            DefaultJobElement.CheckHasCeilingCheckbox();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickCeilingLinerFromDetailsMenuList();
            DefaultJobElement.SelectCeilingMaterial("Test Random Length");
            DefaultJobElement.EnterCeilingMargin("0");
            DefaultJobElement.EnterCeilingPartLengthOverrides("20");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            VerifyDataFromCutSheet("8' 6 1/2\"");
            ExtentTestManager.TestSteps("Margin Zero: Verify that the ceiling part length override is apply and all parts are cut from 20' pieces, for the random part length material");
        }

        // Check material value with part length overrides invalid value
        private void InvalidPart()
        {
            ExtentTestManager.CreateTest("User part length overrides that are invalid");
            HomePage.ClicksStartFromScratch();
            CommonMethod.Wait(3);
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallSheathing();
            DefaultJobElement.SelectWallMaterialElement("Test Random Length");
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();

            List<string[]> beforeChangeSheathingLength = GetTheLengthFromSheathingWall();

            VerifySheathingLengthOverride("0'", beforeChangeSheathingLength);
            VerifySheathingLengthOverride("-1", beforeChangeSheathingLength);
            VerifySheathingLengthOverride("15/16\"", beforeChangeSheathingLength);
            VerifySheathingLengthOverride("Fred", beforeChangeSheathingLength);
            string[] expectedLength = { "0' 1\"" };
            List<string[]> expectedLengthList = new List<string[]> { expectedLength };
            DefaultJobElement.EnterSheathingLengthOverrides("1\"");
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            List<string[]> setPositiveSheathingLength = GetTheLengthFromSheathingWall();
            Assert.That(expectedLengthList, Is.EqualTo(setPositiveSheathingLength));
            VerifySheathingLengthOverride("1\"", expectedLengthList);
            VerifySheathingLengthOverride("-1,0,15/16\",Fred,1\"", expectedLengthList);
        }

        // verify interior wall pick length and cut length
        private void VerifyDataFromCutSheet(string cutLengthValue)
        {
            IWebElement interiorWallLength = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[contains(@id,'grid_MaterialsGrid_records')]//div[text()='InteriorRoof']//following::td[@col='8'])[1]")));
            string interiorWall = interiorWallLength.Text;
            CommonMethod.GetActions().MoveToElement(interiorWallLength).Pause(TimeSpan.FromSeconds(1)).DoubleClick().Perform();
            CommonMethod.Wait(2);
            Assert.That(interiorWall, Is.EqualTo("20'"), "Interior wall length is not equal to 20");
            IWebElement table = Driver.FindElement(By.XPath("//div[@id='w2ui-overlay']//table[@id='mlpopup']"));
            IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

            for (int i = 2; i < rows.Count; i++)
            {
                IList<IWebElement> columns = rows[i].FindElements(By.TagName("td"));

                string firstColumnName = columns[0].Text;

                if (firstColumnName.Equals("InteriorRoof"))
                {
                    string firstPickLength = columns[3].Text;
                    string firstCutLength = columns[6].Text;
                    Assert.That(firstPickLength, Is.EqualTo("20'"), "Pick length is not 20");
                    Assert.That(firstCutLength, Is.EqualTo(cutLengthValue).Or.EqualTo("20'"), $"Cut length is not shown 20' or {cutLengthValue}");
                }
                else
                {
                    string secondRowCutLength = columns[2].Text;
                    Assert.That(secondRowCutLength, Is.EqualTo(cutLengthValue), $"Cut length is not shown 20' or {cutLengthValue}");
                }
            }
        }

        // Method to perform sheathing length override and verify
        void VerifySheathingLengthOverride(string length, List<string[]> afterChangeSheathingLength)
        {
            DefaultJobElement.EnterSheathingLengthOverrides(length);
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            List<string[]> beforeChangeSheathingLength = GetTheLengthFromSheathingWall();
            VerifyLengthIsUpdated(beforeChangeSheathingLength, afterChangeSheathingLength, length);
        }

        private List<string[]> GetTheLengthFromSheathingWall()
        {
            // Find all rows in the table matching the condition
            IReadOnlyList<IWebElement> matchingRows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='ExteriorWall']]"));

            // Create a list to store the data from the matching rows
            List<string[]> tableData = new();

            foreach (IWebElement row in matchingRows)
            {
                // Find the columns in the current row
                IReadOnlyList<IWebElement> columns = row.FindElements(By.XPath(".//td[@col='8']"));

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

        private static void VerifyLengthIsUpdated(List<string[]> beforeApplyAngledRoofCladdingExtension, List<string[]> afterApplyAngledRoofCladdingExtension, string sheathingLength)
        {
            bool sheathingDrawingLength = AreListsOfArraysNotEqual(beforeApplyAngledRoofCladdingExtension, afterApplyAngledRoofCladdingExtension);
            if (sheathingDrawingLength)
            {
                Assert.Fail($"Verify that the exterior wall length is change after sheathing length is set to the {sheathingLength}");
            }
            else
            {
                ExtentTestManager.TestSteps($"Verify that the exterior wall length is not change after sheathing length is set to the {sheathingLength}");
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
    }
}
#endregion