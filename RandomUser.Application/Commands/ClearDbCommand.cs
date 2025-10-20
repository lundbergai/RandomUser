using Microsoft.EntityFrameworkCore;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Application.Commands;

public class ClearDbCommand : IClearDbCommand
{
    private readonly IRandomUserDbContext _dbContext;
    
    public ClearDbCommand(IRandomUserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> ExecuteAsync()
    {
        var users = await _dbContext.Users.ToListAsync();
        _dbContext.Users.RemoveRange(users);
        
        return await _dbContext.SaveChangesAsync();
    }
}