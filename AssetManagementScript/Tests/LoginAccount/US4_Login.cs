using AssetManagementFramework;
using AssetManagementScript.PageObject.Constant;
using AssetManagementScript.PageObject.ConstantAdmin;
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
            Assert.That(adminLoginPage.GetMessageSuccessful().Contains("Admin Page"),"log in failure");
        }
        [Test, TestCaseSource("AddBrowserConfs")]
        public void UserLogin(string UserName, string PassWord)
        {
            // Input Username Password and Click
            UserLoginPage userLoginPage = new UserLoginPage(driver);
            userLoginPage.UserLogin(UserName);
            userLoginPage.PasswordLogin(PassWord);
            userLoginPage.ClickLoginButton();
        }
    }
}
