using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialMigratoToB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BranchLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LevelType = table.Column<int>(type: "int", nullable: false),
                    SuperID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchLevels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchLevels_BranchLevels_SuperID",
                        column: x => x.SuperID,
                        principalTable: "BranchLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SenderPhone1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SenderPhone2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SenderAreaName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SenderStreet = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecieverName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecieverPhone1 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecieverPhone2 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RecieverCityId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecieverAreaName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RecieverStreet = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClientOrderNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ItemWeight = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    DeliveryFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    COD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CODFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Insured = table.Column<bool>(type: "bit", nullable: false),
                    InsuranceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsuranceValueFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerPickupNo = table.Column<int>(type: "int", nullable: true),
                    CustomerPickupInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClientBR = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginCenter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeliveryCenter = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PickupBRId = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SigningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AdditionalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false, computedColumnSql: "[DeliveryFees] + [AdditionalFees]"),
                    FOD = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FODFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Signed = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VolumeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PickupWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InboundWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HubWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InternalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Voided = table.Column<int>(type: "int", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TripleNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OFDTimes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_Order_BranchLevels_PickupBRId",
                        column: x => x.PickupBRId,
                        principalTable: "BranchLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_City_RecieverCityId",
                        column: x => x.RecieverCityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiverAddress_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SenderAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SecondPhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AreaId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SenderAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SenderAddress_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchLevels_SuperID",
                table: "BranchLevels",
                column: "SuperID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientId",
                table: "Order",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PickupBRId",
                table: "Order",
                column: "PickupBRId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProductTypeId",
                table: "Order",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RecieverCityId",
                table: "Order",
                column: "RecieverCityId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverAddress_AreaId",
                table: "ReceiverAddress",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_SenderAddress_AreaId",
                table: "SenderAddress",
                column: "AreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "ReceiverAddress");

            migrationBuilder.DropTable(
                name: "SenderAddress");

            migrationBuilder.DropTable(
                name: "BranchLevels");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
