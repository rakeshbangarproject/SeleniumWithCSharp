using Forms.Reporting;
using MongoDB.Bson.Serialization.Conventions;
using NUnit.Framework;
using OpenQA.Selenium;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Pages1;
using SmartBuildAutomation.Resource;
using SmartBuildProductionAutomation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SmartBuildAutomation.Test_Suites.Smoke_Test.DetailsMenu
{
    public class WallFramingFunctionality : BaseClass
    {
        private static readonly string DownloadFolderPath = FolderPath.Download();
        public string[] elementNameOfSheathingDrawing = { "EXT_1", "EXT_2", "EXT_3", "EXT_4" };
        public string[] gableWallMaterial = { "EXT_2", "EXT_4" };


        [Test]
        public void SubMenuOfWallFraming()
        {
            CommonMethod.LoginApplicationAndSetDistributorToAUTOTEST_PHTEST("Smoke test on the Main Building Sub-Menu Functionality");
            CreateAndDeleteFolder(DownloadFolderPath);
            HomePage.ClicksStartFromScratch();
            string interiorWallFraming = CheckWallFramingSubMenuElements();
            CheckInteriorWallFraming(interiorWallFraming);
            CheckPostMaterial();
            CheckGablePostMaterial();
            OpenWallPostMaterial();
            CheckKeepOpenWallGablePostsCheckbox();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test");
        }

        private string CheckWallFramingSubMenuElements()
        {
            DefaultJobElement.ServerDelay();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectWallFramingDropdown("Stud Frame");
            DefaultJobElement.ClickExteriorStudFraming();
            string studMaterial = DefaultJobElement.GetStudMaterialValue();
            ClickSyncButtonWaitForCanvasLoad();

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "Stud", null, studMaterial, null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the stud frame is applied on the canvas building and shown in the framing table's job review.");
            DefaultJobElement.ClickDrawingButton();
            CheckWallMaterialInTheDrawing("Stud", studMaterial);
            ExtentTestManager.TestSteps($"Verify that the stud frame is applied on the canvas building and shown in the exterior wall of sheathing drawing");

            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectWallFramingDropdown("Post Frame");
            string postMaterial = DefaultJobElement.GetPostMaterial();
            ClickSyncButtonWaitForCanvas2DLoad();
            CheckWallMaterialInTheDrawing("Post", postMaterial);

            ExtentTestManager.TestSteps($"Verify that the post frame is applied on the canvas building and shown in the exterior wall of sheathing drawing");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "Post", null, postMaterial, null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the post frame is applied on the canvas building and shown in the framing table's job review.");
            return DefaultJobElement.GetInteriorWallFramingValue();
        }

        private void CheckInteriorWallFraming(string interiorWallFraming)
        {
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickInteriorWallsFromThe2DView();
            DefaultJobElement.ClickAddRoom();
            DefaultJobElement.EnterLengthInputFieldOfInteriorWall("30");
            DefaultJobElement.EnterWidthInputFieldOfInteriorWall("40");

            string wallFramingOf2D = DefaultJobElement.GetWallFramingValueOfInteriorWall2DView();
            Assert.That(interiorWallFraming, Is.EqualTo(wallFramingOf2D), "Verify that interior wall framing of canvas 3D and wall framing of 2D are not match ");
            string interiorStudMaterial = DefaultJobElement.GetInteriorStudMaterialOfInteriorWallOf2DView();

            DefaultJobElement.PlaceOpening(270, 270);
            DefaultJobElement.SaveButtonOf2DView();
            DefaultJobElement.ClickDrawingButton();
            ClickSheathingDrawingElement("INT_1");
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("Stud", null, interiorStudMaterial, null, null);
            ExtentTestManager.TestSteps($"Verify that the interior wall is attached to the canvas building and the interior wall material as shown in the drawing.");

            CheckInteriorWallFramingInTheAdvancedEdit();
        }

        private void CheckInteriorWallFramingInTheAdvancedEdit()
        {
            DefaultJobElement.ClickAdvancedEdit();
            DefaultJobElement.ClickINT_1();
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectInteriorWallFramingDropdownInTheAdvancedEdit("Post Frame");
            string postMaterial = DefaultJobElement.GetPostMaterial();

            ClickSyncButtonWaitForCanvas2DLoad();
            DefaultJobElement.ClickDrawingButton();
            ClickSheathingDrawingElement("INT_1");
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("Post", null, postMaterial, null, null);
            ExtentTestManager.TestSteps($"Verify that the post is attached to the interior wall of the building after updating the interior wall framing from stud to a post frame in the advanced edit.");
            DefaultJobElement.ClickEdit2DView();
            DefaultJobElement.ClickInteriorWallsFromThe2DView();
            DefaultJobElement.ClickInteriorWallElementsInThe2DView("INT-1");
            string wallFraming = DefaultJobElement.GetWallFramingValueOfInteriorWall2DView();

            Assert.That(wallFraming, Is.EqualTo("Post Frame"), "Error: The wall framing material is not updated After interior wall framing material is change in the advanced edit");
            ExtentTestManager.TestSteps($"Verify that the The wall framing material is not updated After interior wall framing material is change in the advanced edit");
            DefaultJobElement.ClickCrossIcon();
            DefaultJobElement.ClickReturnButton();
        }

        private void CheckPostMaterial()
        {
            DefaultJobElement.ClickDetails();
            DefaultJobElement.ClickWallFraming();
            DefaultJobElement.SelectPostMaterialDropdown("None");
            ClickSyncButtonWaitForCanvasLoad();

            DefaultJobElement.ClickJobReview();
            DefaultJobElement.ClickFramingOfJobReview();
            DefaultJobElement.CheckMaterialIsNotShownInTheJobReview("Post");
            ExtentTestManager.TestSteps($"Verify that the post materials are not shown in the job review of framing table if user select none from post frame");

            DefaultJobElement.ClickDrawingButton();
            CheckPostMaterialIsNotShownInTheDrawing();
            DefaultJobElement.SelectPostMaterialDropdown("5Ply2x8");
            DefaultJobElement.SelectPostMaterialDropdown("2x4RL");
            ClickSyncButtonWaitForCanvas2DLoad();
            CheckWallMaterialInTheDrawing("Post", "2x4RL");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "Post", null, "2x4RL", null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the post frame is updated in the job review after changing the post material in the wall framing.");
        }

        private void CheckGablePostMaterial()
        {
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.SelectGablePostMaterial("4x6 Treated Post");
            ClickSyncButtonWaitForCanvas2DLoad();
            CheckGableWallMaterialInTheDrawing("Post", "4x6 Treated Post");
            ExtentTestManager.TestSteps($"Verify that the gable post material are updated for the gable wall and shown in the in the drawing table");
            DefaultJobElement.ClickJobReview();
            DefaultJobElement.CheckMaterialsDataFromJobReview("Framing", "Post", null, "4x6 Treated Post", null, null, null, null, null, null, null);
            ExtentTestManager.TestSteps($"Verify that the gable post material are updated for the gable wall and shown in the in the job review table");
            DefaultJobElement.ClickCanvas3DViewButton();
            CommonMethod.Wait(1);
            ChangeFrontLeftViewAndOpenWall("Front Left", 100, 100);
        }

        private void CheckKeepOpenWallGablePostsCheckbox()
        {
            ChangeFrontLeftViewAndOpenWall("Front Right", 150, 150);
            DefaultJobElement.UncheckKeepOpenWallGablePostsCheckbox();
            ClickSyncButtonWaitForCanvasLoad();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_2();
            DefaultJobElement.CheckMaterialIsNotShownInTheDrawing("Post");
            ExtentTestManager.TestSteps($"Verify that if the 'Keep Open Wall Gable Posts' checkbox is not checked, the post is not shown in the open gable wall");
            DefaultJobElement.CheckKeepOpenWallGablePostsCheckbox();
            ClickSyncButtonWaitForCanvas2DLoad();
            string openWallPostMaterial = DefaultJobElement.GetOpenWallPostMaterial();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("Post", null, openWallPostMaterial, null, null);
            ExtentTestManager.TestSteps($"Verify that if the 'Keep Open Wall Gable Posts' checkbox is checked, the post is shown in the open gable wall");
        }

        private void OpenWallPostMaterial()
        {
            DefaultJobElement.SelectOpenWallPostMaterial("4Ply2x8");
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
            DefaultJobElement.ClickDrawingButton();
            DefaultJobElement.ClickAssemblyDrawingEXT_1();
            DefaultJobElement.CheckSingleMaterialValueFromDrawingTable("Post", null, "4Ply2x8", null, null);
            ExtentTestManager.TestSteps($"Verify that the stud frame is applied on the canvas building and shown in the exterior wall of sheathing drawing");
            DefaultJobElement.ClickCanvas3DViewButton();
            ChangeFrontLeftViewAndOpenWall("Front Left", 100, 100);
        }

        private void ChangeFrontLeftViewAndOpenWall(string directionName, int x_axis, int y_axis)
        {
            ChangeViewOfCanvasBuilding(directionName);

            if (!CommonMethod.IsElementPresent(By.XPath("//td[@id='tb_view3dToolbar_item_btnWallOpen']//table[@class='w2ui-button checked']")))
            {
                DefaultJobElement.ClickOpenWallButton();
            }
            else
            {
                CommonMethod.GetActions().MoveToElement(DefaultJobElement.OpenWallButton()).Perform();
            }

            DefaultJobElement.PlaceOpening(x_axis, y_axis);
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void ChangeViewOfCanvasBuilding(string directionName)
        {
            switch (directionName)
            {
                case "Front Left":
                    DefaultJobElement.ChangeViewFrontLeft();
                    break;
                case "Front Right":
                    DefaultJobElement.ChangeViewFrontRight();
                    break;
                default:
                    Assert.Fail("Error: Change view popup not open");
                    break;
            }
        }


        private void CreateAndDeleteFolder(string folder)
        {
            FolderPath.CreateFolder(folder);
            CommonMethod.DeleteFolderFile(folder);
        }

        private void ClickSheathingDrawingElement(string sheathingElement)
        {
            switch (sheathingElement)
            {
                case "Roof-1":
                    DefaultJobElement.ClickAssemblyDrawingROOF_1();
                    break;
                case "Roof-2":
                    DefaultJobElement.ClickAssemblyDrawingROOF_2();
                    break;
                case "EXT_1":
                    DefaultJobElement.ClickAssemblyDrawingEXT_1();
                    break;
                case "EXT_2":
                    DefaultJobElement.ClickAssemblyDrawingEXT_2();
                    break;
                case "EXT_3":
                    DefaultJobElement.ClickAssemblyDrawingEXT_3();
                    break;
                case "EXT_4":
                    DefaultJobElement.ClickAssemblyDrawingEXT_4();
                    break;
                case "INT_1":
                    DefaultJobElement.ClickAssemblyDrawingINT_1();
                    break;
                default:
                    Console.WriteLine($"{sheathingElement} is not shown in the drawing");
                    break;
            }
        }

        private void CheckWallMaterialInTheDrawing(string usage, string material)
        {
            foreach (string elementName in elementNameOfSheathingDrawing)
            {
                ClickSheathingDrawingElement(elementName);
                DefaultJobElement.CheckSingleMaterialValueFromDrawingTable(usage, null, material, null, null);
            }
        }

        private void CheckPostMaterialIsNotShownInTheDrawing()
        {
            foreach (string elementName in elementNameOfSheathingDrawing)
            {
                ClickSheathingDrawingElement(elementName);
                DefaultJobElement.CheckMaterialIsNotShownInTheDrawing("Post");
            }
        }

        private void CheckGableWallMaterialInTheDrawing(string usage, string material)
        {
            foreach (string elementName in gableWallMaterial)
            {
                ClickSheathingDrawingElement(elementName);
                DefaultJobElement.CheckSingleMaterialValueFromDrawingTable(usage, null, material, null, null);
            }
        }


        private void ClickSyncButtonWaitForCanvasLoad()
        {
            DefaultJobElement.ClickSyncButton();
            CommonMethod.PageLoaderForApplyElementOnCanvasBuilding();
        }

        private void ClickSyncButtonWaitForCanvas2DLoad()
        {
            DefaultJobElement.ClickSyncButton();
            DefaultJobElement.PageLoaderFor2D();
        }
    }
}
