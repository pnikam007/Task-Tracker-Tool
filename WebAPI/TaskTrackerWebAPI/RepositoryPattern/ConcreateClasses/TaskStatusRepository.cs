using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class TaskStatusRepository : ITaskStatusRepository
    {
        private readonly TaskTrackerDbContext _context;
        public TaskStatusRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }
        public bool AddTaskStatus(Models.TaskStatus taskStatus)
        {
            _context.TaskStatuses.Add(taskStatus);
            return true;
        }

        public bool DeleteTaskStatus(int id)
        {
            var taskStatus = _context.TaskStatuses.Find(id);
            _context.TaskStatuses.Remove(taskStatus);
            return true;
        }

        public Models.TaskStatus GetTaskStatus(int id)
        {
            return _context.TaskStatuses.Find(id);
        }

        public async Task<IEnumerable<Models.TaskStatus>> GetTaskStatusAsync()
        {
            return await _context.TaskStatuses.ToListAsync();
        }
    }
}
