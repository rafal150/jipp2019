using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Konwerter
{

    public partial class StatisticContext : DbContext
    {
        public StatisticContext()
            : base("name=Statistics")
        {
        }

        public virtual DbSet<Statystyki> Statystykis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
