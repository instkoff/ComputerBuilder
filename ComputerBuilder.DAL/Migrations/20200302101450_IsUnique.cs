using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class IsUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HardwareItems_Name",
                table: "HardwareItems",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HardwareItems_Name",
                table: "HardwareItems");
        }
    }
}
