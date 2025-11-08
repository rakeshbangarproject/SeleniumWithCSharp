using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._94
{
    public class EaveEdge : BaseClass
    {
        public IList<int> originalCutLengths = new List<int>();
        public IList<int> updatedCutLengthsAfterEaveEdgeMaterial = new List<int>();

        [Test]
        public void TrimMarginOption()
        {
            // Log into the application and set the distributor
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add 'Eave Edge' as a Trim Margin option");

            // Perform steps to reach the Eave Edge Trim field
            HomePage.ClicksStartFromScratch();
            CommonMethod.Wait(2);
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickRoofTrim();
            DefaultJobElement.SelectEaveEdgeTrim("Part Length Trim");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickTrimMargins();
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickTrimOfJobReview();

            // Check material data and fetch cut lengths
            DefaultJobElement.CheckMaterialsDataFromJobReviewAndDoubleClickOnTheMaterial("Trim", "EaveEdge", null, "Part Length Trim", null, null, null, null, null, null, null);

            string cutLengthXPath = "//table[@id='mlpopup']//tr[{0}]//td[7]";

            // Store initial cut lengths
            for (int i = 2; i <= 3; i++)
            {
                string cutLengthText = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(cutLengthXPath, i)))).Text;
                int cutLength = int.Parse(cutLengthText.Replace("'", "").Trim());
                originalCutLengths.Add(cutLength);
            }

            // Enter new Eave Edge value and apply changes
            DefaultJobElement.EnterEaveEdgeInputField("5'");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));

            // Fetch new cut lengths after applying Eave Edge material changes
            DefaultJobElement.CheckMaterialsDataFromJobReviewAndDoubleClickOnTheMaterial("Trim", "EaveEdge", null, "Part Length Trim", null, null, null, null, null, null, null);

            for (int i = 2; i <= 3; i++)
            {
                string cutLengthText = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(cutLengthXPath, i)))).Text;
                int updatedCutLength = int.Parse(cutLengthText.Replace("'", "").Trim());
                updatedCutLengthsAfterEaveEdgeMaterial.Add(updatedCutLength);
            }

            // Verify if the updated cut lengths have increased by at least 5
            bool isCutLengthIncreased = true;
            for (int i = 0; i < originalCutLengths.Count; i++)
            {
                if (updatedCutLengthsAfterEaveEdgeMaterial[i] < originalCutLengths[i] + 5)
                {
                    isCutLengthIncreased = false;
                    break;
                }
            }

            if (isCutLengthIncreased)
            {
                ExtentTestManager.TestSteps("Verify that after applying the Eave Edge material, the cut length for the Eave Edge has increased by at least 5.");
                Console.WriteLine("Verify that after applying the Eave Edge material, the cut length for the Eave Edge has increased by at least 5.");
            }
            else
            {
                ExtentTestManager.TestSteps("Cut length increase verification failed.");
                Assert.Fail("Cut length has not increased as expected.");
            }
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add 'Eave Edge' as a Trim Margin option");
        }
    }
}
