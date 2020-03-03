using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class removeUniqPropertyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CompatibilityProperties_PropertyType",
                table: "CompatibilityProperties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityProperties_PropertyType",
                table: "CompatibilityProperties",
                column: "PropertyType",
                unique: true);
        }
    }
}
