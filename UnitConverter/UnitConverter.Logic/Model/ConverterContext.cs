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
        public virtual DbSet<Converter> Converters { get; set; }
        public virtual DbSet<ConverterUnit> ConverterUnits { get; set; }

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
