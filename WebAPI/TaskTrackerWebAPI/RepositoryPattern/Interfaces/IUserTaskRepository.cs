using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface IUserTaskRepository
    {
        Task<IEnumerable<UserTask>> GetUserTaskAsync();
        UserTask GetUserTask(int id);
        bool AddUserTask(UserTask user);

        bool DeleteUserTask(int id);
    }
}
