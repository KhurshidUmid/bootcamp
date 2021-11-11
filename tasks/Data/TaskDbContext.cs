using Microsoft.EntityFrameworkCore;
using tasks.Entites;


namespace tasks.Data
{
    public class TaskDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskDbContext(DbContextOptions options)
            : base(options) {}
        
        
    }
}