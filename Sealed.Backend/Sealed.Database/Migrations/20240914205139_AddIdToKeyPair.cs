using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sealed.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIdToKeyPair : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "KeyPairId",
                table: "keypair",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeyPairId",
                table: "keypair");
        }
    }
}
