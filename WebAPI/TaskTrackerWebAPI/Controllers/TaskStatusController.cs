using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public TaskStatusController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getTaskStatus/{id}")]
        public Models.TaskStatus GetTaskStatus([FromRoute] int id)
        {
            var taskStatus = _uow.TaskStatusRepository.GetTaskStatus(id);
            return (taskStatus);
        }

        [HttpGet("getAllTaskStatus")]
        public async Task<IActionResult> GetTaskStatuses()
        {
            var user = await _uow.TaskStatusRepository.GetTaskStatusAsync();
            return Ok(user);
        }

        [HttpPost("addTaskStatus")]
        public async Task<IActionResult> AddTaskStatus(Models.TaskStatus taskStatus)
        {
            _uow.TaskStatusRepository.AddTaskStatus(taskStatus);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteTaskStatus/{id}")]
        public async Task<IActionResult> DeleteTaskStatus(int id)
        {
            _uow.TaskStatusRepository.DeleteTaskStatus(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
