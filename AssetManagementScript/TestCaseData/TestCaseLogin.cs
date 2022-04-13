using AssetManagementScript.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.TestCaseData
{
    public class TestCaseLogin
    {
        public static IEnumerable<dynamic> GetTestData()
        {
            var data = new LoginData
            {
                userName = "Admin",
                password = "Admin"
            };
            yield return new[] { data };
        }
    }
}
