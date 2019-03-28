using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReport.Migrations
{
    public partial class DepartmentWorksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Graduation",
                table: "Users",
                newName: "DegreeLevel");

            migrationBuilder.AddColumn<DateTime>(
                name: "DegreeDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TitleDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DepartmentWorkTopic",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Intro",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentWorkTopic",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DepartmentWorks",
                columns: table => new
                {
                    Topic = table.Column<string>(nullable: false),
                    Intro = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentWorks", x => x.Topic);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DepartmentWorkTopic",
                table: "Reports",
                column: "DepartmentWorkTopic");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DepartmentWorkTopic",
                table: "Authors",
                column: "DepartmentWorkTopic");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_DepartmentWorks_DepartmentWorkTopic",
                table: "Authors",
                column: "DepartmentWorkTopic",
                principalTable: "DepartmentWorks",
                principalColumn: "Topic",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_DepartmentWorks_DepartmentWorkTopic",
                table: "Reports",
                column: "DepartmentWorkTopic",
                principalTable: "DepartmentWorks",
                principalColumn: "Topic",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_DepartmentWorks_DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_DepartmentWorks_DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.DropTable(
                name: "DepartmentWorks");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Authors_DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "DegreeDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TitleDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Intro",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "DegreeLevel",
                table: "Users",
                newName: "Graduation");
        }
    }
}
