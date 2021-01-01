using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoMvp.CommerceContext.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ACCOUNT",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ACCOUNT", x => x.Id);
                });

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
                    Country = table.Column<string>(type: "text", nullable: false),
                    TempId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ADDRESS", x => x.CommerceId);
                    table.UniqueConstraint("AK_TB_ADDRESS_TempId1", x => x.TempId1);
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
                name: "TB_ACCOUNT");

            migrationBuilder.DropTable(
                name: "TB_ADDRESS");

            migrationBuilder.DropTable(
                name: "TB_SITE");

            migrationBuilder.DropTable(
                name: "TB_COMMERCE");
        }
    }
}
