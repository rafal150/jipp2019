namespace lab1
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Tabela1> Tabela1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tabela1>()
                .Property(e => e.TypJednostki)
                .IsUnicode(false);

            modelBuilder.Entity<Tabela1>()
                .Property(e => e.JednostkaZ)
                .IsUnicode(false);

            modelBuilder.Entity<Tabela1>()
                .Property(e => e.JednostkaDo)
                .IsUnicode(false);
        }
    }
}
