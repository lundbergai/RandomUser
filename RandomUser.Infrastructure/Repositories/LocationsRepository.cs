using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.Locations;

namespace RandomUser.Infrastructure.Repositories;

public class LocationsRepository : ILocationsRepository
{
    private readonly IRandomUserDbContext _context;
    
    public LocationsRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<LocationDto>> GetLocationsAsync()
    {
        return await _context.Locations
            .GroupBy(l => new { l.Country, l.State, l.City })
            .Select(g => new LocationDto
            {
                Country = g.Key.Country,
                State = g.Key.State,
                City = g.Key.City,
                UserCount = g.Count()
            })
            .OrderByDescending(l => l.Country)
            .ToListAsync();
    }
    
    public async Task<List<LocationWithStreetDto>> GetLocationsWithStreetEfficientAsync()
    {
        return await _context.Locations
            .Include(l => l.Street)
            .GroupBy(l => new { l.Country, l.State, l.City, l.Street.Name, l.Street.Number })
            .Select(g => new LocationWithStreetDto
            {
                Country = g.Key.Country,
                State = g.Key.State,
                City = g.Key.City,
                StreetName = g.Key.Name,
                StreetNumber = g.Key.Number,
                UserCount = g.Count()
            })
            .OrderByDescending(l => l.Country)
            .ToListAsync();
    }
    
    public async Task<List<LocationWithStreetDto>> GetLocationsWithStreetInefficientAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        var streets = await _context.Streets.ToListAsync();
        
        return locations
            .Join(streets,
                l => l.Id,
                s => s.Id,
                (l, s) => new { Location = l, Street = s })
            .GroupBy(x => new 
            { 
                x.Location.Country, 
                x.Location.State, 
                x.Location.City, 
                x.Street.Name, 
                x.Street.Number 
            })
            .Select(g => new LocationWithStreetDto
            {
                Country = g.Key.Country,
                State = g.Key.State,
                City = g.Key.City,
                StreetName = g.Key.Name,
                StreetNumber = g.Key.Number,
                UserCount = g.Count()
            })
            .OrderByDescending(l => l.Country)
            .ToList();
    }
}