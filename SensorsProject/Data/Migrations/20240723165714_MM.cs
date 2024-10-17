using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorsProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class MM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pump",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pumpName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pumpType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timeOff = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pump", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pump");
        }
    }
}
