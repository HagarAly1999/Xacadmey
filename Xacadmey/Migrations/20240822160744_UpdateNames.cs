using Microsoft.EntityFrameworkCore.Migrations;

namespace Xacadmey.Migrations
{
    public partial class UpdateNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_course_department_departmentId",
                table: "course");

            migrationBuilder.DropForeignKey(
                name: "FK_instructor_course_CourseId",
                table: "instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_instructor_department_DepartmentId",
                table: "instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_traineess",
                table: "traineess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_instructor",
                table: "instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_department",
                table: "department");

            migrationBuilder.DropPrimaryKey(
                name: "PK_courseresult",
                table: "courseresult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                table: "course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_account",
                table: "account");

            migrationBuilder.DropColumn(
                name: "Dept_Id",
                table: "course");

            migrationBuilder.RenameTable(
                name: "traineess",
                newName: "Traineess");

            migrationBuilder.RenameTable(
                name: "instructor",
                newName: "Instructors");

            migrationBuilder.RenameTable(
                name: "department",
                newName: "Departments");

            migrationBuilder.RenameTable(
                name: "courseresult",
                newName: "CourseResults");

            migrationBuilder.RenameTable(
                name: "course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "account",
                newName: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Dept_Id",
                table: "Traineess",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_instructor_DepartmentId",
                table: "Instructors",
                newName: "IX_Instructors_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_instructor_CourseId",
                table: "Instructors",
                newName: "IX_Instructors_CourseId");

            migrationBuilder.RenameColumn(
                name: "Trainee_Id",
                table: "CourseResults",
                newName: "TraineeId");

            migrationBuilder.RenameColumn(
                name: "Crs_Id",
                table: "CourseResults",
                newName: "CourseId");

            migrationBuilder.RenameColumn(
                name: "departmentId",
                table: "Courses",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_course_departmentId",
                table: "Courses",
                newName: "IX_Courses_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traineess",
                table: "Traineess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departments",
                table: "Departments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Courses_CourseId",
                table: "Instructors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Courses_CourseId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Departments_DepartmentId",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Traineess",
                table: "Traineess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Instructors",
                table: "Instructors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departments",
                table: "Departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseResults",
                table: "CourseResults");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Traineess",
                newName: "traineess");

            migrationBuilder.RenameTable(
                name: "Instructors",
                newName: "instructor");

            migrationBuilder.RenameTable(
                name: "Departments",
                newName: "department");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "course");

            migrationBuilder.RenameTable(
                name: "CourseResults",
                newName: "courseresult");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "account");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "traineess",
                newName: "Dept_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_DepartmentId",
                table: "instructor",
                newName: "IX_instructor_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Instructors_CourseId",
                table: "instructor",
                newName: "IX_instructor_CourseId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "course",
                newName: "departmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DepartmentId",
                table: "course",
                newName: "IX_course_departmentId");

            migrationBuilder.RenameColumn(
                name: "TraineeId",
                table: "courseresult",
                newName: "Trainee_Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "courseresult",
                newName: "Crs_Id");

            migrationBuilder.AlterColumn<int>(
                name: "departmentId",
                table: "course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Dept_Id",
                table: "course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_traineess",
                table: "traineess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_instructor",
                table: "instructor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_department",
                table: "department",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                table: "course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_courseresult",
                table: "courseresult",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_account",
                table: "account",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_course_department_departmentId",
                table: "course",
                column: "departmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_instructor_course_CourseId",
                table: "instructor",
                column: "CourseId",
                principalTable: "course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_instructor_department_DepartmentId",
                table: "instructor",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
