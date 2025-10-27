using RandomUser.Application.Queries.Countries;
using RandomUser.Domain.Entities;

namespace RandomUser.Application.Interfaces;

public interface ICountriesRepository
{
	Task<List<User>> GetAllUsersAsync();
	Task<List<CountryDto>> GetCountriesByLocationsAsync();
}