using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parcoist.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_product_add_column_links : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "Products");
        }
    }
}
