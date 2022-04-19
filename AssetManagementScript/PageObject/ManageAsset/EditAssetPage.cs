using AssetManagementFramework.Driver;
using AssetManagementScript.DTO;
using AssetManagementScript.Service;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.ManageAsset
{
    public class EditAssetPage : WebDriverAction
    {
        By _Name = By.XPath("//input[@id='asset-edit-input-name']");
        By _Category = By.XPath("//select[@id='asset-edit-input-category']/option");
        By _Specification = By.XPath("//textarea[@id='asset-edit-input-specification']");
        By _InstallDate = By.XPath("//input[@id='asset-edit-input-install-date']");
        By _StateAvailable = By.XPath("//input[@id='asset-add-input-state-available']");
        By _StateNotAvailable = By.XPath("//input[@id='asset-add-input-state-not-available']");
        By _StateWaitingForRecycling = By.XPath("//div[@class='ant-space-item'][3]//span[@class='ant-radio']");
        By _StateRecycled = By.XPath("(//input[@id='asset-add-input-state-not-available'])[2]");
        By _SaveButton = By.XPath("//button[@type='submit']");

        public EditAssetPage(IWebDriver driver) : base(driver)
        {
        }
        public void EditAsset(string name, string specification, string installDate, string state)
        {
            Name(name);
            Specification(specification);
            InstallDate(installDate);
            State(state);
        }
        public void Name(string input)
        {
            SendKey(_Name, input);
        }
        public void Specification(string input)
        {
            SendKey(_Specification, input);
        }
        public void InstallDate(string input)
        {
            SendKey(_InstallDate, input);
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
        public AssetDataObject GetAssetInputForUITest()
        {
            Wait(500);
            AssetDataObject userDataObject = new AssetDataObject
            {

                assetName = GetInputText(_Name),
                categoryName = GetText(_Category),
                specification = GetInputText(_Specification),
                installedDate = ReplaceDateValue(),
                state = ReplaceState(),

            };
            return userDataObject;
        }
        public AssetDataObject GetAssetInputForAssetDetail()
        {
            Wait(500);
            AssetDataObject userDataObject = new AssetDataObject
            {

                assetName = GetInputText(_Name),
                categoryName = GetText(_Category),
                specification = GetInputText(_Specification),
                state = ReplaceState(),

            };
            return userDataObject;
        }
        public string ReplaceState()
        {
            string var = "";
            if (CheckSelectBox(_StateAvailable))
            {
                return var = "Available";
            }
            else if (CheckSelectBox(_StateNotAvailable))
            {
                return var = "Not Available";
            }
            else if (CheckSelectBox(_StateWaitingForRecycling))
            {
                return var = "Waiting for recycle";
            }
            else if (CheckSelectBox(_StateRecycled))
            {
                return var = "Recycled";
            }
            return var;
        }
        public void SaveEdit()
        {
            ClickElement(_SaveButton);
        }
        public string ReplaceDateValue()
        {
            ManageAssetService manageAssetService = new();
            return manageAssetService.ConvertInputDate(GetInputText(_InstallDate));
        }
    }
}
