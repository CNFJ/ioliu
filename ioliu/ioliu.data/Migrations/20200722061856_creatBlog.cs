using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ioliu.data.Migrations
{
    public partial class creatBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "imgs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "blog_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentAddTime = table.Column<string>(nullable: false),
                    CommentModificationTime = table.Column<DateTime>(nullable: false),
                    CommentAddUser = table.Column<string>(nullable: false),
                    CommentContent = table.Column<string>(nullable: false),
                    CommentLike = table.Column<int>(nullable: false),
                    Blog_Id = table.Column<int>(nullable: false),
                    Blog_Comment_ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blog_Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_Tag_Name = table.Column<string>(nullable: true),
                    Blog_Tag_Alias = table.Column<string>(nullable: true),
                    Blog_Tag_Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "blog_Types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Blog_Type_Name = table.Column<string>(nullable: true),
                    Blog_Type_Alias = table.Column<string>(nullable: true),
                    Blog_Type_Context = table.Column<string>(nullable: true),
                    Blog_Type_ParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blog_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogName = table.Column<string>(nullable: false),
                    BlogAddTime = table.Column<string>(nullable: false),
                    BlogModificationTime = table.Column<DateTime>(nullable: false),
                    BlogAddUser = table.Column<string>(nullable: false),
                    BlogContent = table.Column<string>(nullable: false),
                    BlogLike = table.Column<int>(nullable: false),
                    BlogReply = table.Column<int>(nullable: false),
                    BlogBrowse = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blog_Comments");

            migrationBuilder.DropTable(
                name: "blog_Tags");

            migrationBuilder.DropTable(
                name: "blog_Types");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.AlterColumn<string>(
                name: "GroupName",
                table: "imgs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
