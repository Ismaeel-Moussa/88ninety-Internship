using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace University.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Credit", "Name" },
                values: new object[,]
                {
                    { 1, (byte)7, "Mathematics" },
                    { 2, (byte)5, "Physics" },
                    { 3, (byte)5, "Chemistry" },
                    { 4, (byte)5, "Biology" },
                    { 5, (byte)5, "Computer Science" },
                    { 6, (byte)3, "English" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
