using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject
{
    public class ChangePasswordPage : WebDriverAction
    {
        By Menu_Btn = By.XPath("//button[@id='dropdown-split-variants-basic']");
        By ChangePassword_Btn = By.XPath("//a[text()='Change Password']");
        By Old_Password = By.XPath("//input[@name='oldPassword']");
        By New_Password = By.XPath("//input[@name='newPassword']");
        By Save_Btn = By.XPath("//button[@class='btn btn-primary btn btn-primary']");
        By Verify_Text = By.XPath("//div[text()='Your password has been changed successfully']");
        By Close_Btn = By.XPath("//button[text()='Close']");

        public ChangePasswordPage(IWebDriver driver) : base(driver)
        {
        }
        public void ClickMenuButton()
        {
            ClickElement(Menu_Btn);
        }
        public void ClickChangePasswordButton()
        {
            ClickElement(ChangePassword_Btn);
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
        public void ClickClose()
        {
            ClickElement(Close_Btn);
        }
    }
}
