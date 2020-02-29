namespace UnitConverter.Logic.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
        }

        public virtual DbSet<MyStatistics2> MyStatistics2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyStatistics2>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<MyStatistics2>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);

            modelBuilder.Entity<MyStatistics2>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
