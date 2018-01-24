using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TopHundred.Migrations
{
    public partial class AddedIcoLinksEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IcoLink",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IcoItemId = table.Column<Guid>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LinkIcon = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IcoLink", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IcoLink_IcoItems_IcoItemId",
                        column: x => x.IcoItemId,
                        principalTable: "IcoItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IcoLink_IcoItemId",
                table: "IcoLink",
                column: "IcoItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IcoLink");
        }
    }
}
