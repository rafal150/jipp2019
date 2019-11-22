namespace Rafal_Ciupak_converter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Histr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "fromValue", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "fromValue", c => c.Double(nullable: false));
        }
    }
}
