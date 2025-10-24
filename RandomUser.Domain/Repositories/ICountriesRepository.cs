using RandomUser.Domain.Entities;

namespace RandomUser.Domain.Repositories;

public interface ICountriesRepository
{
	IQueryable<User> GetUsersQuery();
}