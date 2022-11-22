using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPBag.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaggageGridModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RackNo = table.Column<string>(type: "TEXT", nullable: true),
                    Bagtype = table.Column<string>(type: "TEXT", nullable: true),
                    Bagsize = table.Column<string>(type: "TEXT", nullable: true),
                    NoOfBoxes = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomNo = table.Column<string>(type: "TEXT", nullable: true),
                    BaggageReceived = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BaggageReturned = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ImageName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaggageGridModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BaggageGridModelArchive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RackNo = table.Column<string>(type: "TEXT", nullable: true),
                    Bagtype = table.Column<string>(type: "TEXT", nullable: true),
                    Bagsize = table.Column<string>(type: "TEXT", nullable: true),
                    NoOfBoxes = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomNo = table.Column<string>(type: "TEXT", nullable: true),
                    BaggageReceived = table.Column<DateTime>(type: "TEXT", nullable: true),
                    BaggageReturned = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaggageGridModelArchive", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaggageGridModel");

            migrationBuilder.DropTable(
                name: "BaggageGridModelArchive");
        }
    }
}
