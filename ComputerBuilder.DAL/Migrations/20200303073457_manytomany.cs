using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompatibilityProperties_HardwareItems_HardwareItemId",
                table: "CompatibilityProperties");

            migrationBuilder.DropIndex(
                name: "IX_CompatibilityProperties_HardwareItemId",
                table: "CompatibilityProperties");

            migrationBuilder.DropColumn(
                name: "HardwareItemId",
                table: "CompatibilityProperties");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ComputerBuilds",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CompatibilityPropertyHardwareItem",
                columns: table => new
                {
                    HardwareItemId = table.Column<int>(nullable: false),
                    CompatibilityPropertyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompatibilityPropertyHardwareItem", x => new { x.HardwareItemId, x.CompatibilityPropertyId });
                    table.ForeignKey(
                        name: "FK_CompatibilityPropertyHardwareItem_CompatibilityProperties_C~",
                        column: x => x.CompatibilityPropertyId,
                        principalTable: "CompatibilityProperties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompatibilityPropertyHardwareItem_HardwareItems_HardwareIte~",
                        column: x => x.HardwareItemId,
                        principalTable: "HardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityProperties_PropertyName",
                table: "CompatibilityProperties",
                column: "PropertyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityProperties_PropertyType",
                table: "CompatibilityProperties",
                column: "PropertyType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityPropertyHardwareItem_CompatibilityPropertyId",
                table: "CompatibilityPropertyHardwareItem",
                column: "CompatibilityPropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompatibilityPropertyHardwareItem");

            migrationBuilder.DropIndex(
                name: "IX_CompatibilityProperties_PropertyName",
                table: "CompatibilityProperties");

            migrationBuilder.DropIndex(
                name: "IX_CompatibilityProperties_PropertyType",
                table: "CompatibilityProperties");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ComputerBuilds",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HardwareItemId",
                table: "CompatibilityProperties",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CompatibilityProperties_HardwareItemId",
                table: "CompatibilityProperties",
                column: "HardwareItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompatibilityProperties_HardwareItems_HardwareItemId",
                table: "CompatibilityProperties",
                column: "HardwareItemId",
                principalTable: "HardwareItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
