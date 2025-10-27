using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly IRandomUserDbContext _context;
    
    public LocationsRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetLocationsAsync()
    {
        return await _context.Locations.ToListAsync();
    }
    
    public async Task<List<Location>> GetLocationsWithStreetAsync()
    {
        return await _context.Locations
            .Include(l => l.Street)
            .ToListAsync();
    }
}