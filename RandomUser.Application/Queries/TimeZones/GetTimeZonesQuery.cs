using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.TimeZones;

public class GetTimeZonesQuery
{
    private readonly ITimeZonesRepository _repository;

    public GetTimeZonesQuery(ITimeZonesRepository repository)
    {
        _repository = repository;
    }

    public async Task<TimeZoneDto> ExecuteAsync()
    {
        var timeZones = await _repository.GetTimeZonesAsync();
        
        var timeZoneStats = timeZones
            .GroupBy(t => new { t.Offset, t.Description })
            .Select(g => new TimeZoneStats
            {
                Offset = g.Key.Offset,
                Description = g.Key.Description,
                UserCount = g.Count()
            })
            .OrderByDescending(t => t.UserCount)
            .ToList();

        return new TimeZoneDto
        {
            TimeZones = timeZoneStats
        };
    }
}