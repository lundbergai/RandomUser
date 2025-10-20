using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure.Persistence;

public interface IRandomUserDbContext
{
    DbSet<User> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    int SaveChanges();
}