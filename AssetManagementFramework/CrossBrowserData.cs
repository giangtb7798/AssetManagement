using NUnit.Framework;
using System;
using System.Collections;

namespace AssetManagementFramework
{
    public class CrossBrowserData
    {
        public static IEnumerable LastestConfigurations
        {
            get
            {
                //chrome
                yield return new TestFixtureData("chrome", "WINDOWS");
                //firefox
                yield return new TestFixtureData("firefox", "WINDOWS");
            }
        }
        public static IEnumerable SimpleConfiguration
        {
            get
            {
                //chrome
                yield return new TestFixtureData("chrome", "WINDOWS");
            }
        }
    }
}
