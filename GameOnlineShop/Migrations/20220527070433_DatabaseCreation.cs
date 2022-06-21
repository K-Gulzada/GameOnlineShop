using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameOnlineShop.Migrations
{
    public partial class DatabaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDesc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    OrderTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrder", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbGame",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    TechReq = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbGame_DbCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "DbCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbOrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbOrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbOrderDetails_DbGame_GameId",
                        column: x => x.GameId,
                        principalTable: "DbGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbOrderDetails_DbOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "DbOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DbShopCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(nullable: true),
                    ShopCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbShopCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbShopCartItem_DbGame_GameId",
                        column: x => x.GameId,
                        principalTable: "DbGame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbGame_CategoryId",
                table: "DbGame",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrderDetails_GameId",
                table: "DbOrderDetails",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_DbOrderDetails_OrderId",
                table: "DbOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DbShopCartItem_GameId",
                table: "DbShopCartItem",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbOrderDetails");

            migrationBuilder.DropTable(
                name: "DbShopCartItem");

            migrationBuilder.DropTable(
                name: "DbOrder");

            migrationBuilder.DropTable(
                name: "DbGame");

            migrationBuilder.DropTable(
                name: "DbCategory");
        }
    }
}
