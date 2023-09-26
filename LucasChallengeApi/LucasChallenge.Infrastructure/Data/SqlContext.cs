using LucasChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Infra.Data.Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options) {
        
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Supplier> Supplier { get; set; }
        
    }
}
