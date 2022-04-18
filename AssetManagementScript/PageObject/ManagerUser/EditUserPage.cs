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
    public class EditUserPage : WebDriverAction
    {
        By _Firstname = By.XPath("//input[@id='basic_firstName']");
        By _Lastname = By.XPath("//input[@id='basic_lastName']");
        By _Dob = By.XPath("//input[@id='basic_doB']");
        By _Male = By.XPath("//input[@value='Male']");
        By _Female = By.XPath("//input[@value='Female']");
        By _JoinedDate = By.XPath("//input[@id='basic_joinDate']");
        By _type = By.XPath("//div[@class='ant-select-selector']");
        By _TypeSelect = By.XPath("//span[@class='ant-select-selection-item']");
        By _Admin = By.XPath("//div[@class='ant-select-item-option-content' and text()='Admin']");
        By _Staff = By.XPath("//div[@class='ant-select-item-option-content' and text()='Staff']");
        By _SaveChange = By.XPath("//span[contains(text(), 'Save')]");
        By _CancelChange = By.XPath("//a[contains(text(), 'Cancel')]");
        By _SelectValue = By.XPath("//span[@class='ant-select-selection-item']");

        public EditUserPage(IWebDriver driver) : base(driver)
        {

        }
        public void EditUser(string gender, string joinedDate, string type)
        {
            EditGender(gender);
            EditJoinedDate(joinedDate);
            EditType(type);
        }
        public string GenderOption()
        {
            string var = "";
            if (CheckSelectBox(_Female))
            {
                return var = "Female";
            }
            else if (!CheckSelectBox(_Female))
            {
                return var = "Male";
            }
            return var;
        }
        public UserDataObject GetInputData()
        {
            Wait(500);
            UserDataObject userDataObject = new UserDataObject
            {

                firstName = GetInputText(_Firstname),
                lastName = GetInputText(_Lastname),
                doB = GetInputText(_Dob),
                gender = GenderOption(),
                joinDate = GetInputText(_JoinedDate),
                type = ReplaceType(),
            };
            return userDataObject;
        }
        public UserDataObject GetInputDataForAPITest()
        {
            Wait(500);
            UserDataObject userDataObject = new UserDataObject
            {

                firstName = GetInputText(_Firstname),
                lastName = GetInputText(_Lastname),
                userName = GetInputText(_Firstname).ToLower() + GetInputText(_Lastname).ToLower()[0],
                doB = GetInputText(_Dob),
                gender = GenderOption(),
                joinDate = GetInputText(_JoinedDate),
                type = SelectedDropdownText(_TypeSelect),
            };
            return userDataObject;
        }
        public string ReplaceType()
        {
            string var = "";
            if (GetInputText(_SelectValue) == "true")
            {
                return var = "Admin";
            }
            else if (GetInputText(_SelectValue) == "false")
                return var = "Staff";
            return var;
        }
        public void EditDOB(string input)
        {
            SendKey(_Dob, input);
        }
        public void EditGender(string input)
        {
            if (input.ToLower() == "male")
            {
                ClickElement(_Male);
            }
            else if (input.ToLower() == "female")
            {
                ClickElement(_Female);
            }
        }
        public void EditJoinedDate(string input)
        {
            SendKey(_JoinedDate, input);
        }
        public void EditType(string input)
        {
            if (input.ToLower() == "admin")
            {
                ClickElement(_type);
                ClickElement(_Admin);
            }
            else if (input.ToLower() == "staff")
            {
                ClickElement(_type);
                ClickElement(_Staff);
            }
        }
        public void SaveEdit()
        {
            ClickElement(_SaveChange);
            Wait(10000);
        }
        public void CancelEdit()
        {
            ClickElement(_CancelChange);
        }
    }
}
