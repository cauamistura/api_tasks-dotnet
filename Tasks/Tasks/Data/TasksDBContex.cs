using Microsoft.EntityFrameworkCore;
using Tasks.Models;

namespace Tasks.Data
{
    public class TasksDBContex: DbContext
    {
        public TasksDBContex(DbContextOptions<TasksDBContex> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
