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
        By _UserDropdown = By.XPath("//a[@id='basic-nav-dropdown']");
        By _Logout = By.XPath("//a[@id='basic-nav-dropdown']/following-sibling::div//a[contains(text(),' Log out')]");
        By _LogoutCf = By.XPath("//button[contains(text(), 'Log out')]");


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
            ClickElement(_UserDropdown);
        }
        public void Logout()
        {
            UserDropdown();
            ClickElement(_Logout);
            ClickElement(_LogoutCf);

        }

    }
}
