using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using System.Reflection;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Infrastructure.Seed;

public class Seed
{
    public static async Task SeedDataAsync(IRandomUserDbContext dbContext)
    {
        if (!await dbContext.Users.AnyAsync())
        {
            // https://randomuser.me/api/?results=50&inc=name,location,phone
            var assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var assemblyDirectory = Path.GetDirectoryName(assemblyLocation);
            var jsonFilePath = Path.Combine(assemblyDirectory, "Seed", "randomUser.json");

            var json = await File.ReadAllTextAsync(jsonFilePath);

            var options = new JsonSerializerOptions
            {
                Converters = { new StringConverter() },
                PropertyNameCaseInsensitive = true
            };

            var data = JsonSerializer.Deserialize<UserResponse>(json, options);

            if (data?.Results != null)
            {
                await dbContext.Users.AddRangeAsync(data.Results);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}