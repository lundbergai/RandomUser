namespace RandomUser.Domain.Entities;

public class Location
{
    public int Id { get; set; }
    public Street Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Postcode { get; set; }
    public Coordinates Coordinates { get; set; }
    public TimeZone TimeZone { get; set; }
}