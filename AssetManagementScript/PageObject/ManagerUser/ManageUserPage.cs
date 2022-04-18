using AssetManagementFramework.Driver;
using AssetManagementScript.DTO;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.ManagerUser
{
    public class ManageUserPage : WebDriverAction
    {
        By _SearchBox = By.XPath("//input[@class='ant-input']");
        By _SearchBoxBtn = By.XPath("//button[@class='ant-btn ant-btn-default ant-btn-icon-only ant-input-search-button']");
        string _StaffCode = "//tr{0}//td[1]";
        string _FullName = "(//td[count(//th[.='Staff Code ']/preceding-sibling::th)+2]){0}";
        string _Username = "(//td[count(//th[.='Staff Code ']/preceding-sibling::th)+3]){0}";
        string _JoinedDate = "(//td[count(//th[.='Staff Code ']/preceding-sibling::th)+4]){0}";
        string _Type = "(//td[count(//th[.='Staff Code ']/preceding-sibling::th)+5]){0}";


        By _Filter = By.XPath("//div[@class='ant-select-selection-overflow']");
        By _FilterAdmin = By.XPath("//div[@class='ant-select-item-option-content' and text()='Admin']");
        By _FilterStaff = By.XPath("//div[@class='ant-select-item-option-content' and text()='Staff']");
        By _FilterClear = By.XPath("//span[@class='ant-select-clear']");

        By _CreateUserBtn = By.XPath("//a[@href='#/create-user']");
        By _PageTitle = By.XPath("//h2[text()='User List']");
        By _Row1Data = By.XPath("(//tbody//tr)[1]");

        By _StaffCodeDetail = By.XPath("//input[@placeholder='Staff Code']");
        By _FullnameDetail = By.XPath("//table[@class='UserListPage_shuModal__3wtxD']//tr[2]//td[2]");
        By _UsernameDetail = By.XPath("//table[@class='UserListPage_shuModal__3wtxD']//tr[1]//td[2]");
        By _DOB = By.XPath("//table[@class='UserListPage_shuModal__3wtxD']//tr[4]//td[2]");
        By _GenderDetail = By.XPath("//table[@class='UserListPage_shuModal__3wtxD']//tr[5]//td[2]");
        By _TypeDetail = By.XPath("//table[@class='UserListPage_shuModal__3wtxD']//tr[6]//td[2]");
        By _LocationDetail = By.XPath("//input[@placeholder='Location']");
        By _CloseDetailBtn = By.XPath("//button[contains(text(), 'Close')]");

        string _EditUserBtn = "(//td[count(//th[.='Type ']/preceding-sibling::th)+2]/span/a){0}";
        string _DisableUserBtn = "(//*[name()='svg'][@class='deleteUserIcon']){0}";
        By _ConfirmDisableUser = By.XPath("//span[text()='Disable']");

        public ManageUserPage(IWebDriver driver) : base(driver)
        {
        }
        public void InputSeachBox(string input)
        {
            ClickElement(_SearchBox);
            SendKeyWithDelay(250, input, _SearchBox);
            ClickElement(_SearchBoxBtn);
            Wait(3000);
        }
        public string CheckInputText()
        {
            return CheckInputText(_SearchBox);
        }
        public string StaffCodeByIndex(int index)
        {
            string staffcode = string.Format(_StaffCode, "[" + index + "]");
            return GetText(By.XPath(staffcode));
        }
        public string FullNameByIndex(int index)
        {
            string fullname = string.Format(_FullName, "[" + index + "]");
            return GetText(By.XPath(fullname));
        }
        public string UsernameByIndex(int index)
        {
            string username = string.Format(_Username, "[" + index + "]");
            return GetText(By.XPath(username));
        }
        public string JoinedDateByIndex(int index)
        {
            string joineddate = string.Format(_JoinedDate, "[" + index + "]");
            return GetText(By.XPath(joineddate));
        }
        public string TypeByIndex(int index)
        {
            string type = string.Format(_Type, "[" + index + "]");
            return GetText(By.XPath(type));
        }
        public UserDataObject DisplayRowDataByIndex(int index)
        {
            UserDataObject list = new UserDataObject
            {
                fullName = FullNameByIndex(index),
                userName = UsernameByIndex(index),
                joinDate = JoinedDateByIndex(index),
                type = TypeByIndex(index),
            };

            return list;
        }
        public void FilterAdmin()
        {
            ClickElement(_Filter);
            ClickElement(_FilterAdmin);
            Wait(3000);
        }
        public void FilterStaff()
        {
            ClickElement(_FilterClear);
            ClickElement(_Filter);
            ClickElement(_FilterStaff);
            Wait(3000);
        }
        public List<string> StateList()
        {
            string type = string.Format(_Type, "");
            return ElementsToListText(By.XPath(type));
        }
        public List<string> UserNameList()
        {
            string username = string.Format(_Username, "");
            return ElementsToListText(By.XPath(username));
        }
        public List<string> StaffCodeList()
        {
            string staffcode = string.Format(_StaffCode, "");
            return ElementsToListText(By.XPath(staffcode));
        }
        public List<string> FullNameList()
        {
            string fullname = string.Format(_FullName, "");
            return ElementsToListText(By.XPath(fullname));
        }
        public void ClearSearch()
        {
            ClearText(_SearchBox);
            Wait(250);
        }
        public void ClickAddUser()
        {
            ClickElement(_CreateUserBtn);
        }
        public string GetTitleName()
        {
            return GetText(_PageTitle);
        }
        public void ClickRowByIndex(int index)
        {
            string staffcode = string.Format(_StaffCode, "[" + index + "]");
            ClickElement(By.XPath(staffcode));
        }

        public void CloseUserDetail()
        {
            ClickElement(_CloseDetailBtn);
        }
        public void ClickEditUserByIndex(int index)
        {
            string edituser = string.Format(_EditUserBtn, "[" + index + "]");
            ClickElement(By.XPath(edituser));
        }
        public void ClickDisableUser(int index)
        {
            string disableuser = string.Format(_DisableUserBtn, "[" + index + "]");
            ClickElement(By.XPath(disableuser));
            Wait(1000);
            ClickElement(_ConfirmDisableUser);
            Wait(3000);
        }
        public bool FindNoElements()
        {
            string staffcode = string.Format(_StaffCode, "");
            return FindNoSuchElements(By.XPath(staffcode));
        }
        public bool FindNoElements1(string StaffCodeDisable)
        {
            bool Disable = false;
            string staffcode = string.Format(_StaffCode, "");
            string findstaffcode = GetText(By.XPath(staffcode));
            if(StaffCodeDisable == findstaffcode)
            {
                return Disable = false;
            }
            return true;
        }
        public UserDataObject UserDetailData()
        {
            UserDataObject data = new UserDataObject
            {
                fullName = GetText(_FullnameDetail),
                userName = GetText(_UsernameDetail),
                doB = GetText(_DOB),
                gender = GetText(_GenderDetail),
                type = GetText(_TypeDetail),
            };
            return data;
        }
        public UserDataObject UserListByIndex(int index)
        {
            UserDataObject data = new UserDataObject
            {
                code = StaffCodeByIndex(index),
                fullName = FullNameByIndex(index),
                userName = UsernameByIndex(index),
                joinDate = JoinedDateByIndex(index),
                type = TypeByIndex(index),
            };
            return data;
        }
    }
}
