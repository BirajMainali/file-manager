using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FileManager.Infrastructure.Migrations
{
    public partial class permission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "permission",
                schema: "auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PermissionTypes = table.Column<List<string>>(type: "text[]", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RecDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RecAuditLog = table.Column<string>(type: "text", nullable: true),
                    RecStatus = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permission_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "auth",
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_permission_UserId",
                schema: "auth",
                table: "permission",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "permission",
                schema: "auth");
        }
    }
}
