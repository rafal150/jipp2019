namespace Konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrzezSqlServer : DbContext
    {
        public PrzezSqlServer()
            : base("name=SQLuczelniany")
        {
        }

        public virtual DbSet<Rekord> Rekordy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rekord>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Rekord>()
                .Property(e => e.RawValue)
                .IsUnicode(false);

            modelBuilder.Entity<Rekord>()
                .Property(e => e.ConvertedValue)
                .IsUnicode(false);
        }
    }
}
