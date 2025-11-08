using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.pageObjectModel;
using SmartBuildAutomation.Pages_Application;
using SmartBuildAutomation.Pages1;
using SmartBuildProductionAutomation.Helper;
using System;

namespace Roofing_Passport
{
    [TestFixture, Category("Roofing_Passport")]
    public class SmokeTestOnCustomizePage : BaseClass
    {
        #region XPath 
        By uploadFile = By.XPath("//input[contains(@id,'fileBox')]");
        By popUp = By.XPath("//div[@id='w2ui-popup']/div[2]/div/div");
        By aboutPage = By.PartialLinkText("About");
        By contactPage = By.PartialLinkText("Contact");
        #endregion
        #region URL
        public string googleLink = TestContext.Parameters.Get("GooglePageURL");
        public string wikipediaLink = TestContext.Parameters.Get("WikipediaPageURL");
        public string facebookLink = TestContext.Parameters.Get("FacebookPageURL");

        public static string path = SmartBuildAutomation.Helper.FolderPath.ImagesFolder();
        #endregion

        [Test]
        public void CustomizePage()
        {
            ExtentTestManager.CreateTest("Smoke Test On The Customize Page");
            CommonMethod.Login();
            CommonMethod.AUTOTESTEAGLEVIEW();
            HomePage.NavigateToCustomizePage();
            CheckBoxesCheck();
            SizeCheck();
            DefaultLinks();
            SupportButton();
            Notification();
            CommonMethod.ChangesDistributor();
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            ExtentManager.GetExtent().Flush();
            CommonMethod.SendEmail("Test Report of Smoke Test On The Customize Page");
        }

        #region Private Method
        private void EnterDataInTheHomeAboutAndContactField()
        {
            Customize.EnterDataInTheHomeField(TestContext.Parameters.Get("GooglePageURL"));
            Customize.EnterDataInTheAboutField(TestContext.Parameters.Get("WikipediaPageURL"));
            Customize.EnterDataInTheContactField(TestContext.Parameters.Get("FacebookPageURL"));
            Customize.ClickSaveButton();
        }

        private void OpenNewTabForLogo(string logoLink, string aboutLink, string contactLink)
        {
            string firstWindows = NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//img[@alt='SmartBuild']"))).Click();
            CommonMethod.Wait(10);
            string logoPageTitleDefault = Driver.Url;
            Assert.True(logoPageTitleDefault.Contains(logoLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the logo icon is redirected to the {logoPageTitleDefault}");

            NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(aboutPage)).Click();
            CommonMethod.Wait(10);
            string aboutPageTitleDefault = Driver.Url;
            Assert.True(aboutPageTitleDefault.Contains(aboutLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the about button is redirected to the {logoPageTitleDefault}");

            NavigateToJobPage();
            CommonMethod.Wait(10);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(contactPage)).Click();
            CommonMethod.Wait(10);
            string contactPageTitleDefault = Driver.Url;
            Assert.True(contactPageTitleDefault.Contains(contactLink));
            Driver.Close();
            Driver.SwitchTo().Window(firstWindows);
            ExtentTestManager.TestSteps($"Verify that click on the contact button is redirected to the {logoPageTitleDefault}");
        }

        private string NavigateToJobPage()
        {
            string jobLink = TestContext.Parameters.Get("HomePageURL");
            ((IJavaScriptExecutor)Driver).ExecuteScript($"window.open('{jobLink}', '_blank');");
            string originalWindow = Driver.CurrentWindowHandle;
            foreach (string window in Driver.WindowHandles)
            {
                if (originalWindow != window)
                {
                    Driver.SwitchTo().Window(window);
                    break;
                }
            }
            GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
            return originalWindow;
        }

        private void ClearDataFromHomeAboutContactField()
        {
            HomePage.NavigateToCustomizePage();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("HomeLink"))).Clear();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("AboutLink"))).Clear();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("ContactLink"))).Clear();
            ExtentTestManager.TestSteps("Clear data from the Home, About, and Contact field");
            Customize.ClickSaveButton();
        }

        private void CheckBoxesCheck()
        {
            Customize.CheckedIncludeCheckbox();
            Customize.CheckedWaterMarkCheckbox();
            Customize.ChangeNotificationsCheckbox();
            EditableField();
            Driver.Navigate().Refresh();
        }

        private void SizeCheck()
        {
            string[] uploadImages = new string[3] { $@"{path}\sample.pdf", $@"{path}\file-csv.csv", $@"{path}\5mb.png" };

            for (int i = 0; i < uploadImages.Length; i++)
            {
                // Click on Upload button 
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(uploadFile)).SendKeys(uploadImages[i]);
                ExtentTestManager.TestSteps($"Click on Upload button and upload {uploadImages[i]}");
                CommonMethod.Wait(1);

                // Show the alert message popup
                CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(popUp));
                string alertMessageForPdfFile = CommonMethod.element.Text;
                ExtentTestManager.TestSteps("Show alert message" + alertMessageForPdfFile);
                Customize.ClickOkayButton();
            }

            // Click upload button 
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Id("fileBox"))).SendKeys($@"{path}\Logo.png");
            ExtentTestManager.TestSteps("Upload image size should be less than 1 mb");
            CommonMethod.Wait(2);

            Customize.ClickSaveButton();
            HomePage.NavigateToCustomizePage();
            Customize.ClickDeleteButton();
            Customize.ClickSaveButton();
            HomePage.NavigateToCustomizePage();
        }

        private void DefaultLinks()
        {
            EnterDataInTheHomeAboutAndContactField();
            OpenNewTabForLogo(TestContext.Parameters.Get("GooglePageURL"), TestContext.Parameters.Get("WikipediaPageURL"), TestContext.Parameters.Get("FacebookPageURL"));
            ClearDataFromHomeAboutContactField();
            OpenNewTabForLogo(TestContext.Parameters.Get("SmartBuildSystemPageURL"), TestContext.Parameters.Get("SmartBuildResourcesPageURL"), TestContext.Parameters.Get("SmartBuildContactPageURL"));
        }

        private void SupportButton()
        {
            HomePage.NavigateToCustomizePage();
            VerifySupportAndHelpButtonShownIfUncheckIncludeCheckbox();
            VerifySupportAndHelpButtonShownIfCheckIncludeCheckbox();
        }

        private string VerifyHelpButton()
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("(//button[contains(text(),'Help')])[1]"));

                if (CommonMethod.element.Displayed)
                {
                    return "The Help button appears when the include support checkbox is check";
                }
                else
                {
                    return "The Help button disappears when the include support checkbox is Unchecked";
                }
            }
            catch (NoSuchElementException)
            {
                return "The Help button disappears when the include support checkbox is Unchecked";
            }
        }

        private string VerifyIncludeSupport()
        {
            try
            {
                CommonMethod.element = Driver.FindElement(By.XPath("//button[@id='feedbackBtn']"));

                if (CommonMethod.element.Displayed)
                {
                    return "The Support button appears when the include support checkbox is check";
                }
                else
                {
                    return "The support button disappears when the include support checkbox is Unchecked";
                }
            }
            catch (NoSuchElementException)
            {
                return "The support button disappears when the include support checkbox is Unchecked";
            }
        }

        private void VerifySupportAndHelpButtonShownIfCheckIncludeCheckbox()
        {
            // Click on checkbox
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='IncludeFeedback']")));

            if (!CommonMethod.element.Selected)
            {
                CommonMethod.element.Click();
            }

            Console.WriteLine("Check the Support Checkbox");
            ExtentTestManager.TestSteps("Check the Support Checkbox'");
            Customize.ClickSaveButton();
            Console.WriteLine("In the home Page:");
            ExtentTestManager.TestSteps("In the home Page:");
            string home = VerifyIncludeSupport();
            Assert.That(home, Is.EqualTo("The Support button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Support button appears when the include support checkbox is check");
            Console.WriteLine("The Support button appears when the include support checkbox is check");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            Console.WriteLine("In the default job:");
            ExtentTestManager.TestSteps("In the default job:");
            string defaultJob = VerifyIncludeSupport();
            Assert.That(defaultJob, Is.EqualTo("The Support button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Support button appears when the include support checkbox is check");
            Console.WriteLine("The Support button appears when the include support checkbox is check");
            string help = VerifyHelpButton();
            Assert.That(help, Is.EqualTo("The Help button appears when the include support checkbox is check"));
            ExtentTestManager.TestSteps("The Help button appears when the include support checkbox is check");
            Console.WriteLine("The Help button appears when the include support checkbox is check");
            DefaultJobElement.ClickJobListButton();
        }

        private void VerifySupportAndHelpButtonShownIfUncheckIncludeCheckbox()
        {
            // Click on checkbox
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='IncludeFeedback']")));

            if (CommonMethod.element.Selected)
            {
                CommonMethod.element.Click();
            }

            Console.WriteLine("Uncheck the Support Checkbox");
            ExtentTestManager.TestSteps("Uncheck the Support Checkbox'");
            Customize.ClickSaveButton();
            Console.WriteLine("In the home Page:");
            ExtentTestManager.TestSteps("In the home Page:");
            string home = VerifyIncludeSupport();
            Assert.That(home, Is.EqualTo("The support button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The support button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The support button disappears when the include support checkbox is Unchecked");
            HomePage.ClicksJobTab();
            JobPage.OpenJob("Zombie Parts");
            CommonMethod.PageLoader();
            Console.WriteLine("In the default job:");
            ExtentTestManager.TestSteps("In the default job:");
            string defaultJob = VerifyIncludeSupport();
            Assert.That(defaultJob, Is.EqualTo("The support button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The support button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The support button disappears when the include support checkbox is Unchecked");
            string help = VerifyHelpButton();
            Assert.That(help, Is.EqualTo("The Help button disappears when the include support checkbox is Unchecked"));
            ExtentTestManager.TestSteps("The Help button disappears when the include support checkbox is Unchecked");
            Console.WriteLine("The Help button disappears when the include support checkbox is Unchecked\n");
            DefaultJobElement.ClickJobListButton();
            HomePage.NavigateToCustomizePage();
        }

        private void EditableField()
        {
            int k = 1;
            string[] value = new string[3] { googleLink, wikipediaLink, facebookLink };
            for (int j = 0; j < value.Length; j++)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(string.Format("//label[contains(text(),'Home Link')]//following :: input[{0}]", k)))).SendKeys(value[j]);
                CommonMethod.Wait(1);
                k++;
            }

            ExtentTestManager.TestSteps("Verify that the Home, About, and Contact fields are editable");
        }

        private void Notification()
        {
            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();
            SetupWizard.ClickAddButton();
            SetupWizard.ColorNameInputField("Test Color 0673");
            SetupWizard.CodeTransparencyInputField("0");
            SetupWizard.ColorCodeInputField("#545686");
            SetupWizard.SelectHexCode("F4CCCC");
            SetupWizard.ClickSaveButton();
            SetupWizard.SaveDataInTheSetupWizard();

            Driver.SwitchTo().NewWindow(WindowType.Tab);
            Driver.Navigate().GoToUrl(TestContext.Parameters.Get("GMailPageURL"));
            ExtentTestManager.TestSteps("Navigate to Gmail account");
            CommonMethod.LoginGmail();

            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//tr[contains(@jscontroller,'ZdOxDb')])[1]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            CommonMethod.element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//div[contains(@role,'button')])[34]")));
            CommonMethod.GetActions().MoveToElement(CommonMethod.element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Verify that the user receive the Gmail");
            Driver.Close();
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);

            HomePage.NavigateToSetupWizardPages();
            SetupWizard.ClickColors();
            SetupWizard.DeleteSetupWizardData("Test Color 0673");
            SetupWizard.SaveDataInTheSetupWizard();
            HomePage.NavigateToCustomizePage();
            Customize.ChangeNotificationsCheckbox();
            Customize.ClickSaveButton();
        }
    }
}
#endregion
