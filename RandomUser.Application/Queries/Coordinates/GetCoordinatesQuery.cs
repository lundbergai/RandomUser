using RandomUser.Application.Interfaces;

namespace RandomUser.Application.Queries.Coordinates;

public class GetCoordinatesQuery
{
    private readonly ICoordinatesRepository _repository;

    public GetCoordinatesQuery(ICoordinatesRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CoordinateDto>> ExecuteAsync()
    {
        return await _repository.GetCoordinatesAsync();
    }
}