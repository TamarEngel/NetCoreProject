using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlaTicket.Data.Migrations
{
    public partial class relationShips3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_ProducerList_ProducerId",
                table: "EventList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList");

            migrationBuilder.DropColumn(
                name: "EventCode",
                table: "TicketList");

            migrationBuilder.DropColumn(
                name: "EventProducerId",
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

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "EventList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventList_ProducerList_ProducerId",
                table: "EventList",
                column: "ProducerId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventList_ProducerList_ProducerId",
                table: "EventList");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketList_EventList_EventId",
                table: "TicketList");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "TicketList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EventCode",
                table: "TicketList",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ProducerId",
                table: "EventList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EventProducerId",
                table: "EventList",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
