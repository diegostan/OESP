using Microsoft.EntityFrameworkCore.Migrations;

namespace OESP.Infra.Migrations
{
    public partial class UpdateDataSource_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRunning",
                table: "ApplicationsEventSource",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRunning",
                table: "ApplicationsEventSource");
        }
    }
}
