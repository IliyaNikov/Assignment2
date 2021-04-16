using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();

        Task<Adult> GetAdultByIdAsync(int Id);

        Task AddAdultAsync(Adult adult);

        Task RemoveAdultAsync(int adultId);

        Task EditAdultAsync(Adult adult);
    }
}