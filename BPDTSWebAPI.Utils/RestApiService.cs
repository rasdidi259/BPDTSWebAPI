
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BPDTSWebAPI.Utils
{
    public static class RestApiService
    {
        // Static for only tcp ip client call(save time)
        public static HttpClient RestApiClient { get; set; }

        public static void InitializeClient()
        {
            RestApiClient = new HttpClient();
            RestApiClient.DefaultRequestHeaders.Accept.Clear();
            RestApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
