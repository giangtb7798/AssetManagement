using AssetManagementFramework.APIController;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using Newtonsoft.Json;
using System;

namespace AssetManagementScript.Service
{
    public class AuthenticationService
    {
        private APIResponse LoginRequest(string location)
        {
            APIResponse? Response = null;
            APIRequest Request = new APIRequest();
            if (location == Constant.LOCATION_HANOI)
            {
                Response = Request.SetClient(Constant.API_URL, "Authentication/Login").AddHeader("accept", "text/plain").AddStringBody(string.Format("{{\"userName\":\"{0}\",\"password\":\"{1}\"}}", Constant.USERNAME_ADMINHN, Constant.PASSWORD_ADMINHN), RestSharp.DataFormat.Json).Post();

            }
            return Response;
        }

        //public UserDataObject LoginData(string location)
        //{
        //    APIResponse response = LoginRequest(location);
        //    UserDataObject data = JsonConvert.DeserializeObject<UserDataObject>(response.responseBody);
        //    return data;
        //}

        public string LoginData(string location)
        {
            APIResponse response = LoginRequest(location);
            string data = response.responseBody;
            return data;
        }
    }
}
