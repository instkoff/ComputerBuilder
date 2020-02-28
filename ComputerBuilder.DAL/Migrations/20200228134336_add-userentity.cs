using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ComputerBuilder.DAL.Migrations
{
    public partial class adduserentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "ComputerBuilds",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerBuilds_UserEntityId",
                table: "ComputerBuilds",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComputerBuilds_Users_UserEntityId",
                table: "ComputerBuilds",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComputerBuilds_Users_UserEntityId",
                table: "ComputerBuilds");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_ComputerBuilds_UserEntityId",
                table: "ComputerBuilds");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "ComputerBuilds");
        }
    }
}
