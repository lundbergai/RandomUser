using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using TimeZone = RandomUser.Domain.Entities.TimeZone;

namespace RandomUser.Application.Interfaces;

public interface IRandomUserDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}