namespace Unitconverter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BazaUnitConverter : DbContext
    {
        public BazaUnitConverter()
            : base("name=BazaUnitConverter")
        {
        }

        public virtual DbSet<UnitConverter> UnitConverters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UnitConverter>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<UnitConverter>()
                .Property(e => e.FromUnit)
                .IsUnicode(false);

            modelBuilder.Entity<UnitConverter>()
                .Property(e => e.ToUnit)
                .IsUnicode(false);
        }
    }
}
