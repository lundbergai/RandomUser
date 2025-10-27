using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Locations;

public class GetLocationsWithStreetQuery
{
    private readonly ILocationsRepository _repository;

    public GetLocationsWithStreetQuery(ILocationsRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<List<LocationWithStreetDto>> ExecuteEfficientAsync()
    {
        return await _repository.GetLocationsWithStreetEfficientAsync();
    }

    public async Task<List<LocationWithStreetDto>> ExecuteInefficientAsync()
    {
        return await _repository.GetLocationsWithStreetInefficientAsync();
    }
}