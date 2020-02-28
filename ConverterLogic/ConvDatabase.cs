namespace ConverterLogic
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class ConvDatabase : DbContext
    {
        // Your context has been configured to use a 'ConvDatabase' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Rafal_Ciupak_converter.ConvDatabase' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ConvDatabase' 
        // connection string in the application configuration file.
        public ConvDatabase()
            : base("name=ConvDatabase")
        {
        }
        public virtual DbSet<Event> Events { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class Event
    {

        [Key]
        public int Id { get; set; }
        public DateTime date { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string fromValue { get; set; }
        public double resultValue { get; set; }


        public Event(int id, DateTime date, string from, string to, string fromValue, double resultValue)
        {
            this.Id = id;
            this.date = date;
            this.from = from;
            this.to = to;
            this.fromValue = fromValue;
            this.resultValue = resultValue;
        }

        //Entity framework w visualu po 2015 wymaga tego, po prostu inaczej wysypuje siê przy ".ToList();"
        public Event()
        {

        }

    }
}