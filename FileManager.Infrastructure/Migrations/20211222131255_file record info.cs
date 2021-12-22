using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infrastructure.Migrations
{
    public partial class filerecordinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identity",
                table: "file_record_info",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "file_record_info",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_file_record_info_UserId",
                table: "file_record_info",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_file_record_info_user_UserId",
                table: "file_record_info",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_record_info_user_UserId",
                table: "file_record_info");

            migrationBuilder.DropIndex(
                name: "IX_file_record_info_UserId",
                table: "file_record_info");

            migrationBuilder.DropColumn(
                name: "Identity",
                table: "file_record_info");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "file_record_info");
        }
    }
}
