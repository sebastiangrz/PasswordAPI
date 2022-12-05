﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Passwords",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Passwords");
        }
    }
}
