using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;

namespace SmartBuildAutomation.Test_Suites.Framing_Rules
{
    [TestFixture, Category("Framing_Rules")]
    public class FramingRulesDetails : BaseClass
    {
        [Test]
        public void DetailsTab()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("PFS-3237");
            HomePage.NavigateToFramingRulesPages();
            FramingRules.OpenAUTOTEST__PHTEST_FramingRules();
            FramingRules.ClickDetails();
            Bays();
            Foundation();
            Slab();
            WallFraming();
            TrussCarrier();
            OpenWallTrussCarrier();
            WallGirtFraming();
            SkirtBoards();
            ExteriorStudFraming();
            InteriorStudFraming();
            RoofFraming();
            PurlinFraming();
            RafterFraming();
            CeilingFraming();
            FloorFraming();
            InteriorGirtFraming();
            RoofSheathing();
            WallSheathing();
            WallLiner();
            InteriorWalls();
            CeilingLiner();
            FloorSheathing();
            RoofTrim();
            FasciaAndSoffit();
            WallTrim();
            ExteriorCornerTrim();
            OpenWallTrim();
            LinerTrim();
            InteriorCornerTrim();
            CeilingTrim();
            TrimMargins();
            ExtraSheathingParts();
            ExtraTrimParts();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test on Framing Rules(Details)");
        }

        #region Private Method
        private void Bays()
        {
            string[] dropdownList = new string[2] { "Bay Spacing", "Bay Placement" };
            SelectDropdownAndCheckboxes("-- Bays --", dropdownList);

            string[] checkboxList = new string[4] { "Use Bay Spacing", "No Structural Doors", "Match Bay Spacing Purlins", "Match Bay Spacing Girts" };
            CheckTheCheckBoxes("-- Bays --", checkboxList);
        }

        private void Foundation()
        {
            string[] dropdownLists = new string[18] { "Type", "Fastener", "Base", "Uplift", "Eave Fastener", "Eave Base", "Eave Uplift", "Gable Base",
                "Gable Uplift", "Left Corner Fastener", "Left Corner Base", "Left Corner Uplift", "Right Corner Fastener", "Right Corner Base", "Right Corner Uplift", "Jamb Post Fastener",
                "Jamb Post Base", "Jamb Post Uplift" };
            SelectDropdownAndCheckboxes("-- Foundation --", dropdownLists);

            string[] inputFieldLists = new string[20] { "Depth", "Post Offset", "Width", "Footing Depth", "Footing Width", "Eave Depth", "Eave Post Offset", "Eave Width",
                "Gable Depth", "Gable Post Offset", "Gable Width", "Left Corner Depth", "Left Corner Post Offset", "Left Corner Width", "Right Corner Depth", "Right Corner Post Offset",
                "Right Corner Width", "Jamb Post Depth","Jamb Post Post Offset","Jamb Post Width" };
            EnterValuesAndCheckboxes("-- Foundation --", inputFieldLists);

            string[] checkboxList = new string[1] { "Advanced Post Hole Settings" };
            CheckTheCheckBoxes("-- Foundation --", checkboxList);
        }

        private void Slab()
        {
            string[] inputFieldLists = new string[3] { "Slab Depth", "Slab Offset", "ThickEdgeSlab Depth" };
            EnterValuesAndCheckboxes("-- Slab --", inputFieldLists);
        }

        private void WallFraming()
        {
            string[] dropdownLists = new string[15] { "Wall Framing", "Interior Wall Framing", "Gable Wall Style", "Post Material", "Gable Post Material", "Open Wall Post Material", "Top of Eave Post", "Eave Post Spacing",
                "Eave Post Placement", "Gable Post Spacing", "Gable Post Placement", "Shed Post Spacing", "Shed Post Placement", "Corner Post Placement", "Corner Post Material" };
            SelectDropdownAndCheckboxes("-- Wall Framing --", dropdownLists);

            FramingRules.EnterValueInTheInputField("-- Wall Framing --", "Post Margin");

            string[] checkboxList = new string[2] { "Uniform Gable Posts", "Keep Open Wall Gable Posts" };
            CheckTheCheckBoxes("-- Wall Framing --", checkboxList);
        }

        private void TrussCarrier()
        {
            string[] dropdownLists = new string[3] { "Truss Carrier Style", "Truss Carrier Material", "Top Girt Material" };
            SelectDropdownAndCheckboxes("-- Truss Carrier --", dropdownLists);

            string[] inputFieldLists = new string[2] { "Truss Carrier Length Overrides", "Top Girt Length Overrides" };
            EnterValuesAndCheckboxes("-- Truss Carrier --", inputFieldLists);

            string[] checkboxList = new string[1] { "Per Bay Sizing" };
            CheckTheCheckBoxes("-- Truss Carrier --", checkboxList);
        }

        private void OpenWallTrussCarrier()
        {
            string[] dropdownLists = new string[4] { "Truss Carrier Style", "Open Wall Truss Carrier Material", "Open Wall Carrier Bay Span", "Open Wall Top Girt Material" };
            SelectDropdownAndCheckboxes("-- Open Wall Truss Carrier --", dropdownLists);

            string[] inputFieldLists = new string[2] { "Open Wall Carrier Length Overrides", "Open Wall Top Girt Length Overrides" };
            EnterValuesAndCheckboxes("-- Open Wall Truss Carrier --", inputFieldLists);
        }

        private void WallGirtFraming()
        {
            string[] dropdownLists = new string[6] { "Girt Style", "Girt Material", "Girt Spacing", "Wainscot Girt", "Wainscot Girt Backer", "Girt Corner" };
            SelectDropdownAndCheckboxes("-- Wall Girt Framing --", dropdownLists);

            FramingRules.EnterValueInTheInputField("-- Wall Girt Framing --", "Girt Length Overrides");

            string[] checkboxList = new string[4] { "Offset Ply Posts", "Girt Space Evenly", "Stagger Girts", "Skip Girts Below Wainscot" };
            CheckTheCheckBoxes("-- Wall Girt Framing --", checkboxList);
        }

        private void SkirtBoards()
        {
            string[] dropdownLists = new string[3] { "Skirt Board Material", "Skirt Board Alignment", "Cut Skirt Board at Walk Doors" };
            SelectDropdownAndCheckboxes("-- Skirt Boards --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Skirt Board Length Overrides", "Rows of Skirt Boards", "Skirt Board Offset" };
            EnterValuesAndCheckboxes("-- Skirt Boards --", inputFieldLists);
        }

        private void ExteriorStudFraming()
        {
            string[] dropdownLists = new string[7] { "Stud Material", "Stud Spacing", "Top Plate", "Very Top Plate", "Bottom Plate", "Very Bottom Plate", "End Stud Placement" };
            SelectDropdownAndCheckboxes("-- Exterior Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Stud Length Overrides", "Top Plate Length Overrides", "Bottom Plate Length Overrides" };
            EnterValuesAndCheckboxes("-- Exterior Stud Framing --", inputFieldLists);
        }

        private void InteriorStudFraming()
        {
            string[] dropdownLists = new string[6] { "Interior Stud Material", "Interior Stud Spacing", "Interior Top Plate", "Interior Very Top Plate", "Interior Bottom Plate", "Interior Very Bottom Plate" };
            SelectDropdownAndCheckboxes("-- Interior Stud Framing --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Interior Stud Length Overrides", "Interior Top Plate Length Overrides", "Interior Bottom Plate Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Stud Framing --", inputFieldLists);
        }

        private void RoofFraming()
        {
            string[] dropdownLists = new string[14] { "Default Material", "Roof Framing Style", "Truss Special", "Truss Material", "Drop Front Gables w/ Flush Purlins", "Drop Back Gables w/ Flush Purlins", "Truss Spacing", "Truss Placement", "Overhang Style", "Truss Block Style", "Truss Block Material",
                "Eave Sub Fascia Material", "Gable Sub Fascia Material", "Gable Rake Material" };
            SelectDropdownAndCheckboxes("-- Roof Framing --", dropdownLists);

            string[] inputFieldLists = new string[7] { "Truss Heel Height", "Bottom Chord Pitch", "PCT depth", "Truss Block Length Overrides", "Eave Sub Fascia Length Overrides", "Gable Sub Fascia Length Overrides", "Gable Rake Length Overrides" };
            EnterValuesAndCheckboxes("-- Roof Framing --", inputFieldLists);

            string[] checkboxList = new string[5] { "Match Truss Heel Height", "Use Standard Trusses for Gables", "Front Gable Flat", "Back Gable Flat", "Double Truss" };
            CheckTheCheckBoxes("-- Roof Framing --", checkboxList);
        }

        private void PurlinFraming()
        {
            string[] dropdownLists = new string[11] { "Purlin Material", "Purlin Type", "Purlin Spacing", "Purlin Start", "Eave Purlin", "Flush Purlin Ledger", "Purlin Block Material", "Outrigger Material", "Gable Outrigger Material",
                "Gable Blocking Material", "Purlin Block Style" };
            SelectDropdownAndCheckboxes("-- Purlin Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Purlin Length Overrides", "Purlin Overlap Length", "Purlin Overlap Length", "Purlin Top Offset", "Purlin Block Length Overrides" };
            EnterValuesAndCheckboxes("-- Purlin Framing --", inputFieldLists);

            string[] checkboxList = new string[5] { "Purlin Space Evenly", "Overlap Purlins", "Stagger Purlins", "Force Overhang Purlin", "Extend Gable Blocking Through Overhang" };
            CheckTheCheckBoxes("-- Purlin Framing --", checkboxList);
        }

        private void RafterFraming()
        {
            string[] dropdownLists = new string[11] { "Rafter Material", "End Rafter Material", "Rafter Spacing", "Rafter Placement", "Seat Cut Type", "Hip Rafter", "Hip Rafter Plies",
                "Ridge Board", "Ridge Board Plies", "Roof Ledger Material", "Rafter Bond Plate Material" };
            SelectDropdownAndCheckboxes("-- Rafter Framing --", dropdownLists);

            string[] inputFieldLists = new string[7] { "Rafter Length Overrides", "End Rafter Length Overrides", "Rafter Height Above Plate", "Ridge Board Length Overrides", "Roof Ledger Length Overrides", "Roof Ledger Offset", "Rafter Bond Plate Length Overrides" };
            EnterValuesAndCheckboxes("-- Rafter Framing --", inputFieldLists);

            string[] checkboxList = new string[1] { "Double Rafter" };
            CheckTheCheckBoxes("-- Rafter Framing --", checkboxList);
        }

        private void CeilingFraming()
        {
            string[] dropdownLists = new string[8] { "Ceiling Joist Material", "Ceiling Joist Spacing", "Ceiling Joist Placement", "Ceiling Ledger Material", "Interior Purlin Material", "Interior Purlin Type",
                "Interior Purlin Spacing", "Interior Purlin Start" };
            SelectDropdownAndCheckboxes("-- Ceiling Framing --", dropdownLists);

            string[] inputFieldLists = new string[7] { "Ceiling Joist Length Overrides", "Ceiling Height Offset", "Ceiling Ledger Length Overrides", "Ceiling Ledger Length Overrides", "Ceiling Ledger Offset", "Interior Purlin Length Overrides", "Interior Overlap Length" };
            EnterValuesAndCheckboxes("-- Ceiling Framing --", inputFieldLists);

            string[] checkboxList = new string[4] { "Ceiling Joist Space Evenly", "Interior Purlin Space Evenly", "Overlap Interior Purlins", "Stagger Interior Purlins" };
            CheckTheCheckBoxes("-- Ceiling Framing --", checkboxList);
        }

        private void FloorFraming()
        {
            string[] dropdownLists = new string[6] { "Joist Material", "Joist Spacing", "Perpendicular Rim Joist Material", "Parallel Rim Joist Material", "Skid Material", "Skid Spacing" };
            SelectDropdownAndCheckboxes("-- Floor Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Joist Length Overrides", "Perpendicular Rim Joist Length Overrides", "Parallel Rim Joist Length Overrides", "Skid Offset", "Skid Length Overrides" };
            EnterValuesAndCheckboxes("-- Floor Framing --", inputFieldLists);

            string[] checkboxList = new string[2] { "Joists Space Evenly", "Skid Space Evenly" };
            CheckTheCheckBoxes("-- Floor Framing --", checkboxList);
        }

        private void InteriorGirtFraming()
        {
            string[] dropdownLists = new string[9] { "Interior Girt Style", "Interior Top Girt Material", "Interior Girt Material", "Interior Girt Spacing", "Interior Wainscot Girt", "Interior Wainscot Girt Backer", "Interior Skirt Board Material", "Interior Skirt Board Alignment", "Cut Int Skirt Board at Walk Doors" };
            SelectDropdownAndCheckboxes("-- Interior Girt Framing --", dropdownLists);

            string[] inputFieldLists = new string[5] { "Interior Top Girt Length Overrides", "Interior Girt Length Overrides", "Interior Skirt Board Length Overrides", "Rows of Interior Skirt Boards", "Interior Skirt Board Offset" };
            EnterValuesAndCheckboxes("-- Interior Girt Framing --", inputFieldLists);

            string[] checkboxList = new string[3] { "Interior Girt Space Evenly", "Stagger Interior Girts", "Skip Girts Below Wainscot" };
            CheckTheCheckBoxes("-- Interior Girt Framing --", checkboxList);
        }

        private void RoofSheathing()
        {
            string[] dropdownLists = new string[2] { "Roof Material", "Roof Start" };
            SelectDropdownAndCheckboxes("-- Roof Sheathing --", dropdownLists);

            string[] inputFieldLists = new string[6] { "Roof Margin", "Angled Roof Margin", "Roof Edge Margin", "Sheathing Length Overrides", "Roof Offset", "Min Sheathing Length" };
            EnterValuesAndCheckboxes("-- Roof Sheathing --", inputFieldLists);
        }

        private void WallSheathing()
        {
            string[] dropdownLists = new string[5] { "Wall Material", "Wainscot", "Upper Sheathing", "Eave Start", "Gable Start" };
            SelectDropdownAndCheckboxes("-- Wall Sheathing --", dropdownLists);

            string[] inputFieldLists = new string[14] { "Sheathing Offset From Grade", "Sheathing Length Overrides", "Eave Wall Margin", "Gable Wall Margin", "Corner Sheathing Margin", "Wainscot Margin", "Wainscot Sheathing Length Overrides", "Upper Sheathing Margin", "Upper Sheathing Length Overrides", "Eave Offset", "Gable Offset", "Min Sheathing Length", "Round Sheathing", "Round Angled Sheathing" };
            EnterValuesAndCheckboxes("-- Wall Sheathing --", inputFieldLists);
        }

        private void WallLiner()
        {
            string[] dropdownLists = new string[4] { "Liner Material", "Wainscot Liner Material", "Eave Liner Start", "Gable Liner Start" };
            SelectDropdownAndCheckboxes("-- Wall Liner --", dropdownLists);

            string[] inputFieldLists = new string[9] { "Sheathing Offset From Slab", "Sheathing Length Overrides", "Eave Liner Margin", "Gable Liner Margin", "Corner Sheathing Margin", "Wainscot Liner Margin", "Wainscot Sheathing Length Overrides", "Eave Liner Offset", "Gable Liner Offset" };
            EnterValuesAndCheckboxes("-- Wall Liner --", inputFieldLists);
        }

        private void InteriorWalls()
        {
            string[] dropdownLists = new string[2] { "Sheathing Side A", "Sheathing Side B" };
            SelectDropdownAndCheckboxes("-- Interior Walls --", dropdownLists);
        }

        private void CeilingLiner()
        {
            string[] dropdownLists = new string[2] { "Ceiling Material", "Ceiling Start" };
            SelectDropdownAndCheckboxes("-- Ceiling Liner --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Ceiling Margin", "Angled Ceiling Margin", "Ceiling Part Length Overrides", "Ceiling Offset" };
            EnterValuesAndCheckboxes("-- Ceiling Liner --", inputFieldLists);
        }

        private void FloorSheathing()
        {
            string[] dropdownLists = new string[2] { "Floor Sheathing", "Floor Sheathing Start" };
            SelectDropdownAndCheckboxes("-- Floor Sheathing --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Floor Sheathing Margin", "Floor Sheathing Part Length Overrides", "Floor Sheathing Offset" };
            EnterValuesAndCheckboxes("-- Floor Sheathing --", inputFieldLists);
        }

        private void RoofTrim()
        {
            string[] dropdownLists = new string[22] { "Ridge Cap", "Ridge Cap Color", "Hip Ridge Cap", "Hip Ridge Cap Color", "Valley Trim", "Valley Trim Color", "Gambrel Transition Trim", "Western Transition Trim", "Gambrel Transition Trim Color", "Western Transition Trim Color", "Eave Edge Trim", "Eave Edge Trim Color", "Gable Edge Trim", "Gable Edge Trim Color", "Angled Edge Trim", "Angled Edge Trim Color", "High Side Trim", "High Side Trim Color", "Gable Flashing", "Gable Flashing Color", "Shed Flashing", "Shed Flashing Color" };
            SelectDropdownAndCheckboxes("-- Roof Trim --", dropdownLists);

            string[] inputFieldLists = new string[10] { "Ridge Cap Length Overrides", "Hip Cap Length Overrides", "Valley Trim Length Overrides", "Gambrel Transition Trim Length Overrides", "Western Transition Trim Length Overrides", "Gable Edge Length Overrides", "Angled Edge Length Overrides", "High Side Trim Length Overrides", "Gable Flashing Length Overrides", "Shed Flashing Length Overrides" };
            EnterValuesAndCheckboxes("-- Roof Trim --", inputFieldLists);

            string[] checkboxList = new string[2] { "Hold Back Hip Cap", "Combine Angles" };
            CheckTheCheckBoxes("-- Roof Trim --", checkboxList);
        }

        private void FasciaAndSoffit()
        {
            string[] dropdownLists = new string[11] { "Eave Fascia Material", "Gable Fascia Material", "Eave Fascia Color", "Gable Fascia Color", "Soffit Style", "Eave Soffit Color", "Gable Soffit Color", "Eave Soffit Box", "Gable Soffit Box", "Eave Soffit Material", "Gable Soffit Material" };
            SelectDropdownAndCheckboxes("-- Fascia and Soffit --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Eave Fascia Length Overrides", "Gable Fascia Length Overrides", "Eave Soffit Margin", "Gable Soffit Margin" };
            EnterValuesAndCheckboxes("-- Fascia and Soffit --", inputFieldLists);
        }

        private void WallTrim()
        {
            string[] dropdownLists = new string[6] { "Base Trim", "Base Trim Color", "Top of Wall Trim", "Top of Wall Trim Color", "Wainscot Trim", "Wainscot Trim Color" };
            SelectDropdownAndCheckboxes("-- Wall Trim --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Base Trim Length Overrides", "Top of Wall Length Overrides", "Wainscot Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Wall Trim --", inputFieldLists);
        }

        private void ExteriorCornerTrim()
        {
            string[] dropdownLists = new string[8] { "Outside Corner", "Outside Corner Color", "Inside Corner", "Inside Corner Color", "Wainscot Outside Corner", "Wainscot Outside Corner Color", "Wainscot Inside Corner", "Wainscot Inside Corner Color" };
            SelectDropdownAndCheckboxes("-- Exterior Corner Trim --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Outside Corner Length Overrides", "Inside Corner Length Overrides", "Wainscot Outside Corner Length Overrides", "Wainscot Inside Corner Length Overrides" };
            EnterValuesAndCheckboxes("-- Exterior Corner Trim --", inputFieldLists);

            string[] checkboxList = new string[1] { "Cut Corner at Wainscot" };
            CheckTheCheckBoxes("-- Exterior Corner Trim --", checkboxList);
        }

        private void OpenWallTrim()
        {
            string[] dropdownLists = new string[7] { "Open Wall Measured From", "Open Wall Base Trim", "Open Wall Base Trim Color", "Open Top of Wall Trim", "Open Top of Wall Trim Color", "Interior Open Wall Base Trim", "Interior Open Base Trim Color" };
            SelectDropdownAndCheckboxes("-- Open Wall Trim --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Open Wall Offset", "Open Wall Base Trim Length Overrides", "Open Top of Wall Length Overrides", "Interior Open Base Length Overrides" };
            EnterValuesAndCheckboxes("-- Open Wall Trim --", inputFieldLists);

            string[] checkboxList = new string[1] { "Use Flat Gable Panel" };
            CheckTheCheckBoxes("-- Open Wall Trim --", checkboxList);
        }

        private void LinerTrim()
        {
            string[] dropdownLists = new string[4] { "Interior Base Trim", "Interior Base Trim Color", "Interior Wainscot Trim", "Interior Wainscot Trim Color" };
            SelectDropdownAndCheckboxes("-- Liner Trim --", dropdownLists);

            string[] inputFieldLists = new string[2] { "Interior Base Trim Length Overrides", "Interior Wainscot Trim Length Overrides" };
            EnterValuesAndCheckboxes("-- Liner Trim --", inputFieldLists);
        }

        private void InteriorCornerTrim()
        {
            string[] dropdownLists = new string[8] { "Interior Outside Corner", "Interior Outside Corner Color", "Interior Inside Corner", "Interior Inside Corner Color", "Interior Outside Wainscot Corner", "Interior Outside Wainscot Corner Color", "Interior Inside Wainscot Corner", "Interior Inside Wainscot Corner Color" };
            SelectDropdownAndCheckboxes("-- Interior Corner Trim --", dropdownLists);

            string[] inputFieldLists = new string[4] { "Interior Outside Corner Part Length Overrides", "Interior Inside Corner Part Length Overrides", "Interior Outside Wainscot Corner Part Length Overrides", "Interior Inside Wainscot Corner Part Length Overrides" };
            EnterValuesAndCheckboxes("-- Interior Corner Trim --", inputFieldLists);

            string[] checkboxList = new string[1] { "Cut Corner at Wainscot" };
            CheckTheCheckBoxes("-- Interior Corner Trim --", checkboxList);
        }

        private void CeilingTrim()
        {
            string[] dropdownLists = new string[6] { "Ceiling Pitch Break", "Ceiling Pitch Break Color", "Eave Ceiling/Wall", "Eave Ceiling/Wall Color", "Gable Ceiling/Wall", "Gable Ceiling/Wall Color" };
            SelectDropdownAndCheckboxes("-- Ceiling Trim --", dropdownLists);

            string[] inputFieldLists = new string[3] { "Ceiling Transition Length Overrides", "Eave Ceiling/Wall Length Overrides", "Gable Ceiling/Wall Length Overrides" };
            EnterValuesAndCheckboxes("-- Ceiling Trim --", inputFieldLists);
        }

        private void TrimMargins()
        {
            string[] inputFieldLists = new string[5] { "Gable Edge", "Angled Gable Edge", "Outside Corner", "Inside Corner", "Gable Fascia" };
            EnterValuesAndCheckboxes("-- Trim Margins --", inputFieldLists);
        }

        private void ExtraSheathingParts()
        {
            string[] inputFieldLists = new string[11] { "Roof", "Wall", "Wainscot", "Upper Sheathing", "Slider Wall", "Slider Wainscot", "Slider Upper Sheathing", "Soffit", "Ceiling", "Interior Wall", "Interior Wainscot" };
            EnterValuesAndCheckboxes("-- Extra Sheathing Parts --", inputFieldLists);
        }

        private void ExtraTrimParts()
        {
            string[] inputFieldLists = new string[36] { "Base", "Ceiling Transition", "Corner", "Door", "Door Jamb", "Eave Ceiling To Wall", "Eave Edge", "High Side Trim", "Fascia", "Gable Ceiling To Wall", "Gable Edge", "Gable Roof Wall", "Hip Cap", "Inside Corner", "Open-Wall Base", "Ridge Cap", "Roof Transition Trim", "Roof Wall", "Shed Roof to Wall", "Slider Panel", "Soffit", "Top of Wall", "Track Cover", "Sliding Door Track", "Valley Trim", "Wainscot", "Upper Sheathing", "Window", "Window Jamb", "Interior Base", "Interior Corner",
                "Interior Door", "Interior Open Base", "Interior Outside Corner", "Interior Wainscot", "Interior Window" };
            EnterValuesAndCheckboxes("-- Extra Trim Parts --", inputFieldLists);
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