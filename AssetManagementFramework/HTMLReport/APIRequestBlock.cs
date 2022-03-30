using AssetManagementFramework.APIController;
using AventStack.ExtentReports.MarkupUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFramework.HTMLReport
{
    public class APIRequestBlock : IMarkup
    {
        public APIRequest Request { get; set; }
        public APIResponse Response { get; set; }
        public string GetMarkup()
        {
            string requestURL = Request.url;
            string requestURI = Request.uri;
            string requestMethod = Request._Method;
            string requestHeader = Request._Header;
            string requestBody = Request.requestBody;

            string responseBody = Response.responseBody;
            int responseCode = Response.responseStatusCode;
            string responseStatus = Response.responseStatus;


            string htmlBody =

                "<p><b>URL:</b> " + requestURL + "</p></br><p><b>URI:</b> " + requestURI + "</p> " + "</br><p><b>Method:</b> " + requestMethod + "</p></br><p><b>Request Header:</b> " + requestHeader + "</p></br><p><b>Request Body:</b> </br>" + requestBody + "</p></br></br>" + "<p><b>Response code:</b> " + responseCode + "</p></br><p><b>Response status:</b> " + responseStatus + "</p></br></br>" +
                "<p><b>Response body:</b> </br>" + responseBody + "</p>";


            return htmlBody;
        }
    }
}
