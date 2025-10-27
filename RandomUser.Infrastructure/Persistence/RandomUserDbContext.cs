using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using RandomUser.Application.Interfaces;
using TimeZone = RandomUser.Domain.Entities.TimeZone;

namespace RandomUser.Infrastructure.Persistence;

public class RandomUserDbContext : DbContext, IRandomUserDbContext
{
    public RandomUserDbContext(DbContextOptions<RandomUserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Name> Names { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Coordinates> Coordinates { get; set; }
    public DbSet<TimeZone> TimeZones { get; set; }
}