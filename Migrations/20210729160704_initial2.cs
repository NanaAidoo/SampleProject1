using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleProject1.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VendorId",
                table: "Payments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_VendorId",
                table: "Payments",
                column: "VendorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Vendors_VendorId",
                table: "Payments",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Vendors_VendorId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_VendorId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "VendorId",
                table: "Payments");
        }
    }
}
