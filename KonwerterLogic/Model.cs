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

        public virtual DbSet<STATISTICS> STATISTICS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<STATISTICS>()
                .Property(e => e.CONVERTED_FROM_VAL);

            modelBuilder.Entity<STATISTICS>()
                .Property(e => e.CONVERTED_TO_VAL);

            modelBuilder.Entity<STATISTICS>()
                .Property(e => e.CONVERTED_FROM)
                .IsUnicode(false);

            modelBuilder.Entity<STATISTICS>()
                .Property(e => e.CONVERTED_TO)
                .IsUnicode(false);

            modelBuilder.Entity<STATISTICS>()
                .Property(e => e.TYPE)
                .IsUnicode(false);
        }
    }
}