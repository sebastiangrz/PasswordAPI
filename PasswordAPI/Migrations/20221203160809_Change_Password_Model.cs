using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasswordAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Passwords",
                newName: "Username");

            migrationBuilder.AddColumn<string>(
                name: "Tag",
                table: "Passwords",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tag",
                table: "Passwords");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Passwords",
                newName: "Name");
        }
    }
}
