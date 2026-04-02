
using Microsoft.EntityFrameworkCore;
using lawyer_management_system.Models;

namespace lawyer_management_system.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Case> Cases { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
