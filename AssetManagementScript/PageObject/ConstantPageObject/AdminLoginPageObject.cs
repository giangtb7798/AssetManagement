using AssetManagementFramework.Driver;
using OpenQA.Selenium;

namespace AssetManagementScript.PageObject.ConstantAdmin
{
    public class AdminLoginPage : WebDriverAction
    {
        By Admin_Login = By.XPath("");
        By Password_Login = By.XPath("");
        By Login_btn = By.XPath("");
        public AdminLoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void AdminLogin()
        {
            SendKey(Admin_Login, "admin");
        }
        public void PasswordLogin()
        {
            SendKey(Password_Login, "password");
        }
        public void ClickLoginButton()
        {
            ClickElement(Login_btn);
        }
    }
}
