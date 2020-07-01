using Microsoft.EntityFrameworkCore.Migrations;

namespace ioliu.data.Migrations.ApplicationDb
{
    public partial class app7011641 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PassWord",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassWord",
                table: "AspNetUsers");
        }
    }
}
