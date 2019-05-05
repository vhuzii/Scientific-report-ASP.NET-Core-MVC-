using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ScientificReportData.Migrations
{
    public partial class grant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GrantId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Grants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_GrantId",
                table: "Authors",
                column: "GrantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Grants_GrantId",
                table: "Authors",
                column: "GrantId",
                principalTable: "Grants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Grants_GrantId",
                table: "Authors");

            migrationBuilder.DropTable(
                name: "Grants");

            migrationBuilder.DropIndex(
                name: "IX_Authors_GrantId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "GrantId",
                table: "Authors");
        }
    }
}
