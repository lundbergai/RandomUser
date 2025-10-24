namespace RandomUser.Application.Queries.Countries;

public interface IGetCountriesQuery
{
    Task<List<CountryDto>> ExecuteAsync();
}