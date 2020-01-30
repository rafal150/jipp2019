namespace JIPP5_LAB.Bazy
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
        }
    }
}