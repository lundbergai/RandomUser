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

    public CountriesController(RandomUserDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<CountryDto>>> GetCountries()
    {
        return await _context.Users
            .Where(u => u.Location != null)
            .GroupBy(u => u.Location.Country)
            .Select(g => new CountryDto
            {
                Country = g.Key,
                UserCount = g.Count()
            })
            .OrderByDescending(c => c.UserCount)
            .ToListAsync();
    }

}