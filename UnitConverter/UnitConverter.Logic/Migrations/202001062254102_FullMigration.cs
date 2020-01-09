namespace UnitConverter.Logic.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FullMigration : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Converter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Created = c.DateTime(),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ConverterUnit",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConversionToBaseValueFormula = c.String(nullable: false, maxLength: 255),
                        ConversionFromBaseValueFormula = c.String(nullable: false, maxLength: 255),
                        Converter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Converter", t => t.Converter_Id)
                .Index(t => t.Converter_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConverterUnit", "Converter_Id", "dbo.Converter");
            DropIndex("dbo.ConverterUnit", new[] { "Converter_Id" });
            DropTable("dbo.ConverterUnit");
            DropTable("dbo.Converter");
        }
    }
}
