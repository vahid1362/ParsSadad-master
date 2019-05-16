using Microsoft.EntityFrameworkCore.Migrations;

namespace QtasHelpDesk.DataLayer.Migrations
{
    public partial class V2019_05_16_1708 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ParentId",
                table: "Groups",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups",
                column: "ParentId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Groups_ParentId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ParentId",
                table: "Groups");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "Groups",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
