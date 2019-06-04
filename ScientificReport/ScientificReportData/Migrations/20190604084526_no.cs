using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReportData.Migrations
{
    public partial class no : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConferenceId",
                table: "ConferenceComments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "ConferenceComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ConferenceComments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ConferenceComments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConferenceId",
                table: "ConferenceComments");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "ConferenceComments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ConferenceComments");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ConferenceComments");
        }
    }
}
