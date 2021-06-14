using Microsoft.EntityFrameworkCore;

namespace monitorIntegration.Models
{
    public class monitorIntegrationContext : DbContext
    {
        public monitorIntegrationContext(DbContextOptions<monitorIntegrationContext> options)
            : base(options)
        {
        }

        public DbSet<monitorInformationItem> Items { get; set; }
    }
}