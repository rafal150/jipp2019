//namespace UnitsConverter
//{
//    using System;
//    using System.Data.Entity;
//    using System.ComponentModel.DataAnnotations.Schema;
//    using System.Linq;

//    public partial class ConverterContext : DbContext
//    {
//        public ConverterContext()
//            : base("name=masterEntities1")
//        {
//        }
        
//        public virtual DbSet<Statistic> Statistic { get; set; }

//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {

//            modelBuilder.Entity<Statistic>()
//                .Property(e => e.FromUnit)
//                .IsUnicode(false);

//            modelBuilder.Entity<Statistic>()
//                .Property(e => e.FromTo)
//                .IsUnicode(false);

//            modelBuilder.Entity<Statistic>()
//                .Property(e => e.Type)
//                .IsUnicode(false);
//        }
//    }
//}
