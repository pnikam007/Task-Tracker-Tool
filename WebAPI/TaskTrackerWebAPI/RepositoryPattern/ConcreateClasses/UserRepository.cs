using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTrackerWebAPI.Models;
using TaskTrackerWebAPI.RepositoryPattern.Interfaces;

namespace TaskTrackerWebAPI.RepositoryPattern.ConcreateClasses
{
    public class UserRepository : IUserRepository
    {
        private readonly TaskTrackerDbContext _context;
        public UserRepository(TaskTrackerDbContext context)
        {
            _context = context;
        }

        public bool AddUser(User user)
        {
            _context.Users.AddAsync(user);
            return true;
        }

        public bool DeleteUser(int id)
        { 
            var user = _context.Users.Find(id);
            _context.Users.Remove(user);
            return true;
        }

        public User GetUser(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<IEnumerable<User>> GetUserAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
