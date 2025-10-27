using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.Countries;
using RandomUser.Domain.Entities;


namespace RandomUser.Infrastructure.Repositories;

public class CountriesRepository : ICountriesRepository
{
	private readonly IRandomUserDbContext _context;

	public CountriesRepository(IRandomUserDbContext context)
	{
		_context = context;
	}

	public async Task<List<User>> GetAllUsersAsync()
	{
		return await _context.Users
			.Include(u => u.Location)
			.ToListAsync();
	}
	
	public async Task<List<CountryDto>> GetCountriesByLocationsAsync()
	{
		return await _context.Locations
			.GroupBy(l => l.Country)
			.Select(g => new CountryDto
			{
				Country = g.Key,
				UserCount = g.Count()
			})
			.OrderByDescending(c => c.UserCount)
			.ToListAsync();
	}
}