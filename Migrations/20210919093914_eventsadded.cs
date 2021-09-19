using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class eventsadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategory_Event_EventId",
                table: "EventCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Event_EventId",
                table: "SpeakerEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvent_Speakers_SpeakerId",
                table: "SpeakerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "SpeakerEvent",
                newName: "SpeakerEvents");

            migrationBuilder.RenameTable(
                name: "EventCategory",
                newName: "EventCategories");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_SpeakerId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvent_EventId",
                table: "SpeakerEvents",
                newName: "IX_SpeakerEvents_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_EventId",
                table: "EventCategories",
                newName: "IX_EventCategories_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategory_CategoryId",
                table: "EventCategories",
                newName: "IX_EventCategories_CategoryId");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "eventImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_eventImage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_eventImage_EventId",
                table: "eventImage",
                column: "EventId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Events_EventId",
                table: "SpeakerEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpeakerEvents_Speakers_SpeakerId",
                table: "SpeakerEvents");

            migrationBuilder.DropTable(
                name: "eventImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpeakerEvents",
                table: "SpeakerEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Events");

            migrationBuilder.RenameTable(
                name: "SpeakerEvents",
                newName: "SpeakerEvent");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "EventCategory");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_SpeakerId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_SpeakerId");

            migrationBuilder.RenameIndex(
                name: "IX_SpeakerEvents_EventId",
                table: "SpeakerEvent",
                newName: "IX_SpeakerEvent_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_EventId",
                table: "EventCategory",
                newName: "IX_EventCategory_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_CategoryId",
                table: "EventCategory",
                newName: "IX_EventCategory_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpeakerEvent",
                table: "SpeakerEvent",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategory",
                table: "EventCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Categories_CategoryId",
                table: "EventCategory",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategory_Event_EventId",
                table: "EventCategory",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Event_EventId",
                table: "SpeakerEvent",
                column: "EventId",
                principalTable: "Event",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpeakerEvent_Speakers_SpeakerId",
                table: "SpeakerEvent",
                column: "SpeakerId",
                principalTable: "Speakers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
