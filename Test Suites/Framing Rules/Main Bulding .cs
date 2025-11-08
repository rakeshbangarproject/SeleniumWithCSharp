using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildProject
{
    [TestFixture, Category("Framing_Rules")]
    class MainBuilding : BaseClass
    {
        [Test]
        public void MainBuildingSizeCheck()
        {
            ExtentTestManager.CreateTest("Smoke Test on Framing Rules(Main Building)");
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Smoke Test on Framing Rules(Main Building)");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            BuildingSize();
            RoofPeak();
            ProductSystem();
            Colors();
            Wainscot();
            UpperSheathing();
            CeilingLiner();
            WallLiner();
            Floor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test on Framing Rules(Main Building)");
        }

        #region Private method
        private void BuildingSize()
        {
            string[] dropdownList = new string[5] { "Building Size", "Measure From", "Roof Height Style", "Roof Style", "Overhangs" };
            SelectDropdownAndCheckboxes("-- Building Size --", dropdownList);

            string[] inputFieldLists = new string[5] { "Width", "Length", "Ceiling Height", "Exterior Metal Height", "Roof Pitch" };
            EnterValuesAndCheckboxes("-- Building Size --", inputFieldLists);
        }

        private void RoofPeak()
        {
            string[] dropdownList = new string[2] { "Front Peak", "Back Peak"};
            SelectDropdownAndCheckboxes("-- Roof Peak --", dropdownList);

            string[] inputFieldLists = new string[4] { "Front Peak Extension", "Front Peak Offset", "Back Peak Extension", "Back Peak Offset"};
            EnterValuesAndCheckboxes("-- Roof Peak --", inputFieldLists);
        }

        private void ProductSystem()
        {
            string[] dropdownList = new string[9] { "Main Product System", "Roof Product System", "Ceiling Product System", "Wall Product System", "Wainscot Product System", "Upper Wall Product System", "Wall Liner Product System", "Interior Wainscot Product System", "Overhang Product System" };
            SelectDropdownAndCheckboxes("-- Product Systems --", dropdownList);
        }

        private void Colors()
        {
            string[] dropdownList = new string[7] { "Roof Color", "Wall Color", "Trim Color", "Accent Color 1", "Accent Color 2", "Accent Color 3", "Accent Color 4"};
            SelectDropdownAndCheckboxes("-- Colors --", dropdownList);
        }

        private void Wainscot()
        {
            string[] checkbox = new string[1] { "Has Wainscot" };
            CheckTheCheckBoxes("-- Wainscot --", checkbox);

            string[] dropdownList = new string[1] { "Wainscot Color"};
            SelectDropdownAndCheckboxes("-- Wainscot --", dropdownList);

            string[] inputFieldLists = new string[1] { "Wainscot Height"};
            EnterValuesAndCheckboxes("-- Wainscot --", inputFieldLists);
        }

        private void UpperSheathing()
        {
            string[] checkbox = new string[1] { "Has Upper Sheathing" };
            CheckTheCheckBoxes("-- Upper Sheathing --", checkbox);

            string[] dropdownList = new string[1] { "Upper Sheathing Color" };
            SelectDropdownAndCheckboxes("-- Upper Sheathing --", dropdownList);

            string[] inputFieldLists = new string[1] { "Upper Sheathing Height" };
            EnterValuesAndCheckboxes("-- Upper Sheathing --", inputFieldLists);
        }

        private void CeilingLiner()
        {
            string[] checkbox = new string[2] { "Has Ceiling", "Flat Ceiling"};
            CheckTheCheckBoxes("-- Ceiling Liner --", checkbox);

            string[] dropdownList = new string[2] { "Ceiling Color" , "Ceiling Trim Color" };
            SelectDropdownAndCheckboxes("-- Ceiling Liner --", dropdownList);
        }

        private void WallLiner()
        {
            string[] checkbox = new string[2] { "Has Liner Panels", "Has Interior Wainscot" };
            CheckTheCheckBoxes("-- Wall Liner --", checkbox);

            string[] dropdownList = new string[3] { "Wall Liner Color", "Interior Trim Color", "Interior Wainscot Color" };
            SelectDropdownAndCheckboxes("-- Wall Liner --", dropdownList);

            string[] inputFieldLists = new string[1] { "Interior Wainscot Height" };
            EnterValuesAndCheckboxes("-- Wall Liner --", inputFieldLists);
        }

        private void Floor()
        {
            string[] checkbox = new string[1] { "Main Building Floor"};
            CheckTheCheckBoxes("-- Floor --", checkbox);

            string[] dropdownList = new string[1] { "Floor Color"};
            SelectDropdownAndCheckboxes("-- Floor --", dropdownList);
        }

        private void SelectDropdownAndCheckboxes(string section, string[] options)
        {
            foreach (string option in options)
            {
                FramingRules.SelectDropdownMaterials(section, option, "2");
                FramingRules.ChecksCheckboxes(section, option, 3);
                FramingRules.ChecksCheckboxes(section, option, 4);
                FramingRules.TableScrollDown("50");
            }
        }

        private void CheckTheCheckBoxes(string section, string[] options)
        {
            foreach (string option in options)
            {
                FramingRules.ChecksCheckboxes(section, option, 1);
                FramingRules.ChecksCheckboxes(section, option, 3);
                FramingRules.ChecksCheckboxes(section, option, 4);
                FramingRules.TableScrollDown("50");
            }
        }

        private void EnterValuesAndCheckboxes(string section, string[] inputFields)
        {
            foreach (string field in inputFields)
            {
                FramingRules.EnterValueInTheInputField(section, field);
                FramingRules.ChecksCheckboxes(section, field, 3);
                FramingRules.ChecksCheckboxes(section, field, 4);
                FramingRules.TableScrollDown("50");
            }
        }
    }
}
#endregion