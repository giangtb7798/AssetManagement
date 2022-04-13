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
        By Verify_Text = By.XPath("//div[text()=\"You're Login\"]");
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
        public string GetMessageSuccessful()
        {
            System.Threading.Thread.Sleep(6000);
            goToUrl("https://group5reactjs.azurewebsites.net/login");
            return GetText(Verify_Text);
        }

    }
}
