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
        return await _repository.GetTimeZoneStatsAsync();
    }
}