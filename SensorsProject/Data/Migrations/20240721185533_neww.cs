using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorsProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class neww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TempSensor_Position",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ph = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhData_Sensors_PhSensorId",
                        column: x => x.PhSensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhData_PhSensorId",
                table: "PhData",
                column: "PhSensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhData");

            migrationBuilder.DropColumn(
                name: "TempSensor_Position",
                table: "Sensors");
        }
    }
}
