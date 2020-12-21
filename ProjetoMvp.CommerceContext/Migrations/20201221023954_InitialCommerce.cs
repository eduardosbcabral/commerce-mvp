using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvp.CommerceContext.Migrations
{
    public partial class InitialCommerce : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_COMMERCE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SiteId = table.Column<int>(type: "integer", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_COMMERCE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ADDRESS",
                columns: table => new
                {
                    CommerceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: false),
                    ZipCode = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADDRESS", x => x.CommerceId);
                    table.ForeignKey(
                        name: "FK_TB_ADDRESS_TB_COMMERCE_CommerceId",
                        column: x => x.CommerceId,
                        principalTable: "TB_COMMERCE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_SITE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Domain = table.Column<string>(type: "text", nullable: false),
                    CommerceId = table.Column<Guid>(type: "uuid", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SITE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_SITE_TB_COMMERCE_CommerceId",
                        column: x => x.CommerceId,
                        principalTable: "TB_COMMERCE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_SITE_CommerceId",
                table: "TB_SITE",
                column: "CommerceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ADDRESS");

            migrationBuilder.DropTable(
                name: "TB_SITE");

            migrationBuilder.DropTable(
                name: "TB_COMMERCE");
        }
    }
}
