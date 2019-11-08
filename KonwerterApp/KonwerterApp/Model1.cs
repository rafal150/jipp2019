namespace KonwerterApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Polaczeniedb")
        {
        }

        public virtual DbSet<TabelaKonwertera> TabelaKonwerteras { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabelaKonwertera>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<TabelaKonwertera>()
                .Property(e => e.FromUnit)
                .IsUnicode(false);

            modelBuilder.Entity<TabelaKonwertera>()
                .Property(e => e.ToUnit)
                .IsUnicode(false);
        }
    }
}
