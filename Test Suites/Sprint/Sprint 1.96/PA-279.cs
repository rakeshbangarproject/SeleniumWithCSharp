using System;
using System.Collections.Generic;
using System.IO;
using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Sprint.Sprint_1._96
{
    public class IsChildControlled : BaseClass
    {
        public readonly List<string> forParent = new();
        public readonly List<string> forChild = new();
        public string folderPath = FolderPath.Download();
        public bool result = false;

        [Test, Order(1)]
        public void CheckControlledFunctionality()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add new IsChildControlled builder setting");
            ExecuteScenario(ScenarioOne);
            ExecuteScenario(ScenarioTwo);
            ExecuteScenario(ScenarioThree);
            ExecuteScenario(ScenarioFour);
            ExecuteScenario(ScenarioFive);
            ExecuteScenario(ScenarioSix);
            ExecuteScenario(ScenarioSeven);
            ExecuteScenario(ScenarioEight);
            ExecuteScenario(ScenarioNine);
            result = true;
        }

        [Test, Order(2)]
        public void ResetFramingRulesData()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add new IsChildControlled builder setting");
            NavigateParentFramingRulesAndOpenDoEditFrame();
            DeleteDataFramingDOEditFrame();
            FramingRules.AddMaterialInDoEditFrame("3D Soffit Box");
            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("SubBuilder_AUTOTEST_PHTEST");
            Distributor.ClickOnTheDistributorElement("SubBuilder_AUTOTEST_PHTEST");
            CommonMethod.Wait(1);
            Distributor.ClickDeleteButtonAndYesButton();
            HomePage.NavigateToTheBuilderPage();
            Builder.DeleteBuilder("TestBuilder_AUTOTEST_PHTEST");

            if(!result)
            {
                HomePage.NavigateToSetupWizardPages();
                SetupWizard.ClickTrim();
                SetupWizard.ClickHomeIconButton();
                SetupWizard.HouseGridCheckboxUncheck("DoorHeaderTrim", "Bird Stop");
                SetupWizard.PushUsageChangesToBuilderInSetupWizard();
            }   
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Add new IsChildControlled builder setting");
        }

        #region Private Method
        private void ExecuteScenario(Action scenario)
        {
            scenario.Invoke();
        }

        private void DeleteDataFramingDOEditFrame()
        {
            string[] materialList = { "TestChildFramingRule", "TestParentFraming", "Z BAR", "6in FASCIA" };
            for (int index = 0; index < materialList.Length; index++)
            {
                try
                {
                    FramingRules.DeleteDataFromDoEditTable(materialList[index]);
                }
                catch (Exception)
                {
                    ExtentTestManager.TestSteps($"{materialList[index]} element is already deleted in the framing rules");
                }
            }

        }

        private void CheckExistingBuilderAreDeleting(string builderName)
        {
            try
            {
                Distributor.SearchInputField(builderName);
                CommonMethod.Wait(4);
                Driver.FindElement(By.XPath($"//tr[contains(@id,'grid_grid_rec_') and @line=1]//span[text()='{builderName}']//following::td[1]")).Click();
                CommonMethod.Wait(1);
                Distributor.ClickDeleteButtonAndYesButton();
            }
            catch (Exception)
            {
                Driver.Navigate().Refresh();
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            }
        }

        private void ScenarioOne()
        {
            ExtentTestManager.CreateTest("Scenario 1").Info("Check 'IsControlled' and 'CanFramingRules' checkbox functionality in the Builder page");
            HomePage.NavigateToDistributor();
            CommonMethod.Wait(2);
            CheckExistingBuilderAreDeleting("SubBuilder_AUTOTEST_PHTEST");
            CommonMethod.Wait(2);
            CheckExistingBuilderAreDeleting("TestBuilder_AUTOTEST_PHTEST");
            HomePage.NavigateToTheBuilderPage();
            CommonMethod.Wait(2);
            DownloadCSVFileAndCheckData();
            CreateNewBuilder();
            CheckIsControlledAndCanFramingRulesCheckboxesFunctionalityInBuilderPage();
        }

        private void ScenarioTwo()
        {
            ExtentTestManager.CreateTest("Scenario 2").Info("Verify if the user has unchecked the 'CanFramingRule' option in the child builder, the framing rules, and the setup wizard within the settings list.");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.VerifyBuilderAndEditButton("TestBuilder_AUTOTEST_PHTEST", "ParentDistributor");
            ExtentTestManager.TestSteps("Verify that when the 'IsControlled' checkbox is unchecked, the child builder appears on the framing rules edit page, along with the edit button.");
            CommonMethod.ChangeDistributorFunctionality("TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Login with child builder");
            VerifyElementVisibility(false);
        }

        private void ScenarioThree()
        {
            ExtentTestManager.CreateTest("Scenario 3").Info("Check if the user has unchecked the 'IsControlled' checkbox, then verify that the edit button appears in the framing rules");
            CommonMethod.ChangeDistributorFunctionality("AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Login with AUTOTEST_PHTEST distributor");
            HomePage.NavigateToTheBuilderPage();
            ToggleCheckbox("IsChildControlled", "Builder", "TestBuilder_AUTOTEST_PHTEST", true);
            ExtentTestManager.TestSteps("checked the 'IsControlled' checkbox");
            Distributor.ClickSaveButton();
            HomePage.NavigateToFramingRulesPages();
            FramingRules.VerifyBuilderAndEditButton("TestBuilder_AUTOTEST_PHTEST", "ChildDistributor");
            ExtentTestManager.TestSteps("Verify that when the 'IsControlled' checkbox is unchecked, the child builder appears on the framing rules edit page, but the edit button disappears, and 'Child-Controlled' is shown in place of the edit button.");
            CommonMethod.ChangeDistributorFunctionality("TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Login with child builder");
            VerifyElementVisibility(true);
            CommonMethod.ChangeDistributorFunctionality("AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Login with AUTOTEST_PHTEST distributor");
        }

        private void VerifyElementVisibility(bool listFromSetting)
        {
            HomePage.ClickSetting();

            if (listFromSetting)
            {
                HomePage.CheckElementShownInTheSettingsList("Setup Wizard");
                HomePage.CheckElementShownInTheSettingsList("Framing Rules");
                ExtentTestManager.TestSteps("Verify that Selecting 'CanFramingRule' option for the Builder, the setup wizard and framing rules are appear from the settings list.");
            }
            else
            {
                HomePage.CheckElementIsNotShownInTheSettingsList("Setup Wizard");
                HomePage.CheckElementIsNotShownInTheSettingsList("Framing Rules");
                ExtentTestManager.TestSteps("Verify that Selecting 'CanFramingRule' option for the Builder, the setup wizard and framing rules are disappear from the settings list.");
            }
        }

        /// <summary>
        /// This Method is used for the check the scenario four
        /// Navigate to the 'Distributor page and confirm that new builder is shown in the Distributor table
        /// User create new sub- builder using that builder and check IsControlled and CanFramingRules functionality
        /// </summary>
        private void ScenarioFour()
        {
            ExtentTestManager.CreateTest("Scenario 4").Info("Create new grandchild builder using child builder and check 'IsControlled' checkbox functionality'");
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Search Child builder in the distributor");
            Distributor.ClickOnTheDistributorElement("TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Click on the child builder from the distributor table");
            CommonMethod.Wait(1);
            CreateSubBuilder();
            Distributor.CheckElementShownInTheDistributorTable("SubBuilder_AUTOTEST_PHTEST");
            CheckTheIsControlledFunctionality("Distributor", "SubBuilder_AUTOTEST_PHTEST");
        }

        private void ScenarioFive()
        {
            ExtentTestManager.CreateTest("Scenario 5").Info("Check child and grandchild builder 'IsControlled' functionality working in the edit framing rules");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.VerifyBuilderAndEditButton("TestBuilder_AUTOTEST_PHTEST", "ChildDistributor");
            FramingRules.VerifyBuilderAndEditButton("SubBuilder_AUTOTEST_PHTEST", "ChildDistributor");
            ExtentTestManager.TestSteps("Verify that when both the child and grandchild builders of the ‘IsControlled’ checkbox are unchecked, 'Child-Controlled' is displayed instead of the edit button in the framing rules.");
            HomePage.NavigateToTheBuilderPage();
            ToggleCheckbox("IsChildControlled", "Builder", "TestBuilder_AUTOTEST_PHTEST", false);
            ExtentTestManager.TestSteps("Unchecked the 'IsControlled checkbox of child builder from the builder table");
            Distributor.ClickSaveButton();
            HomePage.NavigateToFramingRulesPages();
            FramingRules.VerifyBuilderAndEditButton("TestBuilder_AUTOTEST_PHTEST", "ChildDistributor");
            FramingRules.VerifyBuilderAndEditButton("SubBuilder_AUTOTEST_PHTEST", "ParentDistributor");
            ExtentTestManager.TestSteps("Verify that if the user unchecks the child builder 'IsControlled' checkbox, the edit button appears in the framing rules edit.");

            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("SubBuilder_AUTOTEST_PHTEST");
            ToggleCheckbox("IsChildControlled", "Distributor", "SubBuilder_AUTOTEST_PHTEST", false);
            Distributor.ClickSaveButton();
            HomePage.NavigateToTheBuilderPage();
            ToggleCheckbox("IsChildControlled", "Builder", "TestBuilder_AUTOTEST_PHTEST", false);
            Distributor.ClickSaveButton();
            HomePage.NavigateToFramingRulesPages();
            FramingRules.VerifyBuilderAndEditButton("TestBuilder_AUTOTEST_PHTEST", "ChildDistributor");
            FramingRules.VerifyBuilderAndEditButton("SubBuilder_AUTOTEST_PHTEST", "ParentDistributor");
            ExtentTestManager.TestSteps("Verify that if the user unchecks both the child and grandchild builders 'IsControlled' checkbox, the edit button appears in the framing rules edit.");
        }

        private void ScenarioSix()
        {
            ExtentTestManager.CreateTest("Scenario 6").Info("Check filter functionality working");
            OpenParentDistributorAndEditData("3D Soffit Box", "TestParentFraming", true);
            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();
            FramingRules.ApplyInputFieldFromFramingRuleEditPage("Walkdoor Trim - Header");

            // Parent framing data comparison
            PerformFramingDataComparison("AUTOTEST_PHTEST", "parent framing rules");
            // Child framing data comparison
            PerformFramingDataComparison("TestBuilder_AUTOTEST_PHTEST", "child framing rules");
            // Sub-child framing data comparison
            PerformFramingDataComparison("SubBuilder_AUTOTEST_PHTEST", "sub-child framing rules");
            ExtentTestManager.TestSteps("Verify both child and grandchild data are updated when framing rules are saved with the builder checkbox checked and 'IsControlled' unchecked.");

            forChild.Clear();
            forParent.Clear();
            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("SubBuilder_AUTOTEST_PHTEST");
            ToggleCheckbox("IsChildControlled", "Distributor", "SubBuilder_AUTOTEST_PHTEST", true);
            ExtentTestManager.TestSteps("Checked the 'IsControlled' checkbox of grandchild builder.");
            Distributor.ClickSaveButton();

            // For sub-child 'IsControlled' checkbox is checked and child checkbox is unchecked
            OpenParentDistributorAndEditData("TestParentFraming", "3D Soffit Box", true);
            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();

            // Controlled parent framing data comparison
            PerformFramingDataComparison("AUTOTEST_PHTEST", "parent framing rules");
            // Controlled child framing data comparison
            PerformFramingDataComparison("TestBuilder_AUTOTEST_PHTEST", "child framing rules");
            // Controlled sub-child framing data comparison
            CheckChildControlledBuilderData("SubBuilder_AUTOTEST_PHTEST", "child framing rules", "TestParentFraming");
            ExtentTestManager.TestSteps("Verify that child data is updated when saving framing rules with the builder checkbox checked, while grandchild data remains unchanged due to the 'IsControlled' checked.");

            HomePage.NavigateToTheBuilderPage();
            ToggleCheckbox("IsChildControlled", "Builder", "TestBuilder_AUTOTEST_PHTEST", true);
            Distributor.ClickSaveButton();
            HomePage.NavigateToFramingRulesPages();

            forChild.Clear();
            forParent.Clear();

            OpenParentDistributorAndEditData("3D Soffit Box", "TestChildFramingRule", true);
            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();

            // Controlled parent framing data comparison
            PerformFramingDataComparison("AUTOTEST_PHTEST", "parent framing rules");
            // Controlled child framing data comparison
            CheckChildControlledBuilderData("TestBuilder_AUTOTEST_PHTEST", "child framing rules", "3D Soffit Box ");
            CheckChildControlledBuilderData("SubBuilder_AUTOTEST_PHTEST", "grand child framing rules", "TestParentFraming");
            // Controlled sub-child framing data comparison
            ExtentTestManager.TestSteps("Verify that child and grandchild data are not updated when saving framing rules with the builder checkbox checked, while child and grandchild data remains unchanged due to the 'IsControlled' checkbox checked.");
        }

        private void ScenarioSeven()
        {
            ExtentTestManager.CreateTest("Scenario 7");

            forParent.Clear();

            HomePage.NavigateToDistributor();
            Distributor.SearchInputField("TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Search child builder in the distributor");
            ToggleCheckbox("IsChildControlled", "Distributor", "TestBuilder_AUTOTEST_PHTEST", false);
            ExtentTestManager.TestSteps("Unchecked child 'IsControlled' checkbox");
            Distributor.ClickSaveButton();
            Driver.Navigate().Refresh();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(Locator.CommonXPath.waitForSpinnerLoad)));
            CommonMethod.Wait(1);
            Distributor.SearchInputField("SubBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Search grandchild builder in the distributor");
            ToggleCheckbox("IsChildControlled", "Distributor", "SubBuilder_AUTOTEST_PHTEST", false);
            Distributor.ClickSaveButton();
            HomePage.NavigateToFramingRulesPages();
            OpenParentDistributorAndEditData("3D Soffit Box", "TestParentFraming", false);
            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();

            // Controlled parent framing data comparison
            PerformFramingDataComparison("AUTOTEST_PHTEST", "parent framing rules");

            var secondLastChild = forChild[1];
            var secondLastParent = forParent[1];

            if (!secondLastChild.ToString().Contains(secondLastParent.ToString()))
            {
                ExtentTestManager.TestSteps($"Error: If user set the material at top and save the changes in the framing rule but in the edit framing rule page entry shown bottom");
                Assert.Fail($"Error: If user set the material at top and save the changes in the framing rule but in the edit framing rule page entry shown bottom");
            }

            // Controlled child framing data comparison
            CheckChildControlledBuilderData("TestBuilder_AUTOTEST_PHTEST", "child framing rules", "Z BAR");
            // Controlled sub-child framing data comparison
            CheckChildControlledBuilderData("SubBuilder_AUTOTEST_PHTEST", "grandchild framing rules", "Z BAR");
            ExtentTestManager.TestSteps("Verify that if the parent, child, and grandchild materials are same, and the parent material element is set at the top, then the child and grandchild entries are shown at the bottom.");
        }

        private void ScenarioEight()
        {
            ExtentTestManager.CreateTest("Scenario 8").Info("Check material entries are same and material set to bottom");
            forParent.Clear();
            OpenParentDistributorAndEditData("Z BAR", "6in FASCIA", true);

            FramingRules.ClickSaveButtonOfDoEditField();
            ClickPencilIcon();
            FramingRules.ClickSaveButton();
            CommonMethod.Wait(1);

            // Controlled parent framing data comparison
            PerformFramingDataComparison("AUTOTEST_PHTEST", "parent framing rules");
            // Controlled child framing data comparison
            CheckChildControlledBuilderData("TestBuilder_AUTOTEST_PHTEST", "child framing rules", "6in FASCIA");
            // Controlled sub-child framing data comparison
            CheckChildControlledBuilderData("SubBuilder_AUTOTEST_PHTEST", "grandchild framing rules", "6in FASCIA");
            ExtentTestManager.TestSteps("Verify that if the parent, child, and grandchild materials are same, and the parent material element is set at the bottom, then the child and grandchild entries are shown at the bottom.");
        }

        private void ScenarioNine()
        {
            ExtentTestManager.CreateTest("Scenario 9").Info("Check material entries are same and material set to bottom");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.ClickHomeIconButton();
            SetupWizard.HouseGridCheckboxCheck("DoorHeaderTrim", "Bird Stop");
            SetupWizard.PushUsageChangesToBuilderInSetupWizard();
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.ClickHomeIconButton();
            SetupWizard.CheckCheckboxIsCheck("DoorHeaderTrim", "Bird Stop");
            ExtentTestManager.TestSteps("Verify that the checkbox of bird stop of walkdoor trim - header is checked after reopen the setup wizard");
            HomePage.NavigateToFramingRulesPages();

            Assert.True(CheckSettingHouseGridInFramingRules("AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            Assert.True(CheckSettingHouseGridInFramingRules("TestBuilder_AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            Assert.True(CheckSettingHouseGridInFramingRules("SubBuilder_AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            ExtentTestManager.TestSteps("Verify that after changes in the setup wizard the material is update in the framing rules");
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickTrim();
            SetupWizard.ClickHomeIconButton();
            SetupWizard.HouseGridCheckboxUncheck("DoorHeaderTrim", "Bird Stop");
            SetupWizard.PushUsageChangesToBuilderInSetupWizard();
            HomePage.NavigateToFramingRulesPages();

            Assert.False(CheckSettingHouseGridInFramingRules("AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            Assert.False(CheckSettingHouseGridInFramingRules("TestBuilder_AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            Assert.False(CheckSettingHouseGridInFramingRules("SubBuilder_AUTOTEST_PHTEST"), "Error: After changes in the setup wizard the material is not update in the framing rules");
            ExtentTestManager.TestSteps("Verify that after changes in the setup wizard the material is update in the framing rules");
        }

        private bool CheckSettingHouseGridInFramingRules(string distributorName)
        {
            forChild.Clear();
            CommonMethod.Wait(1);
            StoreFramingEditListData(distributorName);

            var forCount = forChild.Count - 1;

            var secondLastChild = forChild[forCount - 1];
            var secondLastParent = "Bird Stop";

            if (secondLastChild != null && secondLastChild.Contains(secondLastParent))
            {
                return true;
            }

            return false;
        }

        private void PerformFramingDataComparison(string distributorName, string framingType, bool isControlled = false)
        {
            forChild.Clear();
            CommonMethod.Wait(1);
            StoreFramingEditListData(distributorName);

            int countMaterial = 0;
            var forCount = forChild.Count - 1;

            for (int i = 0; i < forCount; i++)
            {
                if (forChild[i].ToString().Contains(forParent[i].ToString()))
                {
                    countMaterial++;
                }
            }

            if (!isControlled && countMaterial != forCount)
            {
                Assert.Fail($"Framing data do not match for {framingType}");
            }

            if (isControlled)
            {
                CompareSecondLastEntryForTheChildControlled(forCount, framingType);
            }
            else
            {
                CompareEntriesAreShownInTheCorrectPosition(forCount, framingType);
            }
        }

        private void CompareEntriesAreShownInTheCorrectPosition(int count, string framingType)
        {
            if (count >= 1)
            {
                var secondLastChild = forChild[count - 1];
                var secondLastParent = forParent[count - 1];

                if (secondLastChild.ToString().Contains(secondLastParent.ToString()))
                {
                    ExtentTestManager.TestSteps($"Verify that if the user changes the framing rules data for parent framing and unchecked the 'IsControlled' checkbox of child and sub-child, the updated data is shown on the framing edit page for the {framingType}.");
                }
                else
                {
                    Assert.Fail($"Error: The updated data is not shown on the framing edit page for the {framingType}.");
                }
            }
        }

        public static string GetFirstRowName(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();
                return firstLine;
            }
        }

        private void CompareSecondLastEntryForTheChildControlled(int count, string framingType)
        {
            if (count >= 1)
            {
                var secondLastChild = forChild[count - 1];
                var secondLastParent = forParent[count - 1];

                if (secondLastChild.ToString().Contains(secondLastParent.ToString()))
                {
                    ExtentTestManager.TestSteps($"Verify that if the user changes the framing rules data for parent framing and unchecked the 'IsControlled' checkbox of child and sub-child, the updated data is shown on the framing edit page for the {framingType}.");
                }
                else
                {
                    Assert.Fail($"Error: Parent updated framing rules data shown in the {framingType} controlled job");
                }
            }
        }

        private void CheckChildControlledBuilderData(string distributorName, string framingType, string elementName)
        {
            forChild.Clear();
            CommonMethod.Wait(1);
            StoreFramingEditListData(distributorName);
            CommonMethod.Wait(1);
            var forCount = forChild.Count - 1;

            if (forCount >= 1)
            {
                var secondLastChild = forChild[forCount - 1];
                var secondLastParent = elementName;

                if (!secondLastChild.ToString().Contains(secondLastParent.ToString()))
                {
                    Assert.Fail($"Error: Parent updated framing rules data shown in the {framingType} controlled job");
                }
                ExtentTestManager.TestSteps($"Verify that if the user changes the framing rules data for parent framing and unchecked the 'IsControlled' checkbox of child and sub-child, the updated data is shown on the framing edit page for the {framingType}.");
            }
        }

        private void OpenParentDistributorAndEditData(string deleteMaterial, string addMaterial, bool elementDelete)
        {
            NavigateParentFramingRulesAndOpenDoEditFrame();

            if (elementDelete)
            {
                FramingRules.DeleteDataFromDoEditTable(deleteMaterial);
                ExtentTestManager.TestSteps($"Delete {deleteMaterial} from the DoEditQuestion frame");
                FramingRules.AddMaterialInDoEditFrame(addMaterial);
                ExtentTestManager.TestSteps($"Add {addMaterial} in the DoEditQuestion frame");
            }
            else
            {
                FramingRules.AddMaterialInDoEditFrame("Z BAR");
                ExtentTestManager.TestSteps("Add Z BAR material from 'DoEditQuestion frame");
                CommonMethod.Wait(1);
                FramingRules.MoveElementAtTopInDoEditFrame("Z BAR");
                ExtentTestManager.TestSteps("Set Z BAR material at the top");
            }

            GetTheParentData();
        }

        private static void NavigateParentFramingRulesAndOpenDoEditFrame()
        {
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDoorAndWindow();
            CommonMethod.Wait(1);
            FramingRules.ClickDoEditButton("-- Walkdoor Trim --", "Header");
        }

        // This method is used for the check IsControlled and CanFramingRules functionality working or not
        private void CheckIsControlledAndCanFramingRulesCheckboxesFunctionalityInBuilderPage()
        {
            HomePage.NavigateToTheBuilderPage();
            CommonMethod.Wait(2);
            Builder.CheckBuilderShownInTheTable("TestBuilder_AUTOTEST_PHTEST");
            BothCheckboxesAreUnchecked("IsChildControlled", "CanEditFramingRules", "Builder", "TestBuilder_AUTOTEST_PHTEST");
            ExtentTestManager.TestSteps("Verify that after creating a new builder, both the 'IsChildControlled' and 'CanEditFramingRules' options are unchecked.");
            CommonMethod.Wait(2);
            CheckTheIsControlledFunctionality("Builder", "TestBuilder_AUTOTEST_PHTEST");
        }

        private void CreateNewBuilder()
        {
            Builder.AddNewBuilderAndCheckboxesAreUnchecked("TestBuilder_AUTOTEST_PHTEST", "CanEditFramingRules", "IsChildControlled");
        }

        private void CreateSubBuilder()
        {
            Builder.AddNewBuilderAndCheckboxesAreUnchecked("SubBuilder_AUTOTEST_PHTEST", "CanEditFramingRules", "IsChildControlled");
        }

        private void CheckTheIsControlledFunctionality(string tableName, string elementName)
        {
            BothCheckboxesAreUnchecked("IsChildControlled", "CanEditFramingRules", tableName, elementName);
            ExtentTestManager.TestSteps("Verify that the after newly created builder, both checkboxes 'IsControlled' and 'CanFramingRules' are unchecked");
            ToggleCheckbox("IsChildControlled", tableName, elementName, true);
            CommonMethod.Wait(2);
            Distributor.ClickSaveButton();
            BothCheckboxesAreChecked("IsChildControlled", "CanEditFramingRules", tableName, elementName);
            ExtentTestManager.TestSteps("Verify that the after checked the IsControlled checkbox, the 'CanFramingRules' checkbox is checked");
            ToggleCheckbox("IsChildControlled", tableName, elementName, false);
            CommonMethod.Wait(2);
            Distributor.ClickSaveButton();
            VerifyOneCheckboxIsCheckedAndSecondIsUnchecked("IsChildControlled", "CanEditFramingRules", tableName, elementName);
            ExtentTestManager.TestSteps("Verify that the after unchecked the IsControlled checkbox, the 'CanFramingRules' checkbox is checked");
            ToggleCheckbox("CanEditFramingRules", tableName, elementName, false);
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps("Unchecked the 'CanFramingRules' checkbox");
            Distributor.ClickSaveButton();
        }

        // Toggle checkbox by name, table, and element
        private void ToggleCheckbox(string checkboxName, string tableName, string elementName, bool check)
        {
            if (check)
            {
                Builder.CheckCheckbox(checkboxName, tableName, elementName);
                ExtentTestManager.TestSteps($"Checked the '{checkboxName}' checkbox");
            }
            else
            {
                Builder.UncheckCheckbox(checkboxName, tableName, elementName);
                ExtentTestManager.TestSteps($"Unchecked the '{checkboxName}' checkbox");
            }
        }

        // Verify whether a checkbox is checked or unchecked
        private void ConfirmCheckboxState(string checkboxName, string tableName, string elementName, bool shouldBeChecked)
        {
            string checkboxXpath = Builder.GetCheckboxXpathUsingColumnIndex(checkboxName, tableName, elementName);
            CommonMethod.Wait(1);
            IWebElement checkbox = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(checkboxXpath)));
            Assert.AreEqual(shouldBeChecked, checkbox.Selected, $"{checkboxName} checkbox status is incorrect.");
        }

        // This method is used for the check both the checkboxes are unchecked
        private void BothCheckboxesAreUnchecked(string firstCheckbox, string secondCheckbox, string tableName, string elementName)
        {
            ConfirmCheckboxState(firstCheckbox, tableName, elementName, false);
            ConfirmCheckboxState(secondCheckbox, tableName, elementName, false);
        }

        // This method is used for the check both the checkboxes are checked
        private void BothCheckboxesAreChecked(string firstCheckbox, string secondCheckbox, string tableName, string elementName)
        {
            ConfirmCheckboxState(firstCheckbox, tableName, elementName, true);
            ConfirmCheckboxState(secondCheckbox, tableName, elementName, true);
        }

        // This method is used for the check one checkbox is unchecked and second checkbox is checked
        private void VerifyOneCheckboxIsCheckedAndSecondIsUnchecked(string firstCheckbox, string secondCheckbox, string tableName, string elementName)
        {
            ConfirmCheckboxState(firstCheckbox, tableName, elementName, false);
            ConfirmCheckboxState(secondCheckbox, tableName, elementName, true);
        }

        private void StoreFramingEditListData(string distributorName)
        {
            CommonMethod.Wait(1);
            string table = Driver.FindElement(By.XPath($"//div[normalize-space()='{distributorName}']//following::td[2]")).Text;

            string[] multiArray = table.Split(new Char[] { '|' });

            foreach (string multi in multiArray)
            {
                forChild.Add(multi);
            }
        }

        private void DownloadCSVFileAndCheckData()
        {
            Builder.ClickOnTheDownloadButton();
            CheckIsControlledFieldIsShownInTheCSVFile();
        }

        private void CheckIsControlledFieldIsShownInTheCSVFile()
        {
            string downloadCSVFile = Path.Combine(folderPath, "DistributorList.csv");
            FolderPath.WaitForFileDownload(downloadCSVFile, 60);

            string getPath = GetFirstRowName(downloadCSVFile);

            if (!getPath.Contains("Is Child Controlled"))
            {
                Assert.Fail("In the CSV file Is Child Controlled is not appear");
            }

            ExtentTestManager.TestSteps("Verify that Is Child Controlled is shown in the csv file");
        }

        private void ClickPencilIcon()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[text()='-- Walkdoor Trim --']//following::div[text()='Header']//following::td[@col='7']//div[contains(@class,'w2ui-icon-pencil')])[1]"))).Click();
        }

        private void GetTheParentData()
        {
            IList<IWebElement> elements = Driver.FindElements(By.XPath("//tr[contains(@id,'grid_questionGrid_rec_') and @line]//div"));

            foreach (IWebElement element in elements)
            {
                string getElementName = element.Text;
                forParent.Add(getElementName);
            }
        }
    }
}
#endregion