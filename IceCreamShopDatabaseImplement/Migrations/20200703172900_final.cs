using Microsoft.EntityFrameworkCore.Migrations;

namespace IceCreamShopDatabaseImplement.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientFIO",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ImplementerFIO",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientFIO",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImplementerFIO",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
