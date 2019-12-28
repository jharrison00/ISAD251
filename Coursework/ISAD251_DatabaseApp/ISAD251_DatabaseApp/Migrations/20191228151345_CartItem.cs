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
