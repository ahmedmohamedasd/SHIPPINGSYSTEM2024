using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddSenderCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderCityId",
                table: "Order",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Order_SenderCityId",
                table: "Order",
                column: "SenderCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_City_SenderCityId",
                table: "Order",
                column: "SenderCityId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_City_SenderCityId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_SenderCityId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "SenderCityId",
                table: "Order");
        }
    }
}
