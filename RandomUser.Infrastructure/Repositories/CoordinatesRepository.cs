using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Repositories;

public class CoordinatesRepository : ICoordinatesRepository
{
    private readonly IRandomUserDbContext _context;

    public CoordinatesRepository(IRandomUserDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Coordinates>> GetCoordinatesAsync()
    {
        return await _context.Coordinates.ToListAsync();
    }
}