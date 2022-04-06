using AssetManagementFramework;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.Constant;
using NUnit.Framework;

namespace AssetManagementScript.Tests
{
    public class US28_ChangePassword : TestSetup
    {
        public US28_ChangePassword(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {
            // Input Username Password and Click
            UserLoginPageObject userLoginPageObject = new UserLoginPageObject(driver);
            userLoginPageObject.UserLogin("user");
            userLoginPageObject.PasswordLogin("user");
            userLoginPageObject.ClickLoginButton();

            //Change password
            ChangePasswordPageObject changePasswordPageObject = new ChangePasswordPageObject(driver);
            changePasswordPageObject.OldPassword("user");
            changePasswordPageObject.NewPassword("oki");
            changePasswordPageObject.ClickSaveButton();

            //Verify Change Password Successfully

            Assert.That(changePasswordPageObject.GetMessageSuccessful().Contains("Your password has been changed successfully"),"Password is not able to change");
        }
    }
}
