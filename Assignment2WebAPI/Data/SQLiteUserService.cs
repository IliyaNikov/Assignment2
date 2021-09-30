using System;
using System.Threading.Tasks;
using Assignment2WebAPI.Models;
using Assignment2WebAPI.Persistance;
using Microsoft.EntityFrameworkCore;

namespace Assignment2WebAPI.Data
{
    public class SQLiteUserService : IUserService
    {
        private AdultContext adultContext;
        
        public SQLiteUserService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }
        public async Task<User> ValidateUserAsync(string username, string password)
        {
            Console.WriteLine("reached the user service");
            User first = await adultContext.users.FirstOrDefaultAsync(user => user.UserName.Equals(username) && user.Password.Equals(password));
            Console.WriteLine("database checked");
            if (first != null)
            {
                return first;
            }

            throw new Exception("User not found");
        }
    }
}