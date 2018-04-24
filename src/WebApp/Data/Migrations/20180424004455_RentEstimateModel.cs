using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class RentEstimateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Addresses_AddressId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Accounts");

            migrationBuilder.CreateTable(
                name: "RentEstimates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RentZestimateLow = table.Column<decimal>(nullable: true),
                    RentZestimateHigh = table.Column<decimal>(nullable: true),
                    ExpectedRent = table.Column<decimal>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentEstimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentEstimates_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentEstimates_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentEstimates_AccountId",
                table: "RentEstimates",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RentEstimates_AddressId",
                table: "RentEstimates",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentEstimates");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Accounts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AddressId",
                table: "Accounts",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Addresses_AddressId",
                table: "Accounts",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
