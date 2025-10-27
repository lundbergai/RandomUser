using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Coordinates;

public class GetCoordinatesQuery
{
    private readonly ICoordinatesRepository _repository;

    public GetCoordinatesQuery(ICoordinatesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CoordinatesDto>> ExecuteAsync()
    {
        var coordinates = await _repository.GetCoordinatesAsync();
        
        return coordinates.Select(c => new CoordinatesDto
        {
            Latitude = c.Latitude,
            Longitude = c.Longitude,
            Hemisphere = (c.Latitude.StartsWith("-") ? "South" : "North") +
                         (c.Longitude.StartsWith("-") ? "West" : "East")
        })
        .OrderBy(c => c.Hemisphere)
        .ToList();
    }
}