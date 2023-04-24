using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class temp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "OrderId",
                table: "FlightRates",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    FlightRateId = table.Column<Guid>(nullable: true),
                    IsDraft = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_FlightRates_FlightRateId",
                        column: x => x.FlightRateId,
                        principalTable: "FlightRates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlightRates_OrderId",
                table: "FlightRates",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FlightRateId",
                table: "Orders",
                column: "FlightRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightRates_Orders_OrderId",
                table: "FlightRates",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightRates_Orders_OrderId",
                table: "FlightRates");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_FlightRates_OrderId",
                table: "FlightRates");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FlightRates");
        }
    }
}
