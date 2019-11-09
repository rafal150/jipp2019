namespace MójKonwerterJednostek.Dane
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticModel : DbContext
    {
        public StatisticModel()
            : base("name=StatisticModel")
        {
        }

        public virtual DbSet<Statistic> Statistic { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>()
                .Property(e => e.RawValue)
                .HasPrecision(18, 9);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.ConvertedValue)
                .HasPrecision(18, 9);
        }
    }
}
