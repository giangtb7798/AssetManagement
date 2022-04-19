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
    public class CreateNewAssetPage : WebDriverAction
    {

        By _AssetName = By.XPath("//input[@id='createAsset_assetName']");
        By _Category = By.XPath("//input[@id='createAsset_categoryPrefix']");
        By _CategoryBtn = By.XPath("//span[@class='ant-select-selection-item']");
        By _AddCategoryButton = By.XPath("//a[@class='ant-typography']");
        By _AddCategoryName = By.XPath("//input[@id='createCategory_categoryName']");
        By _AddCategoryPrefix = By.XPath("//input[@id='createCategory_categoryPrefix']");
        By _ConfirmNewCategory = By.XPath("//div[@class='ant-modal-footer']//button[@type='button'][1]");
        string _CategoryList  = "//div[@class='ant-select-item-option-content' and text()='{0}']";
        By _CategoryLaptop = By.XPath("//div[@class='ant-select-item-option-content' and text()='Laptop']");
        By _Specification = By.XPath("//textarea[@id='createAsset_specification']");
        By _InstallDate = By.XPath("//input[@id='createAsset_installedDate']");
        By _StateAvailable = By.XPath("//input[@value='0']");
        By _StateNotAvailable = By.XPath("//input[@value='2']");

        By _SaveBtn = By.XPath("//span[text()='Save']");
        By _CancelBtn = By.XPath("//span[text()='Cancel']");

        public CreateNewAssetPage(IWebDriver driver) : base(driver)
        {
        }
        public void CreateNewAsset(string assetname, string category, string specification, string installDate, string state)
        {
            AssetName(assetname);
            Category(category);
            Specification(specification);
            InstallDate(installDate);
            State(state);
            Wait(3000);
        }
        public string ReplaceState()
        {
            string var = "";
            if (CheckSelectBox(_StateAvailable))
            {
                return var = "Available";
            }
            else
                return var = "Not Available";
        }
        public void AssetName(string input)
        {
            SendKey(_AssetName, input);
        }
        public void Category(string input)
        {
            ClickElement(_Category);
            ClickElement(_CategoryLaptop);
        }
        public void Specification(string input)
        {
            SendKey(_Specification, input);
        }
        public void InstallDate(string input)
        {
            SendKeyEnter(_InstallDate, input);

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
        }
        public AssetDataObject GetAssetInputDataForUITest()
        {
            AssetDataObject user = new AssetDataObject
            {
                assetName = GetInputText(_AssetName),
                categoryName = SelectedDropdownText(_CategoryBtn),
                state = ReplaceState(),
            };
            return user;
        }
        public void SaveAsset()
        {
            ClickElement(_SaveBtn);
            Wait(3000);
        }
        public string CheckCategory()
        {
            return SelectedDropdownText(_Category);
        }
        public void CreatNewCategory(string categoryName, string categoryPrefix)
        {

            ClickElement(_CategoryBtn);
            Wait(1000);
            ClickElement(_AddCategoryButton);
            SendKeyNormal(_AddCategoryName,categoryName);
            SendKeyNormal(_AddCategoryPrefix,categoryPrefix);
            ClickElement(_ConfirmNewCategory);
        }
        public string CheckCurrentCategory(string text)
        {
            Wait(2000);
            ClickElement(_CategoryBtn);
            ClickNewCategory(text);
            return SelectedDropdownText(_CategoryBtn);
        }
        public void ClickNewCategory(string text)
        {
            string categorytName = string.Format(_CategoryList, text);
            ClickElement(By.XPath(categorytName));
        }
    }
}
