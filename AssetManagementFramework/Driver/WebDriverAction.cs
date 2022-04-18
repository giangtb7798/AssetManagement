using AssetManagementFramework.HTMLReport;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
                TestContext.WriteLine("Find element [" + locator.ToString + "]");
                HTMLReporter.Pass("Element found by locator [" + locator.ToString + "]");
                return e;

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot find element located by [" + locator.ToString + "]");
                HTMLReporter.Pass("Locator [" + locator.ToString + "] not found");
                throw ex;
            }
        }
        public List<IWebElement> FindElements(By locator)
        {
            try
            {
                List<IWebElement> e = driver.FindElements(locator).ToList();
                foreach (IWebElement element in e)
                { ElementFocus(element); }

                TestContext.WriteLine("Find elements [" + locator.ToString + "]");
                HTMLReporter.Pass("Elements found by locator [" + locator.ToString + "]");
                return e;

            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot find elements located by [" + locator.ToString + "]");
                HTMLReporter.Pass("Locator [" + locator.ToString + "] not found");
                throw ex;
            }
        }
        public List<string> ElementsToListText(By locator)
        {
            List<IWebElement> list = FindElements(locator);
            List<string> strings = new List<string>();
            foreach (IWebElement e in list)
            {
                strings.Add(e.Text);
            }
            return strings;
        }

        public void SendKey(By locator, string key)
        {
            try
            {
                FindElement(locator).SendKeys(Keys.Control + "a");
                FindElement(locator).SendKeys(Keys.Delete);
                FindElement(locator).SendKeys(key);
                FindElement(locator).SendKeys(Keys.Escape);

                TestContext.WriteLine("Send [" + key + "] to [" + locator.ToString + "]");
                HTMLReporter.Pass("Sent key [" + key + "] to element located by [" + locator.ToString + "]");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot send key [" + key + "] to element located by [" + locator.ToString + "]");
                HTMLReporter.Fail("Can not send key [" + key + "] to element located by [" + locator.ToString + "]");
                throw ex;
            }
        }
        public void SendKeyNormal(By locator, string key)
        {
            FindElement(locator).SendKeys(key);
        }
        public void SendKeyEnter(By locator, string key)
        {
            FindElement(locator).SendKeys(key);
            FindElement(locator).SendKeys(Keys.Enter);
        }
        public string getTitle()
        {
            try
            {
                string title = driver.Title;
                TestContext.WriteLine("Extract title");
                HTMLReporter.Pass("Title is: " + title);
                return title;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot get current title");
                HTMLReporter.Fail("Title not found");
                throw ex;
            }
        }
        public void ClickElement(By locator)
        {
            try
            {
                FindElement(locator).Click();
                TestContext.WriteLine("Click locator [" + locator.ToString + "]");
                HTMLReporter.Pass("Clicked to Element" + locator.ToString);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot click to element located by [" + locator.ToString + "]");
                HTMLReporter.Fail("Can not Click to Element in Locator: " + locator.ToString);
                throw ex;
            }
        }
        public void Wait(int milisecond)
        {
            Thread.Sleep(milisecond);
        }
        public void WaitUntil(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(FindElement(locator)));
        }
        public string CheckInputText(By locator)
        {
            return FindElement(locator).GetAttribute("value");
        }
        public void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
                TestContext.WriteLine("Click element [" + element.ToString + "]");
                HTMLReporter.Pass("Clicked to Element: " + element.ToString);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot click to element located by [" + element.ToString + "]");
                HTMLReporter.Fail("Can not Click to Element" + element.ToString);
                throw ex;
            }
        }
        public void SendKey(IWebElement element, string key)
        {
            try
            {
                element.SendKeys(key);
                TestContext.WriteLine("Send [" + key + "] to [" + element.ToString + "]");
                HTMLReporter.Pass("Sent key [" + key + "] to element located by [" + element.ToString + "]");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot send key [" + key + "] to element located by [" + element.ToString + "]");
                HTMLReporter.Fail("Can not send key [" + key + "] to element located by [" + element.ToString + "]");
                throw ex;
            }
        }

        public bool findText(string text)
        {
            if (driver.PageSource.Contains(text))
            {
                TestContext.WriteLine("Finding [" + text + "]");
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
                var.SelectByText(value);
                TestContext.WriteLine("Select dropdown by value: " + value);
                HTMLReporter.Pass("Select value " + value);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot get current dropdown value");
                HTMLReporter.Fail("Value not found");
                throw ex;
            }
        }
        public string GetText(By locator)
        {
            try
            {
                string var = FindElement(locator).Text;
                TestContext.WriteLine("Extract Text");
                HTMLReporter.Pass("Text is: " + var);
                return var;
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot get current text");
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
                TestContext.WriteLine("Hover element" + locator);
                HTMLReporter.Pass("Hover Element " + locator);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot Hover this element");
                HTMLReporter.Fail("Element not found");
                throw ex;
            }
        }

        private void SendKeysSlowly(int delay, string text, IWebElement element)
        {
            foreach (char str in text)
            {
                element.SendKeys(str.ToString());
                Thread.Sleep(delay);
            }
        }
        public void SendKeyWithDelay(int delay, string text, By locator)
        {
            FindElement(locator).SendKeys(Keys.Control + "a");
            FindElement(locator).SendKeys(Keys.Delete);
            SendKeysSlowly(delay, text, FindElement(locator));
        }
        public void ClearText(By locator)
        {
            FindElement(locator).SendKeys(Keys.Control + "a");
            FindElement(locator).SendKeys(Keys.Delete);
        }
        public string GetInputText(By locator)
        {
            return FindElement(locator).GetAttribute("value");
        }
        public string ConvertDateForLogin(string date)
        {
            DateTime asDate = DateTime.ParseExact(date,
               "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("ddMMyyyy");
        }
        public void WaitUntilTextPresent(By locator, string input)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, input));
        }
        public bool FindNoSuchElements(By locator)
        {
            bool found = false;
            if (FindElements(locator).Count == 0)
            {
                return found = true;
            }
            else if (FindElements(locator).Count > 0)
                return found = false;
            return true;
        }

        public string SelectedDropdownText(By locator)
        {

            return FindElement(locator).GetAttribute("title");

        }
        public bool CheckSelectBox(By locator)
        {
            bool se = FindElement(locator).Selected;
            return se;
        }
        public void ClickElementAction(By locator)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(FindElement(locator)).Click().Build().Perform();


        }

        public void SendKeysAction(By locator, string key)
        {
            Actions action = new Actions(driver);
            action.SendKeys(FindElement(locator), key).Click().Build().Perform();


        }
        public void ElementClick(By element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click()", FindElement(element));
        }
        public void ElementTypeChange(By element, string input)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].type = arguments[1]", FindElement(element), input);
        }
        public void ElementChangeValue(By element, string input)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].value= 'arguments[1]';", FindElement(element), input);
        }
        public void SendKeyWithoutExit(By locator, string key)
        {
            try
            {
                FindElement(locator).SendKeys(Keys.Control + "a");
                FindElement(locator).SendKeys(Keys.Delete);
                FindElement(locator).SendKeys(key);
                TestContext.WriteLine("Send [" + key + "] to [" + locator.ToString + "]");
                HTMLReporter.Pass("Sent key [" + key + "] to element located by [" + locator.ToString + "]");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Cannot send key [" + key + "] to element located by [" + locator.ToString + "]");
                HTMLReporter.Fail("Can not send key [" + key + "] to element located by [" + locator.ToString + "]");
                throw ex;
            }
        }
    }
}
