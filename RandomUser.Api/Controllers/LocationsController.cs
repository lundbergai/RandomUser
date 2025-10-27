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
    public async Task<IActionResult> GetLocations([FromQuery] bool includeStreet = false)
    {
        if (includeStreet)
        {
            var locationsWithStreet = await _getLocationsWithStreetQuery.ExecuteAsync();
            return Ok(locationsWithStreet); // Returns List<LocationWithStreetDto>
        }

        var locations = await _getLocationsQuery.ExecuteAsync();
        return Ok(locations); // Returns List<LocationDto>
    }
}