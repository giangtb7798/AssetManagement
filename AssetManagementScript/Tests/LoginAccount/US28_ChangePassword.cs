using AssetManagementFramework;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.Constant;
using AssetManagementScript.PageObject.ConstantAdmin;
using NUnit.Framework;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    [Parallelizable(ParallelScope.Self)]
    public class US28_ChangePassword : TestSetup
    {
        public US28_ChangePassword(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void ChangePassword()
        {
            // Input Username Password and Click
            UserLoginPage userLoginPage = new UserLoginPage(driver);
            userLoginPage.UserLogin("huong");
            userLoginPage.PasswordLogin("Huong1234567");
            userLoginPage.ClickLoginButton();

            //Change password
            ChangePasswordPage changePasswordPage = new ChangePasswordPage(driver);
            changePasswordPage.ClickMenuButton();
            changePasswordPage.ClickChangePasswordButton();
            changePasswordPage.OldPassword("Huong1234567");
            changePasswordPage.NewPassword("Huong123456");
            changePasswordPage.ClickSaveButton();

            //Verify Change Password Successfully

            Assert.That(changePasswordPage.GetMessageSuccessful().Contains("Your password has been changed successfully"), "Password is not able to change");

            // Input Username Password and Click
            userLoginPage.UserLogin("huong");
            userLoginPage.PasswordLogin("Huong123456");
            userLoginPage.ClickLoginButton();
        }
    }
}
