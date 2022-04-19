using AssetManagementFramework;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using AssetManagementScript.PageObject;
using AssetManagementScript.PageObject.ManageAsset;
using AssetManagementScript.Service;
using AssetManagementScript.TestSource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    [Parallelizable(ParallelScope.Self)]
    public class ManageAssetTest : ProjectTestSetupHN
    {
        public ManageAssetTest(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US8_ViewAssetList(string username, string password)
        {
            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Click Manage Asset Tab
            HomePage homePage = new(driver);
            homePage.ManageAsset();
            ManageAssetPage manageAssetPage = new(driver);

            //Input Search Box Asset Code
            manageAssetPage.InputSeachBox("AS000001");

            //Check Asset Code available
            List<string> AssetCodeList = manageAssetPage.AssetCodeList();
            Assert.That(AssetCodeList.Contains("AS000001"), "No such Asset with input Asset Code condition");
            manageAssetPage.ClearSearch();

            //Input Search Box Asset Name
            manageAssetPage.InputSeachBox("Alienware X17");

            //Check Asset name available
            List<string> AssetNameList = manageAssetPage.AssetNameList();
            Assert.That(AssetNameList.Contains("Alienware X17"), "No such Asset with input Asset Name condition");
            manageAssetPage.ClearSearch();

            //Check State Not Available filer
            manageAssetPage.FilterStateNotAvailable();
            List<string> StateList = manageAssetPage.StateList();
            foreach (string state in StateList)
            {
                Assert.That(state.Equals("Not available"), "Not all State are Not Available");
            }
            manageAssetPage.FilterStateDefault();

            //Check Laptop Category filer
            manageAssetPage.FilterCategoryLaptop();
            List<string> CategoryList = manageAssetPage.CategoryList();
            foreach (string state in CategoryList)
            {
                Assert.That(state.Equals("Laptop"), "Not all Category are Laptop");
            }
            manageAssetPage.FilterCategoryDefault();

            //Click row 1 to show asset detail
            manageAssetPage.ClickRowByIndex(1);
            ManageAssetService manageAssetService = new();
            AssetDataObject AssetDetail = manageAssetPage.AssetDetail();
            Console.WriteLine(AssetDetail.assetCode);
            AssetDataObject AssetDetailAPI = manageAssetService.UserDataAPI(_token, AssetDetail.assetCode);

            Console.WriteLine(AssetDetailAPI.assetName);
            string AssetDetailSerialized = manageAssetService.SerializeData(AssetDetail);
            string AssetDetailAPISerialized = manageAssetService.SerializeData(AssetDetailAPI);
            Assert.AreEqual(AssetDetailSerialized, AssetDetailAPISerialized, "Asset Detail UI is inconsistent with API");
        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US9_CreateAsset(string username, string password)
        {
            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Click Manage Asset Tab
            AssetDataObject InputAsset = new AssetDataObject("Dell G5", "Laptop", "Day la laptop cua Giang", "02/05/2022", "Available");
            CreateNewAssetPage createNewAssetPage = new(driver);
            testDriverAction.CreateNewAsset(InputAsset);
            AssetDataObject InputAssetUI = createNewAssetPage.GetAssetInputDataForUITest();
            createNewAssetPage.SaveAsset();

            // Check Input with UI
            ManageAssetPage manageAssetPage = new(driver);
            ManageAssetService manageAssetService = new();
            AssetDataObject UIAssetData = manageAssetPage.DisplayRowDataByIndex(1);
            string InputAssetUISerialized = manageAssetService.SerializeData(InputAssetUI);
            string UIAssetDataSerialized = manageAssetService.SerializeData(UIAssetData);
            Assert.AreEqual(InputAssetUISerialized, UIAssetDataSerialized, "UI data is inconsistent with Input Asset");

        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US9_AddNewCategory(string username, string password)
        {
            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Input User data 
            AssetDataObject InputAsset = new AssetDataObject("Dell G5", "Laptop", "Day la laptop cua a Giang", "02/05/2022", "Available");
            CreateNewAssetPage createNewAssetPage = new(driver);
            testDriverAction.CreateNewAsset(InputAsset);

            //Create new asset category
            string var = "Day la test category 7";
            createNewAssetPage.CreatNewCategory(var, "anh10");

            //Check new Asset category is available
            Assert.That(createNewAssetPage.CheckCurrentCategory(var).Equals(var));
        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US10_EditAsset(string username, string password)
        {
            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Input User data 
            AssetDataObject InputAsset = new AssetDataObject("Dell G5 69", "Laptop", "Day la laptop cua a Dao", "02/05/2022", "Available");
            CreateNewAssetPage createNewAssetPage = new(driver);
            testDriverAction.CreateNewAsset(InputAsset);
            createNewAssetPage.SaveAsset();

            //Click edit asset
            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            manageAssetPage.EditAssetByIndex(1);
            EditAssetPage editAssetPage = new(driver);
            AssetDataObject AssetInputForUI = editAssetPage.GetAssetInputForUITest();

            //Assert input with edit data
            ManageAssetService manageAssetService = new();
            string InputAssetSerialized = manageAssetService.SerializeData(InputAsset);
            string AssetInputForUISerialized = manageAssetService.SerializeData(AssetInputForUI);
            Assert.AreEqual(InputAssetSerialized, AssetInputForUISerialized);

            //Edit Asset info
            AssetDataObject inputEditAsset = new AssetDataObject("Iphone13", "haha", "08/04/2022", "Not Available");
            testDriverAction.EditAsset(inputEditAsset);
            AssetDataObject AssetEditedInputForDetail = editAssetPage.GetAssetInputForAssetDetail();
            editAssetPage.SaveEdit();

            //compare edited input with detail
            manageAssetPage.ClickRowByIndex(1);
            AssetDataObject AssetDetail = manageAssetPage.AssetDetailForEditAssetTest();
            string AssetDetailSerialized = manageAssetService.SerializeData(AssetDetail);
            string AssetEditedInputForDetailSerialized = manageAssetService.SerializeData(AssetEditedInputForDetail);
            Assert.AreEqual(AssetEditedInputForDetailSerialized, AssetDetailSerialized, "Edited Asset Input is inconsistent with asset detail");
        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US11_DeleteAsset(string username, string password)
        {

            // <-------------------- Available State ------------------------------------->

            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Input User data 
            AssetDataObject InputAsset = new AssetDataObject("Dell G5 69", "Laptop", "Day la laptop cua a Dao", "02/05/2022", "Available");
            CreateNewAssetPage createNewAssetPage = new(driver);
            //testDriverAction.CreateNewAsset(InputAsset);
            //createNewAssetPage.SaveAsset();

            ////Delete Asset with Available state
            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            //string recentCreatedAssetCode = manageAssetPage.AssetCodeByIndex(1);
            //manageAssetPage.DeleteAssetByIndex(1);
            //manageAssetPage.ConfirmDeleteAsset();

            ////Check if deleted asset unavailable
            //manageAssetPage.InputSeachBox(recentCreatedAssetCode + " ");
            //Assert.That(manageAssetPage.FindNoElements1(recentCreatedAssetCode), "Deleted Asset still available in the UI, please try to find error");
            //manageAssetPage.ClearSearch();

            //// <-------------------- Not Available State ------------------------------------->

            ////Input User data 
            //AssetDataObject InputAsset2 = new AssetDataObject("Dell G5 69", "Laptop", "Day la laptop cua a Giang", "02/05/2022", "Not Available");
            //testDriverAction.CreateNewAsset(InputAsset2);
            //createNewAssetPage.SaveAsset();

            ////Delete Asset with Not Available state
            //string recentCreatedAssetCode2 = manageAssetPage.AssetCodeByIndex(1);
            //manageAssetPage.DeleteAssetByIndex(1);
            //manageAssetPage.ConfirmDeleteAsset();

            //// Check if deleted asset unavailable
            //manageAssetPage.InputSeachBox(recentCreatedAssetCode2 + " ");
            //Assert.That(manageAssetPage.FindNoElements1(recentCreatedAssetCode), "Deleted Asset still available in the UI, please try to find error");
            //manageAssetPage.ClearSearch();

            // <-------------------- Waiting for recycling ------------------------------------->

            //Input User data 
            testDriverAction.CreateNewAsset(InputAsset);
            createNewAssetPage.SaveAsset();
            string recentCreatedAssetCode3 = manageAssetPage.AssetCodeByIndex(1);

            //Change asset state to Waiting for recycling
            manageAssetPage.EditAssetByIndex(1);
            EditAssetPage editAssetPage = new(driver);
            editAssetPage.State("waiting for recycling");
            editAssetPage.SaveEdit();


            //Delete Asset with Waiting for recycling state
            manageAssetPage.DeleteAssetByIndexAndState(1, "Waiting for recycling");
            manageAssetPage.ConfirmDeleteAsset();

            // Check if deleted asset unavailable
            manageAssetPage.SelectStateByText("Waiting for recycling");
            manageAssetPage.InputSeachBox(recentCreatedAssetCode3 + " ");
            Assert.That(manageAssetPage.FindNoElements(), "Deleted Asset still available in the UI, please try to find error");
            manageAssetPage.ClearSearch();

            // <-------------------- Recycled ------------------------------------->

            //Input User data 
            testDriverAction.CreateNewAsset(InputAsset);
            createNewAssetPage.SaveAsset();
            string recentCreatedAssetCode4 = manageAssetPage.AssetCodeByIndex(1);

            //Change asset state to Waiting for recycling
            manageAssetPage.EditAssetByIndex(1);
            editAssetPage.State("recycled");
            editAssetPage.SaveEdit();

            //Delete Asset with Waiting for recycling state
            manageAssetPage.DeleteAssetByIndexAndState(1, "Recycled");
            manageAssetPage.ConfirmDeleteAsset();

            // Check if deleted asset unavailable
            manageAssetPage.SelectStateByText("Recycled");
            manageAssetPage.InputSeachBox(recentCreatedAssetCode4 + " ");
            Assert.That(manageAssetPage.FindNoElements(), "Deleted Asset still available in the UI, please try to find error");
            manageAssetPage.ClearSearch();

            // <-------------------- Historical Assignment: Not Available State (Not implement yet)------------------------------------->

            manageAssetPage.SelectStateByText("State");
            manageAssetPage.InputSeachBox("CS000002"); // this should be changed to completed asset.
            manageAssetPage.DeleteAssetByIndex(1);
            Assert.That(manageAssetPage.HistoricalAssetWarning().Equals("Cannot Delete Asset"), "Cannot delete asset Popup does not show up, please try to find error with this asset");


        }
        [Test]
        [TestCaseSource(typeof(UILoginAccount), "GetTestData")]
        public void US11_CancelDelete(string username, string password)
        {
            //login UI
            TestDriverAction testDriverAction = new(driver);
            testDriverAction.Login(username, password);

            //Input User data 
            AssetDataObject InputAsset = new AssetDataObject("Dell G5 69", "Laptop", "Day la laptop cua Giang", "02/05/2022", "Available");
            CreateNewAssetPage createNewAssetPage = new(driver);
            testDriverAction.CreateNewAsset(InputAsset);
            createNewAssetPage.SaveAsset();

            //Delete Asset with Available state
            ManageAssetPage manageAssetPage = new ManageAssetPage(driver);
            string recentCreatedAssetCode = manageAssetPage.AssetCodeByIndex(1);
            manageAssetPage.DeleteAssetByIndex(1);
            manageAssetPage.CancelDeleteAsset();

            //Assert That Asset Code is still available
            manageAssetPage.InputSeachBox(recentCreatedAssetCode);
            Assert.That(manageAssetPage.AssetCodeByIndex(1).Equals(recentCreatedAssetCode), "This Asset Code is unavailable after click cancel delete, please try again later");
        }
    }
}
