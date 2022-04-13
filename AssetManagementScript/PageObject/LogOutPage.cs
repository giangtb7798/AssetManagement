using AssetManagementFramework.Driver;
using OpenQA.Selenium;

namespace AssetManagementScript.PageObject.ConstantAdmin
{
    public class LogOutPage : WebDriverAction
    {
        By Menu_Btn = By.XPath("//button[@id='dropdown-split-variants-basic']");
        By LogOut_Button = By.XPath("//a[text()='Logout']");       
        By Yes_Btn = By.XPath("//button[@class='btn btn-primary btn btn-primary']");
        By LogIn_Btn = By.XPath("//a[@class='btn btn-Danger']");
        public LogOutPage(IWebDriver driver) : base(driver)
        {
        }
        public void ClickMenuButton()
        {
            ClickElement(Menu_Btn);
        }
        public void ClickLogOutButton()
        {
            ClickElement(LogOut_Button);
        }
        public void ClickConFirmButton()
        {
            ClickElement(Yes_Btn);
        }
        public void GetTextLogInBtn()
        {
            GetText(LogIn_Btn);
        }
    }
}
