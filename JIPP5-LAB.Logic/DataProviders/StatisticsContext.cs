namespace JIPP5_LAB.DataProviders
{
    using System.Data.Entity;

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