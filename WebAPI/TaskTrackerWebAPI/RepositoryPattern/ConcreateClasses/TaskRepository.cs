using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskTrackerDbContext _context;
        public TaskRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }
        public bool AddTask(Models.Task task)
        {
            _context.Tasks.Add(task);
            return true;
        }

        public bool DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            _context.Tasks.Remove(task);
            return true;
        }

        public Models.Task GetTask(int id)
        {
            return _context.Tasks.Find(id);
        }

        public async Task<IEnumerable<Models.Task>> GetTaskAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
    }
}
