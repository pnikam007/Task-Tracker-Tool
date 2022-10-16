using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly TaskTrackerDbContext _context;
        public UserTaskRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public bool AddUserTask(UserTask userTask)
        {
            _context.UserTasks.Add(userTask);
            return true;
        }

        public bool DeleteUserTask(int id)
        {
            var userTask = _context.UserTasks.Find(id);
            _context.UserTasks.Remove(userTask);
            return true;
        }

        public UserTask GetUserTask(int id)
        {
            return _context.UserTasks.Find(id);
        }

        public async Task<IEnumerable<UserTask>> GetUserTaskAsync()
        {
            return await _context.UserTasks.ToListAsync();
        }
    }
}
