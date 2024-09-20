using Microsoft.EntityFrameworkCore;

namespace RunningActivity.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<LocalFile> LocalFiles { get; set; }

        public DbSet<RunningRecord> RunningRecords { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<WebConfig> WebConfigs { get; set; }
    }
}
