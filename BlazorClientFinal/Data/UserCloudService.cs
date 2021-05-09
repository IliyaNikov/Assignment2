using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace BlazorClientFinal.Data
{
    public class UserCloudService : IUserService
    {
        private string uri = "http://localhost:5003";
        private readonly HttpClient client;

        public UserCloudService()
        {
            client = new HttpClient();
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5003/users?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
    }
}