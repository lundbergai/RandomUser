using Microsoft.EntityFrameworkCore;
using RandomUser.Api.Seed;
using RandomUser.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add DbContext with In-Memory database
builder.Services.AddDbContext<RandomUserDbContext>(options =>
    options.UseInMemoryDatabase("RandomUserDb"));

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data from JSON file
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RandomUserDbContext>();
    await Seed.SeedDataAsync(dbContext);
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    // Add CORS - only in development
    app.UseCors(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();