using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Assignment1.Data
{
    public class AdultCloudService : IAdultData

    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public AdultCloudService()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/adult");
            string message = await stringAsync;
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(message);
            return adults;
        }

        public async Task<Adult> GetAdultByIdAsync(int Id)
        {
            string message = await client.GetStringAsync(uri + "/adult?id=" + Id);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            Adult resultAdult = new Adult();
            for (int i = 0; i < 1; i++)
            {
                resultAdult = result.First();
            }

            return resultAdult;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/adult", content);
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            await client.DeleteAsync($"{uri}/adult/{adultId}");
        }

        public async Task EditAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PatchAsync($"{uri}/adult/{adult.Id}", content);
        }
    }
}