using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUser.Application.Queries.Users;
using RandomUser.Domain.Entities;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly GetUsersQuery _query;

        public UsersController(GetUsersQuery query)
        {
            _query = query;
        }
        
        // GET: api/users?search=john
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers([FromQuery] string? search = null)
        {
            var users = await _query.ExecuteAsync(search);
            return Ok(users);
        }
    }
}