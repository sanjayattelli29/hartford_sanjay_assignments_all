using Microsoft.EntityFrameworkCore;
using insurance_api.Models;

namespace insurance_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Policy> Policies { get; set; }
    }
}
