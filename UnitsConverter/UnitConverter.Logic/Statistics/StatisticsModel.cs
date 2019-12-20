using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Units_Converter.Statistics
{
    public partial class StatisticsModel : DbContext
    {
            public StatisticsModel()
                : base("name=StatisticsModel")
            {
            }

            public virtual DbSet<Statistic> Statistics { get; set; }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Statistic>()
                    .Property(e => e.Type)
                    .IsUnicode(false);

                modelBuilder.Entity<Statistic>()
                    .Property(e => e.FromUnit)
                    .IsUnicode(false);

                modelBuilder.Entity<Statistic>()
                    .Property(e => e.FromTo)
                    .IsUnicode(false);
            }
        }
    }
