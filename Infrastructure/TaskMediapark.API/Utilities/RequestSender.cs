using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskMediapark.API.Utilities
{
    public class RequestSender
    {
        public async Task<string> SendRequest(string requestUrl)
        {
            using (var httpClient = new HttpClient())
            {
                string endpoint = requestUrl;
                HttpResponseMessage response = await httpClient.GetAsync(endpoint);
                string jsonData = await response.Content.ReadAsStringAsync();
                return jsonData;
            }
        }
    }
}
