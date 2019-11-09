namespace UnitsConverter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConverterContext : DbContext
    {
        public ConverterContext()
            : base("name=masterEntities")
        {
        }
        
        public virtual DbSet<masterEntities> masterEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<masterEntities>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<masterEntities>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<masterEntities>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
