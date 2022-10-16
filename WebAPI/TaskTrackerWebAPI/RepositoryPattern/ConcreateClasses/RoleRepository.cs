using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TaskTrackerDbContext _context;
        public RoleRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }
        public bool AddRole(Role role)
        {
            _context.Roles.Add(role);
            return true;
        }

        public bool DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            _context.Roles.Remove(role);
            return true;
        }

        public Role GetRole(int id)
        {
            return _context.Roles.Find(id);
        }

        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
