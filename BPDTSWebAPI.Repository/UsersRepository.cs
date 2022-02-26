using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Utils;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;

        public UsersRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Returns the baseUrl for the WebAPI
        /// </summary>
        /// <returns></returns>
        private string GetBaseUrl() {
            return _configuration.GetSection("BpdtsWebAPI").Value;
        }


        public async Task<IList<User>> GetAllUsersAsync()
        {
            using HttpResponseMessage response = await RestApiService.RestApiClient.GetAsync($"{GetBaseUrl()}users");
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

        public async Task<List<UserByCity>> GetUserByCityAsync(string city)
        {
            using HttpResponseMessage response = await RestApiService.RestApiClient.GetAsync($"{GetBaseUrl()}city/{city}/users");
            if (response.IsSuccessStatusCode)
            {
                List<UserByCity> users = await response.Content.ReadAsAsync<List<UserByCity>>();
                return users;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            using HttpResponseMessage response = await RestApiService.RestApiClient.GetAsync($"{GetBaseUrl()}user/{userId}");
            if (response.IsSuccessStatusCode)
            {
                User user = await response.Content.ReadAsAsync<User>();
                return user;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
