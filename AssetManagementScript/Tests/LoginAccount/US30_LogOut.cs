using AssetManagementFramework;
using AssetManagementScript.PageObject.Constant;
using AssetManagementScript.PageObject.ConstantAdmin;
using NUnit.Framework;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    [Parallelizable(ParallelScope.Self)]
    public class US30_LogOut : TestSetup
    {
        public US30_LogOut(string browser, string osPlatform) : base(browser, osPlatform)
        {
        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AdminLogOut()
        {
            //logIn
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver);
            adminLoginPage.AdminLogin();
            adminLoginPage.PasswordLogin();
            adminLoginPage.ClickLoginButton();

            //LogOut
            LogOutPage logOutPageObject = new LogOutPage(driver);
            logOutPageObject.ClickMenuButton();
            logOutPageObject.ClickLogOutButton();
            logOutPageObject.ClickConFirmButton();

            //Confirm LogOut successfully
            logOutPageObject.GetTextLogInBtn();
        }
        [Test]
        public void UserLogOut()
        {
            //logIn
            UserLoginPage userLoginPageObject = new UserLoginPage(driver);
            userLoginPageObject.UserLogin("Admin");
            userLoginPageObject.PasswordLogin("Admin");
            userLoginPageObject.ClickLoginButton();

            //LogOut
            LogOutPage logOutPageObject = new LogOutPage(driver);
            logOutPageObject.ClickMenuButton();
            logOutPageObject.ClickLogOutButton();
            logOutPageObject.ClickConFirmButton();

            //Confirm LogOut successfully
            logOutPageObject.GetTextLogInBtn();
        }
    }
}
