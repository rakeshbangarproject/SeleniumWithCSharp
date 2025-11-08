using AventStack.ExtentReports;
using OpenQA.Selenium;
using SmartBuildAutomation;

namespace Forms.Reporting
{
    public class ExtentTestManager
    {
        public static ExtentReports extent = ExtentManager.GetExtent();
        public static ExtentTest test;
        public static IWebDriver Driver = BaseClass.Driver;

        // This method is used for the create extent report.
        public static ExtentTest CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
            return test;
        }

        // This method is used for the added the test step.
        public static ExtentTest TestSteps(string Step)
        {
            return test.Log(Status.Info, Step);
        }      
    }
}