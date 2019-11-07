namespace Konwerter.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsModel : DbContext
    {
        public StatisticsModel()
            : base("name=StatisticsModel")
        {
        }

        public virtual DbSet<Konwerter_stat> Konwerter_stats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Konwerter_stat>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<Konwerter_stat>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<Konwerter_stat>()
                .Property(e => e.RawValue)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Konwerter_stat>()
                .Property(e => e.ConvertedValue)
                .HasPrecision(10, 3);

            modelBuilder.Entity<Konwerter_stat>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
