using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject
{
    public class CreateNewUserPage : WebDriverAction
    {
        By Menu_Btn = By.XPath("//div[@class='jss5'][2]");
        By CreateUser_Btn = By.XPath("//a[text()='Create new user']");
        By FirstName_ft = By.XPath("//input[@name='firstName']");
        By LastName_ft = By.XPath("//input[@name='lastName']");
        By DTB_ft = By.XPath("//input[@name='dateOfBirth']");
        By Gender_Male = By.XPath("//input[@value='Male']");
        By Gender_Female = By.XPath("//input[@value='Female']");
        By JoinedDate = By.XPath("//input[@name='joinedDate']");
        By TypeStaff = By.XPath("//option[@value='User']");
        By TypeAdmin = By.XPath("//option[@value='Admin']");
        By Submit_Btn = By.XPath("//button[text()='Submit']");

        public CreateNewUserPage(IWebDriver driver) : base(driver)
        {
        }
        public void ClickManageUserMenu()
        {
            ClickElement(Menu_Btn);
        }
        public void ClickCreateUserBtn()
        {
            ClickElement(CreateUser_Btn);
        }
        public void InputFirstName(string FirstName)
        {
            SendKey(FirstName_ft, FirstName);
        }
        public void InputLastName(string LastName)
        {
            SendKey(LastName_ft, LastName);
        }
        public void DOB(string DOB)
        {
            SendKey(DTB_ft,DOB);
        }
        public void Gender(string Gender)
        {
            if(Gender == "male")
            {
                ClickElement(Gender_Male);
            }
            else
            {
                ClickElement(Gender_Female);
            }
            
        }
        public void InputJoinedDate(string IJD)
        {
            SendKey(JoinedDate, IJD);
        }
        public void SelectType(string Type)
        {
            if (Type == "admin")
            {
                ClickElement(TypeAdmin);
            }
            else
            {
                ClickElement(TypeStaff);
            }
        }
        public void ClickSubmit()
        {
            ClickElement(Submit_Btn);
        }
    }
}
