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
            int TotalRow = manageUserPage.StateList().Count;
            ManageUserService manageUserService = new ManageUserService();
            for (int i = 0; i < TotalRow; i++)
            {
                string userListByIndex = manageUserService.SerializeData(manageUserPage.UserListByIndex(i + 1));
                string userListAPIByIndex = manageUserService.SerializeData(manageUserService.GetUserDataByIndex(_token, i));
                Assert.That(userListByIndex, Is.EqualTo(userListAPIByIndex), "User List from UI is different with API");
            }

            //input Staff code Search
            manageUserPage.InputSeachBox("SD0001");

            //Check Staff Code Search
            List<string> listStaffCode = manageUserPage.StaffCodeList();
            Assert.That(listStaffCode.Contains("SD0001"), "No such user with input Staffcode condition");
            manageUserPage.ClearSearch();

            //Input User name search
            manageUserPage.InputSeachBox("nghialt");

            //Check User name result
            List<string> listUsername = manageUserPage.UserNameList();
            Assert.That(listUsername.Contains("nghialt"), "No such user with input Username condition");
            manageUserPage.ClearSearch();

            //Input Full name search
            manageUserPage.InputSeachBox("Nghia Le Trung");

            //Check Full name result
            List<string> listFullname = manageUserPage.FullNameList();
            Assert.That(listFullname.Contains("Nghia Le Trung"), "No such user with input full name condition");
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
            Random rnd = new Random();
            int UsernameRandom = rnd.Next(0, 99999);
            UserDataObject InputNewUserData = new UserDataObject("Automation" + UsernameRandom, "52", "02/02/1996", "Male", "04/04/2022", "Admin");
            CreateNewUserPage createNewUserPage = new(driver);
            testDriverAction.CreateNewUser(InputNewUserData);
            UserDataObject userInputData = createNewUserPage.GetUserInputData();
            Console.WriteLine(userInputData.code);
            createNewUserPage.SubmitNewUser();

            ////Edit User Page
            //ManageUserPage manageUserPage = new(driver);
            //manageUserPage.ClickEditUserByIndex(1);

            ////Compare UI data with InputData
            //ManageUserService manageUserService = new ManageUserService();
            //EditUserPage editUserPage = new(driver);
            //UserDataObject EditInputData = editUserPage.GetInputData();
            //string InputNewUserDataSerialized = manageUserService.SerializeData(userInputData);
            //string EditInputDataSerialized = manageUserService.SerializeData(EditInputData);

            //Assert.AreEqual(InputNewUserDataSerialized, EditInputDataSerialized, "Input data is not equal with Edit User data UI");

            ////edit user data
            //UserDataObject editedUserData = new UserDataObject("05/02/1997", "female", "04/12/2022", "staff");
            //testDriverAction.EditUser(editedUserData);
            //UserDataObject InputDataForAPITest = editUserPage.GetInputDataForAPITest();
            //editUserPage.SaveEdit();

            ////Compare with API
            //UserDataObject UserDataAPI = manageUserService.UserDataAPI(_token, manageUserPage.StaffCodeByIndex(1));
            //string UserDataAPISerialized = manageUserService.SerializeData(UserDataAPI);
            //string InputDataForAPITestSerialized = manageUserService.SerializeData(InputDataForAPITest);
            //Assert.AreEqual(InputDataForAPITestSerialized, UserDataAPISerialized, "Edited Input is not equal with API");

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
            //UserDataObject UserDisplay = manageUserPage.DisplayRowDataByIndex(1);
            //string InputUserUISerialized = manageUserService.SerializeData(InputUserUI);
            //string UserDisplaySerialized = manageUserService.SerializeData(UserDisplay);
            //Assert.AreEqual(InputUserUISerialized, UserDisplaySerialized, "Input data is inconsistent with first row display data");

            //Check new user input data with API
            //UserDataObject UserDataAPI = manageUserService.UserDataAPI(_token, manageUserPage.StaffCodeByIndex(1));
            //string InputUserAPISerialized = manageUserService.SerializeData(InputUserAPI);
            //string UserDataAPISerialized = manageUserService.SerializeData(UserDataAPI);
            //Assert.AreEqual(InputUserAPISerialized, UserDataAPISerialized, "Input data is inconsistent with api data");

            //Check new user input data with user detail
            manageUserPage.ClickRowByIndex(1);
            UserDataObject userDetailData = manageUserPage.UserDetailData();

            Console.WriteLine(userDetailData.userName);
            //string InputUserDetailSerialized = manageUserService.SerializeData(InputUserDetail);
            //string UserDetailDataSerialized = manageUserService.SerializeData(userDetailData);
            //Assert.AreEqual(InputUserDetailSerialized, UserDetailDataSerialized, "Input data is inconsistent with user detail data");
            //manageUserPage.CloseUserDetail();

            ////Logout
            //testDriverAction.Logout();

            ////Login with newly created account and confirm logged in
            //testDriverAction.Login(InputNewUserData.userName, InputNewUserData.firstTimePassword);
            //HomePage homePage = new(driver);
            //Assert.That(homePage.GetPopupTitle().Equals("Change password"), "User have not logged in yet");
        }
    }
}
