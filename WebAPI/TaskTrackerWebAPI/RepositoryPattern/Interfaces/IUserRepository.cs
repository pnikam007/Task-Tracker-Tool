using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUserAsync();

        User GetUser(int id);

        bool AddUser(User user);

        bool DeleteUser(int id);
    }
}
