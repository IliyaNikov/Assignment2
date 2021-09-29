using System.Threading.Tasks;
using Assignment2WebAPI.Models;

namespace Assignment2WebAPI.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username);
       
    }
}