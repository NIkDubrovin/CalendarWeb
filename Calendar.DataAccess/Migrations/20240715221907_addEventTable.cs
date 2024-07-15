using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Calendar.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addEventTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Color = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Color", "Date", "Title" },
                values: new object[,]
                {
                    { 1, "FF0000", new DateTime(2024, 7, 16, 6, 19, 6, 962, DateTimeKind.Local).AddTicks(6851), "Lunch" },
                    { 2, "FFFF00", new DateTime(2024, 7, 16, 2, 19, 6, 962, DateTimeKind.Local).AddTicks(6867), "Work" },
                    { 3, "00FFFF", new DateTime(2024, 7, 15, 22, 19, 6, 962, DateTimeKind.Local).AddTicks(6869), "Start" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
