namespace Rafal_Ciupak_converter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Events", "from", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Events", "from");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "from", c => c.String());
            AlterColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Events", "Id");
        }
    }
}
