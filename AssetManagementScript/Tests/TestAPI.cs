using AssetManagementFramework;
using AssetManagementScript.Service;
using NUnit.Framework;
using System;

namespace AssetManagementScript.Tests
{
    [TestFixtureSource(typeof(CrossBrowserData), nameof(CrossBrowserData.SimpleConfiguration))]
    [Parallelizable(ParallelScope.Self)]
    public class TestAPI : TestSetup
    {
        public TestAPI(string browser, string osPlatform) : base(browser, osPlatform)
        {

        }
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void AdminLogin()
        {
            // Input Username Password and Click
            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.LoginData();
        }
    }
}
