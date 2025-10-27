using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.TimeZones;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeZonesController : ControllerBase
{
    private readonly GetTimeZonesQuery _query;

    public TimeZonesController(GetTimeZonesQuery query)
    {
        _query = query;
    }

    [HttpGet]
    public async Task<ActionResult<TimeZoneDto>> GetTimeZoneStats()
    {
        var stats = await _query.ExecuteAsync();
        return Ok(stats);
    }
}