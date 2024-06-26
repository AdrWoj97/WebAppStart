﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "KategorieId", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Akcja" },
                    { 2, 2, "SciFi" },
                    { 3, 3, "Historia" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "KategorieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "KategorieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kategorie",
                keyColumn: "KategorieId",
                keyValue: 3);
        }
    }
}
