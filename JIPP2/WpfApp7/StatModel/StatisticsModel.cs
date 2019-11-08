namespace WpfAppJIPP
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Converter : DbContext
    {
        public Converter()
            : base("name=Converter")
        {
        }


        public virtual DbSet<Statistics> Stats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {


            modelBuilder.Entity<Statistics>()
                .Property(e => e.Konwersja_z)
                .IsUnicode(false)    
                .IsFixedLength();


            modelBuilder.Entity<Statistics>()
                .Property(e => e.Konwersja_na)
                .IsFixedLength()
                .IsUnicode(false);

        }
    }
}
