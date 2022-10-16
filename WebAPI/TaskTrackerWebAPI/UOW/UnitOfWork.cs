using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskTrackerDbContext _context;

        public UnitOfWork(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => new UserRepository(_context);

        public IRoleRepository RoleRepository => new RoleRepository(_context);

        public IStatusReposotiry StatusReposotiry => new StatusReposotiry(_context);

        public ITaskRepository TaskRepository => new TaskRepository(_context);

        public IUserTaskRepository UserTaskRepository => new UserTaskRepository(_context);

        public IProjectRepository ProjectRepository => new ProjectRepository(_context);

        public ITaskStatusRepository TaskStatusRepository => new TaskStatusRepository(_context);

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
