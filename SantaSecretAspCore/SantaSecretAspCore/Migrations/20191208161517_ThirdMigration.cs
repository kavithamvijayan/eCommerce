using Microsoft.EntityFrameworkCore.Migrations;

namespace SantaSecretAspCore.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data2",
                table: "ObjectsToSend",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Data1",
                table: "ObjectsToSend",
                newName: "image");

            migrationBuilder.AddColumn<string>(
                name: "desc",
                table: "ObjectsToSend",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "ObjectsToSend",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "shippingCost",
                table: "ObjectsToSend",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "desc",
                table: "ObjectsToSend");

            migrationBuilder.DropColumn(
                name: "price",
                table: "ObjectsToSend");

            migrationBuilder.DropColumn(
                name: "shippingCost",
                table: "ObjectsToSend");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ObjectsToSend",
                newName: "Data2");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "ObjectsToSend",
                newName: "Data1");
        }
    }
}
