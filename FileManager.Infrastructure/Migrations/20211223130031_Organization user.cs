using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FileManager.Infrastructure.Migrations
{
    public partial class Organizationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TransactionSequence",
                schema: "auth",
                table: "user",
                newName: "RecAuditLog");

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangeAt",
                schema: "auth",
                table: "user",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                schema: "auth",
                table: "user",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecDate",
                schema: "auth",
                table: "user",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrgName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Fax = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Logo = table.Column<string>(type: "text", nullable: true),
                    RecDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ChangeAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RecAuditLog = table.Column<string>(type: "text", nullable: true),
                    RecStatus = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_OrganizationId",
                schema: "auth",
                table: "user",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_organization_OrganizationId",
                schema: "auth",
                table: "user",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_organization_OrganizationId",
                schema: "auth",
                table: "user");

            migrationBuilder.DropTable(
                name: "organization");

            migrationBuilder.DropIndex(
                name: "IX_user_OrganizationId",
                schema: "auth",
                table: "user");

            migrationBuilder.DropColumn(
                name: "ChangeAt",
                schema: "auth",
                table: "user");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                schema: "auth",
                table: "user");

            migrationBuilder.DropColumn(
                name: "RecDate",
                schema: "auth",
                table: "user");

            migrationBuilder.RenameColumn(
                name: "RecAuditLog",
                schema: "auth",
                table: "user",
                newName: "TransactionSequence");
        }
    }
}
