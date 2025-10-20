using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;

namespace RandomUser.Infrastructure;

public class RandomUserDbContext : DbContext
{
    public RandomUserDbContext(DbContextOptions<RandomUserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}