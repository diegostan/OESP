using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OESP.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationsEventSource",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApplicationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageResult = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationsEventSource", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationsEventSource_ApplicationName",
                table: "ApplicationsEventSource",
                column: "ApplicationName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationsEventSource");
        }
    }
}
