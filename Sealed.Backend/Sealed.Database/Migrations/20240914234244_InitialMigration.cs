using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sealed.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "keytype",
                columns: table => new
                {
                    keytypeid = table.Column<int>(type: "integer", nullable: false),
                    keytypename = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("keytype_pkey", x => x.keytypeid);
                });

            migrationBuilder.CreateTable(
                name: "key",
                columns: table => new
                {
                    keyid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    code = table.Column<Guid>(type: "uuid", nullable: false),
                    keytypeid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("key_pkey", x => x.keyid);
                    table.ForeignKey(
                        name: "key_keytypeid_fkey",
                        column: x => x.keytypeid,
                        principalTable: "keytype",
                        principalColumn: "keytypeid");
                });

            migrationBuilder.CreateTable(
                name: "keypair",
                columns: table => new
                {
                    keypairid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    privatekeyid = table.Column<long>(type: "bigint", nullable: false),
                    publickeyid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("keypair_pkey", x => x.keypairid);
                    table.ForeignKey(
                        name: "keypair_privatekeyid_fkey",
                        column: x => x.privatekeyid,
                        principalTable: "key",
                        principalColumn: "keyid");
                    table.ForeignKey(
                        name: "keypair_publickeyid_fkey",
                        column: x => x.publickeyid,
                        principalTable: "key",
                        principalColumn: "keyid");
                });

            migrationBuilder.CreateTable(
                name: "userentry",
                columns: table => new
                {
                    userentryid = table.Column<long>(type: "bigint", nullable: false),
                    publickeyid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "userentry_publickeyid_fkey",
                        column: x => x.publickeyid,
                        principalTable: "key",
                        principalColumn: "keyid");
                });

            migrationBuilder.InsertData(
                table: "keytype",
                columns: new[] { "keytypeid", "keytypename" },
                values: new object[,]
                {
                    { 1, "Private" },
                    { 2, "Public" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_key_keytypeid",
                table: "key",
                column: "keytypeid");

            migrationBuilder.CreateIndex(
                name: "IX_keypair_privatekeyid",
                table: "keypair",
                column: "privatekeyid");

            migrationBuilder.CreateIndex(
                name: "IX_keypair_publickeyid",
                table: "keypair",
                column: "publickeyid");

            migrationBuilder.CreateIndex(
                name: "IX_userentry_publickeyid",
                table: "userentry",
                column: "publickeyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "keypair");

            migrationBuilder.DropTable(
                name: "userentry");

            migrationBuilder.DropTable(
                name: "key");

            migrationBuilder.DropTable(
                name: "keytype");
        }
    }
}
