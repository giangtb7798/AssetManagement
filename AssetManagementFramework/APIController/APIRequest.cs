using AssetManagementFramework.HTMLReport;
using Newtonsoft.Json;
using RestSharp;
using System;

namespace AssetManagementFramework.APIController
{
    public class APIRequest
    {
        private RestRequest Request;
        public string requestBody { get; set; }
        public string formData { get; set; }
        public string url { get; set; }
        public string uri { get; set; }
        public string _Method { get; set; }
        public string _Header { get; set; }

        private static RestClient Client;
        public static RestClient CreateClient(string url)
        {

            if (Client == null)
            {
                Client = createInstance(url);
            }
            return Client;

        }
        private static RestClient createInstance(string url)
        {
            RestClient Client = new RestClient(url);
            return Client;
        }
        public APIRequest SetClient(string url, string uri)
        {
            this.url = url;
            this.uri = uri;
            CreateClient(url);
            Request = new RestRequest(uri);
            return this;
        }
        public APIRequest()
        {
            requestBody = "";
            formData = "";
            _Method = "";
            _Header = "";
        }
        public APIRequest AddHeader(string key, string value)
        {
            Request.AddHeader(key, value);
            _Header = key + " " + value;
            return this;
        }

        public APIRequest AddParameter(string key, string value)
        {
            Request.AddParameter(key, value);
            return this;
        }
        public APIRequest AddObJect(object obj)
        {
            Request.AddObject(obj);
            return this;
        }
        public APIRequest AddJsonBody(object obj)
        {
            requestBody = JsonConvert.SerializeObject(obj);
            Request.AddJsonBody(obj);
            return this;
        }

        public APIRequest AddURLSegment(string segment, string data)
        {
            Request.AddUrlSegment(segment, data);
            return this;
        }
        public APIRequest AddStringBody(string bodyRequest, DataFormat format)
        {
            requestBody = bodyRequest;
            Request.AddStringBody(bodyRequest, format);
            return this;
        }

        public APIResponse Get()
        {
            try
            {
                requestBody = null;
                Request.Method = Method.Get;
                _Method = Method.Get.ToString();
                var response = Client.GetAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public APIResponse Post()
        {
            try
            {
                Request.Method = Method.Post;
                _Method = Method.Post.ToString();
                var response = Client.PostAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public APIResponse Delete()
        {
            try
            {
                Request.Method = Method.Delete;
                _Method = Method.Delete.ToString();
                var response = Client.DeleteAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public APIResponse Put()
        {
            try
            {
                Request.Method = Method.Put;
                _Method = Method.Put.ToString();
                var response = Client.PutAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public APIResponse Head()
        {
            try
            {
                Request.Method = Method.Head;
                _Method = Method.Head.ToString();
                var response = Client.HeadAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public APIResponse Option()
        {
            try
            {
                Request.Method = Method.Options;
                _Method = Method.Options.ToString();
                var response = Client.HeadAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public APIResponse Patch()
        {
            try
            {
                Request.Method = Method.Patch;
                _Method = Method.Patch.ToString();
                var response = Client.HeadAsync(Request).Result;
                APIResponse Response = new(response);
                HTMLReporter.Pass(this, Response);
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
