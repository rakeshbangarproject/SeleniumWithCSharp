using Forms.Reporting;
using NUnit.Framework;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._86
{
    [TestFixture, Category("Sprint_1._86")]
    public class SwitchToOtherElement : BaseClass
    {

        [Test]
        public void DefaultHeight()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("When switch to Offset Down, default Height to 0");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickAttachedBuilding();
            CommonMethod.Wait(1);
            VerifyElementInAttachedBuilding("Attached Building");
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickCustom();
            VerifyElementInAttachedBuilding("Porch");
            DefaultJobElement.ClickCrossIcon();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of switch to Offset Down, default Height to 0 Script");
        }

        #region Private Method
        private void VerifyElementInAttachedBuilding(string name)
        {
            CommonMethod.Wait(1);
            DefaultJobElement.SelectHeightDropdownOpeningOption("Ceiling Height");
            CommonMethod.Wait(1);
            string heightCeilingHeight = DefaultJobElement.GetHeightInputFieldOpeningValue();
            Assert.That(heightCeilingHeight, Is.EqualTo("8'"), $"Verify that the height field is not changes to {heightCeilingHeight} when you select the 'Ceiling Height' from the Height dropdown of {name}");
            Console.WriteLine($"Verify that the height field changes to {heightCeilingHeight} when you select the 'Ceiling Height' from the Height dropdown of {name}");
            ExtentTestManager.TestSteps($"Verify that the height field changes to {heightCeilingHeight} when you select the 'Ceiling Height' from the Height dropdown of {name}");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Offset Down");
            CommonMethod.Wait(1);
            string heightOffsetDown = DefaultJobElement.GetHeightInputFieldOpeningValue();
            Assert.That(heightOffsetDown, Is.EqualTo("0'"), $"Verify that the height field is not changes to {heightOffsetDown} when you select the 'Offset Down' from the Height dropdown of {name}");
            Console.WriteLine($"Verify that the height field changes to {heightOffsetDown} when you select the 'Offset Down' from the Height dropdown of {name}");
            ExtentTestManager.TestSteps($"Verify that the height field changes to {heightOffsetDown} when you select the 'Offset Down' from the Height dropdown of {name}");
            DefaultJobElement.SelectHeightDropdownOpeningOption("Top of Wall Material");
            CommonMethod.Wait(1);
            string heightWallMaterial = DefaultJobElement.GetHeightInputFieldOpeningValue();
            Assert.That(heightWallMaterial, Is.EqualTo("8' 6\""), $"Verify that the height field is not changes to {heightWallMaterial} when you select the 'Top of Wall Material' from the Height dropdown of {name}");
            ExtentTestManager.TestSteps($"Verify that the height field changes to {heightWallMaterial} when you select the 'Top of Wall Material' from the Height dropdown of {name}");
            Console.WriteLine($"Verify that the height field changes to {heightWallMaterial} when you select the 'Top of Wall Material' from the Height dropdown of {name}");
        }
    }
}
#endregion