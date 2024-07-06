using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class updateBranchLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_CourierId",
                table: "Order");

            migrationBuilder.RenameColumn(
                name: "CourierId",
                table: "Order",
                newName: "CourierUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CourierId",
                table: "Order",
                newName: "IX_Order_CourierUserId");

            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "BranchLevels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ModifiedId",
                table: "BranchLevels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrincipalId",
                table: "BranchLevels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId");

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_CreatorId",
                table: "BranchLevels",
                column: "CreatorId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_ModifiedId",
                table: "BranchLevels",
                column: "ModifiedId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BranchLevels_Users_PrincipalId",
                table: "BranchLevels",
                column: "PrincipalId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_CourierUserId",
                table: "Order",
                column: "CourierUserId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_ModifiedId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_BranchLevels_Users_PrincipalId",
                table: "BranchLevels");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Users_CourierUserId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_ModifiedId",
                table: "BranchLevels");

            migrationBuilder.DropIndex(
                name: "IX_BranchLevels_PrincipalId",
                table: "BranchLevels");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "BranchLevels");

            migrationBuilder.DropColumn(
                name: "ModifiedId",
                table: "BranchLevels");

            migrationBuilder.DropColumn(
                name: "PrincipalId",
                table: "BranchLevels");

            migrationBuilder.RenameColumn(
                name: "CourierUserId",
                table: "Order",
                newName: "CourierId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CourierUserId",
                table: "Order",
                newName: "IX_Order_CourierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Users_CourierId",
                table: "Order",
                column: "CourierId",
                principalSchema: "Security",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
