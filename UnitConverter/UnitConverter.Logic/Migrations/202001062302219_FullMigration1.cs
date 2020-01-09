namespace UnitConverter.Logic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ConverterUnit", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ConverterUnit", "Name");
        }
    }
}
