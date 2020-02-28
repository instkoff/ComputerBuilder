using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class Rename_PropertyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "CompatibilityProperties");

            migrationBuilder.AddColumn<string>(
                name: "PropertyName",
                table: "CompatibilityProperties",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyName",
                table: "CompatibilityProperties");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CompatibilityProperties",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
