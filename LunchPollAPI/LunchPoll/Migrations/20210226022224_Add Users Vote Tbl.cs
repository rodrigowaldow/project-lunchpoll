using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LunchPoll.Migrations
{
    public partial class AddUsersVoteTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LunchVote",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    LocalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchVote", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_LunchVote_LunchLocals_LocalId",
                        column: x => x.LocalId,
                        principalTable: "LunchLocals",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LunchVote_LocalId",
                table: "LunchVote",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LunchVote");
        }
    }
}
