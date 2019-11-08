namespace Konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Konwerter.Model;

    public partial class KonwContext : DbContext
    {
        public KonwContext()
            : base("name=KonwContext")
        {
        }

        public virtual DbSet<Konwerter_stat> Konwerter_stat { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
