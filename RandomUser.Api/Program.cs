using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Commands;
using RandomUser.Application.Queries.Countries;
using RandomUser.Infrastructure.Persistence.Seed;
using RandomUser.Infrastructure.Persistence;
using RandomUser.Infrastructure;
using RandomUser.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Context
builder.Services.AddDbContext<RandomUserDbContext>(options =>
    options.UseSqlite("Data Source=randomuser.db"));

builder.Services.AddScoped<IRandomUserDbContext>(provider =>
    provider.GetRequiredService<RandomUserDbContext>());

// Commands
builder.Services.AddScoped<IFetchSaveUsersCommand, FetchSaveUsersCommand>();
builder.Services.AddScoped<IClearDbCommand, ClearDbCommand>();

// Queries
builder.Services.AddScoped<IGetCountriesQuery, GetCountriesQuery>();

// Other Services
builder.Services.AddScoped<IRandomUserApiService, RandomUserApiService>();
builder.Services.AddHttpClient<IRandomUserApiService, RandomUserApiService>();

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data from JSON file
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RandomUserDbContext>();
    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.EnsureCreatedAsync();
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