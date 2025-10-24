using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Repositories;

public interface ICountriesRepository
{
	IQueryable<User> GetUsersQuery();
}