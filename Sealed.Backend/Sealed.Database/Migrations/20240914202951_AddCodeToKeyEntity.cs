using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sealed.Database.Migrations
{
    // I have no clue how I forgot to add the most important column of this whole application when I first
    // manually made the database.

    /// <inheritdoc />
    public partial class AddCodeToKeyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Code",
                table: "key",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "key");
        }
    }
}
