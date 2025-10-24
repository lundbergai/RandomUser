namespace RandomUser.Application.Commands;

public interface IClearDbCommand
{
    Task<int> ExecuteAsync();
}