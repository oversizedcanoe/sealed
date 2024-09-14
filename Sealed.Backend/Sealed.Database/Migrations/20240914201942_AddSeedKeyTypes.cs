using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sealed.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedKeyTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "keytype",
                columns: new[] { "keytypeid", "keytypename" },
                values: new object[,]
                {
                    { 1, "Private" },
                    { 2, "Public" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "keytype",
                keyColumn: "keytypeid",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "keytype",
                keyColumn: "keytypeid",
                keyValue: 2);
        }
    }
}
