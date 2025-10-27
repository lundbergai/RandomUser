using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Locations;

public class GetLocationsWithStreetQuery
{
    private readonly ILocationsRepository _repository;

    public GetLocationsWithStreetQuery(ILocationsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<LocationWithStreetDto>> ExecuteAsync()
    {
        var locations = await _repository.GetLocationsWithStreetAsync();
        
        return locations
            .GroupBy(l => new { l.Country, l.State, l.City, l.Street.Name, l.Street.Number })
            .Select(g => new LocationWithStreetDto
            {
                Country = g.Key.Country,
                State = g.Key.State,
                City = g.Key.City,
                StreetName = g.Key.Name,
                StreetNumber = g.Key.Number,
                UserCount = g.Count()
            })
            .OrderByDescending(l => l.Country)
            .ToList();
    }
}