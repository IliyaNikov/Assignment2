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
            User first = await adultContext.users.FirstOrDefaultAsync(user => user.UserName.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            return first;
        }
    }
}