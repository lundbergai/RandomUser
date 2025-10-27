using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.Coordinates;

namespace RandomUser.Infrastructure.Repositories;

public class CoordinatesRepository : ICoordinatesRepository
{
    private readonly IRandomUserDbContext _context;

    public CoordinatesRepository(IRandomUserDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CoordinateDto>> GetCoordinatesAsync()
    {
        return await _context.Coordinates
            .Select(c => new CoordinateDto
            {
                Latitude = c.Latitude,
                Longitude = c.Longitude,
                Hemisphere = (c.Latitude.StartsWith("-") ? "South" : "North") +
                             (c.Longitude.StartsWith("-") ? "West" : "East")
            })
            .OrderBy(c => c.Hemisphere)
            .ToListAsync();
    }
}