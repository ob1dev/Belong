using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddressModelMakeGooglePlaceId60Chars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GooglePlaceId",
                table: "Addresses",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 27);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GooglePlaceId",
                table: "Addresses",
                maxLength: 27,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 60);
        }
    }
}
