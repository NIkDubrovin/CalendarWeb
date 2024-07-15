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
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Color = table.Column<long>(type: "bigint", nullable: false)
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
                    { 1, 255L, new DateTime(2024, 7, 15, 23, 55, 11, 241, DateTimeKind.Local).AddTicks(6481), "Lunch" },
                    { 2, 16711680L, new DateTime(2024, 7, 15, 19, 55, 11, 241, DateTimeKind.Local).AddTicks(6514), "Work" },
                    { 3, 32768L, new DateTime(2024, 7, 15, 15, 55, 11, 241, DateTimeKind.Local).AddTicks(6520), "Start" }
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
