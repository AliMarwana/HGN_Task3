using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class grnana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_FlashcardId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_FlashcardsListModelId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_FormerResponseId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_FormerUserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_UserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_UserId",
                table: "BaseModels");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseModels_BaseModels_UserRequest_UserId",
                table: "BaseModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseModels",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_FlashcardId",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_FlashcardsListModelId",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_FormerUserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_UserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_UserId",
                table: "BaseModels");

            migrationBuilder.DropIndex(
                name: "IX_BaseModels_UserRequest_UserId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "FlashcardId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "FlashcardsListModelId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "FormerUserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "Prompt",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "UserFullResponseId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BaseModels");

            migrationBuilder.DropColumn(
                name: "UserRequest_UserId",
                table: "BaseModels");

            migrationBuilder.RenameTable(
                name: "BaseModels",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_BaseModels_FormerResponseId",
                table: "Users",
                newName: "IX_Users_FormerResponseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FlashcardsListModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlashcardsListModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserFullResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFullResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFullResponses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Prompt = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRequests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Flashcards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    FlashcardsListModelId = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flashcards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flashcards_FlashcardsListModels_FlashcardsListModelId",
                        column: x => x.FlashcardsListModelId,
                        principalTable: "FlashcardsListModels",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateTable(
                name: "UserItemResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FlashcardId = table.Column<int>(type: "integer", nullable: true),
                    UserAnswer = table.Column<string>(type: "text", nullable: true),
                    UserFullResponseId = table.Column<int>(type: "integer", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserItemResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserItemResponses_Flashcards_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "Flashcards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserItemResponses_UserFullResponses_UserFullResponseId",
                        column: x => x.UserFullResponseId,
                        principalTable: "UserFullResponses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flashcards_FlashcardsListModelId",
                table: "Flashcards",
                column: "FlashcardsListModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FormerResponse_FormerUserFullResponseId",
                table: "FormerResponse",
                column: "FormerUserFullResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFullResponses_UserId",
                table: "UserFullResponses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItemResponses_FlashcardId",
                table: "UserItemResponses",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserItemResponses_UserFullResponseId",
                table: "UserItemResponses",
                column: "UserFullResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRequests_UserId",
                table: "UserRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FormerResponse_FormerResponseId",
                table: "Users",
                column: "FormerResponseId",
                principalTable: "FormerResponse",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FormerResponse_FormerResponseId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "FormerResponse");

            migrationBuilder.DropTable(
                name: "UserItemResponses");

            migrationBuilder.DropTable(
                name: "UserRequests");

            migrationBuilder.DropTable(
                name: "Flashcards");

            migrationBuilder.DropTable(
                name: "UserFullResponses");

            migrationBuilder.DropTable(
                name: "FlashcardsListModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "BaseModels");

            migrationBuilder.RenameIndex(
                name: "IX_Users_FormerResponseId",
                table: "BaseModels",
                newName: "IX_BaseModels_FormerResponseId");

            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "BaseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseModels",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FlashcardId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FlashcardsListModelId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormerUserFullResponseId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prompt",
                table: "BaseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "BaseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAnswer",
                table: "BaseModels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserFullResponseId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRequest_UserId",
                table: "BaseModels",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseModels",
                table: "BaseModels",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FlashcardId",
                table: "BaseModels",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FlashcardsListModelId",
                table: "BaseModels",
                column: "FlashcardsListModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FormerUserFullResponseId",
                table: "BaseModels",
                column: "FormerUserFullResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_UserFullResponseId",
                table: "BaseModels",
                column: "UserFullResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_UserId",
                table: "BaseModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_UserRequest_UserId",
                table: "BaseModels",
                column: "UserRequest_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_FlashcardId",
                table: "BaseModels",
                column: "FlashcardId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_FlashcardsListModelId",
                table: "BaseModels",
                column: "FlashcardsListModelId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_FormerResponseId",
                table: "BaseModels",
                column: "FormerResponseId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_FormerUserFullResponseId",
                table: "BaseModels",
                column: "FormerUserFullResponseId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_UserFullResponseId",
                table: "BaseModels",
                column: "UserFullResponseId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_UserId",
                table: "BaseModels",
                column: "UserId",
                principalTable: "BaseModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseModels_BaseModels_UserRequest_UserId",
                table: "BaseModels",
                column: "UserRequest_UserId",
                principalTable: "BaseModels",
                principalColumn: "Id");
        }
    }
}
