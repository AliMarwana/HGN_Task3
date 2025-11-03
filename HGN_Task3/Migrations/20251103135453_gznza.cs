using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class gznza : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FlashcardsListModels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Flashcards",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Flashcards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FlashcardsListModels_UserId",
                table: "FlashcardsListModels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels");

            migrationBuilder.DropIndex(
                name: "IX_FlashcardsListModels_UserId",
                table: "FlashcardsListModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FlashcardsListModels");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Flashcards");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Flashcards");
        }
    }
}
