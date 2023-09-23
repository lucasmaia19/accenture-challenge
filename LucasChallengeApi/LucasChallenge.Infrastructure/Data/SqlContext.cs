using LucasChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Infra.Data.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }
        public DbSet<Company> Company { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("dateRegister") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dateRegister").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dateRegister").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
