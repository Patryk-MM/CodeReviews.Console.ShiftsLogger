using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftsLogger.API.Patryk_MM.Migrations
{
    /// <inheritdoc />
    public partial class Initialcreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "End", "Start" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new DateTime(2026, 4, 24, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 4, 24, 8, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
