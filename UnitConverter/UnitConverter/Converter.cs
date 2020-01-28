namespace UnitConverter {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Converter : DbContext {
        public Converter()
            : base("name=Converter") {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<Statistic>()
                .Property(e => e.ConversionType)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);
        }
    }
}
