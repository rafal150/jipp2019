namespace JIPP5_LAB.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsContext : DbContext
    {
        public StatisticsContext()
            : base("name=StatisticsModel")
        {
        }

        public virtual DbSet<StatisticModel> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatisticModel>()
                .Property(e => e.FromUnit)
                .IsUnicode(false);

            modelBuilder.Entity<StatisticModel>()
                .Property(e => e.ToUnit)
                .IsUnicode(false);
        }
    }
}
