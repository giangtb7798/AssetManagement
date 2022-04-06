using AssetManagementFramework.Driver;
using OpenQA.Selenium;

namespace AssetManagementScript.PageObject.ConstantAdmin
{
    public class LogOutPageObject : WebDriverAction
    {
        By LogOut_Button = By.XPath("");
        By LogOut_Confirm = By.XPath("");
        public LogOutPageObject(IWebDriver driver) : base(driver)
        {
        }
        public void ClickLogOutButton()
        {
            ClickElement(LogOut_Button);
        }
        public void ClickConFirmButton()
        {
            ClickElement(LogOut_Confirm);
        }
    }
}
