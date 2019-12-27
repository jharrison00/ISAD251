using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ISAD251_DatabaseApp.Migrations
{
    public partial class CartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cafe_Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(nullable: false),
                    CustFirstName = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    CustSurName = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafe_Customers", x => x.CustID);
                });

            migrationBuilder.CreateTable(
                name: "Cafe_Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    ProductType = table.Column<string>(unicode: false, maxLength: 5, nullable: true),
                    ProductPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    ProductName = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    ProductCalories = table.Column<int>(nullable: true),
                    ProductDetails = table.Column<string>(type: "text", nullable: true),
                    ProductImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafe_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Cafe_Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    CustID = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrderTotalPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafe_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "fk_Cafe_Orders",
                        column: x => x.CustID,
                        principalTable: "Cafe_Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductsProductId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Cafe_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Cafe_Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cafe_Order_Details",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ProductOrderPrice = table.Column<decimal>(type: "decimal(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cafe_Order_Details", x => new { x.OrderID, x.ProductID });
                    table.ForeignKey(
                        name: "fk_Cafe_Order_Details_O",
                        column: x => x.OrderID,
                        principalTable: "Cafe_Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Cafe_Order_Details_P",
                        column: x => x.ProductID,
                        principalTable: "Cafe_Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cafe_Order_Details_ProductID",
                table: "Cafe_Order_Details",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Cafe_Orders_CustID",
                table: "Cafe_Orders",
                column: "CustID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductsProductId",
                table: "ShoppingCartItems",
                column: "ProductsProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cafe_Order_Details");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Cafe_Orders");

            migrationBuilder.DropTable(
                name: "Cafe_Products");

            migrationBuilder.DropTable(
                name: "Cafe_Customers");
        }
    }
}
