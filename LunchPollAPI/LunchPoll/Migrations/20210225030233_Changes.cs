using Microsoft.EntityFrameworkCore.Migrations;

namespace LunchPoll.Migrations
{
    public partial class Changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LunchLocals",
                newName: "LocalId");

            migrationBuilder.AlterColumn<string>(
                name: "LocalName",
                table: "LunchLocals",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LocalId",
                table: "LunchLocals",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "LocalName",
                table: "LunchLocals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");
        }
    }
}
