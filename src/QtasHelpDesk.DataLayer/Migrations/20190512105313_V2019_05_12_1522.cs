using Microsoft.EntityFrameworkCore.Migrations;

namespace QtasHelpDesk.DataLayer.Migrations
{
    public partial class V2019_05_12_1522 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Posts");
        }
    }
}
