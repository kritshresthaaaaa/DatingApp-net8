using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly DataContext _dataContext;
    public UsersController(DataContext dataContext)
    {
        _dataContext = dataContext;

    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _dataContext.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id:int}")] //api/users/3
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
        if (id == 0)
        {
            return BadRequest("Id cannot be zero");
        }
        var user = await _dataContext.Users.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return user;
    }

}
