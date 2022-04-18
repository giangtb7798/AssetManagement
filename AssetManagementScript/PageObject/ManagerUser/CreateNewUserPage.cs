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
    public class CreateNewUserPage : WebDriverAction
    {

        By _Firstname = By.XPath("//input[@id='basic_firstName']");
        By _Lastname = By.XPath("//input[@id='basic_lastName']");
        By _Dob = By.XPath("//input[@id='basic_doB']");
        By _FemaleBtn = By.XPath("//input[@value='1']");
        By _MaleBtn = By.XPath("//input[@value='0']");
        By _JoinedDate = By.XPath("//input[@id='basic_joinDate']");
        By _TypeAdmin = By.XPath("//div[@class='ant-select-item-option-content' and text()='Admin']");
        By _Type = By.XPath("//input[@id='basic_type']");
        By _TypeSelect = By.XPath("//span[@class='ant-select-selection-item']");

        By _TypeStaff = By.XPath("//div[@class='ant-select-item-option-content' and text()='Staff']");
        By _SaveBtn = By.XPath("//span[contains(text(), 'Save')]");

        public CreateNewUserPage(IWebDriver driver) : base(driver)
        {
        }
        public void CreateNewUSer(string firstname, string lastname, string Dob, string gender, string joinedDate, string type)
        {

            Firstname(firstname);
            Lastname(lastname);
            DoB(Dob);
            ChooseGender(gender);
            JoinedDate(joinedDate);
            ChooseType(type);
        }

        public UserDataObject GetUserInputDataForUITest()
        {
            UserDataObject user = new UserDataObject
            {
                fullName = GetInputText(_Firstname) + " " + GetInputText(_Lastname),
                userName = GetInputText(_Firstname).ToLower() + GetInputText(_Lastname).ToLower()[0],
                joinDate = GetInputText(_JoinedDate),
                type = SelectedDropdownText(_TypeSelect),
            };

            return user;
        }

        public UserDataObject GetUserInputDataForAPITest()
        {
            UserDataObject user = new UserDataObject
            {
                firstName = GetInputText(_Firstname),
                lastName = GetInputText(_Lastname),
                userName = GetInputText(_Firstname).ToLower() + GetInputText(_Lastname).ToLower()[0],
                doB = GetInputText(_Dob),
                gender = GenderOption(),
                joinDate = GetInputText(_JoinedDate),
                type = SelectedDropdownText(_TypeSelect),
            };

            return user;
        }

        public UserDataObject GetUserInputDetailData()
        {
            UserDataObject user = new UserDataObject
            {
                fullName = GetInputText(_Firstname) + " " + GetInputText(_Lastname),
                userName = GetInputText(_Firstname).ToLower() + GetInputText(_Lastname).ToLower()[0],
                doB = GetInputText(_Dob),
                gender = GenderOption(),
                type = SelectedDropdownText(_TypeSelect),
            };
            return user;
        }
        public UserDataObject GetUserInputData()
        {
            UserDataObject user = new UserDataObject
            {
                firstName = GetInputText(_Firstname),
                lastName = GetInputText(_Lastname),
                doB = GetInputText(_Dob),
                joinDate = GetInputText(_JoinedDate),
                gender = GenderOption(),
                type = SelectedDropdownText(_Type),
            };
            return user;
        }

        public string GenderOption()
        {
            string var = "";
            if (CheckSelectBox(_FemaleBtn))
            {
                return var = "Female";
            }
            else if (!CheckSelectBox(_FemaleBtn))
            {
                return var = "Male";
            }
            return var;
        }

        public string ChooseGender(string input)
        {
            string _input = "";
            if (input.ToLower() == "male")
            {
                Male();
                _input = "true";
                return _input;
            }
            else if (input.ToLower() == "female")
            {
                Female();
                _input = "false";
                return _input;
            }
            return _input;
        }
        public string ChooseType(string input)
        {
            string _input = "";
            if (input.ToLower() == "admin")
            {
                ChooseAdmin();
                _input = "true";
                return _input;
            }
            else if (input.ToLower() == "staff")
            {
                ChooseStaff();
                _input = "false";
                return _input;
            }
            return _input;
        }

        public void Firstname(string input)
        {
            SendKey(_Firstname, input);
            Wait(1000);
        }
        public void Lastname(string input)
        {
            SendKey(_Lastname, input);
            Wait(1000);
        }
        public void DoB(string input)
        {
            SendKeyEnter(_Dob, input);
            Wait(1000);
        }
        public void Female()
        {
            ClickElement(_FemaleBtn);
        }
        public void Male()
        {
            ClickElement(_MaleBtn);
        }
        public void JoinedDate(string input)
        {
            SendKeyEnter(_JoinedDate, input);
        }
        public void ChooseAdmin()
        {
            ClickElement(_Type);
            ClickElement(_TypeAdmin);
        }
        public void ChooseStaff()
        {
            ClickElement(_Type);
            ClickElement(_TypeStaff);

        }
        public void SubmitNewUser()
        {
            ClickElement(_SaveBtn);
            Wait(6000);
        }
        public string ConvertJoinedtDate(string input)
        {
            DateTime asDate = DateTime.ParseExact(input,
               "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("dd/MM/yyyy");
        }
    }
}
