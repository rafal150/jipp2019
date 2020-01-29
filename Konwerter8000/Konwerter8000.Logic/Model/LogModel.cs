namespace Konwerter8000.Model
{
    using System.Data.Entity;


    public class LogModel : DbContext
    {

        public LogModel()
            : base("name=ModelLog")
        {
        }


        public virtual DbSet<Log> Log { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}