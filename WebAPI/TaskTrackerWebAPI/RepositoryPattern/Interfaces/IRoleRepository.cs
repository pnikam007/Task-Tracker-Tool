using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRoleAsync();

        Role GetRole(int id);

        bool AddRole(Role role);

        bool DeleteRole(int id);
    }
}
