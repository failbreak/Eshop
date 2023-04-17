using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class lol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[,]
                {
                    { 2, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 2 },
                    { 3, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 3 },
                    { 4, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 4);
        }
    }
}
