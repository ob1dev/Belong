using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddressModelAddGooglePlaceId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GooglePlaceId",
                table: "Addresses",
                maxLength: 27,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_GooglePlaceId",
                table: "Addresses",
                column: "GooglePlaceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Addresses_GooglePlaceId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "GooglePlaceId",
                table: "Addresses");
        }
    }
}
