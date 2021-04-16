using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI2.Models;

namespace WebAPI2.Data
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