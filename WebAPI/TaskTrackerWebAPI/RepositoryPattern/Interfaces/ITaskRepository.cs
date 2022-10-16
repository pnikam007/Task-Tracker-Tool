using System.Collections.Generic;
using TaskTrackerWebAPI.Models;
using DotnetTask = System.Threading.Tasks;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface ITaskRepository
    {
        DotnetTask.Task<IEnumerable<Task>> GetTaskAsync();
        Task GetTask(int id);

        bool AddTask(Task task);

        bool DeleteTask(int id);
    }
}
