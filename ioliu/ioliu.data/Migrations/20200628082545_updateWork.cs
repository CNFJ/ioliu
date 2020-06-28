using Microsoft.EntityFrameworkCore.Migrations;

namespace ioliu.data.Migrations
{
    public partial class updateWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Work_systemUsers_SystemUserId",
                table: "Work");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Work",
                table: "Work");

            migrationBuilder.RenameTable(
                name: "Work",
                newName: "works");

            migrationBuilder.RenameIndex(
                name: "IX_Work_SystemUserId",
                table: "works",
                newName: "IX_works_SystemUserId");

            migrationBuilder.AlterColumn<int>(
                name: "SystemUserId",
                table: "works",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_works",
                table: "works",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_works_systemUsers_SystemUserId",
                table: "works",
                column: "SystemUserId",
                principalTable: "systemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_works_systemUsers_SystemUserId",
                table: "works");

            migrationBuilder.DropPrimaryKey(
                name: "PK_works",
                table: "works");

            migrationBuilder.RenameTable(
                name: "works",
                newName: "Work");

            migrationBuilder.RenameIndex(
                name: "IX_works_SystemUserId",
                table: "Work",
                newName: "IX_Work_SystemUserId");

            migrationBuilder.AlterColumn<int>(
                name: "SystemUserId",
                table: "Work",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Work",
                table: "Work",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_systemUsers_SystemUserId",
                table: "Work",
                column: "SystemUserId",
                principalTable: "systemUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
