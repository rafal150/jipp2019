namespace converter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConverterCtx : DbContext
    {
        public ConverterCtx()
            : base("name=ConverterCtx")
        {
        }

        public virtual DbSet<Telemetry> Telemetry { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telemetry>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Telemetry>()
                .Property(e => e.UnitFrom)
                .IsUnicode(false);

            modelBuilder.Entity<Telemetry>()
                .Property(e => e.UnitTo)
                .IsUnicode(false);
        }
    }
}
