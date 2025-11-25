using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Commands;
using RandomUser.Application.Interfaces;
using RandomUser.Application.Queries.Coordinates;
using RandomUser.Application.Queries.Countries;
using RandomUser.Application.Queries.Locations;
using RandomUser.Application.Queries.TimeZones;
using RandomUser.Application.Queries.Users;
using RandomUser.Infrastructure.Persistence;
using RandomUser.Infrastructure.Services;
using RandomUser.Infrastructure.Repositories;
using RandomUser.Infrastructure.Seed;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Simple connection string for Docker MSSQL
var connectionString = "Server=localhost,1433;Database=RandomUserDb;User Id=sa;Password=Passw0rd@123;Encrypt=false;TrustServerCertificate=true;";

builder.Services.AddDbContext<RandomUserDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IRandomUserDbContext>(provider =>
    provider.GetRequiredService<RandomUserDbContext>());

// Repositories
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ILocationsRepository, LocationsRepository>();
builder.Services.AddScoped<ICoordinatesRepository, CoordinatesRepository>();
builder.Services.AddScoped<ITimeZonesRepository, TimeZonesRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

// Commands
builder.Services.AddScoped<FetchSaveUsersCommand>();
builder.Services.AddScoped<ClearDbCommand>();

// Queries
builder.Services.AddScoped<GetCountriesQuery>();
builder.Services.AddScoped<GetLocationsQuery>();
builder.Services.AddScoped<GetLocationsWithStreetQuery>();
builder.Services.AddScoped<GetCoordinatesQuery>();
builder.Services.AddScoped<GetTimeZonesQuery>();
builder.Services.AddScoped<GetUsersQuery>();

// Other Services
builder.Services.AddScoped<IRandomUserApiService, RandomUserApiService>();
builder.Services.AddHttpClient<IRandomUserApiService, RandomUserApiService>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Initialize database and seed data
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