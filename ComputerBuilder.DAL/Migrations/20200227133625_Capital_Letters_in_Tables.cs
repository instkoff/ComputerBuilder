using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class Capital_Letters_in_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_compatibilityProperties_hardwareItems_HardwareItemId",
                table: "compatibilityProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_hardwareItems_hardwareTypes_HardwareTypeId",
                table: "hardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_hardwareItems_manufacturers_ManufacturerId",
                table: "hardwareItems");

            migrationBuilder.DropTable(
                name: "ManyBuildsToManyHwItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_manufacturers",
                table: "manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hardwareTypes",
                table: "hardwareTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hardwareItems",
                table: "hardwareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_computerBuilds",
                table: "computerBuilds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_compatibilityProperties",
                table: "compatibilityProperties");

            migrationBuilder.RenameTable(
                name: "manufacturers",
                newName: "Manufacturers");

            migrationBuilder.RenameTable(
                name: "hardwareTypes",
                newName: "HardwareTypes");

            migrationBuilder.RenameTable(
                name: "hardwareItems",
                newName: "HardwareItems");

            migrationBuilder.RenameTable(
                name: "computerBuilds",
                newName: "ComputerBuilds");

            migrationBuilder.RenameTable(
                name: "compatibilityProperties",
                newName: "CompatibilityProperties");

            migrationBuilder.RenameIndex(
                name: "IX_hardwareItems_ManufacturerId",
                table: "HardwareItems",
                newName: "IX_HardwareItems_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_hardwareItems_HardwareTypeId",
                table: "HardwareItems",
                newName: "IX_HardwareItems_HardwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_compatibilityProperties_HardwareItemId",
                table: "CompatibilityProperties",
                newName: "IX_CompatibilityProperties_HardwareItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareTypes",
                table: "HardwareTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HardwareItems",
                table: "HardwareItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComputerBuilds",
                table: "ComputerBuilds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompatibilityProperties",
                table: "CompatibilityProperties",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ComputerBuildHardwareItem",
                columns: table => new
                {
                    HardwareItemId = table.Column<int>(nullable: false),
                    ComputerBuildId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerBuildHardwareItem", x => new { x.ComputerBuildId, x.HardwareItemId });
                    table.ForeignKey(
                        name: "FK_ComputerBuildHardwareItem_ComputerBuilds_ComputerBuildId",
                        column: x => x.ComputerBuildId,
                        principalTable: "ComputerBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerBuildHardwareItem_HardwareItems_HardwareItemId",
                        column: x => x.HardwareItemId,
                        principalTable: "HardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerBuildHardwareItem_HardwareItemId",
                table: "ComputerBuildHardwareItem",
                column: "HardwareItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompatibilityProperties_HardwareItems_HardwareItemId",
                table: "CompatibilityProperties",
                column: "HardwareItemId",
                principalTable: "HardwareItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompatibilityProperties_HardwareItems_HardwareItemId",
                table: "CompatibilityProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_HardwareTypes_HardwareTypeId",
                table: "HardwareItems");

            migrationBuilder.DropForeignKey(
                name: "FK_HardwareItems_Manufacturers_ManufacturerId",
                table: "HardwareItems");

            migrationBuilder.DropTable(
                name: "ComputerBuildHardwareItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Manufacturers",
                table: "Manufacturers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareTypes",
                table: "HardwareTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HardwareItems",
                table: "HardwareItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComputerBuilds",
                table: "ComputerBuilds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompatibilityProperties",
                table: "CompatibilityProperties");

            migrationBuilder.RenameTable(
                name: "Manufacturers",
                newName: "manufacturers");

            migrationBuilder.RenameTable(
                name: "HardwareTypes",
                newName: "hardwareTypes");

            migrationBuilder.RenameTable(
                name: "HardwareItems",
                newName: "hardwareItems");

            migrationBuilder.RenameTable(
                name: "ComputerBuilds",
                newName: "computerBuilds");

            migrationBuilder.RenameTable(
                name: "CompatibilityProperties",
                newName: "compatibilityProperties");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareItems_ManufacturerId",
                table: "hardwareItems",
                newName: "IX_hardwareItems_ManufacturerId");

            migrationBuilder.RenameIndex(
                name: "IX_HardwareItems_HardwareTypeId",
                table: "hardwareItems",
                newName: "IX_hardwareItems_HardwareTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CompatibilityProperties_HardwareItemId",
                table: "compatibilityProperties",
                newName: "IX_compatibilityProperties_HardwareItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_manufacturers",
                table: "manufacturers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hardwareTypes",
                table: "hardwareTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hardwareItems",
                table: "hardwareItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_computerBuilds",
                table: "computerBuilds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_compatibilityProperties",
                table: "compatibilityProperties",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ManyBuildsToManyHwItems",
                columns: table => new
                {
                    ComputerBuildId = table.Column<int>(type: "integer", nullable: false),
                    HardwareItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManyBuildsToManyHwItems", x => new { x.ComputerBuildId, x.HardwareItemId });
                    table.ForeignKey(
                        name: "FK_ManyBuildsToManyHwItems_computerBuilds_ComputerBuildId",
                        column: x => x.ComputerBuildId,
                        principalTable: "computerBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManyBuildsToManyHwItems_hardwareItems_HardwareItemId",
                        column: x => x.HardwareItemId,
                        principalTable: "hardwareItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManyBuildsToManyHwItems_HardwareItemId",
                table: "ManyBuildsToManyHwItems",
                column: "HardwareItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_compatibilityProperties_hardwareItems_HardwareItemId",
                table: "compatibilityProperties",
                column: "HardwareItemId",
                principalTable: "hardwareItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hardwareItems_hardwareTypes_HardwareTypeId",
                table: "hardwareItems",
                column: "HardwareTypeId",
                principalTable: "hardwareTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hardwareItems_manufacturers_ManufacturerId",
                table: "hardwareItems",
                column: "ManufacturerId",
                principalTable: "manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
