using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class courseimageadde : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseImage_CourseImageId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseImageId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseImageId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "CourseImage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseImage_CourseId",
                table: "CourseImage",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseImage_Courses_CourseId",
                table: "CourseImage");

            migrationBuilder.DropIndex(
                name: "IX_CourseImage_CourseId",
                table: "CourseImage");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "CourseImage");

            migrationBuilder.AddColumn<int>(
                name: "CourseImageId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseImageId",
                table: "Courses",
                column: "CourseImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseImage_CourseImageId",
                table: "Courses",
                column: "CourseImageId",
                principalTable: "CourseImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
