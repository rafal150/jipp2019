namespace JIPP5_LAB.Data
{
    using JIPP5_LAB.Models;
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