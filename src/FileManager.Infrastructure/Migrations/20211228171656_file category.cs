using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FileManager.Infrastructure.Migrations
{
    public partial class filecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                schema: "auth",
                table: "user",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                schema: "auth",
                table: "user",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                schema: "auth",
                table: "permission",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                schema: "auth",
                table: "permission",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                table: "organization",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                table: "organization",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                table: "file_record_info",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                table: "file_record_info",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FileCategoryId",
                table: "file_record_info",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "file_category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<long>(type: "bigint", nullable: true),
                    RecUserId = table.Column<long>(type: "bigint", nullable: false),
                    RecDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecAuditLog = table.Column<string>(type: "text", nullable: true),
                    RecStatus = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_file_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_file_category_organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_file_category_user_RecUserId",
                        column: x => x.RecUserId,
                        principalSchema: "auth",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_file_record_info_FileCategoryId",
                table: "file_record_info",
                column: "FileCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_file_category_OrganizationId",
                table: "file_category",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_file_category_RecUserId",
                table: "file_category",
                column: "RecUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_file_record_info_file_category_FileCategoryId",
                table: "file_record_info",
                column: "FileCategoryId",
                principalTable: "file_category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_file_record_info_file_category_FileCategoryId",
                table: "file_record_info");

            migrationBuilder.DropTable(
                name: "file_category");

            migrationBuilder.DropIndex(
                name: "IX_file_record_info_FileCategoryId",
                table: "file_record_info");

            migrationBuilder.DropColumn(
                name: "FileCategoryId",
                table: "file_record_info");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                schema: "auth",
                table: "user",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                schema: "auth",
                table: "user",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                schema: "auth",
                table: "permission",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                schema: "auth",
                table: "permission",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                table: "organization",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                table: "organization",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecDate",
                table: "file_record_info",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ChangeAt",
                table: "file_record_info",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);
        }
    }
}
