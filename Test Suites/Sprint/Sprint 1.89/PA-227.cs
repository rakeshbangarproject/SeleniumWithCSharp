using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace SmartBuildAutomation.Sprint_1._89
{
    [TestFixture, Category("Sprint_1._89")]
    public class CeilingProductSystem : BaseClass
    {
        readonly string captureScreenShot = FolderPath.StoreCaptureImage("ScreenShot of PA-227");

        [Test]
        public void Canvas2DView()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("2d Ceiling Product System not working");
            FolderPath.CreateFolder(captureScreenShot);
            CommonMethod.DeleteFolderFile(captureScreenShot);
            HomePage.ClicksStartFromScratch();
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickLoftsFromThe2DView();
            CreateNewLoftElement();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of 2d Ceiling Product System not working");
        }

        #region Private Method
        private void CreateNewLoftElement()
        {
            LoftTable("Sheathing Ceiling M1", -330, 250);
            LoftTable("Sheathing Ceiling M2", -340, -270);
            DefaultJobElement.SaveButtonOf2DView();
            ClickOnTheRoofTab();
        }

        private void LoftTable(string ceilingElement, int x_axis, int y_axis)
        {
            DefaultJobElement.ClickAddButtonOfLofts();
            DefaultJobElement.SelectCeilingProductSystemOfLoft("Ceiling Product System");
            DefaultJobElement.SelectCeilingMaterialOfLoft(ceilingElement);
            DefaultJobElement.CheckHasCeilingCheckboxOfLoft();
            DefaultJobElement.PlaceOpening(-x_axis, y_axis);
            DefaultJobElement.ClickCrossIcon();
        }

        private void ClickOnTheRoofTab()
        {
            DefaultJobElement.ClickRoofButton();
            DefaultJobElement.ChangeViewOfBuildingOf3DCanvas(0, -200);
            CaptureScreenShot("ApplyCeilingMaterialMainBuilding.png", "drawingArea");
            Console.WriteLine("Verify that the product systems are changed in the main building");
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickLOFT_1();
            DefaultJobElement.ChangeViewOfBuildingOf2DCanvas(0, -400);
            CaptureScreenShot("Loft_1.png", "drawing2d");
            VerifyCeilingProductSystem();
            DefaultJobElement.ClickLOFT_2();
            DefaultJobElement.ChangeViewOfBuildingOf2DCanvas(0, -400);
            CaptureScreenShot("Loft_2.png", "drawing2d");
            VerifyCeilingProductSystem();
            Console.WriteLine("Verify that the product systems are changed in the advanced edit");
        }

        private void CaptureScreenShot(string imageName, string elementID)
        {
            string imageXpath = "//canvas[@id='{0}']";
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format(imageXpath, elementID))));
            CommonMethod.Wait(2);

            Screenshot elementScreenshot = ((ITakesScreenshot)CommonMethod.element).GetScreenshot();
            string imagePath = $@"{captureScreenShot}\{imageName}";
            elementScreenshot.SaveAsFile(imagePath);
        }

        private void VerifyCeilingProductSystem()
        {
            DefaultJobElement.ClickProductSystem();
            DefaultJobElement.GetTheCeilingProductSystemValue();
            string ceilingProduct = DefaultJobElement.GetTheCeilingProductSystemValue();
            Assert.That(ceilingProduct, Is.EqualTo("Ceiling Product System"));
        }
    }
}
#endregion