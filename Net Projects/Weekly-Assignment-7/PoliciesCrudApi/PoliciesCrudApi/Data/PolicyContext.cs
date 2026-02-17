using Microsoft.EntityFrameworkCore;
using PoliciesCrudApi.Models;

namespace PoliciesCrudApi.Data
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options)
            : base(options)
        {
        }

        public DbSet<Policy> Policies { get; set; }
    }
}
