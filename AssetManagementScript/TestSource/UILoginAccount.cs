using AssetManagementScript.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.TestSource
{
    public class UILoginAccount
    {
        public static IEnumerable<string[]> GetTestData()
        {
            yield return new[] { Constant.USERNAME_ADMINHN, Constant.PASSWORD_ADMINHN };
        }
    }
}
