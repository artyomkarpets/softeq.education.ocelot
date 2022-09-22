using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrialsSystem.UsersService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdentityId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("353644da-be6a-4bb4-ac85-d5b39ffd98e9"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 22, 10, 26, 27, 723, DateTimeKind.Utc).AddTicks(5013), new DateTime(2022, 9, 22, 10, 26, 27, 723, DateTimeKind.Utc).AddTicks(5016) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "IdentityId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("353644da-be6a-4bb4-ac85-d5b39ffd98e9"),
                columns: new[] { "CreatedDate", "LastModifiedDate" },
                values: new object[] { new DateTime(2022, 9, 22, 9, 30, 31, 633, DateTimeKind.Utc).AddTicks(7226), new DateTime(2022, 9, 22, 9, 30, 31, 633, DateTimeKind.Utc).AddTicks(7228) });
        }
    }
}
