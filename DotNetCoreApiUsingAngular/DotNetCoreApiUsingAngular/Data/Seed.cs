using DotNetCoreApiUsingAngular.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreApiUsingAngular.Data
{
    public class Seed
    {
        public static async Task SeedUser(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            //var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            string jsonString = JsonConvert.SerializeObject(userData);
            var users = JsonConvert.DeserializeObject<List<AppUser>>(jsonString);

            foreach(var user in users)
            {
                using var hmac = new HMACSHA512();
                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd"));
                user.PasswordSalt = hmac.Key;

                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
