using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TopHundred.Migrations
{
    public partial class IcoListLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink");

            migrationBuilder.AlterColumn<Guid>(
                name: "IcoItemId",
                table: "IcoLink",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink",
                column: "IcoItemId",
                principalTable: "IcoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink");

            migrationBuilder.AlterColumn<Guid>(
                name: "IcoItemId",
                table: "IcoLink",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink",
                column: "IcoItemId",
                principalTable: "IcoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
