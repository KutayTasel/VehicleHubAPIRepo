using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VehicleHub.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    HeadlightsOn = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Boats",
                columns: new[] { "Id", "Color", "Created", "Deleted", "Status", "Updated" },
                values: new object[,]
                {
                    { 1, "Red", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9771), null, 1, null },
                    { 2, "White", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9772), null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Buses",
                columns: new[] { "Id", "Color", "Created", "Deleted", "Status", "Updated" },
                values: new object[,]
                {
                    { 1, "White", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9747), null, 1, null },
                    { 2, "Black", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9749), null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "Created", "Deleted", "HeadlightsOn", "NumberOfWheels", "Status", "Updated" },
                values: new object[,]
                {
                    { 1, "Red", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9583), null, false, 4, 1, null },
                    { 2, "Blue", new DateTime(2024, 9, 14, 12, 25, 17, 179, DateTimeKind.Local).AddTicks(9586), null, false, 4, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
