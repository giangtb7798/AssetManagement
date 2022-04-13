using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject.Constant
{
    public class ChangePasswordFirstTimePage : WebDriverAction
    {
        By NewPassword_tf = By.XPath("//input[@name='newPassword']");
        By Save_Btn = By.XPath("//button[text()='Save']");
        public ChangePasswordFirstTimePage(IWebDriver driver) : base(driver)
        {
        }
        public void InputNewPassword(string NewPassword)
        {
            SendKey(NewPassword_tf, NewPassword);
        }
        public void ClickSaveBtn()
        {
            ClickElement(Save_Btn);
        }
    }
}
