using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pikemarketshopper.Migrations
{
    public partial class AddNameImageToShops : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Shops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Shops",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Shops");
        }
    }
}
