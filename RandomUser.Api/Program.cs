using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Add DbContext with In-Memory database
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseInMemoryDatabase("RandomUserDb"));

// Add Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed data from JSON file
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<YourDbContext>();
    await SeedData(dbContext);
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

async Task SeedData(YourDbContext context)
{
    if (!await context.YourEntity.AnyAsync())
    {
        var json = await File.ReadAllTextAsync("seeddata.json");
        var data = System.Text.Json.JsonSerializer.Deserialize<List<YourEntity>>(json);
        await context.YourEntity.AddRangeAsync(data);
        await context.SaveChangesAsync();
    }
}