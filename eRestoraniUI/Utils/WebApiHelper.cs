using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eRestoraniUI.Utils
{
    class WebApiHelper
    {
        public HttpClient Client { get; set; }
        public string Route { get; set; }
        public readonly String DEFAULT_API_URI = "http://localhost:58299";
        public readonly String DEFAULT_API_PREFIX = "api";

        public WebApiHelper(string route)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(DEFAULT_API_URI);

            this.Route = DEFAULT_API_PREFIX + "/" + route;
        }
        public WebApiHelper(string uri, string route)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(uri);

            this.Route = DEFAULT_API_PREFIX + "/" + route;
        }

        // api/Endpoint
        public HttpResponseMessage PostResponse(object obj)
        {
            return Client.PostAsJsonAsync(Route, obj).Result;
        }

        // api/Endpoint/{param}
        public HttpResponseMessage PutResponse(int id, Object existingObj)
        {
            return Client.PutAsJsonAsync(Route + "/" + id + "/", existingObj).Result;
        }

        // api/Endpoint
        public async Task<HttpResponseMessage> GetResponse()
        {
            HttpResponseMessage result = await Client.GetAsync(Route);
            return result;
        }

        // api/Endpoint/{param}
        public async Task<HttpResponseMessage> GetResponse(string param)
        {
            HttpResponseMessage result = await Client.GetAsync(Route + "/" + param + "/");
            return result;
        }

        internal async Task<HttpResponseMessage> DeleteResponse(int resourceId)
        {
            HttpResponseMessage result = await Client.DeleteAsync(Route + "/" + resourceId + "/");
            return result;
        }
    }
}
