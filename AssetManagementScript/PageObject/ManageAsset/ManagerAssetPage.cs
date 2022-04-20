using AssetManagementFramework.Driver;
using AssetManagementScript.DTO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.ManageAsset
{
    public class ManageAssetPage : WebDriverAction
    {
        By _CreateNewAsset = By.XPath("//span[contains(text(),'Create new asset')]");
        By _SearchBox = By.XPath("//input[@id='search']");
        By _SearchBoxBtn = By.XPath("//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']");
        By _StateSelect = By.XPath("//div[@style='margin-bottom: 0px;'][1]");
        By _CategorySelect = By.XPath("//div[@style='margin-bottom: 0px;']");
        By _ClearState = By.XPath("//span[@class='ant-select-clear']");
        By _StateAvailable = By.XPath("//input[@id='asset-add-input-state-available']");
        By _StateNotAvailable = By.XPath("//div[@class='ant-select-item-option-content' and text()='Not available']");
        By _StateDefault = By.XPath("//div/select/option[text()='State']");
        By _StateWaitingForRecycling = By.XPath("//div[@class='ant-select-item-option-content' and text()='Waiting for recycling']");
        By _StateRecycled = By.XPath("//div[@class='ant-select-item-option-content' and text()='Recycled']");
        By _CategoryLaptop = By.XPath("//div[@class='ant-select-item-option-content' and text()='Laptop']");
        By _CategoryDefault = By.XPath("//div/select/option[text()='Category']");
        By _StateFilter = By.XPath("(//select[@class='form-control'])[1]");
        By _CategoryFilter = By.XPath("(//select[@class='form-control'])[2]");


        string _AssetCode = "(//td[count(//th[.='Asset Code']/preceding-sibling::th)+1]){0}";
        string _AssetName = "(//td[count(//th[.='Asset Code']/preceding-sibling::th)+2]){0}";
        string _Category = "(//td[count(//th[.='Asset Code']/preceding-sibling::th)+3]){0}";
        string _State = "(//td[count(//th[.='Asset Code']/preceding-sibling::th)+4]){0}";
        string _AssetDetail = "//table[@class='AssetPage_shuModal__It91k']//tr{0}//td//span[1]";

        string _EditAssetBtn = "//tr{0}//td[@class='ant-table-cell']//span[@aria-label='edit']";
        string _DeletetAssetBtn = "//tr{0}//td[@class='ant-table-cell']//span[@aria-label='close-circle']";
        By _ConfirmDelete = By.XPath("//span[text()='Delete']");
        By _CancelDelete = By.XPath("//span[text()='Cancel']");
        By _DeleteAssetWarningTitle = By.XPath("//div[text()='Cannot Delete Asset']");

        public ManageAssetPage(IWebDriver driver) : base(driver)
        {
        }
        public void CreateNewAsset()
        {
            ClickElement(_CreateNewAsset);
        }
        public void InputSeachBox(string input)
        {
            ClickElement(_SearchBox);
            SendKeyWithDelay(300, input, _SearchBox);
            ClickElement(_SearchBoxBtn);
            Wait(3000);
        }
        public string AssetCodeByIndex(int index)
        {
            string assetCode = string.Format(_AssetCode, "[" + index + "]");
            return GetText(By.XPath(assetCode));
        }
        public void EditAssetByIndex(int index)
        {
            string edit = string.Format(_EditAssetBtn, "[" + index + "]");
            ClickElement(By.XPath(edit));
            Wait(3000);
        }
        public void DeleteAssetByIndexAndState(int index, string state)
        {
            SelectStateByText(state);
            Wait(1000);
            string delete = string.Format(_DeletetAssetBtn, "[" + index + "]");
            WaitUntil(By.XPath(delete));
            ClickElement(By.XPath(delete));
            Wait(2000);
        }
        public void DeleteAssetByIndex(int index)
        {
            string delete = string.Format(_DeletetAssetBtn, "[" + index + "]");
            WaitUntil(By.XPath(delete));
            ClickElement(By.XPath(delete));
            Wait(1000);
        }
        public string AssetNameByIndex(int index)
        {
            string assetName = string.Format(_AssetName, "[" + index + "]");
            return GetText(By.XPath(assetName));
        }
        public string CategoryByIndex(int index)
        {
            string category = string.Format(_Category, "[" + index + "]");
            return GetText(By.XPath(category));
        }
        public string StateByIndex(int index)
        {
            string state = string.Format(_State, "[" + index + "]");
            return GetText(By.XPath(state));
        }
        public List<string> StateList()
        {
            string state = string.Format(_State, "");
            return ElementsToListText(By.XPath(state));
        }
        public List<string> CategoryList()
        {
            string category = string.Format(_Category, "");
            return ElementsToListText(By.XPath(category));
        }
        public List<string> AssetCodeList()
        {
            string assetCode = string.Format(_AssetCode, "");
            return ElementsToListText(By.XPath(assetCode));
        }
        public List<string> AssetNameList()
        {
            string assetName = string.Format(_AssetName, "");
            return ElementsToListText(By.XPath(assetName));
        }
        public void ClearSearch()
        {
            ClearText(_SearchBox);
            Wait(250);
        }
        public void FilterStateNotAvailable()
        {
            goToUrl("https://group2reactjs.azurewebsites.net/#/assets");
            Wait(6000);
            ClickElement(_StateSelect);
            ClickElement(_StateNotAvailable);
            WaitUntilTextPresent(By.XPath(string.Format(_State, "[" + 1 + "]")), "Not available");
            Wait(500);
        }
        public void FilterStateDefault()
        {
            ClickElement(_ClearState);
            Wait(500);
        }
        public void FilterCategoryDefault()
        {
            ClickElement(_ClearState);
            Wait(500);
        }

        public void FilterCategoryLaptop()
        {
            Wait(6000);
            ClickElement(_CategorySelect);
            ClickElement(_CategoryLaptop);
            WaitUntilTextPresent(By.XPath(string.Format(_Category, "[" + 1 + "]")), "Laptop");
            Wait(500);
        }
        public void ClickRowByIndex(int index)
        {
            string assetcode = string.Format(_AssetCode, "[" + index + "]");
            ClickElement(By.XPath(assetcode));
            Wait(3000);
        }
        public AssetDataObject AssetDetail()
        {
            AssetDataObject assetDataObject = new AssetDataObject
            {
                assetCode = GetText(By.XPath(string.Format(_AssetDetail, "[" + 1 + "]"))),
                assetName = GetText(By.XPath(string.Format(_AssetDetail, "[" + 2 + "]"))),
                categoryName = GetText(By.XPath(string.Format(_AssetDetail, "[" + 3 + "]"))),
                state = GetText(By.XPath(string.Format(_AssetDetail, "[" + 6 + "]"))),
            };
            return assetDataObject;
        }
        public AssetDataObject AssetDetailForEditAssetTest()
        {
            AssetDataObject assetDataObject = new AssetDataObject
            {
                assetName = GetText(By.XPath(string.Format(_AssetDetail, "[" + 2 + "]"))),
                categoryName = GetText(By.XPath(string.Format(_AssetDetail, "[" + 3 + "]"))),
                specification = GetText(By.XPath(string.Format(_AssetDetail, "[" + 4 + "]"))),
                state = GetText(By.XPath(string.Format(_AssetDetail, "[" + 6 + "]"))),
            };
            return assetDataObject;
        }
        public AssetDataObject DisplayRowDataByIndex(int index)
        {
            AssetDataObject list = new AssetDataObject
            {
                assetName = AssetNameByIndex(index),
                categoryName = CategoryByIndex(index),
                state = StateByIndex(index),
            };

            return list;
        }
        public void ConfirmDeleteAsset()
        {
            ClickElement(_ConfirmDelete);
            Wait(2000);
        }
        public void CancelDeleteAsset()
        {
            ClickElement(_CancelDelete);
        }

        public bool FindNoElements()
        {
            Wait(1000);
            string assetcode = string.Format(_AssetCode, "");
            return FindNoSuchElements(By.XPath(assetcode));
        }
        public bool FindNoElements1(string StaffCodeDisable)
        {
            bool Disable = false;
            string staffcode = string.Format(_AssetCode, "");
            string findstaffcode = GetText(By.XPath(staffcode));
            if (StaffCodeDisable == findstaffcode)
            {
                return Disable = false;
            }
            return true;
        }
        public void SelectStateByText(string input)
        {
            WaitUntil(By.XPath(string.Format(_State, "")));
            ClickElement(_StateSelect);
            State(input);
            Wait(500);
        }
        public string HistoricalAssetWarning()
        {
            return GetText(_DeleteAssetWarningTitle);
        }
        public void State(string input)
        {

            if (input.ToLower() == "available")
            {
                ClickElement(_StateAvailable);
            }
            else if (input.ToLower() == "not available")
            {
                ClickElement(_StateNotAvailable);
            }
            else if (input.ToLower() == "waiting for recycling")
            {
                ClickElement(_StateWaitingForRecycling);
            }
            else if (input.ToLower() == "recycled")
            {
                ClickElement(_StateRecycled);
            }
        }
    }
}
