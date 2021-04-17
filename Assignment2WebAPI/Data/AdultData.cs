using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment2WebAPI.Models;

namespace Assignment2WebAPI.Data
{
    public class AdultData : IAdultData
    {
        private IList<Adult> adults;
        private string adultFile = "adults.json";

        public AdultData()
        {
            if (!File.Exists(adultFile))
            {
                WriteAdultsToFile();
            } else {
                string content = File.ReadAllText(adultFile);
                adults = JsonSerializer.Deserialize<List<Adult>>(content);
            }
        }

        public void WriteAdultsToFile()
        {
            string productAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productAsJson);
        }
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
            return adult;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toRemove = adults.First(adult => adult.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        public async Task<Adult> EditAdultAsync(Adult adult)
        {
            Adult toUpdate = adults.First(a => a.Id == adult.Id);
            toUpdate.JobTitle = adult.JobTitle;
            toUpdate.Id = adult.Id;
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            WriteAdultsToFile();
            return toUpdate;
        }
    }
}