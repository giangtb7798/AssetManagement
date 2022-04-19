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
    public class ManageAssetService
    {
        private APIResponse GetAssetListRequest(string token)
        {
            APIRequest Request = new APIRequest();
            APIResponse Response = Request.SetClient(Constant.API_URL, "asset/list").AddParameter("location", Constant.LOCATION_HANOI).AddParameter("pageIndex", "1").AddParameter("PageSize", "10").AddHeader("Authorization", "Bearer " + token).Get();
            return Response;
        }
        private APIResponse GetAssetDetailRequest(string token, string assetCode)
        {
            APIRequest Request = new APIRequest();
            APIResponse Response = Request.SetClient(Constant.API_URL, "asset/detail/{assetCode}").AddURLSegment("assetCode", assetCode).AddHeader("Authorization", "Bearer " + token).Get();
            return Response;
        }
        public AssetDataObject AssetDetailData(string token)
        {
            APIResponse response = GetAssetListRequest(token);
            AssetDataObject data = JsonConvert.DeserializeObject<AssetDataObject>(response.responseBody);
            return data;
        }
        public AssetDataObject AssetDetailData(string token, string assetCode)
        {
            APIResponse response = GetAssetDetailRequest(token, assetCode);
            AssetDataObject data = JsonConvert.DeserializeObject<AssetDataObject>(response.responseBody);
            return data;
        }
        public AssetDataObject UserDataAPI(string token, string userid)
        {
            AssetDataObject data = new AssetDataObject
            {
                assetCode = AssetDetailData(token, userid).assetCode,
                assetName = AssetDetailData(token, userid).assetName,
                categoryName = AssetDetailData(token, userid).categoryName,
                state = ReplaceStateName(token, userid),

            };
            return data;
        }
        public string ReplaceStateName(string token, string userid)
        {
            string var = "";
            if (AssetDetailData(token, userid).state == "Available")
            {
                return var = "Available";
            }
            else if (AssetDetailData(token, userid).state == "NotAvailable")
            {
                return var = "Not Available";
            }
            else if (AssetDetailData(token, userid).state == "WaitingForRecycling")
            {
                return var = "Waiting For Recycle";
            }
            else if (AssetDetailData(token, userid).state == "Recycled")
            {
                return var = "Recycled";
            }
            else if (AssetDetailData(token, userid).state == "Assigned")
            {
                return var = "Assigned";
            }
            return var;
        }
        public string ReplaceCategoryName(string token, string userid)
        {
            string var = "";
            if (AssetDetailData(token, userid).category.id == "8f6a57fd-fa03-4a0b-09f3-08da1e8b3ee0")
            {
                return var = "Laptop";
            }
            else if (AssetDetailData(token, userid).category.id == "7bc04563-a3ce-4ef0-1f75-08da21cf1057")
            {
                return var = "AAAAA";
            }
            else if (AssetDetailData(token, userid).category.id == "AAAAA")
            {
                return var = "Key Board";
            }
            return var;
        }
        public string SerializeData(dynamic data)
        {
            string var = JsonConvert.SerializeObject(data);
            return var;
        }
        public string ConvertInputDate(string input)
        {
            DateTime asDate = DateTime.ParseExact(input,
               "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            return asDate.ToString("dd/MM/yyyy");
        }
    }
}
