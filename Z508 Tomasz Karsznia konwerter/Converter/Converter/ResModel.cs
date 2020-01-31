using Converter;
using Microsoft.EntityFrameworkCore;

namespace UnitConverter4
{ 
    public class ResModel : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=local.db");
        }

        public DbSet<CalcResult> CalculationResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalcResult>().ToTable("CalculationResults");
        }
    }
}