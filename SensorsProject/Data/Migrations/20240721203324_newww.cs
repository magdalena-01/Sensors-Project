using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SensorsProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class newww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ECSensor_Position",
                table: "Sensors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ECData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Ec = table.Column<double>(type: "float", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EcSensorId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ECData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ECData_Sensors_EcSensorId",
                        column: x => x.EcSensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ECData_EcSensorId",
                table: "ECData",
                column: "EcSensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ECData");

            migrationBuilder.DropColumn(
                name: "ECSensor_Position",
                table: "Sensors");
        }
    }
}
