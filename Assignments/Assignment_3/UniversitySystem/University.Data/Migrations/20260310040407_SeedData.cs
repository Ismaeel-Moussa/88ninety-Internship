using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "ismaeel.moussa1@gmail.com", "Ismaeel-Moussa" },
                    { 2, "fatehabdalsalam@gmail.com", "Abdulsalam-Fateh" },
                    { 3, "aeter520@gmail.com", "Ahmad-Thaer-Ater" },
                    { 4, "ihababuwardah@gmail.com", "Ihap-Abuwarda" },
                    { 5, "mohamadrimi12345@gmail.com", "Muhammed-Elrimi" },
                    { 6, "wasemalhariri13@gmail.com", "Wasem-Alhariri" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
