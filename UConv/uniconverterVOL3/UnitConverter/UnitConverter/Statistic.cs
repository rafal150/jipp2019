namespace UnitConverter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Statistic : DbContext
    {
        public Statistic()
            : base("name=Statistic")
        {
        }

        public virtual DbSet<StatisticJZ> StatisticJZs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatisticJZ>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<StatisticJZ>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<StatisticJZ>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
