namespace UnitConverter.DataBase
{
    using System;
    using System.Data.Entity;
    using UnitConverter.Statistics;

    public class DatabaseContext : DbContext
    {
        public DbSet<Statistic> Statistics { get; set; }

        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Database.SetInitializer<DatabaseContext>(null);
            modelBuilder.Entity<Statistic>()
             .Property(e => e.type)
             .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.fromUnit)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.toUnit)
                .IsUnicode(false);
            base.OnModelCreating(modelBuilder);
          //  modelBuilder.Entity<DatabaseContext>().ToTable("Z502_05.Logs");

        }
    }
    }