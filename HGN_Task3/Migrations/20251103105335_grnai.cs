using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class grnai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "UserItemResponses");

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "UserItemResponses",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Success",
                table: "UserItemResponses");

            migrationBuilder.AddColumn<string>(
                name: "UserAnswer",
                table: "UserItemResponses",
                type: "text",
                nullable: true);
        }
    }
}
