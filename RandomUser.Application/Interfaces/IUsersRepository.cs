using RandomUser.Domain.Entities;

namespace RandomUser.Application.Interfaces;

public interface IUsersRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<List<User>> SearchUsersByNameAsync(string searchTerm);
}