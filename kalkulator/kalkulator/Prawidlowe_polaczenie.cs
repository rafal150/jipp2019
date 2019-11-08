namespace kalkulator
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Prawidlowe_polaczenie : DbContext
    {
        public Prawidlowe_polaczenie()
            : base("name=Prawidlowe_polaczenie")
        {
        }

        public virtual DbSet<statystyki> statystyki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<statystyki>()
                .Property(e => e.KATEGORIA)
                .IsUnicode(false);

            modelBuilder.Entity<statystyki>()
                .Property(e => e.KTO)
                .IsUnicode(false);
        }
    }
}
