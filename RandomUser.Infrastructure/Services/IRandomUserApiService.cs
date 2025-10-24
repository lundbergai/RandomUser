using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Services;

public interface IRandomUserApiService
{
    Task<List<User>> FetchUsersAsync(int count);
}