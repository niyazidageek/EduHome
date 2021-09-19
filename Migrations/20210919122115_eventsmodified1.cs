using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class eventsmodified1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_eventImage_Events_EventId",
                table: "eventImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_eventImage",
                table: "eventImage");

            migrationBuilder.RenameTable(
                name: "eventImage",
                newName: "EventImage");

            migrationBuilder.RenameIndex(
                name: "IX_eventImage_EventId",
                table: "EventImage",
                newName: "IX_EventImage_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventImage",
                table: "EventImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventImage_Events_EventId",
                table: "EventImage",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventImage_Events_EventId",
                table: "EventImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventImage",
                table: "EventImage");

            migrationBuilder.RenameTable(
                name: "EventImage",
                newName: "eventImage");

            migrationBuilder.RenameIndex(
                name: "IX_EventImage_EventId",
                table: "eventImage",
                newName: "IX_eventImage_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_eventImage",
                table: "eventImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_eventImage_Events_EventId",
                table: "eventImage",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
