using AssetManagementFramework;
using AssetManagementScript.Service;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.Configuration
{
    public class ProjectTestSetupHN : TestSetup
    {

        public string _token;

        public ProjectTestSetupHN(string browser, string osPlatform) : base(browser, osPlatform)
        {
        }

        [SetUp]
        public void Setup()
        {
            AuthenticationService loginService = new AuthenticationService();
            _token = loginService.LoginData("Ha noi");

        }
    }
}
