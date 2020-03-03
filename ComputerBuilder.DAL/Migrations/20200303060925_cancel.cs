using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class cancel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_HardwareTypes_Name",
                table: "HardwareTypes",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HardwareTypes_Name",
                table: "HardwareTypes");
        }
    }
}
