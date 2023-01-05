using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsClub.Migrations
{
    public partial class addedmembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cart");

            migrationBuilder.EnsureSchema(
                name: "Club");

            migrationBuilder.CreateTable(
                name: "Memberships",
                schema: "Club",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Period = table.Column<string>(nullable: true),
                    AmountOfWorkouts = table.Column<long>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    TotalAmount = table.Column<long>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Memberships",
                schema: "Club");
        }
    }
}
