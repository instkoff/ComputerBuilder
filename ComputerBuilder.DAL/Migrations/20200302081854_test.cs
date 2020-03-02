using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                table: "HardwareItems");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "HardwareItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "HardwareTypeId",
                table: "HardwareItems",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                table: "HardwareItems",
                column: "HardwareTypeId",
                principalTable: "HardwareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                table: "HardwareItems",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                table: "HardwareItems");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturerId",
                table: "HardwareItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HardwareTypeId",
                table: "HardwareItems",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                table: "HardwareItems",
                column: "HardwareTypeId",
                principalTable: "HardwareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                table: "HardwareItems",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
