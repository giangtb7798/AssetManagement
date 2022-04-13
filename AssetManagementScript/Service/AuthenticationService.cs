using AssetManagementFramework.APIController;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using Newtonsoft.Json;
using System;

namespace AssetManagementScript.Service
{
    public class AuthenticationService
    {
        private APIResponse LoginRequest()
        {
            APIResponse? Response = null;
            APIRequest Request = new APIRequest();
            Response = Request.SetClient(Constant.API_URL, "User/Authenticate").AddStringBody(string.Format("{{\"userName\":\"{0}\",\"password\":\"{1}\"}}", Constant.UserName, Constant.Password), RestSharp.DataFormat.Json).Post();
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
