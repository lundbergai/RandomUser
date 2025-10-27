using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.Locations;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationsController : ControllerBase
{
    private readonly GetLocationsQuery _getLocationsQuery;
    private readonly GetLocationsWithStreetQuery _getLocationsWithStreetQuery;
    
    public LocationsController(
        GetLocationsQuery getLocationsQuery,
        GetLocationsWithStreetQuery getLocationsWithStreetQuery)
    {
        _getLocationsQuery = getLocationsQuery;
        _getLocationsWithStreetQuery = getLocationsWithStreetQuery;
    }

    [HttpGet]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocations()
    {
        var locations = await _getLocationsQuery.ExecuteAsync();
        return Ok(locations);
    }
    
    [HttpGet("WithStreetEfficient")]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocationsEfficient()
    {
        var locations = await _getLocationsWithStreetQuery.ExecuteEfficientAsync();
        return Ok(locations);
    }
    
    [HttpGet("WithStreetInefficient")]
    public async Task<ActionResult<List<LocationWithStreetDto>>> GetLocationsInefficient()
    {
        var locations = await _getLocationsWithStreetQuery.ExecuteInefficientAsync();
        return Ok(locations);
    }
}