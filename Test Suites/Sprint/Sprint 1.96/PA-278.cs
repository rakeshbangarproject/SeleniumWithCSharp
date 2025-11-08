using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System.Collections.Generic;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._96
{
    public class MaintainExteriorMetalHeight : BaseClass
    {
        [Test]
        public void SheathingOffsetFromGrade()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Maintain Exterior Metal Height with Top of Wall Material when using Sheathing Offset from Grade");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectRoofHeightStyleMaterial("Top Of Wall Material");
            DefaultJobElement.ExteriorMetalHeightInputField("14");
            DefaultJobElement.ClickWainscot();
            DefaultJobElement.UncheckHasWainscotCheckbox();
            DefaultJobElement.ClickUpperSheathing();
            DefaultJobElement.UncheckHasUpperSheathingCheckbox();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallSheathing();

            if (!DefaultJobElement.GetSheathingOffsetFromGrade().Contains("0'"))
            {
                DefaultJobElement.EnterSheathingOffsetFromGrade("0'");
            }

            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            CheckTheExteriorLengthValueInTheSheathingDrawingOfEXT_1Wall();
            ExtentTestManager.TestSteps("Verify that the cut lengths match the 'Exterior Metal Height' value in the sheathing drawing table.");
            CheckTheExteriorLengthValueInTheJobReview();
            ExtentTestManager.TestSteps("Verify that the cut lengths match the 'Exterior Metal Height' value in the job review of sheathing table.");
            DefaultJobElement.EnterSheathingOffsetFromGrade("2'");
            DefaultJobElement.ClickSyncButton();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            CheckTheExteriorLengthValueInTheSheathingDrawingOfEXT_1Wall();
            ExtentTestManager.TestSteps("Verify that the cut length value is not changed in the sheathing drawing table after applying the sheathing offset from grade.");
            CheckTheExteriorLengthValueInTheJobReview();
            ExtentTestManager.TestSteps("Verify that the cut length value is not changed in the sheathing table of job review after applying the sheathing offset from grade.");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Maintain Exterior Metal Height with Top of Wall Material when using Sheathing Offset from Grade");
        }

        private static void CheckTheExteriorLengthValueInTheJobReview()
        {
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickSheathingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReviewAndDoubleClickOnTheMaterial("Sheathing", "ExteriorWall", null, null, null, null, null, null, "14'", null, null);

            IList<IWebElement> usageName = Driver.FindElements(By.XPath("//div[@id='w2ui-overlay']//td[text()='ExteriorWall']//following::td[6]"));
            int result = 0;

            foreach (IWebElement element in usageName)
            {
                if (element.Text.Contains("14'"))
                {
                    result++;
                }
            }

            Assert.AreEqual(usageName.Count, result, "Cut length values are changed");
        }

        private static void CheckTheExteriorLengthValueInTheSheathingDrawingOfEXT_1Wall()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickSheathingDrawingEXT_1();
            DefaultJobElement.CheckMaterialValueFromSheathingDrawingTable("ExteriorWall", null, null, null, "14'");
        }
    }
}
