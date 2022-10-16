using Microsoft.EntityFrameworkCore;

namespace TaskTrackerWebAPI.Models
{
    public class TaskTrackerDbContext : DbContext
    {
        // Declare db set's here.
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }

        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9U0EL5Q;Initial Catalog=TaskTracker;Integrated Security=True");

            //UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TaskTracker;
            //               Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;
            //               ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
    }
}
