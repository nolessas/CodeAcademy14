using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeAcademy14.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Lectures",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lectures", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumber);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLectures",
                columns: table => new
                {
                    DepartmentCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LectureName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLectures", x => new { x.DepartmentCode, x.LectureName });
                    table.ForeignKey(
                        name: "FK_DepartmentLectures_Departments_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Departments",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentLectures_Lectures_LectureName",
                        column: x => x.LectureName,
                        principalTable: "Lectures",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentLectures",
                columns: table => new
                {
                    StudentNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LectureName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLectures", x => new { x.StudentNumber, x.LectureName });
                    table.ForeignKey(
                        name: "FK_StudentLectures_Lectures_LectureName",
                        column: x => x.LectureName,
                        principalTable: "Lectures",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLectures_Students_StudentNumber",
                        column: x => x.StudentNumber,
                        principalTable: "Students",
                        principalColumn: "StudentNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLectures_LectureName",
                table: "DepartmentLectures",
                column: "LectureName");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLectures_LectureName",
                table: "StudentLectures",
                column: "LectureName");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentCode",
                table: "Students",
                column: "DepartmentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentLectures");

            migrationBuilder.DropTable(
                name: "StudentLectures");

            migrationBuilder.DropTable(
                name: "Lectures");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
