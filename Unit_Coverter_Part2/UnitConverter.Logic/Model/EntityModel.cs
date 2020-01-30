using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Diagnostics;

namespace UnitCoverterPart2.Model
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=EntityModel")
        {
            this.Database.Log = s=> Debug.Write(s);
        }

        public virtual DbSet<MyStatistics2> MyStatistics2 { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

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
