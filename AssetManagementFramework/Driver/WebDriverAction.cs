using AssetManagementFramework.HTMLReport;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;

namespace AssetManagementFramework.Driver
{
    public class WebDriverAction
    {
        private IWebDriver driver;

        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void goToUrl(string url)
        {
            driver.Url = url;
            HTMLReporter.Pass("go to url: " + url);
        }
        public IWebElement FindElement(By locator)
        {
            try
            {
                IWebElement e = driver.FindElement(locator);
                ElementFocus(e);
                HTMLReporter.Pass("Element found by locator [" + locator.ToString + "]");
                return e;

            }
            catch (Exception ex)
            {     
                HTMLReporter.Pass("Locator [" + locator.ToString + "] not found");
                throw ex;
            }
        }
        public void SendKey(By locator, string key)
        {
            try
            {
                FindElement(locator).SendKeys(Keys.Control + "a");
                FindElement(locator).SendKeys(Keys.Delete);
                FindElement(locator).SendKeys(key);
                HTMLReporter.Pass("Sent key [" + key + "] to element located by [" + locator.ToString + "]");
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Can not send key [" + key + "] to element located by [" + locator.ToString + "]");
                throw ex;
            }
        }
        public string getTitle()
        {
            try
            {
                string title = driver.Title;
                HTMLReporter.Pass("Title is: " + title);
                return title;
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Title not found");
                throw ex;
            }
        }
        public void ClickElement(By locator)
        {
            try
            {
                FindElement(locator).Click();
                HTMLReporter.Pass("Clicked to Element" + locator.ToString);
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Can not Click to Element in Locator: " + locator.ToString);
                throw ex;
            }
        }
        public void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
                HTMLReporter.Pass("Clicked to Element: " + element.ToString);
            }
            catch (Exception ex)
            {  
                HTMLReporter.Fail("Can not Click to Element" + element.ToString);
                throw ex;
            }
        }
        public void SendKey(IWebElement element, string key)
        {
            try
            {
                element.SendKeys(key);
                HTMLReporter.Pass("Sent key [" + key + "] to element located by [" + element.ToString + "]");
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Can not send key [" + key + "] to element located by [" + element.ToString + "]");
                throw ex;
            }
        }
        public bool findText(string text)
        {
            if (driver.PageSource.Contains(text))
            {
                HTMLReporter.Pass("Text: [" + text + "] is found");
                return true;
            }
            else
            {
                HTMLReporter.Fail("Page does not contain these keyword: " + text);
                return false;
            }
        }
        public void CaptureScreenshotAndReturnModel(string path)
        {
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(path);

        }
        public void ElementFocus(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].style.border = '2px solid red';", element);
        }
        public void SelectText(By locator, string value)
        {
            try
            {
                SelectElement var = new SelectElement(FindElement(locator));
                var.SelectByValue(value);
                HTMLReporter.Pass("Select value " + value);
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Value not found");
                throw ex;
            }
        }
        public string GetText(By locator)
        {
            try
            {
                string var = FindElement(locator).Text;
                HTMLReporter.Pass("Text is: " + var);
                return var;
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Text not found");
                throw ex;
            }
        }
        public void HoverElement(By locator)
        {
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(FindElement(locator)).Perform();
                HTMLReporter.Pass("Hover Element " + locator);
            }
            catch (Exception ex)
            {
                HTMLReporter.Fail("Element not found");
                throw ex;
            }
        }
    }
}
