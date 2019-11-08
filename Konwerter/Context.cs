namespace Konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=SQLuczelniany")
        {
        }

        public virtual DbSet<Statistic> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistic>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.RawValue)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.ConvertedValue)
                .IsUnicode(false);
        }
    }
}
