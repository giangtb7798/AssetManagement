using AssetManagementFramework.APIController;
using AventStack.ExtentReports.MarkupUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFramework.HTMLReport
{
    public class MarkupHelperPlus
    {
        public static IMarkup CreateRequestInfor(APIRequest request, APIResponse response)
        {
            APIRequestBlock markup = new APIRequestBlock();
            markup.Request = request;
            markup.Response = response;
            return markup;

        }
    }
}
