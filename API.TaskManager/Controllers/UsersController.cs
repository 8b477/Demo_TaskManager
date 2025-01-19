using ApplicationLayer.TaskManager.DTOs.UserDTOs;
using ApplicationLayer.TaskManager.Interfaces;
using ApplicationLayer.TaskManager.Mappers;

using DomainLayer.TaskManager.Entities;
using DomainLayer.TaskManager.Interfaces;

using Microsoft.AspNetCore.Mvc;


namespace API.TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // <--------------------------------> TODO <-------------------------------->
        // 
        // <--------------------------------> **** <-------------------------------->


        #region <-------------> DEPENDENCY <------------->
        private readonly IUsersRepository _usersRepository;
        private readonly IUserService _userService;

        public UsersController(IUsersRepository usersRepository, IUserService userService)
        {
            _usersRepository = usersRepository;
            _userService = userService;
        }
        #endregion



        #region <-------------> POST <------------->
        [HttpPost]
        public async Task<ActionResult<Users>> CreateUser(CreateUserDTO user)
        {
            var userToAdd = user.ToEntity();
            var result = await _userService.AddUserServiceAsync(userToAdd);

            if (!result.Flag)
                return BadRequest(new { result });

            return CreatedAtAction("GetUser", new { id = userToAdd.Id_User }, result.Message);
        }
        #endregion



        #region <-------------> GET <------------->
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            return Ok(users);
        }


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
        #endregion



        #region <-------------> UPDATE <------------->
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
        #endregion



        #region <-------------> DELETE <------------->
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _usersRepository.DeleteUserAsync(id);
            return NoContent();
        }
        #endregion



        #region <-------------> TOOLS <------------->

        #endregion
    }
}
