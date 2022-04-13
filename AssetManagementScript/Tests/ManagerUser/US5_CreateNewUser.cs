using AssetManagementFramework;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.ConstantAdmin;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.Tests.ManagerUser
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    public class US5_CreateNewUser : TestSetup
    {
        public US5_CreateNewUser(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void CreateNewUser()
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

        }
    }
}
