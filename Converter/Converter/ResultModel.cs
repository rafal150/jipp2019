using Converter;
using Microsoft.EntityFrameworkCore;

namespace UnitConverter4
{ 
    public class ResultModel : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=local.db");
        }

        public DbSet<CalculationResult> CalculationResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculationResult>().ToTable("CalculationResults");
        }
    }
}