using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using TimeZone = RandomUser.Domain.Entities.TimeZone;

namespace RandomUser.Infrastructure.Repositories;

public class TimeZonesRepository : ITimeZonesRepository
{
    private readonly IRandomUserDbContext _context;

    public TimeZonesRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<TimeZone>> GetTimeZonesAsync()
    {
        return await _context.TimeZones.ToListAsync();
    }
}