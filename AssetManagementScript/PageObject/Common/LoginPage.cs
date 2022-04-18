using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject
{
    public class LoginPage : WebDriverAction
    {
        By _Username = By.XPath("//input[@id='basic_username']");
        By _Password = By.XPath("//input[@id='basic_password']");
        By Login_btn = By.XPath("//span[contains(text(), 'Login')]");

        public LoginPage(IWebDriver driver) : base(driver)
        {

        }
        public void Login(string username, string password)
        {
            SendKey(_Username, username);
            SendKey(_Password, password);
            ClickElement(Login_btn);
        }

    }
}
