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

        public async Task<User> ValidateUserAsync(string username, string password)
        {
           /* HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5003/User?username={username}&password={password}");
            if(response.StatusCode == HttpStatusCode.OK)
            { 
                string userAsJson = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Dies here no?");
                User result = JsonSerializer.Deserialize<User>(userAsJson);
                return result;
            }
            throw new Exception("User not found"); */
           
           
           //Hardcoded user. It works! 
           User tryout = new User();
           tryout.password = "12345";
           tryout.username = "Troels";
           tryout.SecurityLevel = "1";
           if (username == tryout.username && password == tryout.password)
           {
               return tryout;
           }
           throw new Exception("The login name or password is not correct");
           
        }
    }
}