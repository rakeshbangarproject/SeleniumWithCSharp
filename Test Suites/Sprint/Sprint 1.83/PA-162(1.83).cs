using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Resource;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Sprint_1._83
{
    [TestFixture, Category("Smoke_test")]
    public class VerifyCloning : BaseClass
    {
        [Test]
        public void Clone()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST(TestData.PA_162.extentReport);
            HomePage.NavigateToSetupWizardPages();
            CheckIfOldDataIsShownInTheTableThenDeleted();
            CloneAndModifyColor();
            VerifyDataShownInTheColorAndSheathingTables();
            VerifyCloneColorShownInTheDefaultJobColorTab();
            SetupWizard.ClickColors();
            SetupWizard.DeleteSetupWizardData(TestData.PA_162.colorName);
            SetupWizard.SaveDataInTheSetupWizard();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail(TestData.PA_162.subjectOfEmail);
        }

        #region private Methods  
        /// <summary>
        /// Clone and modify a material from the colors table.
        /// </summary>
        private void CloneAndModifyColor()
        {
            SetupWizard.ClickOnFirstElementThenClickOnCloneIcon();
            SetupWizard.ColorNameInputField(TestData.PA_162.colorName);
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ColorCodeInputField(TestData.PA_162.colorCode);
            SetupWizard.SelectHexCode(TestData.PA_162.hexCode);
            SetupWizard.ClickSaveButton();
        }

        /// <summary>
        /// Verify that the newly created color is shown in the Colors table.
        /// Also, check if the new color description is displayed in the Material of the Sheathing table.
        /// Save data in the setup wizard.
        /// </summary>
        private void VerifyDataShownInTheColorAndSheathingTables()
        {
            SetupWizard.CheckNewEntries(TestData.PA_162.colorName, "Verify the new Cloned color is applied to the Colors list", "Verify the new Cloned color is not applied to the Colors list");
            SetupWizard.ClickSheathing();
            ScrollDownAndVerifyColor();
            SetupWizard.SaveDataInTheSetupWizard();
        }

        /// <summary>
        /// Open the default job, click on the Colors menu tab, and verify that the newly created color is shown in the roof color dropdown.
        /// </summary>
        private void VerifyCloneColorShownInTheDefaultJobColorTab()
        {
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectRoofColor(TestData.PA_162.colorName);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickHomeButton();
            DefaultJobElement.ClickNoButton();
            HomePage.NavigateToSetupWizardPages();
        }

        /// <summary>
        /// Scrolls down the Color Code table after clicking on the first material in the sheathing table.
        /// Verifies that the newly created color description is shown in the Color Code table.
        /// </summary>
        private void ScrollDownAndVerifyColor()
        {
            string verificationMessage = SetupWizard.ScrollDownSubTableAndCheckMaterialDataIsShown().Contains("Test Clone Color")
                ? "Verify that the New Cloned Color has been applied automatically to the list of colors"
                : "Verify that the New Cloned Color has not been applied automatically to the list of colors";

            ExtentTestManager.TestSteps(verificationMessage);

            // Fail the test if the New Cloned Color has not been applied automatically
            if (verificationMessage.Contains("Verify that the New Cloned Color has not been applied automatically to the list of colors"))
            {
                Assert.Fail("Verification failed: New Cloned Color has not been applied automatically to the list of colors");
            }
        }

        /// <summary>
        /// Delete the data from colors table
        /// </summary>
        private void CheckIfOldDataIsShownInTheTableThenDeleted()
        {
            SetupWizard.ClickColors();
            SetupWizard.DeleteSetupWizardData(TestData.PA_162.colorName);

            if (SetupWizard.SaveAllButton().Enabled)
            {
                SetupWizard.SaveDataInTheSetupWizard();
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickColors();
            }
        }
    }
}
#endregion