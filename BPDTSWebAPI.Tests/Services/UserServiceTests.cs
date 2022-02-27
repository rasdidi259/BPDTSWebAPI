using BPDTSWebAPI.Entities;
using BPDTSWebAPI.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BPDTSWebAPI.Tests.Services
{
    public class UserServiceTests
    {
        private readonly string getBasUrl = "https://bpdts-test-app.herokuapp.com/";
        private readonly HttpClient httpClient = new();
        private readonly HttpRequestMessage request = new();
        
        [Fact]
        public async Task GetAllUsersAsync_NoCondition_ReturnAllUsers()
        {            
            request.RequestUri = new Uri($"{getBasUrl}users");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            
            HttpResponseMessage response = await httpClient.SendAsync(request);
            Console.WriteLine(response.ToString());

            // Status Code
            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine($"Status Code {statusCode}");
            Console.WriteLine($"Statue Code {(int)statusCode}");

            // Response Data
            HttpContent responseContent = response.Content;
            Task<IList<User>> responseData = responseContent.ReadAsAsync<IList<User>>();
            var userList = responseData.Result;
            Console.WriteLine(userList);

            // Close the Connection
            httpClient.Dispose();

        }

        [Fact]
        public async Task GetUserByIdAsync_IdPassed_ReturnsRightUser()
        {
            var userId = 1;
            request.RequestUri = new Uri($"{getBasUrl}user/{userId}");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            Console.WriteLine(response.ToString());

            // Status Code
            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine($"Status Code {statusCode}");
            Console.WriteLine($"Status Code {(int)statusCode}");

            // Response Data
            HttpContent responseContent = response.Content;
            Task<User> responseData = responseContent.ReadAsAsync<User>();
            var user = responseData.Result;
            Console.WriteLine(user);

            // Close the Connection 
            httpClient.Dispose();
        }

        [Fact]
        public async Task GetUserByCityAsync_CityPassed_ReturnsRightUser()
        {
            var city = "Wielbark";
            request.RequestUri = new Uri($"{getBasUrl}city/{city}/users");
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");

            HttpResponseMessage response = await httpClient.SendAsync(request);
            Console.WriteLine(response.ToString());

            // Status Code
            HttpStatusCode statusCode = response.StatusCode;
            Console.WriteLine($"Status Code {statusCode}");
            Console.WriteLine($"Status Code {(int)statusCode}");

            // Response Date
            Task<List<UserByCity>> responseData = response.Content.ReadAsAsync<List<UserByCity>>();
            var userByCity = responseData.Result;
            Console.WriteLine(userByCity);

            httpClient.Dispose();
           }
        }
}
