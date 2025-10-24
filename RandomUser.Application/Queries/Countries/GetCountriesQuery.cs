using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Repositories;

namespace RandomUser.Application.Queries.Countries;

public class GetCountriesQuery : IGetCountriesQuery
{
    private readonly ICountriesRepository _repository;

    public GetCountriesQuery(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CountryDto>> ExecuteAsync()
    {
        return await _repository.GetUsersWithLocations()
            .Where(u => u.Location != null)
            .GroupBy(u => u.Location.Country)
            .Select(g => new CountryDto
            {
                Country = g.Key,
                UserCount = g.Count()
            })
            .OrderByDescending(c => c.UserCount)
            .ToListAsync();
    }
}