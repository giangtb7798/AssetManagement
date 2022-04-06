using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.Constant
{
    public class UserLoginPageObject : WebDriverAction
    {
        By Admin_Login = By.XPath("");
        By Password_Login = By.XPath("");
        By Login_btn = By.XPath("");
        public UserLoginPageObject(IWebDriver driver) : base(driver)
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
