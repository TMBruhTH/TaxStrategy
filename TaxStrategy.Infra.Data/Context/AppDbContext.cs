using Microsoft.EntityFrameworkCore;
using TaxStrategy.Domain.Entities;

namespace TaxStrategy.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<TaxStrategyPai> DbTaxStrategyPai { get; set; }
        public DbSet<TaxStrategyFilho> DbTaxStrategyFilho { get; set; }
    }
}
