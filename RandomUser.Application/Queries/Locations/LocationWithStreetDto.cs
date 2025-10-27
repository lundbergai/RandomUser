namespace RandomUser.Application.Queries.Locations;

public class LocationWithStreetDto
{
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string StreetName { get; set; }
    public int StreetNumber { get; set; }
    public int UserCount { get; set; }
}