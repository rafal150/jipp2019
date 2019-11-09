namespace KonwerterJedn
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StatystykiSQL : DbContext
    {
        public StatystykiSQL()
            : base("name=StatystykiSQLConnect")
        {
        }

        public virtual DbSet<StatsBaza> StatsBaza { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StatsBaza>()
                .Property(e => e.UnitFrom)
                .IsFixedLength();

            modelBuilder.Entity<StatsBaza>()
                .Property(e => e.UnitTo)
                .IsFixedLength();

            modelBuilder.Entity<StatsBaza>()
                .Property(e => e.ValueFrom)
                .IsFixedLength();

            modelBuilder.Entity<StatsBaza>()
                .Property(e => e.ValueTo)
                .IsFixedLength();

            modelBuilder.Entity<StatsBaza>()
                .Property(e => e.Type)
                .IsFixedLength();
        }
    }
}
