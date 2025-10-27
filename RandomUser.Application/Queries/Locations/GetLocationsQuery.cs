using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Locations;

public class GetLocationsQuery
{
    private readonly ILocationsRepository _repository;

    public GetLocationsQuery(ILocationsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<LocationDto>> ExecuteAsync()
    {
        var locations = await _repository.GetLocationsAsync();
        
        return locations
            .GroupBy(l => new { l.Country, l.State, l.City })
            .Select(g => new LocationDto
            {
                Country = g.Key.Country,
                State = g.Key.State,
                City = g.Key.City,
                UserCount = g.Count()
            })
            .OrderByDescending(l => l.Country)
            .ToList();
    }
}