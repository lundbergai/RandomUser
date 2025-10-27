using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Users;

public class GetUsersQuery
{
    private readonly IUsersRepository _repository;

    public GetUsersQuery(IUsersRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserDto>> ExecuteAsync(string? searchTerm = null)
    {
        var users = string.IsNullOrWhiteSpace(searchTerm) 
            ? await _repository.GetAllUsersAsync()
            : await _repository.SearchUsersByNameAsync(searchTerm);

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Title = u.Name.Title,
            FirstName = u.Name.First,
            LastName = u.Name.Last,
            FullName = $"{u.Name.First} {u.Name.Last}",
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
        }).ToList();
    }
}