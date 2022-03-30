using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFramework.Driver
{
    public class WebDriverCreator
    {
        public static IWebDriver CreateLocalDriver(String BrowserName)
        {
            IWebDriver driver = null;
            if (BrowserName.SequenceEqual("firefox"))
            {
                driver = new FirefoxDriver();
            }
            else if (BrowserName.SequenceEqual("chrome"))
            {
                driver = new ChromeDriver();
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
        public static IWebDriver CreateRemoteDriver(String BrowserName, String OSName)
        {
            IWebDriver driver = null;
            if (BrowserName.SequenceEqual("firefox"))
            {
                FirefoxOptions options = new FirefoxOptions();
                options.PlatformName = OSName;
                Console.Out.WriteLine("This is" + options.BrowserName + "browser");
                driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
            }
            else if (BrowserName.SequenceEqual("chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.PlatformName = OSName;
                Console.Out.WriteLine("This is" + options.BrowserName + "browser");
                driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), options.ToCapabilities());
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
        public static IWebDriver CreateChromeRBrowserStackDriver(String BrowserName, String OSName, String BrowserVersion, String OSVersion)
        {
            IWebDriver driver = null;
            String test_name = "Exercise 3 Browerstack";
            String build_name = "Practice Browerstack";

            ChromeOptions chromeCapability = new ChromeOptions();
            chromeCapability.AddAdditionalCapability("os_version", OSVersion, true);
            chromeCapability.AddAdditionalCapability("browser", BrowserName, true);
            chromeCapability.AddAdditionalCapability("browser_version", BrowserVersion, true);
            chromeCapability.AddAdditionalCapability("os", OSName, true);
            chromeCapability.AddAdditionalCapability("name", test_name, true);
            chromeCapability.AddAdditionalCapability("build", build_name, true);
            chromeCapability.AddAdditionalCapability("browserstack.user", "quydaohoang_KAIGuv", true);
            chromeCapability.AddAdditionalCapability("browserstack.key", "9jH2f4azupacTK3kLkaN", true);
            driver = new RemoteWebDriver(
             new Uri("https://hub-cloud.browserstack.com/wd/hub/"), chromeCapability);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
