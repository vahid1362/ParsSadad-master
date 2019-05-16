using Microsoft.EntityFrameworkCore.Migrations;

namespace QtasHelpDesk.DataLayer.Migrations
{
    public partial class V2019_05_16_2151 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Faq",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_UserId",
                table: "Faq",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_AppUsers_UserId",
                table: "Faq",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AppUsers_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_AppUsers_UserId",
                table: "Faq");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AppUsers_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Faq_UserId",
                table: "Faq");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Faq");
        }
    }
}
