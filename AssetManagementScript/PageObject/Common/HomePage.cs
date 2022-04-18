using AssetManagementFramework.Driver;
using OpenQA.Selenium;

namespace AssetManagementScript.PageObject
{
    public class HomePage : WebDriverAction
    {
        By _ManageUser = By.XPath("//a[@href='#/users']");
        By _ManageAsset = By.XPath("//a[@href='#/assets']");
        By _ManageAssignment = By.XPath("//a[@href='#/assignments']");
        By _MenuUser = By.XPath("//div[@class='ant-breadcrumb']//span[@class='ant-breadcrumb-link']");
        By _ChangePasswordTitle = By.XPath("//span[contains(text(), 'Change Password')]");
        By _NewPasswordField = By.XPath("//input[@id='ChangePass_Oldpassword']");
        By _NewPasswordConfirmation = By.XPath("//input[@id='ChangePass_Newpassword']");
        By _SaveNewPassword = By.XPath("//span[contains(text(), 'Save')]");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        public void ManageUser()
        {
            ClickElement(_ManageUser);
        }
        public void ManageAsset()
        {
            ClickElement(_ManageAsset);
        }
        public void ManageAssignment()
        {
            ClickElement(_ManageAssignment);
        }
        public string GetPopupTitle()
        {
            return GetText(_ChangePasswordTitle);
        }
        public void ChangePassWord(string input)
        {
            SendKey(_NewPasswordField, input);
            SendKey(_NewPasswordConfirmation, input);
            SaveNewPassword();
        }
        public void SaveNewPassword()
        {
            ClickElement(_SaveNewPassword);
        }

    }
}
