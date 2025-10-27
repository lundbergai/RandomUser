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
        return await _repository.GetLocationsAsync();
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