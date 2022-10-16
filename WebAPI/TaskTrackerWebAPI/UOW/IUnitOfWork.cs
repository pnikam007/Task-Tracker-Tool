using System.Threading.Tasks;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.UOW
{
    public interface IUnitOfWork
    {
        IRoleRepository RoleRepository { get; }
        IStatusReposotiry StatusReposotiry { get; }
        ITaskRepository TaskRepository { get;}
        IUserRepository UserRepository { get; }
        IUserTaskRepository UserTaskRepository { get; }
        IProjectRepository ProjectRepository { get; }
        ITaskStatusRepository TaskStatusRepository { get; }

        Task<bool> SaveAsync();
    }
}
