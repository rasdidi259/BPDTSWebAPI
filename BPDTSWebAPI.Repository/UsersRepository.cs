using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Repository
{
    public class UsersRepository : IUsersRepository
    {
        // Need to sort out base Url
        private static string baseUrl = "https://bpdts-test-app.herokuapp.com/";

        public async Task<IList<User>> GetAllUsersAsync()
        {
            using (HttpResponseMessage response = await RestApiService.RestApiClient.GetAsync($"{baseUrl}users"))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<User> users = await response.Content.ReadAsAsync<List<User>>();
                    return users;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
