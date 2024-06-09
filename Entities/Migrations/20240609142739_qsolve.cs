using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class qsolve : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ORDER_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    CUSTOMER_ID = table.Column<int>(type: "int", nullable: false),
                    ORDER_DATETIME = table.Column<DateTime>(type: "date", nullable: false),
                    TOTAL_PRICE = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ORDER_ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_CATEGORY",
                columns: table => new
                {
                    PRODUCT_CATEGORY_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PRODUCT_CATEGORY_NAME = table.Column<string>(type: "string", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_CATEGORY", x => x.PRODUCT_CATEGORY_ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_ITEM",
                columns: table => new
                {
                    ORDER_ITEM_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ProductId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ORDER_QUANTITY = table.Column<int>(type: "int", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal", nullable: false),
                    OrdersOrderId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_ITEM", x => x.ORDER_ITEM_ID);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDERS_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ORDERS",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_ITEM_ORDERS_OrdersOrderId",
                        column: x => x.OrdersOrderId,
                        principalTable: "ORDERS",
                        principalColumn: "ORDER_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    PRODUCT_ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    PRODUCT_NAME = table.Column<string>(type: "string", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "string", nullable: false),
                    ProductCategoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderItemId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.PRODUCT_ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_ORDER_ITEM_OrderItemId",
                        column: x => x.OrderItemId,
                        principalTable: "ORDER_ITEM",
                        principalColumn: "ORDER_ITEM_ID");
                    table.ForeignKey(
                        name: "FK_PRODUCT_PRODUCT_CATEGORY_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "PRODUCT_CATEGORY",
                        principalColumn: "PRODUCT_CATEGORY_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_OrderId",
                table: "ORDER_ITEM",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_ITEM_OrdersOrderId",
                table: "ORDER_ITEM",
                column: "OrdersOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_OrderItemId",
                table: "PRODUCT",
                column: "OrderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_ProductCategoryId",
                table: "PRODUCT",
                column: "ProductCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "PRODUCT_CATEGORY");

            migrationBuilder.DropTable(
                name: "ORDERS");
        }
    }
}
