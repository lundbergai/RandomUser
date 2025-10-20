using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Commands;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DbController : ControllerBase
{
    private readonly IFetchSaveUsersCommand _fetchSaveUsers;
    private readonly IClearDbCommand _clearDb;

    public DbController(IFetchSaveUsersCommand fetchSaveUsers, IClearDbCommand clearDb)
    {
        _fetchSaveUsers = fetchSaveUsers;
        _clearDb = clearDb;
    }

    [HttpPost("fetch")]
    public async Task<ActionResult> FetchUsers([FromQuery] int count = 50)
    {
        var addedCount = await _fetchSaveUsers.ExecuteAsync(count);
        
        return Ok(new { message = $"{addedCount} rows affected" });
    }
    
    [HttpPost("clear")]
    public async Task<ActionResult> ClearDatabase()
    {
        var deletedCount = await _clearDb.ExecuteAsync();
        
        return Ok(new { message = $"{deletedCount} rows affected" });
    }
}