using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using TimeZone = RandomUser.Domain.Entities.TimeZone;

namespace RandomUser.Application.Interfaces;

public interface IRandomUserDbContext
{
    DbSet<User> Users { get; set; }
    DbSet<Name> Names { get; set; }
    DbSet<Location> Locations { get; set; }
    DbSet<Street> Streets { get; set; }
    DbSet<Coordinates> Coordinates { get; set; }
    DbSet<TimeZone> TimeZones { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}