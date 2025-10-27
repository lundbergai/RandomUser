using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Entities;
using RandomUser.Infrastructure.Persistence;

namespace RandomUser.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RandomUserDbContext _context;

        public UsersController(RandomUserDbContext context)
        {
            _context = context;
        }
        
        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users
                .Include(u => u.Name)
                .Include(u => u.Location)
                .ThenInclude(l => l.Street)
                .Include(u => u.Location)
                .ThenInclude(l => l.Coordinates)
                .Include(u => u.Location)
                .ThenInclude(l => l.TimeZone)
                .ToListAsync();
        }
    }
}