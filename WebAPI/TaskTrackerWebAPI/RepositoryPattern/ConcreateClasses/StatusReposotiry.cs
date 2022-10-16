using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class StatusReposotiry : IStatusReposotiry
    {
        private readonly TaskTrackerDbContext _context;
        public StatusReposotiry(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public bool AddStatus(Status status)
        {
            _context.Statuses.Add(status);
            return true;
        }

        public bool DeleteStaus(int id)
        {
            var status = _context.Statuses.Find(id);
            _context.Statuses.Remove(status);
            return true;
        }

        public Status GetStatus(int id)
        {
            return _context.Statuses.Find(id);
        }

        public async Task<IEnumerable<Status>> GetStatusAsync()
        {
            return await _context.Statuses.ToListAsync();
        }
    }
}
