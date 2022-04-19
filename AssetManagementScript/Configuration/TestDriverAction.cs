using AssetManagementScript.DTO;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.ManageAsset;
using AssetManagementScript.PageObject.ManagerUser;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.Configuration
{
    public class TestDriverAction
    {
        private IWebDriver driver;

        public TestDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void CreateNewUser(UserDataObject user)
        {

            HomePage homePage = new(driver);
            homePage.ManageUser();

            //Click add user button
            ManageUserPage manageUserPage = new(driver);
            manageUserPage.ClickAddUser();

            //Create new user
            CreateNewUserPage createNewUserPage = new(driver);
            createNewUserPage.CreateNewUSer(user.firstName, user.lastName, user.doB, user.gender, user.joinDate, user.type);

        }
        public void CreateNewAsset(AssetDataObject asset)
        {
            //Click Manage User Tab
            HomePage homePage = new(driver);
            homePage.ManageAsset();

            //Click add asset button
            ManageAssetPage manageAssetPage = new(driver);
            manageAssetPage.CreateNewAsset();

            //Create new Asset
            CreateNewAssetPage createNewAssetPage = new(driver);
            createNewAssetPage.CreateNewAsset(asset.assetName, asset.categoryName, asset.specification, asset.installedDate, asset.state);
        }
        public void Login(string username, string password)
        {
            LoginPage loginPage = new(driver);
            loginPage.Login(username, password);
        }
        public void Logout()
        {
            NavigationPage navigationPage = new(driver);
            navigationPage.Logout();
        }
        public void EditUser(UserDataObject user)
        {
            EditUserPage editUserPage = new(driver);
            editUserPage.EditUser(user.gender, user.joinDate, user.type);
        }
        public void EditAsset(AssetDataObject asset)
        {
            EditAssetPage editAssetPage = new(driver);
            editAssetPage.EditAsset(asset.assetName, asset.specification, asset.installedDate, asset.state);
        }
        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
