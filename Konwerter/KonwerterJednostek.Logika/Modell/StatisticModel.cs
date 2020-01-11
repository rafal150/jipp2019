namespace KonwerterNS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticModel : DbContext
    {
        public StatisticModel()
            : base("name=Konwerter")
        {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.FromUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.FromTo)
                .IsUnicode(false);
        }
    }
}
