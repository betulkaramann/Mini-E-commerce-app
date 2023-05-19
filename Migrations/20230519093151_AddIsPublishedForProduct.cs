using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model_Binding.Migrations
{
    /// <inheritdoc />
    public partial class AddIsPublishedForProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPublished",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPublished",
                table: "Products");
        }
    }
}
