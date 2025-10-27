namespace RandomUser.Application.Queries.TimeZones;

public class TimeZoneDto
{
    public List<TimeZoneStats> TimeZones { get; set; } = new();
}

public class TimeZoneStats
{
    public string Offset { get; set; }
    public string Description { get; set; }
    public int UserCount { get; set; }
}