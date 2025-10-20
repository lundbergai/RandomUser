using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Queries.Countries;
using RandomUser.Infrastructure;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly RandomUserDbContext _context;
    private readonly GetCountriesQuery _query;

    public CountriesController(GetCountriesQuery query)
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