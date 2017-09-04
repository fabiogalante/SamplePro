using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SamplePro.Migrations
{
    public partial class AppV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "PostImage");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "PostImage",
                table: "Posts",
                newName: "Content");
        }
    }
}
