using RandomUser.Application.Queries.Coordinates;

namespace RandomUser.Application.Interfaces;

public interface ICoordinatesRepository
{
    Task<List<CoordinateDto>> GetCoordinatesAsync();
}