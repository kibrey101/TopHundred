using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TopHundred.Migrations
{
    public partial class IcoLinksAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IcoLink",
                table: "IcoLink");

            migrationBuilder.RenameTable(
                name: "IcoLink",
                newName: "IcoLinks");

            migrationBuilder.RenameIndex(
                name: "IX_IcoLink_IcoItemId",
                table: "IcoLinks",
                newName: "IX_IcoLinks_IcoItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IcoLinks",
                table: "IcoLinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IcoLinks_IcoItems_IcoItemId",
                table: "IcoLinks",
                column: "IcoItemId",
                principalTable: "IcoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IcoLinks_IcoItems_IcoItemId",
                table: "IcoLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IcoLinks",
                table: "IcoLinks");

            migrationBuilder.RenameTable(
                name: "IcoLinks",
                newName: "IcoLink");

            migrationBuilder.RenameIndex(
                name: "IX_IcoLinks_IcoItemId",
                table: "IcoLink",
                newName: "IX_IcoLink_IcoItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IcoLink",
                table: "IcoLink",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IcoLink_IcoItems_IcoItemId",
                table: "IcoLink",
                column: "IcoItemId",
                principalTable: "IcoItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
