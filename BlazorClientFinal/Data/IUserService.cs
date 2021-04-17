using System.Threading.Tasks;
using Models;

namespace BlazorClientFinal.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string username, string password);
       
    }
}