namespace Konwerter
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Konwerter.Model;

    public partial class Db : DbContext
    {
        public Db()
            : base("name=Db")
        {
        }

        public virtual DbSet<DbSql> Statistics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
