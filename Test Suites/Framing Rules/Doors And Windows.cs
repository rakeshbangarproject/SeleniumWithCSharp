using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Framing_Rules
{
    [TestFixture, Category("Framing_Rules")]
    public class FramingRulesDoorAndWindow : BaseClass
    {
        [Test]
        public void DoorsAndWindowsMenuLists()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Door And Window");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDoorAndWindow();
            WalkdoorTrim();
            WalkdoorPostFraming();
            ExteriorWalkdoorStudFraming();
            InteriorWalkdoorStudFraming();
            OverheadDoorTrim();
            OverheadDoorPostFraming();
            ExteriorOverheadDoorStudFraming();
            InteriorOverheadDoorStudFraming();
            SlidingDoorTrim();
            SlidingDoorPostFraming();
            ExteriorSlidingDoorStudFraming();
            InteriorSlidingDoorStudFraming();
            SliderDoorPanelSheathing();
            SlidingDoorPanelTrim();
            SlidingDoorPanelFraming();
            WindowTrim();
            WindowPostFraming();
            ExteriorWindowStudFraming();
            InteriorWindowStudFraming();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test on Framing Rules(Details)");
        }
        #region Private Method
        private void WalkdoorTrim()
        {
            string[] dropdownLists = new string[12] { "Header", "Header Color", "Trimmer", "Trimmer Color", "Top Jamb", "Top Jamb Color", "Side Jamb",
                "Side Jamb Color", "Interior Header", "Interior Header Color", "Interior Trimmer", "Interior Trimmer Color" };
            SelectDropdownAndCheckboxes("-- Walkdoor Trim --", dropdownLists);

            string[] inputFieldLists = new string[6] { "Header Trim Length Overrides", "Trimmer Trim Length Overrides", "Top Jamb Trim Length Overrides", "Side Jamb Trim Length Overrides", "Interior Header Trim Length Overrides", "Interior Trimmer Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Walkdoor Trim --", inputFieldLists);
        }

        private void WalkdoorPostFraming()
        {
            string[] dropdownLists = new string[14] { "Jamb Type", "Jamb Post Material", "Jamb Post Plies", "Jamb Packing Material", "Jamb Packing Plies", "Girt Blocking", "Jamb Top", "Header Style",
                "Header Soffit Material", "Header Material", "Interior Header Material", "Header Filler Material", "Header boundaries","Header Plies" };
            SelectDropdownAndCheckboxes("-- Walkdoor Post Framing --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Jamb Post Part Length Overrides", "Jamb Packing Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Walkdoor Post Framing --", inputFieldLists);

            string[] checkboxList = new string[3] { "Use Jamb Post instead of Standard Post?", "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Walkdoor Post Framing --", checkboxList);
        }

         private void ExteriorWalkdoorStudFraming()
        {
            string[] dropdownLists = new string[13] { "Jamb Type", "King Stud Material", "Number of King Studs","Trimmer Material", "Number of Trimmers", "Trimmer Backing", "Header Style", "Header Soffit Material", "Header Soffit Material",
                "Header Material", "Interior Header Material", "Header Filler Material","Header Soffit Plies" };
            SelectDropdownAndCheckboxes("-- Exterior Walkdoor Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Jamb Post Part Length Overrides", "Jamb Packing Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Exterior Walkdoor Stud Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Exterior Walkdoor Stud Framing --", checkboxList);
        }
        

        private void InteriorWalkdoorStudFraming()
        {
            string[] dropdownLists = new string[15] { "Interior Jamb Type", "Interior King Stud Material", "Interior Number of King Studs", "Interior Trimmer Material", "Interior Number of Trimmers", "Interior Trimmer Backing", "Interior Header Style", "Interior Header Soffit Material",
                "Interior Header Material", "Interior Inside Header Material", "Interior Header Filler Material", "Interior Header Backing Material", "Interior Header Soffit Plies","Interior Cut Framing","Interior Cut Sheathing", };
            SelectDropdownAndCheckboxes("-- Interior Walkdoor Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Interior King Stud Part Length Overrides", "Interior Trimmer Part Length Overrides", "Interior Girt Blocking Part Length Overrides", "Interior Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Walkdoor Stud Framing --", inputFieldLists);
        }

        private void OverheadDoorTrim()
        {
            string[] dropdownLists = new string[12] { "Header", "Header Color", "Trimmer", "Trimmer Color", "Top Jamb", "Top Jamb Color", "Side Jamb",
                "Side Jamb Color", "Interior Header", "Interior Header Color", "Interior Trimmer", "Interior Trimmer Color"};
            SelectDropdownAndCheckboxes("-- Overhead Door Trim --", dropdownLists);

            string[] inputFieldLists = new string[6] { "Header Trim Length Overrides", "Trimmer Trim Length Overrides", "Top Jamb Trim Length Overrides", "Side Jamb Trim Length Overrides", "Interior Header Trim Length Overrides", "Interior Trimmer Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Overhead Door Trim --", inputFieldLists);
        }

        private void OverheadDoorPostFraming()
        {
            string[] dropdownLists = new string[19] { "Jamb Type", "Jamb Post Material", "Jamb Post Plies", "Jamb Packing Material", "Jamb Packing Plies", "Girt Blocking", "Jamb Top",
                "Header Style", "Header Soffit Material", "Header Material", "Interior Header Material", "Interior Header Material","Header Filler Material","Extra Header Material","Header High Material","Header High Style","Header High boundaries","Header boundaries","Header Plies"};
            SelectDropdownAndCheckboxes("-- Overhead Door Post Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Jamb Post Part Length Overrides", "Jamb Packing Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides", "Truss Carrier Length Overrides" };
            EnterValuesAndCheckboxes("-- Overhead Door Post Framing --", inputFieldLists);

            string[] checkboxList = new string[4] { "Use Jamb Post instead of Standard Post?", "Header High", "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Overhead Door Post Framing --", checkboxList);
        }

        private void ExteriorOverheadDoorStudFraming()
        {
            string[] dropdownLists = new string[13] { "Jamb Type", "King Stud Material", "Number of King Studs", "Trimmer Material", "Number of Trimmers", "Trimmer Backing", "Header Style",
                "Header Soffit Material", "Header Material", "Interior Header Material", "Header Filler Material", "Header Backing Material","Header Soffit Plies"};
            SelectDropdownAndCheckboxes("-- Exterior Overhead Door Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[4] { "King Stud Part Length Overrides", "Trimmer Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Exterior Overhead Door Stud Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Exterior Overhead Door Stud Framing --", checkboxList);
        }

        private void InteriorOverheadDoorStudFraming()
        {
            string[] dropdownLists = new string[16] { "Interior Jamb Type", "Interior King Stud Material", "Interior Number of King Studs", "Interior Trimmer Material", "Interior Number of Trimmers", "Interior Trimmer Backing", "Interior Header Style",
                "Interior Header Style", "Interior Header Soffit Material", "Interior Header Material", "Interior Inside Header Material","Interior Header Filler Material","Interior Header Backing Material","Interior Header Soffit Plies","Interior Cut Framing","Interior Cut Sheathing",};
            SelectDropdownAndCheckboxes("-- Interior Overhead Door Stud Framing --", dropdownLists);
            string[] inputFieldLists = new string[4] { "Interior King Stud Part Length Overrides", "Interior Trimmer Part Length Overrides", "Interior Girt Blocking Part Length Overrides", "Interior Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Overhead Door Stud Framing --", inputFieldLists);
        }

        private void SlidingDoorTrim()
        {
            string[] dropdownLists = new string[12] { "Header", "Header Color", "Trimmer", "Trimmer Color", "Top Jamb", "Top Jamb Color", "Side Jamb",
                "Side Jamb Color", "Interior Header", "Interior Header Color", "Interior Trimmer", "Interior Trimmer Color"};
            SelectDropdownAndCheckboxes("-- Sliding Door Trim --", dropdownLists);

            string[] inputFieldLists = new string[6] { "Header Trim Length Overrides", "Trimmer Trim Length Overrides", "Top Jamb Trim Length Overrides", "Side Jamb Trim Length Overrides", "Interior Header Trim Length Overrides", "Interior Trimmer Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Sliding Door Trim --", inputFieldLists);
        }

        private void SlidingDoorPostFraming()
        {
            string[] dropdownLists = new string[24] { "Jamb Type", "Jamb Post Material", "Jamb Post Plies", "Jamb Packing Material", "Jamb Packing Plies", "Girt Blocking","Jamb Top", "Header Style",
                "Header Soffit Material", "Header Material", "Interior Header Material", "Header Filler Material", "Extra Header Material","Header High Material","Extra Header Material","Header High Material","Header High Style","Header High boundaries","Header boundaries","Header Plies","Track Board","Track Board Support","Jamb Board","Rub Rail"};
            SelectDropdownAndCheckboxes("-- Sliding Door Post Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Lengths", "Jamb Post Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides", "Truss Carrier Length Overrides" };
            EnterValuesAndCheckboxes("-- Sliding Door Post Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Sliding Door Post Framing --", checkboxList);
        }

        private void ExteriorSlidingDoorStudFraming()
        {
            string[] dropdownLists = new string[18] { "Jamb Type", "King Stud Material", "Number of King Studs", "Trimmer Material", "Number of Trimmers", "Trimmer Backing", "Header Style",
                "Header Soffit Material", "Header Material", "Interior Header Material", "Header Filler Material", "Header Backing Material","Header Filler Material","Header Soffit Plies","Track Board","Track Board Support","Jamb Board","Rub Rail"};
            SelectDropdownAndCheckboxes("-- Exterior Sliding Door Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[6] { "Track Board Length Overrides", "Rub Rail Length Overrides", "Jamb Board Part Length Overrides", "Trimmer Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Exterior Sliding Door Stud Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Exterior Sliding Door Stud Framing --", checkboxList);
        }

        private void InteriorSlidingDoorStudFraming()
        {
            string[] dropdownLists = new string[20] { "Interior Jamb Type", "Interior King Stud Material", "Interior Number of King Studs", "Interior Trimmer Material", "Interior Number of Trimmers", "Interior Trimmer Backing", "Interior Header Style",
                "Interior Header Style", "Interior Header Soffit Material", "Interior Header Material", "Interior Inside Header Material","Interior Header Filler Material","Interior Header Backing Material","Interior Header Soffit Plies","Interior Cut Framing","Interior Cut Sheathing","Interior Track Board","Interior Track Board Support",
            "Interior Jamb Board","Interior Rub Rail"};
            SelectDropdownAndCheckboxes("-- Interior Sliding Door Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[8] { "Interior Track Board Length Overrides", "Interior Track Board Support Length Overrides", "Interior Rub Rail Length Overrides","Interior King Stud Part Length Overrides", "Interior Jamb Board Part Length Overrides", "Interior Trimmer Part Length Overrides", "Interior Girt Blocking Part Length Overrides", "Interior Header Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Sliding Door Stud Framing --", inputFieldLists);
        }

        private void SliderDoorPanelSheathing()
        {
            string[] dropdownLists = new string[2] { "Slider Wainscot", "Slider Panel Color" };
            SelectDropdownAndCheckboxes("-- Slider Door Panel Sheathing --", dropdownLists);
        }

        private void SlidingDoorPanelTrim()
        {
            string[] dropdownLists = new string[12] { "Top Trim", "Top Trim Color", "Bottom Trim", "Bottom Trim Color", "Outside Trim", "Outside Trim Color", "Inside Right Trim",
                "Inside Right Trim Color", "Side Margin Affects", "Track Cover", "Sliding Door Track","Sliding Door Track Color"};
            SelectDropdownAndCheckboxes("-- Sliding Door Panel Trim --", dropdownLists);

            string[] inputFieldLists = new string[9] { "Top Trim Length Overrides", "Bottom Trim Trim Length Overrides", "Outside Trim Length Overrides", "Inside Right Trim Length Overrides", "Slider Side Margin", "Slider Top Margin", "Slider Bottom Margin", "Track Cover Trim Length Overrides", "Sliding Door Track Length Overrides" };
            EnterValuesAndCheckboxes("-- Sliding Door Panel Trim --", inputFieldLists);
        }

        private void SlidingDoorPanelFraming()
        {

            string[] dropdownLists = new string[7] { "Top Rail", "Bottom Rail", "Outside Vertical", "Right Inside Vertical", "Girts", "Girt Style", "Girt Spacing" };
            SelectDropdownAndCheckboxes("-- Sliding Door Panel Framing --", dropdownLists);

            string[] checkboxList = new string[2] { "Girt Space Evenly", "Skip Girts Below Wainscot" };
            CheckTheCheckBoxes("-- Sliding Door Panel Framing --", checkboxList);
        }

        private void WindowTrim()
        {
            string[] dropdownLists = new string[18] { "Header", "Header Color", "Trimmer", "Trimmer Color", "Sill", "Sill Color", "Top Jamb",
                "Top Jamb Color", "Side Jamb", "Side Jamb Color", "Bottom Jamb", "Bottom Jamb Color","Interior Header","Interior Header Color","Interior Trimmer","Interior Trimmer Color","Interior Sill","Interior Sill Color"};
            SelectDropdownAndCheckboxes("-- Window Trim --", dropdownLists);

            string[] inputFieldLists = new string[9] { "Header Trim Length Overrides", "Trimmer Trim Length Overrides", "Sill Trim Length Overrides", "Top Jamb Trim Length Overrides", "Side Jamb Trim Length Overrides", "Bottom Jamb Trim Length Overrides", "Interior Header Trim Length Overrides", "Interior Trimmer Trim Length Overrides", "Interior Sill Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Window Trim --", inputFieldLists);
        }

        private void WindowPostFraming()
        {
            string[] dropdownLists = new string[21] { "Jamb Type", "Jamb Post Material", "Jamb Post Plies", "Jamb Packing Material", "Girt Blocking", "Jamb Top", "Jamb Bottom",
                "Header Style", "Header Soffit Material", "Header Material", "Interior Header Material","Header Filler Material", "Header boundaries","Header Plies","Sill Style","Sill Horizontal Material","Sill Vertical Material","Interior Sill Material","Sill Filler Material","Extra Sill Material","Sill boundaries"};
            SelectDropdownAndCheckboxes("-- Window Post Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Jamb Post Part Length Overrides", "Jamb Packing Part Length Overrides", "Girt Blocking Part Length Overrides", "Header Part Length Overrides", "Sill Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Window Post Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Window Post Framing --", checkboxList);
        }

        private void ExteriorWindowStudFraming()
        {
            string[] dropdownLists = new string[19] { "Jamb Type", "King Stud Material", "Number of King Studs", "Trimmer Material", "Number of Trimmers", "Trimmer Backing",
                "Header Style", "Header Soffit Material", "Header Material", "Interior Header Material","Header Filler Material","Header Backing Material", "Header Soffit Plies","Sill Style","Sill Horizontal Material","Sill Vertical Material","Sill Filler Material","Extra Sill Material","Sill Plies"};
            SelectDropdownAndCheckboxes("-- Exterior Window Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "King Stud Part Length Overrides", "Trimmer Part Length Overrides", "Girt Backing Part Length Overrides", "Header Part Length Overrides", "Sill Part Length Overrides"};
            EnterValuesAndCheckboxes("-- Exterior Window Stud Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Cut Framing", "Cut Sheathing" };
            CheckTheCheckBoxes("-- Exterior Window Stud Framing --", checkboxList);
        }

        private void InteriorWindowStudFraming()
        {
            string[] dropdownLists = new string[23] { "Interior Jamb Type", "Interior King Stud Material", "Interior Number of King Studs", "Interior Trimmer Material", "Interior Number of Trimmers", "Interior Trimmer Backing",
                "Interior Header Style", "Interior Header Soffit Material", "Interior Header Material", "Interior Inside Header Material","Interior Header Filler Material","Interior Header Backing Material", "Interior Header Soffit Plies","Interior Sill Style","Interior Sill Soffit Material","Interior Sill Material","Interior Inside Sill Material","Interior Inside Sill Material","Interior Sill Filler Material"
                ,"Interior Sill Backing Material","Interior Sill Soffit Plies","Interior Cut Framing","Interior Cut Sheathing"};
            SelectDropdownAndCheckboxes("-- Interior Window Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Interior King Stud Part Length Overrides", "Interior Trimmer Part Length Overrides", "Interior Girt Blocking Part Length Overrides", "Interior Header Part Length Overrides", "Interior Sill Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Window Stud Framing --", inputFieldLists);

        }

        private void SelectDropdownAndCheckboxes(string section, string[] options)
        {
            foreach (string option in options)
            {
                FramingRules.SelectDropdownMaterials(section, option, "2");
                FramingRules.ChecksCheckboxes(section, option, 3);
                FramingRules.ChecksCheckboxes(section, option, 4);
                FramingRules.TableScrollDown("20");
            }
        }

        private void CheckTheCheckBoxes(string section, string[] options)
        {
            foreach (string option in options)
            {
                FramingRules.ChecksCheckboxes(section, option, 1);
                FramingRules.ChecksCheckboxes(section, option, 3);
                FramingRules.ChecksCheckboxes(section, option, 4);
                FramingRules.TableScrollDown("20");
            }
        }

        private void EnterValuesAndCheckboxes(string section, string[] inputFields)
        {
            foreach (string field in inputFields)
            {
                FramingRules.EnterValueInTheInputField(section, field);
                FramingRules.ChecksCheckboxes(section, field, 3);
                FramingRules.ChecksCheckboxes(section, field, 4);
                FramingRules.TableScrollDown("20");
            }
        }
    }
}
#endregion