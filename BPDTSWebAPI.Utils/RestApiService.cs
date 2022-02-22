using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace BPDTSWebAPI.Utils
{
    public static class RestApiService
    {
        // Static for only tcp ip client call(save time)
        public static HttpClient restApiClient { get; set; }


        public static void InitializeClient()
        {
            restApiClient = new HttpClient();

            //todo : need to pass baseAddress Uri from the appsettings.json
            restApiClient.BaseAddress = new Uri("https://bpdts-test-app.herokuapp.com/");

            restApiClient.DefaultRequestHeaders.Accept.Clear();
            restApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

    }
}
