using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KomunikatorTekstowy.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMessage_UserDetailData_RecipentId",
                table: "UserMessage");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMessage_UserDetailData_SenderId",
                table: "UserMessage");

            migrationBuilder.DropIndex(
                name: "IX_UserMessage_RecipentId",
                table: "UserMessage");

            migrationBuilder.DropIndex(
                name: "IX_UserMessage_SenderId",
                table: "UserMessage");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipentId",
                table: "UserMessage",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "UserMessage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "UserMessage");

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "UserMessage",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipentId",
                table: "UserMessage",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_RecipentId",
                table: "UserMessage",
                column: "RecipentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMessage_SenderId",
                table: "UserMessage",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessage_UserDetailData_RecipentId",
                table: "UserMessage",
                column: "RecipentId",
                principalTable: "UserDetailData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMessage_UserDetailData_SenderId",
                table: "UserMessage",
                column: "SenderId",
                principalTable: "UserDetailData",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
