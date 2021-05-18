using Microsoft.EntityFrameworkCore.Migrations;

namespace SantaSecretAspCore.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ObjectsToSend",
                table: "ObjectsToSend");

            migrationBuilder.RenameTable(
                name: "ObjectsToSend",
                newName: "Gifts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Gifts",
                table: "Gifts");

            migrationBuilder.RenameTable(
                name: "Gifts",
                newName: "ObjectsToSend");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ObjectsToSend",
                table: "ObjectsToSend",
                column: "Id");
        }
    }
}
