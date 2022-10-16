using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public UserTaskController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getUserTask/{id}")]
        public UserTask GetUserTask([FromRoute] int id)
        {
            var userTask = _uow.UserTaskRepository.GetUserTask(id);
            return (userTask);
        }

        [HttpGet("getAllUserTask")]
        public async Task<IActionResult> GetUserTasks()
        {
            var user = await _uow.UserTaskRepository.GetUserTaskAsync();
            return Ok(user);
        }

        [HttpPost("addUserTask")]
        public async Task<IActionResult> AddUserTask(UserTask userTask)
        {
            _uow.UserTaskRepository.AddUserTask(userTask);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteUserTask/{id}")]
        public async Task<IActionResult> DeleteUserTask(int id)
        {
            _uow.UserTaskRepository.DeleteUserTask(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
