namespace RandomUser.Application.Commands;

public interface IFetchSaveUsersCommand
{
    Task<int> ExecuteAsync(int count);
}