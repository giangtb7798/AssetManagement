using AssetManagementFramework.Driver;
using AssetManagementFramework.HTMLReport;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace AssetManagementFramework
{

    [TestFixture]
    public class TestSetup
    {
        private readonly string _browser;
        private readonly string _osPlatform;
        string? NewPath;

        public IWebDriver driver { get; set; }
        public TestSetup(string browser, string osPlatform)
        {
            _browser = browser;
            _osPlatform = osPlatform;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            string REPORT_PATH;
            string HTML_PATH;
            string SCREENSHOT_PATH;
            string projectPath = Path.GetFullPath(@"..\..\..\");

            REPORT_PATH = projectPath + "\\Reports\\Report_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            HTML_PATH = REPORT_PATH + "\\index.html";
            SCREENSHOT_PATH = REPORT_PATH + "\\Screenshot";
            NewPath = Path.Combine(SCREENSHOT_PATH, "Image.png");

            Directory.CreateDirectory(projectPath + "\\Reports");
            Directory.CreateDirectory(REPORT_PATH);
            Directory.CreateDirectory(SCREENSHOT_PATH);

            HTMLReporter.createReport(HTML_PATH);
            HTMLReporter.createTest(TestContext.CurrentContext.Test.ClassName, "test class description here");
        }

        [SetUp]
        public void SetUp()
        {
            HTMLReporter.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name, "test class description here");
            driver = WebDriverCreator.CreateLocalDriver(_browser);
            driver.Url = "https://group5reactjs.azurewebsites.net/";
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                WebDriverAction TakeScreenShoot = new(driver);
                TakeScreenShoot.CaptureScreenshotAndReturnModel(NewPath);
                HTMLReporter.Fail("Test case: " + TestContext.CurrentContext.Test.Name + " is failed", NewPath);
            }
            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            HTMLReporter.Flush();
        }
    }
}
