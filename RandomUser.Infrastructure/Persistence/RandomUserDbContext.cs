using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Infrastructure;

public class RandomUserDbContext : DbContext, IRandomUserDbContext
{
    public RandomUserDbContext(DbContextOptions<RandomUserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}