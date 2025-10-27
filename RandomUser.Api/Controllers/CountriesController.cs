using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.Countries;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly GetCountriesQuery _query;

    public CountriesController(GetCountriesQuery query)
    {
        _query = query;
    }

    [HttpGet("UsersSet")]
    public async Task<ActionResult<List<CountryDto>>> GetCountries()
    {
        var countries = await _query.ExecuteAsync();
        
        return Ok(countries);
    }
    
    [HttpGet("CountriesSet")]
    public async Task<ActionResult<List<CountryDto>>> GetCountriesLocationSet()
    {
        var countries = await _query.ExecuteAsyncLocationsSet();
        
        return Ok(countries);
    }
}