using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._84
{
    [TestFixture, Category("Sprint_1_.84")]
    public class RoofFraming : BaseClass
    {

        [Test]
        public void RoofFramingMaterial()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Roof Framing Style");
            HomePage.ClicksStartFromScratch();
            VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheAttachedBuilding();
            VerifyRoofFramingNotChangedAfterRoofStyleChangeInThePorch();
            VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheLeanTo();
            VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheAwning();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Roof Framing Style Script");
        }

        #region Private Methods
        /// <summary>
        /// Verify that Roof framing element is not changed after roof style element changes.
        /// </summary>
        private void VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheAttachedBuilding()
        {
            DefaultJobElement.ClickAttachedBuilding();
            CommonMethod.Wait(3);
            VerifyRoofFramingConsistency("Rafters", new[] { "Shed", "Gable", "Gambrel" });
            VerifyRoofFramingConsistency("Trusses", new[] { "Shed", "Gable", "Gambrel" });

            Console.WriteLine("Attached Building Element:-");
            Console.WriteLine("For Rafters:");
            Console.WriteLine("Verify that the Roof Framing still shows as 'rafters' after changing the Roof Style dropdown");
            Console.WriteLine("For Trusses:");
            Console.WriteLine("Verify that the Roof Framing still shows as 'trusses' after changing the Roof Style and Gable Wall Style dropdown");

            DefaultJobElement.ClickCrossIcon();
        }

        private void VerifyRoofFramingConsistency(string framingOption, string[] roofStyles)
        {
            DefaultJobElement.SelectRoofFramingDropdownOpeningOption(framingOption);
            string expectedFraming = DefaultJobElement.GeTheRoofFramingOptionValue();
            DefaultJobElement.CheckAdvancedCheckboxOfOpening();

            foreach (var style in roofStyles)
            {
                DefaultJobElement.SelectRoofStyleOfOpeningOption(style);
                string actualFraming = DefaultJobElement.GeTheRoofFramingOptionValue();
                Assert.That(actualFraming, Is.EqualTo(expectedFraming));
                ExtentTestManager.TestSteps($"Verify that Roof Style still shows '{framingOption}' after selecting '{style}' from the Roof Style dropdown.");
            }
        }

        private void VerifyRoofFramingNotChangedAfterRoofStyleChangeInThePorch()
        {
            DefaultJobElement.ClickPorch();
            DefaultJobElement.ClickFrontLeft();
            CommonMethod.GetActions().Pause(TimeSpan.FromSeconds(1)).Perform();
            VerifyTrusses();
            DefaultJobElement.ClickCancel();
            Console.WriteLine("Porch Element For Trusses:-");
            Console.WriteLine("Verify that the Roof Framing still shows as 'trusses' after changing the 'gable wall style' dropdown");
        }

        private void VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheLeanTo()
        {
            DefaultJobElement.ClickLeanTo();
            DefaultJobElement.ClickFrontLeft();
            VerifyTrusses();
            DefaultJobElement.ClickCancel();
            Console.WriteLine("Lean-To Element For Trusses:-");
            Console.WriteLine("Verify that the Roof Framing still shows as 'trusses' after changing the 'gable wall style' dropdown");
        }

        private void VerifyRoofFramingNotChangedAfterRoofStyleChangeInTheAwning()
        {
            DefaultJobElement.ClickAwning();
            DefaultJobElement.ClickFrontLeft();
            VerifyTrusses();
            DefaultJobElement.ClickCancel();
            Console.WriteLine("Awning Element For Trusses:-");
            Console.WriteLine("Verify that the Roof Framing still shows as 'trusses' after changing the 'gable wall style' dropdown");
        }

        private void VerifyTrusses()
        {
            DefaultJobElement.SelectRoofFramingDropdownOpeningOption("Trusses");
            DefaultJobElement.CheckAdvancedCheckboxOfOpening();
            string trusses = DefaultJobElement.GeTheRoofFramingOptionValue();

            VerifyGableStyles(trusses);
        }

        private void VerifyGableStyles(string trusses)
        {
            string trussSpecial = DefaultJobElement.GetTheTrussSpecialValue();
            string trussMaterial = DefaultJobElement.GetTheTrussMaterialValue();
            string[] gableStyles =
            {
        "Balloon Framed",
        "Gable Truss",
        "Gable Truss(Short Post)",
        "Inset Gable",
        "Inset Gable (Short Post)"
    };

            foreach (string style in gableStyles)
            {
                DefaultJobElement.SelectGableWallsStyleDropdownOption(style);
                VerifyRoofFramingAfterGableWallStyleChange(trusses, trussSpecial, trussMaterial);
            }
        }

        private void VerifyRoofFramingAfterGableWallStyleChange(string trusses, string trussSpecial, string trussMaterial)
        {
            VerifyAttributeValue(Locator.DefaultJob.roofFramingDropdown, trusses);
            VerifyAttributeValue(Locator.DefaultJob.trussSpecialDropdown, trussSpecial);
            VerifyAttributeValue(Locator.DefaultJob.trussMaterialDropdown, trussMaterial);
        }

        private void VerifyAttributeValue(string xpath, string expectedValue)
        {
            IWebElement element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            string actualValue = element.GetAttribute("title");
            Assert.That(expectedValue, Is.EqualTo(actualValue));
            ExtentTestManager.TestSteps($"Verify that the attribute value is still '{expectedValue}' after the Gable Wall Style change");
        }
    }
}
#endregion