using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class GRAN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_FormerResponse_FormerResponseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FormerResponse");

            migrationBuilder.DropIndex(
                name: "IX_Users_FormerResponseId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FormerResponseId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FlashcardsListModels",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels");

            migrationBuilder.AddColumn<int>(
                name: "FormerResponseId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FlashcardsListModels",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "FormerResponse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FormerUserFullResponseId = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormerResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormerResponse_UserFullResponses_FormerUserFullResponseId",
                        column: x => x.FormerUserFullResponseId,
                        principalTable: "UserFullResponses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_FormerResponseId",
                table: "Users",
                column: "FormerResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_FormerResponse_FormerUserFullResponseId",
                table: "FormerResponse",
                column: "FormerUserFullResponseId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlashcardsListModels_Users_UserId",
                table: "FlashcardsListModels",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FormerResponse_FormerResponseId",
                table: "Users",
                column: "FormerResponseId",
                principalTable: "FormerResponse",
                principalColumn: "Id");
        }
    }
}
