using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public StatusController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getStatus/{id}")]
        public Status GetStatus([FromRoute] int id)
        {
            var Status = _uow.StatusReposotiry.GetStatus(id);
            return (Status);
        }

        [HttpGet("getAllStatus")]
        public async Task<IActionResult> GetStatuses()
        {
            var status = await _uow.StatusReposotiry.GetStatusAsync();
            return Ok(status);
        }

        [HttpPost("addStatus")]
        public async Task<IActionResult> AddStatus(Status status)
        {
            _uow.StatusReposotiry.AddStatus(status);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteStatus/{id}")]
        public async Task<IActionResult> DeleteStatus(int id)
        {
            _uow.StatusReposotiry.DeleteStaus(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
