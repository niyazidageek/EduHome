using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class testimonaladded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Testimonal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonPhoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testimonal", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Testimonal");
        }
    }
}
