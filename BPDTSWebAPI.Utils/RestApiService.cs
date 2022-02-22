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

            //todo : need to pass baseAddress Uri from the appsettings.json
            //RestApiClient.BaseAddress = new Uri("https://bpdts-test-app.herokuapp.com/");

            RestApiClient.DefaultRequestHeaders.Accept.Clear();
            RestApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
