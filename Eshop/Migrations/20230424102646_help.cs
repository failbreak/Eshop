using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class help : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 5,
                column: "ProductId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 6,
                column: "ProductId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 8,
                column: "ProductId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 9,
                column: "ProductId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 10,
                column: "ProductId",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 11,
                column: "ProductId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 12,
                column: "ProductId",
                value: 12);

            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[] { 7, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 7 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 5,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 6,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 8,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 9,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 10,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 11,
                column: "ProductId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 12,
                column: "ProductId",
                value: 4);

            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[] { 13, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 4 });
        }
    }
}
