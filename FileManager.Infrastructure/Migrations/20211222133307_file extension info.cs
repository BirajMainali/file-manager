using Microsoft.EntityFrameworkCore.Migrations;

namespace FileManager.Infrastructure.Migrations
{
    public partial class fileextensioninfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "file_record_info",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "file_record_info");
        }
    }
}
