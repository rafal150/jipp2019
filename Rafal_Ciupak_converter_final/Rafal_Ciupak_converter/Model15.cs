namespace Rafal_Ciupak_converter
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model15 : DbContext
    {
        // Your context has been configured to use a 'Model15' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Rafal_Ciupak_converter.Model15' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model15' 
        // connection string in the application configuration file.
        public Model15()
            : base("name=Model15")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}