using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.TimeZones;

namespace RandomUser.Infrastructure.Repositories;

public class TimeZonesRepository : ITimeZonesRepository
{
    private readonly IRandomUserDbContext _context;

    public TimeZonesRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<TimeZoneDto> GetTimeZoneStatsAsync()
    {
        var timeZoneStats = await _context.TimeZones
            .GroupBy(t => new { t.Offset, t.Description })
            .Select(g => new TimeZoneStats
            {
                Offset = g.Key.Offset,
                Description = g.Key.Description,
                UserCount = g.Count()
            })
            .OrderByDescending(t => t.UserCount)
            .ToListAsync();

        return new TimeZoneDto
        {
            TimeZones = timeZoneStats
        };
    }
}