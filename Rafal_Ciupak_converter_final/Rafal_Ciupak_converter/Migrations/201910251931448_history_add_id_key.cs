namespace Rafal_Ciupak_converter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class history_add_id_key : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Events");
            AddColumn("dbo.Events", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Events", "from", c => c.String());
            AddPrimaryKey("dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Events");
            AlterColumn("dbo.Events", "from", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Events", "Id");
            AddPrimaryKey("dbo.Events", "from");
        }
    }
}
