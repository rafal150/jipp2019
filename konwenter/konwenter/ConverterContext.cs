using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace konwenter
{
    public partial class ConverterContext : DbContext
    {
        public ConverterContext()
            : base("name=ConverterContext")
        {
        }

        public virtual DbSet<Statystyka> Statystyka { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statystyka>()
                .Property(e => e.Rodzaj)
                .IsUnicode(false);

            modelBuilder.Entity<Statystyka>()
                .Property(e => e.JednostkaWyjściowa)
                .IsUnicode(false);

            modelBuilder.Entity < Statystyka >()
                .Property(e => e.JednostkaDocelowa)
                .IsUnicode(false);
        }
    }
}

