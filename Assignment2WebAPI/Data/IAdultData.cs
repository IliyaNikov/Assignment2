using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2WebAPI.Models;

namespace Assignment2WebAPI.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();

        //Task<Adult> GetAdultByIdAsync(int Id);

        Task<Adult> AddAdultAsync(Adult adult);

        Task RemoveAdultAsync(int adultId);

        Task<Adult> EditAdultAsync(Adult adult);
    }
}