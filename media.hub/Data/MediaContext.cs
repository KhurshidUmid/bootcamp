using media.hub.Entities;
using Microsoft.EntityFrameworkCore;

namespace media.hub.Data
{
    public class MediaContext : DbContext
    {
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Media> Medias { get; set; }
        public MediaContext(DbContextOptions options)
            : base(options) { }


        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Media>()
        //         .Property(media => media.SIzeInMb)
        //         .HasComputedColumnSql();
        // }

        
    }
}