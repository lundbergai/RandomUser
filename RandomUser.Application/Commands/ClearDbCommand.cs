using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Commands;

public class ClearDbCommand
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