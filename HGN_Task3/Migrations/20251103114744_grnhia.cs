using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HGN_Task3.Migrations
{
    /// <inheritdoc />
    public partial class grnhia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Success",
                table: "UserItemResponses",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserAnswer",
                table: "UserItemResponses",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAnswer",
                table: "UserItemResponses");

            migrationBuilder.AlterColumn<bool>(
                name: "Success",
                table: "UserItemResponses",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");
        }
    }
}
