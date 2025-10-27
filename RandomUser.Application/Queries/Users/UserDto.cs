namespace RandomUser.Application.Queries.Users;

public class UserDto
{
    public int Id { get; set; }
    
    // Name information
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    
    // Contact
    public string Phone { get; set; }
    
    // Location information
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Postcode { get; set; }
    
    // Street information
    public int StreetNumber { get; set; }
    public string StreetName { get; set; }
    
    // Coordinates
    public string Latitude { get; set; }
    public string Longitude { get; set; }
    
    // TimeZone
    public string TimeZoneOffset { get; set; }
    public string TimeZoneDescription { get; set; }
}