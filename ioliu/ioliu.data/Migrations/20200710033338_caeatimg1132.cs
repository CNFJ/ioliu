using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ioliu.data.Migrations
{
    public partial class caeatimg1132 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_educations_systemUsers_SystemUserId",
                table: "educations");

            migrationBuilder.DropForeignKey(
                name: "FK_works_systemUsers_SystemUserId",
                table: "works");

            migrationBuilder.DropTable(
                name: "systemUsers");

            migrationBuilder.DropIndex(
                name: "IX_works_SystemUserId",
                table: "works");

            migrationBuilder.DropIndex(
                name: "IX_educations_SystemUserId",
                table: "educations");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "educations");

            migrationBuilder.CreateTable(
                name: "imgs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imgName = table.Column<string>(nullable: false),
                    imgPath = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imgs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "imgs");

            migrationBuilder.AddColumn<int>(
                name: "SystemUserId",
                table: "educations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "systemUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IDCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Nation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWorld = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemUsers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_works_SystemUserId",
                table: "works",
                column: "SystemUserId");

            migrationBuilder.CreateIndex(
                name: "IX_educations_SystemUserId",
                table: "educations",
                column: "SystemUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_educations_systemUsers_SystemUserId",
                table: "educations",
                column: "SystemUserId",
                principalTable: "systemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_works_systemUsers_SystemUserId",
                table: "works",
                column: "SystemUserId",
                principalTable: "systemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
