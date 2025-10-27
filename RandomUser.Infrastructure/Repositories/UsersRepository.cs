using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IRandomUserDbContext _context;

    public UsersRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Name)
            .Include(u => u.Location)
                .ThenInclude(l => l.Street)
            .Include(u => u.Location)
                .ThenInclude(l => l.Coordinates)
            .Include(u => u.Location)
                .ThenInclude(l => l.TimeZone)
            .ToListAsync();
    }

    public async Task<List<User>> SearchUsersByNameAsync(string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        
        return await _context.Users
            .Include(u => u.Name)
            .Include(u => u.Location)
                .ThenInclude(l => l.Street)
            .Include(u => u.Location)
                .ThenInclude(l => l.Coordinates)
            .Include(u => u.Location)
                .ThenInclude(l => l.TimeZone)
            .Where(u => 
                u.Name.First.ToLower().Contains(lowerSearchTerm) ||
                u.Name.Last.ToLower().Contains(lowerSearchTerm) ||
                (u.Name.First + " " + u.Name.Last).ToLower().Contains(lowerSearchTerm))
            .ToListAsync();
    }
}