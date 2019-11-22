namespace Rafal_Ciupak_converter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Rafal_Ciupak_converter.ConvDatabase>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Rafal_Ciupak_converter.ConvDatabase";
        }

        protected override void Seed(Rafal_Ciupak_converter.ConvDatabase context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
