using Microsoft.EntityFrameworkCore.Migrations;

namespace Xacadmey.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_CourseResults_CourseId",
            //    table: "CourseResults",
            //    column: "CourseId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_CourseResults_TraineeId",
            //    table: "CourseResults",
            //    column: "TraineeId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CourseResults_Courses_CourseId",
            //    table: "CourseResults",
            //    column: "CourseId",
            //    principalTable: "Courses",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_CourseResults_Traineess_TraineeId",
            //    table: "CourseResults",
            //    column: "TraineeId",
            //    principalTable: "Traineess",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Courses_CourseId",
                table: "CourseResults");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseResults_Traineess_TraineeId",
                table: "CourseResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseResults_CourseId",
                table: "CourseResults");

            migrationBuilder.DropIndex(
                name: "IX_CourseResults_TraineeId",
                table: "CourseResults");

            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");
        }
    }
}
