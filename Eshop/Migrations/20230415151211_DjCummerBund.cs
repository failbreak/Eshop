using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DjCummerBund : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufactureId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "CateGoryId", "Name" },
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
                    { 4, 1, false, 1, "Call Of Booty: Black Hens 1", 1000m }
                });

            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[] { 1, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPicture_ProductId",
                table: "ProductPicture",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufactureId",
                table: "Products",
                column: "ManufactureId",
                principalTable: "Manufacturers",
                principalColumn: "ManufactureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturers_ManufactureId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductPicture");

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categorys",
                keyColumn: "CateGoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "ManufactureId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "CustId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AlterColumn<int>(
                name: "ManufactureId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManufacturerId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImgBytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturers_ManufactureId",
                table: "Products",
                column: "ManufactureId",
                principalTable: "Manufacturers",
                principalColumn: "ManufactureId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
