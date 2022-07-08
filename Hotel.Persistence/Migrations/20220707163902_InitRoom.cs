using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Persistence.Migrations
{
    public partial class InitRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<Guid>(type: "TEXT", nullable: false),
                    RoomNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomFloor = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomPlaces = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomPriceDefault = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomId",
                table: "Rooms",
                column: "RoomId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
