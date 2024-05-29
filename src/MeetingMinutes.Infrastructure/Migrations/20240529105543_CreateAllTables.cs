using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateAllTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Corporate_Customer_Tbl",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Corporate_Customer_Tbl", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Individual_Customer_Tbl",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual_Customer_Tbl", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Products_Service_Tbl",
                columns: table => new
                {
                    ProductServiceId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_Service_Tbl", x => x.ProductServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Details_Tbl",
                columns: table => new
                {
                    DetailsId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProductServiceId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Details_Tbl", x => x.DetailsId);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Details_Tbl_Products_Service_Tbl_ProductServiceId",
                        column: x => x.ProductServiceId,
                        principalTable: "Products_Service_Tbl",
                        principalColumn: "ProductServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Meeting_Minutes_Master_Tbl",
                columns: table => new
                {
                    MeetingMinutesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Place = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ClientSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostSide = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agenda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discussion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datetime = table.Column<DateTime>(type: "datetime", nullable: true),
                    CorporateCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    IndividualCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    MeetingDetailsId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meeting_Minutes_Master_Tbl", x => x.MeetingMinutesId);
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Corporate_Customer_Tbl_CorporateCustomerId",
                        column: x => x.CorporateCustomerId,
                        principalTable: "Corporate_Customer_Tbl",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Individual_Customer_Tbl_IndividualCustomerId",
                        column: x => x.IndividualCustomerId,
                        principalTable: "Individual_Customer_Tbl",
                        principalColumn: "CustomerId");
                    table.ForeignKey(
                        name: "FK_Meeting_Minutes_Master_Tbl_Meeting_Minutes_Details_Tbl_MeetingDetailsId",
                        column: x => x.MeetingDetailsId,
                        principalTable: "Meeting_Minutes_Details_Tbl",
                        principalColumn: "DetailsId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_ProductServiceId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "ProductServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_CorporateCustomerId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_IndividualCustomerId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "IndividualCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "MeetingDetailsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.DropTable(
                name: "Corporate_Customer_Tbl");

            migrationBuilder.DropTable(
                name: "Individual_Customer_Tbl");

            migrationBuilder.DropTable(
                name: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropTable(
                name: "Products_Service_Tbl");
        }
    }
}
