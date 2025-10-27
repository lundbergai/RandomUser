using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.Users;

namespace RandomUser.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly IRandomUserDbContext _context;

    public UsersRepository(IRandomUserDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        return await _context.Users
            .Include(u => u.Name)
            .Include(u => u.Location)
                .ThenInclude(l => l.Street)
            .Include(u => u.Location)
                .ThenInclude(l => l.Coordinates)
            .Include(u => u.Location)
                .ThenInclude(l => l.TimeZone)
            .Select(u => new UserDto
            {
                Id = u.Id,
                Title = u.Name.Title,
                FirstName = u.Name.First,
                LastName = u.Name.Last,
                FullName = u.Name.First + " " + u.Name.Last,
                Phone = u.Phone,
                Country = u.Location.Country,
                State = u.Location.State,
                City = u.Location.City,
                Postcode = u.Location.Postcode,
                StreetNumber = u.Location.Street.Number,
                StreetName = u.Location.Street.Name,
                Latitude = u.Location.Coordinates.Latitude,
                Longitude = u.Location.Coordinates.Longitude,
                TimeZoneOffset = u.Location.TimeZone.Offset,
                TimeZoneDescription = u.Location.TimeZone.Description
            })
            .ToListAsync();
    }

    public async Task<List<UserDto>> SearchUsersByNameAsync(string searchTerm)
    {
        var lowerSearchTerm = searchTerm.ToLower();
        
        return await _context.Users
            .Include(u => u.Name)
            .Include(u => u.Location)
                .ThenInclude(l => l.Street)
            .Include(u => u.Location)
                .ThenInclude(l => l.Coordinates)
            .Include(u => u.Location)
                .ThenInclude(l => l.TimeZone)
            .Where(u => 
                u.Name.First.ToLower().Contains(lowerSearchTerm) ||
                u.Name.Last.ToLower().Contains(lowerSearchTerm) ||
                (u.Name.First + " " + u.Name.Last).ToLower().Contains(lowerSearchTerm))
            .Select(u => new UserDto
            {
                Id = u.Id,
                Title = u.Name.Title,
                FirstName = u.Name.First,
                LastName = u.Name.Last,
                FullName = u.Name.First + " " + u.Name.Last,
                Phone = u.Phone,
                Country = u.Location.Country,
                State = u.Location.State,
                City = u.Location.City,
                Postcode = u.Location.Postcode,
                StreetNumber = u.Location.Street.Number,
                StreetName = u.Location.Street.Name,
                Latitude = u.Location.Coordinates.Latitude,
                Longitude = u.Location.Coordinates.Longitude,
                TimeZoneOffset = u.Location.TimeZone.Offset,
                TimeZoneDescription = u.Location.TimeZone.Description
            })
            .ToListAsync();
    }
}