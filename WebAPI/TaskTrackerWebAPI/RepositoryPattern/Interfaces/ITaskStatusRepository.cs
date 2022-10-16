using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface ITaskStatusRepository
    {
        Task<IEnumerable<Models.TaskStatus>> GetTaskStatusAsync();

        Models.TaskStatus GetTaskStatus(int id);

        bool AddTaskStatus(Models.TaskStatus role);

        bool DeleteTaskStatus(int id);
    }
}
