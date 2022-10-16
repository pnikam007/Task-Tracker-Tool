using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectAsync();

        Project GetProject(int id);

        bool AddProject(Project role);

        bool DeleteProject(int id);
    }
}
