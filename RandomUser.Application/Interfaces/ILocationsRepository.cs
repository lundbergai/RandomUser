using RandomUser.Application.Queries.Locations;

namespace RandomUser.Application.Interfaces;

public interface ILocationsRepository
{
    Task<List<LocationDto>> GetLocationsAsync();
    Task<List<LocationWithStreetDto>> GetLocationsWithStreetEfficientAsync(); 
    Task<List<LocationWithStreetDto>> GetLocationsWithStreetInefficientAsync();
}