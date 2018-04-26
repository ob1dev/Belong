using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AccountModelAddPhoneLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Accounts",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Accounts",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);
        }
    }
}
