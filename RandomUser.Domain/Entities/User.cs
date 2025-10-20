namespace RandomUser.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public Name Name { get; set; } = null!;
    public Location Location { get; set; } = null!;
    public string Phone { get; set; }
}
