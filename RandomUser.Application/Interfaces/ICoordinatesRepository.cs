using RandomUser.Domain.Entities;

namespace RandomUser.Application.Interfaces;

public interface ICoordinatesRepository
{
    Task<List<Coordinates>> GetCoordinatesAsync();
}