namespace UnitCoverterPart2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using UnitCoverterPart2.Model;

    public partial class ConverterContext : DbContext
    {
        public ConverterContext()
            : base("name=ConverterContext")
        {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
