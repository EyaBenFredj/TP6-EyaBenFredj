using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TP6.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Schools",
                columns: new[] { "Id", "Director", "Name", "Rating", "Sections", "WebSite" },
                values: new object[,]
                {
                    { 1, "Dr. A", "ENISo", 4.5, "Info, Meca", "http://www.eniso.rnu.tn" },
                    { 2, "Dr. B", "ENIT", 4.0, "Civil", null },
                    { 3, "Dr. C", "ENSI", 5.0, "Info", "http://www.ensi.rnu.tn" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Schools",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
