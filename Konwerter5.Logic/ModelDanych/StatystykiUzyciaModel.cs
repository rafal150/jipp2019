namespace Konwerter5.Logic.ModelDanych
{
    using System.Data.Entity;


    public class StatystykiUzyciaModel : DbContext
    {
        
        public StatystykiUzyciaModel()
            : base("name=ModelStatystykiUzycia")
        {
        }

        
        public virtual DbSet<StatystykiUzycia> StatystykiUzycia { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}