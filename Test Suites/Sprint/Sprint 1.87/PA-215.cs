using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._87
{
    [TestFixture, Category("Sprint_1._87")]
    public class SoffitAndFascia : BaseClass
    {
        public static string pathFile = FolderPath.StoreCaptureImage("ScreenShot of PA-215");

        [Test]
        public void SelectColors()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Add the Soffit and Fascia colors selectors to the Main Building job tab Colors drop down");
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickBuildingSize();
            DefaultJobElement.SelectOverhangMaterial("2'");
            DefaultJobElement.ClickColors();
            DefaultJobElement.SelectAccentColor3("BRIGHT RED");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.SelectAccentColor4("BRIGHT WHITE");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDetails();
            FasciaAndSoffitTab();
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            VerifyColors();
            CheckTheColorIsApplyOnCanvasBuilding("Soffit And Fascia Colors", 0, -150);
            Console.WriteLine("Verify that the selected colors are shown for facias and soffits on the eave wall and gable wall.");
            ExtentTestManager.TestSteps("Verify that the selected colors are shown for facias and soffits on the eave wall and gable wall.");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Add the Soffit and Fascia colors selectors to the Main Building job tab Colors drop down");
        }

        #region Private Method
        private void FasciaAndSoffitTab()
        {
            DefaultJobElement.ClickFasciaAndSoffit();
            CommonMethod.Wait(1);
            DefaultSoffitColor("Accent Color 3", "Accent Color 4");
        }

        private void DefaultSoffitColor(string accentColor3, string accentColor4)
        {
            DefaultJobElement.SelectEaveFasciaColor(accentColor3);
            DefaultJobElement.SelectGableFasciaMaterial("J Hagerman Eave Trim");
            CommonMethod.Wait(1);
            DefaultJobElement.SelectGableFasciaColor(accentColor4);
            DefaultJobElement.SelectSoffitStyle("Panels");
            DefaultJobElement.SelectEaveSoffitMaterial("29ga 9/38 Tuff Rib");
            CommonMethod.Wait(1);
            DefaultJobElement.SelectEaveSoffitColor(accentColor3);
            DefaultJobElement.SelectGableSoffitMaterial("Single Shingle");
            DefaultJobElement.SelectGableSoffitColor(accentColor4);
        }

        private void VerifyColors()
        {
            string gableSoffitColor = DefaultJobElement.GetGableSoffitColorValue();
            string gableFasciaColor = DefaultJobElement.GetGableFasciaColorValue();
            string eaveSoffitColor = DefaultJobElement.GetEaveSoffitColorValue();
            string eaveFasciaColor = DefaultJobElement.GetEaveFasciaColorValue();
            // Assert for eaveSoffitColor and eaveFasciaColor
            Assert.That("Accent Color 3", Is.EqualTo(eaveSoffitColor));
            Assert.That("Accent Color 3", Is.EqualTo(eaveFasciaColor));

            // Assert for gableSoffitColor and gableFasciaColor
            Assert.That("Accent Color 4", Is.EqualTo(gableSoffitColor));
            Assert.That("Accent Color 4", Is.EqualTo(gableFasciaColor));
        }

        private void CheckTheColorIsApplyOnCanvasBuilding(string imageName, int x_axes, int y_axes)
        {
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.DefaultJob.Canvas3DBuilding)));
            CommonMethod.GetActions().ClickAndHold(CommonMethod.element).MoveByOffset(x_axes, y_axes).Release().Perform();
            DefaultJobElement.CaptureScreenShot($"{pathFile}", $"{imageName}.png");
        }
    }
}
#endregion