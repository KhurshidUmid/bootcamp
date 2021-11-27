using MediaHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediaHub.Data
{
    public class MediaContext : DbContext
    {
        public DbSet<Ad> Addss { get; set; }
        public DbSet<Media> Mediass { get; set; }

        public MediaContext(DbContextOptions options)
            : base(options) { }
        
        
        
    }
}