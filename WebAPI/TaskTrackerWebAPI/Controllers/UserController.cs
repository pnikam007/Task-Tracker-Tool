using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UserController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getUser/{id}")]
        public User GetUser([FromRoute]int id)
        {
            var user = _uow.UserRepository.GetUser(id);
            return (user);
        }

        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _uow.UserRepository.GetUserAsync();
            return Ok(user);
        }

        [HttpPost("addUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            _uow.UserRepository.AddUser(user);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _uow.UserRepository.DeleteUser(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
