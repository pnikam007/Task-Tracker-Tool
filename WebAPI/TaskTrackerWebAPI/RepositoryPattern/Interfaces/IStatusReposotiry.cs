using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;

namespace TaskTrackerWebAPI.RepositoryPattern.Interfaces
{
    public interface IStatusReposotiry
    {
        Task<IEnumerable<Status>> GetStatusAsync();

        Status GetStatus(int id);
        bool AddStatus(Status status);

        bool DeleteStaus(int id);
    }
}
