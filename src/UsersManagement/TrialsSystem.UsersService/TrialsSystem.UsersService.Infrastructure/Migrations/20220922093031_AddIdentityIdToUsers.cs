using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrialsSystem.UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityIdToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdentityId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("353644da-be6a-4bb4-ac85-d5b39ffd98e9"),
                columns: new[] { "CreatedDate", "LastModifiedDateDate" },
                values: new object[] { new DateTime(2022, 9, 22, 9, 30, 31, 633, DateTimeKind.Utc).AddTicks(7226), new DateTime(2022, 9, 22, 9, 30, 31, 633, DateTimeKind.Utc).AddTicks(7228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("353644da-be6a-4bb4-ac85-d5b39ffd98e9"),
                columns: new[] { "CreatedDate", "LastModifiedDateDate" },
                values: new object[] { new DateTime(2022, 9, 20, 5, 51, 48, 82, DateTimeKind.Utc).AddTicks(3978), new DateTime(2022, 9, 20, 5, 51, 48, 82, DateTimeKind.Utc).AddTicks(3980) });
        }
    }
}
