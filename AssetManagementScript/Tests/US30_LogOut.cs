using AssetManagementFramework;
using AssetManagementScript.PageObject.ConstantAdmin;
using NUnit.Framework;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.LastestConfigurations))]
    [Parallelizable(ParallelScope.Self)]
    public class US30_LogOut : TestSetup
    {
        public US30_LogOut(string browser, string osPlatform) : base(browser, osPlatform)
        {
            //LogOut
            LogOutPageObject logOutPageObject = new LogOutPageObject(driver);
            logOutPageObject.ClickLogOutButton();
            logOutPageObject.ClickConFirmButton();
        }
    }
}
