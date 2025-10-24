using RandomUser.Domain.Entities;
using RandomUser.Domain.Repositories;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Infrastructure.Repositories;

public class CountriesRepository : ICountriesRepository
{
	private readonly IRandomUserDbContext _context;

	public CountriesRepository(IRandomUserDbContext context)
	{
		_context = context;
	}

	public IQueryable<User> GetUsersWithLocations()
	{
		return _context.Users;
	}
}