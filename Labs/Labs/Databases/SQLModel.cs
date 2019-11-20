namespace Labs
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SQLModel : DbContext
    {
        public SQLModel()
            : base("name=DBEntityModel")
        {
        }

        public virtual DbSet<SQLValues> Values { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SQLValues>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<SQLValues>()
                .Property(e => e.Subcategory)
                .IsUnicode(false);

            modelBuilder.Entity<SQLValues>()
                .Property(e => e.from)
                .IsUnicode(false);

            modelBuilder.Entity<SQLValues>()
                .Property(e => e.to)
                .IsUnicode(false);
        }
    }
}
