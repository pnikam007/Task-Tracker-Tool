using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TaskTrackerDbContext _context;

        public ProjectRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public bool AddProject(Project project)
        {
            _context.Projects.Add(project);
            return true;
        }

        public bool DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
            return true;
        }

        public Project GetProject(int id)
        {
            return _context.Projects.Find(id);
        }

        public async Task<IEnumerable<Project>> GetProjectAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
