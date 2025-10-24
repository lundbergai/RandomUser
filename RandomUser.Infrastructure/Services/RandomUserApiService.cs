using System.Text.Json;
using RandomUser.Domain.Entities;
using RandomUser.Infrastructure.Seed;

namespace RandomUser.Infrastructure.Services;

public class RandomUserApiService : IRandomUserApiService
{
    private readonly HttpClient _client;
    private const string BaseUrl = "https://randomuser.me/api/";

    public RandomUserApiService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<User>> FetchUsersAsync(int count)
    {
        var response = await _client.GetAsync($"{BaseUrl}?results={count}&inc=name,location,phone");
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions
        {
            Converters = { new StringConverter() },
            PropertyNameCaseInsensitive = true
        };

        var apiData = JsonSerializer.Deserialize<UserResponse>(json, options);

        return apiData?.Results ?? new List<User>();
    }
}