using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReport.Migrations
{
    public partial class DepartmentWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_DepartmentWork_DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_DepartmentWork_DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentWork",
                table: "DepartmentWork");

            migrationBuilder.RenameTable(
                name: "DepartmentWork",
                newName: "DepartmentWorks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks",
                column: "Topic");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks");

            migrationBuilder.RenameTable(
                name: "DepartmentWorks",
                newName: "DepartmentWork");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentWork",
                table: "DepartmentWork",
                column: "Topic");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_DepartmentWork_DepartmentWorkTopic",
                table: "Authors",
                column: "DepartmentWorkTopic",
                principalTable: "DepartmentWork",
                principalColumn: "Topic",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_DepartmentWork_DepartmentWorkTopic",
                table: "Reports",
                column: "DepartmentWorkTopic",
                principalTable: "DepartmentWork",
                principalColumn: "Topic",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
