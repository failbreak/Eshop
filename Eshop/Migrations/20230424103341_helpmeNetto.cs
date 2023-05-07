using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class helpmeNetto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductPicture",
                columns: new[] { "ProductPictureId", "PictureUrl", "ProductId" },
                values: new object[] { 13, "https://f8n-production.s3.amazonaws.com/creators/profile/gra96ordf-aufkleber-trollface-jpg-cibag1.jpg", 13 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductPicture",
                keyColumn: "ProductPictureId",
                keyValue: 13);
        }
    }
}
