using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuildAutomation.Resource
{
    public class TestData
    {
        public class PA_162
        {
            public static string extentReport = "Verify Cloning for the Color";
            public static string subjectOfEmail = "Test Report of Verify Cloning for the Color Script";
            public static string colorName = "Red Roof Color";
            public static string colorCode = "Test Clone Color";
            public static string hexCode = "FFFD59";
        }

        public class PA_164
        {
            public static string extentReport = "Verify the Assembly Drawing";
        }

        public class Separator
        {
            public static string newSeparator = "//tr[contains(@id,'grid_formGrid_rec_')]//td[@col='0']//div";
            public static string searchElementFromJobTableOfPreview = "//div[@class='w2ui-page page-3']//div[@class='w2ui-group-title-separator']";
            public static string jobTableMenuLists = "//div[@class='w2ui-page page-5']//div[@class='w2ui-group-title-separator']";
        }
        public class RoofExtension
        {
            public static string exteriorWallValue = "(//div[text()='ExteriorWall']//following :: td[@col='6'])[1]";
        }








    }
}
