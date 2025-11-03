using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class bhjji : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FlashcardsListModels",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "FlashcardsListModels");
        }
    }
}
