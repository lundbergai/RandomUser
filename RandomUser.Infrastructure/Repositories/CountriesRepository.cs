using RandomUser.Domain.Entities;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Infrastructure.Repositories;

public class CountriesRepository : ICountriesRepository
{
	private readonly IRandomUserDbContext _context;

	public CountriesRepository(IRandomUserDbContext context)
	{
		_context = context;
	}

	public IQueryable<User> GetUsersQuery()
	{
		return _context.Users;
	}
}