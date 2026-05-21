using KS.Domain.Modules;
using Microsoft.EntityFrameworkCore;

namespace KS.Infrastructure
{
    public class KSDbContext: DbContext
    {
        public DbSet<Module> Module => Set<Module>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("");
        }
    }
}
