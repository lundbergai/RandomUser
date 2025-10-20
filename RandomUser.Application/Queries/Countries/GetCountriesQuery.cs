using Microsoft.EntityFrameworkCore;
using RandomUser.Infrastructure;

namespace RandomUser.Application.Queries.Countries;

public class GetCountriesQuery
{
    private readonly RandomUserDbContext _context;

    public GetCountriesQuery(RandomUserDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<CountryDto>> ExecuteAsync()
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