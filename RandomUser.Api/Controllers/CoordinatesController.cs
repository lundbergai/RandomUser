using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.Coordinates;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoordinatesController : ControllerBase
{
    private readonly GetCoordinatesQuery _query;

    public CoordinatesController(GetCoordinatesQuery query)
    {
        _query = query;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<CoordinateDto>>> GetLocations()
    {
        var coordinates = await _query.ExecuteAsync();
        return Ok(coordinates);
    }
}