using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ioliu.data.Migrations
{
    public partial class initIoliu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "resumes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resumes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "systemUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 24, nullable: false),
                    PassWorld = table.Column<string>(maxLength: 512, nullable: false),
                    LoginName = table.Column<DateTime>(maxLength: 128, nullable: false),
                    State = table.Column<DateTime>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Birth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    IDCard = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    Remark = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCard = table.Column<string>(nullable: true),
                    arrangement = table.Column<string>(nullable: true),
                    SchoolSystem = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    Major = table.Column<string>(nullable: true),
                    EduType = table.Column<string>(nullable: true),
                    EduForm = table.Column<string>(nullable: true),
                    EduBJ = table.Column<string>(nullable: true),
                    EduName = table.Column<string>(nullable: true),
                    EduCard = table.Column<string>(nullable: true),
                    Curriculum = table.Column<string>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.id);
                    table.ForeignKey(
                        name: "FK_educations_systemUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "systemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Work",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCard = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    WorkContent = table.Column<string>(nullable: true),
                    WorkStart = table.Column<DateTime>(nullable: false),
                    WorkEnd = table.Column<DateTime>(nullable: false),
                    Position = table.Column<string>(nullable: true),
                    SystemUserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Work", x => x.id);
                    table.ForeignKey(
                        name: "FK_Work_systemUsers_SystemUserId",
                        column: x => x.SystemUserId,
                        principalTable: "systemUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_educations_SystemUserId",
                table: "educations",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Work_SystemUserId",
                table: "Work",
                column: "SystemUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "resumes");

            migrationBuilder.DropTable(
                name: "Work");

            migrationBuilder.DropTable(
                name: "systemUsers");
        }
    }
}
