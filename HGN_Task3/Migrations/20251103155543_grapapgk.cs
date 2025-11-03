using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class grapapgk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "UserItemResponses");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswerKnown",
                table: "UserItemResponses",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswerKnown",
                table: "UserItemResponses");

            migrationBuilder.AddColumn<string>(
                name: "UserAnswer",
                table: "UserItemResponses",
                type: "text",
                nullable: true);
        }
    }
}
