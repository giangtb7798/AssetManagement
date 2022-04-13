using AssetManagementFramework.APIController;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using Newtonsoft.Json;
using System;

namespace AssetManagementScript.Service
{
    public class AuthenticationService
    {
        public APIResponse LoginRequest()
        {
            APIResponse? Response = null;
            APIRequest Request = new APIRequest();
            Response = Request.SetClient(Constant.API_URL, "Users/Authenticate").AddStringBody(string.Format("{{\"userName\":\"{0}\",\"password\":\"{1}\"}}", Constant.UserName, Constant.Password), RestSharp.DataFormat.Json).Post();
            return Response;
        }

        public UserDataObject LoginData()
        {
            APIResponse response = LoginRequest();
            UserDataObject data = JsonConvert.DeserializeObject<UserDataObject>(response.responseBody);
            return data;
        }
    }
}
