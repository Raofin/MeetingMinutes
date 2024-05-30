using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingMinutes.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMeetingFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Master_Tbl_Meeting_Minutes_Details_Tbl_MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl");

            migrationBuilder.AddColumn<long>(
                name: "MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinutesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl",
                column: "MeetingMinutesId",
                principalTable: "Meeting_Minutes_Master_Tbl",
                principalColumn: "MeetingMinutesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Minutes_Details_Tbl_Meeting_Minutes_Master_Tbl_MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropIndex(
                name: "IX_Meeting_Minutes_Details_Tbl_MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.DropColumn(
                name: "MeetingMinutesId",
                table: "Meeting_Minutes_Details_Tbl");

            migrationBuilder.AddColumn<long>(
                name: "MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meeting_Minutes_Master_Tbl_MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "MeetingDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Minutes_Master_Tbl_Meeting_Minutes_Details_Tbl_MeetingDetailsId",
                table: "Meeting_Minutes_Master_Tbl",
                column: "MeetingDetailsId",
                principalTable: "Meeting_Minutes_Details_Tbl",
                principalColumn: "DetailsId");
        }
    }
}
