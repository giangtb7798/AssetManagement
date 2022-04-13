using AssetManagementFramework;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.Constant;
using AssetManagementScript.PageObject.ConstantAdmin;
using AssetManagementScript.TestCaseData;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
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
            Assert.That(adminLoginPage.GetMessageSuccessful().Contains("User List"),"log in failure");
        }
        [Test]
        public void UserLogin()
        {
            // Input Username Password and Click
            UserLoginPage userLoginPage = new UserLoginPage(driver);
            userLoginPage.UserLogin("Huong");
            userLoginPage.PasswordLogin("Huong");
            userLoginPage.ClickLoginButton();
            userLoginPage.GetMessageSuccessful();
            Assert.That(userLoginPage.GetMessageSuccessful().Contains("User Page"), "log in failure");
        }
        [Test]
        public void FisrtAdminLogin()
        {
            //Sign In
            AdminLoginPage adminLoginPage = new AdminLoginPage(driver);
            adminLoginPage.AdminLogin();
            adminLoginPage.PasswordLogin();
            adminLoginPage.ClickLoginButton();

            //Create new user
            CreateNewUserPage createNewUserPage = new CreateNewUserPage(driver);
            createNewUserPage.ClickManageUserMenu();
            createNewUserPage.ClickCreateUserBtn();
            createNewUserPage.InputFirstName("test");
            createNewUserPage.InputLastName("test");
            createNewUserPage.DOB("07071998");
            createNewUserPage.Gender("male");
            createNewUserPage.InputJoinedDate("07071998");
            createNewUserPage.SelectType("admin");
            createNewUserPage.ClickSubmit();

            //LogOut
            LogOutPage logOutPageObject = new LogOutPage(driver);
            logOutPageObject.ClickMenuButton();
            logOutPageObject.ClickLogOutButton();
            logOutPageObject.ClickConFirmButton();

            //login with new user
            UserLoginPage userLoginPage = new UserLoginPage(driver);
            userLoginPage.UserLogin("testt");
            userLoginPage.PasswordLogin("testt@07071998");
            userLoginPage.ClickLoginButton();

            //Change new password
            ChangePasswordFirstTimePage changePasswordFirstTimePage = new ChangePasswordFirstTimePage(driver);
            changePasswordFirstTimePage.InputNewPassword("Giang1234");
            changePasswordFirstTimePage.ClickSaveBtn();

            //LogOut
            logOutPageObject.ClickMenuButton();
            logOutPageObject.ClickLogOutButton();
            logOutPageObject.ClickConFirmButton();

            //signin
            userLoginPage.UserLogin("testt");
            userLoginPage.PasswordLogin("Giang1234");
            userLoginPage.ClickLoginButton();
            userLoginPage.GetMessageSuccessful();
            Assert.That(userLoginPage.GetMessageSuccessful().Contains("You're Login"), "log in failure");
        }
    }
}
