namespace WpfApp1.Logic
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsDatabase : DbContext
    {
        public StatisticsDatabase()
            : base("name= StatisticsDatabase")
        {
        }

        public virtual DbSet<Statistics> StatisticsSqlSource { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistics>()
                .Property(e => e.From)
                .IsFixedLength();

            modelBuilder.Entity<Statistics>()
                .Property(e => e.To)
                .IsFixedLength();
        }
    }
}
