using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QtasHelpDesk.DataLayer.Migrations
{
    public partial class V2019_05_16_2303 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteDate",
                table: "Posts",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegisteDate",
                table: "Faq",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegisteDate",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "RegisteDate",
                table: "Faq");
        }
    }
}
