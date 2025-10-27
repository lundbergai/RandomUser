using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.Locations;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly GetLocationsQuery _query;
    
    public LocationsController(GetLocationsQuery query)
    {
        _query = query;
    }

    [HttpGet]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocations()
    {
        var locations = await _query.ExecuteAsync();
        return Ok(locations);
    }
    
    [HttpGet("WithStreetEfficient")]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocationsEfficient()
    {
        var locations = await _query.ExecuteEfficientAsync();
        return Ok(locations);
    }
    
    [HttpGet("WithStreetInefficient")]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocationsInefficient()
    {
        var locations = await _query.ExecuteInefficientAsync();
        return Ok(locations);
    }
}