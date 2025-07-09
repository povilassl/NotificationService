using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notifications",
                newSchema: "notifications");

            migrationBuilder.AlterColumn<string>(
                name: "NotificationType",
                schema: "notifications",
                table: "Notifications",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                schema: "notifications",
                table: "Notifications",
                type: "character varying(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Provider",
                schema: "notifications",
                table: "Notifications",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Provider",
                schema: "notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                schema: "notifications",
                newName: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "NotificationType",
                table: "Notifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(256)",
                oldMaxLength: 256);
        }
    }
}
