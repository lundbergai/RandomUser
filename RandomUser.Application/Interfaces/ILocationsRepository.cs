using RandomUser.Domain.Entities;

namespace RandomUser.Application.Interfaces;

public interface ILocationsRepository
{
    Task<List<Location>> GetLocationsAsync();
    Task<List<Location>> GetLocationsWithStreetAsync();
}