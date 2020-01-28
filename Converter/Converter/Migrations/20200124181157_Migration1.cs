using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Converter.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UnitType = table.Column<int>(nullable: false),
                    FromUnit = table.Column<string>(nullable: true),
                    ToUnit = table.Column<string>(nullable: true),
                    FromValue = table.Column<double>(nullable: false),
                    ToValue = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationResults", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationResults");
        }
    }
}
