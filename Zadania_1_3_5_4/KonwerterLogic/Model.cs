namespace Konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelCon")
        {
        }

        public virtual DbSet<Kalkulator> Kalkulator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kalkulator>()
                .Property(e => e.Wartosc);

            modelBuilder.Entity<Kalkulator>()
                .Property(e => e.Przekonwertowane);

            modelBuilder.Entity<Kalkulator>()
                .Property(e => e.JednostkaWyjsciowa)
                .IsUnicode(false);

            modelBuilder.Entity<Kalkulator>()
                .Property(e => e.JednostkaDocelowa)
                .IsUnicode(false);

            modelBuilder.Entity<Kalkulator>()
                .Property(e => e.Rodzaj)
                .IsUnicode(false);
        }
    }
}