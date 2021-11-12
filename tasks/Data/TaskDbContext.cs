using Microsoft.EntityFrameworkCore;
using tasks.Entities;


namespace tasks.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskDbContext(DbContextOptions options)
            : base(options) { }
        
        
    }
}