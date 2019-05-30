using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReportData.Migrations
{
    public partial class updateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Publications",
                newName: "Type");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Publications",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Publications",
                newName: "Time");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Publications",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
