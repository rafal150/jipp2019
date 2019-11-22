namespace Rafal_Ciupak_converter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Events", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Id", c => c.Int(nullable: false));
        }
    }
}
