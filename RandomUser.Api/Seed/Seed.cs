using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using RandomUser.Infrastructure;

namespace RandomUser.Api.Seed;

public class Seed
{
    public static async Task SeedDataAsync(RandomUserDbContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            // https://randomuser.me/api/?results=50&inc=name,location,phone
            var json = await File.ReadAllTextAsync(Path.Combine("Seed", "randomUser.json"));
            
            var options = new JsonSerializerOptions
            {
                Converters = { new StringConverter() },
                PropertyNameCaseInsensitive = true
            };
            
            var data = JsonSerializer.Deserialize<UserResponse>(json, options);

            if (data?.Results != null)
            {
                await context.Users.AddRangeAsync(data.Results); 
                await context.SaveChangesAsync();
            }
        }
    }
}