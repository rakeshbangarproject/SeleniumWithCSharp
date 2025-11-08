using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System.Collections.Generic;
using System.Linq;

namespace RoofingPassport
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestOnPackagesPage : BaseClass
    {
        #region XPath      
        readonly By taxableDropdownYes = By.XPath("//td[contains(text(),'Yes')]");
        readonly By calculationButton = By.XPath("//button[contains(@onclick,'clickCalcBtn(event)')]");
        readonly By ceilingLF = By.XPath("//div[@id='grid_selectCalcBaseOverlay_grid_records']//td[@col='1']//div[text()='LFCeiling']");
        readonly By questionButton = By.XPath("//button[contains(@onclick,'clickQuestionBtn()')]");
        readonly By questionField = By.XPath("//label[contains(text(),'Question:')]//following :: input[1]");
        readonly By defaultField = By.XPath("//label[contains(text(),'Question:')]//following :: input[2]");
        readonly By okButton = By.XPath("//button[contains(text(),'OK')]");
        readonly By clickTestButton = By.XPath("//button[contains(@onclick,'clickTestBtn()')]");
        readonly By ceilingLFField = By.XPath("//label[contains(text(),'LFCeiling:')]//following :: input[1]");
        readonly By testField = By.XPath("//label[contains(text(),'LFCeiling:')]//following :: input[2]");
        readonly By calculationValue = By.XPath("//label[contains(@id,'w2prompt_answer')]");
        readonly By calculateButton = By.XPath("//button[contains(text(),'Calculate')]");
        readonly By closeButton = By.XPath("//button[contains(text(),'Close')]");
        readonly By saveButton = By.XPath("(//button[contains(text(),'Save')])[2]");
        readonly By editButton = By.Id("tb_MaterialsGrid_toolbar_item_edit");
        readonly By cancelButton = By.XPath("//button[contains(text(),'Cancel')]");
        readonly By clickOnFirstRow = By.XPath("(//div[contains(@id,'grid_MaterialsGrid_records')]//following :: td)[9]");
        readonly By arrowDownButton = By.Id("tb_MaterialsGrid_toolbar_item_bottom");
        readonly By SaveButtonMainPage = By.XPath("//table[contains(@title,'+ Save all changes and return to the Jobs List.')]");
        #endregion

        int s = 1;
        [Test]
        public void PackagesPage()
        {
            ExtentTestManager.CreateTest("Smoke Test On Packages Page").Info("Main");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();        
            Main();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On Packages Page");
        }

        #region Main
        private void Main()
        {
            GroupOneForMain();
            GroupTwoForMain();
            SaveButton();
            HomePage.NavigateToPackagePagesForRoofingPassport();
            VerifyElement();
            SaveButton();
        }

        private void GroupOneForMain()
        {
            HomePage.NavigateToPackagePagesForRoofingPassport();
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.GroupNameInputField("Roofing.Group1");
            PackageElement.PackageNameInputField("Test 1");
            PackageElement.SelectPackageType("Bundle");
            AddPackagesDataForMain();
        }

        private void GroupTwoForMain()
        {
            PackageElement.ClickAddButton();
            PackageElement.ClickBlankButton();
            PackageElement.GroupNameInputField("Roofing.Group2");
            PackageElement.PackageNameInputField("Test 2");
            PackageElement.SelectPackageType("Bundle");
            PackageElement.SelectDefaultSetting("On");
            PackageElement.InfoTextField("Testing Field");

            AddMiscDataMain();
            AddCatalogDataForMain();
            AddMiscDataForMain();
        }

        private void AddPackagesDataForMain()
        {
            PackageElement.SelectDefaultSetting("On");
            PackageElement.InfoTextField("Testing Field");
            PackageElement.ClickAddMiscButton();
            PackageElement.SelectOutputCategory("Accessories");

            string[] price = new string[4] { "Test1", "Test1", "60", "55" };
            for (int i = 0; i < price.Length; i++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//label[contains(text(),'SKU')]//following :: input[{0}]", s)))).SendKeys(price[i] + Keys.Enter);
                s++;
                CommonMethod.Wait(1);
            }

            SelectTaxableElement();
            PackageElement.UsageInputField("Testing data");
            CalculationFieldForMain();
            CommonMethod.Wait(3);
            AddCatalogDataForMain();
            AddMiscDataForMain();
        }

        private void AddCatalogDataForMain()
        {
            PackageElement.ClickAddCatalogButton();
            PackageElement.UsageInputField("Testing data");
            PackageElement.SelectCatalogCategory("Fastener");
            PackageElement.SelectCatalogItem("ROOFING NAILS 2 1/2 FlatHead");
            PackageElement.SelectOutputCategory("Cladding");
            CalculationFieldForMain();
            CommonMethod.Wait(2);
        }

        private void AddMiscDataForMain()
        {
            PackageElement.ClickAddMiscButton();
            PackageElement.UsageInputField("Testing data");

            int w = 1;
            string[] priceTest = new string[4] { "Test2", "Test2", "70", "35" };

            for (int i = 0; i < priceTest.Length; i++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//label[contains(text(),'SKU')]//following :: input[{0}]", w)))).SendKeys(priceTest[i] + Keys.Enter);
                w++;
                CommonMethod.Wait(1);
            }

            SelectTaxableElement();
            CalculationFieldForMain();
            CommonMethod.Wait(3);
        }
        #endregion

        #region private method       
        private void VerifyElement()
        {
            IWebElement tableDelete = Driver.FindElement(By.XPath("//div[@id='grid_packageList_records']/table/tbody"));
            IList<IWebElement> elements = tableDelete.FindElements(By.TagName("tr"));
            string a = "//div[@id='grid_packageList_records']/table/tbody/tr[";
            string b = "]/td[3]/div[1]";
            var rowCountDelete = elements.Count() - 2;

            for (int i = 3; i <= rowCountDelete; i++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + i + b))).Text;
                if (c.Contains("Roofing.Group1"))
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_packageList_records']/table/tbody/tr[" + i + "]"))).Click();
                    CommonMethod.Wait(1);
                    break;
                }
            }

            ExtentTestManager.TestSteps("Click on the Roofing.Group1");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(clickOnFirstRow)).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(editButton)).Click();
            ExtentTestManager.TestSteps("Verify that edit button is working");
            CommonMethod.Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(cancelButton)).Click();
            CommonMethod.Wait(2);

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(arrowDownButton)).Click();
            ExtentTestManager.TestSteps("Click on the Down Arrow button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(" ((//div[contains(@id,'grid_MaterialsGrid_records')])[1]//following :: div)[17]")));
            string downfield = CommonMethod.element.GetAttribute("title");
            Assert.True(downfield.Equals("Test1"));
            ExtentTestManager.TestSteps("Verify that the element is going to the down of the table after clicking the Arrow down button");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tb_MaterialsGrid_toolbar_item_top"))).Click();
            ExtentTestManager.TestSteps("Click on the Down Arrow button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("((//div[contains(@id,'grid_MaterialsGrid_records')])[1]//following :: div)[3]")));
            string topField = CommonMethod.element.GetAttribute("title");
            Assert.True(topField.Equals("Test1"));
            ExtentTestManager.TestSteps("Verify that the element is going to the top of the table after clicking the Arrow up button");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tb_MaterialsGrid_toolbar_item_copy"))).Click();
            ExtentTestManager.TestSteps("Click on thw Copy button");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[contains(text(),'Test 2')]"))).Click();
            ExtentTestManager.TestSteps("Copy Test1 element in the Roofing.Group2 Material");
            CommonMethod.Wait(1);

            for (int i = 3; i <= rowCountDelete; i++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + i + b))).Text;
                if (c.Contains("Roofing.Group2"))
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_packageList_records']/table/tbody/tr[" + i + "]"))).Click();
                    ExtentTestManager.TestSteps("Click on the Roofing.Group2 package");
                    CommonMethod.Wait(1);
                    break;
                }
            }

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("((//div[contains(@id,'grid_MaterialsGrid_records')])[1]//following :: div)[24]")));
            string copyElementPresent = CommonMethod.element.GetAttribute("title");
            Assert.True(copyElementPresent.Equals("Test1"));
            ExtentTestManager.TestSteps("Verify that the Test1 data is copy to the Roofing.Group1 Packages.");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(clickOnFirstRow)).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tb_MaterialsGrid_toolbar_item_move"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//td[contains(text(),'Test 1')]"))).Click();

            for (int i = 3; i <= rowCountDelete; i++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + i + b))).Text;
                if (c.Contains("Roofing.Group1"))
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_packageList_records']/table/tbody/tr[" + i + "]"))).Click();
                    CommonMethod.Wait(1);
                    break;
                }
            }

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("((//div[contains(@id,'grid_MaterialsGrid_records')])[1]//following :: div)[3]")));
            string moveElementPresent = CommonMethod.element.GetAttribute("title");
            Assert.True(copyElementPresent.Equals("Test1"));
            ExtentTestManager.TestSteps("Verify that the Test1 data is move to the Roofing.Group2 Packages.");

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tb_packageList_toolbar_item_w2ui-delete"))).Click();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click(CommonMethod.element).Perform();

            for (int i = 3; i <= rowCountDelete; i++)
            {
                string c = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(a + i + b))).Text;
                if (c.Contains("Roofing.Group2"))
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='grid_packageList_records']/table/tbody/tr[" + i + "]"))).Click();
                    CommonMethod.Wait(1);
                    break;
                }
            }

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("tb_packageList_toolbar_item_w2ui-delete"))).Click();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),'Yes')]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click(CommonMethod.element).Perform();
            ExtentTestManager.TestSteps("Click on the Delete button");
        }

        private void SaveButton()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(SaveButtonMainPage)).Click();
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
            ExtentTestManager.TestSteps("Click on the save button");
        }

        private void AddMiscDataMain()
        {
            PackageElement.ClickAddMiscButton();
            PackageElement.UsageInputField("Testing data");

            int w = 1;
            string[] priceTest = new string[4] { "Test1", "Test1", "40", "35" };

            for (int i = 0; i < priceTest.Length; i++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'SKU')]//following :: input[" + w + "]"))).SendKeys(priceTest[i] + Keys.Enter);
                w++;
                CommonMethod.Wait(1);
            }
            ExtentTestManager.TestSteps("Enter data in SKu and other field");

            SelectTaxableElement();
            CalculationFieldForMain();
            CommonMethod.Wait(3);
        }

        private void CalculationFieldForMain()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(calculationButton)).Click();
            CommonMethod.Wait(2);
            ExtentTestManager.TestSteps("Click on the Calculation button");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(ceilingLF));
            CommonMethod.GetActions().DoubleClick(CommonMethod.element).Perform();
            ExtentTestManager.TestSteps("Select ceiling LF from table");
            QuestionField();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(ceilingLFField)).SendKeys("55");
            ExtentTestManager.TestSteps("Enter data in the Ceiling LF field");
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(testField));
            CommonMethod.GetActions().Click(CommonMethod.element).KeyDown(Keys.Control).SendKeys("a").KeyUp(Keys.Control).SendKeys("45").Perform();
            ExtentTestManager.TestSteps("Enter data in the Test field");
            CalculationValue();
        }

        private void CalculationValue()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(calculateButton)).Click();
            ExtentTestManager.TestSteps("Click on the calculation field");
            CommonMethod.Wait(5);
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(calculationValue));
            string calculate = CommonMethod.element.Text;
            Assert.True(calculate.Equals("15545"));
            ExtentTestManager.TestSteps("Verify that the calculation is correct");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(closeButton)).Click();
            ExtentTestManager.TestSteps("Click on the close button");
            CommonMethod.Wait(1);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(saveButton)).Click();
            ExtentTestManager.TestSteps("Click on the save button");
        }

        private void QuestionField()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(questionButton)).Click();
            ExtentTestManager.TestSteps("Click on the question button");
            CommonMethod.Wait(1);

            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(questionField)).SendKeys("Testing Field");
            ExtentTestManager.TestSteps("Enter data in the question field");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(defaultField)).SendKeys("Testing Field");
            ExtentTestManager.TestSteps("Enter data in the default field");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(okButton)).Click();
            ExtentTestManager.TestSteps("Click on the ok button");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(clickTestButton)).Click();
            ExtentTestManager.TestSteps("Click on the test button");
            CommonMethod.Wait(1);
        }

        private void SelectTaxableElement()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//label[contains(text(),'Taxable')]//following :: div[5]"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(taxableDropdownYes)).Click();
            ExtentTestManager.TestSteps("Select yes from Taxable Element dropdown");
            CommonMethod.Wait(1);
        }
    }
}
#endregion