using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Konwenter
{
    public partial class StatisticsModel : DbContext
    {
        public StatisticsModel() : base("name=StatisticModel")
        {

        }
        public virtual DbSet<Statystyki> Statystyki { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
