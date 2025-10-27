using Microsoft.AspNetCore.Mvc;
using RandomUser.Application.Commands;

namespace RandomUser.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DbController : ControllerBase
{
    private readonly FetchSaveUsersCommand _fetchSaveUsers;
    private readonly ClearDbCommand _clearDb;

    public DbController(FetchSaveUsersCommand fetchSaveUsers, ClearDbCommand clearDb)
    {
        _fetchSaveUsers = fetchSaveUsers;
        _clearDb = clearDb;
    }

    [HttpPost("FetchUsers")]
    public async Task<ActionResult> FetchUsers([FromQuery] int count = 50)
    {
        var addedCount = await _fetchSaveUsers.ExecuteAsync(count);
        
        return Ok(new { message = $"{addedCount} rows affected" });
    }
    
    [HttpDelete("ClearDatabase")]
    public async Task<ActionResult> ClearDatabase()
    {
        var deletedCount = await _clearDb.ExecuteAsync();
        
        return Ok(new { message = $"{deletedCount} rows affected" });
    }
}