using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.UOW;

namespace TaskTrackerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public RoleController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("getRole/{id}")]
        public Role GetUser([FromRoute] int id)
        {
            var role = _uow.RoleRepository.GetRole(id);
            return (role);
        }

        [HttpGet("getAllRole")]
        public async Task<IActionResult> GetRoles()
        {
            var user = await _uow.RoleRepository.GetRoleAsync();
            return Ok(user);
        }

        [HttpPost("addRole")]
        public async Task<IActionResult> AddUser(Role role)
        {
            _uow.RoleRepository.AddRole(role);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpDelete("deleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            _uow.RoleRepository.DeleteRole(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}
