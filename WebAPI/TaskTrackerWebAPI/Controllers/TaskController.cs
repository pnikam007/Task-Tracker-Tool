using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TaskController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getTask/{id}")]
        public Models.Task GetTask([FromRoute] int id)
        {
            var task = _uow.TaskRepository.GetTask(id);
            return (task);
        }

        [HttpGet("getAllTask")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _uow.TaskRepository.GetTaskAsync();
            return Ok(tasks);
        }

        [HttpPost("addTask")]
        public async Task<IActionResult> AddTask(Models.Task task)
        {
            _uow.TaskRepository.AddTask(task);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            _uow.TaskRepository.DeleteTask(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
