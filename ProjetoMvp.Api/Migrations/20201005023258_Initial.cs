using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvp.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ADDRESS",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADDRESS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_COMMERCE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    AddressId = table.Column<Guid>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMMERCE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_COMMERCE_TB_ADDRESS_AddressId",
                        column: x => x.AddressId,
                        principalTable: "TB_ADDRESS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_PRODUCT_IMAGE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT_IMAGE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_PRODUCT_IMAGE_TB_PRODUCT_ProductId",
                        column: x => x.ProductId,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_SITE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SITE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SITE_TB_COMMERCE_Id",
                        column: x => x.Id,
                        principalTable: "TB_COMMERCE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_COMMERCE_AddressId",
                table: "TB_COMMERCE",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PRODUCT_IMAGE_ProductId",
                table: "TB_PRODUCT_IMAGE",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUCT_IMAGE");

            migrationBuilder.DropTable(
                name: "TB_SITE");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");

            migrationBuilder.DropTable(
                name: "TB_COMMERCE");

            migrationBuilder.DropTable(
                name: "TB_ADDRESS");
        }
    }
}
