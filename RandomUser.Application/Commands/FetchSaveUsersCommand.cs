using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Commands;

public class FetchSaveUsersCommand
{
    private readonly IRandomUserApiService _apiService;
    private readonly IRandomUserDbContext _dbContext;

    public FetchSaveUsersCommand(IRandomUserApiService apiService, IRandomUserDbContext dbContext)
    {
        _apiService = apiService;
        _dbContext = dbContext;
    }

    public async Task<int> ExecuteAsync(int count)
    {
        var users = await _apiService.FetchUsersAsync(count);
        
        await _dbContext.Users.AddRangeAsync(users); 
        
        return await _dbContext.SaveChangesAsync();
    }
}