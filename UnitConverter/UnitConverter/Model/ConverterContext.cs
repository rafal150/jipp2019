namespace UnitConversion
{
    using System.Data.Entity;

    public partial class ConverterContext : DbContext
    {
        public ConverterContext()
            : base("name=ConverterContext")
        {
        }

        public virtual DbSet<ConversionHistory> ConversionHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversionHistory>()
                .Property(e => e.BaseValue)
                .HasPrecision(19, 9);

            modelBuilder.Entity<ConversionHistory>()
                .Property(e => e.TargetValue)
                .HasPrecision(19, 9);
        }
    }
}
