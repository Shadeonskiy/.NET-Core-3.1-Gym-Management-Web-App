using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsClub.Migrations
{
    public partial class AddedCustomProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "Identity",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserNameChangeLimit",
                schema: "Identity",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "Identity",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserNameChangeLimit",
                schema: "Identity",
                table: "Users");
        }
    }
}
