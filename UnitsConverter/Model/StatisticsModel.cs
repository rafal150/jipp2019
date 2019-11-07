using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using UnitsConverter;

public partial class StatisticsModel : DbContext
{
    public StatisticsModel()
        : base("name=masterEntities1")
    {
    }

    public virtual DbSet<Statistic> Statistics { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
    }
}
