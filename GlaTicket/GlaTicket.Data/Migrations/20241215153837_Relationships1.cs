using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlaTicket.Data.Migrations
{
    public partial class Relationships1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "TicketList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TicketList_ClientId",
                table: "TicketList",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketList_EventId",
                table: "TicketList",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventList_EventProducerId",
                table: "EventList",
                column: "EventProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventList_ProducerList_EventProducerId",
                table: "EventList",
                column: "EventProducerId",
                principalTable: "ProducerList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketList_clientList_ClientId",
                table: "TicketList",
                column: "ClientId",
                principalTable: "clientList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList",
                column: "EventId",
                principalTable: "EventList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_ProducerList_EventProducerId",
                table: "EventList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_clientList_ClientId",
                table: "TicketList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList");

            migrationBuilder.DropIndex(
                name: "IX_TicketList_ClientId",
                table: "TicketList");

            migrationBuilder.DropIndex(
                name: "IX_TicketList_EventId",
                table: "TicketList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_EventProducerId",
                table: "EventList");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TicketList");
        }
    }
}
