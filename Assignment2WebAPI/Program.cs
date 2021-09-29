using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2WebAPI.Models;
using Assignment2WebAPI.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignment2WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (AdultContext adultContext = new AdultContext())
            {
                if (!adultContext.adults.Any())
                {
                    await SeedAdult(adultContext);
                }

                if (!adultContext.users.Any())
                {
                    await SeedUser(adultContext);
                }
            }
            CreateHostBuilder(args).Build().Run();
        }

        private static async Task SeedUser(AdultContext adultContext)
        {
            User user1 = new User
            {
                UserName = "Troels",
                Password = "12345",
                SecurityLevel = "1"

            };

            await adultContext.users.AddAsync(user1);
            await adultContext.SaveChangesAsync();
        }

        private static async Task SeedAdult(AdultContext adultContext)
        {


            Adult a1 = new Adult
            {
                JobTitle = "Database Manager",
                FirstName = "Yeshua",
                LastName = "Magana",
                EyeColor = "Blue",
                HairColor = "Grey",
                Age = 44,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a2 = new Adult
            {
                JobTitle = "Captain",
                FirstName = "Jayden",
                LastName = "Harrell",
                EyeColor = "Hazel",
                HairColor = "Leverpostej",
                Age = 44,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a3 = new Adult
            {
                JobTitle = "Veterenarian",
                FirstName = "Titus",
                LastName = "England",
                EyeColor = "Brown",
                HairColor = "Red",
                Age = 45,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a4 = new Adult
            {
                JobTitle = "ITManager",
                FirstName = "Skylah",
                LastName = "Hernandez",
                EyeColor = "Green",
                HairColor = "Brown",
                Age = 38,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a5 = new Adult
            {
                JobTitle = "Personal Tranier",
                FirstName = "Zaid",
                LastName = "Dalton",
                EyeColor = "Blue",
                HairColor = "Black",
                Age = 38,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a6 = new Adult
            {
                JobTitle = "Talent Acquisition Coordinator",
                FirstName = "Ulises",
                LastName = "Lewis",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a7 = new Adult
            {
                JobTitle = "Electrical Engineer",
                FirstName = "Colt",
                LastName = "Lewis",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 42,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a8 = new Adult
            {
                JobTitle = "Front Desk Coordinator",
                FirstName = "Zaynab",
                LastName = "Schultz",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 34,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a9 = new Adult
            {
                JobTitle = "Aquatic Ecologist",
                FirstName = "Kaidence",
                LastName = "Ferguson",
                EyeColor = "Brown",
                HairColor = "Brown",
                Age = 37,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };
            Adult a10 = new Adult
            {
                JobTitle = "Casino Host",
                FirstName = "Magnus",
                LastName = "Rivas",
                EyeColor = "Brown",
                HairColor = "Brown",
                Age = 53,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a11 = new Adult
            {
                JobTitle = "Chemist",
                FirstName = "Zayne",
                LastName = "Douglas",
                EyeColor = "Grey",
                HairColor = "Black",
                Age = 48,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a12 = new Adult
            {
                JobTitle = "Business Development Manager",
                FirstName = "Mustafa",
                LastName = "Mckay",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a13 = new Adult
            {
                JobTitle = "Hairdresser",
                FirstName = "Landry",
                LastName = "Armstrong",
                EyeColor = "Blue",
                HairColor = "Brown",
                Age = 58,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a14 = new Adult
            {
                JobTitle = "Meeting Planner",
                FirstName = "Jace",
                LastName = "Orr",
                EyeColor = "Grey",
                HairColor = "Green",
                Age = 51,
                Weight = 61.4f,
                Height = 166,
                Sex = "M"
            };
            Adult a15 = new Adult
            {
                JobTitle = "Gardener",
                FirstName = "Kehlani",
                LastName = "Hernandez",
                EyeColor = "Brown",
                HairColor = "Black",
                Age = 45,
                Weight = 61.4f,
                Height = 166,
                Sex = "F"
            };

            await adultContext.adults.AddAsync(a1);
            await adultContext.adults.AddAsync(a2);
            await adultContext.adults.AddAsync(a3);
            await adultContext.adults.AddAsync(a4);
            await adultContext.adults.AddAsync(a5);
            await adultContext.adults.AddAsync(a6);
            await adultContext.adults.AddAsync(a7);
            await adultContext.adults.AddAsync(a8);
            await adultContext.adults.AddAsync(a9);
            await adultContext.adults.AddAsync(a10);
            await adultContext.adults.AddAsync(a11);
            await adultContext.adults.AddAsync(a12);
            await adultContext.adults.AddAsync(a13);
            await adultContext.adults.AddAsync(a14);
            await adultContext.adults.AddAsync(a15);
            await adultContext.SaveChangesAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}