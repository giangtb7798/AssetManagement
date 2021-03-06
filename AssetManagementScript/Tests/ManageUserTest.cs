using AssetManagementFramework;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.ManagerUser;
using AssetManagementScript.Service;
using AssetManagementScript.TestSource;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    public class ManageUserTest : ProjectTestSetupHN
    {
        public ManageUserTest(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US3_ViewUserList(string username, string password)
        {
            //ManageUserService manageUserService = new ManageUserService();
            //string userListAPIByIndex = manageUserService.SerializeData(manageUserService.GetUserDataByIndex(_token,0));
            //Console.WriteLine(userListAPIByIndex);
            //login UI
            TestDriverAction testDriverAction = new TestDriverAction(driver);
            testDriverAction.Login(username, password);

            //Click Manage User Tab
            HomePage homePage = new(driver);
            homePage.ManageUser();

            //Compare UI with API
            ManageUserPage manageUserPage = new(driver);
            ManageUserService manageUserService = new ManageUserService();
            List<UserDataObject> viewUserList = manageUserPage.GetViewUserList();
            List<UserDataObject> viewUserListAPI = manageUserService.GetListUserDataAPI(_token);
            for (int i = 0; i < viewUserList.Count; i++)
            {
                string viewUserListSerialized = manageUserService.SerializeData(viewUserList);
                string viewUserListAPISerialized = manageUserService.SerializeData(viewUserListAPI);
                Assert.AreEqual(viewUserListSerialized, viewUserListAPISerialized, "View User List is inconsistent with list API user response");
            }

            //input Staff code Search
            manageUserPage.InputSeachBox(viewUserList[0].code);

            //Check Staff Code Search
            List<string> listStaffCode = manageUserPage.StaffCodeList();
            Assert.That(listStaffCode.Contains(viewUserList[0].code), "No such user with input Staffcode condition");
            manageUserPage.ClearSearch();

            //Input User name search
            manageUserPage.InputSeachBox(viewUserList[0].userName);

            //Check User name result
            List<string> listUsername = manageUserPage.UserNameList();
            Assert.That(listUsername.Contains(viewUserList[0].userName), "No such user with input Username condition");
            manageUserPage.ClearSearch();

            //Input Full name search
            manageUserPage.InputSeachBox(viewUserList[0].fullName);

            //Check Full name result
            List<string> listFullname = manageUserPage.FullNameList();
            Assert.That(listFullname.Contains(viewUserList[0].fullName), "No such user with input full name condition");
            manageUserPage.ClearSearch();

            //Check State of displayed user: Admin
            manageUserPage.FilterAdmin();
            List<string> stateList = manageUserPage.StateList();
            foreach (string state in stateList)
            {
                Assert.That(state.Equals("Admin"), "Not all Types are Admin");
            }

            //Check State of displayed user: Staff
            manageUserPage.FilterStaff();
            List<string> stateList2 = manageUserPage.StateList();
            foreach (string state in stateList2)
            {
                Assert.That(state.Equals("Staff"), "Not all Types are Staff");
            }
        }

        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US6_EditUser(string username, string password)
        {
            //login
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Create new user
            string UsernameRandom = testDriverAction.RandomString(6);
            UserDataObject InputNewUserData = new UserDataObject("Automation" + UsernameRandom, "test", "02/02/1996", "Male", "04/04/2022", "Admin");
            CreateNewUserPage createNewUserPage = new(driver);
            testDriverAction.CreateNewUser(InputNewUserData);
            UserDataObject userInputData = createNewUserPage.GetUserInputData();
            Console.WriteLine(userInputData.code);
            createNewUserPage.SubmitNewUser();

            ////Edit User Page
            ManageUserPage manageUserPage = new(driver);
            manageUserPage.ClickEditUserByIndex(1);

            //Compare UI data with InputData
            ManageUserService manageUserService = new ManageUserService();
            EditUserPage editUserPage = new(driver);
            UserDataObject EditInputData = editUserPage.GetInputData();
            string InputNewUserDataSerialized = manageUserService.SerializeData(userInputData);
            string EditInputDataSerialized = manageUserService.SerializeData(EditInputData);

            Assert.AreEqual(InputNewUserDataSerialized, EditInputDataSerialized, "Input data is not equal with Edit User data UI");

            //edit user data
            UserDataObject editedUserData = new UserDataObject("female", "04/12/2022", "staff");
            testDriverAction.EditUser(editedUserData);
            UserDataObject InputDataForAPITest = editUserPage.GetInputDataForAPITest();
            editUserPage.SaveEdit();

            //Compare with API
            string test = manageUserPage.StaffCodeByIndex(1);
            UserDataObject UserDataAPI = manageUserService.UserDataAPI(_token, test);
            string UserDataAPISerialized = manageUserService.SerializeData(UserDataAPI);
            string InputDataForAPITestSerialized = manageUserService.SerializeData(InputDataForAPITest);
            Assert.AreEqual(InputDataForAPITestSerialized, UserDataAPISerialized, "Edited Input is not equal with API");

        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US7_DisableUser(string username, string password)
        {
            //login 
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);


            //Add new User
            string UsernameRandom = testDriverAction.RandomString(6);
            UserDataObject InputNewUserData = new UserDataObject("Automation" + UsernameRandom, "giang", "02/02/1996", "Male", "04/04/2022", "Admin");
            CreateNewUserPage createNewUserPage = new(driver);
            testDriverAction.CreateNewUser(InputNewUserData);

            createNewUserPage.SubmitNewUser();

            //Click Disable User
            ManageUserPage manageUserPage = new ManageUserPage(driver);
            UserDataObject userDisplayData = manageUserPage.UserListByIndex(1);
            manageUserPage.ClickDisableUser(1);

            //Asset fail is okay
            manageUserPage.InputSeachBox(userDisplayData.code);
            Assert.That(manageUserPage.FindNoElements1(userDisplayData.code), "User still there");

        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US5_CreateNewUser(string username, string password)
        {
            //login
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Create new user
            string UsernameRandom = testDriverAction.RandomString(6);
            UserDataObject InputNewUserData = new UserDataObject("Automation" + UsernameRandom, "test", "02/02/1996", "Male", "04/03/2021", "Admin");
            testDriverAction.CreateNewUser(InputNewUserData);

            //Get User input Data
            CreateNewUserPage createNewUserPage = new(driver);
            UserDataObject InputUserUI = createNewUserPage.GetUserInputDataForUITest();
            UserDataObject InputUserAPI = createNewUserPage.GetUserInputDataForAPITest();
            UserDataObject InputUserDetail = createNewUserPage.GetUserInputDetailData();

            createNewUserPage.SubmitNewUser();

            //Confirm navigated back to Manage User
            ManageUserPage manageUserPage = new(driver);
            Assert.That(manageUserPage.GetTitleName().Equals("User List"), "Page has not navigated yet");

            //Check new user input data with Top Row User
            ManageUserService manageUserService = new ManageUserService();
            UserDataObject UserDisplay = manageUserPage.DisplayRowDataByIndex(1);
            string InputUserUISerialized = manageUserService.SerializeData(InputUserUI);
            string UserDisplaySerialized = manageUserService.SerializeData(UserDisplay);
            Assert.AreEqual(InputUserUISerialized, UserDisplaySerialized, "Input data is inconsistent with first row display data");

            //Check new user input data with API
            UserDataObject UserDataAPI = manageUserService.UserDataAPI(_token, manageUserPage.StaffCodeByIndex(1));
            string InputUserAPISerialized = manageUserService.SerializeData(InputUserAPI);
            string UserDataAPISerialized = manageUserService.SerializeData(UserDataAPI);
            Assert.AreEqual(InputUserAPISerialized, UserDataAPISerialized, "Input data is inconsistent with api data");

            //Check new user input data with user detail
            manageUserPage.ClickRowByIndex(1);
            UserDataObject userDetailData = manageUserPage.UserDetailData();
            string InputUserDetailSerialized = manageUserService.SerializeData(InputUserDetail);
            string UserDetailDataSerialized = manageUserService.SerializeData(userDetailData);
            Assert.AreEqual(InputUserDetailSerialized, UserDetailDataSerialized, "Input data is inconsistent with user detail data");
            manageUserPage.CloseUserDetail();

            //Logout
            testDriverAction.Logout();

            //Login with newly created account and confirm logged in
            testDriverAction.Login(InputNewUserData.userName, InputNewUserData.firstTimePassword);
            HomePage homePage = new(driver);
            Console.WriteLine(homePage.GetPopupTitle());
            Assert.That(homePage.GetPopupTitle().Equals("Change Password"), "User have not logged in yet");
        }
    }
}
