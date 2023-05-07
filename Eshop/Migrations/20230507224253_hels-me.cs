using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class helsme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufactureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufactureId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ManufactureId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_Products_Manufacturers_ManufactureId",
                        column: x => x.ManufactureId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufactureId");
                });

            migrationBuilder.CreateTable(
                name: "OrderProduct",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Items = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProduct", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProduct_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPicture",
                columns: table => new
                {
                    ProductPictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPicture", x => x.ProductPictureId);
                    table.ForeignKey(
                        name: "FK_ProductPicture_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorys",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "First Person Shooter" },
                    { 2, "Action" },
                    { 3, "Strategy" },
                    { 4, "Adventure" },
                    { 5, "RolePlay" },
                    { 6, "SEX" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "ManufactureId", "Name" },
                values: new object[,]
                {
                    { 1, "HailStorm" },
                    { 2, "Volvo" },
                    { 3, "BigHard" },
                    { 4, "NotActivision" },
                    { 5, "Bluray Project Blue" },
                    { 6, "Todd Howard" },
                    { 7, "RecycleSoft" },
                    { 8, "Popstar Games" },
                    { 9, "EEEEEEEeee" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "IsDeleted", "ManufactureId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 5, false, 8, "Grand Thug Auto 6: Watch Me NAE NAE", 69m },
                    { 2, 4, false, 6, "The elder scrolls 6: Shimmering Booty", 420m },
                    { 3, 6, false, 9, "Only Hands", 0m },
                    { 4, 1, false, 1, "Call Of Booty: Black Hens 1", 1000m },
                    { 5, 1, false, 1, "Call Of Booty: Black Hens 2", 1000m },
                    { 6, 1, false, 1, "Call Of Booty: Black Hens 3", 1000m },
                    { 7, 1, false, 1, "Call Of Booty: Black Hens 4", 1000m },
                    { 8, 6, false, 1, "Call Of Booty: Modern FartFare", 100m },
                    { 9, 6, false, 1, "Call Of Booty: Modern FartFare 2", 100m },
                    { 10, 6, false, 1, "Call Of Booty: Modern FartFare 3", 102m },
                    { 11, 6, false, 1, "Call Of Booty: Modern FartFare 4", 100m },
                    { 12, 6, false, 7, "I ran out of ideas", 600m },
                    { 13, 6, false, 3, "I ran out of ideas 2", 220m }
                });

            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 1 },
                    { 2, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 2 },
                    { 3, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 3 },
                    { 4, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 4 },
                    { 5, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 5 },
                    { 6, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 6 },
                    { 7, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 7 },
                    { 8, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 8 },
                    { 9, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 9 },
                    { 10, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 10 },
                    { 11, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 11 },
                    { 12, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 12 },
                    { 13, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 13 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrderProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureId",
                table: "Products",
                column: "ManufactureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProduct");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
