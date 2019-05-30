using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReportData.Migrations
{
    public partial class updateConference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_DepartmentWorks_DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_DepartmentWorkTopic",
                table: "Reports");

            migrationBuilder.RenameColumn(
                name: "DepartmentWorkTopic",
                table: "Reports",
                newName: "DepartmentWork");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentWork",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conferences",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "DepartmentWorks",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ConferenceId",
                table: "Authors",
                column: "ConferenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Conferences_ConferenceId",
                table: "Authors",
                column: "ConferenceId",
                principalTable: "Conferences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Conferences_ConferenceId",
                table: "Authors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ConferenceId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Conferences",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "DepartmentWorks");

            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "DepartmentWork",
                table: "Reports",
                newName: "DepartmentWorkTopic");

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentWorkTopic",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DepartmentWorkTopic",
                table: "Reports",
                column: "DepartmentWorkTopic");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_DepartmentWorks_DepartmentWorkTopic",
                table: "Reports",
                column: "DepartmentWorkTopic",
                principalTable: "DepartmentWorks",
                principalColumn: "Topic",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
