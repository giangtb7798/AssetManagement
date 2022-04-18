using AssetManagementFramework.APIController;
using AssetManagementScript.Configuration;
using AssetManagementScript.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementScript.Service
{
    public class ManageUserService
    {
        public APIResponse GetUserListRequest(string token)
        {
            APIRequest Request = new APIRequest();
            APIResponse Response = Request.SetClient(Constant.API_URL, "User/list").AddParameter("location", Constant.LOCATION_HANOI).AddParameter("pageIndex", "1").AddParameter("PageSize", "10").AddHeader("Authorization","Bearer " + token).Get();
            return Response;
        }
        public APIResponse GetUserDetailRequest(string token, string userid)
        {
            APIRequest Request = new APIRequest();
            APIResponse Response = Request.SetClient(Constant.API_URL, "User/details?code=" + userid).AddHeader("Authorization", "Bearer " + token).Get();
            return Response;
        }
        public UserDataObject UserDetailData(string token)
        {
            APIResponse response = GetUserListRequest(token);
            UserDataObject data = JsonConvert.DeserializeObject<UserDataObject>(response.responseBody);
            return data;
        }
        public UserDataObject UserDetailData(string token, string userid)
        {
            APIResponse response = GetUserDetailRequest(token, userid);
            UserDataObject data = JsonConvert.DeserializeObject<UserDataObject>(response.responseBody);
            return data;
        }
        public UserDataObject UserDataAPI(string token, string userid)
        {
            UserDataObject data = new UserDataObject
            {
                firstName = UserDetailData(token, userid).firstName,
                lastName = UserDetailData(token, userid).lastName,
                userName = UserDetailData(token, userid).userName,
                doB = ConvertDoB(token, userid),
                gender = UserDetailData(token, userid).gender,
                joinDate = ConvertJoinedDate(token, userid),
                type = ReplaceType(token, userid)
            };
            return data;
        }
        public string ReplaceType(string token, string userid)

        {
            string var = null;
            if (UserDetailData(token, userid).type == "Admin")
            {
                var = "Admin";
                return var;
            }
            else if (UserDetailData(token, userid).type == "Staff")
                var = "Staff";
            return var;
        }
        public string TypeReplacement(string input)
        {
            string var = null;
            if (input == "true")
            {
                var = "Admin";
                return var;
            }
            else if (input == "false")
                var = "Staff";
            return var;
        }
        public string ReplaceGender(string token, string userid)

        {
            string var = null;
            if (UserDetailData(token, userid).gender == "true")
            {
                var = "Male";
                return var;
            }
            else if (UserDetailData(token, userid).gender == "false")
                var = "Female";
            return var;
        }
        public List<string> GetUserStaffCodeList(string token)
        {
            List<string> data = new List<string>();
            for (int x = 0; x < UserDetailData(token).items.Count; x++)
            {
                data.Add(UserDetailData(token).items[x].code);
            }
            return data;
        }
        public UserDataObject GetUserDataByIndex(string token, int index)
        {
            UserDataObject data = new UserDataObject
            {
                code = UserDetailData(token).items[index].code,
                fullName = UserDetailData(token).items[index].firstName + " " + UserDetailData(token).items[index].lastName,
                userName = UserDetailData(token).items[index].userName,
                joinDate = ConvertInputDate(UserDetailData(token).items[index].joinDate),
                type = UserDetailData(token).items[index].type
            };

            return data;
        }

        public string ConvertDoB(string token, string userid)
        {
            DateTime asDate = DateTime.ParseExact(UserDetailData(token, userid).doB,
               "yyyy-MM-dd'T'HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("dd/MM/yyyy");
        }
        public string ConvertJoinedDate(string token, string userid)
        {
            DateTime asDate = DateTime.ParseExact(UserDetailData(token, userid).joinDate,
               "yyyy-MM-dd'T'HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("dd/MM/yyyy");
        }
        public string ConvertInputDate(string input)
        {
            DateTime asDate = DateTime.ParseExact(input,
               "yyyy-MM-dd'T'HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("dd/MM/yyyy");
        }
        public string SerializeData(dynamic data)
        {
            string var = JsonConvert.SerializeObject(data);
            return var;
        }
    }
}
