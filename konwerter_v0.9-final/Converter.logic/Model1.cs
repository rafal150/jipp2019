namespace konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<LenghtUnits> LenghtUnits { get; set; }
        public virtual DbSet<TempUnits> TempUnits { get; set; }
        public virtual DbSet<UsageStatistics> UsageStatistics { get; set; }
        public virtual DbSet<WieghtUnits> WieghtUnits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LenghtUnits>()
                .Property(e => e.UnitBaseValue)
                .HasPrecision(18, 12);

            modelBuilder.Entity<TempUnits>()
                .Property(e => e.UnitBaseValue)
                .HasPrecision(18, 12);

            modelBuilder.Entity<UsageStatistics>()
                .Property(e => e.Value)
                .HasPrecision(18, 12);

            modelBuilder.Entity<WieghtUnits>()
                .Property(e => e.UnitBaseValue)
                .HasPrecision(18, 12);
        }
    }
}
