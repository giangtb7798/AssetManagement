using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace AssetManagementFramework.APIController
{
    public class APIResponse
    {

        private RestResponse response;
        public string responseBody { get; set; }
        public int responseStatusCode { get; set; }
        public string responseStatus { get; set; }
        public APIResponse(RestResponse response)
        {
            this.response = response;
            GetResponseBody();
            GetresponseStatusCode();
            GetResponseStatus();
            //deserialize();
        }
        private string GetResponseBody()
        {
            responseBody = "";

            if (response != null)

            { responseBody = response.Content; }

            return responseBody;
        }
        private int GetresponseStatusCode()
        {
            HttpStatusCode statusCode = response.StatusCode;
            responseStatusCode = (int)statusCode;

            return responseStatusCode;
        }
        private string GetResponseStatus()
        {
            responseStatus = response.StatusCode.ToString();

            return responseStatus;
        }
        //private dynamic deserialize()
        //{
        //    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseBody);
        //    obj = result;
        //    return result;
        //}
    }
}
