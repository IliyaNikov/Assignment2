using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class UserCloudService : IUserService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public UserCloudService()
        {
            client = new HttpClient();
        }
        
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            string message = await client.GetStringAsync(uri + "/user?username" + username);

            User result = JsonSerializer.Deserialize<User>(message);

            if (!result.password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return result;
        }
    }
}