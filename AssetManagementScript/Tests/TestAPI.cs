using AssetManagementFramework;
using AssetManagementScript.Service;
using AssetManagementScript.TestCaseData;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void AddPetData()
        {
            AuthenticationService authenticationService = new AuthenticationService();
            authenticationService.LoginData();
        }
    }
}
