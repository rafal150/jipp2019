namespace UnitCoverterPart2.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsModel : DbContext
    {
        public StatisticsModel()
            : base("StatisticsModel")
        {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<StatisticsModel>(null);
            
            modelBuilder.Entity<Statistic>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.RawValue);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.ConvertedValue);
        }
    }
}
