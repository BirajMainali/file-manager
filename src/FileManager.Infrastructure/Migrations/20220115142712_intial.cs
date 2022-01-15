using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FileManager.Infrastructure.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_category_user_RecUserId",
                table: "file_category");

            migrationBuilder.DropForeignKey(
                name: "FK_file_record_info_user_RecUserId",
                table: "file_record_info");

            migrationBuilder.DropIndex(
                name: "IX_file_record_info_RecUserId",
                table: "file_record_info");

            migrationBuilder.DropIndex(
                name: "IX_file_category_RecUserId",
                table: "file_category");

            migrationBuilder.AlterColumn<long>(
                name: "Priority",
                table: "file_category",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Priority",
                table: "file_category",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_file_record_info_RecUserId",
                table: "file_record_info",
                column: "RecUserId");

            migrationBuilder.CreateIndex(
                name: "IX_file_category_RecUserId",
                table: "file_category",
                column: "RecUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_file_category_user_RecUserId",
                table: "file_category",
                column: "RecUserId",
                principalSchema: "auth",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_file_record_info_user_RecUserId",
                table: "file_record_info",
                column: "RecUserId",
                principalSchema: "auth",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
