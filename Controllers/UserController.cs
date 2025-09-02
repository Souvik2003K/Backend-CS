using Microsoft.AspNetCore.Mvc;
using CRUD.Models;
using CRUD.Interfaces;
using System.Threading.Tasks;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        readonly private IUserService _userservice;
        public UserController(IUserService userservice)
        {
            _userservice = userservice;
        }

        [HttpGet]
        [Route("users")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userservice.GetAllUsers();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _userservice.GetUser(id);
            if (user == null)
                return NotFound(new { message = $"User with id {id} not found" });

            return Ok(user);
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUser(UserDto userdto)
        {
            var user = new User()
            {
                Name = userdto.Name,
                Email = userdto.Email,
                Password = userdto.Password
            };

            var result = await _userservice.CreateUser(user);
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userdto)
        {
            if (id <= 0 || userdto == null)
                return BadRequest();
            var user = await _userservice.UpdateUser(userdto, id);
            if (user == null)
                return NotFound(new { message = $"User with id {id} not found" });

            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id <= 0)
                return BadRequest();
            var result = await _userservice.DeleteUser(id);
            if (!result)
                return NotFound(new { message = $"User with id {id} not found" });
            return Ok(new { message = $"User with id {id} deleted successfully" });
        }


    }
}
