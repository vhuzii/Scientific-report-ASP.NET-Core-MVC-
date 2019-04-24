using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReportData.Migrations
{
    public partial class addPublicationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_DepartmentWorks_DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks");

            migrationBuilder.DropIndex(
                name: "IX_Authors_DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "DepartmentWorkTopic",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "DepartmentWorks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DepartmentWorks",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentWorkId",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_DepartmentWorkId",
                table: "Authors",
                column: "DepartmentWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_DepartmentWorks_DepartmentWorkId",
                table: "Authors",
                column: "DepartmentWorkId",
                principalTable: "DepartmentWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_DepartmentWorks_DepartmentWorkId",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks");

            migrationBuilder.DropIndex(
                name: "IX_Authors_DepartmentWorkId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DepartmentWorks");

            migrationBuilder.DropColumn(
                name: "DepartmentWorkId",
                table: "Authors");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "DepartmentWorks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentWorkTopic",
                table: "Authors",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentWorks",
                table: "DepartmentWorks",
                column: "Topic");

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
        }
    }
}
