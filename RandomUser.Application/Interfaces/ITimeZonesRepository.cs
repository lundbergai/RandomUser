using RandomUser.Application.Queries.TimeZones;

namespace RandomUser.Application.Interfaces;

public interface ITimeZonesRepository
{
    Task<TimeZoneDto> GetTimeZoneStatsAsync();
}