using AssetManagementFramework;
using AssetManagementScript.PageObject.Constant;
using AssetManagementScript.PageObject.ConstantAdmin;
using NUnit.Framework;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LastestConfigurations))]
    [Parallelizable(ParallelScope.Self)]
    internal class US4_Login : TestSetup
    {
        public US4_Login(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AdminLogin()
        {
            // Input Username Password and Click
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver);
            adminLoginPage.AdminLogin();
            adminLoginPage.PasswordLogin();
            adminLoginPage.ClickLoginButton();
        }
        [Test]
        public void UserLogin()
        {
            // Input Username Password and Click
            UserLoginPageObject userLoginPageObject = new UserLoginPageObject(driver);
            userLoginPageObject.UserLogin("user");
            userLoginPageObject.PasswordLogin("user");
            userLoginPageObject.ClickLoginButton();
        }
    }
}
