using AssetManagementFramework.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.PageObject
{
    public class NavigationPage : WebDriverAction
    {
        By _ManageUser = By.XPath("//a[@href='/users']");
        By _ManageAsset = By.XPath("//a[@href='/assets']");
        By _UserDropdown = By.XPath("//span[@class='ant-dropdown-trigger ant-dropdown-link']");
        By _Logout = By.XPath("//a[@href='#/users' and text()='Logout']");
        By _LogoutCf = By.XPath("//span[contains(text(), 'Log out')]");


        public NavigationPage(IWebDriver driver) : base(driver)
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
        public void UserDropdown()
        {
            HoverElement(_UserDropdown);
            Wait(1000);
        }
        public void Logout()
        {
            UserDropdown();
            ClickElement(_Logout);
            Wait(1000);
            ClickElement(_LogoutCf);

        }

    }
}
