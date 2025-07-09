using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Notifications.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MakeNotificationIntoValueObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                schema: "notifications",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "notifications",
                table: "Notifications");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                schema: "notifications",
                table: "Notifications",
                columns: new[] { "NotificationType", "ExternalUserId", "Content", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                schema: "notifications",
                table: "Notifications");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "notifications",
                table: "Notifications",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                schema: "notifications",
                table: "Notifications",
                column: "Id");
        }
    }
}
