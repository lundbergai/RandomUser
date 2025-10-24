using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Queries.Countries;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly IGetCountriesQuery _query;

    public CountriesController(IGetCountriesQuery query)
    {
        _query = query;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryDto>>> GetCountries()
    {
        var countries = await _query.ExecuteAsync();
        
        return Ok(countries);
    }
}