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
}