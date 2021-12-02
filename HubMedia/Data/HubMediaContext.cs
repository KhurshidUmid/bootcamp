using HubMedia.Entities;
using Microsoft.EntityFrameworkCore;

namespace HubMedia.Data
{
    public class HubMediaContext : DbContext
    {
        public HubMediaContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Ad> AAds { get; set; }

        public DbSet<Media> MMedias { get; set; }
    }

}