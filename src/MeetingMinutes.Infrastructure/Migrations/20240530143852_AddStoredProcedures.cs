using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Corporate_Customer_Tbl",
                columns: new[] { "CustomerId", "CustomerName" },
                values: new object[,]
                {
                    { 1L, "Tech Corp" },
                    { 2L, "Finance Inc" },
                    { 3L, "Healthcare LLC" },
                    { 4L, "Education Group" },
                    { 5L, "Retail Co" },
                    { 6L, "Manufacturing Ltd" },
                    { 7L, "Agriculture Farm" },
                    { 8L, "Construction Co" },
                    { 9L, "Real Estate LLC" },
                    { 10L, "Media Group" }
                });

            migrationBuilder.InsertData(
                table: "Individual_Customer_Tbl",
                columns: new[] { "CustomerId", "CustomerName" },
                values: new object[,]
                {
                    { 1L, "John Doe" },
                    { 2L, "Jane Smith" },
                    { 3L, "Alice Johnson" },
                    { 4L, "Bob Brown" },
                    { 5L, "Charlie White" },
                    { 6L, "Diana Green" },
                    { 7L, "Ethan Black" },
                    { 8L, "Fiona Red" },
                    { 9L, "George Blue" },
                    { 10L, "Hannah Yellow" }
                });

            migrationBuilder.InsertData(
                table: "Products_Service_Tbl",
                columns: new[] { "ProductServiceId", "Name", "Type" },
                values: new object[,]
                {
                    { 1L, "Cloud-Based CRM Software", "service" },
                    { 2L, "AI-Powered Analytics Suite", "service" },
                    { 3L, "E-Commerce Platform", "service" },
                    { 4L, "Blockchain Technology Solutions", "service" },
                    { 5L, "Cybersecurity Services", "service" },
                    { 6L, "Wireless Earbuds", "product" },
                    { 7L, "Smart Home Hub", "product" },
                    { 8L, "Electric Scooter", "product" },
                    { 9L, "Solar Energy Panels", "product" },
                    { 10L, "Portable Power Bank", "product" }
                });

            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[Meeting_Minutes_Details_Save_SP]
                    @Quantity INT,
                    @Unit NVARCHAR(255),
                    @ProductServiceId BIGINT,
                    @MeetingMinutesId BIGINT
                AS
                BEGIN
                    INSERT INTO dbo.Meeting_Minutes_Details_Tbl (Quantity, Unit, ProductServiceId, MeetingMinutesId)
                    VALUES (@Quantity, @Unit, @ProductServiceId, @MeetingMinutesId);
                END;
            ");

            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[Meeting_Minutes_Master_Save_SP]
                    @Place NVARCHAR(255),
                    @ClientSide NVARCHAR(MAX),
                    @HostSide NVARCHAR(MAX),
                    @Agenda NVARCHAR(MAX),
                    @Discussion NVARCHAR(MAX),
                    @Decision NVARCHAR(MAX),
                    @Datetime DATETIME = null,
                    @CorporateCustomerId BIGINT null,
                    @IndividualCustomerId BIGINT = null,
                    @InsertedId BIGINT OUTPUT
                AS
                BEGIN
                    INSERT INTO Meeting_Minutes_Master_Tbl (
                        Place, ClientSide, HostSide, Agenda, Discussion, 
                        Decision, Datetime, CorporateCustomerId, IndividualCustomerId
                    )
                    VALUES (
                        @Place, @ClientSide, @HostSide, @Agenda, @Discussion, 
                        @Decision, @Datetime, @CorporateCustomerId, @IndividualCustomerId
                    );

                    SET @InsertedId = SCOPE_IDENTITY();
                END;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Corporate_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Individual_Customer_Tbl",
                keyColumn: "CustomerId",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "Products_Service_Tbl",
                keyColumn: "ProductServiceId",
                keyValue: 10L);
        }
    }
}
