using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public ProjectController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getProject/{id}")]
        public Project GetProject([FromRoute] int id)
        {
            var project = _uow.ProjectRepository.GetProject(id);
            return (project);
        }

        [HttpGet("getAllProject")]
        public async Task<IActionResult> GetProjects()
        {
            var user = await _uow.ProjectRepository.GetProjectAsync();
            return Ok(user);
        }

        [HttpPost("addProject")]
        public async Task<IActionResult> AddProject(Project project)
        {
            _uow.ProjectRepository.AddProject(project);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteProject/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            _uow.ProjectRepository.DeleteProject(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}

