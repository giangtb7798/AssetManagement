using AssetManagementFramework.Driver;
using AssetManagementScript.Configuration;
using OpenQA.Selenium;

namespace AssetManagementScript.PageObject.ConstantAdmin
{
    public class AdminLoginPage : WebDriverAction
    {
        By Admin_Login = By.XPath("//input[@name='username']");
        By Password_Login = By.XPath("//input[@name='password']");
        By Login_btn = By.XPath("//button[@class='btn btn-primary']");
        By Verify_Text = By.XPath("//div[text()='Admin Page']");
        public AdminLoginPage(IWebDriver driver) : base(driver)
        {
        }
        public void AdminLogin()
        {
            SendKey(Admin_Login, Configuration.Constant.UserName);
        }
        public void PasswordLogin()
        {
            SendKey(Password_Login, "Admin12345678");
        }
        public void ClickLoginButton()
        {
            ClickElement(Login_btn);
        }
        public string GetMessageSuccessful()
        {
            return GetText(Verify_Text);
        }
    }
}
