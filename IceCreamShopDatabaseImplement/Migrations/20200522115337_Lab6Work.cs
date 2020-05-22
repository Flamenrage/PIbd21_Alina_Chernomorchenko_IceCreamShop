using Microsoft.EntityFrameworkCore.Migrations;

namespace IceCreamShopDatabaseImplement.Migrations
{
    public partial class Lab6Work : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImplementerFIO",
                table: "Bookings",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ImplementerId",
                table: "Bookings",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Implementers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImplementerFIO = table.Column<string>(nullable: true),
                    WorkTime = table.Column<int>(nullable: false),
                    PauseTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Implementers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ImplementerId",
                table: "Bookings",
                column: "ImplementerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Implementers_ImplementerId",
                table: "Bookings",
                column: "ImplementerId",
                principalTable: "Implementers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Implementers_ImplementerId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "Implementers");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ImplementerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ImplementerFIO",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ImplementerId",
                table: "Bookings");
        }
    }
}
