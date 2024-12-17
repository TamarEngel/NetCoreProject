using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlaTicket.Data.Migrations
{
    public partial class Relationships2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_ProducerList_EventProducerId",
                table: "EventList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_EventProducerId",
                table: "EventList");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "TicketList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProducerId",
                table: "EventList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventList_ProducerId",
                table: "EventList",
                column: "ProducerId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventList_ProducerList_ProducerId",
                table: "EventList",
                column: "ProducerId",
                principalTable: "ProducerList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList",
                column: "EventId",
                principalTable: "EventList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_ProducerList_ProducerId",
                table: "EventList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList");

            migrationBuilder.DropIndex(
                name: "IX_EventList_ProducerId",
                table: "EventList");

            migrationBuilder.DropColumn(
                name: "ProducerId",
                table: "EventList");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "TicketList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList",
                column: "EventId",
                principalTable: "EventList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
