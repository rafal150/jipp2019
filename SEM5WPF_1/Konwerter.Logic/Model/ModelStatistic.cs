namespace SEM5WPF_1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelStatistic : DbContext
    {
        public ModelStatistic()
            : base("name=ModelStatistic")
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>()
                .Property(e => e.WartoscA)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.WartoscB)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.JednostkaA)
                .IsUnicode(false);

            modelBuilder.Entity<Table>()
                .Property(e => e.JednostkaB)
                .IsUnicode(false);
        }
    }
}
