using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment2WebAPI.Models;
using Assignment2WebAPI.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Assignment2WebAPI.Data
{
    public class SQLiteAdultService : IAdultData
    {
        private AdultContext adultContext;

        public SQLiteAdultService(AdultContext adultContext)
        {
            this.adultContext = adultContext;
        }
        
        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return await adultContext.adults.ToListAsync();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await adultContext.adults.AddAsync(adult);
            await adultContext.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toDelete = await adultContext.adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                adultContext.adults.Remove(toDelete);
                await adultContext.SaveChangesAsync();
            }
        }

        public async Task<Adult> EditAdultAsync(Adult adult)
        {
            try
            {
                Adult toUpdate = await adultContext.adults.FirstAsync(t => t.Id == adult.Id);
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
                adultContext.Update(toUpdate);
                await adultContext.SaveChangesAsync();
                return toUpdate;
            }
            catch (Exception e)
            {
                throw new Exception($"Adult with id{adult.Id} does not exist.");
            }
        }
    }
}