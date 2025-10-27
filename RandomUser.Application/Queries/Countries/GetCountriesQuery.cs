using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Countries;

public class GetCountriesQuery
{
    private readonly ICountriesRepository _repository;

    public GetCountriesQuery(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CountryDto>> ExecuteAsync()
    {
        var users = await _repository.GetAllUsersAsync();

        return users
            .Where(u => u.Location != null)
            .GroupBy(u => u.Location.Country)
            .Select(g => new CountryDto
            {
                Country = g.Key,
                UserCount = g.Count()
            })
            .OrderByDescending(c => c.UserCount)
            .ToList();
    }
}