using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._92
{
    public class TrussCarrierOverrides : BaseClass
    {

        [Test]
        public void AdvancedEdit()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Truss Carrier Override lengths not honored in Advanced Edit");
            OpenDefaultJobAndApplyPorch();
            SetTrussCarrierMaterial();
            CheckMainBuildingTrussCarrierApplyOnCanvas();
            SetTrussCarrierMaterialOnTheAdvancedEdit();
            CheckLengthOverrides();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Truss Carrier Override lengths not honored in Advanced Edit");
        }

        #region Private Method
        // Check length overrides is apply on the canvas building or not using framing data of job review 
        private void CheckLengthOverrides()
        {
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();

            IList<string[]> singleLengthOverridesForFramingAfterChanges = GetTheCutLength("TrussBearer", "20'", "14 LVL", "20'", "EXT-6");
            IList<string[]> secondLengthOverridesForFramingAfterChanges = GetTheCutLength("TrussBearer", "30'", "BAR JOIST", "30'", " ");
            ExtentTestManager.TestSteps("Verify that the Advanced Edit length overrides are applied to the EXT-6 wall.");

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_6();
            IList<string[]> singleLengthOverridesForDrawing1 = CompareCutLength();
            CheckCutLengths(secondLengthOverridesForFramingAfterChanges, singleLengthOverridesForDrawing1);
            ExtentTestManager.TestSteps("Verify that the same cut length is shown in the Assembly of drawing");
        }

        // Click on the Advanced edit and apply truss carrier material on the EXT-6 wall
        private void SetTrussCarrierMaterialOnTheAdvancedEdit()
        {
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickEXT_6();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierMaterialForTheAdvancedEdit("BAR JOIST");
            TrussCarrierLengthOverridesField("30'");
        }

        // Main building truss carrier material is apply on the canvas building using framing data of job review
        private void CheckMainBuildingTrussCarrierApplyOnCanvas()
        {
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();

            IList<string[]> singleLengthOverridesForFraming = GetTheCutLength("TrussBearer", "20'", "14 LVL", "20'", " ");
            ExtentTestManager.TestSteps("Verify that the truss carrier length overrides are applied on all EXT walls ");

            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_6();
            IList<string[]> singleLengthOverridesForDrawing = CompareCutLength();
            CheckCutLengths(singleLengthOverridesForFraming, singleLengthOverridesForDrawing);
            ExtentTestManager.TestSteps("Verify that the same cut length is shown in the Assembly of drawing");
        }

        // Apply truss carrier material on the main canvas building walls
        private void SetTrussCarrierMaterial()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickTrussCarrier();
            DefaultJobElement.SelectTrussCarrierMaterial("14 LVL");
            TrussCarrierLengthOverridesField("20'");
        }

        // Open default job and attached the porch on the left side
        private void OpenDefaultJobAndApplyPorch()
        {
            // Open Default Job
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClicksShellButton();
            string initialValue = DefaultJobElement.GetTheConfiguredPrice();

            // Attached porch on the eft side of canvas building
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickLeft();
            DefaultJobElement.ClickApplyButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            string currentValue = DefaultJobElement.GetTheConfiguredPrice();
            CheckCanvasBuildingModify(initialValue, currentValue, "Left side of the wall is not open");
        }

        // Check job review cult length and Drawing wall cut length
        private static void CheckCutLengths(IList<string[]> singleLengthOverridesForFraming, IList<string[]> singleLengthOverridesForDrawing)
        {
            bool isSame = AreListsEqualIgnoringLength(singleLengthOverridesForFraming, singleLengthOverridesForDrawing);

            if (!isSame)
            {
                Assert.Fail("Verify that the length overrides is not apply on the canvas building");
            }
        }

        static bool AreListsEqualIgnoringLength(IList<string[]> list1, IList<string[]> list2)
        {
            // Flatten the arrays within the lists
            var flattenedList1 = list1.SelectMany(arr => arr).ToList();
            var flattenedList2 = list2.SelectMany(arr => arr).ToList();

            // Check if both flattened lists are equal in length
            if (flattenedList1.Count == flattenedList2.Count)
            {
                // If lists are already of the same length, compare them directly
                return flattenedList1.SequenceEqual(flattenedList2);
            }
            else
            {
                // Find the shorter and longer lists
                IList<string> shorterList = flattenedList1.Count < flattenedList2.Count ? flattenedList1 : flattenedList2;
                IList<string> longerList = flattenedList1.Count < flattenedList2.Count ? flattenedList2 : flattenedList1;

                // Check if all elements from the shorter list are present in the longer list
                return shorterList.All(item => longerList.Contains(item));
            }
        }

        // Get the Length of cut from the drawing 
        private List<string[]> CompareCutLength()
        {
            IReadOnlyList<IWebElement> matchingRows = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_dwgMaterialsGrid_rec_') and descendant::div[text()='TrussBearer']]"));

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

        // Check the pick length, material, and cult length of truss bearer material
        private List<string[]> GetTheCutLength(string trussName, string valueOne, string materialName, string pickLengthOfRow, string panelName)
        {
            bool result = false;
            IReadOnlyList<IWebElement> matchingRows = Driver.FindElements(By.XPath($"//tr[contains(@id,'grid_MaterialsGrid_rec_') and descendant::div[text()='{trussName}']]"));

            List<string[]> tableData = new List<string[]>();

            foreach (IWebElement row in matchingRows)
            {
                IReadOnlyList<IWebElement> columns = row.FindElements(By.XPath(".//td[@col='8']"));
                IReadOnlyList<IWebElement> material = row.FindElements(By.XPath(".//td[@col='3']"));

                for (int i = 0; i < columns.Count; i++)
                {
                    string columnText = columns[i].Text;
                    string materialText = material[i].Text;

                    if (columnText.Equals(valueOne) && materialText.Equals(materialName))
                    {
                        CommonMethod.GetActions().DoubleClick(columns[i]).Perform();
                        CommonMethod.Wait(2);

                        IWebElement table = Driver.FindElement(By.XPath("//div[@id='w2ui-overlay']//table[@id='mlpopup']"));
                        IList<IWebElement> rows = table.FindElements(By.TagName("tr"));

                        foreach (IWebElement row1 in rows.Skip(1))
                        {
                            IList<IWebElement> columns1 = row1.FindElements(By.TagName("td"));

                            if (columns1[0].Text.Equals(trussName))
                            {
                                result = true;
                                string data = columns1[6].Text;
                                string panel = columns1[4].Text;
                                string pickLength = columns1[3].Text;

                                Assert.That(pickLength, Is.EqualTo(pickLengthOfRow), "Pick length is not match with length");
                                Assert.IsTrue(panel != panelName, "Length overrides is not apply on the wall");

                                tableData.Add(new string[] { data });
                            }
                        }
                    }
                }
            }

            Assert.That(result, Is.True, "Length overrides is not apply on the wall");
            return tableData;
        }

        // Check canvas is modified or not
        private void CheckCanvasBuildingModify(string initialValue, string currentValue, string reason)
        {
            if (initialValue.Equals(currentValue))
            {
                Assert.Fail(reason);
            }
        }

        private void TrussCarrierLengthOverridesField(string length)
        {
            DefaultJobElement.EnterTrussCarrierLengthOverrides(length);
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
        }
    }
}
#endregion