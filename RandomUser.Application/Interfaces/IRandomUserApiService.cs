using RandomUser.Domain.Entities;

namespace RandomUser.Application.Interfaces;

public interface IRandomUserApiService
{
    Task<List<User>> FetchUsersAsync(int count);
}