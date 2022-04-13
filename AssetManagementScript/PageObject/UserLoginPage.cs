using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.Constant
{
    public class UserLoginPage : WebDriverAction
    {
        By Admin_Login = By.XPath("//input[@name='username']");
        By Password_Login = By.XPath("//input[@name='password']");
        By Login_btn = By.XPath("//button[@class='btn btn-primary']");
        public UserLoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void UserLogin(string UserName)
        {
            SendKey(Admin_Login, UserName);
        }
        public void PasswordLogin(string PassWord)
        {
            SendKey(Password_Login, PassWord);
        }
        public void ClickLoginButton()
        {
            ClickElement(Login_btn);
        }
    }
}
