using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI2.Models;

namespace WebAPI2.Data
{
    public class UserService : IUserService
    {
        private ICollection<User> users;

        public UserService()
        {
            users = new List<User>();
            users.Add(new User
            {
                username = "Troels",
                password = "1234"
            });
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User user = users.FirstOrDefault(u => u.username.Equals(username) && u.password.Equals(password));
            if (user != null)
            {
                return user;
            }

            throw new Exception("User not found");
        }
    }
}