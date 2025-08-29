using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcoist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Products_ProductID",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_Users_UserID",
                table: "UserComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments");

            migrationBuilder.DropColumn(
                name: "LogoDate",
                table: "Logo");

            migrationBuilder.RenameTable(
                name: "UserComments",
                newName: "UserComment");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_UserID",
                table: "UserComment",
                newName: "IX_UserComment_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_ProductID",
                table: "UserComment",
                newName: "IX_UserComment_ProductID");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment",
                column: "UserCommentID");

            migrationBuilder.CreateTable(
                name: "ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductComments_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductComments_UserID",
                table: "ProductComments",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_Products_ProductID",
                table: "UserComment",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_Users_UserID",
                table: "UserComment",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_Products_ProductID",
                table: "UserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_Users_UserID",
                table: "UserComment");

            migrationBuilder.DropTable(
                name: "ProductComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "UserComment",
                newName: "UserComments");

            migrationBuilder.RenameIndex(
                name: "IX_UserComment_UserID",
                table: "UserComments",
                newName: "IX_UserComments_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserComment_ProductID",
                table: "UserComments",
                newName: "IX_UserComments_ProductID");

            migrationBuilder.AddColumn<DateTime>(
                name: "LogoDate",
                table: "Logo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments",
                column: "UserCommentID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Products_ProductID",
                table: "UserComments",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_Users_UserID",
                table: "UserComments",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
