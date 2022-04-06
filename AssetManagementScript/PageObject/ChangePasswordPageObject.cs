using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject
{
    public class ChangePasswordPageObject : WebDriverAction
    {
        By Old_Password = By.XPath("");
        By New_Password = By.XPath("");
        By Save_Btn = By.XPath("");
        By Verify_Text = By.XPath("");
        public ChangePasswordPageObject(IWebDriver driver) : base(driver)
        {
        }
        public void OldPassword(string PassWord)
        {
            SendKey(Old_Password, PassWord);
        }
        public void NewPassword(string PassWord)
        {
            SendKey(New_Password, PassWord);
        }
        public void ClickSaveButton()
        {
            ClickElement(Save_Btn);
        }
        public string GetMessageSuccessful()
        {
            return GetText(Verify_Text);
        }
    }
}
