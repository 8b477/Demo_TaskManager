using DomainLayer.TaskManager.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
    {
        var users = await _usersRepository.GetAllUsersAsync();
        return Ok(users);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Users>> GetUser(Guid id)
    {
        var user = await _usersRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult<Users>> CreateUser(Users user)
    {
        await _usersRepository.AddUserAsync(user);
        return CreatedAtAction("GetUser", new { id = user.Id_User }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, Users user)
    {
        if (id != user.Id_User)
        {
            return BadRequest();
        }

        await _usersRepository.UpdateUserAsync(user);
        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _usersRepository.DeleteUserAsync(id);
        return NoContent();
    }

    }
}
