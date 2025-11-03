using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class bfuoa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    Question = table.Column<string>(type: "text", nullable: true),
                    Answer = table.Column<string>(type: "text", nullable: true),
                    FlashcardsListModelId = table.Column<int>(type: "integer", nullable: true),
                    FormerUserFullResponseId = table.Column<int>(type: "integer", nullable: true),
                    FormerResponseId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    FlashcardId = table.Column<int>(type: "integer", nullable: true),
                    UserAnswer = table.Column<string>(type: "text", nullable: true),
                    UserFullResponseId = table.Column<int>(type: "integer", nullable: true),
                    UserRequest_UserId = table.Column<int>(type: "integer", nullable: true),
                    Prompt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_FlashcardId",
                        column: x => x.FlashcardId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_FlashcardsListModelId",
                        column: x => x.FlashcardsListModelId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_FormerResponseId",
                        column: x => x.FormerResponseId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_FormerUserFullResponseId",
                        column: x => x.FormerUserFullResponseId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_UserFullResponseId",
                        column: x => x.UserFullResponseId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseModels_BaseModels_UserRequest_UserId",
                        column: x => x.UserRequest_UserId,
                        principalTable: "BaseModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FlashcardId",
                table: "BaseModels",
                column: "FlashcardId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FlashcardsListModelId",
                table: "BaseModels",
                column: "FlashcardsListModelId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseModels_FormerResponseId",
                table: "BaseModels",
                column: "FormerResponseId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseModels");
        }
    }
}
