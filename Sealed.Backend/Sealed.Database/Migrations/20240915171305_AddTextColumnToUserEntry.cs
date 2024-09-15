﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sealed.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddTextColumnToUserEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntryText",
                table: "userentry",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntryText",
                table: "userentry");
        }
    }
}
