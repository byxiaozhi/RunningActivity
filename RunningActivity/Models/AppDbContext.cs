using Microsoft.EntityFrameworkCore;

namespace RunningActivity.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
    }
}
