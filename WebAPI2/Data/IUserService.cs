using System.Threading.Tasks;
using WebAPI2.Models;

namespace WebAPI2.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
       
    }
}