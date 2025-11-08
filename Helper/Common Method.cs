using Forms.Reporting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SmartBuildAutomation;
using SmartBuildAutomation.Helper;
using SmartBuildAutomation.Locators;
using SmartBuildAutomation.Pages1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace SmartBuildProductionAutomation.Helper
{
    public class CommonMethod : BaseClass
    {
        public static Actions GetActions() => new(Driver);
        public static SelectElement SelectElement(IWebElement element) => new(element);
        public static WebDriverWait GetWebDriverWaitForDefault() => new(Driver, TimeSpan.FromSeconds(2));
        public static IWebElement element;

        // Performs the login operation using credentials provided in TestContext parameters
        public static void Login()
        {
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("Username"))).SendKeys(TestContext.Parameters.Get("Username"));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.Name("Password"))).SendKeys(TestContext.Parameters.Get("Password"));
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#RememberMe"))).Click();
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='loginForm']/form/div[4]/div/input"))).Click();
            CreateDownloadFolder();
        }

        // Login to the application and set distributor as AutoTest_PHTest
        public static void LoginApplicationAndSetDistributorToAUTOTEST_PHTEST(string taskName)
        {
            Login();
            ChangeDistributor("AUTOTEST_PHTEST");
            ExtentTestManager.CreateTest(taskName).Info("Log in to AUTOTEST_PHTEST Distributor for Test Environment");
            Assert.That(Driver.Title, Is.EqualTo("Home - SmartBuild Framer"), "Error: Incorrect page title after login");
            Assert.That(Driver.Url, Is.EqualTo(TestContext.Parameters.Get("HomePageURL")), "Error: Incorrect page URL after login");
        }

        /// <summary>
        /// Selects an element from a dropdown list.
        /// </summary>
        /// <param name="materialName">The name of the element to be selected from the dropdown.</param>
        /// <param name="xpath">The static XPath of the dropdown list.</param>
        public static void SelectMaterialFromDropdown(string materialName, string xpath)
        {
            bool result = false;
            Wait(2);
            for (int attempt = 0; attempt < 3; attempt++)
            {
                IReadOnlyList<IWebElement> numberOfElements = Driver.FindElements(By.XPath(xpath));

                for (int index = 0; index < numberOfElements.Count; index++)
                {
                    string elementText = numberOfElements[index].Text;

                    if (!string.IsNullOrEmpty(elementText) && elementText.Equals(materialName))
                    {
                        GetActions().Click(numberOfElements[index]).Perform();
                        result = true;
                        break;
                    }
                }
            }
            Assert.AreEqual(result, true, $"{materialName} is not shown in the dropdown");
        }

        // This method is used to handle browser alerts.
        public static bool HandleAlert()
        {
            try
            {
                Driver.SwitchTo().Alert().Accept();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Sends an email with a specified report attached.
        /// </summary>
        /// <param name="reportName">The name of the report.</param>
        public static void SendEmail(string reportName)
        {
            string PathToDirectory = Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory);
            var path = PathToDirectory + @"/../../Result/index.html";
            var fromAddress = new MailAddress("test2@gmail.com", "From Name");
            var toAddress = new MailAddress("test@gmail.com", "To Name");
            string fromPassword = "dev12345678";
            string subject = reportName;
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = "Please find the attachment of this Test"
            };

            message.Attachments.Add(new Attachment(path));
            smtp.Send(message);
        }

        // This method is used to retrieve the job name using the date format: month/day/year
        public static string GetThePdfFileName(string pdfName)
        {
            var date = DateTime.Now.ToString("MM/dd/yyyy");
            string currentDate = date.Replace('/', '-');
            string pdfFileName = $"{pdfName}_{currentDate}.pdf";
            return pdfFileName;
        }

        // This method is used to retrieve the job name using the date format: day/month/year
        public static string GetThePdfFileNameDateStartWithDays(string pdfName)
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            string currentDate = date.Replace('/', '-');
            string pdfFileName = $"{pdfName}_{currentDate}.pdf";
            return pdfFileName;
        }

        // Wait until the element becomes invisible
        public static bool WaitForPageElementInvisibility(string elementXPath)
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(elementXPath)));
                return true;
            }
            catch
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(elementXPath)));
                return false;
            }
        }

        // Delete file from folder
        public static void DeleteFolderFile(string fileName)
        {
            DirectoryInfo deleteFiles = new DirectoryInfo(fileName);
            foreach (FileInfo file in deleteFiles.GetFiles())
            {
                if (file.Exists)
                {
                    file.Delete();
                }
            }
        }

        // Checking download folder create
        public static bool CreateDownloadFolder()
        {
            string folderPath = FolderPath.Download();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                return true;
            }
            else
            {
                return false;
            }
        }

        // Wait for the job page loads
        public static void PageLoader()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));
                Wait(1);

                if (IsElementPresent(By.XPath("//div[@class='w2ui-spinner']")))
                {
                    GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='w2ui-spinner']")));
                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
                }

                string errorMessage = Driver.FindElement(By.XPath("//div[@id='w2ui-popup']//div[2]")).Text;
                Console.WriteLine(errorMessage);
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            }
        }

        public static bool IsElementPresent(By locator)
        {
            try
            {
                GetWebDriverWaitForDefault().Until(ExpectedConditions.ElementIsVisible(locator));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string WindowHandle()
        {
            // Switch to the new window
            string mainHandle = Driver.CurrentWindowHandle;
            foreach (string handle in Driver.WindowHandles)
            {
                if (handle != mainHandle)
                {
                    Driver.SwitchTo().Window(handle);
                    break;
                }
            }
            return mainHandle;
        }

        // Wait for the job page after click on the save button
        public static void PageLoaderForSaveButton()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));

                if (IsElementPresent(By.XPath("//div[@class='w2ui-lock-msg']")))
                {
                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-lock-msg']")));
                    GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));
                }

                string errorMessage = Driver.FindElement(By.XPath("//div[@id='w2ui-popup']//div[2]")).Text;
                Console.WriteLine(errorMessage);
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            }
        }

        // This method is used to wait for the spinner to disappear after selecting an element from the canvas menu.
        public static void PageLoaderForApplyElementOnCanvasBuilding()
        {
            try
            {
                GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
                GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));
                Wait(1);

                if (IsElementPresent(By.XPath("//div[@class='w2ui-spinner']")))
                {
                    GetWebDriverWait().Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//div[@class='w2ui-spinner']")));
                    GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath("//canvas[@id='drawingArea']")));
                }

                string errorMessage = Driver.FindElement(By.XPath("//div[@id='w2ui-popup']//div[2]")).Text;
                Console.WriteLine(errorMessage);
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//canvas[@id='drawingArea']")));
            }
        }

        // This method is used for the fetch data from pdf file
        public static string VerifyPDFContent(string fileName)
        {
            try
            {
                string pdfFileName = GetThePdfFileName(fileName);
                FolderPath.WaitForFileDownload(pdfFileName, 30);
                string pdfFilePath = System.IO.Path.Combine(downloadFolder, pdfFileName);
                Wait(5);
                return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
            catch (Exception)
            {
                string pdfFileName = GetThePdfFileNameDateStartWithDays(fileName);
                FolderPath.WaitForFileDownload(pdfFileName, 60);
                string pdfFilePath = System.IO.Path.Combine(downloadFolder, pdfFileName);
                Wait(5);
                return DefaultJobElement.CheckDataFromPDFFiles(pdfFilePath);
            }
        }

        /// <summary>
        /// Navigates to the beta environment and performs login.
        /// </summary>
        public static void GoToBetaEnvironment()
        {
            try
            {
                Driver.Navigate().GoToUrl(TestContext.Parameters.Get("BetaURL"));
                Driver.SwitchTo().Alert().Accept();
                Login();
            }
            catch (Exception)
            {
                Login();
            }
        }

        /// <summary>
        /// Navigates to the Production environment and performs login.
        /// </summary>
        public static void GoToProductionEnvironment()
        {
            try
            {
                Driver.Navigate().GoToUrl(TestContext.Parameters.Get("ProductionURL"));
                Driver.SwitchTo().Alert().Accept();
                Login();
            }
            catch (Exception)
            {
                Login();
            }
        }

        public static void Wait(int delay)
        {
            // Causes the WebDriver to wait for at least a fixed delay
            var now = DateTime.Now;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(delay));
            wait.Until(Driver => (DateTime.Now - now) - TimeSpan.FromSeconds(delay) > TimeSpan.Zero);
        }

        public static void AUTOTESTEAGLEVIEW()
        {
            // Navigate to a page element and perform actions
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Hello Kritika Dhillon!')]"))).Click();
            Wait(2);
            // Wait for the distributor dropdown to be clickable
            IWebElement distributorName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[contains(@class,'baseDistEditor')]")));

            // Get the currently selected distributor
            SelectElement select = new SelectElement(distributorName);
            select.SelectByText("AUTOTEST_EAGLEVIEW BASE");
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'form-manage')]//following :: input[7]"))).Click();
        }

        public static void LoginToBuilderDistributor(string builderName)
        {
            // Navigate to a page element and perform actions
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Hello Kritika Dhillon!')]"))).Click();
            Wait(2);
            // Wait for the distributor dropdown to be clickable
            IWebElement distributorName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[contains(@class,'baseDistEditor')]")));

            // Get the currently selected distributor
            SelectElement select = new SelectElement(distributorName);
            select.SelectByText(builderName);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'form-manage')]//following :: input[7]"))).Click();
            ExtentTestManager.TestSteps($"Change {builderName} distributor");
        }

        public static void ChangesDistributor()
        {
            // Navigate to a page element and perform actions
            IWebElement helloButton = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Hello Kritika Dhillon!')]")));
            GetActions().MoveToElement(helloButton).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
            Wait(2);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[contains(@name,'DistributorId')]"))).SendKeys("AUTOTEST PHTEST");
            IWebElement saveChanges = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'form-manage')]//following :: input[7]")));
            GetActions().MoveToElement(saveChanges).Pause(TimeSpan.FromSeconds(1)).Click().Perform();
        }

        // This method is used for the click on the IWebElement
        public static void Click(IWebElement element)
        {
            // Wait for an element to be clickable and then click on it
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(120));
            Func<IWebDriver, bool> ElementToBeClickable = arg0 =>
            {
                try
                {
                    element.Click();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                }
            };
            wait.Until(ElementToBeClickable);
        }

        public static IJavaScriptExecutor ExecuteJavaScript()
        {
            GetWebDriverWait().Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            return js;
        }

        public static string DownloadFile()
        {
            string DownloadsFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            DirectoryInfo DirectoryInfo = new DirectoryInfo(DownloadsFolderPath);
            FileInfo[] files = DirectoryInfo.GetFiles();
            FileInfo LatestFile = files.OrderByDescending(f => f.LastWriteTime).FirstOrDefault();
            string FileName = LatestFile.Name;
            string FilePath = LatestFile.FullName;
            return FilePath;
        }

        // This method is used for the deleted the folder file
        public static void DeleteFolderData()
        {
            DirectoryInfo deleteFiles = new DirectoryInfo($@"{downloadFolder}");
            foreach (FileInfo file in deleteFiles.GetFiles())
            {
                if (file.Exists)
                {
                    file.Delete();
                }
            }
        }

        // This method is used for the login Gmail account
        public static void LoginGmail()
        {
            try
            {
                element = Driver.FindElement(By.XPath(Locator.CommonXPath.signInButton));
                GetActions().MoveToElement(element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CommonXPath.emailInputField))).SendKeys(TestContext.Parameters.Get("Username"));
                ExtentTestManager.TestSteps("Enter username");
            }
            catch (Exception)
            {
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath(Locator.CommonXPath.emailInputField))).SendKeys(TestContext.Parameters.Get("Username"));
                ExtentTestManager.TestSteps("Enter username");
            }

            Wait(5);
            element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.nextButton)));
            GetActions().MoveToElement(element).Click().Pause(TimeSpan.FromSeconds(1)).Perform();
            ExtentTestManager.TestSteps("Click on the next button");
            Wait(5);
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath((Locator.CommonXPath.passwordInputField)))).SendKeys(TestContext.Parameters.Get("Password"));
            ExtentTestManager.TestSteps("Enter Password");
            element = GetWebDriverWait().Until(ExpectedConditions.ElementIsVisible(By.XPath(Locator.CommonXPath.nextButtons)));
            GetActions().MoveToElement(element).Click().Pause(TimeSpan.FromSeconds(5)).Perform();
            ExtentTestManager.TestSteps("Click on the next button");
        }

        // This method is used for the change the distributor
        public static void ChangeDistributorFunctionality(string distributor)
        {
            // Click on the user profile link
            element = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Hello Kritika Dhillon!')]")));
            GetActions().Click(element).Pause(TimeSpan.FromSeconds(1)).Perform();

            // Wait for the distributor dropdown to be clickable
            IWebElement distributorName = GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[contains(@class,'baseDistEditor')]")));

            // Get the currently selected distributor
            SelectElement select = new SelectElement(distributorName);
            string currentDistributor = select.SelectedOption.Text;

            // Check if the current distributor is different from the desired distributor
            if (currentDistributor != distributor)
            {
                // Change the distributor
                select.SelectByText(distributor);

                // Click on the submit button to apply the changes
                GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(@class,'form-manage')]//following :: input[7]"))).Click();
            }

            // Click on the "Home" link
            GetWebDriverWait().Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Home"))).Click();
        }

        // This method is used for the check distributor is set as autotest phtest
        public static void ChangeDistributor(string distributor)
        {
            try
            {
                Driver.FindElement(By.XPath("//h2[text()='Welcome back, Kritika Dhillon at AUTOTEST_PHTEST!']"));
            }
            catch (NoSuchElementException)
            {
                ChangeDistributorFunctionality(distributor);
            }
        }
    }
}
