namespace Konwerter_Azure.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatisticsModel : DbContext
    {
        public StatisticsModel()
            : base("name=StatisticsModel")
        {
        }

        public virtual DbSet<Grupy> Grupy { get; set; }
        public virtual DbSet<Jednostki> Jednostki { get; set; }
        public virtual DbSet<Statystyki> Statystyki { get; set; }
        public virtual DbSet<StatystykiObliczen> StatystykiObliczen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grupy>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<Grupy>()
                .HasMany(e => e.Jednostki)
                .WithRequired(e => e.Grupy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Jednostki>()
                .Property(e => e.nazwa)
                .IsUnicode(false);

            modelBuilder.Entity<Statystyki>()
                .Property(e => e.grupa)
                .IsUnicode(false);

            modelBuilder.Entity<Statystyki>()
                .Property(e => e.przeliczZ)
                .IsUnicode(false);

            modelBuilder.Entity<Statystyki>()
                .Property(e => e.dane)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Statystyki>()
                .Property(e => e.przeliczNa)
                .IsUnicode(false);

            modelBuilder.Entity<Statystyki>()
                .Property(e => e.wynik)
                .HasPrecision(10, 2);

            modelBuilder.Entity<StatystykiObliczen>()
                .Property(e => e.dane)
                .HasPrecision(10, 2);

            modelBuilder.Entity<StatystykiObliczen>()
                .Property(e => e.wynik)
                .HasPrecision(10, 2);
        }
    }
}
