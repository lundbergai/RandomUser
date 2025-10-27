using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Users;

public class GetUsersQuery
{
    private readonly IUsersRepository _repository;

    public GetUsersQuery(IUsersRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDto>> ExecuteAsync(string? searchTerm = null)
    {
        return string.IsNullOrWhiteSpace(searchTerm) 
            ? await _repository.GetAllUsersAsync()
            : await _repository.SearchUsersByNameAsync(searchTerm);
    }
}