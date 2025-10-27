using TimeZone = RandomUser.Domain.Entities.TimeZone;

namespace RandomUser.Application.Interfaces;

public interface ITimeZonesRepository
{
    Task<List<TimeZone>> GetTimeZonesAsync();
}