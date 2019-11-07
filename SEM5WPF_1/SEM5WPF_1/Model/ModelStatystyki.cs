namespace SEM5WPF_1.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelStatystyki : DbContext
    {
        public ModelStatystyki()
            : base("name=ModelStatystyki")
        {
        }

        public virtual DbSet<Statystyki> Statystyki { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
        }
    }
}
