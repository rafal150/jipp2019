using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace Converter
{
    public partial class StatisticsContext : DbContext
    {
        public StatisticsContext()
            : base("name=StatisticsModel")
        {
        }

        public virtual DbSet<StatisticsDB> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}

